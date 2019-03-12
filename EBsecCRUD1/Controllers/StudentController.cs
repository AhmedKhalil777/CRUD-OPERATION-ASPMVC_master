using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EBsecCRUD1.Models;

namespace EBsecCRUD1.Controllers
{
    public class StudentController : Controller
    {
        static List<Student> students = new List<Student>()
        {
            new Student{id =1 , address = "Mahalah"  , name ="Mike " , age=12},
                        new Student{id =2 , address = "Mahalah"  , name ="Ahmed " , age=12},
            new Student{id =3 , address = "Mahalah"  , name ="Ahmed " , age=12},

        };
        // GET: Student
        public ActionResult Index()
        {
            return View(students);
        }

         [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public  ActionResult Create(string name , string address , int age)
        {
            Student st = new Student() { name = name, address = address, age = age };
            students.Add(st);

            return RedirectToAction("Index"); 
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
         Student student =   students.Find(a => a.id == id);
            
            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(Student newstudent)
        {
          Student oldstudent =  students.Find(a => a.id == newstudent.id);
            oldstudent.name = newstudent.name;
            oldstudent.age = newstudent.age;
            oldstudent.address = newstudent.address;
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Student student = students.Find(a => a.id == id);
            
            return View(student);
        }
         
        [HttpPost]
        public ActionResult Delete( Student st)
        {
            Student student = students.Find(a => a.id == st.id);
            students.Remove(student);

            return RedirectToAction("Index");
        }
        
    }
}