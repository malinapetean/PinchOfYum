using System;
using System.Collections.Generic;
using System.Text;
using LibraryMySql;


namespace PinchOfYum.Controllers
{
    public class Controller<T>
    {
        protected MySqlDB db = new MySqlDB();
        protected string connection= StaticMetods.getConnectionString();
        protected List<T> list = new List<T>();

        public List<T> List
        {
            get => list;
        }

        protected virtual void getAll()
        {

        }

        public virtual void printAll()
        {

        }
    }

}
