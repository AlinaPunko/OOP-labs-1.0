using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.IO.Compression;
namespace Lab13
{
    static class PAADirInfo
    {
        public static void FileCount(string path)
        {
            Console.WriteLine("Количество файлов в каталоге {0}: {1}", path, Directory.GetFiles(path).Length);
            Console.WriteLine();
        }
        public static void CreationTime(string path)
        {
            Console.WriteLine("Время создания каталога {0}: {1}", path, Directory.GetCreationTime(path));
            Console.WriteLine();
        }
        public static void SubdirectoriesCount(string path)
        {
            Console.WriteLine("Количество подкаталогов в каталоге {0}: {1}", path, Directory.GetDirectories(path).Length);
            Console.WriteLine();
        }
        public static void ParentDirectory(string path)
        {
            Console.WriteLine("Родительский каталог каталога {0}: {1}", path, Directory.GetParent(path));
            Console.WriteLine();
        }

    }
    static class PAADiskInfo
    {
        public static void FreeSpace(string driveName)
        {
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.Name == driveName && drive.IsReady)
                    Console.WriteLine("Доступный объем на диске {0} : {1}", driveName.First(), drive.AvailableFreeSpace);
            }
            Console.WriteLine();
        }
        public static void FileSystemInfo(string driveName)
        {
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.Name == driveName && drive.IsReady)
                    Console.WriteLine("Тип файловой системы и формат диска {0} : {1}, {2}", driveName.First(), drive.DriveType, drive.DriveFormat);
            }
            Console.WriteLine();
        }
        public static void DrivesFullInfo()
        {
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady)
                {
                    Console.WriteLine("Имя: {0}", drive.Name);
                    Console.WriteLine("Объем: {0}", drive.TotalSize);
                    Console.WriteLine("Доступный объем: {0}", drive.AvailableFreeSpace);
                    Console.WriteLine("Метка тома: {0}", drive.VolumeLabel);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
    static class PAAFileInfo
    {
        public static void FullPath(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            Console.WriteLine("Полный путь к файлу {0}: {1}", fileInfo.Name, fileInfo.FullName);
            Console.WriteLine();
        }
        public static void BasicFileInfo(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            Console.WriteLine("Имя файла: {0}", fileInfo.Name);
            Console.WriteLine("Расширение файла: {0}", fileInfo.Extension);
            Console.WriteLine("Размер файла: {0}", fileInfo.Length);
            Console.WriteLine();
        }
        public static void CreationTime(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            Console.WriteLine("Время создания файла {0}: {1}", fileInfo.Name, fileInfo.CreationTime);
            Console.WriteLine();
        }
    }
    static class PAAFileManager
    {
        /// Записывает в txt файл содержимое 1-ого уровня указанного диска
        public static void InspectDrive(string driveName)
        {

            DirectoryInfo dir = new DirectoryInfo(driveName);
            FileInfo[] file = dir.GetFiles();
            Directory.CreateDirectory(@"PAAInspect");
            using (StreamWriter sw = new StreamWriter(@"PAAInspect\paadirinfo.txt"))
            {
                foreach (DirectoryInfo d in dir.GetDirectories())
                    sw.WriteLine(d.Name);
                foreach (FileInfo f in file)
                    sw.WriteLine(f.Name);
            }
            File.Copy(@"PAAInspect\paadirinfo.txt", @"PAAInspect\paadirinfo_renamed.txt");
            File.Delete(@"PAAInspect\paadirinfo.txt");
        }
        /// Создает папку PAAFiles, копирует в нее файлы из заданного пути по заданному расширению и перемещает папку в PAAFiles
        public static void CopyFiles(string path, string ext)
        {
            string dirpath = @"PAAFiles";
            Directory.CreateDirectory(dirpath);
            DirectoryInfo di = new DirectoryInfo(path);
            FileInfo[] files = di.GetFiles();
            foreach (FileInfo file in files)
            {
                if (file.Extension == ext)
                    file.CopyTo($@"{dirpath}\{file.Name}");
            }
            Directory.Move(@"PAAFiles", @"PAAInspect\PAAFiles");
            //DirectoryInfo dInfo = new DirectoryInfo("E:\\SAAFiles");
            //dInfo.Create();

            //string[] files2 = Directory.GetFiles("E:\\");

            //foreach (string s in files2)
            //{

            //    File.Copy(s, "E:\\SAAFiles\\" + new FileInfo(s).Name);

            //}
            //foreach (FileInfo Info in dInfo.GetFiles())
            //{
            //    Info.CopyTo(path + "\\" + Info.Name, true);
            //}
        }
        /// Архивация и разархивация
        public static void ArchiveUnarchive()
        {
            string dirpath = @"PAAInspect\PAAFiles";
            string zippath = @"PAAInspect\PAAFiles.zip";
            string unzippath = @"Unzipped";
            ZipFile.CreateFromDirectory(dirpath, zippath);
            ZipFile.ExtractToDirectory(zippath, unzippath);
        }

    }
    static class PAALog
    {
        static FileSystemWatcher watcher = new FileSystemWatcher
        {
            Path = @"E:\лабы\ООП\Lab13\Lab13\bin\Debug",
            IncludeSubdirectories = true,
            NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName
        };
        public static void Start()
        {
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            watcher.EnableRaisingEvents = true;
        }

        public static void SearchByDate(string date)
        {
            watcher.EnableRaisingEvents = false;
            using (StreamReader sr = new StreamReader("paalogfile.txt"))
            {
                while (!sr.EndOfStream)
                {
                    if (sr.ReadLine().StartsWith(date))
                        Console.WriteLine(sr.ReadLine());
                }
            }
        }
        private static void OnChanged(object sender, FileSystemEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("paalogfile.txt", true))
            {
                sw.WriteLine(DateTime.Now + "   " + e.ChangeType + "    путь: " + e.FullPath);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Начало слежения за Debug в папке с программой
            Thread thread = new Thread(PAALog.Start);
            thread.Start();

            // Демонстрация работы LIADiskInfo
            PAADiskInfo.FreeSpace("C:\\");
            PAADiskInfo.FileSystemInfo("C:\\");
            PAADiskInfo.DrivesFullInfo();

            // Демонстрация работы PAADirInfo
            PAADirInfo.FileCount(@"E:\лабы\ООП");
            PAADirInfo.CreationTime(@"E:\лабы\ООП");
            PAADirInfo.SubdirectoriesCount(@"E:\лабы\ООП");
            PAADirInfo.ParentDirectory(@"E:\лабы\ООП");

            // Демонстрация работы PAAFileInfo
            PAAFileInfo.FullPath(@"D:\in.txt");
            PAAFileInfo.BasicFileInfo(@"D:\in.txt");
            PAAFileInfo.CreationTime(@"D:\in.txt");

            // Демонстрация работы PAAFileManager
            PAAFileManager.InspectDrive(@"E:\");
            PAAFileManager.CopyFiles(@"PAAInspect", ".txt");
            PAAFileManager.ArchiveUnarchive();

            // Остановка процесса наблюдения
            thread.Abort();

            // Удаление каталогов
            Console.WriteLine("Удалить каталоги? 1 - да");
            int key = int.Parse(Console.ReadLine());
            if (key == 1)
            {
                System.IO.Directory.Delete("PAAInspect", true);
                System.IO.Directory.Delete("Unzipped", true);
            }
            // Демонстрация работы PAALog
            //PAALog.SearchByDate("12.12.2018");
        }
    }
}
