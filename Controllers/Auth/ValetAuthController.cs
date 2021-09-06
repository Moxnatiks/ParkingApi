using Microsoft.AspNetCore.Mvc;
using ParkingApi.Exceptions;
using ParkingApi.Models;
using ParkingApi.Requests.Auth;
using ParkingApi.Responses;
using ParkingApi.Settings;
using System.Linq;

namespace ParkingApi.Controllers.Auth
{
    [ApiController]
    [Route("api/auth/valet")]
    public class ValetAuthController : BaseAuth
    {
        private string Role = "valet";
        private readonly ApiDbContext db;
        public ValetAuthController(ApiDbContext apiDbContext)
        {
            db = apiDbContext;
        }

        /// <summary>
        /// Public
        /// </summary>
        [HttpPost]
        [Route("login")]
        public IActionResult AdminLogin(ValetLogRequest request)
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
            Valet user = db.Valets.FirstOrDefault(x => x.Email == email);
            if (user != null)
            {
  
                bool isPasswordMatched = new HashPassword(password).VerifyPassword(user.StoredSalt, user.Password);
                if (isPasswordMatched)
                {
                    if (user.IsAccess)
                    {
                        return user.Id.ToString();
                    }
                    else throw new AppException("Access blocked!");
                }
                return null;
            }
            return null;
        }
    }
}
