using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using VibrantVoluntaire3.Models;

namespace VibrantVoluntaire3.Data
{
    public class SecurityDAO
    {

        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=VV2Db;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        internal bool FindByUser(UserAcc user)
        {
            // start by assuming that it failed
            bool success = false;

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

                        success = true;
                    }
                    else
                    {
                        success = false;
                    }
                    reader.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return success;
        }

        internal int FindId(UserAcc user)
        {
            int x=0;

            string queryString2 = "SELECT usernameId = @usernameId FROM dbo.User_Info WHERE username = @username AND password = @password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // create the command and parameter objects
                SqlCommand command = new SqlCommand(queryString2, connection);

                // @username is from query assigned to value of parameter import, in this case, user
                // associate @username with user.username
                command.Parameters.Add("@usernameId", System.Data.SqlDbType.Int).Value = user.usernameId;
                command.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 50).Value = user.username;
                command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 50).Value = user.password;
                
                //command.Parameters.Add("@usernameId", System.Data.SqlDbType.VarChar, 50).Value = user.usernameId;

                // open the database and run the command.
                try
                {
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
                            x = user.usernameId;


                        }

                        
                    }
                    else
                    {
                        x = 0;
                    }
                    reader.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }



            return x;
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