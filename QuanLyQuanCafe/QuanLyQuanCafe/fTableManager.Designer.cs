namespace QuanLyQuanCafe
{
    partial class fTableManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fTableManager));
            menuStrip1 = new MenuStrip();
            adminToolStripMenuItem = new ToolStripMenuItem();
            thôngTinCáNhânToolStripMenuItem = new ToolStripMenuItem();
            đăngXuấtToolStripMenuItem = new ToolStripMenuItem();
            đăngXuấtToolStripMenuItem1 = new ToolStripMenuItem();
            panel2 = new Panel();
            lsvBill = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            panel3 = new Panel();
            PrintBillInfo = new Button();
            label6 = new Label();
            label2 = new Label();
            txbTotalPrice = new TextBox();
            cbSwitchTable = new ComboBox();
            btnSwichTable = new Button();
            nmDisCount = new NumericUpDown();
            btnCheckOut = new Button();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            panel4 = new Panel();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            btnAddFood = new Button();
            nmFoodCount = new NumericUpDown();
            cbFood = new ComboBox();
            cbCategory = new ComboBox();
            flpTable = new FlowLayoutPanel();
            label1 = new Label();
            pictureBox3 = new PictureBox();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            pdPrintBill = new System.Drawing.Printing.PrintDocument();
            pddPrintBill = new PrintPreviewDialog();
            menuStrip1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nmDisCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nmFoodCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { adminToolStripMenuItem, thôngTinCáNhânToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1592, 32);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.ItemClicked += menuStrip1_ItemClicked;
            // 
            // adminToolStripMenuItem
            // 
            adminToolStripMenuItem.Font = new Font("#9Slide03 BoosterNextFYBlack", 9F, FontStyle.Regular, GraphicsUnit.Point);
            adminToolStripMenuItem.Image = Properties.Resources.USER_LOGIN1;
            adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            adminToolStripMenuItem.Size = new Size(238, 28);
            adminToolStripMenuItem.Text = "Trang quản lý (admin)";
            adminToolStripMenuItem.Click += aDMINToolStripMenuItem_Click;
            // 
            // thôngTinCáNhânToolStripMenuItem
            // 
            thôngTinCáNhânToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { đăngXuấtToolStripMenuItem, đăngXuấtToolStripMenuItem1 });
            thôngTinCáNhânToolStripMenuItem.Font = new Font("#9Slide03 BoosterNextFYBlack", 9F, FontStyle.Regular, GraphicsUnit.Point);
            thôngTinCáNhânToolStripMenuItem.Image = Properties.Resources.contactlist1;
            thôngTinCáNhânToolStripMenuItem.Name = "thôngTinCáNhânToolStripMenuItem";
            thôngTinCáNhânToolStripMenuItem.Size = new Size(216, 28);
            thôngTinCáNhânToolStripMenuItem.Text = "Tài khoản hệ thống";
            thôngTinCáNhânToolStripMenuItem.Click += thôngTinCáNhânToolStripMenuItem_Click;
            // 
            // đăngXuấtToolStripMenuItem
            // 
            đăngXuấtToolStripMenuItem.Image = Properties.Resources.contactlist;
            đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            đăngXuấtToolStripMenuItem.Size = new Size(279, 34);
            đăngXuấtToolStripMenuItem.Text = "Thông tin tài khoản";
            đăngXuấtToolStripMenuItem.Click += đăngXuấtToolStripMenuItem_Click;
            // 
            // đăngXuấtToolStripMenuItem1
            // 
            đăngXuấtToolStripMenuItem1.Image = Properties.Resources.thoát2;
            đăngXuấtToolStripMenuItem1.Name = "đăngXuấtToolStripMenuItem1";
            đăngXuấtToolStripMenuItem1.Size = new Size(279, 34);
            đăngXuấtToolStripMenuItem1.Text = "Đăng xuất";
            đăngXuấtToolStripMenuItem1.Click += đăngXuấtToolStripMenuItem1_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(lsvBill);
            panel2.Location = new Point(9, 234);
            panel2.Name = "panel2";
            panel2.Size = new Size(527, 436);
            panel2.TabIndex = 1;
            // 
            // lsvBill
            // 
            lsvBill.BackColor = Color.White;
            lsvBill.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4 });
            lsvBill.ForeColor = SystemColors.InfoText;
            lsvBill.GridLines = true;
            lsvBill.Location = new Point(1, 3);
            lsvBill.Name = "lsvBill";
            lsvBill.Size = new Size(533, 430);
            lsvBill.TabIndex = 0;
            lsvBill.UseCompatibleStateImageBehavior = false;
            lsvBill.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Tên món";
            columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Số lượng";
            columnHeader2.TextAlign = HorizontalAlignment.Center;
            columnHeader2.Width = 90;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Đơn giá";
            columnHeader3.TextAlign = HorizontalAlignment.Center;
            columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Thành tiền";
            columnHeader4.Width = 180;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Transparent;
            panel3.Controls.Add(PrintBillInfo);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(txbTotalPrice);
            panel3.Controls.Add(cbSwitchTable);
            panel3.Controls.Add(btnSwichTable);
            panel3.Controls.Add(nmDisCount);
            panel3.Controls.Add(btnCheckOut);
            panel3.Location = new Point(7, 676);
            panel3.Name = "panel3";
            panel3.Size = new Size(533, 115);
            panel3.TabIndex = 1;
            panel3.Paint += panel3_Paint;
            // 
            // PrintBillInfo
            // 
            PrintBillInfo.Font = new Font("#9Slide03 BoosterNextFYBlack", 9F, FontStyle.Regular, GraphicsUnit.Point);
            PrintBillInfo.Image = Properties.Resources.printer_print_221332;
            PrintBillInfo.ImageAlign = ContentAlignment.TopCenter;
            PrintBillInfo.Location = new Point(398, 0);
            PrintBillInfo.Name = "PrintBillInfo";
            PrintBillInfo.Size = new Size(128, 75);
            PrintBillInfo.TabIndex = 11;
            PrintBillInfo.Text = "In hóa đơn";
            PrintBillInfo.TextAlign = ContentAlignment.BottomCenter;
            PrintBillInfo.UseVisualStyleBackColor = true;
            PrintBillInfo.Click += PrintBillInfo_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("#9Slide03 BoosterNextFYBlack", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label6.ForeColor = SystemColors.HighlightText;
            label6.Location = new Point(282, 10);
            label6.Name = "label6";
            label6.Size = new Size(117, 25);
            label6.TabIndex = 10;
            label6.Text = "Giảm giá %";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("#9Slide03 BoosterNextFYBlack", 10.999999F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.Yellow;
            label2.Location = new Point(282, 79);
            label2.Name = "label2";
            label2.Size = new Size(110, 28);
            label2.TabIndex = 8;
            label2.Text = "Tổng tiền";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // txbTotalPrice
            // 
            txbTotalPrice.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txbTotalPrice.BackColor = Color.Red;
            txbTotalPrice.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold, GraphicsUnit.Point);
            txbTotalPrice.ForeColor = Color.White;
            txbTotalPrice.Location = new Point(398, 77);
            txbTotalPrice.Name = "txbTotalPrice";
            txbTotalPrice.ReadOnly = true;
            txbTotalPrice.Size = new Size(128, 37);
            txbTotalPrice.TabIndex = 7;
            txbTotalPrice.Text = "0";
            txbTotalPrice.TextAlign = HorizontalAlignment.Right;
            // 
            // cbSwitchTable
            // 
            cbSwitchTable.FormattingEnabled = true;
            cbSwitchTable.Location = new Point(143, 78);
            cbSwitchTable.Name = "cbSwitchTable";
            cbSwitchTable.Size = new Size(137, 33);
            cbSwitchTable.TabIndex = 4;
            // 
            // btnSwichTable
            // 
            btnSwichTable.Font = new Font("#9Slide03 BoosterNextFYBlack", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnSwichTable.Image = Properties.Resources.twocirclingarrows_120593;
            btnSwichTable.ImageAlign = ContentAlignment.TopCenter;
            btnSwichTable.Location = new Point(142, 3);
            btnSwichTable.Name = "btnSwichTable";
            btnSwichTable.Size = new Size(139, 76);
            btnSwichTable.TabIndex = 6;
            btnSwichTable.Text = "Chuyển bàn";
            btnSwichTable.TextAlign = ContentAlignment.BottomCenter;
            btnSwichTable.UseVisualStyleBackColor = true;
            btnSwichTable.Click += btnSwichTable_Click;
            // 
            // nmDisCount
            // 
            nmDisCount.Location = new Point(278, 44);
            nmDisCount.Name = "nmDisCount";
            nmDisCount.Size = new Size(122, 31);
            nmDisCount.TabIndex = 4;
            nmDisCount.TextAlign = HorizontalAlignment.Center;
            // 
            // btnCheckOut
            // 
            btnCheckOut.Font = new Font("#9Slide03 BoosterNextFYBlack", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnCheckOut.Image = Properties.Resources.pay_per_click_icon_129400__1_;
            btnCheckOut.ImageAlign = ContentAlignment.TopCenter;
            btnCheckOut.Location = new Point(3, 3);
            btnCheckOut.Name = "btnCheckOut";
            btnCheckOut.Size = new Size(139, 108);
            btnCheckOut.TabIndex = 4;
            btnCheckOut.Text = "Thanh toán";
            btnCheckOut.TextAlign = ContentAlignment.BottomCenter;
            btnCheckOut.UseVisualStyleBackColor = true;
            btnCheckOut.Click += btnCheckOut_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.Artboard_2_3x1;
            pictureBox2.Location = new Point(543, 92);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(679, 108);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 11;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.coffee_12325__1_1;
            pictureBox1.Location = new Point(162, 35);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(73, 55);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Transparent;
            panel4.Controls.Add(label5);
            panel4.Controls.Add(label4);
            panel4.Controls.Add(label3);
            panel4.Controls.Add(btnAddFood);
            panel4.Controls.Add(nmFoodCount);
            panel4.Controls.Add(cbFood);
            panel4.Controls.Add(cbCategory);
            panel4.Location = new Point(6, 92);
            panel4.Name = "panel4";
            panel4.Size = new Size(537, 108);
            panel4.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("#9Slide03 BoosterNextFYBlack", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.Desktop;
            label5.Location = new Point(4, 78);
            label5.Name = "label5";
            label5.Size = new Size(85, 23);
            label5.TabIndex = 6;
            label5.Text = "Số lượng";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("#9Slide03 BoosterNextFYBlack", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.Desktop;
            label4.Location = new Point(6, 46);
            label4.Name = "label4";
            label4.Size = new Size(88, 23);
            label4.TabIndex = 5;
            label4.Text = "Tên món ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("#9Slide03 BoosterNextFYBlack", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.ControlText;
            label3.ImageAlign = ContentAlignment.MiddleRight;
            label3.Location = new Point(4, 15);
            label3.Name = "label3";
            label3.Size = new Size(140, 23);
            label3.TabIndex = 4;
            label3.Text = "Danh mục món ";
            // 
            // btnAddFood
            // 
            btnAddFood.Font = new Font("#9Slide03 BoosterNextFYBlack", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnAddFood.Image = Properties.Resources.eating_placescafe_food_restaurant_drink_icon_193787__1_;
            btnAddFood.ImageAlign = ContentAlignment.TopCenter;
            btnAddFood.Location = new Point(425, 10);
            btnAddFood.Name = "btnAddFood";
            btnAddFood.Size = new Size(106, 98);
            btnAddFood.TabIndex = 2;
            btnAddFood.Text = "Thêm món";
            btnAddFood.TextAlign = ContentAlignment.BottomCenter;
            btnAddFood.UseVisualStyleBackColor = true;
            btnAddFood.Click += btnAddFood_Click;
            // 
            // nmFoodCount
            // 
            nmFoodCount.Location = new Point(146, 74);
            nmFoodCount.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            nmFoodCount.Name = "nmFoodCount";
            nmFoodCount.Size = new Size(280, 31);
            nmFoodCount.TabIndex = 3;
            nmFoodCount.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nmFoodCount.ValueChanged += nmFoodCount_ValueChanged;
            // 
            // cbFood
            // 
            cbFood.FormattingEnabled = true;
            cbFood.Location = new Point(146, 41);
            cbFood.Name = "cbFood";
            cbFood.Size = new Size(280, 33);
            cbFood.TabIndex = 1;
            // 
            // cbCategory
            // 
            cbCategory.FormattingEnabled = true;
            cbCategory.Location = new Point(146, 10);
            cbCategory.Name = "cbCategory";
            cbCategory.Size = new Size(280, 33);
            cbCategory.TabIndex = 0;
            cbCategory.SelectedIndexChanged += cbCategory_SelectIndexChange;
            // 
            // flpTable
            // 
            flpTable.BackColor = Color.White;
            flpTable.BorderStyle = BorderStyle.FixedSingle;
            flpTable.ForeColor = Color.White;
            flpTable.Location = new Point(542, 234);
            flpTable.Name = "flpTable";
            flpTable.Size = new Size(686, 556);
            flpTable.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("#9Slide03 SVNNexa Rust Sans Bla", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Transparent;
            label1.ImeMode = ImeMode.NoControl;
            label1.Location = new Point(241, 35);
            label1.Name = "label1";
            label1.Size = new Size(853, 53);
            label1.TabIndex = 4;
            label1.Text = "PHẦN MỀM QUẢN LÝ HIGHLEND COFFEE ";
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(1224, 28);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(368, 767);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 10;
            pictureBox3.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("#9Slide03 BoosterNextFYBlack", 10.999999F, FontStyle.Regular, GraphicsUnit.Point);
            label7.ForeColor = SystemColors.Desktop;
            label7.Location = new Point(12, 204);
            label7.Name = "label7";
            label7.Size = new Size(202, 28);
            label7.TabIndex = 7;
            label7.Text = "Thông tin hóa đơn";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("#9Slide03 BoosterNextFYBlack", 10.999999F, FontStyle.Regular, GraphicsUnit.Point);
            label8.ForeColor = SystemColors.Desktop;
            label8.Location = new Point(549, 203);
            label8.Name = "label8";
            label8.Size = new Size(275, 28);
            label8.TabIndex = 11;
            label8.Text = "Thông tin danh sách bàn ";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("#9Slide03 BoosterNextFYBlack", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(6, 76);
            label9.Name = "label9";
            label9.Size = new Size(162, 23);
            label9.TabIndex = 12;
            label9.Text = "Thông tin thức ăn";
            // 
            // pdPrintBill
            // 
            pdPrintBill.PrintPage += pdPrintBill_PrintPage;
            // 
            // pddPrintBill
            // 
            pddPrintBill.AutoScrollMargin = new Size(0, 0);
            pddPrintBill.AutoScrollMinSize = new Size(0, 0);
            pddPrintBill.ClientSize = new Size(400, 300);
            pddPrintBill.Enabled = true;
            pddPrintBill.Icon = (Icon)resources.GetObject("pddPrintBill.Icon");
            pddPrintBill.Name = "pddPrintBill";
            pddPrintBill.Visible = false;
            // 
            // fTableManager
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.BurlyWood;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(1592, 795);
            Controls.Add(label9);
            Controls.Add(pictureBox2);
            Controls.Add(panel3);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(pictureBox3);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(flpTable);
            Controls.Add(panel4);
            Controls.Add(panel2);
            Controls.Add(menuStrip1);
            ForeColor = SystemColors.InfoText;
            HelpButton = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            ImeMode = ImeMode.Off;
            MainMenuStrip = menuStrip1;
            MinimizeBox = false;
            Name = "fTableManager";
            SizeGripStyle = SizeGripStyle.Show;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Trang chủ phần mềm quản lý Highlend coffee";
            Load += fTableManager_Load;
            MouseDoubleClick += fTableManager_MouseDoubleClick;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nmDisCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nmFoodCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem adminToolStripMenuItem;
        private ToolStripMenuItem thôngTinCáNhânToolStripMenuItem;
        private ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private Panel panel2;
        private Panel panel3;
        private ListView lsvBill;
        private Panel panel4;
        private NumericUpDown nmFoodCount;
        private Button btnAddFood;
        private ComboBox cbFood;
        private ComboBox cbCategory;
        private FlowLayoutPanel flpTable;
        private Button btnCheckOut;
        private ComboBox cbSwitchTable;
        private Button btnSwichTable;
        private NumericUpDown nmDisCount;
        private ToolStripMenuItem đăngXuấtToolStripMenuItem1;
        private Label label1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private TextBox txbTotalPrice;
        private Label label2;
        private Label label5;
        private Label label4;
        private Label label3;
        private PictureBox pictureBox1;
        private Label label6;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private Label label7;
        private Label label8;
        private Label label9;
        private Button PrintBillInfo;
        private System.Drawing.Printing.PrintDocument pdPrintBill;
        private PrintPreviewDialog pddPrintBill;
    }
}