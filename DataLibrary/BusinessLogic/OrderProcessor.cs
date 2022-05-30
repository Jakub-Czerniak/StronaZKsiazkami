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

        public static List<OrderDetailModel> LoadDetails(int Id)
        {
            OrderDetailModel data = new OrderDetailModel
            {
                OrderId=Id
            };
            string sql = @"EXECUTE FindOrderDetailsById @OrderId";


            return SqlDataAccess.LoadData<OrderDetailModel>(sql,data);
        }

        public static List<OrderModel> LoadOrder(int Id)
        {
            OrderModel data = new OrderModel
            {
                Id = Id
            };
            string sql = @"EXECUTE FindOrderById @Id";

            return SqlDataAccess.LoadData<OrderModel>(sql, data);
        }

        public static int DeleteOrder(int Id)
        {
            OrderModel data = new OrderModel
            {
                Id=Id
            };

            string sql = @"DeleteOrder @Id";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static int EditStatus(int Id, string Status)
        {
            OrderModel data = new OrderModel
            {
                Id = Id,
                Status=Status
            };

            string sql = @"ChangeOrderStatus @Id, @Status";

            return SqlDataAccess.SaveData(sql, data);
        }
    }
}
