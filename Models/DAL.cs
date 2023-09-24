using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace EMedicineApp.Models
{
    public class DAL
    {
        public Response register(Users users, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("SP_Register", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", users.FirstName);
            cmd.Parameters.AddWithValue("@LastName", users.LastName);
            cmd.Parameters.AddWithValue("@Password", users.Password);
            cmd.Parameters.AddWithValue("@Email", users.Email);
            cmd.Parameters.AddWithValue("@Fund", 0);
            cmd.Parameters.AddWithValue("@Type", "Users");
            cmd.Parameters.AddWithValue("@Type", "Pending");
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.statusCode = 200;
                response.statusMessage = "User registered successfully";
            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "Registration failed";
            }
            return response;
        }
        public Response Login(Users users, SqlConnection connection)
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_Login", connection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Email", users.Email);
            da.SelectCommand.Parameters.AddWithValue("@Password", users.Password);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Response response = new Response();
            if (dt.Rows.Count > 0)
            {
                response.statusCode = 200;
                response.statusMessage = "User Valid";

            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "User not valid";
            }
            return response;

        }
        public Response viewUser(Users users,SqlConnection connection)
        {
            SqlDataAdapter da = new SqlDataAdapter("p_viewUser", connection);

            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@ID", users.id);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Response response = new Response();
            if (dt.Rows.Count > 0)
            {
                users.id = Convert.ToInt32(dt.Rows[0]["ID"]);
                users.FirstName = Convert.ToString(dt.Rows[0]["FirstName"]);             
                users.LastName = Convert.ToString(dt.Rows[0]["LastName"]);                   
                users.Email = Convert.ToString(dt.Rows[0]["Email"]);                   
                users.Type = Convert.ToString(dt.Rows[0]["Type"]);                   
                users.fund = Convert.ToDecimal(dt.Rows[0]["Fund"]);                  
                users.CreatedOn = Convert.ToDateTime(dt.Rows[0]["CreatedOn"]); 
                users.Password = Convert.ToString(dt.Rows[0]["Password"]);
                response.statusCode = 200;
                response.statusMessage = "User exists";
            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "User does not exist";
            }
            return response;

        }
        public Response updateProfile(Users users, SqlConnection connection)
        {
            Response response = new Response();

            SqlCommand cmd = new SqlCommand("sp_updateProfile", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FirstName", users.FirstName);
            cmd.Parameters.AddWithValue("@LastName", users.LastName);
            cmd.Parameters.AddWithValue("@Password", users.Password);
            cmd.Parameters.AddWithValue("@Email", users.Email);

            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {
                response.statusCode = 200;
                response.statusMessage = "Profile updated successfully.";
            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "Failed to update profile.";
            }

            return response;
        }

    }
}

