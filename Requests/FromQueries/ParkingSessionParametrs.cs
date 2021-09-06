using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApi.Requests.FromQueries
{
    public class ParkingSessionParametrs
    {
        /// <summary>
        /// Сar search by number 
        /// </summary>
        public string? searchNumberCar { get; set; }
        /// <summary>
        /// Available sortings: 
        /// -numberCar_asc;
        /// -numberCar_desc;
        /// -startTime_asc;
        /// -endTime_desc(default);
        /// </summary>
        public string SortOrder { get; set; } 


        const int maxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}
