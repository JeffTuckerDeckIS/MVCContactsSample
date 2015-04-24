using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleMvcContacts.Models
{
    public class Person
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        
    }
}