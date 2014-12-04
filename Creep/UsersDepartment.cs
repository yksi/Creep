using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creep
{
    class UsersDepartment : CreepORM
    {
        private int department_id;
        private int user_id;

        public UsersDepartment(Dictionary<string, object> database_entity)
        {
            this.department_id = int.Parse(database_entity["department_id"].ToString());
            this.user_id = int.Parse(database_entity["user_id"].ToString());
        }

        public UsersDepartment(int user_id, int department_id)
        {
            this.department_id = department_id;
            this.user_id = user_id;
        }
        
        public static Dictionary<string, int> getEntityMapping()
        {
            Dictionary<string, int> mapping = new Dictionary<string, int>();
            mapping.Add("department_id", 0);
            mapping.Add("user_id", 1);

            return mapping;

        }

        public static Dictionary<string, object> getMappedEntity(List<Object> entity)
        {
            Dictionary<string, int> mapping = UsersDepartment.getEntityMapping();
            Dictionary<string, object> entity_mapping = new Dictionary<string, object>();
            entity_mapping.Add("department_id", int.Parse(entity[mapping["department_id"]].ToString()));
            entity_mapping.Add("user_id", int.Parse(entity[mapping["user_id"]].ToString()));

            return entity_mapping;
        }

        public override Dictionary<string, object> getMappedEntity()
        {
            Dictionary<string, object> entity_mapping = new Dictionary<string, object>();
            entity_mapping.Add("department_id", this.department_id);
            entity_mapping.Add("user_id", this.user_id);

            return entity_mapping;
        }

        public UsersDepartment()
        {

        }

        public static UsersDepartment temporary()
        {
            return new UsersDepartment();
        }
    }
}
