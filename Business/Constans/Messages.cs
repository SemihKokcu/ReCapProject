using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constans
{
    public static class Messages
    {

        //Public messages
        public static string MaintenanceTime = "System Maintenance";

        //Car messages
        public static string CarAdded = "Car Added";
        public static string CarDeleted = "Car Deleted";
        public static string CarUpdated  = "Car Uptated";
        public static string CarListed = "Car Listed";
        public static string CarDetailListed = "Car Details Listed";
        public static string CarDetailListedByBrandId = "Car Detail Listed By Brand ";
        public static string CarDetailListedByColorId = "Car Detail Listed By Color ";


        //Color messages
        public static string ColorAdded = "Color Added";
        public static string ColorDeleted = "Color Deleted";
        public static string ColorUpdated = "Color Uptated";
        public static string ColorListed = "Color Listed";

        //Brand messages
        public static string BrandAdded = "Brand Added";
        public static string BrandDeleted = "Brand Deleted";
        public static string BrandUpdated = "Brand Uptated";
        public static string BrandListed = "Brand Listed";

        //Customer messages
        public static string CustomerAdded = "Customer Added";
        public static string CustomerDeleted = "Customer Deleted";
        public static string CustomerUpdated = "Customer Uptated";
        public static string CustomerListed = "Customer Listed";

        //Rental messages
        public static string RentalAdded = "Car rented";
        public static string RentalDeleted = "Rental Deleted";
        public static string RentalUpdated = "Rental Uptated";
        public static string RentalListed = "Rental Listed";
        public static string CarIsAlreadyRented = "Car is already rented";




        //User messages
        public static string UserAdded = "User Added";
        public static string UserDeleted = "User Deleted";
        public static string UserUpdated = "User Uptated";
        public static string UserListed = "User Listed";

        public static string RentalListedByCarDetails = "Rental Listed By Car Details";
        public static string RentalListedByNotRentedCars = "Rental listed By Not Rented Cars";
        public static string RentalListedByRentedCars = " Rental listed By Rented Cars";
    }
}
