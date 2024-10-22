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
    class PnlDetails:Panel
    {
        
        private Label recipe;
        private Label recipeName;
        private Label ingredients;
        private Label instructions;
        private Label category;
        private Label categoryName;
        private Label creator;
        private TextBox txtIngredients;
        private TextBox txtInstructions;
        private Button btnReturn;
        private PictureBox picture;
        private ControllerRecipe recipes;
        private ControllerUser users;
        private Form1 form;


        public PnlDetails(User user, Form1 form, Recipe r)
        {
            recipes = new ControllerRecipe();
            users = new ControllerUser();
            this.form = form;
            base.Parent = form;
            this.Location = new Point(0, 70);
            this.BackColor = Color.FromArgb(244, 240, 230);
            this.Name = "PnlDetails";
            this.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.Dock = DockStyle.Fill;

            Font font = new Font("Times New Roman", 14, FontStyle.Bold);
            Font labels = new Font("Times New Roman", 12);

            recipe = new Label();
            recipe.Font = labels;
            recipe.Location = new Point(68, 126);
            recipe.Size = new Size(77, 22);
            recipe.Text = "Recipe:";
            recipe.ForeColor = Color.FromArgb(75, 194, 197);
            recipe.BackColor = Color.Transparent;
            this.Controls.Add(recipe);

            recipeName = new Label();
            FontStyle fontStyle = FontStyle.Italic;
            fontStyle |= FontStyle.Bold;
            recipeName.Font = new Font("Times New Roman", 18, fontStyle);
            recipeName.Location = new Point(140, 115);
            recipeName.Size = new Size(360, 41);
            recipeName.Text = r.Name.ToString();
            recipeName.ForeColor = Color.FromArgb(75, 194, 197);
            recipeName.BackColor = Color.Transparent;
            this.Controls.Add(recipeName);

            creator = new Label();
            creator.Font = new Font("Times New Roman", 9);
            creator.Location = new Point(68, 155);
            creator.Size = new Size(131, 17);
            creator.Text = "By " + users.getUserById(r.CreatorID).Last_Name.ToString()+ " "+ users.getUserById(r.CreatorID).First_Name.ToString();
            creator.ForeColor = Color.FromArgb(75, 194, 197);
            this.Controls.Add(creator);

            category = new Label();
            category.Font = labels;
            category.Location = new Point(68, 189);
            category.Size = new Size(90, 22);
            category.Text = "Category:";
            category.ForeColor = Color.FromArgb(75, 194, 197);
            this.Controls.Add(category);

            categoryName = new Label();
            FontStyle fonts = FontStyle.Italic;
            fonts |= FontStyle.Bold;
            categoryName.Font = new Font("Times New Roman", 14, fonts);
            categoryName.Location = new Point(161,183);
            categoryName.Size = new Size(180, 23);
            categoryName.Text = r.Category.ToString();
            categoryName.ForeColor = Color.FromArgb(75, 194, 197);
            this.Controls.Add(categoryName);

            ingredients = new Label();
            ingredients.Font = labels;
            ingredients.Location = new Point(68, 244);
            ingredients.Size = new Size(109, 22);
            ingredients.Text = "Ingredients:";
            ingredients.ForeColor = Color.FromArgb(75, 194, 197);
            this.Controls.Add(ingredients);

            txtIngredients = new TextBox();
            txtIngredients.Location = new Point(68, 269);
            txtIngredients.Size = new Size(300, 190);
            txtIngredients.Text = r.Ingredients.ToString();
            txtIngredients.ForeColor = Color.FromArgb(59, 154, 156);
            txtIngredients.BackColor = Color.FromArgb(244, 240, 230);
            txtIngredients.Multiline = true;
            txtIngredients.ScrollBars = ScrollBars.Both;
            txtIngredients.ReadOnly = true;
            this.Controls.Add(txtIngredients);


            instructions = new Label();
            instructions.Font = labels;
            instructions.Location = new Point(68, 495);
            instructions.Size = new Size(109, 22);
            instructions.Text = "Instructions:";
            instructions.ForeColor = Color.FromArgb(75, 194, 197);
            this.Controls.Add(instructions);

            txtInstructions = new TextBox();
            txtInstructions.Location = new Point(68, 520);
            txtInstructions.Size = new Size(300, 190);
            txtInstructions.Text = r.Instructions.ToString();
            txtInstructions.ForeColor = Color.FromArgb(59, 154, 156);
            txtInstructions.BackColor = Color.FromArgb(244, 240, 230);
            txtInstructions.Multiline = true;
            txtInstructions.ScrollBars = ScrollBars.Both;
            txtInstructions.ReadOnly = true;
            this.Controls.Add(txtInstructions);

            picture = new PictureBox();
            picture.Location = new Point(426, 183);
            picture.SizeMode = PictureBoxSizeMode.Zoom;
            picture.Size = new Size(700,700);
            picture.Image = setImage(r.Picture);
            this.Controls.Add(picture);

            btnReturn = new Button();
            btnReturn.Location = new Point(68, 730);
            btnReturn.Size = new Size(163, 40);
            btnReturn.FlatStyle = FlatStyle.Flat;
            btnReturn.Text = "Return to list";
            btnReturn.Font = new Font("Times New Roman", 14);
            btnReturn.ForeColor = Color.White;
            btnReturn.BackColor = Color.FromArgb(75, 194, 197);
            this.Controls.Add(btnReturn);
            btnReturn.Click += new EventHandler(return_Click);
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
        private void return_Click(object sender, EventArgs e)
        {
            this.form.flag = 1;
            this.form.Controls.Add(new PnlMain(this.recipes.List, form,this.form.flag));
            
            this.form.Controls.Remove(this);
        }
    }
}
