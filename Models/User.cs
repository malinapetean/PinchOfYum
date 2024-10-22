using System;
using System.Collections.Generic;
using System.Text;

namespace PinchOfYum.Models
{
    public class User
    {
        private int id;
        private string firstName = "";
        private string lastName = "";
        private string email = "";
        private string password = "";

        public int Id
        {
            get => this.id;
            set => this.id = value;
        }
        public string First_Name
        {
            get => this.firstName;
            set => this.firstName = value;
        }
        public string Last_Name
        {
            get => this.lastName;
            set => this.lastName = value;
        }
        public string Email
        {
            get => this.email;
            set => this.email = value;
        }
        public string Password
        {
            get => this.password;
            set => this.password = value;
        }
        public virtual string description()
        {
            string txt = "";
            txt += "Id: " + this.id + "\n";
            txt += "First name: " + this.firstName + "\n";
            txt += "Last name: " + this.lastName + "\n";
            txt += "Email: " + this.email + "\n";
            txt += "Password:" + this.password + "\n";

            return txt;
        }
        
        public User(int id, string firstName, string lastName,string email, string password)
        {
            this.id = id;
            this.email = email;
            this.password = password;
            this.firstName = firstName;
            this.lastName = lastName;
            
        }
        public override string ToString()
        {
            string text = "";
            text += this.id + "," + this.firstName + "," + this.lastName + "," + this.email + "," + this.password;
            return text;
        }
        
    }
}
