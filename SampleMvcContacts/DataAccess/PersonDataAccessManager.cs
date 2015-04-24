using System;
using System.Data.OleDb;
using System.Linq;
using System.Collections.Generic;
using Dapper;
using SampleMvcContacts.Models;
using SampleMvcContacts.Utilities;


namespace SampleMvcContacts.DataAccess
{
    public class PersonDataAccessManager : BaseDataAccessManager
    {


        /// <summary>
        /// Retrieve the person with the id from the People table
        /// </summary>
        /// <param name="id">id of the person</param>
        /// <returns>Person Model</returns>
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
                Logger.Log( String.Format("{0} || Data Access Error on RETREVE operation: {1}", DateTime.Now.ToString(), e));
            }
            return person;
        }

        /// <summary>
        /// Get all persons from People Table
        /// </summary>        
        /// <returns>List of Person Model</returns>
        public List<Person> GetPeople()
        {   
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
                Logger.Log("Data Access Error on RETREVE operation: " + e);
            }
            return people;
        }

        /// <summary>
        /// Create a new person in Person Table
        /// </summary>
        /// <param name="person"></param>
        /// <returns>boolian if successfully created a person</returns>
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
                Logger.Log("Data Access Error on CREATE operation: " + e);
            }

            return wasSuccess;
        }

        /// <summary>
        /// Update a person's detail info.
        /// </summary>
        /// <param name="person">Peson Model</param>
        /// <returns>Boolean value: True if updated, False if failed.</returns>
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
                Logger.Log("Data Access Error on Update Operation: " + e);
            }

            return wasSuccess;
        }

        /// <summary>
        /// Delete the person with the id.
        /// </summary>
        /// <param name="id">id of the person</param>
        /// <returns>Boolean Value : True if deleted, False if failed.</returns>
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
                Logger.Log("Data Access Error on DELETE Operation: " + e);
            }

            return wasSuccess;
        }
    }
}