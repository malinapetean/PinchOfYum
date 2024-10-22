using Microsoft.Extensions.Configuration;
using System.IO;


namespace PinchOfYum
{
    public class StaticMetods
    {
        public static string getConnectionString(string connection = "Default_Connection")
        {
            string rez = string.Empty;
            var builder = new ConfigurationBuilder()
                .SetBasePath("D:\\mycode\\csharp\\PinchOfYum\\PinchOfYum\\")
                .AddJsonFile("jsconfig1.json");
            var config = builder.Build();
            rez = config.GetConnectionString(connection);
            return rez;
        }
    }
}
