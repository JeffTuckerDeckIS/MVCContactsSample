using System;
using System.Data.OleDb;
using System.Linq;
using System.Collections.Generic;
using SampleMvcContacts.Models;
using Dapper;
using SampleMvcContacts.Utilities;


namespace SampleMvcContacts.DataAccess
{
    public class PersonDataAccessManager : BaseDataAccessManager
    {
        /// <summary>
        /// Get all person
        /// </summary>        
        /// <returns>List of Person</returns>
        public List<Person> GetPeople()
        {
            //List<Person> people = new List<Person>();


            var people = new List<Person>();
            try
            {
                using (var connection = new OleDbConnection(this.ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT ID, FirstName, LastName, EmailAddress FROM People;";

                    people = connection.Query<Person>(query).ToList();
                }
            }
            catch (Exception e)
            {
                Logger.Log("Data Access Error: " + e);
            }
            return people;
        }


        public Person GetPerson(int? id)
        {
            var person = new Person();

            try
            {
                using (var connection = new OleDbConnection(this.ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT ID, FirstName, LastName, EmailAddress FROM People WHERE ID =" + id + ";";
                    person = connection.Query<Person>(query).First();
                }
            }
            catch (Exception e)
            {
                Logger.Log("Data Access Error: " + e);
            }
            return person;
        }


        public bool CreatePerson(Person person)
        {
            bool wasSuccess = false;
            try
            {
                using (var connection = new OleDbConnection(this.ConnectionString))
                {
                    connection.Open();

                    string insertStatement = "INSERT INTO People " +
                              "( FirstName,  LastName,  EmailAddress) " +
                              String.Format("VALUES( '{0}', '{1}', '{2}');", person.FirstName, person.LastName, person.EmailAddress);


                    connection.Execute(insertStatement);
                    connection.Close();
                }
                wasSuccess = true;
            }
            catch (Exception e)
            {
                Logger.Log("Data Access Error: " + e);
            }

            return wasSuccess;
        }

        public bool UpdatePerson(Person person)
        {
            bool wasSuccess = false;
            try
            {
                using (var connection = new OleDbConnection(this.ConnectionString))
                {
                    connection.Open();
                    string updateStatement = String.Format(@"UPDATE People SET FirstName = '{0}' ,LastName = '{1}' , EmailAddress = '{2}' WHERE ID = '{3}'", person.FirstName, person.LastName, person.EmailAddress, person.ID);
                    connection.Execute(updateStatement);
                    connection.Close();
                }
                wasSuccess = true;
            }
            catch (Exception e)
            {
                Logger.Log("Data Access Error: " + e);
            }

            return wasSuccess;
        }

        public bool Delete(int id)
        {
            bool wasSuccess = false;
            try
            {
                using (var connection = new OleDbConnection(this.ConnectionString))
                {
                    connection.Open();
                    string deleteStatement = "DELETE FROM People WHERE ID = @ID;";
                    connection.Execute(deleteStatement, new { id });
                    connection.Close();
                }
                wasSuccess = true;
            }
            catch (Exception e)
            {
                Logger.Log("Data Access Error: " + e);
            }

            return wasSuccess;
        }
    }
}