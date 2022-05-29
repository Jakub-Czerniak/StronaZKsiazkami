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
        public static int CrateBook(string title, string author_first_name, string author_last_name, string description, decimal price, int amount, string genre_name)
        {
            BookModel data = new BookModel 
            {
                Title = title,
                Author_first_name = author_first_name,
                Author_last_name = author_last_name,
                Short_desc = description,
                Price = price,
                Amount = amount,
                Genre_name = genre_name
            };

            string sql = @"EXECUTE AddNewBook @Title,  @Author_first_name, @Author_last_name, @Price, 
                            @Short_desc, @Amount, @Genre_name";

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

    }
}
