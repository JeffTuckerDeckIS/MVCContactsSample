using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace SampleMvcContacts.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact       
        public ActionResult Index()
        {
            ViewBag.Message = "This is the contact page.";

            var model = this.GetPeopleModel();
            return View(model);
        }

        // GET: Contact/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.Test = "Details Not required";
            DataAccess.PersonDataAccessManager personDataManager = new DataAccess.PersonDataAccessManager();
            Models.Person person = personDataManager.GetPerson(id);
            return View(person);
        }
        private List<Models.Person> GetPeopleModel()
        {
            DataAccess.PersonDataAccessManager personDataMgr = new DataAccess.PersonDataAccessManager();
            return personDataMgr.GetPeople();
        }


        // GET: Contact/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contact/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                DataAccess.PersonDataAccessManager personDataManager = new DataAccess.PersonDataAccessManager();
                Models.Person person = new Models.Person { FirstName = collection["FirstName"], LastName = collection["LastName"], EmailAddress = collection["EmailAddress"] };
                personDataManager.CreatePerson(person);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contact/Edit/5   
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            DataAccess.PersonDataAccessManager personDataManager = new DataAccess.PersonDataAccessManager();
            Models.Person person = personDataManager.GetPerson(id);

            return View(person);

        }

        // POST: Contact/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                DataAccess.PersonDataAccessManager personDataManager = new DataAccess.PersonDataAccessManager();
                Models.Person person = new Models.Person { FirstName = collection["FirstName"], LastName = collection["LastName"], EmailAddress = collection["EmailAddress"], ID = Convert.ToInt32(collection["ID"]) };
                personDataManager.UpdatePerson(person);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contact/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            DataAccess.PersonDataAccessManager personDataManager = new DataAccess.PersonDataAccessManager();
            Models.Person person = personDataManager.GetPerson(id);

            return View(person);
        }

        // POST: Contact/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                DataAccess.PersonDataAccessManager personDataManager = new DataAccess.PersonDataAccessManager();
                Models.Person person = new Models.Person { ID = Convert.ToInt32(collection["ID"]), FirstName = collection["FirstName"], LastName = collection["LastName"], EmailAddress = collection["EmailAddress"] };
                personDataManager.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



    }
}
