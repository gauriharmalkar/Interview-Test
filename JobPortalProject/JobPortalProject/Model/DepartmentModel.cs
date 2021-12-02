namespace JobPortalProject.Model
{
    public class DepartmentModel 
    {
        public int Id { get; set; }
        public string Title { get; set;}
    }
    public class DepartmentSaveModel
    {
        public int Id { get; set; }
    }
    public class CreateDepartmentInput
    {
        public string Title { get; set; }
    }

    public class PutDepartmentInput
    {
        public string Title { get; set; }
    }



}
