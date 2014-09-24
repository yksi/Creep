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
        private MySqlConnection connection;
    
        public Connect() {
            Initialize();
        }

        private void Initialize(){
            connection = new MySqlConnection("SERVER="+Variator.DB_CONNECT_HOST+
                                             ";DATABASE="+Variator.DB_CONNECT_DATABASE+
                                             ";UID="+Variator.DB_CONNECT_UID+
                                             ";PASSWORD="+Variator.DB_CONNECT_PASSWORD);
        }

        public bool Open()
        {
            try
            {
                connection.Open();
                MessageBox.Show("Successfull");
                return true;
            }
            catch(MySqlException exception)
            {
                switch(exception.Number)
                {
                    case 0:
                        MessageBox.Show("Error, while connection to database. Connect with your administrator!");
                        break;
                    case 1045:
                        MessageBox.Show("Invalid username/password. Please check your credentials.");
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
                MessageBox.Show(exception.Message);
            }
            return false;
        }
    }
}
