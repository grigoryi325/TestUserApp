using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TestUserApp.Models
{
    //класс для координації роботи Entity Framework з моделлю бази даних Employee
    public class EmployeeContext : DbContext
    {
        public DbSet <Employee> Employees { get; set; }
    }
}