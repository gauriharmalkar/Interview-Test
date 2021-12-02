using JobPortalProject.Interface;

namespace JobPortalProject.Model
{
    public class JobModel 
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }        
        public string Description { get; set; }
        public locationModel Location { get; set; }
        public DepartmentModel Department { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime ClosingDate { get; set; }


    }

    public class CreateJobSaveModel
    {
        public int Id { get; set; }
    }
    public class PostListModel
    {
        public int totalCount { get; set; }
        public List<Data> data { get; set; }

    }

        

        public class Data 
    {
        
        public int Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string Department { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime ClosingDate { get; set; }
    }
}
