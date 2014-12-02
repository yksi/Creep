using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Creep
{
    class Report : CreepORM
    {
        private int ID;
        private int owner_id;
        private int recipient_id;
        private int department_id;
        private string title;
        private string formatted_text;
        private bool _checked;
        private bool done;
        private int type_id;
        private string created_at;
        private string updated_at;
        private string due_date;
               
        public Report(Dictionary<string, object> database_entity)
        {
            this.ID = int.Parse(database_entity["ID"].ToString());
            this.owner_id = int.Parse(database_entity["owner_id"].ToString());
            this.recipient_id = int.Parse(database_entity["recipient_id"].ToString());
            this._checked = bool.Parse(database_entity["checked"].ToString());
            this.done = bool.Parse(database_entity["done"].ToString());
            this.type_id = int.Parse(database_entity["type_id"].ToString());
            this.title = database_entity["title"].ToString();
            this.formatted_text = database_entity["formatted_text"].ToString();
            this.created_at = database_entity["created_at"].ToString();
            this.updated_at = database_entity["updated_at"].ToString();
            this.due_date = database_entity["due_date"].ToString();
        }

        public Report(int ID, int owner_id, int recipient_id, string title, string formatted_text, bool _checked, bool done, int type_id, string created_at, string updated_at, string due_date, int department_id)
        {
            this.ID = ID;
            this.owner_id = owner_id;
            this.recipient_id = recipient_id;
            this.department_id = department_id;
            this.title = title;
            this.formatted_text = formatted_text;
            this._checked = _checked;
            this.done = done;
            this.type_id = type_id;
            this.created_at = created_at;
            this.updated_at = updated_at;
            this.due_date = due_date;
        }

        /*required constructor
         *  In this case we have to redeclare Report cunstructor
         *  to make editor more secure and to have 
         * 
         */
        
        public Report()
        {
            // TODO: Complete member initialization
        }

        public static Dictionary<string, int> getEntityMapping()
        {
            Dictionary<string, int> mapping = new Dictionary<string, int>();
            mapping.Add("ID", 0);
            mapping.Add("owner_id", 1);
            mapping.Add("recipient_id", 2);
            mapping.Add("title", 3);
            mapping.Add("formatted_text", 4);
            mapping.Add("checked", 5);
            mapping.Add("done", 6);
            mapping.Add("type_id", 7);
            mapping.Add("created_at", 8);
            mapping.Add("updated_at", 9);
            mapping.Add("due_date", 10);
            mapping.Add("department_id", 11);

            return mapping;

        }

        public static Dictionary<string, object> getMappedEntity(List<Object> entity)
        {
            Dictionary<string, int> mapping = Report.getEntityMapping();
            Dictionary<string, object> entity_mapping = new Dictionary<string, object>();

            entity_mapping.Add("ID", int.Parse(entity[mapping["ID"]].ToString()));
            entity_mapping.Add("owner_id", int.Parse(entity[mapping["owner_id"]].ToString()));
            entity_mapping.Add("recipient_id", int.Parse(entity[mapping["recipient_id"]].ToString()));
            entity_mapping.Add("department_id", int.Parse(entity[mapping["department_id"]].ToString()));
            entity_mapping.Add("title", entity[mapping["title"]].ToString());
            entity_mapping.Add("formatted_text", entity[mapping["formatted_text"]].ToString());
            entity_mapping.Add("checked", int.Parse(entity[mapping["checked"]].ToString()) == 0 ? false : true);
            entity_mapping.Add("done", int.Parse(entity[mapping["done"]].ToString()) == 0 ? false : true);
            entity_mapping.Add("type_id", int.Parse(entity[mapping["type_id"]].ToString()));
            entity_mapping.Add("created_at", entity[mapping["created_at"]].ToString());
            entity_mapping.Add("updated_at", entity[mapping["updated_at"]].ToString());
            entity_mapping.Add("due_date",entity[mapping["due_date"]].ToString());

            return entity_mapping;
        }

        public static Report temporary()
        {
            return new Report(); 
        }

        public override Dictionary<string, object> getMappedEntity()
        {
            Dictionary<string, object> entity_mapping = new Dictionary<string, object>();

            entity_mapping.Add("ID", this.ID);
            entity_mapping.Add("owner_id", this.owner_id);
            entity_mapping.Add("recipient_id", this.recipient_id);
            entity_mapping.Add("department_id", this.department_id);
            entity_mapping.Add("title", this.title);
            entity_mapping.Add("formatted_text", this.formatted_text);
            entity_mapping.Add("checked", this._checked);
            entity_mapping.Add("done", this.done);
            entity_mapping.Add("type_id", this.type_id);
            entity_mapping.Add("created_at", this.created_at);
            entity_mapping.Add("updated_at", this.updated_at);
            entity_mapping.Add("due_date", this.due_date);

            return entity_mapping;
        }

        public List<ReportItem> getReportItems()
        {
            List<List<object>> report_items = ReportItem.temporary().findAllBy("report_id", this.ID.ToString());
            List<ReportItem> report_items_as_objects = new List<ReportItem>();
            foreach(List<object> report_item in report_items)
            {
                report_items_as_objects.Add(new ReportItem(ReportItem.getMappedEntity ( report_item )));
            }

            return report_items_as_objects;
        }

        public string getTitle()
        {
            return title;
        }

        public int getRecipientId()
        {
            return this.recipient_id;
        }

        public string getReporter()
        {
            return (new User(User.getMappedEntity(User.temporary().find(this.getReporterId())))).getName();
        }

        public string getAsignee()
        {
            return (new User(User.getMappedEntity(User.temporary().find(this.getRecipientId())))).getName();
        }

        public int getReporterId()
        {
            return this.owner_id;
        }

        public void setIsFinished(bool p)
        {
            this.done = p;
        }

        public void setIsDone(bool p)
        {
            this._checked = p;
        }

        public bool getIsFinished()
        {
            return done;
        }

        public bool getIsDone()
        {
            return _checked;
        }

        public string getType()
        {
            return ( new ReportType( ReportType.getMappedEntity( ReportType.temporary().find(this.type_id ) ) ) ).ToString();
        }

        public Department getDepartment()
        {
            if (this.department_id != 0) return new Department(Department.getMappedEntity(Department.temporary().find(this.department_id)));
            else return new Department();
        }

        public int getID()
        {
            return ID;
        }

        public string getUpdated()
        {
            return this.updated_at.ToString();
        }
    }
}
