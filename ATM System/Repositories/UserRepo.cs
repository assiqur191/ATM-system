using ATM_System.Data;
using ATM_System.Entities;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_System.Repositories
{
    class UserRepo
    {
        DataAccess dataAccess;
        public UserRepo()
        {
            dataAccess = new DataAccess();
        }
        public int AddNewUser(int accountno, string name, int mobile, string address, int pin, string birthday, int balance)
        {
            string sql = "INSERT INTO users(AccountNo,Name,Mobile,Address,Pin,Birthday,Balance) VALUES('" + accountno + "','" + name + "','" + mobile + "','" + address + "','" + pin + "','" + birthday + "','" + balance + "')";
            return dataAccess.ExecuteQuery(sql);
        }
        public User UserLogin(User ue)
        {
            try
            {
                string sql = "SELECT * FROM users WHERE AccountNo ='" + ue.AccountNo + "' AND Pin='" + ue.Pin + "'";
                SqlDataReader reader = dataAccess.GetData(sql);
                reader.Read();
                ue.AccountNo = (int)reader["AccountNo"];
                ue.Name = reader["Name"].ToString();
                return ue;
            }
            catch
            {
                return null;
            }
        }
        public User GetUserProfile(int accountno)
        {
            string sql = "SELECT * FROM users WHERE AccountNo='" + accountno + "'";
            SqlDataReader reader = dataAccess.GetData(sql);
            reader.Read();
            User ue = new User();

            ue.AccountNo = (int)reader["AccountNo"];
            ue.Name = reader["Name"].ToString();
            ue.Mobile = (int)reader["Mobile"];
            ue.Address = reader["Address"].ToString();
            ue.Birthday = reader["Birthday"].ToString();

            return ue;
        }
        public int ChangePin(int accountno, int pin)
        {
            try
            {
                string sql = "UPDATE users SET Pin='" + pin + "' WHERE AccountNo='" + accountno + "'";
                return dataAccess.ExecuteQuery(sql);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public User CheckBalance(int accountno)
        {
            string sql = "SELECT * FROM users WHERE AccountNo='" + accountno + "'";
            SqlDataReader reader = dataAccess.GetData(sql);
            reader.Read();
            User ue = new User();

            ue.AccountNo = (int)reader["AccountNo"];
            ue.Name = reader["Name"].ToString();
            ue.Balance = (Int64)reader["Balance"];

            return ue;
        }
        public int CheckAccount(int accountno)
        {
            try
            {
                string sql = "SELECT * FROM users WHERE AccountNo='" + accountno + "'";
                SqlDataReader reader = dataAccess.GetData(sql);
                reader.Read();
                int accno = (int)reader["AccountNo"];
                if (accno == accountno)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch(Exception)
            {
                return 0;
            }
        }
        public User CheckOldPassword(int accountno)
        {
            string sql = "SELECT * FROM users WHERE AccountNo='" + accountno + "'";
            SqlDataReader reader = dataAccess.GetData(sql);
            reader.Read();
            User ue = new User();
            ue.Pin = (int)reader["Pin"];
            return ue;
        }
    }
}
