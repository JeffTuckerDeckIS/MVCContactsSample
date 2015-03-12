using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleMvcContacts.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<string> names = new List<string>();

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();

                OleDbCommand cmd = new OleDbCommand
                {
                    Connection = conn,
                    CommandText = "select * from People",
                    CommandType = CommandType.Text
                };

                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    names.Add(dr["FirstName"].ToString());
                }
                dr.Close();

            }


            return View(names);
        }
    }
}