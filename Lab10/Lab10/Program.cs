using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    public class Transport 
    {
        protected int number;
        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
            }
        }
        public int speed;
        public int Speed
        {
            get
            {
                return speed;
            }
            set
            {
                speed = value;
            }
        }
        protected int cost;
        public int Cost
        {
            get
            {
                return cost;
            }
            set
            {
                cost = value;
            }
        }
        public override string ToString()
        {
            return "Используем toString в классе Transport Номер " + number + " Скорость " + speed + " Стоимость " + cost;
        }

        internal Transport(int num, int money, int v)
        {
            number = num;
            cost = money;
            speed = v;
        }
    }
    public class Student
    {
        public string name;
        public string university;
        public Student(string yourname, string youruniversity)          
        {
            name = yourname;
            university = youruniversity;
        }
        public override string ToString()
        {
            return name + " " + university;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList arr = new ArrayList();
            arr.Add("строка");
            Student Me = new Student("Alina", "Belstu");
            arr.Add(Me);
            int k = 0;
            int chislo = 0;
            Random rnd = new Random();
            while (k < 5)
            {
                chislo = rnd.Next(0, 100);
                arr.Add(chislo);
                k++;
            }
            Console.WriteLine("Введите номер элемента");
            string n;
            n = Console.ReadLine();
            int l = Convert.ToInt32(n);
            arr.RemoveAt(l);
            Console.WriteLine("Количество элементов " + arr.Count);
            int i = 0;
            while (i < arr.Count)
            {
                Console.WriteLine(arr[i]);
                i++;
            }

            Dictionary<int, long> dict = new Dictionary<int, long>
            {
                [3] = 467,
                [1] = 4,
                [2] = 78,
                [4] = 4670,
            };
            foreach (KeyValuePair<int, long> element in dict)
                Console.WriteLine("Число разрядов: {0}, Число: {1}", element.Key, element.Value);
            Console.WriteLine();
            dict.Add(5, 36777);
            dict[7] = 6347855;
            dict.Remove(3);
            i = 1;
            while (i <= 2)
            {
                dict.Remove(i);
                i++;
            }
            foreach (KeyValuePair<int, long> element in dict)
                Console.WriteLine("Число разрядов: {0}, Число: {1}", element.Key, element.Value);
            Console.WriteLine();
            List<long> mylist = new List<long>();
            foreach (KeyValuePair<int, long> element in dict)
                mylist.Add(element.Value);
            foreach (long element in mylist)
                Console.WriteLine(element);
            Console.WriteLine("Введите элемент");
            string el;
            el = Console.ReadLine();
            long elem = Convert.ToInt64(el);
            Console.WriteLine(mylist[mylist.IndexOf(elem)]);



            Dictionary<string, Transport> dict1 = new Dictionary<string, Transport>();
            Transport express1 = new Transport(45, 3565674, 70);
            Transport car1 = new Transport(567, 78657, 120);
            Transport car2 = new Transport(563, 56785, 100);
            Transport plain1 = new Transport(988, 356546454, 200);
            Transport train2 = new Transport(2345, 43563443, 80);
            Transport train1 = new Transport(123, 67467467, 90);
            dict1.Add("Экспресс1", express1);
            dict1.Add("Машина1", car1);
            dict1.Add("Самолёт1", plain1);
            dict1.Add("Поезд2", train2);
            dict1.Add("Машина2", car2);
            foreach (KeyValuePair<string, Transport> element in dict1)
                Console.WriteLine("Название: {0}, Характеристики: {1}", element.Key, element.Value);
                    
            Console.WriteLine();
            dict1.Add("Поезд1",train1);
            dict1.Remove("Экспресс1");
            i = 1;
            while (i <= 2)
            {
                dict1.Remove("Машина" + i);
                i++;
            }
            foreach (KeyValuePair<string, Transport> element in dict1)
                Console.WriteLine("Название: {0}, Характеристики: {1}", element.Key, element.Value);
            Console.WriteLine();
            List<Transport> mylist1 = new List<Transport>();
            foreach (KeyValuePair<string, Transport> element in dict1)
                mylist1.Add(element.Value);
            foreach (Transport element in mylist1)
                Console.WriteLine(" Характеристики:" + " " + element.Number + " " + element.Cost + " " + element.Speed);               
            Transport element1 = mylist1[2];
            if (mylist1.Contains(element1) == true)
                Console.WriteLine("Содержит");
            else Console.WriteLine("Не содержит");



            ObservableCollection<Student> p = new ObservableCollection<Student>();
            void p_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        Student newStudent = e.NewItems[0] as Student;
                        Console.WriteLine("Добавлен новый объект: " + newStudent.name);
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        Student oldStudent = e.OldItems[0] as Student;
                        Console.WriteLine("Удален объект: " + oldStudent.name);
                        break;
                }
            }

            p.CollectionChanged += p_CollectionChanged;

            Student chel1 = new Student("Xenia", "BSTU");
            Student chel2 = new Student("Nikita", "BSTU");
            Student chel3 = new Student("Sanya", "BSTU");
            p.Add(chel1);
            p.Add(chel2);
            p.Add(chel1);
            p.Add(chel3);
            p.RemoveAt(1);
            foreach (Student s in p)
                Console.WriteLine(s.ToString());
        }
    }
}
