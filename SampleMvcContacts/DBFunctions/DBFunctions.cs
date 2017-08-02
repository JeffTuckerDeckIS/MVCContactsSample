using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlServerCe;
using log4net;
using System.Reflection;

/// <summary>
/// Summary description for Class1
/// </summary>
public class DBfunctions
{
	public SqlCeConnection dbConnection;
    private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
	private void CreateConnection()
	{
		string conString= ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        dbConnection = new SqlCeConnection(conString);
	}//end function

	public void AddPerson(Person person)
	{
		try
		{
			//Add a new person         
            CreateConnection();
			dbConnection.Open();
            SqlCeCommand query = new SqlCeCommand("INSERT INTO People (FirstName,LastName,EmailAddress) VALUES (@FirstName,@LastName,@EmailAddress)", dbConnection);
            query.Parameters.AddWithValue("@FirstName", person.firstName);
			query.Parameters.AddWithValue("@LastName", person.lastName);
			query.Parameters.AddWithValue("@EmailAddress", person.emailAddress);
            query.Prepare();
			query.ExecuteNonQuery();
			dbConnection.Close();
		}
		catch (Exception ex)
		{
            logger.Error("DBFunctions-AddPerson. Error:" + ex.Message);
            throw ex;
		}//end try
	}//end function

	public List<Person> ViewPeople()
	{

		try
		{
			List<Person> returnList = new List<Person>();

			CreateConnection();
			dbConnection.Open();
			SqlCeCommand query = new SqlCeCommand("SELECT ID,FirstName,LastName,EmailAddress FROM People", dbConnection);
			SqlCeDataReader reader = query.ExecuteReader();
			while (reader.Read())
			{
                var tempPerson = new Person(); ;
                tempPerson.personId = reader.GetInt32(0);
                tempPerson.firstName = reader.GetString(1);
                tempPerson.lastName = reader.GetString(2);
                tempPerson.emailAddress = reader.GetString(3);
                returnList.Add(tempPerson);
			}//end while

			dbConnection.Close();
			return returnList;
		}
		catch (Exception ex)
		{
            logger.Error("DBFunctions-ViewPeople. Error:" + ex.Message);
            throw ex;
		}//end try	
	}//end function

	public void UpdatePerson(Person person)
	{
		try
		{
			//Add a new person
			CreateConnection();
			dbConnection.Open();
			SqlCeCommand query = new SqlCeCommand("UPDATE People SET FirstName=@FirstName,LastName=@LastName,EmailAddress=@EmailAddress WHERE IDs=@ID", dbConnection);
            query.Parameters.AddWithValue("@ID", person.personId);
			query.Parameters.AddWithValue("@FirstName", person.firstName);
			query.Parameters.AddWithValue("@LastName", person.lastName);
			query.Parameters.AddWithValue("@EmailAddress", person.emailAddress);
            query.Prepare();
            query.ExecuteNonQuery();
			dbConnection.Close();
		}
		catch (Exception ex)
		{
			//Log the error
            logger.Error("DBFunctions-UpdatePerson. Error:" + ex.Message);
            throw ex;
		}//end try
	}//end function

	public void DeletePerson(int personId)
	{
		try
		{
			CreateConnection();
			dbConnection.Open();
			SqlCeCommand query = new SqlCeCommand("DELETE FROM People WHERE ID=@ID", dbConnection);
			query.Parameters.AddWithValue("@ID", personId);
			query.ExecuteNonQuery();
			dbConnection.Close();
		}
		catch (Exception ex)
		{
			//Log the error
            logger.Error("DBFunctions-DeletePerson. Error:" + ex.Message);
			throw ex;
		}//end try
	}//end function

   
}//End Class
