using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.DataAccess;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace DataLibrary.BusinessLogic
{
    public class EmployeProcessor
    {
        public static List<EmployeModel> Login(string email, string password)
        {
            byte[] salt = new byte[128 / 8];

            EmployeModel data = new EmployeModel
            {
                Email = email,
                Password = Convert.ToBase64String(KeyDerivation.Pbkdf2(password: password,salt: salt, prf: KeyDerivationPrf.HMACSHA256, iterationCount: 100000,
            numBytesRequested: 256 / 8))
            };

            string sql = @"EXECUTE Login @Email, @Password";

            return SqlDataAccess.LoadData<EmployeModel>(sql, data);
        }
    }
}
