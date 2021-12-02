using JobPortalProject.Model;
using System.Data;

namespace JobPortalProject.Interface
{
    public interface IRepositoryJob
    {
        object GetJobDetails(int id);
        int PutJobDetails(PutJobInput input,int id);
        DataSet PostList(PostListInput input);
        object CreateJob(JobDetailsInput input);
        object CreateDepartment(CreateDepartmentInput input);
        int PutDepartment(PutDepartmentInput input, int id);
        object GetDepartment(int id);
        object CreateLocation(CreateLocationInput input);
        int PutLocation(PutLocationInput input, int id);
        object GetLocation(int id);
    }
}
