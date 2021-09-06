using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ParkingApi.Exceptions;
using ParkingApi.Interfaces;
using ParkingApi.Models;
using ParkingApi.Requests.FromQueries;
using ParkingApi.Responses;
using ParkingApi.Responses.Valets;
using ParkingApi.Settings;
using System;
using System.Collections.Generic;

using System.Linq;

namespace ParkingApi.Services.Valets
{
    public class ValetParkingService : BaseService
    {
        private readonly IParking _parkingRepository;
        private readonly ISession _sessionRepository;

        public ValetParkingService( IParking parkingRepository,
                                    ISession sessionRepository,
                                    ApiDbContext apiDbContext,
                                    IMapper mapper) : base(apiDbContext, mapper)
        {
            _parkingRepository = parkingRepository;
            _sessionRepository = sessionRepository;
        }
        public ValetParkingResponse GetParkingById(long parkingId)
        {
            if (_parkingRepository.CheckParkingById(parkingId))
            {
                Parking parking = _parkingRepository.GetParkingByIdForValet(parkingId);
                ValetParkingResponse response = MP.Map<ValetParkingResponse>(parking);
                return response;
            }
            else throw new AppException("Parking not found!");
        }

        public IEnumerable<ValetSessionResponse> GetParkingSessionById (long parkingId)
        {
            IEnumerable<Session> listSessions = _sessionRepository.FindSessionByParkingId(parkingId);

            IEnumerable<ValetSessionResponse> response = MP.Map<IEnumerable<ValetSessionResponse>>(listSessions);

            return response;
        }

        public PaginateResponse<ValetSessionResponse> GetParkingSessionsById (long parkingId, ParkingSessionParametrs parkingSessionParametrs)
        {

            IQueryable<Session> sessions = _sessionRepository.FilterSessionByParkingId(parkingId);

            //Search
            if (!String.IsNullOrEmpty(parkingSessionParametrs.searchNumberCar))
            {
                sessions = sessions.Where(s => s.Car.Number.Contains(parkingSessionParametrs.searchNumberCar)
                                       /*|| s.Car.Model.Contains(searchNumberCar)*/);
            }

            //Sort
            switch (parkingSessionParametrs.SortOrder)
            {
                case "numberCar_asc":
                    sessions = sessions.OrderBy(s => s.Car.Number);
                    break;
                case "numberCar_desc":
                    sessions = sessions.OrderByDescending(s => s.Car.Number);
                    break;
                case "startTime_asc":
                    sessions = sessions.OrderBy(s => s.StartTime);
                    break;

                //endTime_desc
                default:
                    sessions = sessions.OrderByDescending(s => s.EndTime);
                    break;
            }

            PagedList<Session> paginate = PagedList<Session>.ToPagedList(sessions, parkingSessionParametrs.PageNumber , parkingSessionParametrs.PageSize);

            PaginateResponse < ValetSessionResponse > response  = MP.Map<PaginateResponse<ValetSessionResponse>>(paginate);

            return response;
        }
    }
  
}
