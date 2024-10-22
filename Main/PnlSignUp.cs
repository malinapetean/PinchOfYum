using PinchOfYum.Controllers;
using PinchOfYum.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace View
{
    class PnlSignUp:Panel
    {
        private Label signUp;
        private Label firstname;
        private Label lastname;
        private Label email;
        private Label password;
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private PictureBox picture;
        private Button btnSignUp;
        private Button btnCancel;
        private Form1 form;
        private ControllerUser controlUser;
        private ControllerRecipe controlRecipe;

        public PnlSignUp(Form1 form)
        {
            controlUser = new ControllerUser();
            controlRecipe = new ControllerRecipe();
          
            this.form = form;
            this.Parent = form;
            this.Size = new Size(this.Parent.Width, this.Parent.Height);
            this.BackColor = Color.Transparent;
            this.Location = new Point(0, 70);
            this.Name = "PnlSignUp";
            this.Dock = DockStyle.Fill;
            this.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left;

            Font font = new Font("Times New Roman", 28, FontStyle.Bold);
            this.signUp = new Label();
            this.signUp.Location = new Point(573, 130);
            this.signUp.Size = new Size(190, 55);
            this.signUp.ForeColor = Color.FromArgb(75, 194, 197);
            this.signUp.Font = font;
            this.signUp.Text = "Sign Up";
            this.signUp.BackColor = Color.Transparent;
            this.Controls.Add(signUp);

            Font labels = new Font("Times New Roman", 14, FontStyle.Regular);
            this.firstname = new Label();
            this.firstname.Location = new Point(433, 240);
            this.firstname.Size = new Size(130, 26);
            this.firstname.ForeColor = Color.Black;
            this.firstname.Font = labels;
            this.firstname.Text = "First Name";
            this.firstname.BackColor = Color.Transparent;
            this.Controls.Add(firstname);

            this.txtFirstName = new TextBox();
            this.txtFirstName.Location = new Point(433, 269);
            this.txtFirstName.Size = new Size(431, 34);
            this.txtFirstName.BackColor = Color.White;
            this.txtFirstName.ForeColor = Color.Black;
            this.Controls.Add(txtFirstName);

            this.lastname = new Label();
            this.lastname.Location = new Point(433, 326);
            this.lastname.Size = new Size(130, 26);
            this.lastname.ForeColor = Color.Black;
            this.lastname.Font = labels;
            this.lastname.Text = "Last Name";
            this.lastname.BackColor = Color.Transparent;
            this.Controls.Add(lastname);

            this.txtLastName = new TextBox();
            this.txtLastName.Location = new Point(433, 355);
            this.txtLastName.Size = new Size(431, 34);
            this.txtLastName.BackColor = Color.White;
            this.txtLastName.ForeColor = Color.Black;
            this.Controls.Add(txtLastName);

            this.email = new Label();
            this.email.Location = new Point(433, 412);
            this.email.Size = new Size(109, 26);
            this.email.ForeColor = Color.Black;
            this.email.Font = labels;
            this.email.Text = "Email";
            this.email.BackColor = Color.Transparent;
            this.Controls.Add(email);

            this.txtEmail = new TextBox();
            this.txtEmail.Location = new Point(433, 441);
            this.txtEmail.Size = new Size(431, 34);
            this.txtEmail.BackColor = Color.White;
            this.txtEmail.ForeColor = Color.Black;
            this.Controls.Add(txtEmail);

            this.password = new Label();
            this.password.Location = new Point(433, 498);
            this.password.Size = new Size(109, 26);
            this.password.ForeColor = Color.Black;
            this.password.Font = labels;
            this.password.Text = "Password";
            this.password.BackColor = Color.Transparent;
            this.Controls.Add(password);

            this.txtPassword = new TextBox();
            this.txtPassword.Location = new Point(433, 527);
            this.txtPassword.Size = new Size(431, 34);
            this.txtPassword.BackColor = Color.White;
            this.txtPassword.ForeColor = Color.Black;
            this.txtPassword.PasswordChar= '●';
            this.Controls.Add(txtPassword);

            picture = new PictureBox();
            picture.Location = new Point(900, 0);
            picture.SizeMode = PictureBoxSizeMode.Zoom;
            picture.Size = new Size(900, 900);
            picture.Image = Image.FromFile(Application.StartupPath + @"/imagini/" + "Logo Png Teal.png");
            this.Controls.Add(picture);

            this.btnSignUp = new Button();
            this.btnSignUp.Location = new Point(545, 590);
            this.btnSignUp.Size = new Size(115, 35);
            this.btnSignUp.FlatStyle = FlatStyle.Popup;
            this.btnSignUp.Text = "Sign Up";
            this.btnSignUp.Font = new Font("Times New Roman", 14, FontStyle.Bold);
            this.btnSignUp.ForeColor = Color.FromArgb(75, 194, 197);
            this.btnSignUp.BackColor = Color.Transparent;
            this.Controls.Add(btnSignUp);
            this.btnSignUp.Click += new EventHandler(signUp_Click);

            this.btnCancel = new Button();
            this.btnCancel.Location = new Point(675, 590);
            this.btnCancel.Size = new Size(115, 35);
            this.btnCancel.FlatStyle = FlatStyle.Popup;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Font = new Font("Times New Roman", 14, FontStyle.Regular);
            this.btnCancel.ForeColor = Color.Transparent;
            this.btnCancel.BackColor = Color.FromArgb(75, 194, 197);
            this.Controls.Add(btnCancel);
            this.btnCancel.Click += new EventHandler(cancel_Click);



        }


        private void cancel_Click(object sender, EventArgs e)
        {
            this.form.Controls.Add(new PnlSignIn(form));
            this.form.Controls.Remove(this);
        }

        private void signUp_Click(object sender, EventArgs e)
        {
            if (!(txtEmail.Text.Equals("") || txtFirstName.Text.Equals("") || txtLastName.Text.Equals("") || txtPassword.Text.Equals("")))
            {
                controlUser.addUser(txtFirstName.Text,txtLastName.Text,txtEmail.Text,txtPassword.Text);
                this.form.Controls.Add(new PnlSignIn(form));
                this.form.Controls.Remove(this);
            }
            else
            {
                MessageBox.Show("Complete all Boxes");
            }
        }

    }
}
