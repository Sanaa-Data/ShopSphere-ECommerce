namespace Ray_Sanaa_Final_Project
{
    partial class mainForm
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
            panel1 = new Panel();
            buttonProduct = new Button();
            buttonCart = new Button();
            buttonLogout = new Button();
            label1 = new Label();
            panelTop = new Panel();
            GreetingsLabel = new Label();
            flowProducts = new FlowLayoutPanel();
            panel1.SuspendLayout();
            panelTop.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(11, 31, 92);
            panel1.Controls.Add(buttonProduct);
            panel1.Controls.Add(buttonCart);
            panel1.Controls.Add(buttonLogout);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(188, 693);
            panel1.TabIndex = 0;
            // 
            // buttonProduct
            // 
            buttonProduct.FlatAppearance.BorderSize = 0;
            buttonProduct.FlatStyle = FlatStyle.Flat;
            buttonProduct.Font = new Font("Segoe UI", 12F);
            buttonProduct.ForeColor = Color.White;
            buttonProduct.Location = new Point(16, 112);
            buttonProduct.Margin = new Padding(2);
            buttonProduct.Name = "buttonProduct";
            buttonProduct.Size = new Size(160, 36);
            buttonProduct.TabIndex = 5;
            buttonProduct.Text = "Products";
            buttonProduct.UseVisualStyleBackColor = true;
            // 
            // buttonCart
            // 
            buttonCart.FlatAppearance.BorderSize = 0;
            buttonCart.FlatStyle = FlatStyle.Flat;
            buttonCart.Font = new Font("Segoe UI", 12F);
            buttonCart.ForeColor = Color.White;
            buttonCart.Location = new Point(16, 153);
            buttonCart.Margin = new Padding(2);
            buttonCart.Name = "buttonCart";
            buttonCart.Size = new Size(160, 36);
            buttonCart.TabIndex = 4;
            buttonCart.Text = "Cart";
            buttonCart.UseVisualStyleBackColor = true;
            buttonCart.Click += button4_Click;
            // 
            // buttonLogout
            // 
            buttonLogout.FlatAppearance.BorderSize = 0;
            buttonLogout.FlatStyle = FlatStyle.Flat;
            buttonLogout.Font = new Font("Segoe UI", 12F);
            buttonLogout.ForeColor = Color.White;
            buttonLogout.Location = new Point(16, 193);
            buttonLogout.Margin = new Padding(2);
            buttonLogout.Name = "buttonLogout";
            buttonLogout.Size = new Size(160, 50);
            buttonLogout.TabIndex = 2;
            buttonLogout.Text = "Logout";
            buttonLogout.UseVisualStyleBackColor = true;
            buttonLogout.Click += buttonLogout_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(2, 7);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(188, 41);
            label1.TabIndex = 0;
            label1.Text = "ShopSphere";
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.White;
            panelTop.Controls.Add(GreetingsLabel);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(188, 0);
            panelTop.Margin = new Padding(2);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(944, 56);
            panelTop.TabIndex = 1;
            // 
            // GreetingsLabel
            // 
            GreetingsLabel.AutoSize = true;
            GreetingsLabel.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            GreetingsLabel.Location = new Point(5, 10);
            GreetingsLabel.Name = "GreetingsLabel";
            GreetingsLabel.Size = new Size(146, 38);
            GreetingsLabel.TabIndex = 0;
            GreetingsLabel.Text = "Welcome,";
            // 
            // flowProducts
            // 
            flowProducts.AutoScroll = true;
            flowProducts.Dock = DockStyle.Fill;
            flowProducts.Location = new Point(188, 56);
            flowProducts.Margin = new Padding(2);
            flowProducts.Name = "flowProducts";
            flowProducts.Size = new Size(944, 637);
            flowProducts.TabIndex = 2;
            flowProducts.Paint += flowProducts_Paint;
            // 
            // mainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1132, 693);
            Controls.Add(flowProducts);
            Controls.Add(panelTop);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2);
            Name = "mainForm";
            Text = "mainForm";
            WindowState = FormWindowState.Maximized;
            Load += mainForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button buttonProduct;
        private Button buttonCart;
        private Button buttonLogout;
        private Label label1;
        private Panel panelTop;
        private FlowLayoutPanel flowProducts;
        private Label GreetingsLabel;
    }
}