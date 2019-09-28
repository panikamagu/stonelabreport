using Syncfusion.JavaScript.Models;
using Syncfusion.JavaScript.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CCP_MOULDS
{
    public partial class treegrid : System.Web.UI.Page
    {
        List<BusinessObject> FlatData = new List<BusinessObject>();
        List<TreeGridColumn> Columns = new List<TreeGridColumn>();
  

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.TreeGridControlDefault.DataSource = this.GetEditingDataSource();
                this.TreeGridControlDefault.DataBind();
                PrecessHierData(this.GetEditingDataSource(), FlatData);
                int count = FlatData.Count;
               
            }

            Columns = this.TreeGridControlDefault.Columns;
            TreeGridColumn column = Columns[0];


   
        }

        public class BusinessObject
        {
            public string StartDate { get; set; }
            public string EndDate { get; set; }

            public int TaskId { get; set; }
            public string TaskName { get; set; }
            public int Duration { get; set; }
            public int Progress { get; set; }

            public Boolean isCollapsed { get; set; }
            public List<BusinessObject> Children { get; set; }
        }


        private List<BusinessObject> GetEditingDataSource()
        {
            List<BusinessObject> BusinessObjectCollection = new List<BusinessObject>();

            BusinessObject Record1 = null;

            Record1 = new BusinessObject()
            {
                TaskId = 1,
                TaskName = "Planning",
                StartDate = "02/03/2014",
                EndDate = "02/07/2014",
                Progress = 100,
                Duration = 5,
                isCollapsed = true,
                Children = new List<BusinessObject>(),
            };

            BusinessObject Child1 = new BusinessObject()
            {
                TaskId = 2,
                TaskName = "Plan timeline",
                StartDate = "02/03/2014",
                EndDate = "02/07/2014",
                Duration = 5,
                Progress = 100
            };

            BusinessObject Child2 = new BusinessObject()
            {
                TaskId = 3,
                TaskName = "Plan budget",
                StartDate = "02/03/2014",
                EndDate = "02/07/2014",
                Duration = 5,
                Progress = 100
            };

            BusinessObject Child3 = new BusinessObject()
            {
                TaskId = 4,
                TaskName = "Allocate resources",
                StartDate = "02/03/2014",
                EndDate = "02/07/2014",
                Duration = 5,
                Progress = 100
            };

            BusinessObject Child4 = new BusinessObject()
            {
                TaskId = 5,
                TaskName = "Planning complete",
                StartDate = "02/07/2014",
                EndDate = "02/07/2014",
                Duration = 0,
                Progress = 0
            };

            Record1.Children.Add(Child1);
            Record1.Children.Add(Child2);
            Record1.Children.Add(Child3);
            Record1.Children.Add(Child4);

            BusinessObject Record2 = new BusinessObject()
            {
                TaskId = 6,
                TaskName = "Design",
                StartDate = "02/10/2014",
                EndDate = "02/14/2014",
                Progress = 86,
                Duration = 3,
                Children = new List<BusinessObject>(),
            };

            BusinessObject Child5 = new BusinessObject()
            {
                TaskId = 7,
                TaskName = "Software Specification",
                StartDate = "02/10/2014",
                EndDate = "02/12/2014",
                Duration = 3,
                Progress = 60
            };

            BusinessObject Child6 = new BusinessObject()
            {
                TaskId = 8,
                TaskName = "Develop prototype",
                StartDate = "02/10/2014",
                EndDate = "02/12/2014",
                Duration = 3,
                Progress = 100
            };

            BusinessObject Child7 = new BusinessObject()
            {
                TaskId = 9,
                TaskName = "Get approval from customer",
                StartDate = "02/13/2014",
                EndDate = "02/14/2014",
                Duration = 2,
                Progress = 100
            };

            BusinessObject Child8 = new BusinessObject()
            {
                TaskId = 10,
                TaskName = "Design complete",
                StartDate = "02/14/2014",
                EndDate = "02/14/2014",
                Duration = 0,
                Progress = 0
            };

            Record2.Children.Add(Child5);
            Record2.Children.Add(Child6);
            Record2.Children.Add(Child7);
            Record2.Children.Add(Child8);

            BusinessObjectCollection.Add(Record1);
            BusinessObjectCollection.Add(Record2);

            return BusinessObjectCollection;
        }
        public static void PrecessHierData(List<BusinessObject> items, List<BusinessObject> coll)
        {
            foreach (var row in items)
            {
                coll.Add(row);
                List<BusinessObject> childData = row.Children;
                int ChildDataCount = childData != null ? childData.Count : 0;
                if (ChildDataCount > 0)
                {
                    PrecessHierData(childData, coll);
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            PrecessHierData(this.GetEditingDataSource(), FlatData);
            int count = FlatData.Count;

            Columns = this.TreeGridControlDefault.Columns;
          
        }
    }
}