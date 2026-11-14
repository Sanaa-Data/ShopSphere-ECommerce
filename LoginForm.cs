
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System.Data;
using System.Net.NetworkInformation;
using System.IO;
using System.Drawing;

namespace Ray_Sanaa_Final_Project
{
    public partial class LoginForm : Form
    {

        public LoginForm()
        {
            InitializeComponent();
            this.Size = new Size(1200, 700);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;


            Panel backgroundLeft = new Panel();

            backgroundLeft.BackColor = Color.FromArgb(243, 244, 246);
            backgroundLeft.Size = new Size(300, 700);
            backgroundLeft.Location = new Point(0, 0);
            this.Controls.Add(backgroundLeft);


            Panel leftCard = new Panel();
            leftCard.Size = new Size(480, 600);
            leftCard.Location = new Point(120, 50);

            leftCard.BackColor = Color.FromArgb(15, 23, 42);
            this.Controls.Add(leftCard);


            Panel rightCard = new Panel();
            rightCard.Size = new Size(480, 600);
            rightCard.Location = new Point(600, 50);
            rightCard.BackColor = Color.White;
            this.Controls.Add(rightCard);

            backgroundLeft.SendToBack();

            leftCard.BringToFront();
            rightCard.BringToFront();


            PictureBox picPerson = new PictureBox();
            string path = @"Images/loginImage.png";
            if (File.Exists(path)) picPerson.Image = Image.FromFile(path);
            picPerson.SizeMode = PictureBoxSizeMode.Zoom;
            picPerson.BackColor = Color.Transparent;
            picPerson.Size = new Size(220, 220);
            picPerson.Location = new Point(130, 80);
            leftCard.Controls.Add(picPerson);

            Label lblText = new Label();
            lblText.Text = "Manage Your Orders,\nInventory & Analytics\nAll in One Sphere";
            lblText.Font = new Font("Segoe UI", 12);
            lblText.ForeColor = Color.White;
            lblText.TextAlign = ContentAlignment.MiddleCenter;
            lblText.AutoSize = true;
            lblText.Location = new Point(140, 340);
            leftCard.Controls.Add(lblText);

            btnSignUp = new Button();
            btnSignUp.Text = "SIGN UP";
            btnSignUp.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnSignUp.BackColor = Color.White;
            btnSignUp.ForeColor = Color.FromArgb(37, 99, 235);
            btnSignUp.FlatStyle = FlatStyle.Flat;
            btnSignUp.FlatAppearance.BorderSize = 0;
            btnSignUp.Size = new Size(220, 50);
            btnSignUp.Location = new Point(130, 450);
            btnSignUp.Click += btnSignUp_Click;
            leftCard.Controls.Add(btnSignUp);


            Label lblLogo = new Label();
            lblLogo.Text = "ShopSphere";
            lblLogo.Font = new Font("Segoe UI", 28, FontStyle.Bold);
            lblLogo.ForeColor = Color.FromArgb(37, 99, 235); // #4285F4
            lblLogo.AutoSize = true;
            lblLogo.Location = new Point(165, 80);
            rightCard.Controls.Add(lblLogo);

            PictureBox picCart = new PictureBox();
            string cartImage = @"Images/box.png";
            if (File.Exists(cartImage))
            {
                picCart.Image = Image.FromFile(cartImage);
            }
            picCart.SizeMode = PictureBoxSizeMode.Zoom;
            picCart.BackColor = Color.Transparent;
            picCart.Size = new Size(44, 44);
            picCart.Location = new Point(120, 85);
            rightCard.Controls.Add(picCart);
            picCart.BringToFront();

            // Username
            Label lblUsername = new Label();
            lblUsername.Text = "Username";
            lblUsername.Font = new Font("Segoe UI", 11);
            lblUsername.ForeColor = Color.FromArgb(107, 114, 128);
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(80, 180);
            rightCard.Controls.Add(lblUsername);

            txtUsername = new TextBox();
            txtUsername.Font = new Font("Segoe UI", 12);
            txtUsername.Size = new Size(320, 30);
            txtUsername.Location = new Point(80, 215);
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.BackColor = Color.White;
            rightCard.Controls.Add(txtUsername);

            Panel line1 = new Panel();
            line1.BackColor = Color.FromArgb(209, 213, 219);
            line1.Size = new Size(320, 1);
            line1.Location = new Point(80, 248);
            rightCard.Controls.Add(line1);

            // Password
            Label lblPassword = new Label();
            lblPassword.Text = "Password";
            lblPassword.Font = new Font("Segoe UI", 11);

            lblPassword.ForeColor = Color.FromArgb(107, 114, 128);// #757575
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(80, 280);
            rightCard.Controls.Add(lblPassword);

            txtPassword = new TextBox();
            txtPassword.Font = new Font("Segoe UI", 12);
            txtPassword.Size = new Size(280, 30);
            txtPassword.Location = new Point(80, 315);
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.BackColor = Color.White;
            txtPassword.PasswordChar = '*';
            rightCard.Controls.Add(txtPassword);

            Panel line2 = new Panel();

            line2.BackColor = Color.FromArgb(209, 213, 219);
            line2.Size = new Size(280, 1);
            line2.Location = new Point(80, 352);
            rightCard.Controls.Add(line2);
            ShowButton = new Button();

            ShowButton.Size = new Size(65, 30);
            ShowButton.Location = new Point(365, 313);
            ShowButton.Font = new Font("Segoe UI", 8, FontStyle.Bold);

            ShowButton.FlatStyle = FlatStyle.Flat;
            ShowButton.FlatAppearance.BorderSize = 0;
            ShowButton.BackColor = Color.White;
            ShowButton.ForeColor = Color.FromArgb(37, 99, 235);
            ShowButton.Cursor = Cursors.Hand;
            ShowButton.TextAlign = ContentAlignment.MiddleCenter;
            ShowButton.Text = "👁";
            ShowButton.Click += ShowButton_Click;
            rightCard.Controls.Add(ShowButton);
            ShowButton.BringToFront();
            txtUsername.PlaceholderText = "Enter your username";
            txtPassword.PlaceholderText = "Enter your password";
            // Login Button
            Button btnLogin = new Button();
            btnLogin.Text = "LOG IN";
            btnLogin.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnLogin.BackColor = Color.FromArgb(37, 99, 235);
            btnLogin.ForeColor = Color.White;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.Size = new Size(300, 48);
            btnLogin.Location = new Point(80, 400);
            btnLogin.Click += btnLogin_Click;
            rightCard.Controls.Add(btnLogin);
        }

        TextBox txtUsername;
        Button ShowButton;
        TextBox txtPassword;
        Button btnSignUp;
        private void btnSignUp_Click(object sender, EventArgs e)
        {
            CreateAccountForm CreateAccount = new CreateAccountForm();
            CreateAccount.Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            MySqldb db = new MySqldb("ShopSphere");

            if (txtUsername.Text.Trim() == "" || txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("Please enter username and password!");
                return;
            }
            string name = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string adminSql = "SELECT * FROM admin Where Name=@name AND Password=@password";
            DataTable dtadmin = db.GetData(adminSql, new MySqlParameter("@name", name), new MySqlParameter("@password", password));
            if (dtadmin.Rows.Count > 0)
            {
                Class1.admin = dtadmin.Rows[0]["Name"].ToString();
                admin f = new admin();
                f.Show();
                this.Hide();
                return;
            }





            string sql = "SELECT * FROM customers WHERE Username=@name AND Password=@password";
            DataTable dt = db.GetData(sql, new MySqlParameter("@name", txtUsername.Text.Trim()), new MySqlParameter("@password", txtPassword.Text));

            if (dt.Rows.Count > 0)
            {
                CurrentUser.CustomerName = dt.Rows[0]["Name"].ToString();
                CurrentUser.CustomerID = Convert.ToInt32(dt.Rows[0]["customerID"]);
                CurrentUser.Username = dt.Rows[0]["Username"].ToString();

                MessageBox.Show("Login Successful");

                mainForm mf = new mainForm();
                mf.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Username or Password");
            }
        }
        private void ShowButton_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '*')
            {
                txtPassword.PasswordChar = default(char);
                ShowButton.Text = "🙈";
            }
            else
            {
                txtPassword.PasswordChar = '*';
                ShowButton.Text = "👁";
            }
        }

        private void panelRight_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
