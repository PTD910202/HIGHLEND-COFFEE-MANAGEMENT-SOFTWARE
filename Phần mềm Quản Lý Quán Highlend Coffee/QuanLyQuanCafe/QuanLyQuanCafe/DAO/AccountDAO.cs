using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using QuanLyQuanCafe.DTO;

namespace QuanLyQuanCafe.DAO
{
    public class AccountDAO
    { 
        private static AccountDAO instance;

        public static AccountDAO Instance 
        {
          get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set { instance = value; }
        }
        private AccountDAO() { }
        public bool Login(string userName,string passWord)
        {
            string query = "SELECT * FROM dbo.Account WHERE UserName = N'" + userName + "'   AND PassWord = N'"+ passWord +"' ";
            DataTable result = Dataprovider.Instance.ExecuteQuery(query);
            return result.Rows.Count > 0;

        }
        public bool UpdateAccount(string userName, string displayName, string pass, string newPass)
        {
            int result = Dataprovider.Instance.ExecuteNonQuery("exec USP_UpdateAccount @userName , @displayName , @password , @newPassword ", new object[] {userName,displayName,pass,newPass});
            return result > 0;
        }
        public Account GetAccountByUserName(string userName)
        {
            DataTable data = Dataprovider.Instance.ExecuteQuery("Select * from account where userName = '" + userName + "'");

            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }

            return null;
        }
        public DataTable GetListAccount()
        {
            return Dataprovider.Instance.ExecuteQuery("SELECT * FROM dbo.Account");
        }

        //public List<Account> GetListAccount()
        //{
        //    List<Account> list = new List<Account>();
        //    //string query = "SELECT UserName as [Tên tài khoản],DisplayName as [Tên hiển thị],PassWord as [Mật khẩu],Type as [Loại tài khoản] FROM dbo.Account";
        //    string query = "SELECT * FROM dbo.Account";

        //    DataTable data = Dataprovider.Instance.ExecuteQuery(query);

        //    foreach (DataRow item in data.Rows)
        //    {
        //        Account account = new Account(item);
        //        list.Add(account);
        //    }

        //    return list;
        //}

        public bool InsertAccount(string name, string displayName, int type)
        {
            string query = string.Format("INSERT dbo.Account ( UserName, DisplayName, Type )VALUES  ( N'{0}', N'{1}', {2})", name, displayName, type);
            int result = Dataprovider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool updateAccount(string name, string displayName, int type)
        {
            string query = string.Format("UPDATE dbo.Account SET UserName = N'{0}', Type = {2} WHERE  DisplayName = N'{1}'", name, displayName, type);
            int result = Dataprovider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteAccount(string name)
        {
            string query = string.Format("Delete Account where UserName = N'{0}'", name);
            int result = Dataprovider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool ResetPassword(string displayName)
        {
            string query = string.Format("update Account set password = N'0' where DisplayName = N'{0}'", displayName);
            int result = Dataprovider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
