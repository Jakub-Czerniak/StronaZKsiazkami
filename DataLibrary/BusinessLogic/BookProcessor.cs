using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public static class BookProcessor
    {
        public static int CrateBook(string title, string author_first_name, string author_last_name, string description, decimal price, int amount)
        {
            BookModel data = new BookModel 
            {
                Title = title,
                Author_first_name = author_first_name,
                Author_last_name = author_last_name,
                Short_desc = description,
                Price = price,
                Amount = amount
            };

            string sql = @"EXECUTE AddNewBook @Title,  @Author_first_name, @Author_last_name, @Price, 
                            @Description, @Amount";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<BookModel> LoadBooks()
        {
            string sql = @"EXECUTE FindAllBooks";

            return SqlDataAccess.LoadData<BookModel>(sql);
        }

        public static List<BookModel> LoadBook(int id)
        {
            BookModel data = new BookModel
            {
                Id = id
            };
            string sql = @"EXECUTE FindBookById @Id";

            return SqlDataAccess.LoadData<BookModel>(sql, data);
        }
    }
}
