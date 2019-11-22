using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections;
using System.Data;


namespace L_7
{
    public abstract class Product///абстракный класс
    {
        public string nameProduct { get; set; }
        public Product(string nameProduct)
        {
            this.nameProduct = nameProduct;

        }

        public override string ToString()
        {
            return base.ToString();
        }

    }


    class PersonException : ArgumentException//////классы исключений
    {
        public int Value { get; }
        public PersonException(string message, int val)
            : base(message)
        {
            Value = val;
        }
    }
    class PException : Exception
    {
        public int Value { get; }
        public PException(string message)
            : base(message)
        {

        }
    }
    class ZeroException : DivideByZeroException//////классы исключений
    {
        public int Value { get; }
        public ZeroException(string message)
            : base(message)
        {
           
        }
    }


    struct ProducST//////структура
    {
        public string nameProduct { get; set; }
        public int id;
        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {nameProduct}");
        }
    }
    interface IComparable
    {
        int CompareTo(object o);
    }
    public class Technic : Product, IComparable<Technic>
    {
        public int id;


        public int age { get; set; }
        public int price { get; set; }
        

        public int Type
        {

            get { return id; }
            set
            {
                
                if (id == 0)
                {
                    throw new ZeroException("Возникло исключение в делении на 0");
                }
               
            }


        }

        public int Age        ////ислючениееее
        {
            get { return age; }
            set
            {
                if(value>5)
                    throw new PersonException("возраст не может быть >5", value);
                else age = value;
            }
        }
        public string TypePro { get; set; }
        public int CompareTo(Technic p)
        {
            Technic tech = p as Technic;
            if (tech != null)
                return this.price.CompareTo(p.price);
            else
                throw new ZeroException("Невозможно сравнить два объекта");
        }


        public Technic(string typeProduct, string nameProduct, int price) : base(nameProduct)
        {
            TypePro = typeProduct;
            this.price = price;
        }
        public virtual void Write()///переопределение
        {

            Console.WriteLine("Тип продукта " + TypePro);
        }
        /*public int PrintAge(Technic a)
        {
            Technic tech = a as Technic;
            if (tech != null)
                return this.price.CompareTo(a.age);
            else
                throw new Exception("Невозможно сравнить два объекта");

        }*/
        public override string ToString()
        {
            return base.ToString();
        }


    }
    struct TechnicST
    {
        public int id;
        public int age { get; set; }
        public int price { get; set; }
        public string TypePro { get; set; }
        public void DisplayInfo()
        {
            Console.WriteLine($"Тип продукта: {TypePro}  id: {id}");
        }
    }

    public class Computer : Technic
    {

        public string color;
        public int memory;
        public string Color
        {
            get { return color; }
            set
            {
                if(value=="red")
                    throw new PException("Нет красного цвета");
                else color = value;
            }
        }
        public Computer(int id, string color, int age, int price, int memory, string typeProduct, string nameProduct) : base(nameProduct, typeProduct, price)
        {
            this.age = age;
            this.price = price;
            this.id = id + 25;
            
            this.color = color;
            this.memory = memory - 1;


        }
      
        
        public override void Write()
        {
            Console.WriteLine("id computer " + id);
            Console.WriteLine("Цвет " + color);
            Console.WriteLine("Память " + memory);
        }
        public override string ToString()
        {
            return base.ToString();
        }

    }

    struct ComputerST
    {

        public int id;
        public string TypePro { get; set; }
        public string color;
        public int memory;
        public void DisplayInfo()
        {
            Console.WriteLine($"Тип продукта: {TypePro}  id: {id} память: {memory} Цвет: {memory}");
        }
    }
    

    public partial class Pad : Technic//////в другой файл
    {
        private int memory;
        public int Memory
        {
            get { return memory; }
            set
            {
                if (value < 0)
                    throw new PersonException("Значение не может быть отрицательным", value);
                else memory = value;
            }
        }
        public Pad(int id, int age, int price, string typeProduct, string nameProduct) : base(nameProduct, typeProduct, price)
        {
            this.age = age;
            this.price = price;
            this.id = id;

            this.nameProduct = nameProduct;
        }
        public override string ToString()
        {
            return base.ToString();
        }

    }
    sealed class Scanner : Technic //бесплодный класс- запрещено наследование
    {
        public string typeSc;
       
        public Scanner(int id, string typeProduct, int age, int price, string nameProduct) : base(nameProduct, typeProduct, price)
        {
            this.id = (id * 10) + 6;
            this.price = price;
            this.age = age;

        }
        public void WritePrint()
        {
            Console.WriteLine("id Print " + id);

        }
        public override string ToString()
        {
            return base.ToString();
        }

    }
    struct ScannerST
    {
        public int id;
        public string TypePro { get; set; }
        public string typeSc;
        public void DisplayInfo()
        {
            Console.WriteLine($"Тип продукта: {TypePro}  id: {id} typeSc: {typeSc}");
        }
    }
    interface SpreedPrint
    {
        void Spreed();

    }
    public class Print : Technic, SpreedPrint
    {
        public string typePrint;
        public Print(int id, string typePrint, int price, string typeProduct, int age, string nameProduct) : base(nameProduct, typeProduct, price)
        {
            this.id = id * 10;
            this.typePrint = typePrint;
            this.age = age;
            this.price = price;
        }
        public void WritePrint()
        {
            Console.WriteLine("id Print " + id);
            Console.WriteLine("Тип Print " + typePrint);


        }
        public void Spreed()
        {
            Console.WriteLine("Скорость печати ");
        }
        public void ToString(Print obj)//переопределение метода ToString
        {
            Console.WriteLine($"{obj.ToString()}");
        }



    }

    enum Operation
    {
        Add = 1,
        Subtract,
        Multiply,
        Divide
    }

    class Printer
    {
        public virtual void IAmPrinting(Object obj)
        {
            if (obj is Pad)
            {
                Pad newPad = (Pad)obj;
                Console.WriteLine(newPad);
                return;
            }
            if (obj is Computer)
            {
                Computer newComputer = (Computer)obj;
                Console.WriteLine(newComputer);
                return;
            }
            if (obj is Print)
            {
                Print newPrint = (Print)obj;
                Console.WriteLine(newPrint);
                return;
            }
            if (obj is Scanner)
            {
                Scanner newScanner = (Scanner)obj;
                Console.WriteLine(newScanner);
                return;
            }

        }
    } //класс printer



    public class LAB///класс-Контейнер
    {
        List<object> userInterface = new List<object>();

        public void AddElement(object obj)///добавлене
        {


            if (obj is Computer)
            {
                obj = (Computer)obj;
                userInterface.Add(obj);
            }
            if (obj is Pad)
            {
                obj = (Pad)obj;
                userInterface.Add(obj);
            }
            if (obj is Print)
            {
                obj = (Print)obj;
                userInterface.Add(obj);
            }

        }
        public void DelElement(object obj)///удаление
        {


            if (obj is Computer)
            {
                obj = (Computer)obj;
                userInterface.Remove(obj);
            }
            if (obj is Pad)
            {
                obj = (Pad)obj;
                userInterface.Remove(obj);
            }
            if (obj is Print)
            {
                obj = (Print)obj;
                userInterface.Remove(obj);
            }

        }
        public void PrintList()//метод вывести список на консоль/метод get
        {
            for (int i = 0; i < userInterface.Count; i++)
            {


                if (userInterface[i] is Computer)
                {
                    Computer myComp;
                    object obj = userInterface[i];
                    myComp = (Computer)obj;
                    Console.WriteLine("Computer \n" + myComp);
                }
                if (userInterface[i] is Pad)
                {
                    Pad myPad;
                    object obj = userInterface[i];
                    myPad = (Pad)obj;
                    Console.WriteLine("Pad \n" + myPad);
                }
                if (userInterface[i] is Print)
                {
                    Print myPrint;
                    object obj = userInterface[i];
                    myPrint = (Print)obj;
                    Console.WriteLine("Print \n" + myPrint);
                }

            }
        }
        public List<object> get()
        {
            return userInterface;
        }


    }
    class ControLAB
    {
        public void printTechnic(LAB o)
        {
            List<object> userInterface = o.get();

            for (int i = 0; i < userInterface.Count; i++)
            {
                if (userInterface[i] is Computer)
                {
                    Computer myComp;
                    object obj = userInterface[i];
                    myComp = (Computer)obj;
                    Console.WriteLine("Computer \n" + myComp);
                }
                if (userInterface[i] is Pad)
                {
                    Pad myPad;
                    object obj = userInterface[i];
                    myPad = (Pad)obj;
                    Console.WriteLine("Pad \n" + myPad);
                }
                if (userInterface[i] is Print)
                {
                    Print myPrint;
                    object obj = userInterface[i];
                    myPrint = (Print)obj;
                    Console.WriteLine("Print \n" + myPrint);
                }
            }

        }
        public static void CountTechnic(LAB o)// количество каждого вида техники
        {
            List<object> userInterface = o.get();
            int comp = 0, pad = 0, print = 0;

            for (int i = 0; i < userInterface.Count; i++)
            {



                if (userInterface[i] is Computer)
                {
                    comp++;

                }

                if (userInterface[i] is Pad)
                {
                    pad++;

                }

                if (userInterface[i] is Print)
                {
                    print++;

                }

            }

            Console.WriteLine("количество Computer: " + comp);
            Console.WriteLine("количество Pad: " + pad);
            Console.WriteLine("количество Printer: " + print);
            Console.WriteLine("всего: " + userInterface.Count);

        }


        public static void SortTechnic(LAB S)///Вывести список техникив порядке убывания цены.
        {
            List<object> userInterface = S.get();




            int CompPrice = 0, PadPrice = 0, PrintPrice = 0;
            for (int i = 0; i < userInterface.Count; i++)
            {
                if (userInterface[i] is Computer)
                {
                    Computer myComp;
                    object obj = userInterface[i];
                    myComp = (Computer)obj;
                    CompPrice = myComp.price;
                }
                if (userInterface[i] is Pad)
                {
                    Pad myPad;
                    object obj = userInterface[i];
                    myPad = (Pad)obj;
                    PadPrice = myPad.price;

                }
                if (userInterface[i] is Print)
                {
                    Print myPrint;
                    object obj = userInterface[i];
                    myPrint = (Print)obj;
                    PrintPrice = myPrint.price;
                }

            }


            object[] myArr = new object[3];
            myArr[0] = CompPrice;
            myArr[1] = PadPrice;
            myArr[2] = PrintPrice;
            Array.Sort(myArr);
            Array.Reverse(myArr);

            foreach (int t in myArr)
            {

                Console.WriteLine(t);

            }
            Console.WriteLine("-------------");




        }

        public static void printAge(LAB S)///Найти технику старше заданного срока службы, больше 2
        {
            List<object> userInterface = S.get();

            for (int i = 0; i < userInterface.Count; i++)
            {



                if (userInterface[i] is Computer)
                {
                    Computer myComp;
                    object obj = userInterface[i];
                    myComp = (Computer)obj;
                    if (myComp.price >= 2)
                        Console.WriteLine("Computer Age: " + myComp.age);
                    else Console.WriteLine("Computer<2");
                }
                if (userInterface[i] is Pad)
                {
                    Pad myPad;
                    object obj = userInterface[i];
                    myPad = (Pad)obj;
                    if (myPad.age >= 2)
                        Console.WriteLine("Pad Age: " + myPad.age);
                    else Console.WriteLine("Pad<2");

                }
                if (userInterface[i] is Print)
                {
                    Print myPrint;
                    object obj = userInterface[i];
                    myPrint = (Print)obj;
                    if (myPrint.age >= 2)
                        Console.WriteLine(" Print Age: " + myPrint.age);
                    else Console.WriteLine(" Print<2");
                }

            }
        }

    }
    /*класс-Контроллер: Найти технику старше заданного срока службы. Подсчитать
количество каждого вида техники. Вывести список техники
в порядке убывания цены.*/
    class SumComparer : IComparer<Technic>
    {
        public int Compare(Technic x, Technic y)
        {
            
            
            if (x.price > y.price)
                return -1;
            else if (x.price < y.price)
                return 1;
            else return 0;
        }
    }

    class Program
    {




        static int Zero(int x, int y)
        {
            if (y == 0)
            {
                PException exc = new PException("ОШИБКА: деление на 0");
                
                throw exc;
            }
            return x / y;
        }

        static int Arr(int x, int y)
        {
            int[] numbers = new int[x];
            numbers[y] = 9;
            if (x < y)
            {
                PException ex = new PException("ОШИБКА: индекс находится вне границ массива");

                throw ex;
            }
            return x;
        }
        static int ExceptionExample(int x, int y)
    {
        if (y == 0)
        {
            Exception a = new Exception();
            a.HelpLink = "htt://www.ISIT5.by";
            a.Data.Add("Время возникновения: ", DateTime.Now);
            throw a;
        }
        return x / y;


    }


        static void Main(string[] args)
        {


            try
            {
                Pad one = new Pad(236, 10,25,"ipad", "Планшет");////ОШИБКА НЕ МОЖЕТЬ БЫТЬ ОТРИЦАТЕЛЬНОЕ ЗНАЧЕНИЕ
                one.Memory = -25;


            }
            catch(PersonException e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
                Console.WriteLine($"Некорректное значение: {e.Value}\n");
            }

            try
            {
                Technic two = new Technic("dv","technic", 25);////НЕ МОЖЕТ БЫТЬ БОЛЬШЕ 5
                two.Age = 6;
            }
            catch(PersonException e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
                Console.WriteLine($"Некорректное значение: {e.Value}\n");
            }

            try
            {
               
                Technic tr = new Technic("dv", "technic", 25);////деление на 0
                tr.Type=0;
                int x = 5;
                int y = x / 0;

            }
            catch (ZeroException e)
            {
                //Console.WriteLine("Исключение1: Возникло исключение в делении на 0");
                Console.WriteLine($"Ошибка: {e.Message}");
               Console.WriteLine($"Некорректное значение: {e.Value}\n");
            }

            try
            {
                Computer three=new Computer(25, "gray", 3, 100, 89, "ПК", "Компьютер");
                three.Color = "red";
            }
            catch(PException e)
            {
                Console.WriteLine($"Ошибка: {e.Message}\n");
                
            }

            Console.WriteLine("-----------------------");


            try///задание 2
            {
                Zero(5, 0);
                
                Arr(3, 5);
            }
            // Обрабатываем общее исключение
            catch (PException e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
                Console.WriteLine("Возникла ошибка");
            }
            /*
            try
            {
                int x = 5;
                int y = x / 0;
                Console.WriteLine($"Результат: {y}");
            }
            
            catch
            {
                Console.WriteLine("Исключение1: Возникло исключение в делении на 0");
            }
            */
            /*try
            {
                int[] numbers = new int[4];
                numbers[7] = 9;     // IndexOutOfRangeException

            }
           
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Исключение2: "+ex.Message);
            }*/
            /*
            try
            {
                object obj = "you";
                int num = (int)obj;     // InvalidCastException
                Console.WriteLine($"Результат: {num}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Возникло исключение DivideByZeroException");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Возникло исключение IndexOutOfRangeException");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Исключение3: {ex.Message}");
            }
            */


            try/// информация об ошибках
            {
                int x = int.Parse(Console.ReadLine());
                int y = int.Parse(Console.ReadLine());
                ExceptionExample(x, y);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message + "\n\n");
                Console.WriteLine(ex.TargetSite + "\n\n");
                Console.WriteLine(ex.StackTrace + "\n\n");
                Console.WriteLine(ex.HelpLink + "\n\n");
                if (ex.Data != null)
                {
                    Console.WriteLine("Сведения: \n\n");
                    foreach (DictionaryEntry d in ex.Data)
                    {
                        Console.WriteLine("->{0} {1}", d.Key, d.Value);
                        Console.WriteLine("\n\n");
                    }

                }

            }
           

            finally
            {
                Console.WriteLine("Блок finally");
            }


            Computer myComp = new Computer(25, "gray", 3, 100, 89, "ПК", "Компьютер");///AGE 3


            myComp.Write();


            Console.WriteLine("-------------");
           // Pad myPad = new Pad(236, "1024/768", "black", 1, 125, "ipad", "Планшет");///AGE1

            //myPad.Write();
            Console.WriteLine("-------------");
            Print myPrint = new Print(6943, "Print", 25, "FGHFJ", 2, "Принтер");///AGE2
            myPrint.WritePrint();

            /*
            int index;

            index = -40;

            
            Debug.Assert(index > -1);           //Assert
            Object[] myArray = new Object[index];          
            myArray[0] = myComp;
            //myArray[1] = myPad;
            myArray[2] = myPrint;

            
            Printer myPrinter = new Printer();

            foreach (Object myObj in myArray)
            {
                myPrinter.IAmPrinting(myObj);
            }



            LAB myLAB = new LAB();

            myLAB.AddElement(myComp);
           /// myLAB.AddElement(myPad);
            myLAB.AddElement(myPrint);

            myLAB.DelElement(myComp);
            Console.WriteLine("-------------");
            ControLAB.CountTechnic(myLAB);

            myLAB.PrintList();
            Console.WriteLine("-------------");

            ControLAB.SortTechnic(myLAB);

            ControLAB.printAge(myLAB);
           */
            Console.Read();

        }

    }
}


