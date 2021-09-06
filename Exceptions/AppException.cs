using System;
using System.Globalization;

namespace ParkingApi.Exceptions
{
    public class AppException : Exception
    {
        public AppException() : base() { }

        public AppException(string message = "Error!") : base(message) { }

        public AppException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
