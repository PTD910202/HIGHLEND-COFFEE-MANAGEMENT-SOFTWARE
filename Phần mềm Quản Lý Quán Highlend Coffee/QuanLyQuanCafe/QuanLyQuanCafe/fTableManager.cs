using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace QuanLyQuanCafe
{
    public partial class fTableManager : Form
    {
        private Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; changeAccount(loginAccount.Type); }
        }

        public fTableManager(Account acc)
        {
            InitializeComponent();
            this.LoginAccount = acc;
            LoadTable();
            LoadCategory();
            LoadComboboxTable(cbSwitchTable);
        }
        #region Method
        //Thay đổi thông tin tài khoản 
        void changeAccount(int type)
        {
            //Khi type == 1 == "Admin" mới có thể vào trang admin
            adminToolStripMenuItem.Enabled = type == 1;
            //Hiền thị thêm tên tài khoản đang đăng nhập hệ thống
            thôngTinCáNhânToolStripMenuItem.Text += "(" + LoginAccount.DisplayName + ")";
        }
        void LoadCategory()
        {
            List<Category> listCaterory = CategoryDAO.Instance.GetListCategory();
            cbCategory.DataSource = listCaterory;
            cbCategory.DisplayMember = "Name";
        }
        void LoadFoodListByCategoryID(int id)
        {
            List<Food> listFood = FoodDAO.Instance.GetFoodByCategoryID(id);
            cbFood.DataSource = listFood;
            cbFood.DisplayMember = "Name";
        }

        //Load lại bàn khi đặc món
        void LoadTable()
        {
            flpTable.Controls.Clear();
            List<Table> tableList = TableDAO.Instance.LoadTableList();
            foreach (Table item in tableList)
            {
                Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };
                btn.Text = item.Name + Environment.NewLine + item.Status;
                btn.Click += btn_Click;
                btn.Tag = item;

                switch (item.Status)
                {
                    //Thay đổi thông tin bàn và màu sắc
                    case "Trống":
                        btn.BackColor = Color.Blue;
                        break;
                    default:
                        btn.BackColor = Color.Red;
                        break;

                }
                flpTable.Controls.Add(btn);
            }
        }

        //Hiển thị hóa đơn
        void ShowBill(int id)
        {
            lsvBill.Items.Clear();
            List<QuanLyQuanCafe.DTO.Menu> listBillInfo = MenuDAO.Instance.GetListMenuByTable(id);
            float totalPrice = 0;
            foreach (QuanLyQuanCafe.DTO.Menu item in listBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.FoodName.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.TotalPrice.ToString());
                totalPrice += item.Price * item.Count;
                lsvBill.Items.Add(lsvItem);
            }
            //chuyển đổi tiền tử $ sang vnđ
            CultureInfo culture = new CultureInfo("vi-VN");

            txbTotalPrice.Text = totalPrice.ToString("c", culture);

        }
        void btn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as Table).ID;
            lsvBill.Tag = (sender as Button).Tag;
            ShowBill(tableID);
        }
        void LoadComboboxTable(ComboBox cb)
        {
            cb.DataSource = TableDAO.Instance.LoadTableList();
            cb.DisplayMember = "Name";
        }
        #endregion
        #region Event

        //Thông tin cá nhân thôngTinCáNhânToolStripMenuItem_Click 
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccountProfile f = new fAccountProfile(LoginAccount);
            f.UpdateAccount += F_UpdateAccount; ;
            f.ShowDialog();
        }

        private void F_UpdateAccount(object? sender, fAccountProfile.AccountEvent e)
        {
            thôngTinCáNhânToolStripMenuItem.Text = "Thông tài khoản (" + e.Acc.DisplayName + ")";
        }


        private void đăngXuấtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Hàm admin aDMINToolStripMenuItem_Click
        private void aDMINToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin f = new fAdmin();
            f.loginAccount = LoginAccount;
            f.InsertFood += F_InsertFood;
            f.DeleteFood += F_DeleteFood;
            f.UpdateFood += F_UpdateFood;
            //Hiển thị
            f.ShowDialog();
        }

        void F_UpdateFood(object? sender, EventArgs e)
        {
            LoadFoodListByCategoryID((cbCategory.SelectedItem as Category).ID);
            if (lsvBill.Tag != null)
                ShowBill((lsvBill.Tag as Table).ID);
        }
        //Hàm xử lý sự kiện khi xóa món
        void F_DeleteFood(object? sender, EventArgs e)
        {
            LoadFoodListByCategoryID((cbCategory.SelectedItem as Category).ID);
            if (lsvBill.Tag != null)
                ShowBill((lsvBill.Tag as Table).ID);
            LoadTable();
        }
        //Hàm xử lý sự kiện khi thêm món
        void F_InsertFood(object? sender, EventArgs e)
        {
            LoadFoodListByCategoryID((cbCategory.SelectedItem as Category).ID);
            if (lsvBill.Tag != null)
                ShowBill((lsvBill.Tag as Table).ID);
        }

        private void fTableManager_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        #endregion

        private void nmFoodCount_ValueChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        //Chọn danh mục theo món ăn
        private void cbCategory_SelectIndexChange(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;
            Category selected = cb.SelectedItem as Category;
            id = selected.ID;

            LoadFoodListByCategoryID(id);
        }
        //Button thêm món
        private void btnAddFood_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;
            if (table == null)
            {
                MessageBox.Show("Hãy chọn bàn trước khi  thêm món");
                return;
            }
            int idBill = BillDAO.Instance.GetUnCheckBillByTableID(table.ID);
            int foodID = (cbFood.SelectedItem as Food).ID;
            int count = (int)nmFoodCount.Value;

            if (idBill == -1)
            {
                BillDAO.Instance.InsertBill(table.ID);
                BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIDBill(), foodID, count);
            }
            else
            {
                BillInfoDAO.Instance.InsertBillInfo(idBill, foodID, count);
            }
            ShowBill(table.ID);
            LoadTable();
        }
        //Button xử lý sự kiện khi thanh toán  
        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;

            int idBill = BillDAO.Instance.GetUnCheckBillByTableID(table.ID);
            int discount = (int)nmDisCount.Value;

            double totalPrice = Convert.ToDouble(txbTotalPrice.Text.Split(' ')[0]);
            double finalTotalPrice = totalPrice - (totalPrice / 100) * discount;

            if (idBill != -1)
            {
                if (MessageBox.Show(string.Format("Bạn có chắc thanh toán hóa đơn cho bàn {0}\nTổng tiền - (Tổng tiền / 100) x Giảm giá\n=> {1} - ({1} / 100) x {2} = {3}", table.Name, totalPrice, discount, finalTotalPrice), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    BillDAO.Instance.CheckOut(idBill, discount, (float)finalTotalPrice);
                    ShowBill(table.ID);

                    LoadTable();
                }
            }
        }
        //Button chuyển bàn
        private void btnSwichTable_Click(object sender, EventArgs e)
        {
            int id1 = (lsvBill.Tag as Table).ID;

            int id2 = (cbSwitchTable.SelectedItem as Table).ID;

            if (MessageBox.Show(string.Format("Bạn có thật sự muốn chuyển bàn {0} qua bàn {1}", (lsvBill.Tag as Table).Name, (cbSwitchTable.SelectedItem as Table).Name), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                TableDAO.Instance.SwitchTable(id1, id2);

                LoadTable();
            }
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void flpTable_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flpTable_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void fTableManager_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void PrintBillInfo_Click(object sender, EventArgs e)
        {
            {
                Table table = lsvBill.Tag as Table;
                if (table == null)
                {
                    MessageBox.Show("Hãy chọn bàn");
                    return;
                }
                int idBill = BillDAO.Instance.GetUnCheckBillByTableID(table.ID);
                if (idBill != -1)
                {
                    if (MessageBox.Show(string.Format("Bạn có muốn in hóa đơn"), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        pddPrintBill.Document = pdPrintBill;
                        pdPrintBill.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Suit Detail", 600, 1000);
                        pddPrintBill.ShowDialog();

                    }
                }
            }

        }
        //In thông tin hóa đơn theo bàn khi order thức ăn 
        private void pdPrintBill_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Table table = lsvBill.Tag as Table;

            int idBill = BillDAO.Instance.GetUnCheckBillByTableID(table.ID);
            int discount = (int)nmDisCount.Value;

            double totalPrice = Convert.ToDouble(txbTotalPrice.Text.Split(' ')[0]);
            double finalTotalPrice = totalPrice - (totalPrice / 100) * discount;
            double tiengiam = Math.Round((totalPrice / 100) * discount);


            int w = pdPrintBill.DefaultPageSettings.PaperSize.Width;
            Pen blackPen = new Pen(Color.Black, 1);
            e.Graphics.DrawString("HIGHLEND COFFEE", new Font("Stencil", 20), Brushes.Blue, new Point(200, 40));
            e.Graphics.DrawString("Hóa đơn thanh toán của " + table.Name, new Font("Arial Bold", 15, FontStyle.Bold), Brushes.Navy, new Point(30, 70));
            e.Graphics.DrawString("SĐT liên hệ:0828384732", new Font("Arial Bold", 15, FontStyle.Bold), Brushes.Navy, new Point(30, 100));
            e.Graphics.DrawString("Hóa đơn số : " + idBill, new Font("Arial Bold", 15, FontStyle.Bold), Brushes.Black, new Point(30, 130));
            e.Graphics.DrawString(String.Format("Ngày:{0}", DateTime.Now.ToString("dd/MM/yyyy")), new Font("Arial Bold", 15), Brushes.Black, new Point(w / 2, 130));
            Point p1 = new Point(10, 170);
            Point p2 = new Point(w - 10, 170);
            e.Graphics.DrawLine(blackPen, p1, p2);
            int y = 180;
            e.Graphics.DrawString("Tên món", new Font("Arial Bold", 15, FontStyle.Bold), Brushes.Black, new Point(10, y));
            e.Graphics.DrawString("Số lượng", new Font("Arial Bold", 15, FontStyle.Bold), Brushes.Black, new Point(w / 2, y));
            e.Graphics.DrawString("Đơn giá", new Font("Arial Bold", 15, FontStyle.Bold), Brushes.Black, new Point(w / 2 + 100, y));
            e.Graphics.DrawString("Thành tiền", new Font("Arial Bold", 15, FontStyle.Bold), Brushes.Black, new Point(w - 110, y));
            y += 30;
            Point p3 = new Point(10, y);
            Point p4 = new Point(w - 10, y);
            e.Graphics.DrawLine(blackPen, p3, p4);
            for (int i = 0; i < lsvBill.Items.Count; i++)
            {
                e.Graphics.DrawString("" + lsvBill.Items[i].SubItems[0].Text, new Font("Arial Bold", 15), Brushes.Black, new Point(10, y));
                e.Graphics.DrawString("" + lsvBill.Items[i].SubItems[1].Text, new Font("Arial Bold", 15), Brushes.Black, new Point(w / 2 + 20, y));
                e.Graphics.DrawString("" + lsvBill.Items[i].SubItems[2].Text, new Font("Arial Bold", 15), Brushes.Black, new Point(w / 2 + 100, y));
                e.Graphics.DrawString("" + lsvBill.Items[i].SubItems[3].Text, new Font("Arial Bold", 15), Brushes.Black, new Point(w - 100, y));
                y += 30;
            }
            y += 10;
            Point p5 = new Point(10, y);
            Point p6 = new Point(w - 10, y);
            e.Graphics.DrawLine(blackPen, p5, p6);
            y += 10;
            e.Graphics.DrawString("Tiền chưa giảm :", new Font("Arial Bold", 15, FontStyle.Bold), Brushes.Black, new Point(10, y));
            e.Graphics.DrawString("" + totalPrice, new Font("Arial Bold", 15), Brushes.Black, new Point(w - 100, y));
            e.Graphics.DrawString("Giảm giá :", new Font("Arial Bold", 15), Brushes.Black, new Point(10, y + 30));
            e.Graphics.DrawString("" + discount + "%", new Font("Arial Bold", 15), Brushes.Black, new Point(w - 100, y + 30));
            e.Graphics.DrawString("Tiền giảm :", new Font("Arial Bold", 15, FontStyle.Bold), Brushes.Black, new Point(10, y + 60));
            e.Graphics.DrawString("" + tiengiam, new Font("Arial Bold", 15), Brushes.Black, new Point(w - 100, y + 60));
            y += 90;
            Point p7 = new Point(10, y);
            Point p8 = new Point(w - 10, y);
            e.Graphics.DrawLine(blackPen, p7, p8);
            y += 10;
            e.Graphics.DrawString("Tiền thanh toán :", new Font("Arial Bold", 15, FontStyle.Bold), Brushes.Black, new Point(10, y));
            e.Graphics.DrawString("" + finalTotalPrice, new Font("Arial Bold", 15, FontStyle.Bold), Brushes.Black, new Point(w - 100, y));
            e.Graphics.DrawString("Thanh toán chuyển khoản số tài khoản :", new Font("Arial Bold", 13, FontStyle.Bold), Brushes.Black, new Point(10, y + 30));
            e.Graphics.DrawString("BIDV 7500539185 PHAN THANH DO", new Font("Arial Bold", 13, FontStyle.Bold), Brushes.Black, new Point(10, y + 60));
        }
    }
}
