using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParkingApi.Requests.User;
using ParkingApi.Requests.User.Car;
using ParkingApi.Responses.User;
using ParkingApi.Services.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApi.Controllers.Users
{
    [ApiController]
    [Route("api/user/car")]
    [Authorize (Roles = "user")]
    public class UserCarController : ControllerBase
    {
        private readonly UserCarService _service;

        public UserCarController (UserCarService service)
        {
            _service = service;
        }

        /// <summary>
        /// Only user
        /// </summary>
        [HttpPost]
        [Route("add")]
        public ActionResult<UserCarResponse> AddCar (CreateUserCarRequest request)
        {
            long userId = Convert.ToInt64(User.Identity.Name);
            UserCarResponse response = _service.AddCar(userId, request);
            return Ok(response);

        }
        
        /// <summary>
        /// Only user
        /// </summary>
        [HttpPut]
        [Route("update/{carId}")]
        public ActionResult<UserCarResponse> UpdateCar (UpdateUserCarRequest request, long carId)
        {
            long userId = Convert.ToInt64(User.Identity.Name);
            UserCarResponse response = _service.UpdateCar(userId, request, carId);
            return Ok(response);
        }


        /// <summary>
        /// Only user
        /// </summary>
        [HttpDelete]
        [Route("delete/{carId}")] 
        public ActionResult DeleteCar (long carId)
        {
            long userId = Convert.ToInt64(User.Identity.Name);
            _service.DeleteCar(userId, carId);
            return Ok();
        }

        /// <summary>
        /// Only user
        /// </summary>
        [HttpGet]
        [Route("isDefaulte/{carId}")]
        public ActionResult IsDefaulte (long carId)
        {
            long userId = Convert.ToInt64(User.Identity.Name);
            _service.IsDefault(userId, carId);
            return Ok();
        }
    }
}
