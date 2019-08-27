using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{

    interface Interable
    {
        void toString();
    }

    public abstract class Transport : Interable
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
    public class Reflector
    {
        public int Sq(int a)
        { return a ^ 2; }
        public Type type;
        public Reflector(string type)
        {
            this.type = Type.GetType(type, false, true);
        }
        public void AboutClass()
        {
            using (FileStream fstream = new FileStream("class.txt", FileMode.OpenOrCreate))
            {
                foreach (MemberInfo info in type.GetMembers())
                {
                    byte[] array = Encoding.Default.GetBytes(info.DeclaringType + " - " + info.MemberType + " - " + info.Name + " \n");
                    fstream.Write(array, 0, array.Length);
                }
            }
        }
        public void PublicMethods()
        {
            using (FileStream fstream = new FileStream("methods.txt", FileMode.OpenOrCreate))
            {
                foreach (MethodInfo method in type.GetMethods())
                {
                    if (method.IsPublic)
                    {
                        byte[] array = Encoding.Default.GetBytes(method.Name + " \n");
                        fstream.Write(array, 0, array.Length);
                    }
                }
            }
        }
        public void SpecifiedMethods(string arg)
        {
            using (FileStream fstream = new FileStream("specified_methods.txt", FileMode.OpenOrCreate))
            {
                foreach (MethodInfo method in type.GetMethods())
                {
                    ParameterInfo[] parameters = method.GetParameters();
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        if (arg.Contains(parameters[i].ParameterType.Name))
                        {
                            byte[] array1 = Encoding.Default.GetBytes(method.ReturnType.Name + " - " + method.Name + " ( ");
                            fstream.Write(array1, 0, array1.Length);
                            byte[] array2 = Encoding.Default.GetBytes(parameters[i].ParameterType.Name + " " + parameters[i].Name);
                            fstream.Write(array2, 0, array2.Length);
                            byte[] array3 = Encoding.Default.GetBytes(" , ");
                            if (i + 1 < parameters.Length)
                            {
                                fstream.Write(array3, 0, array3.Length);
                            }
                            fstream.Write(Encoding.Default.GetBytes(") \n"), 0, Encoding.Default.GetBytes(") \n").Length);
                        }
                    }
                }
            }
        }
        public void Fields()
        {
            using (FileStream fstream = new FileStream("fields.txt", FileMode.OpenOrCreate))
            {
                foreach (FieldInfo field in type.GetFields())
                {
                    byte[] array = Encoding.Default.GetBytes(field.FieldType + " - " + field.Name + "\n");
                    fstream.Write(array, 0, array.Length);
                }
            }
        }
        public void Properties()
        {
            using (FileStream fstream = new FileStream("properties.txt", FileMode.OpenOrCreate))
            {
                foreach (PropertyInfo prorertie in type.GetProperties())
                {
                    byte[] array = Encoding.Default.GetBytes(prorertie.PropertyType + " - " + prorertie.Name + " \n");
                    fstream.Write(array, 0, array.Length);
                }
            }
        }
        public void Interfaces()
        {
            using (FileStream fstream = new FileStream("interfaces.txt", FileMode.OpenOrCreate))
            {
                foreach (Type interfaces in type.GetInterfaces())
                {
                    byte[] array = Encoding.Default.GetBytes(interfaces.Name + "\n");
                    fstream.Write(array, 0, array.Length);
                }
            }
        }
        public void RunTimeMethod(string type, string method)
        {
            Assembly asm = Assembly.LoadFrom(@"E:\лабы\ООП\Lab12\bin\Debug\Lab12.exe");
            Type newType = asm.GetType(type);
            int k = 3;
            object programm = Activator.CreateInstance(newType, k);
            MethodInfo newMethod = newType.GetMethod(method);
            object result = newMethod.Invoke(programm, new object[] { });
            Console.WriteLine("Method of another instanse: {0}\nMethod's value: {1}", method, result);
        }
    }
    class Program
    {

        static void Main(string[] args)
        {

            Reflector reflector = new Reflector("Lab12.Transport");
            reflector.AboutClass();
            reflector.PublicMethods();
            reflector.Fields();
            reflector.Properties();
            reflector.Interfaces();
            reflector.SpecifiedMethods("Object");
        }
    }
}

