using System;
using System.Collections.Generic;
using System.Text;

namespace XML_Json_Project
{
    [Serializable()]
    public class Department : IPrintinformation
    {
        private string _nameDepartment;//Наименование
        private DateTime _dateCreateDepartment;//Дата создания
        private short _numberWorkers;//Количество сотрудников
        private Dictionary<int, Worker> _workers;//Список сотрудников
        public string NameDepartment { get => _nameDepartment; set => _nameDepartment = value; }
        public DateTime DateCreateDepartment { get => _dateCreateDepartment; set => _dateCreateDepartment = value; }
        public short NumberWorkers { get => _numberWorkers; set => _numberWorkers = value; }
        public Dictionary<int, Worker> Workers { get => _workers; set => _workers = value; }

        /// <summary>
        /// Конструктор департамента
        /// </summary>
        /// <param name="nameDepartment"></param>
        /// <param name="dateCreateDepartment"></param>
        /// <param name="numberWorkers"></param>
        public Department(string nameDepartment, DateTime dateCreateDepartment, short numberWorkers)
        {
            NameDepartment = nameDepartment;
            DateCreateDepartment = dateCreateDepartment;
            NumberWorkers = numberWorkers;
            _workers = new Dictionary<int, Worker>(numberWorkers);
        }
        /// <summary>
        /// Метод №1 - добавление рабочего в Департамент
        /// </summary>
        /// <param name="sname"></param>
        /// <param name="fname"></param>
        /// <param name="age"></param>
        /// <param name="id"></param>
        /// <param name="salary"></param>
        public void AddWorker(string sname, string fname, short age, short id, short salary)
        {
            _workers.Add(this.Workers.Count + 1, new Worker(sname, fname, age, id, salary, this));
        }
        /// <summary>
        /// 
        /// </summary>
        public void Print()
        {
            Console.WriteLine($"Название департамента:               {this.NameDepartment}");
            Console.WriteLine($"Дата создания департамента:          {this.DateCreateDepartment.ToString("d")}");
            Console.WriteLine($"Количество сотрудников департамента: {this.NumberWorkers}");
            Console.WriteLine();
            foreach (KeyValuePair<int, Worker> kvp in this.Workers)
            {
                kvp.Value.Print();
            }
            Menu.ClearScreen();
        }
    }
}
