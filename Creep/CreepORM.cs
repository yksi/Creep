using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

using System.Windows.Forms;

namespace Creep
{
    class CreepORM
    {
        public static string TABLENAME = "defaults";
        protected static Connect connect = new Connect();

        public CreepORM()
        {
            #if TABLENAME
            #endif

        }

        public static Dictionary<string, int> getEntityMapping()
        {
            Dictionary<string, int> _default = new Dictionary<string, int>();
            _default.Add("default", 0);
            return _default;
        }

        public static Dictionary<string, object> getMappedEntity(Object[] entity)
        {
            Dictionary<string, object> _default = new Dictionary<string, object>();
            _default.Add("default", 0);
            return _default;
        }

        public virtual Dictionary<string, object> getMappedEntity() { return new Dictionary<string, object>(); }
        
        public List<List<Object>> all()
        {
            return where("");
        }

        public List<List<Object>> where(string __QUERY__)
        {
            string after_select = "WHERE";
            if (__QUERY__ == "")
            {
                after_select = ";";
            }

            string query = "SELECT * FROM `" + this.GetType().Name + "s` " + after_select + " " + __QUERY__ + ";";
            List<List<Object>> objects = new List<List<Object>>();
            if(CreepORM.connect.Open())
            {
                MySqlCommand command = new MySqlCommand(query, CreepORM.connect.connection);
                MySqlDataReader dataReader = command.ExecuteReader();

                int count = dataReader.FieldCount;
                int index = 0;
                while (dataReader.Read())
                {
                    List<Object> args = new List<Object>();
                    for (int j = 0; j < count; j++)
                    {
                        args.Add(dataReader.GetValue(j));
                            
                    }

                    objects.Add(args);
                }                
            }

            CreepORM.connect.Close();

            return objects;
         }

        public List<Object> find(int __ID__)
        {
            return where("id = " + __ID__.ToString())[0];
        }

        public List<Object> findBy(string key, dynamic value)
        {
            return where("`" + key + "`" + " = '" + value.ToString() + "'")[0];

        }

        public List<Object> findByInt(string key, dynamic value)
        {
            return where("`" + key + "`" + " = " + value.ToString() + "")[0];

        }

        public List<List<Object>> findAllBy(string key, dynamic value)
        {
            return where("`" + key + "`" + " = '" + value.ToString() + "'");
        }

        public List<List<Object>> findAllByInt(string key, dynamic value)
        {
            return where("`" + key + "`" + " = " + value.ToString() + "");
        }

        public List<List<Object>> findAllLessByInt(string key, dynamic value)
        {
            return where("`" + key + "`" + " < " + value.ToString() + "");
        }

        public List<List<Object>> findAllBiggerByInt(string key, dynamic value)
        {
            return where("`" + key + "`" + " > " + value.ToString() + "");
        }

        public int save()
        {
            Dictionary<string, object> entity = this.getMappedEntity();
            List<string> entityKeys = new List<string>(entity.Keys);
            List<object> entityValues = new List<object>(entity.Values);
            if(entity.ContainsKey("ID")) this.deleteByID(int.Parse(entity["ID"].ToString()));
            int ID = 0;
            string keys = "";

            int count = 0;
            int intern_count = 0;
            string valuesString = "";
            foreach(string key in entityKeys)
            {
                if (key != "ID" && key != "created_at" && key!= "updated_at")
                {
                    keys += "`" + key + "`";
                    valuesString += "@" + key + "";
                }
                if (!key.Equals(entityKeys.Last()) && key != "ID" && key != "created_at" && key != "updated_at") { keys += ","; valuesString += ","; }
                count++;
            }

            List<Object> values = new List<Object>();

            foreach (object value in entityValues)
            {
                if (value.GetType().Name == "Int32")
                {
                    values.Add(value.ToString());
                }

                else if (value.GetType().Name == "Boolean")
                {
                    values.Add(Convert.ToInt32(bool.Parse(value.ToString())).ToString());
                }

                else if (value.GetType().Name == "String")
                {
                    values.Add(value.ToString());
                }
            }

            string query = @"INSERT INTO `" + this.GetType().Name +  "s` (" + keys + ") VALUES (" + valuesString + ");";
           
            if (CreepORM.connect.Open())
            {
                MySqlCommand command = new MySqlCommand(query, CreepORM.connect.connection);
                foreach (string key in entityKeys)
                {
                    if (key != "ID" && key != "created_at" && key!= "updated_at")
                    {
                        command.Parameters.AddWithValue("@" + key, values[intern_count]);
                    }
                    
                    intern_count++;
                }
                command.ExecuteReader();
                ID = (int)command.LastInsertedId;
            }

            CreepORM.connect.Close();
            return ID;
        }

        public bool deleteByID(int ID)
        {
            var resultSet = 0;
            string query = "delete from `" + this.GetType().Name + "s` where `ID` = @id";

            if (CreepORM.connect.Open())
            {
               MySqlCommand command = new MySqlCommand(query, CreepORM.connect.connection);
               command.Parameters.AddWithValue("@id", ID.ToString());

               resultSet = command.ExecuteNonQuery();
               CreepORM.connect.Close();
            }

            if (!resultSet.Equals(0)) { return true; }
            return false;
        }

        public bool deleteByIntAnd(string key1, int value1, string key2, int value2)
        {
            var resultSet = 0;
            string query = "delete from `" + this.GetType().Name + "s` where `" + key1 +"` = @key1 and `"+ key2 +"` = @key2";

            if (CreepORM.connect.Open())
            {
                MySqlCommand command = new MySqlCommand(query, CreepORM.connect.connection);
                command.Parameters.AddWithValue("@key1", value1);
                command.Parameters.AddWithValue("@key2", value2);

                resultSet = command.ExecuteNonQuery();
                CreepORM.connect.Close();
            }

            if (!resultSet.Equals(0)) return true;
            return false;
        }

        public void delete()
        {
            Dictionary<string, object> entity = this.getMappedEntity();
            List<string> entityKeys = new List<string>(entity.Keys);
            List<object> entityValues = new List<object>(entity.Values);
            int ID = 0;

            int count = 0;
            int intern_count = 0;
            string key_values = "";
            foreach (string key in entityKeys)
            {
                if (key != "ID" && key != "created_at" && key != "updated_at" && key != "password")
                {
                    key_values += key + " = " + "@" + key;
                    if (!key.Equals(entityKeys.Last()) && key != "ID") { key_values += " and "; }
                }
                count++;
            }

            List<Object> values = new List<Object>();

            foreach (object value in entityValues)
            {
                if(value == null)
                {
                    values.Add("0");
                }

                else if (value.GetType().Name == "Int32")
                {
                        values.Add(value.ToString());                    
                }

                else if (value.GetType().Name == "Boolean")
                {
                    values.Add(Convert.ToInt32(bool.Parse(value.ToString())).ToString());
                }

                else if (value.GetType().Name == "String")
                {
                    values.Add(value.ToString());
                }
            }

            

            string query = @"delete from `" + this.GetType().Name + "s` where " + key_values;
            query = query.Replace("and WHERE", " WHERE");
            if (CreepORM.connect.Open())
            {
                MySqlCommand command = new MySqlCommand(query, CreepORM.connect.connection);
                foreach (string key in entityKeys)
                {
                    if (key != "ID" && key != "created_at" && key != "updated_at" && key != "password")
                    {
                        command.Parameters.AddWithValue("@" + key, values[intern_count]);
                    }

                    intern_count++;
                }
                command.ExecuteReader();
                ID = (int)command.LastInsertedId;
            }

            CreepORM.connect.Close();
        }
        

        public static List<int> queryGetOneIntParam(string QUERY)
        {
            List<int> ResultSet = new List<int>();
            if(connect.Open())
            {
                MySqlCommand command = new MySqlCommand(QUERY, CreepORM.connect.connection);
                MySqlDataReader dataReader = command.ExecuteReader();

                while(dataReader.Read())
                {
                    try
                    {
                        ResultSet.Add(dataReader.GetInt32(0));
                    }

                    catch (Exception e) { continue; }
                }
            }

            connect.Close();

            return ResultSet;
        }

        public void update()
        {
            Dictionary<string, object> entity = this.getMappedEntity();
            List<string> entityKeys = new List<string>(entity.Keys);
            List<object> entityValues = new List<object>(entity.Values);
            int ID = 0;

            int count = 0;
            int intern_count = 0;
            string key_values = "";
            foreach (string key in entityKeys)
            {
                if (key != "ID" && key != "created_at" && key != "updated_at" && key != "password")
                {
                    key_values += key + " = " + "@" + key;
                    if (!key.Equals(entityKeys.Last()) && key != "ID") { key_values += ","; }
                }
                count++;
            }

            List<Object> values = new List<Object>();

            foreach (object value in entityValues)
            {
                if(value == null)
                {
                    values.Add("0");
                }

                else if (value.GetType().Name == "Int32")
                {
                        values.Add(value.ToString());                    
                }

                else if (value.GetType().Name == "Boolean")
                {
                    values.Add(Convert.ToInt32(bool.Parse(value.ToString())).ToString());
                }

                else if (value.GetType().Name == "String")
                {
                    values.Add(value.ToString());
                }
            }

            

            string query = @"UPDATE `" + this.GetType().Name + "s` SET " + key_values + " WHERE ID = " + entity["ID"].ToString();
            query = query.Replace(", WHERE", " WHERE");
            if (CreepORM.connect.Open())
            {
                MySqlCommand command = new MySqlCommand(query, CreepORM.connect.connection);
                foreach (string key in entityKeys)
                {
                    if (key != "ID" && key != "created_at" && key != "updated_at" && key != "password")
                    {
                        command.Parameters.AddWithValue("@" + key, values[intern_count]);
                    }

                    intern_count++;
                }
                command.ExecuteReader();
                ID = (int)command.LastInsertedId;
            }

            CreepORM.connect.Close();
        }

    }
}
