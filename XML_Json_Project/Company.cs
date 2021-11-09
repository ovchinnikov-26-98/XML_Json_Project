using System;
using System.Collections.Generic;
using System.Text;

namespace XML_Json_Project
{
    [Serializable()]
    public class Company : IPrintinformation
    {
        List<Department> _company;
        /// <summary>
        /// Создание компании
        /// </summary>
        public Company()
        {
            _company = new List<Department>();
        }

        public List<Department> company { get => _company; set => _company = value; }
        /// <summary>
        /// Метод №1 - добавление нового департамента
        /// </summary>
        /// <param name="newDepartment"></param>
        public void AddDepartment(Department newDepartment)
        {
            company.Add(newDepartment);
        }
        /// <summary>
        /// Метод №2 - изменение имени Департамента (сокрытие реализации от пользователя)
        /// </summary>
        /// <param name="nameDep"></param>
        private void ChangeNameDepartment(string nameDep)
        {
            foreach (Department d in company)
            {
                string n;
                if (d.NameDepartment == nameDep)
                {
                    Console.Write("Введите новое название департамента: ");
                    Service.TextIsName(Console.ReadLine(), out n, "Название департамента введено некорректно");
                    d.NameDepartment = n;
                    Console.WriteLine("<< Корректировка проведена >>");
                    continue;
                }
            }
        }
        /// <summary>
        /// Метод №3 - изменение даты создания Департамента (сокрытие реализации от пользователя)
        /// </summary>
        /// <param name="nameDep"></param>
        private void ChangeDateCreateDepartment(string nameDep)
        {
            DateTime dt;
            foreach (Department d in company)
            {
                if (d.NameDepartment == nameDep)
                {
                    Console.Write("Введите новую дату создания департамента: ");
                    Service.TextIsDate(Console.ReadLine(), out dt);
                    d.DateCreateDepartment = dt;
                    Console.WriteLine("<< Корректировка проведена >>");
                    continue;
                }
            }
        }
        /// <summary>
        /// Метод №5 - Изменение параметров Департамента
        /// </summary>
        /// <param name="departmentName"></param>
        /// <param name="type_field"></param>
        /// <param name="company"></param>
        /// <returns></returns>
        public static char ChangeDatainDepartment(string departmentName, int type_field, Company myCompany)
        {
            switch (type_field)
            {
                case 1:
                    myCompany.ChangeNameDepartment(departmentName);
                    break;
                case 2:
                    myCompany.ChangeDateCreateDepartment(departmentName);
                    break;
                case 3:
                    short nWorkers;
                    foreach (Department d in myCompany.company)
                    {
                        if (d.NameDepartment == departmentName)
                        {
                            Console.Write("Введите новое кол-во сотрудников департамента: ");
                            Service.TextIsShort(Console.ReadLine(), out nWorkers, "Некорректо введено кол-во сотрудников");
                            d.NumberWorkers = nWorkers;
                            Console.WriteLine("<< Корректировка проведена >>");
                            continue;
                        }
                    }
                    break;

            }
            myCompany.Print();
            return Menu.PrintMenuChangeDepartment();
        }
        /// <summary>
        /// 
        /// </summary>
        public void Print()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("<< Информация о компании >>");
            Console.ResetColor();
            foreach (Department d in this.company)
            {
                d.Print();
            }
            Menu.ClearScreen();
        }
    }
}
