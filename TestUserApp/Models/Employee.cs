using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestUserApp.Models
{
    //модель даних для звязку з таблицею Employees в базі даних
    public class Employee
    {
        //обєкт для визначення поточного часу
        DateTime nowDate = DateTime.Today;
        public int Year;
        //властивості моделі
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public DateTime Date { get; set; }
        public int YearDate
        {
            get
            {
                return Year;
            }
            set
            {
                //визначаємо вік свівробітника
                Year = nowDate.Year - Date.Year;
            }
        }
    }
}