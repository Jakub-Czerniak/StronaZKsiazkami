using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.DataAccess;
using DataLibrary.Models;
using DataLibrary.BusinessLogic;

namespace DataLibrary.BusinessLogic
{
    public class BookGenreProcessor
    {
        public static int CreateBookGenre(int bookId, int genreId)
        {
            BookGenre data = new BookGenre
            {
                BookId = bookId,
                GenreId = genreId
            };
            string sql = @"EXECUTE AddBookGenre @BookId, @GenreId";

            return SqlDataAccess.SaveData(sql, data);
        }
        public static List<BookGenre> LoadBookGenres()
        {
            string sql = @"EXECUTE GetAllBookGenre";
            return SqlDataAccess.LoadData<BookGenre>(sql);
        }
    }
}
