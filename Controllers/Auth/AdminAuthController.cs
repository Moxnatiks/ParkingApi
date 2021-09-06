using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ParkingApi.Settings;
using ParkingApi.Exceptions;
using ParkingApi.Models;
using ParkingApi.Requests.Auth;
using ParkingApi.Responses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApi.Controllers.Auth
{
    [ApiController]
    [Route("api/auth/admin")]
    public class AdminAuthController : BaseAuth
    {
        private string Role = "admin";
        private readonly ApiDbContext db;
        public AdminAuthController(ApiDbContext apiDbContext)
        {
            db = apiDbContext;
        }

        /// <summary>
        /// Public
        /// </summary>
        [HttpPost]
        [Route("login")]
        public IActionResult AdminLogin(AdminLogRequest request)
        {
            if (request.Password != null)
            {
                
                var identity = GetIdentity(request.Email, request.Password);

                if (identity != null)
                {
                    var token = CreateToken(identity);

                    var response = new TokenResponse()
                    {
                        Role = Role,
                        Token = token.ToString()
                    };

                    return Ok(response);

                }
                else throw new AppException("Invalid email or password!");
            } 
            else throw new AppException("Invalid email or password!");


        }

        protected override string getRole()
        {
            return Role;
        }
        protected override string checkPerson(string email, string password)
        {
            Admin user = db.Admins.FirstOrDefault(x => x.Email == email);
            if (user != null)
            {
                bool isPasswordMatched = new HashPassword(password).VerifyPassword(user.StoredSalt, user.Password);
                if (isPasswordMatched)
                {
                    return user.Id.ToString();
                }
                return null;
            }
            else throw new AppException("Invalid email or password!");

        }

    }
}
