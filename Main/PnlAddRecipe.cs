using PinchOfYum.Controllers;
using PinchOfYum.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace View
{
    class PnlAddRecipe : Panel
    {
        private Label createRecipe;
        private Label name;
        private Label id;
        private Label category;
        private Label ingredients;
        private Label instructions;
        private Label creator;
        private TextBox txtId;
        private TextBox txtName;
        private TextBox txtIngredients;
        private TextBox txtInstructions;
        private TextBox txtCategory;
        private TextBox txtCreator;
        private Button btnCreate;
        private Button btnCancel;
        private Button btnImage;
        private PictureBox picture;
        private Recipe recipe;
        private ControllerRecipe recipes;
        private Form1 form;
        private int flag = 0;
        private Image IMG;
        private User user;

        public PnlAddRecipe(Form1 form, User user)
        {
            this.form = form;
            base.Parent = form;
            this.recipes = new ControllerRecipe();
            this.recipe = new Recipe();
            this.user = user;
            this.recipe.ID = recipes.List.Count+1;
            this.Size = this.Parent.Size;
            this.Location = new Point(0, 70);
            this.Name = "PnlAdd";
            this.BackColor = Color.FromArgb(75, 194, 197);
            this.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left;
            this.Dock = DockStyle.Fill;

            createRecipe = new Label();
            createRecipe.Location = new Point(225, 140);
            createRecipe.Width = 187;
            createRecipe.Height = 35;
            createRecipe.Text = "Create recipe";
            Font font = new Font("Times New Roman", 18, FontStyle.Bold);
            createRecipe.ForeColor = Color.White;
            createRecipe.Font = font;
            this.Controls.Add(createRecipe);

            id = new Label();
            id.Location = new Point(200, 195);
            id.Width = 91;
            id.Height = 22;
            id.Text = "Recipe Id";
            Font labels = new Font("Times New Roman", 12);
            id.Font = labels;
            this.Controls.Add(id);

            txtId = new TextBox();
            txtId.Location = new Point(200, 220);
            txtId.Width = 285;
            txtId.Height = 25;
            this.Controls.Add(txtId);
            txtId.Text = (recipes.List.Count+1).ToString();
            txtId.Enabled = false;

            name = new Label();
            name.Location = new Point(200, 245);
            name.Width = 120;
            name.Height = 22;
            name.Text = "Recipe Name";
            name.Font = labels;
            this.Controls.Add(name);

            txtName = new TextBox();
            txtName.Location = new Point(200, 270);
            txtName.Width = 285;
            txtName.Height = 25;
            this.Controls.Add(txtName);

            category = new Label();
            category.Location = new Point(200, 300);
            category.Width = 170;
            category.Height = 22;
            category.Text = "Recipe category";
            category.Font = labels;
            this.Controls.Add(category);

            txtCategory = new TextBox();
            txtCategory.Location = new Point(200, 330);
            txtCategory.Width = 285;
            txtCategory.Height = 25;
            this.Controls.Add(txtCategory);

            ingredients = new Label();
            ingredients.Location = new Point(200, 360);
            ingredients.Width = 103;
            ingredients.Height = 25;
            ingredients.Text = "Ingredients";
            ingredients.Font = labels;
            this.Controls.Add(ingredients);

            txtIngredients = new TextBox();
            txtIngredients.Location = new Point(200, 385);
            txtIngredients.Width = 400;
            txtIngredients.Height = 200;
            txtIngredients.Multiline = true;
            txtIngredients.ScrollBars = ScrollBars.Both;
            this.Controls.Add(txtIngredients);

            instructions = new Label();
            instructions.Location = new Point(200, 590);
            instructions.Size = new Size(103, 25);
            instructions.Text = "Instructions";
            instructions.Font = labels;
            this.Controls.Add(instructions);

            txtInstructions = new TextBox();
            txtInstructions.Location = new Point(200, 620);
            txtInstructions.Size = new Size(400, 200);
            txtInstructions.ScrollBars = ScrollBars.Both;
            txtInstructions.Multiline = true;
            this.Controls.Add(txtInstructions);

            creator = new Label();
            creator.Location = new Point(200, 825);
            creator.Size = new Size(103, 25);
            creator.Text = "Creator";
            creator.Font = labels;
            this.Controls.Add(creator);

            txtCreator = new TextBox();
            txtCreator.Location = new Point(200, 855);
            txtCreator.Size = new Size(285, 25);
            txtCreator.Text = user.First_Name + " " + user.Last_Name;
            this.Controls.Add(txtCreator);

            btnCreate = new Button();
            btnCreate.Location = new System.Drawing.Point(240, 900);
            btnCreate.Width = 95;
            btnCreate.Height = 38;
            btnCreate.Text = "Create";
            btnCreate.Font = new Font("Times New Roman", 12, FontStyle.Bold);
            btnCreate.BackColor = Color.White;
            btnCreate.ForeColor = Color.FromArgb(75, 194, 197);
            btnCreate.FlatStyle = FlatStyle.Flat;
            this.Controls.Add(btnCreate);
            this.btnCreate.Click += new EventHandler(btnCreate_Click);

            btnCancel = new Button();
            btnCancel.Location = new Point(355, 900);
            btnCancel.Width = 95;
            btnCancel.Height = 38;
            btnCancel.Text = "Cancel";
            btnCancel.Font = new Font("Times New Roman", 12, FontStyle.Regular);
            btnCancel.BackColor = Color.White;
            btnCancel.ForeColor = Color.FromArgb(75, 194, 197);
            btnCancel.FlatStyle = FlatStyle.Flat;
            this.Controls.Add(btnCancel);
            this.btnCancel.Click += new EventHandler(cancel_Click);

            btnImage = new Button();
            btnImage.Location = new Point(700,900);
            btnImage.Size = new Size(210, 38);
            btnImage.Text = "Upload Image";
            btnImage.Font = new Font("Times New Roman", 12, FontStyle.Regular);
            btnImage.BackColor = Color.White;
            btnImage.ForeColor = Color.FromArgb(75, 194, 197);
            btnImage.FlatStyle = FlatStyle.Flat;
            this.Controls.Add(btnImage);
            this.btnImage.Click += new EventHandler(image_Click);

            picture = new PictureBox();
            picture.Location = new Point(700, 150);
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            picture.Size = new Size(730, 730);
            this.Controls.Add(picture);
        }

        private void image_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog()==DialogResult.OK)
            {
                Image img = Image.FromFile(ofd.FileName);
                this.recipe.Picture = this.ImageToByteArray(img);
                flag = 1;
                IMG = img;
                picture.Image = img;
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.form.erasePanel("PnlAdd");
            this.form.flag = 1;
            this.form.Controls.Add(new PnlMain(recipes.List, form,this.form.flag));
        }
        private Image setImage(byte[] img)
        {
            MemoryStream stream = new MemoryStream(img);
            Image imgn = Image.FromStream(stream);
            return imgn;
        }
        public byte[] ImageToByteArray(Image imageIn)
        {
            var ms = new MemoryStream();
            imageIn.Save(ms, imageIn.RawFormat);
            return ms.ToArray();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {

            if (!(txtName.Text.Equals("") || txtCreator.Text.Equals("") || txtIngredients.Text.Equals("")
                || txtInstructions.Text.Equals("") || txtCategory.Text.Equals(""))&& flag==1)
            {
                this.recipe.Name = txtName.Text;
                this.recipe.Category = txtCategory.Text;
                this.recipe.Ingredients = txtIngredients.Text;
                this.recipe.Instructions = txtInstructions.Text;
                this.recipe.CreatorID = user.Id;

                int ok = 0;
                foreach (Recipe r in recipes.myRecipes(user.Id))
                {
                    if (r.Name.Equals(recipe.Name))
                    {
                        MessageBox.Show("You already have a recipe with this name");
                        ok = 1;
                    }
                }
                if (ok == 0)
                {
                    this.recipes.addRecipe(txtName.Text,txtCategory.Text,txtIngredients.Text,txtInstructions.Text,
                        this.user.Id,this.ImageToByteArray(IMG));
                    MessageBox.Show("Recipe added succesfully");
                }
                this.form.flag = 1;
                this.form.Controls.Add(new PnlMain(this.recipes.List, form,this.form.flag));
                this.form.Controls.Remove(this);
            }
            else
            {
                MessageBox.Show("Complete all text boxes!");
            }
        }
    
    }
}
