using System;
using System.Collections.Generic;
using System.Text;

namespace XML_Json_Project
{
    [Serializable()]
    public class Worker : IPrintinformation
    {
        string _secondName;//Фамилия
        string _firstName;//Имя
        short _age;//возраст
        private Department _departmentWorker;//Департамент, в котором он работает
        short _ID;//Идентификатор
        short _salaryWorker;//Размер заработной платы

        public string SecondName { get => _secondName; set => _secondName = value; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public short Age { get => _age; set => _age = value; }
        public short ID { get => _ID; set => _ID = value; }
        public short SalaryWorker { get => _salaryWorker; set => _salaryWorker = value; }
        internal Department DepartmentWorker { get => _departmentWorker; set => _departmentWorker = value; }

        public Worker(string sname, string fname, short age, short id, short salary, Department dep)
        {
            _secondName = sname;
            _firstName = fname;
            _age = age;
            _ID = id;
            _salaryWorker = salary;
            _departmentWorker = dep;
        }
        /// <summary>
        /// Метод №2 - Изменение параметров Рабочих
        /// </summary>
        /// <param name="departmentName"></param>
        /// <param name="type_field"></param>
        /// <param name="myCompany"></param>
        /// <returns></returns>
        public static char ChangeDatainWorkers(string departmentName, int type_field, Company myCompany)
        {
            string nameNew, secondNew;
            short newAge;
            switch (type_field)
            {
                case 1:
                    foreach (Department d in myCompany.company)
                    {
                        if (d.NameDepartment == departmentName)
                        {
                            Console.Write("Введите имя рабочего для корректировки: ");
                            Service.TextIsName(Console.ReadLine(), out nameNew, "Ошибка ввода имени рабочего");
                            foreach (KeyValuePair<int, Worker> work in d.Workers)
                            {
                                if (work.Value.FirstName == nameNew)
                                {
                                    Console.WriteLine("Введите новое имя: ");
                                    Service.TextIsName(Console.ReadLine(), out nameNew, "Ошибка ввода имени рабочего");
                                    work.Value.FirstName = nameNew;
                                    Console.WriteLine("<< Корректировка проведена >>");
                                }
                            }
                            continue;
                        }
                    }
                    break;
                case 2:
                    foreach (Department d in myCompany.company)
                    {
                        if (d.NameDepartment == departmentName)
                        {
                            Console.Write("Введите фамилию рабочего для корректировки: ");
                            Service.TextIsName(Console.ReadLine(), out nameNew, "Ошибка ввода фамилии рабочего");
                            foreach (KeyValuePair<int, Worker> work in d.Workers)
                            {
                                if (work.Value.SecondName == nameNew)
                                {
                                    Console.WriteLine("Введите новую Фамилию: ");
                                    Service.TextIsName(Console.ReadLine(), out nameNew, "Ошибка ввода фамилии рабочего");
                                    work.Value.SecondName = nameNew;
                                    Console.WriteLine("<< Корректировка проведена >>");
                                }
                            }
                            continue;
                        }
                    }
                    break;
                case 3://изменение возраста рабочего
                    foreach (Department d in myCompany.company)
                    {
                        if (d.NameDepartment == departmentName)
                        {
                            Console.Write("Введите имя рабочего : ");
                            Service.TextIsName(Console.ReadLine(), out nameNew, "Ошибка ввода имени рабочего");
                            Console.Write("Введите фамилию рабочего : ");
                            Service.TextIsName(Console.ReadLine(), out secondNew, "Ошибка ввода имени рабочего");
                            foreach (KeyValuePair<int, Worker> work in d.Workers)
                            {
                                if (work.Value.SecondName == secondNew && work.Value.SecondName == nameNew)
                                {
                                    Console.WriteLine("Введите новый возраст: ");
                                    Service.TextIsShort(Console.ReadLine(), out newAge, "Ошибка ввода данных рабочего");
                                    work.Value.Age = newAge;
                                    Console.WriteLine("<< Корректировка проведена >>");
                                }
                            }
                            continue;
                        }
                    }
                    break;
                case 4://изменение зарплаты рабочего
                    foreach (Department d in myCompany.company)
                    {
                        if (d.NameDepartment == departmentName)
                        {
                            Console.Write("Введите имя рабочего : ");
                            Service.TextIsName(Console.ReadLine(), out nameNew, "Ошибка ввода имени рабочего");
                            Console.Write("Введите фамилию рабочего : ");
                            Service.TextIsName(Console.ReadLine(), out secondNew, "Ошибка ввода имени рабочего");
                            foreach (KeyValuePair<int, Worker> work in d.Workers)
                            {
                                if (work.Value.SecondName == secondNew && work.Value.FirstName == nameNew)
                                {
                                    Console.Write("Введите новую зарплату рабочего: ");
                                    Service.TextIsShort(Console.ReadLine(), out newAge, "Ошибка ввода данных рабочего");
                                    work.Value.SalaryWorker = newAge;
                                    Console.WriteLine("<< Корректировка проведена >>");
                                }
                            }



                            continue;
                        }
                    }
                    break;
                case 5://изменение департамента рабочего
                    foreach (Department d in myCompany.company)
                    {
                        if (d.NameDepartment == departmentName)
                        {
                            Console.Write("Введите имя рабочего : ");
                            Service.TextIsName(Console.ReadLine(), out nameNew, "Ошибка ввода имени рабочего");
                            Console.Write("Введите фамилию рабочего : ");
                            Service.TextIsName(Console.ReadLine(), out secondNew, "Ошибка ввода имени рабочего");
                            foreach (KeyValuePair<int, Worker> work in d.Workers)
                            {
                                if (work.Value.SecondName == secondNew && work.Value.SecondName == nameNew)
                                {
                                    Console.Write("Введите новый департамент для рабочего: ");
                                    Service.TextIsName(Console.ReadLine(), out nameNew, "Ошибка ввода данных рабочего");
                                    work.Value.DepartmentWorker = myCompany.company.Find(x => x.NameDepartment.Contains(nameNew));
                                    Console.WriteLine("<< Корректировка проведена >>");
                                }
                            }
                            continue;
                        }
                    }
                    break;
            }
            myCompany.Print();
            return Menu.PrintMenuChangeWorker();
        }
        /// <summary>
        /// 
        /// </summary>
        public void Print()
        {
            Console.WriteLine($"Имя сотрудника: {this.FirstName}");
            Console.WriteLine($"Фамилия сотрудника: {this.SecondName}");
            Console.WriteLine($"Возраст сотрудников: {this.Age}");
            Console.WriteLine($"Идентификатор: {this.ID}");
            Console.WriteLine($"Зарплата сотрудника: {this.SalaryWorker}");
            Console.WriteLine($"Название департамента: {this.DepartmentWorker.NameDepartment}");
            Console.WriteLine();
            Menu.ClearScreen();
        }
    }
}
