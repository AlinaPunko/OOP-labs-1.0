using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Создать класс Пользователь с событиями upgrade и work.В main
//создать некоторое количество объектов (ПО). Подпишите объекты
//на события произвольным образом. Реакция на события может
//быть следующая: обновление версии, вывод сообщений и т.п.
//Проверить результаты изменения объектов после наступления
//событий.
public static class String
{
    public static string DelZnak(string str)//удаление знаков
    {
        char[] znak = { '.', ',', '!', '?', '-', ':', '*' };
        for (int i = 0; i < str.Length; i++)
        {
            if (znak.Contains(str[i]))
                str = str.Remove(i, 1);
        }
        return str;
    }
    public static void DelZnak(string str)//удаление знаков
    {
        char[] znak = { '.', ',', '!', '?', '-', ':', '*' };
        for (int i = 0; i < str.Length; i++)
        {
            if (znak.Contains(str[i]))
                str = str.Remove(i, 1);
        }
        Console.WriteLine(str);
    }

    public static string DelProbel(string str)//удаление пробелов
    {
        return str.Replace(" ", string.Empty);//возвр. изменённую строку
    }

    public static string Zaglav(string str)
    {
        for (int i = 0; i < str.Length; i++)
            str = str.Replace(str[i], Char.ToUpper(str[i]));
        return str;
    }

    public static string Letter(string str)
    {
        for (int i = 0; i < str.Length; i++)
            str = str.Replace(str[i], Char.ToLower(str[i]));
        return str;
    }
}
namespace Lab9
{
    public class User
    {
        public bool isworking;
        public int version;
        public delegate void Upgrade(string message);
        public delegate void Work(string message);
        public event Upgrade changeversion;
        public event Work changework;

        public User(int version, bool isworking)
        {
            this.version = version;
            this.isworking = isworking;
        }

        public void Upgrading(int vers)
        {
            version = vers;
            changeversion?.Invoke("Новая версия " + version + "\n");
        }

        public void Working()
        {
            isworking = !(isworking);
            changework?.Invoke("Работает ли? :" + isworking + "\n");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            User Excel = new User(3, true);
            User Word = new User(5, false);
            User Paint = new User(7, false);
            Excel.changeversion += (string message) => Console.WriteLine(message);
            Excel.changework += (string message) => Console.WriteLine(message);
            Excel.Working();
            Excel.Upgrading(12);
            Word.changeversion += (string message) => Console.WriteLine(message);
            Word.Upgrading(16);
            Paint.changework += (string message) => Console.WriteLine(message);
            Paint.Working();

            Console.WriteLine("--------------String--------------");
            string str = "А!П!Е!Л!Ь!С!И!Н        о*р*а*н*ж*е*в*ы*й*";
            Func<string, string> A = null;
            A += String.DelZnak;
            Console.WriteLine("До: {0}\nПосле: {1}\n", str, str = A(str));
            A += String.DelProbel;
            Console.WriteLine("До: {0}\nПосле: {1}\n", str, str = A(str));
            A += String.Zaglav;
            Console.WriteLine("До: {0}\nПосле: {1}\n", str, str = A(str));
            A += String.Letter;
            Console.WriteLine("До: {0}\nПосле: {1}\n", str, str = A(str));


            Action<string> B;
            B = String.DelZnak;
            B(str);
        }
    }
}