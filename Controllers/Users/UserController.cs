using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParkingApi.Responses.User;
using ParkingApi.Services.Users;
using System;

namespace ParkingApi.Controllers.Users
{
    [ApiController]
    [Route("api/user")]
    [Authorize(Roles = "user")]
    public class UserController : ControllerBase
    {
        private readonly UserService _service;

        public UserController(UserService service)
        {
            _service = service;
        }

        /// <summary>
        /// Only user
        /// </summary>
        [HttpGet]
        [Route("get")]
        public ActionResult<UserResponse> GetData ()
        {
            long userId = Convert.ToInt64(User.Identity.Name);
            UserResponse response = _service.GetData(userId);

            return Ok(response);
        }
    }
}
