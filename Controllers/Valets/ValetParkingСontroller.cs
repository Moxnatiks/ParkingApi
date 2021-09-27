using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ParkingApi.Requests.FromQueries;
using ParkingApi.Responses;
using ParkingApi.Responses.Valets;
using ParkingApi.Services.Valets;
using ParkingApi.Settings;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bogus;
using ParkingApi.Models;
using System;
using System.Collections.Generic;

namespace ParkingApi.Controllers.Valets
{
    [ApiController]
    [Route("api/valet/parking")]
    //[Authorize(Roles = "valet")]
    public class ValetParkingСontroller : ControllerBase
    {

        private readonly ValetParkingService _service;
        public ValetParkingСontroller (ValetParkingService service)
        {
            _service = service;
        }


        [HttpGet]
        [Route("session/get/{parkingId}")]
        public async Task<ActionResult<PaginateResponse<ValetSessionResponse>>> GetParkingSessionsById(long parkingId, [FromQuery] ParkingSessionParametrs parkingSessionParametrs)
        {

            PaginateResponse < ValetSessionResponse > response = await _service.GetParkingSessionsById(parkingId, parkingSessionParametrs);


            return Ok(response);

        }


        [HttpGet]
        [Route("test")]
        public ActionResult GetParkingSessionsById()
        {
            return Ok();
        }
    }
}
