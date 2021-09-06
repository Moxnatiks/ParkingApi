using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParkingApi.Responses;
using ParkingApi.Services;
using System.Collections.Generic;
//Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjEiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiMSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6ImFkbWluIiwiTE9DQUwgQVVUSE9SSVRZIjoiMSIsIm5iZiI6MTYyOTQ2NjA1MywiZXhwIjoxNjMwMDY2MDUzLCJpc3MiOiJNeUF1dGhTZXJ2ZXIiLCJhdWQiOiJNeUF1dGhDbGllbnQifQ.TMSJ0TPLCEFimEdi7Yg6Rk_iWb7fKCRiztq76XsZ2Os
namespace ParkingApi.Controllers
{
    [ApiController]
    [Route("parking")]
    //[Authorize(Roles = "admin")]
    public class ParkingController : ControllerBase
    {
        private readonly ParkingService _service;
        public ParkingController( ParkingService service)
        {
            _service = service;
        }

        /// <summary>
        /// Public 
        /// </summary>
        [HttpGet]
        [Route("get")]
        public ActionResult<IEnumerable<ParkingResponse>> GetAllParking()
        {
            IEnumerable<ParkingResponse> response = _service.GetAllParkings();
            return Ok(response);
        }


    }
}
