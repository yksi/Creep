using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Creep
{
    class User : CreepORM
    {
        private int ID;
        private string name;
        private string email;
        private int role;
        private string _PASS;

        static User()
        {
            TABLENAME = "Users";
        }
        
        public User(int __ID__)
        {
            ID = __ID__;
        }

        public User(Dictionary<string, object> database_entity)
        {
            this.ID = int.Parse(database_entity["ID"].ToString());
            this.name = database_entity["name"].ToString();
            this.email = database_entity["email"].ToString();
            this.role = int.Parse(database_entity["role"].ToString());
        }
        
        public User(int ID, string name, string email, int role)
        {
            this.ID = ID;
            this.name = name;
            this.email = email;
            this.role = role;
        }

        public User(int ID, string name, string email, string password)
        {
            this.ID = ID;
            this.name = name;
            this.email = email;
            this.role = 0;
            this._PASS = User.HashPass(password);

        }

        public User()
        {
            // TODO: Complete member initialization
        }

        public static User find()
        {
            return new User(0);
        }

        public static Dictionary<string, int> getEntityMapping()
        {
            Dictionary<string, int> mapping = new Dictionary<string, int>();
            mapping.Add("ID", 0);
            mapping.Add("name", 1);
            mapping.Add("email", 2);
            mapping.Add("role", 3);
            mapping.Add("password", 4);

            return mapping;

        }

        public static Dictionary<string, object> getMappedEntity(List<Object> entity)
        {
            Dictionary<string, int> mapping = User.getEntityMapping();
            Dictionary<string, object> entity_mapping = new Dictionary<string, object>();
            entity_mapping.Add("ID", int.Parse(entity[mapping["ID"]].ToString()));
            entity_mapping.Add("name", entity[mapping["name"]].ToString());
            entity_mapping.Add("email", entity[mapping["email"]].ToString());
            entity_mapping.Add("role", int.Parse(entity[mapping["role"]].ToString()));
            entity_mapping.Add("password", entity[mapping["password"]].ToString());

            return entity_mapping;
        }

        public override Dictionary<string, object> getMappedEntity()
        {
            Dictionary<string, object> entity_mapping = new Dictionary<string, object>();
            entity_mapping.Add("ID", this.ID);
            entity_mapping.Add("name", this.name);
            entity_mapping.Add("email", this.email);
            entity_mapping.Add("role", this.role);
            entity_mapping.Add("password", this._PASS);

            return entity_mapping;
        }

        public static bool verifyPassword(string user_email, string expected_password)
        {
            List<Object> arg = User.temporary().findBy("email", user_email);
            string realPassword = arg[4].ToString();          
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(expected_password);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            if(sb.ToString().ToLower() == realPassword.ToString()) return true;

            return false;
        }

        private static string HashPass(string pass)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(pass);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            return sb.ToString().ToLower();
        }

        public static string roleName(int role)
        {
            switch (role)
            {
                case 0: return "Worker";
                case 1: return "Manager";
                case 2: return "Chief Executive Officer";
                case 3: return "Administrator";
            }

            return "Worker";
        }

        public int getID()
        {
            return ID;
        }

        public string getName()
        {
            return name;
        }

        public int getRole()
        {
            return role;
        }

        public string getEmail()
        {
            return email;
        }

        public static User temporary()
        {
            return new User();
        }

        public override string ToString()
        {
            return this.getID().ToString() + ". " + User.roleName(this.getRole()) + " " + this.getName();
        }

        public static int getIdFromToString(string to_string)
        {
            return int.Parse(to_string.Split(new string[] { "." }, StringSplitOptions.None)[0]); 
        }

        public static User find(int ID, bool OBJ)
        {
            if (OBJ)
                return new User(User.getMappedEntity(User.temporary().find(ID)));
            else
                return new User();
        }

        public List<Department> getManagedDepartments()
        {
            List<List<object>> departments = Department.temporary().findAllByInt("manager_id", Variator.Logged_In_User.getID());
            List<Department> Odepartments = new List<Department>();

            foreach(List<object> department in departments)
            {
                Odepartments.Add(new Department( Department.getMappedEntity(department)));
            }

            return Odepartments;
        }

        public List<Department> getDepartments()
        {
            string query = "SELECT Ds.ID " +
                           "FROM UsersDepartments AS Uds " +
                           "LEFT JOIN Departments AS Ds ON UDs.department_id=Ds.ID  " +
                           "WHERE UDs.user_id = " + this.ID;

            List<int> UsersIDs = CreepORM.queryGetOneIntParam(query);
            List<Department> Departments = new List<Department>();

            foreach (int user_id in UsersIDs)
            {
                Departments.Add(Department.find(user_id, true));
            }

            return Departments;
        }

        public void setRole(int p)
        {
            this.role = p;
        }
    }
}