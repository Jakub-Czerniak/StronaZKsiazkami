using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public class OrderProcessor
    {
        public static List<OrderModel> PlaceOrder(string firstname, string lastname, string city, string address, string apartment, string postcode, decimal cost)
        {
            OrderModel data = new OrderModel
            {
                FirstName = firstname,
                LastName = lastname,
                City = city,
                Address = address,
                Apartment = apartment,
                Postcode = postcode,
                TotalCost = cost
            };
            string sql = @"EXECUTE PlaceOrder @FirstName, @LastName, @City, @Address, @Apartment, @Postcode, @TotalCost"; 

            return SqlDataAccess.LoadData<OrderModel>(sql, data);
        }
        public static int AddOrderDetails(int order_id, int book_id, int amount)
        {
            OrderDetailModel data = new OrderDetailModel
            {
                OrderId = order_id,
                BookId = book_id,
                Amount = amount
            };
            string sql = @"EXECUTE AddOrderDetails @OrderId, @BookId, @Amount";

            return SqlDataAccess.SaveData<OrderDetailModel>(sql, data);
        }

        public static List<OrderModel> LoadOrders()
        {
            string sql = @"EXECUTE FindAllOrders";

            return SqlDataAccess.LoadData<OrderModel>(sql);
        }
    }
}
