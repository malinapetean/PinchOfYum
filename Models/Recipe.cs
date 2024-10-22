using System;
using System.Collections.Generic;
using System.Text;

namespace PinchOfYum.Models
{
    public class Recipe
    {
        private int id;
        private string name = "";
        private string category = "";
        private string ingredients = "";
        private string instructions = "";
        private int creatorId;
        private byte[] picture;

        public int ID
        {
            get => this.id;
            set => this.id = value;
        }
        public int CreatorID
        {
            get => this.creatorId;
            set => this.creatorId = value;
        }
        public string Name
        {
            get => this.name;
            set => this.name = value;

        }
        public string Category
        {
            get => this.category;
            set => this.category = value;
        }
        public string Ingredients
        {
            get => this.ingredients;
            set => this.ingredients = value;
        }
        public string Instructions
        {
            get => this.instructions;
            set => this.instructions = value;
        }
        public byte[] Picture
        {
            get => this.picture;
            set => this.picture = value;
        }

        public string description()
        {
            string d = "";
            d += "Recipe id: " + this.id + "\n";
            d += "Recipe name: " + this.name + "\n";
            d += "Category: " + this.category + "\n";
            d += "Ingredients: " + this.ingredients + "\n";
            d += "Instructions: " + this.instructions + "\n";
            d += "Creator id: " + this.creatorId + "\n";
            d += "Picture: " + this.picture + "\n";
            return d;
        }
        
        public Recipe(int id, string name, string category, string ingredients,string instructions, int creatorID,byte[] picture)
        {
            this.id = id;
            this.name = name;
            this.category = category;
            this.ingredients = ingredients;
            this.instructions =instructions;
            this.creatorId = creatorID;
            this.picture = picture;
        }
        
        public override string ToString()
        {
            string txt = "";
            txt += this.id + "," + this.name + "," + this.category + "," + this.ingredients + "," + this.instructions+ "," + this.creatorId+","+this.picture;

            return txt;
        }
        public override bool Equals(object obj)
        {
            Recipe r = obj as Recipe;

            return this.id == r.id;
        }
        public Recipe()
        {

        }
    }   
}
