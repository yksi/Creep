using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creep
{
    class ReportItem : CreepORM
    {
        private int ID;
        private int report_id;
        private string title;
        private string type;
        private string value;
        private bool required;

        public ReportItem(int ID, int report_id, string title, string type, string value, bool required)
        {
            this.ID = ID;
            this.report_id = report_id;
            this.title = title;
            this.type = type;
            this.value = value;
            this.required = required;
        }

        public ReportItem(Dictionary<string, object> database_entity)
        {
            this.ID = int.Parse(database_entity["ID"].ToString());
            this.report_id = int.Parse(database_entity["report_id"].ToString());
            this.value = database_entity["value"].ToString();
            this.title = database_entity["title"].ToString();
            this.type = database_entity["type"].ToString();
            this.required = bool.Parse(database_entity["required"].ToString());
        }

        public static Dictionary<string, int> getEntityMapping()
        {
            Dictionary<string, int> mapping = new Dictionary<string, int>();
            mapping.Add("ID", 0);
            mapping.Add("report_id", 1);
            mapping.Add("value", 2);
            mapping.Add("title", 4);
            mapping.Add("type", 5);
            mapping.Add("required", 3);

            return mapping;

        }

        public static Dictionary<string, object> getMappedEntity(List<Object> entity)
        {
            Dictionary<string, int> mapping = getEntityMapping();
            Dictionary<string, object> entity_mapping = new Dictionary<string, object>();
            entity_mapping.Add("ID", int.Parse(entity[mapping["ID"]].ToString()));
            entity_mapping.Add("report_id", int.Parse(entity[mapping["report_id"]].ToString()));
            entity_mapping.Add("value", entity[mapping["value"]]);
            entity_mapping.Add("title", entity[mapping["title"]]);
            entity_mapping.Add("type", entity[mapping["type"]]);
            entity_mapping.Add("required", bool.Parse(entity[mapping["required"]].ToString()));

            return entity_mapping;
        }

        public override Dictionary<string, object> getMappedEntity()
        {
            Dictionary<string, object> entity_mapping = new Dictionary<string, object>();
            entity_mapping.Add("ID", this.ID);
            entity_mapping.Add("report_id", this.report_id);
            entity_mapping.Add("value", this.value);
            entity_mapping.Add("title", this.title);
            entity_mapping.Add("type", this.type);
            entity_mapping.Add("required", this.required);

            return entity_mapping;
        }

        public void setReport(int report_id)
        {
            this.report_id = report_id;
        }

        public static ReportItem temporary()
        {
            return new ReportItem();
        }

        public ReportItem()
        {

        }

        //--getters-----setters--------------------------

        public string getType()
        {
            return this.type;
        }

        public string getTitle()
        {
            return this.title;
        }

        public string getValue()
        {
            return this.value;
        }

        //public string getType()
        //{
        //    return this.type;
        //}
//
 //       public string getType()
   //     {
     //       return this.type;
       // }

        public int getID()
        {
            return this.ID;
        }

        public void setValue(string value)
        {
            this.value = value;
        }
    }
}
