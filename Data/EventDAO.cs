using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using VibrantVoluntaire3.Models;
using System.Data;

namespace VibrantVoluntaire3.Data
{
    internal class EventDAO
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=VV2Db;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //public int CreateOrUpdate(EventM eventM, UserAcc userAcc)
        //{
        //    // if NGOAcc.ngoid <= 1 then create

        //    // if NGOAcc.ngoid > 1 then update is meant


        //    // access the database
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {

        //        string sqlQuery = "";

        //        if (userAcc.usernameId <= 0)
        //        {
        //            sqlQuery = "INSERT INTO dbo.User_Info Values(@username, @password, @firstname, @lastname, @age, @gender, @occupation, @title, @interests, @past_experience, @email_address, @phone_num)";
        //        }
        //        else
        //        {
        //            //update
        //            sqlQuery = "UPDATE dbo.User_Info SET username = @username, password = @password, firstname = @firstname, lastname = @lastname, age = @age, gender = @gender, occupation = @occupation, title = @title, interests = @interests, past_experience = @past_experience, email_address = @email_address, phone_num = @phone_num  WHERE usernameId = @usernameId";
        //        }

        //        // associate @id with Id parameter beside fetchone
        //        SqlCommand command = new SqlCommand(sqlQuery, connection);

        //        command.Parameters.Add("@usernameId", System.Data.SqlDbType.VarChar, 1000).Value = userAcc.usernameId;
        //        command.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 1000).Value = userAcc.username;
        //        command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 1000).Value = userAcc.password;
        //        command.Parameters.Add("@firstname", System.Data.SqlDbType.VarChar, 1000).Value = userAcc.firstname;
        //        command.Parameters.Add("@lastname", System.Data.SqlDbType.VarChar, 1000).Value = userAcc.lastname;
        //        command.Parameters.Add("@age", System.Data.SqlDbType.VarChar, 1000).Value = userAcc.age;
        //        command.Parameters.Add("@gender", System.Data.SqlDbType.VarChar, 1000).Value = userAcc.gender;
        //        command.Parameters.Add("@occupation", System.Data.SqlDbType.VarChar, 1000).Value = userAcc.occupation;
        //        command.Parameters.Add("@title", System.Data.SqlDbType.VarChar, 1000).Value = userAcc.title;
        //        command.Parameters.Add("@interests", System.Data.SqlDbType.VarChar, 1000).Value = userAcc.interests;
        //        command.Parameters.Add("@past_experience", System.Data.SqlDbType.VarChar, 1000).Value = userAcc.past_experience;
        //        command.Parameters.Add("@email_address", System.Data.SqlDbType.VarChar, 1000).Value = userAcc.email_address;
        //        command.Parameters.Add("@phone_num", System.Data.SqlDbType.VarChar, 1000).Value = userAcc.phone_num;

        //        connection.Open();

        //        //Doing an inserting
        //        int newID = command.ExecuteNonQuery();




        //        return newID;
        //    }


        //}

        public int Create(EventM eventM)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string sqlQuery = "INSERT INTO dbo.Event_Info Values(@usernameId, @event_name, @event_date, @venue, @location, @attendance_limit, @rating, @additional_info)";



                // associate @id with Id parameter beside fetchone
                SqlCommand command = new SqlCommand(sqlQuery, connection);


                command.Parameters.Add("@usernameId", System.Data.SqlDbType.VarChar, 1000).Value = 1000;
                command.Parameters.Add("@event_name", System.Data.SqlDbType.VarChar, 1000).Value = eventM.event_name;
                command.Parameters.Add("@event_date", System.Data.SqlDbType.VarChar, 1000).Value = eventM.event_date;
                command.Parameters.Add("@venue", System.Data.SqlDbType.VarChar, 1000).Value = eventM.venue;
                command.Parameters.Add("@location", System.Data.SqlDbType.VarChar, 1000).Value = eventM.location;
                command.Parameters.Add("@attendance_limit", System.Data.SqlDbType.VarChar, 1000).Value = eventM.attendance_limit;
                //command.Parameters.Add("@budget", System.Data.SqlDbType.VarChar, 1000).Value = eventM.budget;
                command.Parameters.Add("@rating", System.Data.SqlDbType.VarChar, 1000).Value = eventM.rating;
                command.Parameters.Add("@additional_info", System.Data.SqlDbType.VarChar, 1000).Value = eventM.additional_info;


                connection.Open();

                //Doing an inserting
                int newID = command.ExecuteNonQuery();

                return newID;
            }
        }

        public List<EventM> FetchAll()
        {
            
            List<EventM> returnList = new List<EventM>();

            // access the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * from dbo.Event_Info";
                //string sqlQuery = "SELECT event_name, event_date, venue, location, attendance_limit from dbo.Event_Info";


                SqlCommand command = new SqlCommand(sqlQuery, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        EventM events = new EventM();
                        events.eventId = reader.GetInt32(0);
                        events.usernameId = reader.GetInt32(1);
                        events.event_name = reader.GetString(2);
                        events.event_date = reader.GetString(3);
                        events.venue = reader.GetString(4);
                        events.location = reader.GetString(5);
                        events.attendance_limit = reader.GetInt32(6);
                        
                        events.rating = reader.GetInt32(7);
                        events.additional_info = reader.GetString(8);

                        //events.event_name = reader.GetString(0);
                        //events.event_date = reader.GetString(1);
                        //events.venue = reader.GetString(2);
                        //events.location = reader.GetString(3);
                        //events.attendance_limit = reader.GetInt32(4);


                        returnList.Add(events);
                    }
                }
            }
            return returnList;

        }


        public EventM FetchOne(int id)
        {

            // access the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * from dbo.Event_Info WHERE eventId = @id";

                // associate @id with Id parameter beside fetchone


                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                
                EventM events = new EventM();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        events.eventId = reader.GetInt32(0);
                        events.usernameId = reader.GetInt32(1);
                        events.event_name = reader.GetString(2);
                        events.event_date = reader.GetString(3);
                        events.venue = reader.GetString(4);
                        events.location = reader.GetString(5);
                        events.attendance_limit = reader.GetInt32(6);
                        //events.budget = reader.GetFloat(7);
                        events.rating = reader.GetInt32(7);
                        events.additional_info = reader.GetString(8);                       

                    }
                }
                return events;
            }


        }
    }
}