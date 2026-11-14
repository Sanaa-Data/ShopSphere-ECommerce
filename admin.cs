using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Linq;

namespace Ray_Sanaa_Final_Project
 
{
    public partial class admin : Form
    {

        public admin()
        {
            InitializeComponent();
        }
        MySqldb db = new MySqldb("ShopSphere");
        Button btnViewCustomers;
        Button btnDashboard;
        Button btnLogout;
        Panel pnlMain;
        Button btnAddProduct;
        TextBox txtProductName;
        TextBox txtDescription;
        TextBox txtPrice;
        ErrorProvider errorProvider = new ErrorProvider();
        Button btnSearch;
        Panel pnlCategory;
        Button btnCancel;
        TextBox txtImageLink;
        Button btnSaveCategory;
        TextBox txtCategoryName;
        TextBox txtCategoryDescription;
        Button search;
        Panel pnlSeller;
        Button btnCancelSeller;
        Button btnSaveSeller;
        ComboBox cmbCountryCode;
        TextBox txtSellerPhone;
        TextBox txtSellerName;
        TextBox txtSellerEmail;
        ComboBox cmbMonth;
        TextBox txtSellerAddress;
        Button btnMostOrdered;
        DataGridView dgvTopCustomers;
       ComboBox MonthComboBox;
        ComboBox cmbYear;
        Panel order;
        DataGridView ds;
        ComboBox cmbCategory;
        ComboBox cmbSeller;

        private void txtSellerEmail_Leave(object sender, EventArgs e)
        {
            string email = txtSellerEmail.Text;

            if (string.IsNullOrWhiteSpace(email))
            {
                errorProvider.SetError(txtSellerEmail, "Email is required.");
                return;
            }

            if (!email.EndsWith("@gmail.com"))
            {
                errorProvider.SetError(txtSellerEmail, "Please enter a valid Gmail address.");
                return;
            }

            errorProvider.SetError(txtSellerEmail, "");
        }
        private void txtSellerPhone_Leave(object sender, EventArgs e)
        {
            string phone = txtSellerPhone.Text;
            if (string.IsNullOrWhiteSpace(phone))
            {
                errorProvider.SetError(txtSellerPhone, "Phone number is required."); return;
            }
            for (int i = 0; i < phone.Length; i++)
            {
                if (!char.IsDigit(phone[i]))
                {
                    errorProvider.SetError(txtSellerPhone, "Please enter numbers only.");
                    return;
                }
            }



            errorProvider.SetError(txtSellerPhone, "");

        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Remove(pnlCategory);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();

            pnlMain.BackColor = Color.FromArgb(248, 249, 250);
            Label lblDashboard = new Label();
            lblDashboard.Text = "Dashboard";
            lblDashboard.Location = new Point(35, 35);
            lblDashboard.Size = new Size(400, 50);
            lblDashboard.Font = new System.Drawing.Font("Segoe UI", 28, FontStyle.Bold);
            lblDashboard.ForeColor = Color.FromArgb(15, 23, 42);
            pnlMain.Controls.Add(lblDashboard);

        
            Label lblOverview = new Label();
            lblOverview.Text = "Overview of your store performance";
            lblOverview.Location = new Point(35, 85);
           lblOverview.Size = new Size(500, 20);
            lblOverview.Font = new System.Drawing.Font("Segoe UI", 10);
            lblOverview.ForeColor = Color.Gray;
            pnlMain.Controls.Add(lblOverview);

            Label lblLastUpdated = new Label();
            lblLastUpdated.Name = "lblLastUpdated";
            lblLastUpdated.Location = new Point(50, 110); 
            lblLastUpdated.AutoSize = true;
            lblLastUpdated.Font = new System.Drawing.Font("Segoe UI", 8, FontStyle.Italic);
            lblLastUpdated.ForeColor = Color.FromArgb(130, 130, 130);
            lblLastUpdated.Text = "Last updated: Today at " + DateTime.Now.ToString("t");
            pnlMain.Controls.Add(lblLastUpdated);

            Panel cardCustomers = new Panel();
            cardCustomers.Name = "cardCustomers";
            cardCustomers.Size = new Size(255, 145);
            cardCustomers.Location = new Point(30, 145);
            cardCustomers.BackColor = Color.White;
            cardCustomers.BorderStyle = BorderStyle.FixedSingle;

            Panel accentCustomers = new Panel();
            accentCustomers.Size = new Size(5, 145);
            accentCustomers.Location = new Point(0, 0);
            accentCustomers.BackColor = Color.FromArgb(0, 123, 255);

            Label lblCustTitle = new Label();
            lblCustTitle.Text = "CUSTOMERS";
            lblCustTitle.Location = new Point(25, 20);
            lblCustTitle.AutoSize = true;
            lblCustTitle.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            lblCustTitle.ForeColor = Color.Gray;

            Label lblCustValue = new Label();
            DataTable dtCust = db.TotalCustomers();
            lblCustValue.Text = dtCust.Rows[0][0].ToString();
            lblCustValue.Location = new Point(25, 50);
            lblCustValue.AutoSize = true;
            lblCustValue.Font = new System.Drawing.Font("Segoe UI", 28, FontStyle.Bold);
            lblCustValue.ForeColor = Color.FromArgb(15, 23, 42);

            cardCustomers.Controls.Add(accentCustomers);
            cardCustomers.Controls.Add(lblCustTitle);
            cardCustomers.Controls.Add(lblCustValue);

            pnlMain.Controls.Add(cardCustomers);

            Panel cardOrders = new Panel();
            cardOrders.Name = "cardOrders";
            cardOrders.Size = new Size(255, 145);
            cardOrders.Location = new Point(310, 145);
            cardOrders.BackColor = Color.White;
            cardOrders.BorderStyle = BorderStyle.FixedSingle;

            Panel accentOrders = new Panel();
            accentOrders.Size = new Size(5, 145);
            accentOrders.Location = new Point(0, 0);
            accentOrders.BackColor = Color.FromArgb(40, 167, 69);

            Label lblOrderTitle = new Label();
            lblOrderTitle.Text = "ORDERS";
            lblOrderTitle.Location = new Point(25, 20);
            lblOrderTitle.AutoSize = true;
            lblOrderTitle.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            lblOrderTitle.ForeColor = Color.Gray;

            Label lblOrderValue = new Label();
            DataTable dtOrder = db.TotalOrders();
            lblOrderValue.Text = dtOrder.Rows[0][0].ToString();
            lblOrderValue.Location = new Point(25, 50);
            lblOrderValue.AutoSize = true;
            lblOrderValue.Font = new System.Drawing.Font("Segoe UI", 28, FontStyle.Bold);
            lblOrderValue.ForeColor = Color.FromArgb(15, 23, 42);

            cardOrders.Controls.Add(accentOrders);
            cardOrders.Controls.Add(lblOrderTitle);
            cardOrders.Controls.Add(lblOrderValue);

            pnlMain.Controls.Add(cardOrders);

            Panel cardProducts = new Panel();
            cardProducts.Name = "cardProducts";
            cardProducts.Size = new Size(255, 145);
            cardProducts.Location = new Point(590, 145);

            cardProducts.BackColor = Color.White;
            cardProducts.BorderStyle = BorderStyle.FixedSingle;

            Panel accentProducts = new Panel();
            accentProducts.Size = new Size(5, 145);
            accentProducts.Location = new Point(0, 0);
            accentProducts.BackColor = Color.FromArgb(255, 193, 7);

            Label lblProdTitle = new Label();
            lblProdTitle.Text = "PRODUCTS";
            lblProdTitle.Location = new Point(25, 20);
            lblProdTitle.AutoSize = true;
            lblProdTitle.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            lblProdTitle.ForeColor = Color.Gray;

            Label lblProdValue = new Label();
            DataTable dtProd = db.TotalProducts();
            lblProdValue.Text = dtProd.Rows[0][0].ToString();
            lblProdValue.Location = new Point(25, 50);
            lblProdValue.AutoSize = true;
            lblProdValue.Font = new System.Drawing.Font("Segoe UI", 28, FontStyle.Bold);
            lblProdValue.ForeColor = Color.FromArgb(15, 23, 42);

            cardProducts.Controls.Add(accentProducts);
            cardProducts.Controls.Add(lblProdTitle);
            cardProducts.Controls.Add(lblProdValue);

            pnlMain.Controls.Add(cardProducts);



            Panel cardRevenue = new Panel();
            cardRevenue.Name = "cardRevenue";
            cardRevenue.Size = new Size(255, 145);
            cardRevenue.Location = new Point(870, 145);
            cardRevenue.BackColor = Color.White;
            cardRevenue.BorderStyle = BorderStyle.FixedSingle;

            Panel accentRevenue = new Panel();
            accentRevenue.Size = new Size(5, 145);
            accentRevenue.Location = new Point(0, 0);
            accentRevenue.BackColor = Color.FromArgb(220, 53, 69);

            Label lblRevTitle = new Label();
            lblRevTitle.Text = "REVENUE";
            lblRevTitle.Location = new Point(25, 20);
            lblRevTitle.AutoSize = true;
            lblRevTitle.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            lblRevTitle.ForeColor = Color.Gray;

            Label lblRevValue = new Label();
            DataTable dtRev = db.TotalRevenue();
            decimal total = Convert.ToDecimal(dtRev.Rows[0][0]);

            lblRevValue.Text = "$" + total.ToString();
            lblRevValue.Location = new Point(25, 50);
            lblRevValue.Size = new Size(230, 60);
            lblRevValue.Font = new System.Drawing.Font("Segoe UI", 20, FontStyle.Bold);
            lblRevValue.ForeColor = Color.FromArgb(15, 23, 42);

            cardRevenue.Controls.Add(accentRevenue);
            cardRevenue.Controls.Add(lblRevTitle);
            cardRevenue.Controls.Add(lblRevValue);

            pnlMain.Controls.Add(cardRevenue);

            // TIME BADGE - Top Right
            Label lblTime = new Label();
            lblTime.Name = "lblLiveTime";
            lblTime.Location = new Point(780, 40);
            lblTime.AutoSize=true;
            lblTime.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            lblTime.ForeColor = Color.FromArgb(15, 23, 42);
            lblTime.BackColor = Color.FromArgb(240, 242, 245);
            lblTime.TextAlign = ContentAlignment.MiddleCenter;
            lblTime.Text = DateTime.Now.ToString("f");
            pnlMain.Controls.Add(lblTime);


            // ==================== COLUMN CHART PANEL ====================

            Panel revenuePanel = new Panel();
            revenuePanel.Name = "revenuePanel";
            revenuePanel.Location = new Point(30, 310);
            revenuePanel.Size = new Size(530, 400);
            revenuePanel.BackColor = Color.White;
            revenuePanel.BorderStyle = BorderStyle.FixedSingle;

            pnlMain.Controls.Add(revenuePanel);


            // Title for revenue chart
            Label lblRevenueChart = new Label();
            lblRevenueChart.Text = "Revenue by Month";
            lblRevenueChart.Location = new Point(20, 15);
            lblRevenueChart.AutoSize = true;
            lblRevenueChart.Font = new System.Drawing.Font("Segoe UI", 14, FontStyle.Bold);
            lblRevenueChart.ForeColor = Color.FromArgb(15, 23, 42);

            revenuePanel.Controls.Add(lblRevenueChart);


            // ==================== COLUMN CHART ====================

            Chart Revenue = new Chart();

            Revenue.Location = new Point(10, 50);
            Revenue.Size = new Size(510, 330);

            ChartArea area1 = new ChartArea();
            Revenue.ChartAreas.Add(area1);

            Series data = new Series();
            data.Name = "Revenue";
            data.ChartType = SeriesChartType.Column;

            Revenue.Series.Add(data);

            revenuePanel.Controls.Add(Revenue);


            // ==================== REVENUE DATA ====================

            string sql = "SELECT MONTH(orders.OrderDate) AS `month`, " +
                         "SUM(orders.TotalAmount) AS `Revenue` " +
                         "FROM orders " +
                         "WHERE orders.Status != @status " +
                         "GROUP BY MONTH(orders.OrderDate) " +
                         "ORDER BY MONTH(orders.OrderDate)";

            DataTable ds = db.GetData(sql,new MySqlParameter("@status", "Cancelled"));

            for (int i = 0; i < ds.Rows.Count; i++)
            {
                int month = Convert.ToInt32(ds.Rows[i][0]);
                decimal revenue = Convert.ToDecimal(ds.Rows[i][1]);

                data.Points.AddXY(month, revenue);
            }

            

            Panel statusPanel = new Panel();
            statusPanel.Name = "statusPanel";
            statusPanel.Location = new Point(580, 310);
            statusPanel.Size = new Size(530, 400);
            statusPanel.BackColor = Color.White;
            statusPanel.BorderStyle = BorderStyle.FixedSingle;

            pnlMain.Controls.Add(statusPanel);


            Label lblStatusChart = new Label();
            lblStatusChart.Text = "Order Status";
            lblStatusChart.Location = new Point(20, 15);
            lblStatusChart.AutoSize = true;
            lblStatusChart.Font = new System.Drawing.Font("Segoe UI", 14, FontStyle.Bold);
            lblStatusChart.ForeColor = Color.FromArgb(15, 23, 42);

            statusPanel.Controls.Add(lblStatusChart);



            Chart status = new Chart();

            status.Location = new Point(10, 50);
            status.Size = new Size(510, 330);
            status.Legends.Add(new Legend());
            ChartArea area2 = new ChartArea();
            status.ChartAreas.Add(area2);

            Series statusorders = new Series();
            statusorders.Name = "Order Status";
            statusorders.ChartType = SeriesChartType.Pie;

            status.Series.Add(statusorders);

            statusPanel.Controls.Add(status);


         
            string sql1 = "SELECT COUNT(orders.Status) FROM orders WHERE orders.Status='Cancelled'";
            string sql2 = "SELECT COUNT(orders.Status) FROM orders WHERE orders.Status='Delivered'";
            string sql3 = "SELECT COUNT(orders.Status) FROM orders WHERE orders.Status='Shipped'";
            string sql4 = "SELECT COUNT(orders.Status) FROM orders WHERE orders.Status='Processing'";
            string sql5 = "SELECT COUNT(orders.Status) FROM orders WHERE orders.Status='Pending'";


            DataTable cancelled = db.GetData(sql1);
            int nbb1 = Convert.ToInt32(cancelled.Rows[0][0]);
           int index1= statusorders.Points.AddY(nbb1);
            statusorders.Points[index1].LegendText = "Cancelled";
         
            DataTable shipped = db.GetData(sql3);
            int nbb2 = Convert.ToInt32(shipped.Rows[0][0]);
           int index2= statusorders.Points.AddY(nbb2);
            statusorders.Points[index2].LegendText = "Shipped";

            DataTable processing = db.GetData(sql4);
            int nbb3 = Convert.ToInt32(processing.Rows[0][0]);
            int index3=statusorders.Points.AddY(nbb3);
            statusorders.Points[index3].LegendText = "Processing";

            DataTable pending = db.GetData(sql5);
            int nbb4 = Convert.ToInt32(pending.Rows[0][0]);
           int index4= statusorders.Points.AddY(nbb4);
            statusorders.Points[index4].LegendText = "Pending";

            DataTable delivered = db.GetData(sql2);
            int nbb5 = Convert.ToInt32(delivered.Rows[0][0]);
           int index5= statusorders.Points.AddY(nbb5);
            statusorders.Points[index5].LegendText = "Delivered";

            //gives that legend a name.// keywords


        }

        private void btnSaveCategory_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtCategoryName.Text))
            {
                MessageBox.Show("Please enter the category name.");
                return;
            }

            if (string.IsNullOrEmpty(txtCategoryDescription.Text))
            {
                MessageBox.Show("Please enter the category description.");
                return;
            }
            try
            {
                string sql = "INSERT INTO category (Name, Description) " +
                 "VALUES (@name, @description)";

                db.ExecuteQuery(sql,
                    new MySqlParameter("@name", txtCategoryName.Text.Trim()),
                    new MySqlParameter("@description", txtCategoryDescription.Text.Trim()));
                MessageBox.Show("Category added successfully!");
                pnlMain.Controls.Remove(pnlCategory);

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error adding category: " + ex.Message);
            }
        }
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            pnlMain.Visible = true;

            Panel pnlAddProduct = new Panel();
            pnlAddProduct.Name = "pnlAddProduct";
            pnlAddProduct.Size = new Size(850, 650);
            pnlAddProduct.Location = new Point(50, 50);
            pnlAddProduct.BackColor = Color.White;
            pnlAddProduct.BorderStyle = BorderStyle.FixedSingle;

            Label lblTitle = new Label();
            lblTitle.Text = "Add Product";
            lblTitle.Location = new Point(30, 25);
            lblTitle.Size = new Size(400, 40);
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 22, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(31, 41, 55);


            Label lblSubtitle = new Label();
            lblSubtitle.Text = "Add a new product to your store";
            lblSubtitle.Location = new Point(32, 68);
            lblSubtitle.Size = new Size(500, 25);
            lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10);
            lblSubtitle.ForeColor = Color.Gray;

            Label lblProductName = new Label();
            lblProductName.Text = "Product Name";
            lblProductName.Location = new Point(30, 115);
            lblProductName.Size = new Size(150, 25);
            lblProductName.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            lblProductName.ForeColor = Color.FromArgb(55, 65, 81);

            txtProductName = new TextBox();
            txtProductName.Name = "txtProductName";
            txtProductName.Location = new Point(30, 142);
            txtProductName.Size = new Size(480, 32);
            txtProductName.Font = new System.Drawing.Font("Segoe UI", 10);
            txtProductName.Leave += txtProductName_Leave;
            Label lblCategory = new Label();
            lblCategory.Text = "Category";
            lblCategory.Location = new Point(30, 185);
            lblCategory.Size = new Size(150, 25);
            lblCategory.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            lblCategory.ForeColor = Color.FromArgb(55, 65, 81);

          cmbCategory = new ComboBox();
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Location = new Point(30, 212);
            cmbCategory.Size = new Size(350, 32);
            cmbCategory.Font = new System.Drawing.Font("Segoe UI", 10);
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;

            string sql = "SELECT Name FROM category";

            DataTable dt = db.GetData(sql);

            foreach (DataRow row in dt.Rows)
            {
                cmbCategory.Items.Add(row["Name"].ToString());
            }


            // ADD CATEGORY BUTTON

            Button btnAddCategory = new Button();
            btnAddCategory.Name = "btnAddCategory";
            btnAddCategory.Text = "+ Add Category";
            btnAddCategory.Location = new Point(395, 210);
            btnAddCategory.Size = new Size(115, 35);

            btnAddCategory.BackColor = Color.White;
            btnAddCategory.ForeColor = Color.FromArgb(37, 99, 235);
            btnAddCategory.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);

            btnAddCategory.FlatStyle = FlatStyle.Flat;
            btnAddCategory.FlatAppearance.BorderColor =
                Color.FromArgb(37, 99, 235);

            btnAddCategory.Cursor = Cursors.Hand;

            btnAddCategory.Click += btnAddCategory_Click;

            Label lblSeller = new Label();
            lblSeller.Text = "Seller";
            lblSeller.Location = new Point(30, 255);
            lblSeller.Size = new Size(150, 25);
            lblSeller.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            lblSeller.ForeColor = Color.FromArgb(55, 65, 81);


             cmbSeller = new ComboBox();
            cmbSeller.Name = "cmbSeller";
            cmbSeller.Location = new Point(30, 282);
            cmbSeller.Size = new Size(350, 32);
            cmbSeller.Font = new System.Drawing.Font("Segoe UI", 10);
            cmbSeller.DropDownStyle = ComboBoxStyle.DropDownList;


            // Load sellers

            string sellerSql = "SELECT Name FROM seller";

            DataTable sellerDt = db.GetData(sellerSql);

            foreach (DataRow row in sellerDt.Rows)
            {
                cmbSeller.Items.Add(row["Name"].ToString());
            }


            Button btnAddSeller = new Button();

            btnAddSeller.Name = "btnAddSeller";
            btnAddSeller.Text = "+ Add Seller";
            btnAddSeller.Location = new Point(395, 280);
            btnAddSeller.Size = new Size(115, 35);

            btnAddSeller.BackColor = Color.White;
            btnAddSeller.ForeColor = Color.FromArgb(37, 99, 235);

            btnAddSeller.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);


            btnAddSeller.FlatStyle = FlatStyle.Flat;

            btnAddSeller.FlatAppearance.BorderColor =
                Color.FromArgb(37, 99, 235);

            btnAddSeller.Cursor = Cursors.Hand;

            btnAddSeller.Click += btnAddSeller_Click;

            Label lblPrice = new Label();
            lblPrice.Text = "Price";
            lblPrice.Location = new Point(30, 325);
            lblPrice.Size = new Size(150, 25);
            lblPrice.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            lblPrice.ForeColor = Color.FromArgb(55, 65, 81);

            txtPrice = new TextBox();
            txtPrice.Name = "txtPrice";
            txtPrice.Location = new Point(30, 352);
            txtPrice.Size = new Size(480, 32);
            txtPrice.Font = new System.Drawing.Font("Segoe UI", 10);
            txtPrice.Leave += txtPrice_Leave;
            Label lblImageLink = new Label();
            lblImageLink.Text = "Image Link";
            lblImageLink.Location = new Point(30, 395);
            lblImageLink.Size = new Size(150, 25);
            lblImageLink.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            lblImageLink.ForeColor = Color.FromArgb(55, 65, 81);

            txtImageLink = new TextBox();
            txtImageLink.Name = "txtImageLink";
            txtImageLink.Location = new Point(30, 422);
            txtImageLink.Size = new Size(480, 32);
            txtImageLink.Font = new System.Drawing.Font("Segoe UI", 10);
            Button btnSaveProduct = new Button();

            btnSaveProduct.Name = "btnSaveProduct";
            btnSaveProduct.Text = "Add Product";
            btnSaveProduct.Location = new Point(570, 500);
            btnSaveProduct.Size = new Size(180, 45);

            btnSaveProduct.BackColor = Color.FromArgb(37, 99, 235);
            btnSaveProduct.ForeColor = Color.White;

            btnSaveProduct.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
        

            btnSaveProduct.FlatStyle = FlatStyle.Flat;
            btnSaveProduct.FlatAppearance.BorderSize = 0;

            btnSaveProduct.Cursor = Cursors.Hand;
            btnSaveProduct.Click += btnSaveProduct_Click;
            pnlAddProduct.Controls.Add(lblTitle);
            pnlAddProduct.Controls.Add(lblSubtitle);

            pnlAddProduct.Controls.Add(lblProductName);
            pnlAddProduct.Controls.Add(txtProductName);

            pnlAddProduct.Controls.Add(lblCategory);
            pnlAddProduct.Controls.Add(cmbCategory);
            pnlAddProduct.Controls.Add(btnAddCategory);

            pnlAddProduct.Controls.Add(lblSeller);
            pnlAddProduct.Controls.Add(cmbSeller);
            pnlAddProduct.Controls.Add(btnAddSeller);

            pnlAddProduct.Controls.Add(lblPrice);
            pnlAddProduct.Controls.Add(txtPrice);

            pnlAddProduct.Controls.Add(lblImageLink);
            pnlAddProduct.Controls.Add(txtImageLink);

            pnlAddProduct.Controls.Add(btnSaveProduct);

            pnlMain.Controls.Add(pnlAddProduct);
            pnlAddProduct.BringToFront();
        }
        private void btnAddSeller_Click(object sender, EventArgs e)
        {
            pnlSeller = new Panel();

            pnlSeller.Name = "pnlSeller";
            pnlSeller.Size = new Size(500, 450);
            pnlSeller.Location = new Point(175, 80);
            pnlSeller.BackColor = Color.White;
            pnlSeller.BorderStyle = BorderStyle.FixedSingle;

            // TITLE
            Label lblTitle = new Label();
            lblTitle.Text = "Add New Seller";
            lblTitle.Location = new Point(30, 25);
            lblTitle.Size = new Size(400, 40);
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 20, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(31, 41, 55);

            // SELLER NAME
            Label lblName = new Label();
            lblName.Text = "Seller Name";
            lblName.Location = new Point(30, 85);
            lblName.Size = new Size(150, 25);
            lblName.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            lblName.ForeColor = Color.FromArgb(55, 65, 81);

            txtSellerName = new TextBox();
            txtSellerName.Location = new Point(30, 112);
            txtSellerName.Size = new Size(430, 32);
            txtSellerName.Font = new System.Drawing.Font("Segoe UI", 10);

            // EMAIL
            Label lblEmail = new Label();
            lblEmail.Text = "Email";
            lblEmail.Location = new Point(30, 155);
            lblEmail.Size = new Size(150, 25);
            lblEmail.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            lblEmail.ForeColor = Color.FromArgb(55, 65, 81);

            txtSellerEmail = new TextBox();
            txtSellerEmail.Location = new Point(30, 182);
            txtSellerEmail.Size = new Size(430, 32);
            txtSellerEmail.Font = new System.Drawing.Font("Segoe UI", 10);

            // PHONE
            // PHONE
            Label lblPhone = new Label();
            lblPhone.Text = "Phone";
            lblPhone.Location = new Point(30, 225);
            lblPhone.Size = new Size(150, 25);
            lblPhone.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            lblPhone.ForeColor = Color.FromArgb(55, 65, 81);

            // COUNTRY CODE
            cmbCountryCode = new ComboBox();
            cmbCountryCode.Name = "cmbCountryCode";
            cmbCountryCode.Location = new Point(30, 252);
            cmbCountryCode.Size = new Size(100, 32);
            cmbCountryCode.Font = new System.Drawing.Font("Segoe UI", 10);
            cmbCountryCode.DropDownStyle = ComboBoxStyle.DropDownList;

            // Country codes
            cmbCountryCode.Items.Add("+1");
            cmbCountryCode.Items.Add("+20");
            cmbCountryCode.Items.Add("+30");
            cmbCountryCode.Items.Add("+31");
            cmbCountryCode.Items.Add("+32");
            cmbCountryCode.Items.Add("+33");
            cmbCountryCode.Items.Add("+34");
            cmbCountryCode.Items.Add("+39");
            cmbCountryCode.Items.Add("+44");
            cmbCountryCode.Items.Add("+49");
            cmbCountryCode.Items.Add("+81");
            cmbCountryCode.Items.Add("+82");
            cmbCountryCode.Items.Add("+86");
            cmbCountryCode.Items.Add("+90");
            cmbCountryCode.Items.Add("+91");
            cmbCountryCode.Items.Add("+93");
            cmbCountryCode.Items.Add("+961");
            cmbCountryCode.Items.Add("+962");
            cmbCountryCode.Items.Add("+963");
            cmbCountryCode.Items.Add("+964");
            cmbCountryCode.Items.Add("+965");
            cmbCountryCode.Items.Add("+966");
            cmbCountryCode.Items.Add("+967");
            cmbCountryCode.Items.Add("+968");
            cmbCountryCode.Items.Add("+971");
            cmbCountryCode.Items.Add("+972");
            cmbCountryCode.Items.Add("+973");
            cmbCountryCode.Items.Add("+974");
            cmbCountryCode.Items.Add("+975");
            cmbCountryCode.Items.Add("+976");
            cmbCountryCode.Items.Add("+977");

            // Lebanon selected by default
            cmbCountryCode.SelectedItem = "+961";

            // PHONE NUMBER
            txtSellerPhone = new TextBox();
            txtSellerPhone.Name = "txtSellerPhone";
            txtSellerPhone.Location = new Point(140, 252);
            txtSellerPhone.Size = new Size(320, 32);
            txtSellerPhone.Font = new System.Drawing.Font("Segoe UI", 10);
            txtSellerPhone.Leave += txtSellerPhone_Leave;
            // ADDRESS
            Label lblAddress = new Label();
            lblAddress.Text = "Address";
            lblAddress.Location = new Point(30, 295);
            lblAddress.Size = new Size(150, 25);
            lblAddress.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            lblAddress.ForeColor = Color.FromArgb(55, 65, 81);

            txtSellerAddress = new TextBox();
            txtSellerAddress.Location = new Point(30, 322);
            txtSellerAddress.Size = new Size(430, 50);
            txtSellerAddress.Multiline = true;
            txtSellerAddress.Font = new System.Drawing.Font("Segoe UI", 10);

            // CANCEL BUTTON
            btnCancelSeller = new Button();
            btnCancelSeller.Text = "Cancel";
            btnCancelSeller.Location = new Point(30, 390);
            btnCancelSeller.Size = new Size(120, 40);
            btnCancelSeller.BackColor = Color.FromArgb(243, 244, 246);
            btnCancelSeller.ForeColor = Color.FromArgb(55, 65, 81);
            btnCancelSeller.FlatStyle = FlatStyle.Flat;
            btnCancelSeller.FlatAppearance.BorderSize = 0;
            btnCancelSeller.Cursor = Cursors.Hand;

            btnCancelSeller.Click += btnCancelSeller_Click;

            // SAVE BUTTON
            btnSaveSeller = new Button();
            btnSaveSeller.Text = "Add Seller";
            btnSaveSeller.Location = new Point(270, 390);
            btnSaveSeller.Size = new Size(190, 40);
            btnSaveSeller.BackColor = Color.FromArgb(37, 99, 235);
            btnSaveSeller.ForeColor = Color.White;
            btnSaveSeller.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            btnSaveSeller.FlatStyle = FlatStyle.Flat;
            btnSaveSeller.FlatAppearance.BorderSize = 0;
            btnSaveSeller.Cursor = Cursors.Hand;
            btnSaveSeller.Click += btnSaveSeller_Click;
            pnlSeller.Controls.Add(lblTitle);
            pnlSeller.Controls.Add(lblName);
            pnlSeller.Controls.Add(txtSellerName);
            pnlSeller.Controls.Add(lblEmail);
            pnlSeller.Controls.Add(txtSellerEmail);
            pnlSeller.Controls.Add(lblPhone);

            pnlSeller.Controls.Add(lblAddress);
            pnlSeller.Controls.Add(txtSellerAddress);
            pnlSeller.Controls.Add(btnCancelSeller);
            pnlSeller.Controls.Add(btnSaveSeller);
            pnlSeller.Controls.Add(cmbCountryCode);
            pnlSeller.Controls.Add(txtSellerPhone);
            pnlMain.Controls.Add(pnlSeller);
            pnlSeller.BringToFront();
        }
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            pnlCategory = new Panel();

            pnlCategory.Name = "pnlCategory";
            pnlCategory.Size = new Size(500, 350);
            pnlCategory.Location = new Point(175, 100);
            pnlCategory.BackColor = Color.White;
            pnlCategory.BorderStyle = BorderStyle.FixedSingle;


            // TITLE
            Label lblTitle = new Label();
            lblTitle.Text = "Add New Category";
            lblTitle.Location = new Point(30, 25);
            lblTitle.Size = new Size(400, 40);
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 20, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(31, 41, 55);


            // CATEGORY NAME
            Label lblName = new Label();
            lblName.Text = "Category Name";
            lblName.Location = new Point(30, 85);
            lblName.Size = new Size(150, 25);
            lblName.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            lblName.ForeColor = Color.FromArgb(55, 65, 81);

            txtCategoryName = new TextBox();
            txtCategoryName.Location = new Point(30, 112);
            txtCategoryName.Size = new Size(430, 32);
            txtCategoryName.Font = new System.Drawing.Font("Segoe UI", 10);
        
            txtCategoryName.Leave += txtCategoryName_Leave;
            // DESCRIPTION
            Label lblDescription = new Label();
            lblDescription.Text = "Description";
            lblDescription.Location = new Point(30, 155);
            lblDescription.Size = new Size(150, 25);
            lblDescription.Font = new System.Drawing. Font("Segoe UI", 10, FontStyle.Bold);
            lblDescription.ForeColor = Color.FromArgb(55, 65, 81);

            txtCategoryDescription = new TextBox();
            txtCategoryDescription.Location = new Point(30, 182);
            txtCategoryDescription.Size = new Size(430, 60);
            txtCategoryDescription.Multiline = true;
            txtCategoryDescription.Font = new System.Drawing.Font("Segoe UI", 10);

            txtCategoryDescription.Leave += txtCategoryDescription_Leave;

            // CANCEL
            btnCancel = new Button();
            btnCancel.Text = "Cancel";
            btnCancel.Location = new Point(30, 270);
            btnCancel.Size = new Size(120, 40);
            btnCancel.BackColor = Color.FromArgb(243, 244, 246);
            btnCancel.ForeColor = Color.FromArgb(55, 65, 81);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += btnCancel_Click;

            // ADD CATEGORY
            btnSaveCategory = new Button();
            btnSaveCategory.Text = "Add Category";
            btnSaveCategory.Location = new Point(270, 270);
            btnSaveCategory.Size = new Size(190, 40);
            btnSaveCategory.BackColor = Color.FromArgb(37, 99, 235);
            btnSaveCategory.ForeColor = Color.White;
            btnSaveCategory.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            btnSaveCategory.FlatStyle = FlatStyle.Flat;
            btnSaveCategory.FlatAppearance.BorderSize = 0;

            btnSaveCategory.Click += btnSaveCategory_Click;





            // ADD CONTROLS
            pnlCategory.Controls.Add(lblTitle);

            pnlCategory.Controls.Add(lblName);
            pnlCategory.Controls.Add(txtCategoryName);

            pnlCategory.Controls.Add(lblDescription);
            pnlCategory.Controls.Add(txtCategoryDescription);

            pnlCategory.Controls.Add(btnCancel);
            pnlCategory.Controls.Add(btnSaveCategory);


            // SHOW PANEL
            pnlMain.Controls.Add(pnlCategory);
            pnlCategory.BringToFront();
        }
        private void btnCancelSeller_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Remove(pnlSeller);
        }
        private void btnSaveSeller_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSellerName.Text))
            {
                errorProvider.SetError(txtSellerName, "Seller name is required.");
                return;
            }
            else
            {
                errorProvider.SetError(txtSellerName, "");
            }

            if (string.IsNullOrWhiteSpace(txtSellerEmail.Text))
            {
                errorProvider.SetError(txtSellerEmail, "Email is required.");
                return;
            }
            else if (!txtSellerEmail.Text.EndsWith("@gmail.com"))
            {
                errorProvider.SetError(txtSellerEmail, "Please enter a valid Gmail address.");
                return;
            }
            else
            {
                errorProvider.SetError(txtSellerEmail, "");
            }

            if (string.IsNullOrWhiteSpace(txtSellerPhone.Text))
            {
                errorProvider.SetError(txtSellerPhone, "Phone number is required.");
                return;
            }

            for (int i = 0; i < txtSellerPhone.Text.Length; i++)
            {
                if (!char.IsDigit(txtSellerPhone.Text[i]))
                {
                    errorProvider.SetError(txtSellerPhone, "Please enter numbers only.");
                    return;
                }
            }

            errorProvider.SetError(txtSellerPhone, "");

            if (string.IsNullOrWhiteSpace(txtSellerAddress.Text))
            {
                errorProvider.SetError(txtSellerAddress, "Address is required.");
                return;
            }
            else
            {
                errorProvider.SetError(txtSellerAddress, "");
            }
            if (cmbCountryCode.SelectedItem == null)
            {
                MessageBox.Show("Please select a country code.");
                return;
            }
            string fullPhone = cmbCountryCode.SelectedItem.ToString()
                               + txtSellerPhone.Text;

            string sql = "INSERT INTO seller (Name, Email,Phone, Address) VALUES (@SellerName, @SellerEmail,@SellerPhone, @SellerAddress)";

            db.ExecuteQuery(sql,
                new MySqlParameter("@SellerName", txtSellerName.Text),
                new MySqlParameter("@SellerEmail", txtSellerEmail.Text),
                       new MySqlParameter("@SellerPhone", fullPhone),
                new MySqlParameter("@SellerAddress", txtSellerAddress.Text)); 

            MessageBox.Show("Seller added successfully!");

            pnlMain.Controls.Remove(pnlSeller);
        }
        private void txtCategoryName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                errorProvider.SetError(txtCategoryName, "Category name is required.");
            }
            else
            {
                errorProvider.SetError(txtCategoryName, "");
            }
        }
        private void txtProductName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                errorProvider.SetError(txtProductName, "Product name is required.");
            }
            else
            {
                errorProvider.SetError(txtProductName, "");
            }
        }

        private void txtPrice_Leave(object sender, EventArgs e)
        {
            string price = txtPrice.Text;

            if (string.IsNullOrWhiteSpace(price))
            {
                errorProvider.SetError(txtPrice, "Price is required.");
                return;
            }

            int dotCount = 0;
            for (int i = 0; i < price.Length; i++)
            {
                if (price[i] == '.')
                {
                    dotCount++;

                    if (dotCount > 1)
                    {
                        errorProvider.SetError(txtPrice, "Please enter a valid price.");
                        return;
                    }
                }
                else if (!char.IsDigit(price[i]))
                {
                    errorProvider.SetError(txtPrice, "Please enter a valid price.");
                    return;
                }
            }

            errorProvider.SetError(txtPrice, "");
        }
        private void txtCategoryDescription_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoryDescription.Text))
            {
                errorProvider.SetError(txtCategoryDescription, "Category description is required.");
            }
            else
            {
                errorProvider.SetError(txtCategoryDescription, "");
            }
        }
        private void btnTopCustomers_Click(object sender, EventArgs e)
        {
            // Clear the main panel
            pnlMain.Controls.Clear();
            pnlMain.Visible = true;

            Panel pnlTopCustomers = new Panel();
            pnlTopCustomers.Name = "pnlTopCustomers";
            pnlTopCustomers.Location = new Point(0, 0);
            pnlTopCustomers.Size = new Size(1100, 600);
            pnlTopCustomers.BackColor = Color.White;
            pnlTopCustomers.BorderStyle = BorderStyle.None;
            Label lblTitle = new Label();
            lblTitle.Text = "Top Customers";
            lblTitle.Location = new Point(30, 25);
            lblTitle.Size = new Size(500, 40);
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 22, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(31, 41, 55);

            Label lblSubtitle = new Label();
            lblSubtitle.Text = "Customers with the highest spending";
            lblSubtitle.Location = new Point(32, 80); // more space
            lblSubtitle.Size = new Size(500, 25);
            lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10);
            lblSubtitle.ForeColor = Color.Gray;

            Label lblMonth = new Label();
            lblMonth.Text = "Month";
            lblMonth.Location = new Point(600, 30);


            lblMonth.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            cmbMonth = new ComboBox();

            cmbMonth.Name = "cmbMonth";
            cmbMonth.Location = new Point(600, 55);
            cmbMonth.Size = new Size(130, 30);
            cmbMonth.Font = new System.Drawing.Font("Segoe UI", 10);
            cmbMonth.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbMonth.Items.Add("January");
            cmbMonth.Items.Add("February");
            cmbMonth.Items.Add("March");
            cmbMonth.Items.Add("April");
            cmbMonth.Items.Add("May");
            cmbMonth.Items.Add("June");
            cmbMonth.Items.Add("July");
            cmbMonth.Items.Add("August");
            cmbMonth.Items.Add("September");
            cmbMonth.Items.Add("October");
            cmbMonth.Items.Add("November");
            cmbMonth.Items.Add("December");

            cmbMonth.SelectedIndex = 0;

            btnSearch = new Button();
            btnSearch.Text = "Search";

            btnSearch.Size = new Size(100, 35);
            btnSearch.Location = new Point(750, 55);
            btnSearch.BackColor = Color.FromArgb(37, 99, 235);
            btnSearch.ForeColor = Color.White;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
            btnSearch.Click += btnSearch_Click;

            dgvTopCustomers = new DataGridView();

            dgvTopCustomers.Name = "dgvTopCustomers";
            dgvTopCustomers.Location = new Point(30, 135);

            dgvTopCustomers.Size = new Size(1040, 280);
            dgvTopCustomers.BackgroundColor = Color.White;


            dgvTopCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;// fill all 1040  pixels

            dgvTopCustomers.BorderStyle = BorderStyle.None;
            // =========================
            // COLUMNS
            // =========================
            dgvTopCustomers.AutoGenerateColumns = false;
            dgvTopCustomers.AllowUserToAddRows = false;
            dgvTopCustomers.Columns.Add("Rank", "Rank");
            dgvTopCustomers.Columns.Add("CustomerName", "Customer Name");
            dgvTopCustomers.Columns.Add("TotalOrders", "Total Orders");
            dgvTopCustomers.Columns.Add("TotalSpent", "Total Spent");
            dgvTopCustomers.Columns["CustomerName"].DataPropertyName = ("CustomerName");
            dgvTopCustomers.Columns["Rank"].DataPropertyName = ("Rank");
            dgvTopCustomers.Columns["TotalOrders"].DataPropertyName = ("TotalOrders");
            dgvTopCustomers.Columns["TotalSpent"].DataPropertyName = ("TotalSpent");


            dgvTopCustomers.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);//font of column

            dgvTopCustomers.DefaultCellStyle.Font = new   System.Drawing.Font("Segoe UI", 10);
            dgvTopCustomers.DefaultCellStyle.SelectionBackColor = Color.LightGray;
            dgvTopCustomers.DefaultCellStyle.SelectionForeColor = Color.Black;

            pnlTopCustomers.Controls.Add(lblTitle);
            pnlTopCustomers.Controls.Add(lblSubtitle);

            pnlTopCustomers.Controls.Add(lblMonth);
            pnlTopCustomers.Controls.Add(cmbMonth);
            pnlTopCustomers.Controls.Add(btnSearch);

            pnlTopCustomers.Controls.Add(dgvTopCustomers);


            pnlMain.Controls.Add(pnlTopCustomers);


            pnlTopCustomers.BringToFront();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            int month = cmbMonth.SelectedIndex + 1;

            string sql = "SELECT customers.Name AS CustomerName, " +
                         "COUNT(orders.OrderID) AS TotalOrders, " +
                         "SUM(orders.TotalAmount) AS TotalSpent " +
                         "FROM customers " +
                         "INNER JOIN orders ON customers.CustomerID = orders.CustomerID " +
                         "WHERE MONTH(orders.OrderDate) = " + month + "  AND orders.Status!='Cancelled' " +
                         "GROUP BY customers.Name " +
                         "ORDER BY TotalSpent DESC " +
                         "LIMIT 5";

            DataTable dt = db.GetData(sql);

            dt.Columns.Add("Rank", typeof(int));

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["Rank"] = i + 1;
            }

            dgvTopCustomers.DataSource = dt;
        }





        private void btnSaveProduct_Click(object sender, EventArgs e)
        {
            // Check product name
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                MessageBox.Show("Please enter the product name.");
                return;
            }

            // Check price
            decimal price;
            if (!decimal.TryParse(txtPrice.Text, out price) || price <= 0)
            {
                MessageBox.Show("Please enter a valid price.");
                return;
            }

            // Check category
            if (cmbCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a category.");
                return;
            }

            // Check seller
            if (cmbSeller.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a seller.");
                return;
            }
            string categorySql = "SELECT CategoryID FROM category WHERE Name = @name";

            DataTable categoryDt = db.GetData(categorySql,
                new MySqlParameter("@name", cmbCategory.Text));

            int categoryID = Convert.ToInt32(categoryDt.Rows[0]["CategoryID"]);

            string sellerSql = "SELECT SellerID FROM seller WHERE Name = @name";

            DataTable sellerDt = db.GetData(sellerSql,
                new MySqlParameter("@name", cmbSeller.Text));

            int sellerID = Convert.ToInt32(sellerDt.Rows[0]["SellerID"]);


            string sql = "INSERT INTO product (Name, Price, CategoryID, SellerID, Image) " +
                "VALUES (@name, @price, @category, @seller, @image)";

            db.ExecuteQuery(sql,
                new MySqlParameter("@name", txtProductName.Text.Trim()),
                new MySqlParameter("@price", price),
                new MySqlParameter("@category", categoryID),
                new MySqlParameter("@seller", sellerID),
                new MySqlParameter("@image", txtImageLink.Text.Trim()));

            MessageBox.Show("Product added successfully!");
        }





















        private void admin_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1400, 800);
            this.Text = "admin";
            this.BackColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;

            // 1. Sidebar
            Panel pnlSidebar = new Panel();
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(220, 800);
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.BackColor = Color.FromArgb(15, 23, 42);
            this.Controls.Add(pnlSidebar);

            // 2. Main
            pnlMain = new Panel();
            pnlMain.Visible = true;
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(1180, 800);
            pnlMain.Location = new Point(220, 0);
            pnlMain.BackColor = Color.White;
            pnlMain.AutoScroll = true;
            this.Controls.Add(pnlMain);

            // #2 ShopSphere
            Label lblShop = new Label();
            lblShop.Text = "ShopSphere";
            lblShop.Location = new Point(25, 25);
            lblShop.Size = new Size(180, 35);
            lblShop.Font = new System.Drawing.Font("Segoe UI", 16, FontStyle.Bold);
            lblShop.ForeColor = Color.White;
            pnlSidebar.Controls.Add(lblShop);

            btnDashboard = new Button();
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Text = "Dashboard";
            btnDashboard.Size = new Size(200, 55);
            btnDashboard.Location = new Point(10, 100);

            btnDashboard.BackColor = Color.FromArgb(37, 99, 235);
            btnDashboard.ForeColor = Color.White;
            btnDashboard.Padding = new Padding(30, 0, 0, 0);
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.TextAlign = ContentAlignment.MiddleLeft;
            btnDashboard.Click += btnDashboard_Click;
            btnDashboard.Font = new  System.Drawing.Font("Segoe UI", 10, FontStyle.Regular);
            btnDashboard.Cursor = Cursors.Hand;
            pnlSidebar.Controls.Add(btnDashboard);

            // Add Product Button
            btnAddProduct = new Button();

            btnAddProduct.Click += btnAddProduct_Click;
            btnAddProduct.Name = "btnAddProduct";
            btnAddProduct.Text = "Add Product";
            btnAddProduct.Size = new Size(200, 55);
            btnAddProduct.Location = new Point(10, 170);
            btnAddProduct.Padding = new Padding(30, 0, 0, 0);
            btnAddProduct.FlatStyle = FlatStyle.Flat;
            btnAddProduct.FlatAppearance.BorderSize = 0;
            btnAddProduct.TextAlign = ContentAlignment.MiddleLeft;
            btnAddProduct.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Regular);
            btnAddProduct.ForeColor = Color.White;
            btnAddProduct.BackColor = Color.FromArgb(15, 23, 42);
            btnAddProduct.Cursor = Cursors.Hand;

            pnlSidebar.Controls.Add(btnAddProduct);
            // 2. Reports Button

        
            btnMostOrdered = new Button();
            btnMostOrdered.Name = "btnMostOrdered";
            btnMostOrdered.Size = new Size(200, 55);
            btnMostOrdered.Location = new Point(10, 240);
            btnMostOrdered.BackColor = Color.FromArgb(15, 23, 42);
            btnMostOrdered.ForeColor = Color.White;
            btnMostOrdered.Text = "Most Ordered Items";
            btnMostOrdered.Padding = new Padding(30, 0, 0, 0);
            btnMostOrdered.FlatStyle = FlatStyle.Flat;
            btnMostOrdered.FlatAppearance.BorderSize = 0;
            btnMostOrdered.TextAlign = ContentAlignment.MiddleLeft;
            btnMostOrdered.Font = new System.Drawing.Font ("Segoe UI", 10, FontStyle.Regular);
            btnMostOrdered.Cursor = Cursors.Hand;
            btnMostOrdered.Click += btnMostOrdered_Click;
            pnlSidebar.Controls.Add(btnMostOrdered);

            Button btnTopCustomers = new Button();
            btnTopCustomers.Name = "btnTopCustomers";
            btnTopCustomers.Text = "Top Customers";
            // Top Customers
            btnTopCustomers.Size = new Size(200, 55);
            btnTopCustomers.Location = new Point(10, 310);
            btnTopCustomers.BackColor = Color.FromArgb(15, 23, 42);
            btnTopCustomers.ForeColor = Color.White;
            btnTopCustomers.Padding = new Padding(30, 0, 0, 0);//space 30 pixels
            btnTopCustomers.FlatStyle = FlatStyle.Flat;
            btnTopCustomers.FlatAppearance.BorderSize = 0;
            btnTopCustomers.TextAlign = ContentAlignment.MiddleLeft;
       
            btnTopCustomers.Font = new System.Drawing.Font ("Segoe UI", 10, FontStyle.Regular);
            btnTopCustomers.Click += btnTopCustomers_Click;
            btnTopCustomers.Cursor = Cursors.Hand;
            pnlSidebar.Controls.Add(btnTopCustomers);
            Panel pnlBottom = new Panel();
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Size = new Size(220, 120);
            pnlBottom.Location = new Point(0, 560);
            pnlBottom.BackColor = Color.FromArgb(15, 23, 42);
            pnlSidebar.Controls.Add(pnlBottom);


            // View All Customers Button
           btnViewCustomers = new Button();
            btnViewCustomers.Name = "btnViewCustomers";
            btnViewCustomers.Text = "View All Customers";
            btnViewCustomers.Size = new Size(200, 55);
            btnViewCustomers.Location = new Point(10, 380);
            btnViewCustomers.BackColor = Color.FromArgb(15, 23, 42);
            btnViewCustomers.ForeColor = Color.White;
            btnViewCustomers.Padding = new Padding(30, 0, 0, 0);
            btnViewCustomers.FlatStyle = FlatStyle.Flat;
            btnViewCustomers.FlatAppearance.BorderSize = 0;
            btnViewCustomers.TextAlign = ContentAlignment.MiddleLeft;
            btnViewCustomers.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Regular);
            btnViewCustomers.Cursor = Cursors.Hand;
            btnViewCustomers.Click += btnViewCustomers_Click;

            pnlSidebar.Controls.Add(btnViewCustomers);

            // Separator line
            Panel line = new Panel();
            line.Size = new Size(190, 1);
            line.Location = new Point(15, 5);
            line.BackColor = Color.FromArgb(50, 60, 90);
            pnlBottom.Controls.Add(line);

            // Admin name
            Label lblAdminBottom = new Label();
            lblAdminBottom.Text = "👤  " + Class1.admin;
            lblAdminBottom.Location = new Point(25, 18);
            lblAdminBottom.Size = new Size(170, 25);
            lblAdminBottom.ForeColor = Color.White;
            lblAdminBottom.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            lblAdminBottom.TextAlign = ContentAlignment.MiddleCenter;
            pnlBottom.Controls.Add(lblAdminBottom);

            // Logout
            btnLogout = new Button();
            btnLogout.Name = "btnLogout";
            btnLogout.Text = "Logout";
            btnLogout.Location = new Point(25, 80);
            btnLogout.Size = new Size(190, 40);
            btnLogout.BackColor = Color.FromArgb(220, 53, 69);
            btnLogout.ForeColor = Color.White;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
            btnLogout.TextAlign = ContentAlignment.MiddleCenter;
            btnLogout.Click += BtnLogout_Click;
            pnlBottom.Controls.Add(btnLogout);
            btnDashboard_Click(null, null);

        }
        private void btnViewCustomers_Click(object sender, EventArgs e)
        {


            pnlMain.Controls.Clear();

            ds = new DataGridView();

            ds.Location = new Point(30, 110);
            ds.Size = new Size(1050, 500);
            string sql = "SELECT * FROM customers";
            DataTable customers = db.GetData(sql);

            ds.DataSource = customers;


            pnlMain.Controls.Add(ds);
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout ?","Logout",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                LoginForm s = new LoginForm();
                s.Show();
            }
        }
        private void btnMostOrdered_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear(); 
            order = new Panel();
            order.Name = "pnlMostOrdered";
            order.Location = new Point (0, 0);
            order.Size = new Size(1180, 800);

            Label title = new Label();
            title.Name = "lblMostOrderedTitle";
            title.Text = "Most Ordered Items";
            title.Font = new System.Drawing.Font("Segoe UI", 24, FontStyle.Bold);
            title.Location = new Point(50, 35);
            title.Size = new Size(500, 45);
            title.ForeColor = Color.FromArgb(11, 31, 92);
            order.Controls.Add(title);

            Label subtitle = new Label();
            subtitle.Name = "lblMostOrderedSubtitle";
            subtitle.Text = "Products with the highest number of sales";
            subtitle.Font = new System.Drawing.Font("Segoe UI", 10);
            subtitle.ForeColor = Color.Gray;
            subtitle.Location = new Point(53, 82);
            subtitle.Size = new Size(500, 25);
            order.Controls.Add(subtitle);

            Label year = new Label();
            year.Name = "lblYear";
            year.Text = "Year";
            year.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            year.Location = new Point(700, 45);
            year.Size = new Size(50, 25);
            order.Controls.Add(year);

            cmbYear = new ComboBox();
            cmbYear.Name = "cmbYear";
            cmbYear.Location = new Point(700, 70);
            cmbYear.Size = new Size(100, 30);
            cmbYear.Items.Add("2026");
            cmbYear.SelectedIndex = 0;
            order.Controls.Add(cmbYear);



            Label month = new Label();
            month.Name = "lblMonth";
            month.Text = "Month";
            month.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            month.Location = new Point(820, 45);
            month.Size = new Size(80, 25);
            order.Controls.Add(month);



            MonthComboBox = new ComboBox();
            MonthComboBox.Name = "cmbMonth";
            MonthComboBox.Location = new Point(820, 70);

            MonthComboBox.Size = new Size(130, 30);
            MonthComboBox.Items.Add("January");
            MonthComboBox.Items.Add("February");
            MonthComboBox.Items.Add("March");
            MonthComboBox.Items.Add("April");
            MonthComboBox.Items.Add("May");
            MonthComboBox.Items.Add("June");
            MonthComboBox.Items.Add("July");
            MonthComboBox.Items.Add("August");
            MonthComboBox.Items.Add("September");
            MonthComboBox.Items.Add("October");
            MonthComboBox.Items.Add("November");
            MonthComboBox.Items.Add("December");
            MonthComboBox.SelectedIndex = 0;
            MonthComboBox.DropDownStyle= ComboBoxStyle.DropDownList;
            order.Controls.Add(MonthComboBox);

            search = new Button();
            search.Name = "btnSearchMostOrdered";
            search.Text = "Search";
            search.Location = new Point(970, 70);
            search.Size = new Size(100, 30);

            search.Click += search_Click;

            order.Controls.Add(search);

            ds = new DataGridView();
            ds.Name = "dgvMostOrdered";
            ds.Location = new Point(50, 140);
            ds.Size = new Size(1080, 570);
            ds.Columns.Add("Rank", "Rank");
            ds.Columns.Add("Product", "Product");
            ds.Columns.Add("Category", "Category");
            ds.Columns.Add("Quantity Sold", "Quantity Sold");
            ds.Columns.Add("Revenue", "Revenue");
            ds.AllowUserToAddRows = false;
            ds.AllowUserToDeleteRows = false;
            ds.AutoGenerateColumns = false;
            ds.Columns["Rank"].DataPropertyName = ("Rank");
            ds.Columns["Product"].DataPropertyName = ("Product");
            ds.Columns["Category"].DataPropertyName = ("Category");
            ds.Columns["Quantity Sold"].DataPropertyName = ("Quantity Sold");
            ds.Columns["Revenue"].DataPropertyName = ("Revenue");
            ds.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            ds.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ds.BackgroundColor = Color.White;
            ds.BorderStyle=BorderStyle.None;
            //DataTable → DataGridView (DataPropertyName) Where should this DataGridView column get its data from
            order.Controls.Add(ds);
            pnlMain.Controls.Add(order);
            order.BringToFront();
          

        }
        private void search_Click(object sender, EventArgs e)
        {

            int mon = MonthComboBox.SelectedIndex + 1;
            int year = Convert.ToInt32(cmbYear.SelectedItem);

            string sql = "SELECT product.Name AS `Product`, " +
                         "category.Name AS `Category`, " +
                         "SUM(orderdetails.Quantity) AS `Quantity Sold`, " +
                         "product.Price * SUM(orderdetails.Quantity) AS `Revenue` " +
                         "FROM product " +
                         "INNER JOIN category " +
                         "ON product.CategoryID = category.CategoryID " +
                         "INNER JOIN orderdetails " +
                         "ON orderdetails.ProductID = product.ProductID " +
                         "INNER JOIN orders " +
                         "ON orderdetails.OrderID = orders.OrderID " +
                         "WHERE MONTH(orders.OrderDate) = @month " +
                         "AND YEAR(orders.OrderDate) = @year " +
                         "AND orders.Status != @Status " +
                         "GROUP BY product.ProductID, product.Name, category.Name, product.Price " +
                         "ORDER BY `Quantity Sold` DESC LIMIT 10";

            DataTable report = db.GetData(sql,
                new MySqlParameter("@month", mon),
                new MySqlParameter("@year", year),
                new MySqlParameter("@Status", "Cancelled"));
            report.Columns.Add("Rank", typeof(int));

            for (int i = 0; i < report.Rows.Count; i++)
            {
                report.Rows[i]["Rank"] = i + 1;
            }

            ds.DataSource = report;


        }
    }
}
