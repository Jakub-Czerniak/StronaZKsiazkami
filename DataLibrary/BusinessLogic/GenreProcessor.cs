using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.DataAccess;
using DataLibrary.Models;

namespace DataLibrary.BusinessLogic
{
    public class GenreProcessor
    {
       public List<GenreModel> LoadAllGenres()
        {
            string sql = @"EXECUTE GetAllGenres";
            return SqlDataAccess.LoadData<GenreModel>(sql);
        }
        public static int CreateGenre(string name)
        {
            GenreModel data = new GenreModel
            {
                GenreName = name
            };


            string sql = @"EXECUTE AddGenre @GenreName";

            return SqlDataAccess.SaveData(sql, data);
        }
        public static List<GenreModel> LoadGenre(int id)
        {
            GenreModel data = new GenreModel
            {
                Id = id
        };
            string sql = @"FindGenreById @Id";
            return SqlDataAccess.LoadData<GenreModel>(sql, data);

        }
        public static List<GenreModel> LoadGenreId(string name)
        {
            GenreModel data = new GenreModel
            {
                GenreName=name
            };
            string sql = @"FindGenreByName @GenreName";
            return SqlDataAccess.LoadData<GenreModel>(sql, data);

        }

    }
}
