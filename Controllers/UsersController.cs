using EMedicineApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EMedicineApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public UsersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("registration")]
        public Response register(Users users) // register new user 
        {
            Response response = new Response();
            DAL dal = new DAL();
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("Conn").ToString());
            response = dal.register(users, con);
            return response;
        }
        [HttpPost]
        [Route("login")]
        public Response login(Users users)
        {
            DAL dal = new DAL();
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("Conn").ToString());
            Response response = new Response();
            response = dal.Login(users, con);
            return response;
        }

        [HttpPost]
        [Route("viewUser")]
        public Response viewUser(Users users)
        { 
        DAL dal = new DAL();
        SqlConnection con = new SqlConnection(_configuration.GetConnectionString("Conn").ToString());
        Response response = dal.viewUser(users, con); 
        return response;
         }

        [HttpPost]
        [Route("updateProfile")]
        public Response updateProfile(Users users)
        {
            DAL dal = new DAL();
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("Conn").ToString());
            Response response = dal.updateProfile(users, con); 
            return response;
        }

    }
}
