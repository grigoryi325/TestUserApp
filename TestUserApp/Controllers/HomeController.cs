using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestUserApp.Models;
using System.Data.Entity;

namespace TestUserApp.Controllers
{
    public class HomeController : Controller
    {
        //Обєкт для доступу до бази данних
        private EmployeeContext db = new EmployeeContext();
        
        // GET: Home
        public ActionResult Index()
        {
            //передаємо дані таблиці Employees з відсортованим полем Name за алфавітом
            var employee = db.Employees.OrderBy(b => b.Name);
            return View(employee);
        }

        //Get запит
        public ActionResult Create()
        {
            return View();
        }

        //Post запит
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            try
            {
                //добавляемо дані в таблицю з форми в представленні Create
                db.Employees.Add(employee);
                //зберігаємо зміни
                db.SaveChanges();
                return View();
            }
            catch (Exception e)
            {
                return View();
            }
        }

        //Get запит
        public ActionResult Delete (int id, FormCollection collection)
        {
            try
            {
                //по id який приходе Get запитом з представлення Index при натисканні посилання видалити вибираємо
                //потрібний нам запис з бд 
                Employee employee = db.Employees.Where(x => x.Id == id).FirstOrDefault();
                //видаляємо цей запис
                db.Employees.Remove(employee);
                //зберігаємо зміни
                db.SaveChanges();
                //Перенаправлення на головну сторінку, по суті перезагрузка титульної сторінки в даному випадку
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }   
        }

        //принцип дії аналогічний як і в Delete 
        public ActionResult Edit(int id)
        {
            return View(db.Employees.Where(x => x.Id == id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult Edit(int id, Employee employee)
        {
            try
            {
                //зберігаємо внесені зміни
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }
    }
}