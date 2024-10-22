using PinchOfYum.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace PinchOfYum.Controllers
{
    public class ControllerUser : Controller<User>
    {
        public ControllerUser()
        {
            getAll();
        }
        protected override void getAll()
        {
            string text = "select * from users";
            list = db.LoadData<User, dynamic>(text, new { }, connection);
        }

        public override void printAll()
        {
            string text = "";
            foreach(User u in list)
            {
                text += u.description() + "\n";
            }
            Console.WriteLine(text);
        }

        public void addUser(string lastName, string firstName,string Email,string Password)
        {
            string text = "insert into users(lastName,firstName,email,password) values" +
                "(@lastName,@firstName,@Email,@Password)";
            db.SaveData(text, new { lastName, firstName, Email, Password }, connection);
            getAll();

        }

        public User getUser(string password,string email)
        {
            string text = "select * from users where password=@password and email=@email";
            List<User> user = db.LoadData<User, dynamic>(text, new { password, email }, connection);
            return (user.Count == 0) ? new User(-1, "", "", "", "") : user[0];
        }
        public User getUserById(int id)
        {
            string text = "select * from users where id=@id";
            User user= db.LoadData<User,dynamic>(text, new {id}, connection)[0];
            return user;

        }
        public void deleteUser(string password, string email)
        {
            string text = "delete from users where password=@password and email =@email";
            db.LoadData<User, dynamic>(text, new { password, email }, connection);
            getAll();
        }






       



    }
}
