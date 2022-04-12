using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW7
{
    class Program
    {
        static int CatLength()
        {
            int catLength = 0;
            if (File.Exists(@"D:\Unity\SkillBox\HomeWork\C#\HW7\data.txt"))
            {
                using (StreamReader readCat = new StreamReader(@"D:\Unity\SkillBox\HomeWork\C#\HW7\data.txt"))
                {
                    while (!readCat.EndOfStream)
                    {
                        readCat.ReadLine();
                        catLength++;
                    }
                }
            }
            return catLength;
        }

        static int LastId(Employee[] Emp)
        {
            int lastId = 0;
            int i = 0;
            using (StreamReader readCat = new StreamReader(@"D:\Unity\SkillBox\HomeWork\C#\HW7\data.txt"))
            {
                while (!readCat.EndOfStream)
                {
                    Emp[i] = new Employee(readCat.ReadLine());
                    lastId = Emp[i].ID;
                    i++;
                }
            }
            return lastId;
        }

        static void PrintCat(Employee[] Emp)
        {
            int i = 0;
            while (Emp.Length > i)
            {
                Console.WriteLine(Emp[i].Print());
                i++;
            }
        }

        static void PrintOne(Employee[] Emp)
        {
            Console.Write("\nВведите ID элемента, который хотите вывести на экран: ");
            int l = int.Parse(Console.ReadLine());
            Console.WriteLine(Emp[l - 1].Print());
            Console.ReadKey();
            Console.Clear();
            PrintCat(Emp);
            ChooseAction(Emp);
        }

        static void AddEmployer(Employee[] Emp)
        {
            int lastId = LastId(Emp);
            string input = null;

            if (lastId >= Emp.Length - 1)
            {
                Array.Resize(ref Emp, Emp.Length + 1);
            }

            Console.Write("\nВведите имя нового сотрудника: ");
            string inputedName = Console.ReadLine();
            input = $"{lastId + 1}#{DateTime.Now}#{inputedName}";
            Emp[Emp.Length - 1] = new Employee(input);

            using (StreamWriter sw = new StreamWriter(@"D:\Unity\SkillBox\HomeWork\C#\HW7\data.txt", true, Encoding.Unicode))
            {
                sw.WriteLine(Emp[Emp.Length - 1].Print());
            }
            Console.ReadKey();
            Console.Clear();
            PrintCat(Emp);
            ChooseAction(Emp);
        }

        static void RemoveEmployer(Employee[] Emp)
        {
            // * Продублировать массив
            // * Выбрать номер удаляемого элемента
            // * Заполнить новый массив от 0 до элемента
            // * Заполнить массив от элемента + 1 до конца
            // * Перезаписать файл, стерев всё старое

            Employee[] EmpTemp = new Employee[Emp.Length - 1];
            Console.Write("\nВведите НОМЕР строки, которую хотите удалить:");
            int lineToDelete = Int32.Parse(Console.ReadLine());

            for (int i = 0; i < lineToDelete - 1; i++) EmpTemp[i] = Emp[i];
            for (int i = lineToDelete; i < EmpTemp.Length + 1; i++) EmpTemp[i - 1] = Emp[i];

            Emp = EmpTemp;

            using (StreamWriter sw = new StreamWriter(@"D:\Unity\SkillBox\HomeWork\C#\HW7\data.txt", false, Encoding.Unicode))
            {
                for (int i = 0; i < Emp.Length; i++)
                {
                    sw.WriteLine(Emp[i].Print());
                }
            }
            Console.ReadKey();
            Console.Clear();
            PrintCat(Emp);
            ChooseAction(Emp);
        }

        static void EditEmployer(Employee[] Emp)
        {
            // * Продублировать массив
            // * Выбрать номер изменяемого элемента
            // * Заполнить новый массив от 0 до элемента
            // Добавить в новый массив изменённый элемент
            // Заполнить массив от элемента + 1 до конца
            // Перезаписать файл, стерев всё старое

            Employee[] EmpTemp = new Employee[Emp.Length];
            Console.Write("\nВведите НОМЕР строки, которую хотите изменить:");
            int lineToEdit = Int32.Parse(Console.ReadLine());

            for (int i = 0; i < lineToEdit - 1; i++) EmpTemp[i] = Emp[i];

            string input = null;
            Console.Write("Введите новый ID: ");
            string inputedId = Console.ReadLine().ToString();
            Console.Write("Введите новое имя: ");
            string inputedName = Console.ReadLine().ToString();
            input = $"{inputedId}#{DateTime.Now}#{inputedName}";
            EmpTemp[lineToEdit - 1] = new Employee(input);

            for (int i = lineToEdit; i < EmpTemp.Length; i++) EmpTemp[i] = Emp[i];

            Emp = EmpTemp;

            using (StreamWriter sw = new StreamWriter(@"D:\Unity\SkillBox\HomeWork\C#\HW7\data.txt", false, Encoding.Unicode))
            {
                for (int i = 0; i < Emp.Length; i++)
                {
                    sw.WriteLine(Emp[i].Print());
                }
            }
            Console.ReadKey();
            Console.Clear();
            PrintCat(Emp);
            ChooseAction(Emp);
        }

        static void PrintCatInDates(Employee[] Emp)
        {
            // * Ввести нижнюю дату
            // * Ввести верхнюю дату
            // * Создать цикл, который выводит элементы массива от и до

            Console.Write("Введите дату с которой начнётся список (в формате дд.мм.гггг): ");
            DateTime lowDate = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Введите дату с которой закончится список(в формате дд.мм.гггг): ");
            DateTime highDate = Convert.ToDateTime(Console.ReadLine());


            for (int i = 0; i < Emp.Length; i++)
            {
                if (lowDate <= Emp[i].CreateTime && highDate >= Emp[i].CreateTime)
                {
                    Console.WriteLine(Emp[i].Print());
                }
            }
            Console.ReadKey();
            Console.Clear();
            PrintCat(Emp);
            ChooseAction(Emp);
        }

        static void SortAndPrintCatInDates(Employee[] Emp)
        {
            DateTime[] tempKeyArr = new DateTime[Emp.Length];
            for (int i = 0; i < tempKeyArr.Length; i++)
            {
                tempKeyArr[i] = Emp[i].CreateTime;
            }

            Console.WriteLine("\nОтсортировать по возрастанию \t- введите u");
            Console.WriteLine("Отсортировать по убыванию \t- введите d");
            switch (Console.ReadLine())
            {
                case ("d"):
                    {
                        Array.Reverse(tempKeyArr);
                        Array.Sort(tempKeyArr, Emp);
                        Console.ReadKey();
                        Console.Clear();
                        PrintCat(Emp);
                        ChooseAction(Emp);
                        break;
                    }
                case ("u"):
                    {
                        Array.Sort(tempKeyArr, Emp);
                        Console.ReadKey();
                        Console.Clear();
                        PrintCat(Emp);
                        ChooseAction(Emp);
                        break;
                    }
                default: Console.WriteLine("Вы ввели что-то непонятное. До свидания!"); break;
            }
        }

        static void SortAndPrintCatInID(Employee[] Emp)
        {
            int[] tempKeyArr = new int[Emp.Length];
            for (int i = 0; i < tempKeyArr.Length; i++)
            {
                tempKeyArr[i] = Emp[i].ID;
            }
            Array.Sort(tempKeyArr, Emp);

            using (StreamWriter sw = new StreamWriter(@"D:\Unity\SkillBox\HomeWork\C#\HW7\data.txt", false, Encoding.Unicode))
            {
                for (int i = 0; i < Emp.Length; i++)
                {
                    sw.WriteLine(Emp[i].Print());
                }
            }

            Console.ReadKey();
            Console.Clear();
            PrintCat(Emp);
            ChooseAction(Emp);        
        }

        static void ChooseAction(Employee[] Emp)
        {
            int inputedKey;
            Console.WriteLine();
            Console.WriteLine("Выберите действие (введите с клавиатуры нужную цифру):");
            Console.WriteLine("1 - Найти сотрудника по ID");
            Console.WriteLine("2 - Добавить нового сотрудника");
            Console.WriteLine("3 - Удалить запись о сотруднике");
            Console.WriteLine("4 - Изменить данные о сотруднике");
            Console.WriteLine("5 - Загрузка записей в выбранном диапазоне дат");
            Console.WriteLine("6 - Сортировка по возрастанию и убыванию даты");
            Console.WriteLine("7 - Сортировка по возрастанию ID (по умолчанию): ");
            Console.WriteLine("0 - Выход из программы");
            inputedKey = Int32.Parse(Console.ReadLine());

            switch (inputedKey)
            {
                case 1: PrintOne(Emp); break;
                case 2: AddEmployer(Emp); break;
                case 3: RemoveEmployer(Emp); break;
                case 4: EditEmployer(Emp); break;
                case 5: PrintCatInDates(Emp); break;
                case 6: SortAndPrintCatInDates(Emp); break;
                case 7: SortAndPrintCatInID(Emp); break;
                default: Console.WriteLine("До свидания!"); break;
            }
        }

        static void Main(string[] args)
        {
            int catLenght = CatLength();
            Employee[] Emp = new Employee[catLenght];
            int lastId = LastId(Emp);

            PrintCat(Emp);
            ChooseAction(Emp);
        }
    }
}