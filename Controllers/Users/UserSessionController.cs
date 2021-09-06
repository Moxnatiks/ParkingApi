using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParkingApi.Requests.User.Session;
using ParkingApi.Responses.User;
using ParkingApi.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApi.Controllers.Users
{
    [ApiController]
    [Route("api/user/session")]
    [Authorize (Roles = "user")]
    public class UserSessionController : ControllerBase
    {
        private readonly UserSessionService _service;

        public UserSessionController (UserSessionService service)
        {
            _service = service;
        }

        /// <summary>
        /// Only user
        /// </summary>
        [HttpPost]
        [Route("add")]
        public ActionResult<UserCarResponse> CreateSession(CreateUserSessionRequest request)
        {
            long userId = Convert.ToInt64(User.Identity.Name);
            UserCarResponse response = _service.CreateSession(userId, request);
            return Ok(response);
        }

        [HttpDelete]
        [Route("delete/carId")]
        public ActionResult DeleteSession (long carId)
        {
            long userId = Convert.ToInt64(User.Identity.Name);
            _service.DeleteSessionByCar(userId, carId);
            return Ok();
        }
    }
}
