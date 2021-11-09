using System;
using System.Linq;

namespace XML_Json_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Company myCompany = new Company();
            string nameDep;
            DateTime createTime;
            short numberWorker;
            ///////////////////
            string SName;//Фамилия
            string FName;//Имя
            short age;//возраст
            string DepWorker;//Департамент, в котором он работает
            short ID;//Идентификатор
            short SWorker;//Размер заработной платы

            Console.WriteLine("<<--- Добро пожаловать в информационную систему! --->>");
            //Печать основного меню
            char input = Menu.PrintMenu();
            string dep = "";
            while (input != 'Q')//вход в меню 1
            {
                switch (input)
                {
                    case '1':
                        input = Menu.PrintMenuDepartment();
                        Console.WriteLine();
                        while (input != 'Q')//вход в подменю "Департамент"
                        {
                            switch (input)
                            {
                                case '1'://Создание департамента
                                    Console.Write("Введите название департамента: ");
                                    Service.TextIsName(Console.ReadLine(), out nameDep, "Название не может содержать цифпы, повторите ввод: ");

                                    Console.Write("Введите дату создания департамента (формат: день.месяц.год): ");
                                    Service.TextIsDate(Console.ReadLine(), out createTime);

                                    Console.Write("Введите количество сотрудников департамента: ");
                                    Service.TextIsShort(Console.ReadLine(), out numberWorker, "Некорректный ввод, повторите: ");

                                    myCompany.AddDepartment(new Department(nameDep, createTime, numberWorker));

                                    myCompany.Print();

                                    input = Menu.PrintMenuDepartment();
                                    break;
                                case '2'://Удаление департамента
                                    Console.Write("Введите название департамента: ");
                                    myCompany.company = myCompany.company.Where(x => x.NameDepartment != Console.ReadLine()).ToList();

                                    Console.WriteLine("Корректировка проведена");
                                    myCompany.Print();

                                    input = Menu.PrintMenuDepartment();
                                    break;
                                case '3'://Корректировка данных департамента
                                    input = Menu.PrintMenuChangeDepartment();
                                    Console.Write("Введите название департамента для корректировки: ");

                                    dep = Console.ReadLine();
                                    switch (input)
                                    {
                                        case '1'://изменения департамента в наименовании                                           
                                            input = Company.ChangeDatainDepartment(dep, 1, myCompany);
                                            break;
                                        case '2'://изменения департамента по дате создания                                         
                                            input = Company.ChangeDatainDepartment(dep, 2, myCompany);
                                            break;
                                        case '3'://изменения департамента по кол-ву сотрудников                                            
                                            input = Company.ChangeDatainDepartment(dep, 3, myCompany);
                                            break;
                                        default:
                                            input = Menu.ErrorMessage();
                                            break;
                                    }
                                    break;
                                default:
                                    input = Menu.ErrorMessage();
                                    break;
                            }
                        }
                        input = Menu.PrintMenu();
                        break;
                    case '2':
                        input = Menu.PrintMenuWorkers();
                        Console.WriteLine();
                        while (input != 'Q')//вход в подменю "Рабочий"
                        {
                            switch (input)
                            {
                                case '1'://Создание рабочего
                                    Console.Write("Введите Фамилию рабочего: ");
                                    Service.TextIsName(Console.ReadLine(), out SName, "Фамилия не может содержать цифры, повторите ввод");

                                    Console.Write("Введите Имя рабочего: ");
                                    Service.TextIsName(Console.ReadLine(), out FName, "Имя не может содержать цифры, повторите ввод");

                                    Console.Write("Введите возраст рабочего: ");
                                    Service.TextIsShort(Console.ReadLine(), out age, "Некорректный ввод возраста, повторите: ");

                                    Console.Write("Введите идентификатор рабочего: ");
                                    Service.TextIsShort(Console.ReadLine(), out ID, "Идентификатор не может содержать символы, повторите ввод: ");

                                    Console.Write("Введите размер заработной платы рабочего: ");
                                    Service.TextIsShort(Console.ReadLine(), out SWorker, "Некорректный ввод, повторите: ");

                                    Console.Write("Введите наименование департамента: ");
                                    DepWorker = Console.ReadLine();

                                    if (myCompany.company.Count == 0)
                                    {
                                        Console.WriteLine("Данный департамент не существует в структуре компании. Необходимо создать его");
                                    }
                                    else
                                    {
                                        myCompany.company.Find(x => x.NameDepartment == DepWorker).AddWorker(SName, FName, age, ID, SWorker);
                                        myCompany.Print();
                                    }
                                    input = Menu.PrintMenuWorkers();
                                    break;
                                case '2'://Удаление рабочего
                                    Console.Write("Введите название департамента: ");
                                    myCompany.company = myCompany.company.Where(x => x.NameDepartment != Console.ReadLine()).ToList();

                                    Console.WriteLine("Корректировка проведена");

                                    myCompany.Print();
                                    input = Menu.PrintMenuWorkers();
                                    break;
                                case '3'://Корректировка данных рабочего
                                    input = Menu.PrintMenuChangeWorker();
                                    Console.Write("Введите название департамента для поиска рабочего: ");
                                    dep = Console.ReadLine();

                                    switch (input)
                                    {
                                        case '1'://изменения имени рабочего
                                            input = Worker.ChangeDatainWorkers(dep, 1, myCompany);
                                            myCompany.Print();
                                            break;
                                        case '2'://изменения фамилии рабочего
                                            input = Worker.ChangeDatainWorkers(dep, 2, myCompany);
                                            myCompany.Print();
                                            break;
                                        case '3'://изменения возраста рабочего
                                            input = Worker.ChangeDatainWorkers(dep, 3, myCompany);
                                            myCompany.Print();
                                            break;
                                        case '4'://изменения зарплаты рабочего
                                            input = Worker.ChangeDatainWorkers(dep, 4, myCompany);
                                            myCompany.Print();
                                            break;
                                        case '5'://изменения департамента рабочего
                                            input = Worker.ChangeDatainWorkers(dep, 5, myCompany);
                                            myCompany.Print();
                                            break;
                                        default:
                                            input = Menu.ErrorMessage();
                                            break;
                                    }
                                    break;
                                default:
                                    input = Menu.ErrorMessage();
                                    break;
                            }
                        }
                        input = Menu.PrintMenu();
                        break;
                    case '3'://Сохранение в файл JSON
                        Menu.WriteDictionaryAsJson(myCompany.company, System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "JSONtestfile.txt"));
                        Console.WriteLine("Запись файла окончена");
                        Console.WriteLine("Повторите выбор меню: ");

                        input = Menu.PrintMenu();
                        break;
                    case '4'://Сортировка данных сотрудников в департаменте
                        input = Menu.PrintMenuSortWorkers();
                        Console.WriteLine();
                        Console.Write("Введите название департамента: ");

                        string department = Console.ReadLine();
                        switch (input)
                        {
                            case '1':
                                Menu.SortWorkers(department, 1, myCompany.company);
                                break;
                            case '2':
                                Menu.SortWorkers(department, 2, myCompany.company);
                                break;
                            case '3':
                                Menu.SortWorkers(department, 3, myCompany.company);
                                break;
                            default:
                                input = Menu.ErrorMessage();
                                break;
                        }
                        Console.WriteLine("Повторите выбор меню: ");
                        input = Menu.PrintMenu();
                        break;
                    case '5':
                        myCompany.Print();
                        input = Menu.PrintMenu();
                        break;
                    default:
                        input = Menu.ErrorMessage();
                        Console.WriteLine();
                        break;
                }

            }
            Console.WriteLine("<< Работа программы закончена >>");
            Console.ReadKey();
        }
    }
}
