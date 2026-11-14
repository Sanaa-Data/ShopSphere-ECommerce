using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;


namespace Ray_Sanaa_Final_Project
{
    public partial class CreateAccountForm : Form
    {
        public CreateAccountForm()
        {
            InitializeComponent();
            btn = new Button();
        }

        MySqldb db = new MySqldb("ShopSphere");
        TextBox strength;
        TextBox Emailtxt;
        Button pass;
        Button Conpass;
        TextBox txtName;
        TextBox Passtxt;
        TextBox Contxt;
        ProgressBar bar1, bar2, bar3, bar4;
        TextBox phoneTxt;
        ComboBox allcountry;
        Button btn;
        ComboBox countryCode;
        TextBox Addtxt;
        TextBox Usertxt;
        ErrorProvider error = new ErrorProvider();
        Label lb;
       private void Validate()
        {
            btn.Enabled = IsFormValid();
        }

        private bool IsFormValid()
        {
            return !string.IsNullOrWhiteSpace(txtName.Text) &&
                   !string.IsNullOrWhiteSpace(Passtxt.Text) &&
                   !string.IsNullOrWhiteSpace(Contxt.Text) &&
                   Passtxt.Text == Contxt.Text &&
                   !string.IsNullOrWhiteSpace(Emailtxt.Text) &&
                   !string.IsNullOrWhiteSpace(Usertxt.Text) &&
                   !string.IsNullOrWhiteSpace(Addtxt.Text) &&
                   !string.IsNullOrWhiteSpace(phoneTxt.Text) &&
                   allcountry.SelectedIndex > 0 &&
                   countryCode.SelectedIndex > 0 && error.GetError(txtName) == "" &&
error.GetError(Emailtxt) == "" &&
error.GetError(Usertxt) == "" &&
error.GetError(phoneTxt) == "" &&
error.GetError(Contxt) == ""  ;
        }
        private void phoneTxt_Leave(object sender, EventArgs e)
        {

            error.SetError(phoneTxt, "");
            string number = phoneTxt.Text;
            if (string.IsNullOrWhiteSpace(number))
            {
                error.SetError(phoneTxt, "Phone Number is required."); Validate(); return;
            }
            foreach (char c in number)
            {
                if (!(char.IsDigit(c)))
                {
                    error.SetError(phoneTxt, "Phone number should contain only digits."); Validate(); return;
                }
            }
            if (countryCode.SelectedItem.ToString() == "+93")
            {
                if (phoneTxt.Text.Length != 9)
                    error.SetError(phoneTxt, "Afghanistan phone number must contain 9 digits.");
            }
            else if (countryCode.SelectedItem.ToString() == "+355")
            {
                if (phoneTxt.Text.Length != 9)
                    error.SetError(phoneTxt, "Albania phone number must contain 9 digits.");
            }
            else if (countryCode.SelectedItem.ToString() == "+213")
            {
                if (phoneTxt.Text.Length != 9)
                    error.SetError(phoneTxt, "Algeria phone number must contain 9 digits.");
            }
            else if (countryCode.SelectedItem.ToString() == "+376")
            {
                if (phoneTxt.Text.Length != 6)
                    error.SetError(phoneTxt, "Andorra phone number must contain 6 digits.");
            }
            else if (countryCode.SelectedItem.ToString() == "+244")
            {
                if (phoneTxt.Text.Length != 9)
                    error.SetError(phoneTxt, "Angola phone number must contain 9 digits.");
            }
            else if (countryCode.SelectedItem.ToString() == "+54")
            {
                if (phoneTxt.Text.Length != 10)
                    error.SetError(phoneTxt, "Argentina phone number must contain 10 digits.");
            }
            else if (countryCode.SelectedItem.ToString() == "+374")
            {
                if (phoneTxt.Text.Length != 8)
                    error.SetError(phoneTxt, "Armenia phone number must contain 8 digits.");
            }
            else if (countryCode.SelectedItem.ToString() == "+61")
            {
                if (phoneTxt.Text.Length != 9)
                    error.SetError(phoneTxt, "Australia phone number must contain 9 digits.");
            }
            else if (countryCode.SelectedItem.ToString() == "+43")
            {
                if (phoneTxt.Text.Length < 10 || phoneTxt.Text.Length > 13)
                    error.SetError(phoneTxt, "Austria phone number must contain 10 to 13 digits.");
            }
            else if (countryCode.SelectedItem.ToString() == "+994")
            {
                if (phoneTxt.Text.Length != 9)
                    error.SetError(phoneTxt, "Azerbaijan phone number must contain 9 digits.");
            }

            else if (countryCode.SelectedItem.ToString() == "+973")
            {
                if (phoneTxt.Text.Length != 8)
                    error.SetError(phoneTxt, "Bahrain phone number must contain 8 digits.");
            }
            else if (countryCode.SelectedItem.ToString() == "+880")
            {
                if (phoneTxt.Text.Length != 10)
                    error.SetError(phoneTxt, "Bangladesh phone number must contain 10 digits.");
            }
            else if (countryCode.SelectedItem.ToString() == "+32")
            {
                if (phoneTxt.Text.Length != 9)
                    error.SetError(phoneTxt, "Belgium phone number must contain 9 digits.");
            }
            else if (countryCode.SelectedItem.ToString() == "+55")
            {
                if (phoneTxt.Text.Length < 10 || phoneTxt.Text.Length > 11)
                    error.SetError(phoneTxt, "Brazil phone number must contain 10 or 11 digits.");
            }
            else if (countryCode.SelectedItem.ToString() == "+1")
            {
                if (phoneTxt.Text.Length != 10)
                {
                    if (allcountry.SelectedItem.ToString() == "Canada")
                        error.SetError(phoneTxt, "Canada phone number must contain 10 digits.");
                    else if (allcountry.SelectedItem.ToString() == "United States")
                        error.SetError(phoneTxt, "USA phone number must contain 10 digits.");
            }
            }
            else if (countryCode.SelectedItem.ToString() == "+86")
            {
                if (phoneTxt.Text.Length != 11)
                    error.SetError(phoneTxt, "China phone number must contain 11 digits.");
            }
            else if (countryCode.SelectedItem.ToString() == "+45")
            {
                if (phoneTxt.Text.Length != 8)
                    error.SetError(phoneTxt, "Denmark phone number must contain 8 digits.");
            }
            else if (countryCode.SelectedItem.ToString() == "+20")
            {
                if (phoneTxt.Text.Length != 10)
                    error.SetError(phoneTxt, "Egypt phone number must contain 10 digits.");
            }
            else if (countryCode.SelectedItem.ToString() == "+33")
            {
                if (phoneTxt.Text.Length != 9)
                    error.SetError(phoneTxt, "France phone number must contain 9 digits.");
            }
            else if (countryCode.SelectedItem.ToString() == "+49")
            {
                if (phoneTxt.Text.Length < 10 || phoneTxt.Text.Length > 11)
                    error.SetError(phoneTxt, "Germany phone number must contain 10 to 11 digits.");
            }
            else if (countryCode.SelectedItem.ToString() == "+91")
            {
                if (phoneTxt.Text.Length != 10)
                    error.SetError(phoneTxt, "India phone number must contain 10 digits.");
            }
            else if (countryCode.SelectedItem.ToString() == "+62")
            {
                if (phoneTxt.Text.Length < 9 || phoneTxt.Text.Length > 12)
                    error.SetError(phoneTxt, "Indonesia phone number must contain 9 to 12 digits.");
            }
            else if (countryCode.SelectedItem.ToString() == "+98")
            {
                if (phoneTxt.Text.Length != 10)
                    error.SetError(phoneTxt, "Iran phone number must contain 10 digits.");
            }
            else if (countryCode.SelectedItem.ToString() == "+964")
            {
                if (phoneTxt.Text.Length != 10)
                    error.SetError(phoneTxt, "Iraq phone number must contain 10 digits.");
            }
            else if (countryCode.SelectedItem.ToString() == "+39")
            {
                if (phoneTxt.Text.Length != 10)
                    error.SetError(phoneTxt, "Italy phone number must contain 10 digits.");
            }
            else if (countryCode.SelectedItem.ToString() == "+81")
            {
                if (phoneTxt.Text.Length != 10)
                    error.SetError(phoneTxt, "Japan phone number must contain 10 digits.");
            }
            else if (countryCode.SelectedItem.ToString() == "+962")
            {
                if (phoneTxt.Text.Length != 9)
                    error.SetError(phoneTxt, "Jordan phone number must contain 9 digits.");
            }
            else if (countryCode.SelectedItem.ToString() == "+961")
            {
                if (phoneTxt.Text.Length != 8)
                    error.SetError(phoneTxt, "Lebanon phone number must contain 8 digits.");
            }
            else if (countryCode.SelectedItem.ToString() == "+218")
            {
                if (phoneTxt.Text.Length != 9)
                    error.SetError(phoneTxt, "Libya phone number must contain 9 digits.");
            }
            else if (countryCode.SelectedItem.ToString() == "+966")
            {
                if (phoneTxt.Text.Length != 9)
                    error.SetError(phoneTxt, "Saudi Arabia phone number must contain 9 digits.");
            }
            else if (countryCode.SelectedItem.ToString() == "+971")
            {
                if (phoneTxt.Text.Length != 9)
                    error.SetError(phoneTxt, "UAE phone number must contain 9 digits.");
            }
            else if (countryCode.SelectedItem.ToString() == "+44")
            {
                if (phoneTxt.Text.Length != 10)
                    error.SetError(phoneTxt, "UK phone number must contain 10 digits.");
            }
            else if (countryCode.SelectedItem.ToString() == "+84")
            {
                if (phoneTxt.Text.Length < 9 || phoneTxt.Text.Length > 10)
                    error.SetError(phoneTxt, "Vietnam phone number must contain 9 to 10 digits.");
            }
            else
            {
                error.SetError(phoneTxt, "");
            }
            Validate();
        }
        private void txtName_Leave(object sender, EventArgs e)
        {
            string name = txtName.Text;

          
           if(name.Length<3)
            {
                error.SetError(txtName, "Name should contain at Least 3 letters."); Validate(); return;
            }
            for (int i = 0; i < name.Length; i++)
            {
                if (name[i] ==' ')
                {
                    error.SetError(txtName, "Name should not countain space."); Validate(); return;
                }
                if (char.IsAsciiDigit(name[i]))
                {
                    error.SetError(txtName, "Name should not contain numbers"); Validate(); return;
                }
            }
                error.SetError(txtName,"");
            Validate();
        }
        private void Emailtxt_Leave(object sender, EventArgs e)
        {
            if(!Emailtxt.Text.ToLower().EndsWith("@gmail.com"))
            {
                error.SetError(Emailtxt,"Email must be a Gmail address (@gmail.com)");
                Validate();  return;
            }
            error.SetError(Emailtxt, "");Validate();
        }
        private void Usertxt_Leave(object sender, EventArgs e)
        {
            string username = Usertxt.Text;
        if (string.IsNullOrEmpty(username))
            {
                error.SetError(Usertxt, "Username should not be empty."); Validate();
                return;
            }
        if(Usertxt.Text.Length<5)
            {
                error.SetError(Usertxt, "Username must contain at least 5 characters."); Validate(); return;
            }

            bool hasLetter =false;

        for(int i=0;i<username.Length;i++)
            {
                if (char.IsLetter(username[i]))
                {
                    hasLetter = true;
                }

                if(!(char.IsLetterOrDigit(username[i])))
                {
                    error.SetError(Usertxt, "Username should not contain special characters."); Validate();
                    return;
                }
           
            }
     if(!hasLetter)
            {
                error.SetError(Usertxt, "Username should contain at least one letter."); Validate(); return;
            }
      error.SetError(Usertxt, ""); Validate();

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            Validate();

        }
        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Usertxt.Focus();
            }

        }
        private void phoneTxt_TextChanged(object sender, EventArgs e)
        {
            Validate();
        }
        private void PassTxt_TextChanged(object sender, EventArgs e)
        {
            Validate();
            int score = 0;
            string password = Passtxt.Text;
            bool hasLetter = false;
            bool hasDigit = false;
            bar1.Value = 0;
            bar2.Value = 0;
            bar3.Value = 0;
            bar4.Value = 0;
            bool hasSpecial = false;
            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsDigit(password[i]))
                {
                    hasDigit = true;
                
                }

                if (char.IsLetter(password[i]))
                {
                    hasLetter = true; 
                }

                if (!(char.IsLetterOrDigit(password[i])))
                {
                    hasSpecial = true; 
                }
            }
            if(password.Length>=8)
            {
                score++;
            }
            if(hasLetter)
            {
                score++;
            }
            if (hasDigit)
            {
                score++;
            }
            if(hasSpecial)
            {
                score++;
            }
            if (score >= 1)
            {
                bar1.Value = 100;
                bar1.BackColor = Color.Red;
                lb.Text = "Password Strength: Weak";
                lb.ForeColor = Color.FromArgb(220, 53, 69);
            }

            if (score >= 2)
            {
                bar2.Value = 100;
                bar2.BackColor = Color.Orange;
                lb.Text = "Password Strength: Fair";

                lb.ForeColor = Color.FromArgb(255, 159, 64);
            }

           if (score >= 3)
            {
                bar3.Value = 100;
                bar3.BackColor = Color.Gold;
                lb.Text = "Password Strength: Good";
                lb.ForeColor = Color.FromArgb(255, 193, 7);
            }

             if (score >= 4)
            {
                bar4.Value = 100;
                bar4.BackColor = Color.Green;
                lb.Text = "Password Strength: Strong";
                lb.ForeColor = Color.FromArgb(40, 167, 69);
            }

        }
        private void pass_Click(object sender, EventArgs e)
        {
           if( Passtxt.PasswordChar =='*')
            {
                Passtxt.PasswordChar = '\0';
            }
           else
            {
                Passtxt.PasswordChar = '*';
            }
        }
        private void Emailtxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Addtxt.Focus();
            }
        }

        private void Emailtxt_TextChanged(object sender, EventArgs e)
        {
            Validate();
        }
        private void Usertxt_keyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                Emailtxt.Focus();
            }
        }
        private void Passtxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Contxt.Focus();
            }
        }
        private void phoneTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Passtxt.Focus();
            }
        }
     
        private void Usertxt_TextChanged(object sender, EventArgs e)
        {
            Validate();
        }
        private void Addtxt_TextChanged(object sender, EventArgs e)
        {
            Validate();
        }
        private void Addtxt_KeyDown(object sender, KeyEventArgs e)
        {
         if(e.KeyCode==Keys.Enter)
                {
                allcountry.Focus();
            }
        }
       
        private void allcountry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                phoneTxt.Focus();
            }
        }
        private void Contxt_TextChanged(object sender, EventArgs e)
        {
            

            if (Contxt.Text != Passtxt.Text)
            {
                error.SetError(Contxt, "Passwords do not match.");
            }
            else
            {
                error.SetError(Contxt, "");
            }
            Validate();
        }

        private void countryCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            Validate();

            if (countryCode.SelectedIndex >= 0)
            {
                allcountry.SelectedIndex = countryCode.SelectedIndex;
            }
        }
        private void allcountry_SelectedIndexChanged(object sender, EventArgs e)
        {
      

            if (allcountry.SelectedIndex >= 0)
            {
                countryCode.SelectedIndex = allcountry.SelectedIndex;
            }
            Validate();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(Passtxt.Text) ||
                string.IsNullOrWhiteSpace(Emailtxt.Text) ||
                string.IsNullOrWhiteSpace(Usertxt.Text) ||
                string.IsNullOrWhiteSpace(Addtxt.Text) ||
                string.IsNullOrWhiteSpace(phoneTxt.Text) ||
                allcountry.SelectedIndex <= 0 ||
                countryCode.SelectedIndex <= 0)
            {
                MessageBox.Show("Please complete all fields.");
                return;
            }

            if (Passtxt.Text != Contxt.Text)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }
            if (!IsFormValid())
            {
                MessageBox.Show("Please correct the errors before creating your account.");
                return;
            }

            string sql = @"INSERT INTO Customer
    (Name, Username, Email, Password, PhoneNumber, Address, Country)
    VALUES
    (@name, @username, @email, @password, @phone, @address, @country)";

                db.ExecuteQuery(sql,
                    new MySqlParameter("@name", txtName.Text.Trim()),
                    new MySqlParameter("@username", Usertxt.Text.Trim()),
                    new MySqlParameter("@email", Emailtxt.Text.Trim()),
                    new MySqlParameter("@password", Passtxt.Text),
                    new MySqlParameter("@phone", phoneTxt.Text.Trim()),
                    new MySqlParameter("@address", Addtxt.Text.Trim()),
                    new MySqlParameter("@country", allcountry.Text)
                );

                MessageBox.Show("Account Created Successfully");

                LoginForm login = new LoginForm();
                login.Show();

                this.Close();
            
        }
        private void Conpass_Click(object sender, EventArgs e)
        {
            if(Contxt.PasswordChar=='*')
            {
                Contxt.PasswordChar = '\0';
            }
            else
            {
                Contxt.PasswordChar = '*';
            }
        }
        private Panel CreateInputPanel(int y)
        {
            Panel panel = new Panel();
            panel.Size = new Size(520, 45);
            panel.Location = new Point(40, y);
            panel.BackColor = Color.White;
            panel.BorderStyle = BorderStyle.None;

            return panel;
        }

        private void CreateAccountForm_Load(object sender, EventArgs e)
        {
            Panel mainPanel = new Panel();
            mainPanel.Size = new Size(600, 720);
            mainPanel.Location = new Point((this.ClientSize.Width - 600) / 2, 20);
            mainPanel.BackColor = Color.WhiteSmoke;
            mainPanel.BorderStyle = BorderStyle.None;
            // FORM (DEEP BLUE THEME)
            this.Text = "Create Account";
            this.Size = new Size(1200, 800);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(11, 31, 92);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Controls.Add(mainPanel);



            // TITLE
            Label title = new Label();
            title.Text = "Create your Account";
            title.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            title.ForeColor = Color.FromArgb(11, 31, 92);
            title.AutoSize = true;
            title.Location = new Point(170, 15);
            mainPanel.Controls.Add(title);
            int y = 90;
            int step = 55;

            // INPUTS
            Panel Namepanel = CreateInputPanel(y);
            Label lbl = new Label();
            lbl.Text = "👤";
            lbl.Size = new Size(45, 45);
            lbl.Location = new Point(0, 0);
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Font = new Font("Segoe UI Emoji", 11);
            lbl.ForeColor = Color.FromArgb(100, 100, 100);
            lbl.BackColor = Color.FromArgb(241, 245, 249);

            txtName = new TextBox();
            txtName.BorderStyle = BorderStyle.None;
            txtName.PlaceholderText = "Enter your name";
            txtName.Font = new Font("Segoe UI", 10);
            txtName.Location = new Point(55, 12);
            txtName.Width = 420;
            txtName.ForeColor = Color.FromArgb(100, 116, 139);
            txtName.TextChanged += txtName_TextChanged;
            txtName.KeyDown += txtName_KeyDown;
            txtName.Leave += txtName_Leave;
            Namepanel.Controls.Add(lbl);
            Namepanel.Controls.Add(txtName);
            mainPanel.Controls.Add(Namepanel);
            y += step;
            Panel Userpanel = CreateInputPanel(y);
            Label lbl2 = new Label();
            lbl2.Text = "🆔";
            lbl2.Size = new Size(45, 45);
            lbl2.Location = new Point(0, 0);
            lbl2.TextAlign = ContentAlignment.MiddleCenter;
            lbl2.Font = new Font("Segoe UI Emoji", 11);
            lbl2.ForeColor = Color.FromArgb(100, 100, 100);
            lbl2.BackColor = Color.FromArgb(241, 245, 249);

            Usertxt = new TextBox();
            Usertxt.BorderStyle = BorderStyle.None;
            Usertxt.PlaceholderText = "Enter username";
            Usertxt.Font = new Font("Segoe UI", 10);
            Usertxt.Location = new Point(55, 12);
            Usertxt.Width = 420;
            Usertxt.ForeColor = Color.FromArgb(100, 116, 139);
            Usertxt.TextChanged += Usertxt_TextChanged;
            Usertxt.KeyDown += Usertxt_keyDown;
            Usertxt.Leave += Usertxt_Leave;
            Userpanel.Controls.Add(lbl2);
            Userpanel.Controls.Add(Usertxt);
            mainPanel.Controls.Add(Userpanel);
            y += step;



            // Email 

            Panel Emailpanel = CreateInputPanel(y);
            Label lbl3 = new Label();
            lbl3.Text = "📧";
            lbl3.Size = new Size(45, 45);
            lbl3.Location = new Point(0, 0);
            lbl3.TextAlign = ContentAlignment.MiddleCenter;
            lbl3.Font = new Font("Segoe UI Emoji", 11);
            lbl3.ForeColor = Color.FromArgb(100, 100, 100);
            lbl3.BackColor = Color.FromArgb(241, 245, 249);
            Emailtxt = new TextBox();

            Emailtxt.BorderStyle = BorderStyle.None;
            Emailtxt.PlaceholderText = "Enter email";
            Emailtxt.Font = new Font("Segoe UI", 10);
            Emailtxt.Location = new Point(55, 12);
            Emailtxt.Width = 420;
            Emailtxt.ForeColor = Color.FromArgb(100, 116, 139);

            Emailtxt.TextChanged += Emailtxt_TextChanged;
            Emailtxt.Leave += Emailtxt_Leave; Emailtxt.KeyDown += Emailtxt_KeyDown;
            Emailpanel.Controls.Add(lbl3);
            Emailpanel.Controls.Add(Emailtxt);
            mainPanel.Controls.Add(Emailpanel);
            y += step;
            // Address

            Panel Addresspanel = CreateInputPanel(y);
            Label lbl4 = new Label();
            lbl4.Text = "🆔";
            lbl4.Size = new Size(45, 45);
            lbl4.Location = new Point(0, 0);
            lbl4.TextAlign = ContentAlignment.MiddleCenter;
            lbl4.Font = new Font("Segoe UI Emoji", 11);
            lbl4.ForeColor = Color.FromArgb(100, 100, 100);
            lbl4.BackColor = Color.FromArgb(241, 245, 249);

            Addtxt = new TextBox();
            Addtxt.BorderStyle = BorderStyle.None;
            Addtxt.PlaceholderText = "Enter address";
            Addtxt.Font = new Font("Segoe UI", 10);
            Addtxt.Location = new Point(55, 12);
            Addtxt.Width = 420;
            Addtxt.ForeColor = Color.FromArgb(100, 116, 139);
  
            Addtxt.TextChanged += Addtxt_TextChanged;
            Addtxt.KeyDown += Addtxt_KeyDown;
            Addresspanel.Controls.Add(lbl4);
            Addresspanel.Controls.Add(Addtxt);
            mainPanel.Controls.Add(Addresspanel);
            y += step;

            // COUNTRY


            Panel pCountry = CreateInputPanel(y);
            pCountry.Size = new Size(520, 45);

            pCountry.BackColor = Color.White;
            pCountry.BorderStyle = BorderStyle.None;

            // ICON
            Label icon = new Label();
            icon.Text = "🌍";
            icon.Size = new Size(40, 45);
            icon.TextAlign = ContentAlignment.MiddleCenter;
            icon.Font = new Font("Segoe UI", 10);
            icon.ForeColor = Color.FromArgb(100, 100, 100);
            icon.BackColor = Color.FromArgb(240, 240, 240);
            icon.Location = new Point(0, 0);
            allcountry = new ComboBox();
            countryCode = new ComboBox();
            allcountry.Items.AddRange(new object[]
{
     "Select your Country","Afghanistan","Albania","Algeria",
    "Andorra","Angola","Argentina","Armenia","Australia","Austria","Azerbaijan","Bahrain","Bangladesh","Belgium","Brazil","Canada", "China","Denmark","Egypt","France","Germany","India","Indonesia","Iran","Iraq","Italy","Japan","Jordan","Lebanon","Libya","Malaysia","Mexico","Morocco","Netherlands",
    "New Zealand","Norway","Pakistan","Philippines","Portugal","Qatar","Russia","Saudi Arabia","South Africa","South Korea","Spain","Sweden","Switzerland","Syria","Thailand","Tunisia","Turkey","United Arab Emirates","United Kingdom","United States","Vietnam"
});
            allcountry.ForeColor = Color.FromArgb(100, 116, 139);
            allcountry.FlatStyle = FlatStyle.Flat;

            countryCode.ForeColor = Color.FromArgb(100, 116, 139);
            countryCode.FlatStyle = FlatStyle.Flat;

            allcountry.DropDownStyle = ComboBoxStyle.DropDownList;
            allcountry.Font = new Font("Segoe UI", 10);
            allcountry.Size = new Size(475, 45);
            allcountry.Location = new Point(45, 0);


            allcountry.SelectedIndex = 0;
            allcountry.ForeColor = Color.Gray;
         
            allcountry.SelectedIndexChanged += allcountry_SelectedIndexChanged;
            allcountry.KeyDown += allcountry_KeyDown;
            pCountry.Controls.Add(icon);
            allcountry.FlatStyle = FlatStyle.Flat;
            pCountry.Controls.Add(allcountry);
            mainPanel.Controls.Add(pCountry);
            y += step;

            // PHONE
            Panel phonePanel = new Panel();
            phonePanel.Size = new Size(520, 45);
            phonePanel.Location = new Point(40, y);
            phonePanel.BackColor = Color.White;
            phonePanel.BorderStyle = BorderStyle.None;

            countryCode.DropDownStyle = ComboBoxStyle.DropDownList;
            countryCode.FlatStyle = FlatStyle.Flat;
            countryCode.Font = new Font("Segoe UI", 10);
            countryCode.Size = new Size(90, 45);
            countryCode.Location = new Point(45, 0);

          
            countryCode.Items.AddRange(new object[]{"Code","+93","+355","+213","+376","+244","+54","+374","+61","+43","+994","+973","+880","+32","+55","+1","+86","+45","+20","+33", "+49","+91","+62","+98","+964","+39","+81",
"+962","+961","+218","+60","+52","+212","+31","+64","+47","+92","+63","+351","+974","+7","+966","+27","+82","+34","+46","+41","+963","+66","+216","+90","+971","+44","+1","+84" });
            countryCode.SelectedIndex = 0;
            phoneTxt = new TextBox();
            phoneTxt.BorderStyle = BorderStyle.None;
            phoneTxt.PlaceholderText = "Phone number";
            phoneTxt.Font = new Font("Segoe UI", 10);
            phoneTxt.Location = new Point(140, 12);
            phoneTxt.Width = 360;

            phoneTxt.TextChanged += phoneTxt_TextChanged;
            phoneTxt.KeyDown += phoneTxt_KeyDown;
            phoneTxt.Leave += phoneTxt_Leave;
            phonePanel.Controls.Add(countryCode);
            phonePanel.Controls.Add(phoneTxt);
            mainPanel.Controls.Add(phonePanel);
            y += step;

            // PASSWORDS
            Panel panel = new Panel();
            panel.Size = new Size(520, 45);
            panel.Location = new Point(40, y);
            panel.BackColor = Color.White;
            panel.BorderStyle = BorderStyle.None;

            Label lbl1 = new Label();
            lbl1.Text = "🔒";
            lbl1.Size = new Size(45, 45);
            lbl1.Location = new Point(0, 0);
            lbl1.TextAlign = ContentAlignment.MiddleCenter;
            lbl1.Font = new Font("Segoe UI Emoji", 11);
            lbl1.ForeColor = Color.FromArgb(100, 100, 100);
            lbl1.BackColor = Color.FromArgb(240, 240, 240);


            Passtxt = new TextBox();
            Passtxt.BorderStyle = BorderStyle.None;
            Passtxt.PlaceholderText = "Enter password";
            Passtxt.Font = new Font("Segoe UI", 10);
            Passtxt.Location = new Point(60, 12); 
            Passtxt.PasswordChar = '*';
            Passtxt.Width = 400;

            panel.Controls.Add(lbl1);
            panel.Controls.Add(Passtxt);

            pass = new Button();
            pass.Text = "👁";
            pass.Size = new Size(30, 30);
            pass.FlatStyle = FlatStyle.Flat;
        
            pass.FlatAppearance.BorderSize = 0;
            pass.Anchor = AnchorStyles.Right;// when the panel resizes, keep this control attached to this side
            pass.Location = new Point(480, 7);
            Passtxt.TextChanged += PassTxt_TextChanged;
            Passtxt.KeyDown += Passtxt_KeyDown;
            pass.Click += pass_Click;
            panel.Controls.Add(pass);
            mainPanel.Controls.Add(panel);
            y += step;

            //ConfirmPassword
            Panel Confirmpanel = new Panel();
            Confirmpanel.Size = new Size(520, 45);
            Confirmpanel.Location = new Point(40, y);
            Confirmpanel.BackColor = Color.White;
            Confirmpanel.BorderStyle = BorderStyle.None;

            Label Conlbl = new Label();
            Conlbl.Text = "🔐";
            Conlbl.Size = new Size(45, 45);
            Conlbl.Location = new Point(0, 0);
            Conlbl.TextAlign = ContentAlignment.MiddleCenter;
            Conlbl.Font = new Font("Segoe UI Emoji", 11);
            Conlbl.ForeColor = Color.FromArgb(100, 100, 100);
            Conlbl.BackColor = Color.FromArgb(240, 240, 240);
            Contxt = new TextBox();

            Contxt.BorderStyle = BorderStyle.None;
            Contxt.PlaceholderText = "Confirm password";
            Contxt.Font = new Font("Segoe UI", 10);
            Contxt.Location = new Point(60, 12);
            Contxt.PasswordChar = '*';
            Contxt.Width = 400;
            Contxt.TextChanged += Contxt_TextChanged;
            Confirmpanel.Controls.Add(Conlbl);
            Confirmpanel.Controls.Add(Contxt);


            Conpass = new Button();
            Conpass.Text = "👁";
            Conpass.Size = new Size(30, 30);
            Conpass.FlatStyle = FlatStyle.Flat;
            Conpass.FlatAppearance.BorderSize = 0;
            Conpass.Click += Conpass_Click;
            Conpass.Location = new Point(480, 7);
            Confirmpanel.Controls.Add(Conpass);
            mainPanel.Controls.Add(Confirmpanel);
            y += step;

            Panel BarPanel = new Panel();

            BarPanel.Size = new Size(520, 60);
            BarPanel.Location = new Point(40, y);
            BarPanel.BackColor = Color.White;
            BarPanel.BorderStyle = BorderStyle.None;
            lb = new Label();
            lb.Font = new Font("Segoe UI", 10);
            lb.ForeColor = Color.Black;
            lb.Location = new Point(10, 8);
            lb.AutoSize = true;





            bar1 = new ProgressBar();
            bar2 = new ProgressBar();
            bar3 = new ProgressBar();
            bar4 = new ProgressBar();
            bar1.Size = new Size(110, 3);
            bar2.Size = new Size(110, 3);
            bar3.Size = new Size(110, 3);
            bar4.Size = new Size(110, 3);

            bar1.Location = new Point(20, 40);
            bar2.Location = new Point(145, 40);
            bar3.Location = new Point(270, 40);
            bar4.Location = new Point(395, 40);
            bar1.BackColor = Color.FromArgb(37, 99, 235);
            bar2.BackColor = Color.FromArgb(37, 99, 235);
            bar3.BackColor = Color.FromArgb(37, 99, 235);
            bar4.BackColor = Color.FromArgb(226, 232, 240);
            BarPanel.Controls.Add(lb);
            BarPanel.Controls.Add(bar1);
            BarPanel.Controls.Add(bar2);
            BarPanel.Controls.Add(bar3);
            BarPanel.Controls.Add(bar4);

            mainPanel.Controls.Add(BarPanel);
            y += step;
            // BUTTON (BLUE THEME)
         
            btn.Text = "Create Account";
            btn.Size = new Size(320, 40);
            btn.Location = new Point(140, y);
            btn.BackColor = Color.FromArgb(37, 99, 235); // 🔵 BUTTON BLUE
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;
            btn.Click += btn_Click;
            countryCode.SelectedIndexChanged += countryCode_SelectedIndexChanged;
            mainPanel.Controls.Add(btn); Validate();

        }
    }
}
      
     