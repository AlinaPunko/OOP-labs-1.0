using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Configuration;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Xml;
using System.Xml.Linq;


namespace Lab14
{
    
    class DifferentPC
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public string Country { get; set; }
    }
    [Serializable]

    public abstract class Transport /*: Inter*/
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
    [Serializable]

    class DifferentTransport
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
    }
    [Serializable]

    public class Train : Transport
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
    [Serializable]

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
    [Serializable]

    public class Car : Transport, IComparable
    {
        public Car()
        { }
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
            else throw new Exception("Упс");
        }
    }
    [Serializable]

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
    [Serializable]

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
    //    Сериализация - процесс
    //преобразования объектов в поток байтов
    //(диск, память, сеть)
    //    Десериализация - получение из потока
    //байтов сохраненного объекта

    //XPath представляет язык запросов в XML.Он позволяет выбирать элементы,
    //соответствующие определенному селектору.


    //[Serializable]
    //[DataContract]
    //[KnownType(typeof(Transport))]
    //[KnownType(typeof(Automobil))]
    //[KnownType(typeof(Transport[]))]
    class Program
    {
        static void Main(string[] args)
        {
            Train poezd1 = new Train(123, 8578947, 89);            
            Vagon vagon1 = new Vagon(123, 2354, 89, 6);
            Express express1 = new Express(124, 9465464, 89, 100);
            Car car1 = new Car(456, 34534, 90, "Volvo", 10);
            Engine engine1 = new Engine(456, 2343, 45, "Volvo", 10, 100);
            BinaryFormatter formatter = new BinaryFormatter();
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("poezd.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, poezd1);
                Console.WriteLine("Бинарная сериализация:\nОбъект успешно сериализован");
            }
            using (FileStream fs = new FileStream("poezd.dat", FileMode.OpenOrCreate))
            {
                Train newTrain = (Train)formatter.Deserialize(fs);

                Console.WriteLine("Бинарная десериализация:\nОбъект успешно десериализован");
                Console.WriteLine("Номер: {0}\n" +
                    "Скорость: {1}\n" +
                    "Стоимость: {2}\n" , newTrain.Number, newTrain.Speed, newTrain.Cost);
            }
            Console.WriteLine("==================================");
            XmlSerializer serial = new XmlSerializer(typeof(Car));
            using (FileStream fs = new FileStream("car.xml", FileMode.OpenOrCreate))
            {
                serial.Serialize(fs, car1);
                Console.WriteLine("XML сериализация:\nОбъект успешно сериализован");
            }
            using (FileStream fs = new FileStream("car.xml", FileMode.OpenOrCreate))
            {
                Car newCar = (Car)serial.Deserialize(fs);

                Console.WriteLine("XML десериализация:\nОбъект успешно десериализован");
                Console.WriteLine("Номер: {0}\n" +
                    "Скорость: {1}\n" +
                    "Стоимость: {2}\n"+ "Марка: {3}\n" + "Расход топлива:{4}\n", newCar.Number, newCar.Speed, newCar.Cost,newCar.Mark, newCar.Fuel);
            }
            Console.WriteLine("==================================");
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Express));
            using (FileStream fs = new FileStream("express.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, express1);
                Console.WriteLine("JSON сериализация:\nОбъект сериализован");
            }

            using (FileStream fs = new FileStream("express.json", FileMode.OpenOrCreate))
            {
                Express newexpress = (Express)jsonFormatter.ReadObject(fs);
                Console.WriteLine("JSON десериализация:\nОбъект успешно десериализован");
                Console.WriteLine(
                    "Номер: {0}\n" +
                    "Максимальная скорость: {1}\n" +
                    "Стоимость: {2}\n", newexpress.Number, newexpress.Maxspeed, newexpress.Cost);

            }
            Console.WriteLine("==================================");
            SoapFormatter soapform = new SoapFormatter();
            // получаем поток, куда будем записывать сериализованный объект
            // сохраняет состояние объекта в виде
            //сообщения SOAP(стандартный XML - формат для передачи и приема сообщений от веб - служб)

            using (FileStream fs = new FileStream("engine.soap", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, engine1);
                Console.WriteLine("SOAP сериализация:\nОбъект сериализован");
            }

            // десериализация
            using (FileStream fs = new FileStream("engine.soap", FileMode.OpenOrCreate))
            {
                Engine newengine = (Engine)formatter.Deserialize(fs);

                Console.WriteLine("SOAP десериализация:\nОбъект успешно десериализован");
                Console.WriteLine("Номер: {0}\n" +
                    "Скорость: {1}\n" +
                    "Стоимость: {2}\n" + "Марка: {3}\n" + "Расход топлива:{4}\n" + "Мощность:{5}\n", newengine.Number, newengine.Speed, newengine.Cost, newengine.Mark, newengine.Fuel, newengine.Force);
            }
            Console.WriteLine("==================================");
            Transport[] arr =  new Transport[5];
            arr[0]=poezd1;
            arr[1] = car1;
            arr[2] = engine1;
            arr[3] = vagon1;
            arr[4] = express1;
            BinaryFormatter formatter1 = new BinaryFormatter();
            using (FileStream fs = new FileStream("array.dat", FileMode.OpenOrCreate))
            {
                formatter1.Serialize(fs, arr);
                Console.WriteLine("Сериализация массива:\nОбъект успешно сериализован");
            }
            using (FileStream fs = new FileStream("array.dat", FileMode.OpenOrCreate))
            {
                Transport[] newTransport = (Transport[])formatter.Deserialize(fs);
                Console.WriteLine("Десериализация массива:\nОбъект успешно десериализован");
                foreach (Transport p in newTransport)
                {
                    Console.WriteLine("Номер: {0}\n" +
                                      "Скорость: {1}\n" +
                                      "Стоимость: {2}\n", p.Number, p.Speed, p.Cost);
                }
            }
            Console.WriteLine();
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("LINQ.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            XmlNodeList childnodes = xRoot.SelectNodes("*");
            foreach (XmlNode n in childnodes)
                Console.WriteLine(n.OuterXml);
            XmlNodeList childnodes2 = xRoot.SelectNodes("product");
            foreach (XmlNode n in childnodes2)
                Console.WriteLine(n.SelectSingleNode("@name").Value);
            Console.WriteLine("LINQ To XML");
            Console.WriteLine("Request 1");
            XDocument xdoc = XDocument.Load("LINQ.xml");
            var items = from xe in xdoc.Element("products").Elements("product")
                        where xe.Element("company").Value == "Invasion"
                        select new DifferentPC
                        {
                            Name = xe.Attribute("name").Value,
                            Price = xe.Element("price").Value,
                            Country = xe.Element("country").Value
                        };
            foreach (var item in items)
                Console.WriteLine("{0} - {1} - {2}", item.Name, item.Price, item.Country);
            Console.WriteLine("Request 2");
            var items1 = from xe in xdoc.Element("products").Elements("product")
                         where xe.Element("company").Value == "Lenovo"
                         select new DifferentPC
                         {
                             Name = xe.Attribute("name").Value,
                             Price = xe.Element("price").Value,
                             Country = xe.Element("country").Value
                         };

            foreach (var item in items1)
                Console.WriteLine("{0} - {1} - {2}", item.Name, item.Price, item.Country);
            Console.WriteLine("Request 3");
            var items2 = from xe in xdoc.Element("products").Elements("product")
                         where (xe.Element("company").Value == "Invasion" || xe.Element("company").Value == "Lenovo")
                         select new DifferentPC
                         {
                             Name = xe.Attribute("name").Value,
                             Price = xe.Element("price").Value,
                             Country = xe.Element("country").Value
                         };

            foreach (var item in items2)
                Console.WriteLine("{0} - {1} - {2}", item.Name, item.Price, item.Country);
            
        }
    }
}

