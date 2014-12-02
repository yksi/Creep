using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creep
{
    class ReportType : CreepORM
    {
        private int ID;
        private string type_name;
        public string TABLENAME = "ReportType";

        public ReportType(Dictionary<string, object> database_entity)
        {
            this.ID = int.Parse(database_entity["ID"].ToString());
            this.type_name = database_entity["type_name"].ToString();
        }
        
        public ReportType(int ID, string type_name)
        {
            this.ID = ID;
            this.type_name = type_name;
        }

        public ReportType()
        {
            // TODO: Complete member initialization
        }

        public static Dictionary<string, int> getEntityMapping()
        {
            Dictionary<string, int> mapping = new Dictionary<string, int>();
            mapping.Add("ID", 0);
            mapping.Add("type_name", 1);

            return mapping;

        }

        public static Dictionary<string, object> getMappedEntity(List<Object> entity)
        {
            Dictionary<string, int> mapping = ReportType.getEntityMapping();
            Dictionary<string, object> entity_mapping = new Dictionary<string, object>();
            entity_mapping.Add("ID", int.Parse(entity[mapping["ID"]].ToString()));
            entity_mapping.Add("type_name", entity[mapping["type_name"]].ToString());

            return entity_mapping;
        }

        public override Dictionary<string, object> getMappedEntity()
        {
            Dictionary<string, object> entity_mapping = new Dictionary<string, object>();
            entity_mapping.Add("ID", this.ID);
            entity_mapping.Add("type_name", this.type_name);

            return entity_mapping;
        }

        public static ReportType temporary()
        {
            return new ReportType();
        }

        public override string ToString()
        {
            return this.type_name;
        }

        internal int getID()
        {
            return ID;
        }
    }
}
