using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ray_Sanaa_Final_Project
{
    public partial class cartForm : Form
    {
        public cartForm()
        {
            InitializeComponent();
            this.Load += cartForm_Load;
        }
        TextBox txtCardNumber; TextBox txtExpiry;


        TextBox txtCVV;
        TextBox txtCardholder;


        Button btnBack;
        Panel pnlPayment;
        Label lblPaymentTotal;
        Label lblTotal;
        DataGridView dgvCart;
        Button btnRemove;
        Button btnCheckout;
        RadioButton rbCreditCard;
        RadioButton rbCash;
        Panel pnlCash;
        Panel pnlData;
        MySqldb db = new MySqldb("ShopSphere");
        void headerPanel()
        {
            Panel header = new Panel();
            header.Size = new Size(950, 85);
            header.Location = new Point(0, 0);
            header.BackColor = Color.White;
            this.Controls.Add(header);
            header.BringToFront();

            Label lblTitle = new Label();
            lblTitle.Text = "🛒  Shopping Cart";
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 10);
            lblTitle.AutoSize = true;
            header.Controls.Add(lblTitle);

            Label lblSubtitle = new Label();
            lblSubtitle.Text = "Review your items and proceed to checkout";
            lblSubtitle.Font = new Font("Segoe UI", 10F);
            lblSubtitle.ForeColor = Color.Gray;
            lblSubtitle.Location = new Point(22, 50);
            lblSubtitle.AutoSize = true;
            header.Controls.Add(lblSubtitle);
        }
        private void cartForm_Load(object sender, EventArgs e)
        {
            this.ClientSize = new Size(950, 650);
            this.BackColor = Color.White;
            this.StartPosition = FormStartPosition.CenterScreen;


            headerPanel();

            // FIX dgv position so header is visible
            dgvCart = new DataGridView();
            dgvCart.Location = new Point(20, 95);
            dgvCart.Size = new Size(910, 400);
            dgvCart.BackgroundColor = Color.White;
            dgvCart.BorderStyle = BorderStyle.None;
            dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.Controls.Add(dgvCart);
            // FIX Total label position
            lblTotal = new Label();
            lblTotal.Name = "lblTotal";
            lblTotal.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTotal.ForeColor = Color.FromArgb(0, 0, 180);
            lblTotal.Location = new Point(20, 510);
            lblTotal.AutoSize = true;
            this.Controls.Add(lblTotal);
            lblTotal.BringToFront();

            // Buttons - same names
            btnRemove = new Button();
            btnRemove.Location = new Point(650, 510);
            btnRemove.Size = new Size(280, 45);
            btnRemove.Text = "🗑️ Remove Item";

            btnRemove.BackColor = Color.FromArgb(220, 53, 69);
            btnRemove.ForeColor = Color.White;
            btnRemove.FlatStyle = FlatStyle.Flat;
            btnRemove.FlatAppearance.BorderSize = 0;
            this.Controls.Add(btnRemove);
            btnRemove.BringToFront();
            btnRemove.Click += btnRemove_Click;
            btnCheckout = new Button();
            btnCheckout.Location = new Point(650, 570);
            btnCheckout.Size = new Size(280, 45);
            btnCheckout.Text = "Checkout  →";
            btnCheckout.BackColor = Color.FromArgb(0, 120, 215);
            btnCheckout.ForeColor = Color.White;
            btnCheckout.Click += btnCheckout_Click;
            btnCheckout.FlatStyle = FlatStyle.Flat;
            btnCheckout.FlatAppearance.BorderSize = 0;
            btnCheckout.BringToFront();
            this.Controls.Add(btnCheckout);
            btnBack = new Button();
            btnBack.Location = new Point(20, 600);
            btnBack.Size = new Size(140, 35);
            btnBack.Click += btnBack_Click;
            btnBack.Text = "<--- Back";
            this.Controls.Add(btnBack);
            btnBack.BringToFront();

            dgvCart.DataSource = ShoppingCart.cart;
            decimalTotal();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            mainForm backfrm = new mainForm();
            backfrm.Show();
            this.Close();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvCart.CurrentRow != null)
            {
                int index = dgvCart.CurrentRow.Index;

                ShoppingCart.cart.Rows.RemoveAt(index);
                decimalTotal();
            }
        }
        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (ShoppingCart.cart.Rows.Count == 0)
            {
                MessageBox.Show("Your cart is empty!");
                return;
            }

            if (pnlPayment == null)
            {
                CreatePaymentPanel();
            }

            decimal total = decimalTotal();

            lblPaymentTotal.Text = "Total to pay: " + total.ToString("0.00") + " $";

            pnlPayment.Visible = true;
            pnlPayment.BringToFront();
        }
        decimal decimalTotal()
        {
            decimal total = 0;

            foreach (DataRow row in ShoppingCart.cart.Rows)
            {
                decimal price = Convert.ToDecimal(row["Price"]);
                int quantity = Convert.ToInt32(row["Quantity"]);

                total += price * quantity;
            }


            lblTotal.Text = "Total: " + total.ToString("0.00") + " $";
            return total;
        }

        private void CreatePaymentPanel()
        {
            pnlPayment = new Panel();

            pnlPayment.Name = "pnlPayment";
            pnlPayment.Size = new Size(650, 550);
            pnlPayment.Location = new Point(150, 40);
            pnlPayment.BackColor = Color.White;
            pnlPayment.BorderStyle = BorderStyle.FixedSingle;
            pnlPayment.Visible = false;

            // Payment title
            Label lblTitle = new Label();

            lblTitle.Text = "Payment Details";
            lblTitle.Font = new Font("Arial", 18, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(40, 40, 40);
            lblTitle.Location = new Point(25, 15);
            lblTitle.Size = new Size(580, 35);



            // Payment method label
            Label lblMethod = new Label();
            lblMethod.Text = "Select Payment Method";
            lblMethod.Font = new Font("Arial", 12, FontStyle.Bold);
            lblMethod.Location = new Point(25, 65);
            lblMethod.Size = new Size(300, 30);

            // Panel for payment methods
            Panel pnlMethod = new Panel();
            pnlMethod.Name = "pnlMethod";
            pnlMethod.Location = new Point(25, 100);
            pnlMethod.Size = new Size(580, 90);
            pnlMethod.BorderStyle = BorderStyle.FixedSingle;

            // Credit Card
            rbCreditCard = new RadioButton();
            rbCreditCard.Text = "Credit Card";
            rbCreditCard.Location = new Point(20, 25);
            rbCreditCard.Size = new Size(150, 30);
            rbCreditCard.Checked = true;

            // Cash on Delivery
            rbCash = new RadioButton();
            rbCash.Text = "Cash on Delivery";
            rbCash.Location = new Point(280, 25);
            rbCash.Size = new Size(200, 30);

            // Add radio buttons to the method panel
            pnlMethod.Controls.Add(rbCreditCard);
            pnlMethod.Controls.Add(rbCash);

            // Add controls to the main payment panel
            pnlPayment.Controls.Add(lblTitle);
            pnlPayment.Controls.Add(lblMethod);
            pnlPayment.Controls.Add(pnlMethod);
            lblPaymentTotal = new Label();
            lblPaymentTotal.Text = "Total to pay: 0.00 $";
            lblPaymentTotal.Font = new Font("Arial", 12, FontStyle.Bold);
            lblPaymentTotal.Location = new Point(25, 450);
            lblPaymentTotal.Size = new Size(300, 30);

            pnlPayment.Controls.Add(lblPaymentTotal);

            // Add main panel to the form
            this.Controls.Add(pnlPayment);
            pnlPayment.BringToFront();




            // Small panel for payment information
            pnlData = new Panel();
            pnlData.Name = "pnlData";
            pnlData.Location = new Point(25, 205);
            pnlData.Size = new Size(580, 230);
            pnlData.BorderStyle = BorderStyle.FixedSingle;
            pnlData.BackColor = Color.White;

            // Panel title
            Label lblDataTitle = new Label();
            lblDataTitle.Text = "Payment Information";
            lblDataTitle.Font = new Font("Arial", 12, FontStyle.Bold);
            lblDataTitle.Location = new Point(15, 10);
            lblDataTitle.Size = new Size(300, 25);
            pnlData.Controls.Add(lblDataTitle);

            // Card number
            Label lblCardNumber = new Label();
            lblCardNumber.Text = "Card Number";
            lblCardNumber.Location = new Point(15, 45);
            lblCardNumber.Size = new Size(150, 20);

            txtCardNumber = new TextBox();
            txtCardNumber.Name = "txtCardNumber";
            txtCardNumber.Location = new Point(15, 67);
            txtCardNumber.Size = new Size(530, 25);
            txtCardNumber.MaxLength = 19;

            // Expiration date
            Label lblExpiry = new Label();
            lblExpiry.Text = "Expiration Date (MM/YY)";
            lblExpiry.Location = new Point(15, 100);
            lblExpiry.Size = new Size(200, 20);

            txtExpiry = new TextBox();
            txtExpiry.Name = "txtExpiryDate";
            txtExpiry.Location = new Point(15, 122);
            txtExpiry.Size = new Size(250, 25);
            txtExpiry.MaxLength = 5;

            // CVV
            Label lblCVV = new Label();
            lblCVV.Text = "CVV";
            lblCVV.Location = new Point(300, 100);
            lblCVV.Size = new Size(100, 20);

            txtCVV = new TextBox();
            txtCVV.Name = "txtCVV";
            txtCVV.Location = new Point(300, 122);
            txtCVV.Size = new Size(245, 25);
            txtCVV.MaxLength = 4;
            txtCVV.UseSystemPasswordChar = true;

            // Cardholder name
            Label lblCardholder = new Label();
            lblCardholder.Text = "Cardholder Name";
            lblCardholder.Location = new Point(15, 155);
            lblCardholder.Size = new Size(200, 20);

            txtCardholder = new TextBox();
            txtCardholder.Name = "txtCardholderName";
            txtCardholder.Location = new Point(15, 177);
            txtCardholder.Size = new Size(530, 25);

            // Add information controls to pnlData
            pnlData.Controls.Add(lblCardNumber);
            pnlData.Controls.Add(txtCardNumber);
            pnlData.Controls.Add(lblExpiry);
            pnlData.Controls.Add(txtExpiry);
            pnlData.Controls.Add(lblCVV);
            pnlData.Controls.Add(txtCVV);
            pnlData.Controls.Add(lblCardholder);
            pnlData.Controls.Add(txtCardholder);

            // Add the small panel to the main panel
            pnlPayment.Controls.Add(pnlData);
            pnlData.Visible = false;
            pnlCash = new Panel();

            pnlCash.Name = "pnlCash";
            pnlCash.Size = new Size(580, 230);
            pnlCash.Location = new Point(25, 205);
            pnlCash.BackColor = Color.WhiteSmoke;
            pnlCash.BorderStyle = BorderStyle.FixedSingle;
            pnlCash.Visible = false;

            // Cash title
            Label lblCashTitle = new Label();

            lblCashTitle.Text = "Cash on Delivery";
            lblCashTitle.Font = new Font("Arial", 14, FontStyle.Bold);
            lblCashTitle.Location = new Point(20, 20);
            lblCashTitle.Size = new Size(300, 30);

            // Cash information
            Label lblCashInfo = new Label();

            lblCashInfo.Text = "You will pay in cash when your order arrives.";
            lblCashInfo.Font = new Font("Arial", 11);
            lblCashInfo.Location = new Point(20, 70);
            lblCashInfo.Size = new Size(500, 30);

            // Payment reminder
            Label lblCashNote = new Label();

            lblCashNote.Text = "Please prepare the exact amount if possible.";
            lblCashNote.Font = new Font("Arial", 10, FontStyle.Italic);
            lblCashNote.Location = new Point(20, 115);
            lblCashNote.Size = new Size(500, 30);

            // Add controls
            pnlCash.Controls.Add(lblCashTitle);
            pnlCash.Controls.Add(lblCashInfo);
            pnlCash.Controls.Add(lblCashNote);
            pnlPayment.Controls.Add(pnlCash);

            rbCreditCard.CheckedChanged += paymentMethod_Changed;
            rbCash.CheckedChanged += paymentMethod_Changed;
            // checked true or false 
            // Show the selected payment method
            pnlData.Visible = rbCreditCard.Checked;
            pnlCash.Visible = rbCash.Checked;

            // Pay button
            Button btnPay = new Button();
            btnPay.Text = "Confirm Order";
            btnPay.Location = new Point(400, 490);
            btnPay.Size = new Size(205, 40);
            btnPay.BackColor = Color.FromArgb(0, 120, 215);
            btnPay.ForeColor = Color.White;
            btnPay.FlatStyle = FlatStyle.Flat;
            btnPay.FlatAppearance.BorderSize = 0;
            btnPay.Click += btnPay_Click;

            pnlPayment.Controls.Add(btnPay);

        }
        private void paymentMethod_Changed(object sender, EventArgs e)
        {
            if (rbCreditCard.Checked)
            {
                pnlData.Visible = true;
                pnlCash.Visible = false;
            }
            else
            {
                pnlCash.Visible = true;
                pnlData.Visible = false;

            }
        }
        private void btnPay_Click(object sender, EventArgs e)
        {

            string method;

            if (ShoppingCart.cart.Rows.Count == 0)
            {
                MessageBox.Show("Your cart is empty!");
                return;
            }
            if (rbCreditCard.Checked)
            {
                 method = "Credit Card"; 
                if (txtCardNumber.Text.Trim() == "" ||
                    txtExpiry.Text.Trim() == "" ||
                    txtCVV.Text.Trim() == "" ||
                    txtCardholder.Text.Trim() == "")
                {
                    MessageBox.Show("Please fill in all card information!");
                    return;
                }
            }
            else
            {
                method = "Cash on Delivery";
            }
          
                try
                {
                decimal total = decimalTotal();
     
                string sql = @"INSERT INTO orders
        (CustomerID, OrderDate, Status, TotalAmount)
        VALUES (@customerID, CURDATE(), 'Pending', @total)";

                    int orderID = db.ExecuteQuery(sql,
                 new MySqlParameter("@customerID", CurrentUser.CustomerID),
                 new MySqlParameter("@total", total));

            
                    foreach (DataRow row in ShoppingCart.cart.Rows)
                    {
                        string detailSQL = @"INSERT INTO orderdetails
            (OrderID, ProductID, Quantity, Subtotal)
            VALUES (@orderID, @productID, @quantity, @subtotal)";

                        db.ExecuteQuery(detailSQL,
                            new MySqlParameter("@orderID", orderID),
                            new MySqlParameter("@productID", row["ProductID"]),
                            new MySqlParameter("@quantity", row["Quantity"]),
                            new MySqlParameter("@subtotal", row["Total"]));
                    }
          

                string PaymentSQL = @"INSERT INTO payment
(OrderID, Method, Amount, Status)
VALUES (@orderID, @method, @amount, @status)";

                db.ExecuteQuery(PaymentSQL,
                    new MySqlParameter("@orderID", orderID),
                    new MySqlParameter("@method", method),
                    new MySqlParameter("@amount", total),
                    new MySqlParameter("@status", "Pending"));

                MessageBox.Show("Order placed successfully!");





                ShoppingCart.cart.Clear();
                    dgvCart.DataSource = ShoppingCart.cart;
                    decimalTotal();

                    pnlPayment.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }


            }
        }


    
}
