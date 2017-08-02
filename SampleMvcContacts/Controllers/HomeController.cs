using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Web.Mvc;
using log4net;
using System.Reflection;

namespace SampleMvcContacts.Controllers
{
    public class HomeController : Controller
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        //Default view. Lists all people in database
        public ActionResult Index()
        {
            return View();
        }//end function

        public ActionResult GetAllPeople()
        {
            DBfunctions dbFunctions = new DBfunctions();
            return View(dbFunctions.ViewPeople());
        }
        
        public ActionResult AddPerson()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult AddPerson(Person person)
        {
            try 
            { 
                if(ModelState.IsValid)
                {
                    DBfunctions dbFunctions = new DBfunctions();
                    dbFunctions.AddPerson(person);
                    string displayString=String.Format("{0} {1} added to the database.",person.firstName,person.lastName);
                    ViewBag.Message = displayString;
                }
                return View();

            }
            catch(Exception ex)
            {
                logger.Error("HomeController-AddPerson. Error:" + ex.Message);
                return View();
            }//end try
        }//end function
        
        public ActionResult UpdatePerson(int id)
        {
            DBfunctions dbFunctions = new DBfunctions();
            return View(dbFunctions.ViewPeople().Find(Person => Person.personId == id));   
        }//end function

        [HttpPost]
        public ActionResult UpdatePerson(int id,Person person)
        {
            try
            {
                DBfunctions dbFunctions = new DBfunctions();
                dbFunctions.UpdatePerson(person);
                return RedirectToAction("GetAllPeople");
            }
            catch(Exception ex) 
            {
                logger.Error("HomeController-UpdatePerson. Error:" + ex.Message);
                return View();
            }//end try
        }//end function

        public ActionResult DeletePerson(int id)
        {
            try
            {
                DBfunctions dbFunctions = new DBfunctions();
                dbFunctions.DeletePerson(id);
                return RedirectToAction("GetAllPeople");
            }
            catch(Exception ex)
            {
                logger.Error("HomeController-DeletePerson. Error:" + ex.Message);
                return RedirectToAction("GetAllPeople");
            }
        }//end function

    }
}