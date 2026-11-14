using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;   // ← add this
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ray_Sanaa_Final_Project
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(245, 247, 250);
        }
        private void LoadProducts()
        {
            flowProducts.Controls.Clear();
            GreetingsLabel.Text += CurrentUser.CustomerName + "!";

            MySqldb db = new MySqldb("ShopSphere");

            DataTable dt = db.GetData("SELECT * FROM product");

            foreach (DataRow row in dt.Rows)//👉 Goes row by row (each product)
            {
                Panel productPanel = new Panel();// Product box

                productPanel.Width = 250;
                productPanel.Height = 270;
                productPanel.BackColor = Color.White;
                productPanel.Margin = new Padding(15);
                PictureBox picture = new PictureBox();

                picture.Width = 200;
                picture.Height = 120;
                picture.Left = 25;
                picture.Top = 10;
                picture.SizeMode = PictureBoxSizeMode.Zoom;

                string image = row["Image"].ToString();


                string imagePath = Path.Combine(Application.StartupPath, "Images", image);//Location of image

                if (File.Exists(imagePath))//If a file exists at this exact address/path.
                {
                    picture.Image = Image.FromFile(imagePath);
                }

                Label lblName = new Label();

                lblName.Text = row["name"].ToString();//get the value from the “name” column in that row
                lblName.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                lblName.Top = 140;
                lblName.Left = 20;
                lblName.AutoSize = true;

                Label lblPrice = new Label();

                lblPrice.Text = "$" + row["price"].ToString();
                lblPrice.Font = new Font("Segoe UI", 11);
                lblPrice.Top = 175;
                lblPrice.Left = 20;
                lblPrice.AutoSize = true;

                NumericUpDown numQty = new NumericUpDown();
                numQty.Width = 55;
                numQty.Height = 35;
                numQty.Top = 215;
                numQty.Left = 15; // left side
                numQty.Minimum = 1;
                numQty.Maximum = 99;
                numQty.Value = 1;
                numQty.Font = new Font("Segoe UI", 10);

                Button btnCart = new Button();
                btnCart.Text = "Add To Cart";
                btnCart.Width = 145; // smaller to fit
                btnCart.Height = 38;
                btnCart.Top = 212; // same line
                btnCart.Left = 80;

                int productID = Convert.ToInt32(row["productID"]);
                string productName = row["name"].ToString();
                decimal price = Convert.ToDecimal(row["price"]);
                //sanaa
                btnCart.Click += (s, e2) =>//lambda
                {
                    int quantity = Convert.ToInt32(numQty.Value);
                    decimal total = price * quantity;
                    ShoppingCart.cart.Rows.Add(
                        productID,
                        productName,
                        price,
                        quantity,
                        total
                    );

                    MessageBox.Show(productName + " added to cart");
                };
                productPanel.Controls.Add(numQty);
                productPanel.Controls.Add(lblName);
                productPanel.Controls.Add(lblPrice);
                productPanel.Controls.Add(btnCart);
                productPanel.Controls.Add(picture);
                flowProducts.Controls.Add(productPanel);
            }
        }


        private void mainForm_Load(object sender, EventArgs e)
        {
            LoadProducts();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            cartForm frm = new cartForm();
            frm.Show();
            this.Close();
        }



        private void buttonLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonLogout_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void flowProducts_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
