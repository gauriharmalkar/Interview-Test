using JobPortalProject.Model;
namespace JobPortalProject.Interface
{
    public interface IService
    {
        CreateJobSaveModel CreateJobDetails(JobDetailsInput input);
        List<JobModel> GetJobDetails(int id);        
        int PutJobDetails(PutJobInput input, int id);
        List<PostListModel> PostList(PostListInput input);
        DepartmentSaveModel CreateDepartment(CreateDepartmentInput input);
        int PutDepartment(PutDepartmentInput input, int id);
        List<DepartmentModel> GetDepartment(int id);
        LocationSaveModel CreateLocation(CreateLocationInput input);
        int PutLocation(PutLocationInput input, int id);
        List<locationModel> GetLocation(int id);
    }
}
