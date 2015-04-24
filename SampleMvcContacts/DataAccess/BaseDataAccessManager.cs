using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace SampleMvcContacts.DataAccess
{
    public class BaseDataAccessManager
    {
        public string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    }
}