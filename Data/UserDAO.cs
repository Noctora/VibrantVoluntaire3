using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using VibrantVoluntaire3.Models;

namespace VibrantVoluntaire3.Data
{
    internal class UserDAO
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=VV2Db;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<UserAcc> FetchAll()
        {
            //To list down everything in UserAcc
            List<UserAcc> returnList = new List<UserAcc>();

            // access the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * from dbo.User_Info";

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        UserAcc users = new UserAcc();
                        users.usernameId = reader.GetInt32(0);
                        users.username = reader.GetString(1);
                        users.password = reader.GetString(2);
                        users.firstname = reader.GetString(3);
                        users.lastname = reader.GetString(4);
                        users.age = reader.GetInt32(5);
                        users.gender = reader.GetString(6);
                        users.occupation = reader.GetString(7);
                        users.title = reader.GetString(8);
                        users.interests = reader.GetString(9);
                        users.past_experience = reader.GetString(10);
                        users.email_address = reader.GetString(11);
                        users.phone_num = reader.GetString(12);

                        returnList.Add(users);
                    }
                }
            }
            return returnList;

        }




        //instead of list, we just gonna use a single NGOAcc object
        public UserAcc FetchOne(int id)
        {

            // access the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * from dbo.User_Info WHERE usernameId = @id";

                // associate @id with Id parameter beside fetchone


                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                UserAcc users = new UserAcc();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        users.usernameId = reader.GetInt32(0);
                        users.username = reader.GetString(1);
                        users.password = reader.GetString(2);
                        users.firstname = reader.GetString(3);
                        users.lastname = reader.GetString(4);
                        users.age = reader.GetInt32(5);
                        users.gender = reader.GetString(6);
                        users.occupation = reader.GetString(7);
                        users.title = reader.GetString(8);
                        users.interests = reader.GetString(9);
                        users.past_experience = reader.GetString(10);
                        users.email_address = reader.GetString(11);
                        users.phone_num = reader.GetString(12);


                    }
                }
                return users;
            }


        }



        public int FetchOneName(string names)
        {

            // access the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * from dbo.User_Info WHERE username = @names";

                // associate @id with Id parameter beside fetchone


                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@names", System.Data.SqlDbType.VarChar).Value = names;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                UserAcc users = new UserAcc();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        users.usernameId = reader.GetInt32(0);
                        users.username = reader.GetString(1);
                        users.password = reader.GetString(2);
                        users.firstname = reader.GetString(3);
                        users.lastname = reader.GetString(4);
                        users.age = reader.GetInt32(5);
                        users.gender = reader.GetString(6);
                        users.occupation = reader.GetString(7);
                        users.title = reader.GetString(8);
                        users.interests = reader.GetString(9);
                        users.past_experience = reader.GetString(10);
                        users.email_address = reader.GetString(11);
                        users.phone_num = reader.GetString(12);


                    }
                }
                return users.usernameId;
            }


        }


        // create new
        public int CreateOrUpdate(UserAcc userAcc)
        {
            // if NGOAcc.ngoid <= 1 then create

            // if NGOAcc.ngoid > 1 then update is meant


            // access the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string sqlQuery = "";

                if (userAcc.usernameId <= 0)
                {
                    sqlQuery = "INSERT INTO dbo.User_Info Values(@username, @password, @firstname, @lastname, @age, @gender, @occupation, @title, @interests, @past_experience, @email_address, @phone_num)";
                }
                else
                {
                    //update
                    sqlQuery = "UPDATE dbo.User_Info SET username = @username, password = @password, firstname = @firstname, lastname = @lastname, age = @age, gender = @gender, occupation = @occupation, title = @title, interests = @interests, past_experience = @past_experience, email_address = @email_address, phone_num = @phone_num  WHERE usernameId = @usernameId";
                }

                // associate @id with Id parameter beside fetchone
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@usernameId", System.Data.SqlDbType.VarChar, 1000).Value = userAcc.usernameId;
                command.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 1000).Value = userAcc.username;
                command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 1000).Value = userAcc.password;
                command.Parameters.Add("@firstname", System.Data.SqlDbType.VarChar, 1000).Value = userAcc.firstname;
                command.Parameters.Add("@lastname", System.Data.SqlDbType.VarChar, 1000).Value = userAcc.lastname;
                command.Parameters.Add("@age", System.Data.SqlDbType.VarChar, 1000).Value = userAcc.age;
                command.Parameters.Add("@gender", System.Data.SqlDbType.VarChar, 1000).Value = userAcc.gender;
                command.Parameters.Add("@occupation", System.Data.SqlDbType.VarChar, 1000).Value = userAcc.occupation;
                command.Parameters.Add("@title", System.Data.SqlDbType.VarChar, 1000).Value = userAcc.title;
                command.Parameters.Add("@interests", System.Data.SqlDbType.VarChar, 1000).Value = userAcc.interests;
                command.Parameters.Add("@past_experience", System.Data.SqlDbType.VarChar, 1000).Value = userAcc.past_experience;
                command.Parameters.Add("@email_address", System.Data.SqlDbType.VarChar, 1000).Value = userAcc.email_address;
                command.Parameters.Add("@phone_num", System.Data.SqlDbType.VarChar, 1000).Value = userAcc.phone_num;

                connection.Open();

                //Doing an inserting
                int newID = command.ExecuteNonQuery();




                return newID;
            }


        }

       

        // delete one
        internal int Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string sqlQuery = "DELETE FROM dbo.User_Info WHERE usernameId = @usernameId";

                // associate @id with Id parameter beside fetchone
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@usernameId", System.Data.SqlDbType.VarChar, 1000).Value = id;

                connection.Open();

                //Doing an inserting
                int deleteID = command.ExecuteNonQuery();

                return deleteID;
            }
        }

        // update one

        // search for name
        internal List<UserAcc> SearchForName(string searchPhrase)
        {
            //To list down everything in NGOAcc
            List<UserAcc> returnList = new List<UserAcc>();

            // access the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * from dbo.User_Info WHERE username LIKE @searchForMe";

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@searchForMe", System.Data.SqlDbType.NVarChar).Value = "%" + searchPhrase + "%";

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        UserAcc users = new UserAcc();
                        users.usernameId = reader.GetInt32(0);
                        users.username = reader.GetString(1);
                        users.password = reader.GetString(2);
                        users.firstname = reader.GetString(3);
                        users.lastname = reader.GetString(4);
                        users.age = reader.GetInt32(5);
                        users.gender = reader.GetString(6);
                        users.occupation = reader.GetString(7);
                        users.title = reader.GetString(8);
                        users.interests = reader.GetString(9);
                        users.past_experience = reader.GetString(10);
                        users.email_address = reader.GetString(11);
                        users.phone_num = reader.GetString(12);

                        returnList.Add(users);
                    }
                }
            }
            return returnList;
        }


        public UserAcc AssignUser(UserAcc user)
        {
            // start by assuming that it failed
            //bool success = false;
            UserAcc users = new UserAcc();
            // write the sql expression
            string queryString = "SELECT * FROM dbo.User_Info WHERE username = @username AND password = @password";

            // create and open the connection to the database inside a using block.
            // this ensures that all resources are closed properly when the query is done.

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // create the command and parameter objects
                SqlCommand command = new SqlCommand(queryString, connection);

                // @username is from query assigned to value of parameter import, in this case, user
                // associate @username with user.username
                command.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 50).Value = user.username;
                command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 50).Value = user.password;

                //command.Parameters.Add("@usernameId", System.Data.SqlDbType.VarChar, 50).Value = user.usernameId;

                // open the database and run the command.
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();


                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            users.usernameId = reader.GetInt32(0);
                            users.username = reader.GetString(1);
                            users.password = reader.GetString(2);
                            users.firstname = reader.GetString(3);
                            users.lastname = reader.GetString(4);
                            users.age = reader.GetInt32(5);
                            users.gender = reader.GetString(6);
                            users.occupation = reader.GetString(7);
                            users.title = reader.GetString(8);
                            users.interests = reader.GetString(9);
                            users.past_experience = reader.GetString(10);
                            users.email_address = reader.GetString(11);
                            users.phone_num = reader.GetString(12);


                        }

                        //success = true;
                    }
                    else
                    {
                        //success = false;
                    }
                    reader.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return users;
        }




    }
}