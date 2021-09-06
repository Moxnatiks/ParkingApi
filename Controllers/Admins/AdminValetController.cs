using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParkingApi.Models;
using ParkingApi.Requests.Admin.Valet;
using ParkingApi.Responses.Admin;
using ParkingApi.Services.Admin;
using System.Collections.Generic;

namespace ParkingApi.Controllers.Admins
{
    [ApiController]
    [Route("api/admin/valet")]
    [Authorize(Roles = "admin")]
    public class AdminValetController : ControllerBase
    {
        private readonly AdminValetService _service;
        public AdminValetController(AdminValetService service)
        {
            _service = service;
        }
        /// <summary>
        /// Only admins
        /// </summary>
        [HttpGet]
        [Route("get")]
        public ActionResult<IEnumerable<AdminValetResponse>> GetAllValets() 
        {
            IEnumerable<AdminValetResponse> response = _service.GetAllValets();
            return Ok(response);
        }

        /// <summary>
        /// Only admins
        /// </summary>
        [HttpPost]
        [Route("add")]
        public ActionResult<AdminValetResponse> AddValet (CreateAdminValetRequest request)
        {
            AdminValetResponse response = _service.AddValet(request);
            return Ok(response);

        }

        /// <summary>
        /// Only admins
        /// </summary>
        [HttpPut]
        [Route("update/{valetId}")]
        public ActionResult<AdminValetResponse> UpdateValet (UpdateAdminValetRequest request, long valetId)
        {
            AdminValetResponse response = _service.UpdateValet(request, valetId);
            return Ok(response);
        }

        /// <summary>
        /// Only admins
        /// </summary>
        [HttpDelete]
        [Route("delete/{valetId}")]
        public ActionResult DeleteValet(long valetId)
        {
            _service.DeleteValet(valetId);
            return Ok();
        }

    }
}
