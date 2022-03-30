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
    class TransactionRepo
    {
        DataAccess dataAccess;
        public TransactionRepo()
        {
            dataAccess = new DataAccess();
        }
        public int Deposit(int accountno, int ammount)
        {
            try
            {
                string sql = "UPDATE users SET Balance = Balance + '" + ammount + "' WHERE AccountNo='" + accountno + "'";
                return dataAccess.ExecuteQuery(sql);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public User CheckBalanceForWithdraw(int accountno)
        {
            string sql = "SELECT * FROM users WHERE AccountNo='" + accountno + "'";
            SqlDataReader reader = dataAccess.GetData(sql);
            reader.Read();
            User ue = new User();
            ue.Balance = (Int64)reader["Balance"];
            return ue;
        }
        public int Withdraw(int accountno, int ammount)
        {
            try
            {
                string sql = "UPDATE users SET Balance = Balance - '" + ammount + "' WHERE AccountNo='" + accountno + "'";
                return dataAccess.ExecuteQuery(sql);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public List<Transaction> GetAllTransaction(int accountno)
        {
            try
            {
                string sql = "SELECT * FROM transactions where AccountNo='" + accountno + "'";
                SqlDataReader reader = dataAccess.GetData(sql);
                List<Transaction> tra = new List<Transaction>();
                while (reader.Read())
                {
                    Transaction tr = new Transaction();

                    tr.TraxId = (int)reader["TraxId"]; ;
                    tr.AccountNo = (int)reader["AccountNo"]; ;
                    tr.TransactionType = reader["TransactionType"].ToString();
                    tr.TransactionAmount = (int)reader["TransactionAmount"];
                    tr.Balance = (Int64)reader["Balance"];
                    tr.DateAndTime = reader["DateAndTime"].ToString();

                    tra.Add(tr);
                }
                return tra;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public int InsertTransactionData(int accountno, string transactionType, int transactionAmmount, Int64 balance, string dateAndTime)
        {
            string sql = "INSERT INTO transactions(AccountNo,TransactionType,TransactionAmount,Balance,DateAndTime) VALUES('" + accountno + "','" + transactionType + "','" + transactionAmmount + "','" + balance + "','" + dateAndTime + "')";
            return dataAccess.ExecuteQuery(sql);
        }
    }
}
