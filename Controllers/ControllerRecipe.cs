using PinchOfYum.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace PinchOfYum.Controllers
{
    public class ControllerRecipe : Controller<Recipe>
    {
       
        public ControllerRecipe()
        {
            getAll();
        }
        protected override void getAll()
        {
            string text = "select * from recipes";
            list = db.LoadData<Recipe, dynamic>(text, new { }, connection);
        }

        public override void printAll()
        {
            string text = "";
            foreach (Recipe r in list)
            {
                text += r.description() + "\n";
            }
            Console.WriteLine(text);
        }
        public void addRecipe(string name, string category, string ingredients, string instructions, int creatorID, byte[] picture)
        {
            string text = "insert into recipes(name,category,ingredients,instructions,creatorId,picture) value" +
                "(@name,@category,@ingredients,@instructions,@creatorID,@picture)";
            db.SaveData(text, new { name, category, ingredients, instructions, creatorID, picture }, connection);
            getAll();
        }
        public Recipe getRecipeById(int id)
        {
            string text = "select * from recipes where id=@id";
            Recipe r = db.LoadData<Recipe, dynamic>(text, new { id }, connection)[0];
            return r;
        }
        public List<Recipe> myRecipes(int id)
        {
            string text = "select * from recipes where creatorId=@id";
            List<Recipe >list= db.LoadData<Recipe, dynamic>(text, new { id }, connection);
            return list;
        }
        public List<Recipe> sortList()
        {
            string text = "select * from recipes order by category,name asc";
            List<Recipe> list=db.LoadData<Recipe, dynamic>(text, new { }, connection);
            return list;
           
        }
        
    }
}
