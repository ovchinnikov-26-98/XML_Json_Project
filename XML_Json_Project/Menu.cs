using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace XML_Json_Project
{
    class Menu
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="departmentName"></param>
        /// <param name="type_sort"></param>
        /// <param name="company"></param>
        public static void SortWorkers(string departmentName, int type_sort, List<Department> company)
        {
            if (company.Capacity == 0)
            {
                Console.Clear();
                Console.WriteLine("В компании нет данных о департаментах");
            }
            else
            {
                switch (type_sort)
                {
                    case 1:
                        Console.WriteLine("Департамент после сортировки по фамилии сотрудников");

                        foreach (Department d in company)
                        {
                            if (d.NameDepartment == departmentName)
                            {
                                d.Workers = d.Workers.OrderBy(x => x.Value.SecondName).ToDictionary(x => x.Key, x => x.Value);
                                d.Print();
                                continue;
                            }
                        }
                        break;
                    case 2:
                        Console.WriteLine("Департамент после сортировки по возрасту сотрудников");
                        foreach (Department d in company)
                        {
                            if (d.NameDepartment == departmentName)
                            {
                                d.Workers = d.Workers.OrderBy(x => x.Value.Age).ToDictionary(x => x.Key, x => x.Value);
                                d.Print();
                                continue;
                            }
                        }
                        break;
                    case 3:
                        Console.WriteLine("Департамент после сортировки по зарплате сотрудников");
                        foreach (Department d in company)
                        {
                            if (d.NameDepartment == departmentName)
                            {
                                d.Workers = d.Workers.OrderBy(x => x.Value.Age).ToDictionary(x => x.Key, x => x.Value);
                                d.Print();
                                continue;
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        /// <summary>
        /// Сохранение данных в формате json
        /// </summary>
        /// <param name="myCompany"></param>
        /// <param name="outputfilename"></param>
        public static void WriteDictionaryAsJson(List<Department> myCompany, string outputfilename)
        {
            string json = JsonConvert.SerializeObject(myCompany);
            File.WriteAllText(outputfilename, json);

            /*
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(List<Department>));
            MemoryStream ms = new MemoryStream();
            js.WriteObject(ms, myCompany); //Does the serialization.

            StreamWriter streamwriter = new StreamWriter(outputfilename);
            streamwriter.AutoFlush = true; // Without this, I've run into issues with the stream being "full"...this solves that problem.

            ms.Position = 0; //ms contains our data in json format, so let's start from the beginning
            StreamReader sr = new StreamReader(ms); //Read all of our memory
            streamwriter.WriteLine(sr.ReadToEnd()); // and write it out.

            ms.Close(); //Shutdown everything since we're done.
            streamwriter.Close();
            sr.Close();
            */
        }
        /// <summary>
        /// Очистка консоли
        /// </summary>
        public static void ClearScreen()
        {
            Console.WriteLine("Для продолжения нажмите любую кнопку....");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Повторите выбор меню: ");
        }
        /// <summary>
        /// Печать основного меню
        /// </summary>
        /// <returns></returns>
        public static char PrintMenu()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("[1] - для работы с департаментами нажмите 1");
            Console.WriteLine("[2] - для работы с рабочими нажмите 2");
            Console.WriteLine("[3] - для сохранения данных нажмите 3");
            Console.WriteLine("[4] - для сортировки сотрудников в департаменте нажмите 4");
            Console.WriteLine("[5] - для вывода информации о компании нажмите 5");
            Console.WriteLine("Для выхода - введите Q");
            Console.ResetColor();
            return Console.ReadKey().KeyChar;
        }
        /// <summary>
        /// Печать сообщения об ошибке и повтор выбора меню
        /// </summary>
        /// <returns></returns>
        public static char ErrorMessage()
        {
            Console.WriteLine();
            Console.WriteLine("Введен некорректный символ. Повторите выбор меню: ");
            return Console.ReadKey().KeyChar;
        }
        /// <summary>
        /// Меню работы с департаментами
        /// </summary>
        /// <returns></returns>
        public static char PrintMenuDepartment()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("[1] - для создания департамента введите 1");
            Console.WriteLine("[2] - для удаления департамента введите 2");
            Console.WriteLine("[3] - для корректировки департамента введите 3");
            Console.WriteLine("Для выхода из меню - введите Q");
            Console.ResetColor();
            return Console.ReadKey().KeyChar;
        }
        /// <summary>
        /// Меню сортировки департаментов
        /// </summary>
        /// <returns></returns>
        public static char PrintMenuSortWorkers()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("[1] - для сортировки сотрудников по Фамилии введите 1");
            Console.WriteLine("[2] - для сортировки сотрудников по возрасту введите 2");
            Console.WriteLine("[3] - для сортировки сотрудников по зарплате введите 3");
            Console.WriteLine("Для выхода из меню - введите Q");
            Console.ResetColor();
            return Console.ReadKey().KeyChar;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static char PrintMenuWorkers()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("[1] - для создания рабочего введите 1");
            Console.WriteLine("[2] - для удаления рабочего введите 2");
            Console.WriteLine("[3] - для корректировки рабочего введите 3");
            Console.WriteLine("Для выхода из меню - введите Q");
            Console.ResetColor();
            return Console.ReadKey().KeyChar;
        }

        public static char PrintMenuChangeDepartment()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("[1] - для изменения департаментов в наименовании введите 1");
            Console.WriteLine("[2] - для изменения департаментов по дате создания введите 2");
            Console.WriteLine("[3] - для изменения департаментов по кол-ву сотрудников введите 3");
            Console.WriteLine("Для выхода из меню - введите Q");
            Console.ResetColor();
            return Console.ReadKey().KeyChar;
        }

        public static char PrintMenuChangeWorker()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("[1] - для изменения имени рабочего введите 1");
            Console.WriteLine("[2] - для изменения фамилии рабочего введите 2");
            Console.WriteLine("[3] - для изменения возраста рабочего введите 3");
            Console.WriteLine("[4] - для изменения зарплаты рабочего введите 4");
            Console.WriteLine("[5] - для изменения департамента рабочего введите 5");
            Console.WriteLine("Для выхода из меню - введите Q");
            Console.ResetColor();
            return Console.ReadKey().KeyChar;
        }
    }
}
