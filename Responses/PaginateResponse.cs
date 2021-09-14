using Microsoft.AspNetCore.Mvc.Rendering;
using ParkingApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApi.Responses
{
    public class PaginateResponse<T>
    {
        public  List<T> Items { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public bool HasNext { get; set; }
        public bool HasPrevious { get; set; }
        public int TotalCount { get;  set; }

       /* public PaginateResponse() { }

        public PaginateResponse(List<T> _items, int _currentPage, int _totalPage, bool _hasNextPage, bool _hasPreviousPage )
        {
            Items = _items;
            CurrentPage = _currentPage;
            TotalPages = _totalPage;
            HasNextPage = _hasNextPage;
            HasPreviousPage = _hasPreviousPage;
        }*/
    }
}
