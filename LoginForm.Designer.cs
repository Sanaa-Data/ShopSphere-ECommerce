namespace Ray_Sanaa_Final_Project
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelRight = new Panel();
            SuspendLayout();
            // 
            // panelRight
            // 
            panelRight.BackColor = Color.WhiteSmoke;
            panelRight.BorderStyle = BorderStyle.FixedSingle;
            panelRight.Dock = DockStyle.Fill;
            panelRight.ForeColor = Color.DimGray;
            panelRight.Location = new Point(0, 0);
            panelRight.Name = "panelRight";
            panelRight.Size = new Size(1102, 675);
            panelRight.TabIndex = 1;
            panelRight.Paint += panelRight_Paint;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1102, 675);
            Controls.Add(panelRight);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginForm";
            ResumeLayout(false);
        }

        #endregion
        private Panel panelRight;
    }
}
