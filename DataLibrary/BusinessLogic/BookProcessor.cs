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
                            @Short_desc, @Amount";

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
        public static List<BookModel> LoadBooksBySearch(string param1)
        {
            BookModel data = new BookModel
            {
                Title = param1
            };
            string sql = @"EXECUTE FindBookByString @Title";
            return SqlDataAccess.LoadData<BookModel>(sql, data);
        }
        public static List<BookModel> LoadBooksByData(string title, string short_desc, decimal price, int amount)
        {
            BookModel data = new BookModel
            {
                Title = title,
                Short_desc = short_desc,
                Price = price,
                Amount = amount,

            };
            string sql = @"EXECUTE FindBookIdByOtherData @Title, @Short_desc, @Price, @Amount";
            return SqlDataAccess.LoadData<BookModel>(sql, data);
        }
    }
}
