using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Creep
{
    class CreepORM : MyORM
    {
        protected static string TABLENAME = getClassName();
        protected static Connect connect = new Connect();

        public static Object[] where(string __QUERY__)
        {
            string query = "SELECT * FROM " + TABLENAME + " WHERE " + __QUERY__ + ";";
            Object[] objects;
            if(CreepORM.connect.Open())
            {
                MySqlCommand command = new MySqlCommand(query, CreepORM.connect.connection);
                MySqlDataReader dataReader = command.ExecuteReader();

                int count = dataReader.FieldCount;
                Object[] args = new Object[count];
                int index = 0;
                
                while (dataReader.Read())
                {
                    for (int j = 0; j < count; j++)
                    {
                        args[j] = dataReader.GetValue(j);
                    }
                    objects[index] = System.Activator.CreateInstance(Type.GetType(CreepORM.getClassName())); 
                    index++;
                }
                        
            
            
            
                return objects;
            }
         }

        public static Object find(int __ID__)
        {
            return where("id = " + __ID__.ToString())[0];
        }

        public bool save()
        {
            string query = "INSERT INTO ";
            return true;
        }

        public bool delete()
        {
            throw new NotImplementedException();
        }

        public object update()
        {
            throw new NotImplementedException();
        }

        protected string getClassNameFromObject()
        {
            return this.GetType().Name;
        }

        public static string getClassName()
        {
            User user = new User(0);
            return user.getClassNameFromObject();
        }
    }
}
