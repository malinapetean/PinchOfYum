using PinchOfYum.Controllers;
using PinchOfYum.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace View
{
    class PnlHeader:Panel
    {
        private Label labelName;
       
        private Button btnRecipes;
        private ControllerRecipe recipes;
        private ControllerUser users;

        private Button btnAdd;
        private Button btnLogOut;
        private Button btnSort;
        private Form1 form;

        public PnlHeader(Form1 form)
        {
            this.Parent = form;
            this.form = form;
            this.BackColor = Color.FromArgb(75, 194, 197);
            this.Dock = System.Windows.Forms.DockStyle.Top;
            this.Location = new Point(0, 0);
            this.Name = "PnlHeader";
            this.Size = new Size(this.Parent.Width, 70);
            recipes = new ControllerRecipe();
            users = new ControllerUser();
            labelName = new Label();
            labelName.AutoSize = true;
            labelName.FlatStyle = FlatStyle.Flat;
            labelName.ForeColor = SystemColors.Window;
            labelName.Location = new Point(12, 20);
            labelName.Name = "labelName";
            labelName.Size = new Size(147, 32);
            this.Controls.Add(this.labelName);


            if (this.form.User != null)
            {
                labelName.Font = new Font("Times New Roman", 18.2F, FontStyle.Bold, GraphicsUnit.Point);
                labelName.Text = "RECIPES";
                labelName.Click += new EventHandler(label_Click);

                this.btnRecipes = new Button();
                btnRecipes.AutoSize = true;
                btnRecipes.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
                btnRecipes.FlatStyle = FlatStyle.Flat;
                btnRecipes.ForeColor = Color.FromArgb(75, 194, 197);
                btnRecipes.Name = "btnRecipes";
                btnRecipes.Size = new Size(105, 29);
                btnRecipes.Location = new Point(1415, 20);
                btnRecipes.TabIndex = 0;
                btnRecipes.Text = "My Recipes";
                btnRecipes.BackColor = Color.White;
                this.Controls.Add(this.btnRecipes);
                btnRecipes.Click += new EventHandler(myrecipes_Click);

                this.btnAdd = new Button();
                btnAdd.AutoSize = true;
                btnAdd.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
                btnAdd.FlatStyle = FlatStyle.Flat;
                btnAdd.ForeColor = Color.FromArgb(75, 194, 197);
                btnAdd.Name = "btnAdd";
                btnAdd.Size = new Size(105, 29);
                btnAdd.Location = new Point(1530, 20);
                btnAdd.TabIndex = 0;
                btnAdd.Text = "Add new recipe";
                btnAdd.BackColor = Color.White;
                this.Controls.Add(this.btnAdd);
                btnAdd.Click += new EventHandler(btnAdd_Click);

                btnLogOut = new Button();
                btnLogOut.Location = new Point(1680,20);
                btnLogOut.Size = new Size(105, 29);
                btnLogOut.FlatStyle = FlatStyle.Flat;
                btnLogOut.Text = "Log out";
                btnLogOut.Font = new Font("Times New Roman", 12, FontStyle.Regular, GraphicsUnit.Point);
                btnLogOut.ForeColor = Color.FromArgb(75, 194, 197);
                btnLogOut.BackColor = Color.White;
                btnLogOut.AutoSize = true;
                this.Controls.Add(btnLogOut);
                btnLogOut.Click += new EventHandler(logOut_Click);

                btnSort = new Button();
                btnSort.Location = new Point(1785, 20);
                btnSort.Size = new Size(105, 29);
                btnSort.FlatStyle = FlatStyle.Flat;
                btnSort.Text = "Sort Recipes";
                btnSort.Font = new Font("Times New Roman", 12, FontStyle.Regular, GraphicsUnit.Point);
                btnSort.ForeColor = Color.FromArgb(75, 194, 197);
                btnSort.BackColor = Color.White;
                btnSort.AutoSize = true;
                this.Controls.Add(btnSort);
                btnSort.Click += new EventHandler(sort_Click);
            }
            else if(this.form.User == null)
            {

                labelName.Text = "Welcome to our site. Please login to continue";
                labelName.Font = new Font("High Tower Text", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            }


        }

        private void sort_Click(object sender, EventArgs e)
        {
            this.form.erasePanel("PnlMain");
            this.form.erasePanel("PnlDetails");
            this.form.flag = 1;
            this.form.Controls.Add(new PnlMain(recipes.sortList(),this.form,this.form.flag));
        }

        private void logOut_Click(object sender, EventArgs e)
        {
            var result= MessageBox.Show("are you sure you want to logout?", "Warning!", 
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if(result==DialogResult.Yes )
            {
                this.form.User = null;
                
                this.form.Controls.Add(new PnlSignIn(form));
                this.form.addHeader();
                this.form.erasePanel("PnlMain");
                this.form.erasePanel("PnlDetails");
                this.form.erasePanel("PnlAdd");

            }
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.form.erasePanel("PnlMain");
            this.form.erasePanel("PnlDetails");
            this.form.erasePanel("PnlAdd");
            this.form.Controls.Add(new PnlAddRecipe(this.form, this.form.user));
        }

        private void myrecipes_Click(object sender, EventArgs e)
        {
            this.form.erasePanel("PnlMain");
            this.form.erasePanel("PnlDetails");
            if(recipes.myRecipes(this.form.user.Id).Count==0)
            {
                this.form.flag = 0;
                this.form.Controls.Add(new PnlMain(this.recipes.myRecipes(this.form.user.Id), form, this.form.flag));
            }
            else
                this.form.Controls.Add(new PnlMain(this.recipes.myRecipes(this.form.user.Id), form,this.form.flag)); 
        }

        private void label_Click(object sender, EventArgs e)
        {
            this.form.erasePanel("PnlDetails");
            this.form.erasePanel("PnlAdd");
            this.form.erasePanel("PnlMain");
            recipes = new ControllerRecipe();
            this.form.flag = 1;
            this.form.Controls.Add(new PnlMain(this.recipes.List, form,this.form.flag));
        }
    }
}
