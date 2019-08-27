using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
//Автомобиль, Поезд, Транспортное средство, Экспресс, Двигатель, Вагон.
//Создать частое Транспортное агентство.
//Подсчитать стоимость всех транспортных средств. 
//Провести сортировку автомобилей по расходу топлива.
//Найти транспортное средство в компании, соответствующий заданному диапазону параметров скорости.

namespace Lab5
{

    interface Inter
    {
        void toString();
    }

    public abstract class Transport : Inter
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
        virtual public void toString()
        {
            Console.WriteLine("Используем toString в классе Transport Номер " + number + " Скорость " + speed + " Объект едет в " + cost);
        }

        internal Transport(int a, int b, int c)
        {
            number = 0;
            cost = 0;
            speed = 0;
        }
        internal Transport()
        {
            number = 0;
            cost = 0;
            speed = 0;
        }
    }
    class Train : Transport
    {
        override public void toString()
        {
            Console.WriteLine("Используем toString в классе Train. Номер " + number + " Стоимость" + cost + " Скорость " + speed + "км/ч");
        }
        public Train(int a, int b, int c) : base(a, b, c)
        {
            number = a;
            cost = b;
            speed = c;
        }
        public Train()
        { }
    }
    class Express : Train
    {
        protected int maxspeed;
        public int Maxspeed
        {
            get
            {
                return maxspeed;
            }
            set
            {
                maxspeed = value;
            }
        }
        override public void toString()
        {
            Console.WriteLine("Используем toString в классе Express. Номер " + number + " Стоимость" + cost + " Максимальная скорость " + maxspeed + "км/ч");
        }
        public Express(int a, int b, int c, int d) : base(a, b, c)
        {
            number = a;
            cost = b;
            speed = c;
            maxspeed = d;
        }
    }

    public class Car : Transport, IComparable
    {
        protected string mark;
        public string Mark
        {
            get
            {
                return mark;
            }
            set
            {
                mark = value;
            }
        }
        public int fuel;
        public int Fuel
        {
            get
            {
                return fuel;
            }
            set
            {
                fuel = value;
            }
        }
        override public void toString()
        {
            Console.WriteLine("Используем toString в классе Car. Номер " + number + " Стоимость " + cost + " Скорость " + speed + " км/ч " + " Марка " + mark + " Расход топлива " + fuel);
        }
        public Car(int a, int b, int c, string d, int e) : base(a, b, c)
        {
            number = a;
            cost = b;
            speed = c;
            mark = d;
            fuel = e;

        }
        public int CompareTo(object o)
        {
            Car p = o as Car;
            if (p != null)
                return this.fuel.CompareTo(p.fuel);
            else
                throw new Errorin("Невозможно сравнить два объекта");
        }
    }
    sealed class Engine : Car
    {
        private int force;
        public int Force
        {
            get
            {
                return force;
            }
            set
            {
                force = value;
            }
        }

        public Engine(int a, int b, int c, string d, int e, int f) : base(a, b, c, d, e)
        {
            number = a;
            cost = b;
            speed = c;
            mark = d;
            fuel = e;
            force = f;

        }
        override public void toString()
        {
            Console.WriteLine("Используем toString в классе Engine. Мощность " + force + " л.c.");
        }
    }


    class Vagon : Train
    {
        private int numberofvagon;
        public int Numberofvagon
        {
            get
            {
                return numberofvagon;
            }
            set
            {
                numberofvagon = value;
            }
        }
        override public void toString()
        {
            Console.WriteLine("Используем toString в классе Vagon. Номер " + number + " Стоимость " + cost + " Скорость " + speed + "км/ч, номер вагона " + numberofvagon);
        }
        public Vagon(int a, int b, int c, int d) : base(a, b, c)
        {
            number = a;
            cost = b;
            speed = c;
            numberofvagon = d;
        }
    }

    class Obiect : Object
    {
        public override string ToString()
        {
            Console.WriteLine("Метод ToString");
            return "0";
        }
        public bool Equals()
        {
            Console.WriteLine("Метод Equals");
            return false;
        }
        public override int GetHashCode()
        {
            Console.WriteLine("Метод GetHashCode");
            return 0;
        }
        public new Type GetType()
        {
            Type a = null;
            Console.WriteLine("Метод GetType");
            return a;
        }
    }

    public class Printer
    {
        public void IAmPrinting(Transport arr)
        {
            arr.GetType();
            arr.toString();
        }
    }
    enum Enum { e = 3, n, u = 9, m };
    public struct Structura
    {
        public int size;
        public string name;
    }
    partial class Part
    {
        public void part1()
        {
            Console.WriteLine("Партиал класс ");
        }
    }

    public class TransportAgency

    {
        Transport[] Agency = new Transport[10];
        int i = 0;
        public Transport Ag
        {
            get
            {
                return Agency[i];
            }
            set
            {
                Agency[i] = value;
            }
        }

        public void Add(Transport piece)
        {
            Agency[i] = piece;
            i++;
            if (i > 10)
                throw new Errors("Переполнение");
        }

        public void Delete()
        {
            i--;
            Agency[i] = null;
        }

        public void Vivod()
        {
            for (int k = 0; k < i; k++)
            {
                Agency[i].GetType();
                Agency[i].toString();
            }
        }
        double s = 0;
        public void Stoimoct()
        {
            int count = i;
            for (int i = 0; i < count; i++)
                s += Agency[i].Cost;
            if (count == 0)
                throw new Error("Нет транспортных средств");

            Console.WriteLine($"Стоимость  {s}");
            Console.WriteLine($"Количество {count}");
        }
        public void FindSpeed()
        {
            int firstspeed, secondspeed;
            Console.WriteLine("Введите начальную скорость");
            firstspeed = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите конечную скорость");
            secondspeed = int.Parse(Console.ReadLine());
            if (secondspeed <= firstspeed)
                throw new Errorin("Неверно заданы скорости");
            bool flag = false;
            for (int count = 0; count < i; count++)
            {
                if (Agency[count].speed > firstspeed && Agency[count].speed < secondspeed)
                {
                    Agency[count].toString();
                    flag = true;
                }
            }
            if (flag == false)
                throw new Errors("Нет таких транспортных средств");
        }
    }
    interface Inter<T> where T : new()
    {
        CollectionType<T> Add(CollectionType<T> element, T el);
        CollectionType<T> Del(CollectionType<T> element, T el);
        CollectionType<T> View(CollectionType<T> element);
    }
    public class CollectionType<T> : Inter<T> where T : new()
    {
        public List<T> array;
        public static CollectionType<T> operator +(CollectionType<T> element, T el)
        {
            element.array.Add(el);
            return element;
        }
        public static CollectionType<T> operator -(CollectionType<T> element, T el)
        {
            element.array.Remove(el);
            return element;
        }
        public CollectionType<T> Add(CollectionType<T> element, T el)
        {
            element = element + el;
            return element;
        }
        public CollectionType<T> Del(CollectionType<T> element, T el)
        {
            element = element - el;
            return element;
        }
        public CollectionType<T> View(CollectionType<T> element)
        {
            foreach (T el in element.array)
            {
                Console.WriteLine(el);
            }
            return element;
        }
        public T this[int index]
        {
            get { return array[index]; }
            set { array[index] = value; }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TransportAgency Agent = new TransportAgency();
                Printer Print = new Printer();
                Train poezd1 = new Train(123, 8578947, 89);
                poezd1.toString();
                Train poezd2 = new Train(678, 8745683, 100);
                Train poezd3 = new Train(987, 098009, 85);
                Train poezd4 = new Train(897, 8575, 80);
                Vagon vagon1 = new Vagon(123, 2354, 89, 6);
                vagon1.toString();
                Express express1 = new Express(124, 9465464, 89, 100);
                express1.toString();
                Car car1 = new Car(456, 34534, 90, "Volvo", 10);
                car1.toString();
                Car car2 = new Car(897, 65646, 80, "Opel", 5);
                car1.toString();
                Engine engine1 = new Engine(456, 2343, 45, "Volvo", 10, 100);
                engine1.toString();
                Console.WriteLine();


                Transport[] arr = new Transport[2];
                arr[0] = vagon1;
                arr[1] = car1;
                Print.IAmPrinting(arr[0]);
                Print.IAmPrinting(arr[1]);
                Console.WriteLine();

                Part party = new Part();
                party.part2();
                party.part1();
                Console.WriteLine();
                Console.WriteLine(car1 is Transport);
                Console.WriteLine(car1 is Int32);
                Transport obj1 = express1 as Transport;
                if (obj1 != null)
                    Console.WriteLine("Преобразование удалось");
                else throw new Errors("Это фиаско, братан");


                int en = (int)Enum.e;
                Console.WriteLine("enum " + en);
                Console.WriteLine();


                Agent.Add(poezd1);
                Agent.Add(car1);
                Agent.Add(express1);
                Agent.Add(vagon1);
                Agent.Add(engine1);

                Agent.Stoimoct();
                Agent.FindSpeed();
                Console.WriteLine();



                Car[] ar = new Car[2];
                ar[0] = car1;
                ar[1] = car2;
                Array.Sort(ar);
                foreach (Car p in ar)
                    p.toString();

                int[] aa = null;
                Debug.Assert(aa != null, "Что-то не так");
                Structura struct1 = new Structura { };
                struct1.name = "new";
                struct1.size = 3;
                Console.WriteLine(struct1.size);

                CollectionType<double> i = new CollectionType<double>();
                i.array = new List<double>() { 1, 3, 5 };
                Console.WriteLine("Массив 1:\n");
                i.View(i);
                Console.WriteLine("В массив1 добавим 5:\n");
                i.Add(i, 5);
                Console.WriteLine("Массив1:\n");
                i.View(i);
                Console.WriteLine("Из массива 1 удалим 1:\n");
                i.Del(i, 1);
                Console.WriteLine("Массив 1:\n");
                i.View(i);
                Console.WriteLine();
                Console.WriteLine();


                CollectionType<Train> k = new CollectionType<Train>();
                k.array = new List<Train>(4) { poezd1, poezd2, poezd3 };
                Console.WriteLine("Массив2:\n");
                k.View(k);
                Console.WriteLine("В массив2 добавим еще поезд:\n");
                k.Add(k, poezd4);
                Console.WriteLine("Массив2:\n");
                k.View(k);
                for (int l = 0; l < 4; l++)
                    k[l].toString();
                Console.WriteLine("Из массива 2 удалим поезд:\n");
                k.Del(k, poezd4);
                Console.WriteLine("Массив 2:\n");
                k.View(k);
                for (int l = 0; l < 4; l++)
                    k[l].toString();
                Console.WriteLine();
                Console.WriteLine();
            }
            catch (Error e)
            {
                Console.WriteLine("Используется Error");
            }

            catch (Errorin e)
            {
                Console.WriteLine("Используется Errorin");
            }
            catch (Errors e)
            {
                Console.WriteLine("Используется Errors");
            }
            catch (Exception e)
            {
                Console.WriteLine("Используется Exception");
            }
            finally
            {
                Console.WriteLine("The end");

            }
        }
    }
}
