using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class BillInfoDAO
    {
        private static BillInfoDAO instance;

        public static BillInfoDAO Instance 
        { get { if (instance == null) instance = new BillInfoDAO();  return BillInfoDAO.instance; }
          private set { BillInfoDAO.instance = value; }


        }
        private BillInfoDAO() { }
        public void DeleteBillInfoByFoodID(int id)
        {
            DataTable data = Dataprovider.Instance.ExecuteQuery("DELETE dbo.BillInfo WHERE idFood = " + id);
        }
        //public DataTable GetListBillInfor()
        //{
        //    return Dataprovider.Instance.ExecuteQuery("SELECT * FROM dbo.BillInfo");
        //}
        public List<BillInfo> GetListBillInfos(int id)
        {
            List<BillInfo> listBillInfo = new List<BillInfo>();

            DataTable data = Dataprovider.Instance.ExecuteQuery("SELECT * FROM dbo.BillInfo WHERE idBill = " + id);
            foreach(DataRow item in data.Rows)
            {
                BillInfo info = new BillInfo(item);
                listBillInfo.Add(info);
            }
            return listBillInfo;
        }
        public void InsertBillInfo(int idBill,int idFood,int count)
        {
            Dataprovider.Instance.ExecuteQuery("USP_InsertBillinfo @idBill , @idFood , @count", new object[] { idBill, idFood, count });
        }
    }
}
