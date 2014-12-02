using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Creep
{
    class Connect
    {
        public MySqlConnection connection;
    
        public Connect() {
            Initialize();
        }

        private void Initialize(){
            string command = "SERVER=" + Variator.DB_CONNECT_HOST +
                                             ";DATABASE=" + Variator.DB_CONNECT_DATABASE +
                                             ";UID=" + Variator.DB_CONNECT_UID +
                                             ";PASSWORD=" + Variator.DB_CONNECT_PASSWORD;
            connection = new MySqlConnection(command);
        }

        public bool Open()
        {
            try
            {
                connection.Open();
                Console.WriteLine("Successfull");
                return true;
            }
            catch(MySqlException exception)
            {
                switch(exception.Number)
                {
                    case 0:
                        Console.WriteLine("Error, while connection to database. Connect with your administrator!");
                        break;
                    case 1045:
                        Console.WriteLine("Invalid username/password. Please check your credentials.");
                        break;
                }
            }
            return false;
        }


        public bool Close()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch(MySqlException exception)
            {
                Console.WriteLine(exception.Message);
            }
            return false;
        }
    }
}
