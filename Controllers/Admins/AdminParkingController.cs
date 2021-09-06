using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParkingApi.Requests.Admin.Parking;
using ParkingApi.Responses;
using ParkingApi.Services.AdminParking;

namespace ParkingApi.Controllers.Admins
{
    [ApiController]
    [Route("api/admin/parking")]
    //[Authorize(Roles = "admin")]
    public class AdminParkingController : ControllerBase
    {
        private readonly AdminParkingService _service;
        public AdminParkingController(AdminParkingService service)
        {
            _service = service;
        }

        /// <summary>
        /// Only admins
        /// </summary>
         [HttpPost]
         [Route("add")]
         public ActionResult<ParkingResponse> AddParking(CreateAdminParkingRequest request)
         {
             ParkingResponse response = _service.CreateParking(request);
             return Ok(response);
         }

        /// <summary>
        /// Only admins
        /// </summary>
        [HttpPut]
         [Route("update/{parkingId}")]
         public ActionResult<ParkingResponse> UpdateParking (UpdateAdminParkingRequest request, long parkingId)
         {
             ParkingResponse response = _service.UpdateParking(request, parkingId);
             return Ok(response);
         }

        /// <summary>
        /// Only admins
        /// </summary>
        [HttpDelete]
         [Route("delete/{parkingId}")]
         public ActionResult DeleteParking (long parkingId)
         {
             _service.DeleteParking(parkingId);
             return Ok();
         }

    }
}

