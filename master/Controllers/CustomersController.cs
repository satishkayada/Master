using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using master.Models;
using master.ViewModels;
using System.Data.Entity;

namespace master.Controllers
{
    public class CustomersController : Controller
    {
        //
        // GET: /Customers/
        public ActionResult Random()
        {
            ApplicationDbContext db=new ApplicationDbContext();
            List<Customer> Customers = db.Customers.ToList();
            var ViewModel = new RandomMovieViewModel
            {
                Customers = Customers,
            };
            return View(ViewModel);
        }
        public ActionResult Details(int id)
        {
            var custs = new List<Customer>
            {
                new Customer{ Id=1, Name="Bill Gates"},
                new Customer{ Id=2, Name="Barak Obama"},
                new Customer{ Id=3, Name="Mohandas Gandhi"}
            };
            var customer = (Customer)custs.Find(r => r.Id == id);
            var ViewModel = new RandomMovieViewModel
            {
                Customers = custs,
            };
            return View(customer);
        }
        public ActionResult Create()
        {
            return View("Create");
        }

	}
}