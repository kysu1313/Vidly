using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using System.Dynamic;
using Vidly.ViewModels;
using System.Runtime.Caching;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        /**
         * Constructor; Initializes DBContext.
         */
        public CustomersController()
        {
            _context = new ApplicationDbContext();
            //var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            var customers = _context.Customers;
        }

        //public ViewResult Index()
        //{
        //    if (MemoryCache.Default["Genres"] == null)
        //    {
        //        MemoryCache.Default["Genres"] = _context.Genres.ToList();
        //    }
        //    var genres = MemoryCache.Default["Genres"] as IEnumerable<Genre>;
        //    return View();
        //}

        /**
         * Remove a customer?
         */
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        /**
         * Create new customer object and display create customer view.
         */
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View("New", viewModel);
        }

        /**
         * Create new or update existing customer.
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            customer.MembershipType = _context.MembershipTypes.Find(customer.MembershipTypeId);
            if (!ModelState.IsValid)
            {
                var viewModel = new NewCustomerViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("New", viewModel);
            }

            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            } 
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                
                // This method to update customer has issues because it uses magic strings.
                //TryUpdateModel(customerInDb, "", new string[] { "Name", "Email" });
                
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        /**
         * Return list of all customers on Index view.
         */
        public ActionResult Index()
        {
            if (MemoryCache.Default["Genres"] == null)
            {
                MemoryCache.Default["Genres"] = _context.Genres.ToList();
            }
            var genres = MemoryCache.Default["Genres"] as IEnumerable<Genre>;
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            //var customers = _context.Customers.ToList();
            return View(customers);
        }

        /**
         * Return the details of a customer.
         */
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            } else
            {
                return View(customer);
            }
        }

        /**
         * Update a customers details in the New view.
         */
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new NewCustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("New", viewModel);
            
        }
    }
}