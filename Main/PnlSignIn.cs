using PinchOfYum.Controllers;
using PinchOfYum.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace View
{
    class PnlSignIn:Panel
    {
        private Label signIn;
        private Label email;
        private Label password;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private Button btnSignIn;
        private Button btnRegister;
        private PictureBox picture;
        private ControllerRecipe ctrlrecipes;
        private ControllerUser ctrlusers;
        private Form1 form;

        public PnlSignIn(Form1 form)
        {
            this.form = form;
            this.Parent = form;
            this.ctrlrecipes = new ControllerRecipe();
            this.ctrlusers = new ControllerUser();
            this.Size = new Size(this.Parent.Width,this.Parent.Height);
            this.Location = new Point(0, 70);
            this.Name = "PnlSignIn";
            this.BackColor = Color.Transparent;
            this.Dock = DockStyle.Fill;
            this.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left;

            Font font = new Font("Times New Roman", 28, FontStyle.Bold);
            this.signIn = new Label();
            this.signIn.Location = new Point(573, 130);
            this.signIn.Size = new Size(180, 55);
            this.signIn.ForeColor = Color.FromArgb(75, 194, 197);
            this.signIn.Font = font;
            this.signIn.Text = "Sign In";
            this.signIn.BackColor = Color.Transparent;
            this.Controls.Add(signIn);
           
            Font labels = new Font("Times New Roman", 14, FontStyle.Regular);
            this.email = new Label();
            this.email.Location = new Point(433, 240);
            this.email.Size = new Size(109, 26);
            this.email.ForeColor = Color.Black;
            this.email.Font = labels;
            this.email.Text = "Email";
            this.email.BackColor = Color.Transparent;
            this.Controls.Add(email);

            this.txtEmail = new TextBox();
            this.txtEmail.Location = new Point(433, 269);
            this.txtEmail.Size = new Size(431, 34);
            this.txtEmail.BackColor = Color.White;
            this.txtEmail.ForeColor = Color.Black;
            this.Controls.Add(txtEmail);

            this.password = new Label();
            this.password.Location = new Point(433, 326);
            this.password.Size = new Size(109, 26);
            this.password.ForeColor = Color.Black;
            this.password.Font = labels;
            this.password.Text = "Password";
            this.password.BackColor = Color.Transparent;
            this.Controls.Add(password);

            this.txtPassword = new TextBox();
            this.txtPassword.Location = new Point(433, 355);
            this.txtPassword.Size = new Size(431, 34);
            this.txtPassword.BackColor = Color.White;
            this.txtPassword.ForeColor = Color.Black;
            this.txtPassword.PasswordChar = '●';
            this.Controls.Add(txtPassword);

            picture = new PictureBox();
            picture.Location = new Point(900, 0);
            picture.SizeMode = PictureBoxSizeMode.Zoom;
            picture.Size = new Size(900,900);
            picture.Image = Image.FromFile(Application.StartupPath + @"/imagini/" +  "Logo Png Teal.png");
            this.Controls.Add(picture);
            

            btnSignIn = new Button();
            btnSignIn.Location = new System.Drawing.Point(544, 418);
            btnSignIn.Width = 95;
            btnSignIn.Height = 35;
            btnSignIn.Text = "Sign In";
            btnSignIn.Font = new Font("Times New Roman", 12, FontStyle.Bold);
            btnSignIn.BackColor = Color.FromArgb(75, 194, 197);
            btnSignIn.ForeColor = Color.Transparent;
            btnSignIn.FlatStyle = FlatStyle.Popup;
            this.Controls.Add(btnSignIn);
            this.btnSignIn.Click += new EventHandler(btnSignIn_Click);

            this.btnRegister = new Button();
            this.btnRegister.Location = new Point(675, 418);
            this.btnRegister.Size = new Size(115, 35);
            this.btnRegister.FlatStyle = FlatStyle.Popup;
            this.btnRegister.Text = "Register";
            this.btnRegister.Font = new Font("Times New Roman", 14, FontStyle.Regular);
            this.btnRegister.ForeColor = Color.FromArgb(75, 194, 197);
            this.btnRegister.BackColor = Color.Transparent;
            this.Controls.Add(btnRegister);
            this.btnRegister.Click += new EventHandler(register_Click);
        }

        private void register_Click(object sender, EventArgs e)
        {
            this.form.Controls.Add(new PnlSignUp(form));
            this.form.Controls.Remove(this);
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            User user = ctrlusers.getUser(txtPassword.Text, txtEmail.Text);
            if(user.Id == -1)
            {
                MessageBox.Show("Email/Password was incorect!");
            }
            else
            {
                this.form.user = user;
                this.form.addHeader();
                this.form.flag = 1;
                this.form.Controls.Add(new PnlMain(ctrlrecipes.List, form,this.form.flag));
                this.form.Controls.Remove(this);
            }
        }

    }
}
