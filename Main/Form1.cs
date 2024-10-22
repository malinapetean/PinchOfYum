using PinchOfYum.Controllers;
using PinchOfYum.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class Form1 : Form
    {

        private ControllerRecipe recipes;
        public User user = null;
        public int flag = 1;
        public Form1()
        {
            InitializeComponent();
            this.recipes = new ControllerRecipe();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormBorderStyle= FormBorderStyle.None;
            this.user = null;

            this.Controls.Add(new PnlSignIn(this));
            this.Controls.Add(new PnlHeader(this));

        }
        public void erasePanel(String name)
        {
            Control find = null;

            foreach (Control aux in this.Controls)
            {
                if (aux.Name.Equals(name))
                {
                    find = aux;
                }
            }
            if (find != null)
                this.Controls.Remove(find);
        }

        public bool searchPanel(String panel)
        {
            Control p = null;
            foreach (Control control in this.Controls)
            {
                if (control.Name.Equals(panel))
                {
                    p = control;
                    return true;
                }
            }
            return false;
        }
        public User User
        {
            get => this.user;
            set => this.user = value;
        }

        private void recipes_Click(object sender, EventArgs e)
        {
            if (searchPanel("PnlMain"))
                erasePanel("PnlMain");
            if (searchPanel("PnlAdd"))
                erasePanel("PnlAdd");
            if (searchPanel("PnlUpdate"))
                erasePanel("PnlUpdate");
            flag = 1;
            this.Controls.Add(new PnlMain(this.recipes.List, this,flag));
        }
        public void addHeader()
        {
            this.erasePanel("PnlHeader");
            this.Controls.Add(new PnlHeader(this));
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
