using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ParkingApi.Requests.FromQueries;
using ParkingApi.Responses;
using ParkingApi.Responses.Valets;
using ParkingApi.Services.Valets;
using ParkingApi.Settings;

namespace ParkingApi.Controllers.Valets
{
    [ApiController]
    [Route("api/valet/parking")]
    //[Authorize(Roles = "valet")]
    public class ValetParkingСontroller : ControllerBase
    {

        private readonly ApiDbContext DB;
        private readonly IMapper MP;
        private readonly ValetParkingService _service;
        public ValetParkingСontroller (ValetParkingService service,
                                        ApiDbContext apiDbContext,
                                        IMapper mapper)
        {
            DB = apiDbContext;
            _service = service;
            MP = mapper;

        }

        /// <summary>
        /// Only valets
        /// </summary>
        /*[HttpGet]
        [Route("get/{parkingId}")]
        public ActionResult<ValetParkingResponse> GetParkingById (long parkingId)
        {
            ValetParkingResponse response = _service.GetParkingById(parkingId);
            return Ok(response);
        }*/

        //work
        /*        [HttpGet]
                [Route("session/get/{parkingId}")]
                public async Task<ActionResult<IEnumerable<ValetSessionResponse>>> GetParkingSessionByIdAsync(long parkingId,string sortOrder, string searchNumberCar, int? pageNumber)
                {

                    var response = from s in DB.Sessions
                                   select s;

                    if (!String.IsNullOrEmpty(searchNumberCar))
                    {
                        response = response.Where(s => s.Car.Number.Contains(searchNumberCar)
                                               *//*|| s.Car.Model.Contains(searchNumberCar)*//*);
                    }

                    switch (sortOrder)
                    {
                        case "numberCar_asc ":
                            response = response.OrderBy(s => s.Car.Number);
                            break;
                        case "numberCar_desc":
                            response = response.OrderByDescending(s => s.Car.Number);
                            break;

                        default:
                            response = response.OrderBy(s => s.EndTime);
                            break;
                    }

                    int pageSize = 1;


                    PaginatedList<Session> paginate = await PaginatedList<Session>.CreateAsync(response, pageNumber ?? 1, pageSize);

                    IEnumerable<Session> sessions = paginate.ToArray();

                    IEnumerable<ValetSessionResponse> res = MP.Map<IEnumerable<ValetSessionResponse>>(sessions);



                    //PaginateResponse<Session> paginateResponse = MP.Map<PaginateResponse<Session>>(paginate);

                    //ValetSessionResponsePaginate res = MP.Map<ValetSessionResponsePaginate>(paginate);

                    var metadata = new
                    {
                        paginate.PageIndex
                    };

                    Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

                    return Ok(res);
                }*/


        //test
        [HttpGet]
        [Route("session/get/{parkingId}")]
        public ActionResult<PaginateResponse<ValetSessionResponse>> GetParkingSessionsById(long parkingId, [FromQuery] ParkingSessionParametrs parkingSessionParametrs)
        {


            // PaginateResponse < IEnumerable < Session >> ttt = _service.GetParkingSessionsById(parkingId, parkingSessionParametrs);


            PaginateResponse < ValetSessionResponse > response = _service.GetParkingSessionsById(parkingId, parkingSessionParametrs);



            //IEnumerable<Session> sessions = paginate.ToArray();

            //IEnumerable<ValetSessionResponse> res = MP.Map<IEnumerable<ValetSessionResponse>>(sessions);



            //PaginateResponse<Session> paginateResponse = MP.Map<PaginateResponse<Session>>(paginate);

            //ValetSessionResponsePaginate res = MP.Map<ValetSessionResponsePaginate>(paginate);



            return Ok(response);
        }
    }
}
