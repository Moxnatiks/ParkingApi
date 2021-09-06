using AutoMapper;
using ParkingApi.Exceptions;
using ParkingApi.Interfaces;
using ParkingApi.Models;
using ParkingApi.Requests.Admin.Valet;
using ParkingApi.Responses.Admin;
using ParkingApi.Settings;
using System.Collections.Generic;

namespace ParkingApi.Services.Admin
{
    public class AdminValetService : BaseService
    {
        private readonly IValet _valetRepository;

        public AdminValetService(IValet valetRepository,
                                ApiDbContext apiDbContext,
                                IMapper mapper) : base(apiDbContext, mapper)
        {
            _valetRepository = valetRepository;
        }

        public IEnumerable<AdminValetResponse> GetAllValets ()
        {
            IEnumerable<Valet> valets = _valetRepository.GetAllValets();
            IEnumerable<AdminValetResponse> response = MP.Map<IEnumerable<AdminValetResponse>>(valets);
            return response;
        }

        public AdminValetResponse AddValet(CreateAdminValetRequest request)
        {
            if (_valetRepository.CheckValetByEmail(request.Email) != true)
            {
                Valet valet = MP.Map<Valet>(request);
                HashSalt data = new HashPassword(valet.Password).EncryptPassword();
                if (data != null)
                {
                    if (request.IsAccess == null)
                    {
                        valet.IsAccess = true;
                    }
                    valet.Password = data.Hash;
                    valet.StoredSalt = data.Salt;
                    valet = _valetRepository.AddValet(valet);
                    AdminValetResponse response = MP.Map<AdminValetResponse>(valet);
                    return response;
                }
                else throw new AppException("Invalid password!");
            }
            else throw new AppException("Email busy!");
        }

        public AdminValetResponse UpdateValet (UpdateAdminValetRequest request, long valetId)
        {
            if (_valetRepository.CheckValetById(valetId))
            {
                Valet requestValet = MP.Map<Valet>(request);
                Valet existValet = _valetRepository.GetValetById(valetId);

                if (requestValet.Email != null)
                {
                    if (requestValet.Email != existValet.Email)
                    {
                        if (_valetRepository.CheckValetByEmail(requestValet.Email) == false)
                        {
                            existValet.Email = requestValet.Email;
                        }
                        else throw new AppException("Email busy!");
                    }
                }
                existValet.Full_name = requestValet.Full_name;
                existValet.IsAccess = requestValet.IsAccess;
                existValet.Jetton = requestValet.Jetton;
                existValet.Phone = requestValet.Phone;

                if (requestValet.Password != null)
                {
                    HashSalt data = new HashPassword(requestValet.Password).EncryptPassword();
                    existValet.Password = data.Hash;
                    existValet.StoredSalt = data.Salt;
                }
                existValet = _valetRepository.UpdateValet(existValet);
                AdminValetResponse response = MP.Map<AdminValetResponse>(existValet);
                return response;
            }
            else throw new AppException("Valet not found!");
        }

        public void DeleteValet (long valetId)
        {
            _valetRepository.DeleteValet(valetId);
        }
    }
}
