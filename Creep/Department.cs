using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creep
{
    class Department : CreepORM
    {

        private int ID;
        private int manager_id;
        private string name;
        public string TABLENAME = "Departments";

        public Department()
        {

        }

        public Department(Dictionary<string, object> database_entity)
        {
            this.ID = int.Parse(database_entity["ID"].ToString());
            this.name = database_entity["name"].ToString();
            this.manager_id = int.Parse(database_entity["manager_id"].ToString());
        }

        public Department(int ID, string name, int manager_id)
        {
            this.ID = ID;
            this.name = name;
            this.manager_id = manager_id;
        }

        public static Dictionary<string, int> getEntityMapping()
        {
            Dictionary<string, int> mapping = new Dictionary<string, int>();
            mapping.Add("ID", 0);
            mapping.Add("manager_id", 1);
            mapping.Add("name", 2);

            return mapping;

        }

        public User getManager()
        {
            return User.find(this.manager_id, true);
        }

        public static Dictionary<string, object> getMappedEntity(List<Object> entity)
        {
            Dictionary<string, int> mapping = Department.getEntityMapping();
            Dictionary<string, object> entity_mapping = new Dictionary<string, object>();
            entity_mapping.Add("ID", int.Parse(entity[mapping["ID"]].ToString()));
            entity_mapping.Add("manager_id", int.Parse(entity[mapping["manager_id"]].ToString()));
            entity_mapping.Add("name", entity[mapping["name"]].ToString());

            return entity_mapping;
        }

        public override Dictionary<string, object> getMappedEntity()
        {
            Dictionary<string, int> mapping = User.getEntityMapping();
            Dictionary<string, object> entity_mapping = new Dictionary<string, object>();
            entity_mapping.Add("ID", this.ID);
            entity_mapping.Add("manager_id", this.manager_id);
            entity_mapping.Add("name", this.name);

            return entity_mapping;
        }

        public static Department temporary()
        {
            return new Department();
        }

        public override string ToString()
        {
            return this.ID.ToString() + ". " + this.name;
        }

        public int getID()
        {
            return this.ID;
        }

        public string getName()
        {
            return this.name;
        }

        public static int getIdFromToString(string to_string)
        {
            return int.Parse(to_string.Split(new string[] { "." }, StringSplitOptions.None)[0]);
        }

        public static Department find(int ID, bool OBJ)
        {
            if (OBJ)
                return new Department(Department.getMappedEntity(Department.temporary().find(ID)));
            else
                return new Department();
        }


        public List<User> getUsers()
        {
            string query = "SELECT Us.ID " +
                           "FROM UsersDepartments AS UDs " +
                           "LEFT JOIN Users AS Us ON UDs.user_id=Us.ID " +
                           "WHERE UDs.department_id = " + this.ID;

            List<int> UsersIDs = CreepORM.queryGetOneIntParam(query);
            List<User> Users = new List<User>();

            foreach (int user_id in UsersIDs)
            {
                Users.Add(User.find(user_id, true));
            }

            return Users;
        }

        public void setName(string p)
        {
            this.name = p;
        }
    }
}
