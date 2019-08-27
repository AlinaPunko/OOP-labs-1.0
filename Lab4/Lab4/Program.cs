using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

//Класс Одномерный массив.Дополнительно перегрузить
//следующие операции: - разность со скалярным значением; >
//проверка на вхождение элемента; !=  проверка на
//неравенство массивов; +  объединение массивов
//Методы расширения:
//1) Удаление гласных из строки
//2) Удаление первых пяти элементов
namespace Lab4
{
    static class MathObject
    {
        public static int Max(params int[] arr)
        {
            Array.Sort(arr);
            return arr[arr.Length - 1];
        }

        public static int Min(params int[] arr)
        {
            Array.Sort(arr);
            return arr[0];
        }

        public static int Lenght(params int[] arr)
        {
            return arr.Length;
        }
        public static String DeleteVowels(this String str)
        {
            string result = "";
            result = Regex.Replace(str, "[еуэоаыиюeyuioa]?", "");
            return result;
        }
        public static Massiv FiveElem(this Massiv v)
        {
            Massiv v0 = new Massiv(v.Index - 5);
            for (int i = 0; i < v0.Index; i++)
            {
                v0[i] = v[i + 5];
            }
            return v0;
        }
    }
    class Massiv
    {
        public class Date
        {
            private int DayValue;
            private int MonthValue;
            private int YearValue;

            public Date(int day, int month, int year)
            {
                this.Day = day;
                this.Month = month;
                this.Year = year;
            }

            public int Day
            {
                get
                {
                    return DayValue;
                }
                set
                {

                    DayValue = value;

                }
            }
            private int Month
            {
                get
                {
                    return MonthValue;
                }
                set
                {
                    MonthValue = value;
                }
            }
            public int Year
            {
                get
                {
                    return YearValue;
                }
                set
                {
                    YearValue = value;
                }
            }
        }
        private int hIndex;
        public int[] massiv;
        public Massiv(int Index)// конструктор класса
        {
            hIndex = Index;
            massiv = new int[Index];
        }
        public int Index
        {
            get { return hIndex; }

        }
        public int this[int NumOfElement]
        {
            get
            {
                return massiv[NumOfElement];
            }
            set
            {
                massiv[NumOfElement] = value;
            }
        }
        public static Massiv operator - (Massiv x, Massiv y)
        {
            Massiv temp = new Massiv(x.Index);
            for (int i = 0; i < temp.Index; i++)
            {
                temp[i] = x[i] - y[i];
            }
            return temp;
        }
        public static bool operator ==(Massiv x, Massiv y)
        {
            for (int i = 0; i < x.Index; i++)
            {
                if (x[i] == y[i])
                    continue;
                else
                    return false;
            }
            return true;
        }
        public static bool operator !=(Massiv x, Massiv y)
        {
            for (int i = 0; i < x.Index; i++)
            {
                if (x[i] != y[i])
                    return true;
                else
                    continue;
            }
            return false;
        }
        public static Massiv operator +(Massiv x, Massiv y)
        {
            Massiv temp = new Massiv(x.Index + y.Index);
            for (int i = 0; i < x.Index; i++)
            {
                temp[i] = x[i];
            }
            for (int i = 0; i < y.Index; i++)
            {
                temp[i + x.Index] = y[i];
            }
            return temp;
        }
        public static int operator >(Massiv x, int a)//определение операции >
        {
            for (int i = 0; i < x.Index; i++)
            {
                if (x[i] == a)
                    continue;
                else
                    return 0;
            }
            return 1;
        }
        public static int operator <(Massiv x, int a)//определение операции >
        {
            for (int i = 0; i < x.Index; i++)
            {
                if (x[i] != a)
                    continue;
                else
                    return 0;
            }
            return 1;
        }
        public void Print(int NumOfElement)
        {
            Console.Write(massiv[NumOfElement]);
        }
        public void Print()
        {
            for (int i = 0; i < hIndex; i++)
                Console.Write(massiv[i] + " ");

        }
        private Owner owner = new Owner(23052000, "Алина", "БГТУ");
        private Date data = new Date(08, 10, 2017);
        public override bool Equals(object obj)
        {
            if (!(obj is Massiv))
                return false;
            return this == (Massiv)obj;
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }
    public class Owner
    {
        private int Id;
        private string Name;
        private string Org;
        public Owner(int id, string name, string organization)
        {
            Id = id;
            Name = name;
            Org = organization;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Massiv arr1 = new Massiv(10);
            for (int i = 0; i < arr1.Index; i++)
            {
                arr1[i] = i;
            }
            arr1.Print();
            Console.WriteLine();
            Massiv arr2 = new Massiv(10);
            for (int i = 0; i < arr2.Index; i++)
            {
                arr2[i] = i;
            }
            arr2.Print();
            Console.WriteLine();
            Massiv arr3 = new Massiv(10);
            arr3 = arr1 - arr2;
            arr3.Print();
            Console.WriteLine();
            Massiv arr4 = new Massiv(20);
            arr4 = arr1 + arr2;
            arr4.Print();
            Console.WriteLine();
            int chislo, vhod;
            Console.WriteLine("Введите число");
            chislo = Convert.ToInt32(Console.ReadLine());
            vhod = arr1 > chislo;
            if (vhod == 0)
                Console.WriteLine("число входит в arr1");
            else
                Console.WriteLine("число не входит в arr1");
            if (arr1 != arr2)
                Console.WriteLine(" Arr1 != Arr2");
            else
                Console.WriteLine("Arr1 == Arr2");
            string str = "Апельсин";
            Console.WriteLine(str.DeleteVowels());
            Massiv arr5 = new Massiv(15);
            arr5 = arr4.FiveElem();
            arr5.Print();
        }
    }
}

