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
    class PnlMain:Panel
    {
        private List<Recipe> recipes;
        private List<PnlRecipeCard> cards;
        private ControllerRecipe control;
        private Form1 form;
        private Label noRecipes;
        private int flag;
        
        public PnlMain(List<Recipe> recipes,Form1 form,int flag)
        {
            this.control = new ControllerRecipe();
            this.cards = new List<PnlRecipeCard>();
            this.form = form;
            this.flag = flag;
            this.recipes = recipes;
            base.Parent = form;
            this.Size = new Size(650, 385);
            this.Location = new Point(0, 70);
            this.BackColor = Color.FromArgb(206, 239, 228);
            this.Name = "PnlMain";
            this.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.Dock = DockStyle.Fill;

            createCards(this.Parent.Width / 300);
            this.Resize += new EventHandler(main_Resize);

            this.BorderStyle = BorderStyle.FixedSingle;
        }
        private void main_Resize(object sender, EventArgs e)
        {

            if (this.Width < 460 + 150)
            {

                createCards(1);
            }
            else if (this.Width < 740 + 150)
            {

                createCards(2);
            }
            else if (this.Width < 1020 + 150)
            {

                createCards(3);
            }
            else if (this.Width < 1300 + 150)
            {

                createCards(4);
            }
            else if (this.Width < 1580 + 150)
            {
                createCards(5);
            }
            else
            {
                createCards(6);
            }
        }

        public void createCards(int nrcollums)
        {
            this.Controls.Clear();
            this.Location = new Point(0, 70);
            if(flag==0)
            {
                noRecipes = new Label();
                noRecipes.Location = new Point(this.Width/2-400, this.Height/2-50);
                noRecipes.Size = new Size(500, 100);
                noRecipes.AutoSize = true;
                noRecipes.FlatStyle = FlatStyle.Flat;
                noRecipes.ForeColor = Color.FromArgb(75, 194, 197);
                noRecipes.Font = new Font("Times New Roman", 48F, FontStyle.Bold, GraphicsUnit.Point);
                noRecipes.Text = "Start cooking something";
                this.Controls.Add(noRecipes);
            }
            else
            {
                int x = 60, y = 100, ct = 0;
                foreach (Recipe r in recipes)
                {
                    ct++;
                    PnlRecipeCard pnlrecipe = new PnlRecipeCard(r, form);
                    pnlrecipe.Location = new Point(x, y);
                    this.Controls.Add(pnlrecipe);
                    this.cards.Add(pnlrecipe);

                    x += 280;
                    if (ct % nrcollums == 0)
                    {
                        x = 60;
                        y += 140;
                    }
                    if (y > this.Height)
                    {
                        this.AutoScroll = true;
                    }
                }
            }
           

        }
        

    }
}
