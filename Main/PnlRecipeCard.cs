using Main;
using PinchOfYum.Controllers;
using PinchOfYum.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace View
{
    class PnlRecipeCard:Panel
    {
        private Recipe recipe;
        private ControllerRecipe control;
        private Label name;
        private Label category;
        private User user;

        private Form1 form;

        public PnlRecipeCard(Recipe recipe,Form1 form)
        {
            control = new ControllerRecipe();
            user = form.user;
            this.recipe= recipe;
            this.form = form;
            this.Name = "PnlRecipeCard";
            this.Size = new Size(230, 96);
            this.BackColor = Color.FromArgb(75, 194, 197);

            name = new Label();
            name.Location = new Point(13, 50);
            name.Font = new Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            name.Height = 65;
            name.Width = 150;
            name.Text = recipe.Name;
            name.ForeColor = Color.Black;
            this.Controls.Add(name);

            category = new Label();
            category.Location = new Point(13, 10);
            category.Font = new Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            category.Height = 50;
            category.Width = 100;
            category.Text = recipe.Category;
            category.ForeColor = Color.Black;
            this.Controls.Add(category);

            this.Click += new EventHandler(card_Click);
        }

        private void card_Click(object sender, EventArgs e)
        {
            this.form.erasePanel("PnlMain");
            this.form.Controls.Add(new PnlDetails(user, form, control.getRecipeById(recipe.ID)));
        }
    }
}
