using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constans
{
    public static class Message
    {
        public static string ProductAdded { get; } = "Product is added";
        public static string ProductDeleted { get; } = "Product is added";
        public static string ProductUpdated { get; } = "Product is added";
        public static string ProductAlreadyExist { get; } = "Product already exist";
        public static string ProductLimitIsFull { get; } = "Product limit is full";

        public static string CategoryAdded { get; } = "Category is added";
        public static string CategoryDeleted { get; } = "Category is added";
        public static string CategoryUpdated { get; } = "Category is added";
        public static string CategoryAlreadyExist { get; } = "Category already exist";
    }
}
