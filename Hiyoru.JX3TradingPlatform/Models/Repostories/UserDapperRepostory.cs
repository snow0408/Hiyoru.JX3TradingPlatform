using Dapper;
using Hiyoru.JX3TradingPlatform.Models.Dto;
using Hiyoru.JX3TradingPlatform.Models.Interface;
using SqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Hiyoru.JX3TradingPlatform.Models.Repostories
{
    public class UserDapperRepostory : IUserRepostory
    {
        public void Create(UserDto dto)
        {
            string connStr = SqlDb.GetConnectionString("test");
            string sql = "INSERT INTO Users(Id,Password,UserName)VALUES(@Id,@Password,@UserName);";

            using (var conn = new SqlConnection(connStr))
            {
                conn.Query(sql, new { Id = dto.Id, Password = dto.Password, UserName = dto.UserName });
            }
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public UserDto Get(string id)
        {
            string connStr = SqlDb.GetConnectionString("test");
            string sql = @"SELECT Id, Password, BankAccount FROM Users WHERE Id=@Id";

            using (var conn = new SqlConnection(connStr))
            {
                try
                {
                    UserDto data = conn.QueryFirst<UserDto>(sql, new { Id = id });
                    return data;
                }
                catch
                {
                    return null;
                }
            }
        }

        public List<UserDto> Search(string Id)
        {
            string connStr = SqlDb.GetConnectionString("test");
            string sql = @"SELECT * FROM Users WHERE Id=@Id";

            using (var conn = new SqlConnection(connStr))
            {
                List<UserDto> data = conn.Query<UserDto>(sql, new { Id = Id }).ToList();
                return data;
            }
        }

        public void Update(UserDto dto)
        {
            string connStr = SqlDb.GetConnectionString("test");
            string sql = "UPDATE Users SET Password=@Password, UserName=@UserName, Email=@Email, PhoneNumber=@PhoneNumber, BankAccount=@BankAccount WHERE Id=@Id";

            using (var conn = new SqlConnection(connStr))
            {
                conn.Execute(sql, dto);
            }
        }
    }
}
