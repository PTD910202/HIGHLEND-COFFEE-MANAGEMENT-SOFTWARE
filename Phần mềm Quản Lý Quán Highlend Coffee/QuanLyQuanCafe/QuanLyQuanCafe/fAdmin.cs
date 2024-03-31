using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
using System.Xml.Serialization;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace QuanLyQuanCafe
{

    public partial class fAdmin : Form
    {
        BindingSource foodList = new BindingSource();
        BindingSource accountList = new BindingSource();
        BindingSource tableList = new BindingSource();
        BindingSource CategoryList = new BindingSource();

        public Account loginAccount;
        public fAdmin()
        {
            InitializeComponent();
            Load();


        }
        void Load()
        {
            dtgvFood.DataSource = foodList;
            dtgvAccount.DataSource = accountList;
            dtgvTableFood.DataSource = tableList;
            dtgvCategory.DataSource = CategoryList;
            LoadAccountList();
            LoadTableFoodList();
            LoadListCategory();
            LoadListFood();
            LoadDateTimePickerBill();
            LoadListBillByDate(dtpkFromDate.Value, dtpkToDate.Value);
            AddFoodBinding();
            LoadCategoryCombobox(cbFoodCategory);
            AddCategoryBinding();
            AddTableBinding();
            AddAccountBinding();
            LoadListBill(dtpkformDay.Value, dtpktoDay.Value);
        }
        void LoadListBill(DateTime checkIn, DateTime checkOut)
        {
            dtgvBillInfo.DataSource = BillDAO.Instance.GetListBill(checkIn, checkOut);
        }

        //hiển thị danh sách food khi tìm
        List<Food> SearchFoodByName(string name)
        {
            List<Food> listFood = FoodDAO.Instance.SearchFoodByName(name);

            return listFood;
        }
        void LoadListFood()
        {

            foodList.DataSource = FoodDAO.Instance.GetListFood();
        }
        void LoadListCategory()
        {

            CategoryList.DataSource = CategoryDAO.Instance.GetListCategory();
        }

        void LoadAccountList()
        {

            accountList.DataSource = AccountDAO.Instance.GetListAccount();
        }
        void LoadTableFoodList()
        {

            tableList.DataSource = TableDAO.Instance.GetListTable();
        }
        void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dtpkFromDate.Value = new DateTime(today.Year, today.Month, 1);
            dtpkToDate.Value = dtpkFromDate.Value.AddMonths(1).AddDays(-1);
        }

        //binding thức ăn
        void AddFoodBinding()
        {
            txbFoodName.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "Name"));
            txbFoodID.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "ID"));
            nmFoodPrice.DataBindings.Add(new Binding("Value", dtgvFood.DataSource, "price"));
        }
        void AddCategoryBinding()
        {
            txbCategoryID.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "ID"));
            txbCategoryName.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "Name"));
        }
        void AddTableBinding()
        {
            txbTableName.DataBindings.Add(new Binding("Text", dtgvTableFood.DataSource, "Name"));
            txbTableID.DataBindings.Add(new Binding("Text", dtgvTableFood.DataSource, "ID"));
            cbStatusTable.DataBindings.Add(new Binding("Text", dtgvTableFood.DataSource, "Status"));
        }
        void AddAccountBinding()
        {
            // true, DataSourceUpdateMode.Never không chuyển đổi ngược dữ liệu từ textbox về datagirdview
            txbUserName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            txbDisplayName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
            nmAccountType.DataBindings.Add(new Binding("Value", dtgvAccount.DataSource, "Type", true, DataSourceUpdateMode.Never));

        }

        //load danh mục
        void LoadCategoryCombobox(ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.GetListCategory();
            cb.DisplayMember = "Name";
        }
        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void panel28_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tpAccount_Click(object sender, EventArgs e)
        {

        }

        private void dtgvTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtgvAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tpTable_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
        #region methods
        void LoadListBillByDate(DateTime checkIn, DateTime checkOut)
        {
            dtgvBill.DataSource = BillDAO.Instance.GetBillListByDate(checkIn, checkOut);


        }
        #endregion
        #region events

        private event EventHandler insertFood;
        public event EventHandler InsertFood
        {
            add { insertFood += value; }
            remove { insertFood -= value; }
        }

        private event EventHandler deleteFood;
        public event EventHandler DeleteFood
        {
            add { deleteFood += value; }
            remove { deleteFood -= value; }
        }

        private event EventHandler updateFood;
        public event EventHandler UpdateFood
        {
            add { updateFood += value; }
            remove { updateFood -= value; }
        }
        //Btn thong ke
        private void btnViewBill_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(dtpkFromDate.Value, dtpkToDate.Value);
        }
        #endregion

        private void dtgvFood_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnShowFood_Click(object sender, EventArgs e)
        {
            LoadListFood();
        }

        private void tpFood_Click(object sender, EventArgs e)
        {

        }


        //thêm món
        private void btnAddFood_Click(object sender, EventArgs e)
        {
            string name = txbFoodName.Text;
            int categoryID = (cbFoodCategory.SelectedItem as Category).ID;
            float price = (float)nmFoodPrice.Value;

            if (FoodDAO.Instance.InsertFood(name, categoryID, price))
            {
                MessageBox.Show("Thêm món thành công");
                LoadListFood();
                if (insertFood != null)
                    insertFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm thức ăn hãy thử lại");
            }
        }

        private void txbFoodID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtgvFood.SelectedCells.Count > 0)
                {
                    int id = (int)dtgvFood.SelectedCells[0].OwningRow.Cells["CategoryID"].Value;

                    Category cateogory = CategoryDAO.Instance.GetCategoryByID(id);

                    cbFoodCategory.SelectedItem = cateogory;

                    int index = -1;
                    int i = 0;
                    foreach (Category item in cbFoodCategory.Items)
                    {
                        if (item.ID == cateogory.ID)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }

                    cbFoodCategory.SelectedIndex = index;

                }
            }
            catch { }
        }

        private void btnShowCategory_Click(object sender, EventArgs e)
        {
            LoadListCategory();
        }

        private void btnShowTable_Click(object sender, EventArgs e)
        {
            LoadTableFoodList();
        }
        //sửa món
        private void btnEditFood_Click(object sender, EventArgs e)
        {
            string name = txbFoodName.Text;
            int categoryID = (cbFoodCategory.SelectedItem as Category).ID;
            float price = (float)nmFoodPrice.Value;
            int id = Convert.ToInt32(txbFoodID.Text);
            if (FoodDAO.Instance.UpdateFood(id, name, categoryID, price))
            {
                MessageBox.Show("Sửa món thành công");
                LoadListFood();
                if (updateFood != null)
                    updateFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa thức ăn hãy thử lại");
            }
        }
        //xóa món
        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbFoodID.Text);

            if (FoodDAO.Instance.DeleteFood(id))
            {
                MessageBox.Show("Xóa món thành công");
                LoadListFood();
                if (deleteFood != null)
                    deleteFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa thức ăn");
            }
        }
        //thêm danh mục
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            string name = txbCategoryName.Text;
            if (CategoryDAO.Instance.InsertCategory(name))
            {
                MessageBox.Show("Thêm danh mục thành công");
                LoadListCategory();
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm danh mục hãy thử lại");
            }
        }
        //sửa danh  mục
        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbCategoryID.Text);
            string name = txbCategoryName.Text;

            if (CategoryDAO.Instance.UpdateCategory(id, name))
            {
                MessageBox.Show("Sửa danh mục thành công");
                LoadListCategory();
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa danh mục hãy thử lại");
            }
        }
        //thêm bàn 
        private void btnAddTable_Click(object sender, EventArgs e)
        {
            string name = txbTableName.Text;
            string status = cbStatusTable.Text;
            if (TableDAO.Instance.InsertTable(name, status))
            {
                MessageBox.Show("Thêm bàn thành công");
                LoadTableFoodList();
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm bàn hãy thử lại");
            }
        }
        //sửa bàn
        private void btnEditTable_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbTableID.Text);
            string name = txbTableName.Text;
            string status = cbStatusTable.Text;
            if (TableDAO.Instance.UpdateTable(id, name, status))
            {
                MessageBox.Show("Sửa bàn thành công");
                LoadTableFoodList();
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa bàn hãy thử lại");
            }
        }
        //xóa danh mục
        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbCategoryID.Text);

            if (CategoryDAO.Instance.DeleteCategory(id))
            {
                MessageBox.Show("Xóa danh mục thành công");
                LoadListCategory();
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa danh mục hãy thử lại");
            }
        }
        //xóa bàn ăn
        private void btnDeleteTable_Click(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(txbTableID.Text);

            if (TableDAO.Instance.DeleteTable(id))
            {
                MessageBox.Show("Xóa bàn thành công");
                LoadTableFoodList();
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa bàn hãy thử lại");
            }
        }
        //tìm kiếm món ăn theo tên và hiển thị 
        private void btnSeachFood_Click(object sender, EventArgs e)
        {
            foodList.DataSource = SearchFoodByName(txbSeachFoodName.Text);
        }

        private void btnShowAccount_Click(object sender, EventArgs e)
        {
            LoadAccountList();
        }
        //thêm tài khoản
        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string displayName = txbDisplayName.Text;
            int type = (int)(nmAccountType.Value);
            if (AccountDAO.Instance.InsertAccount(userName, displayName, type))
            {
                MessageBox.Show("Thêm tài khoản mới thành công");
                LoadAccountList();
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm tài khoản mới hãy thử lại");
            }
        }
        //sửa tài khoản
        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string displayName = txbDisplayName.Text;
            int type = (int)(nmAccountType.Value);
            if (AccountDAO.Instance.updateAccount(userName, displayName, type))
            {
                MessageBox.Show("Sửa tài khoản thành công");
                LoadAccountList();
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa tài khoản hãy thử lại");
            }
        }
        //Xóa tài khoản
        private void btnDeleteAsccount_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            if (loginAccount.UserName.Equals(userName))
            {
                MessageBox.Show("Vui lòng không xóa tài khoản đang đăng nhập trên hệ thống");
                return;
            }
            if (AccountDAO.Instance.DeleteAccount(userName))
            {
                MessageBox.Show("Xóa tài khoản thành công");
                LoadAccountList();
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa tài khoản hãy thử lại");
            }
        }
        //Btn đặt lại mật khẩu
        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            string displayName = txbDisplayName.Text;

            if (AccountDAO.Instance.ResetPassword(displayName))
            {
                MessageBox.Show("Đặt lại mật khẩu thành công");
            }
            else
            {
                MessageBox.Show("Có lỗi khi đặt lại mật khẩu hãy thử lại");
            }
        }

        private void tpFoodCategory_Click(object sender, EventArgs e)
        {

        }
        //btnPrevioursBillPage btn hiện trang trước
        private void button2_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(txbPageBill.Text);
            if (page > 1)
                page--;

            txbPageBill.Text = page.ToString();
        }
        //btnFirstBillPage btn hiện trang đầu
        private void btnPrevioursBillPage_Click(object sender, EventArgs e)
        {
            txbPageBill.Text = "1";
        }
        //Btn hiện trang sau
        private void btnNextBillPage_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(txbPageBill.Text);
            int sumRecord = BillDAO.Instance.GetNumBillListByDate(dtpkFromDate.Value, dtpkToDate.Value);

            if (page < sumRecord)
                page++;

            txbPageBill.Text = page.ToString();
        }
        //Btn hiện trang cuối
        private void btnLastBillPage_Click(object sender, EventArgs e)
        {
            int sumRecord = BillDAO.Instance.GetNumBillListByDate(dtpkFromDate.Value, dtpkToDate.Value);

            int lastPage = sumRecord / 10;
            if (sumRecord % 10 != 0)
                lastPage++;
            txbPageBill.Text = lastPage.ToString();
        }
        //Hiển thị số trang của danh thu
        private void txbPageBill_TextChanged(object sender, EventArgs e)
        {
            dtgvBill.DataSource = BillDAO.Instance.GetBillListByDateAndPage(dtpkFromDate.Value, dtpkToDate.Value, Convert.ToInt32(txbPageBill.Text));
        }

        private void fAdmin_Load(object sender, EventArgs e)
        {

        }

        private void tpBill_Click(object sender, EventArgs e)
        {

        }

        private void tpFood_Click_1(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dtgvBill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bntExitBillInfor_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrintBill_Click(object sender, EventArgs e)
        {
            ppdBill.Document = pdBill;
            ppdBill.ShowDialog();
        }

        private void bntnViewBillDay_Click(object sender, EventArgs e)
        {
            LoadListBill(dtpkformDay.Value, dtpktoDay.Value);
        }

        private void fAdmin_Load_1(object sender, EventArgs e)
        {

        }

        private void dtgvBillInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if(e.RowIndex >= 0)
            //{

            //}
        }

        private void pdBill_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            //lấy bề rộng giấy
            var W = pdBill.DefaultPageSettings.PaperSize.Width;
            //Thêm tên của hàng Highlend coffee
            e.Graphics.DrawString(lbNameStore.Text, new Font("#9Slide03 BoosterNextFYBlack", 17, FontStyle.Regular), Brushes.Blue, new Point(130, 20));
            //Thêm tên hóa đơn
            e.Graphics.DrawString(lbNameBill.Text, new Font("UTM Rockwell", 11, FontStyle.Regular), Brushes.Black, new Point(130, 60));
            //in thông tin hóa đơn
            Bitmap bm = new Bitmap(this.dtgvBillInfo.Width, this.dtgvBillInfo.Height);
            dtgvBillInfo.DrawToBitmap(bm, new Rectangle(0, 0, this.dtgvBillInfo.Width, this.dtgvBillInfo.Height));
            e.Graphics.DrawImage(bm, 130, 120);
        }

        private void dtpkToDate_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
