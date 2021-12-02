using System.Data.SqlClient;
using JobPortalProject.Model;
using System.Data;
using JobPortalProject.Interface;

namespace JobPortalProject.Repository
{
    public class RepositoryJob : RepositoryBase , IRepositoryJob
    {
        IConfiguration _IConfiguration;
        private const string SprGetJobsDetails = @"dbo.[getJobsDetails]";
        private const string SprCreateJobsDetails = @"dbo.[createJobs]";
        private const string SprPutJobsDetails = @"dbo.[updateJobs]";
        private const string SprPostList = @"dbo.[jobsList]";
        private const string SprCreatedepart = @"dbo.[createdepart]";
        private const string SprPutDepartment = @"dbo.[updatedepart]";
        private const string SprGetDepartment = @"dbo.[getdepart]";
        private const string SprCreateLocation = @"dbo.[createlocation]";
        private const string SprPutLocation = @"dbo.[updateLocation]";
        private const string SprGetLocation = @"dbo.[getLocation]";


        public RepositoryJob(IConfiguration Config) : base(Config)
        {
            _IConfiguration = Config;
        }

        public object GetJobDetails(int id)        
        {
            var parameterList = new List<SqlParameter>
           {
               new SqlParameter("@ID",id)
           };
            DataSet result = ExecuteSpGet(parameterList.ToArray(), SprGetJobsDetails);
            if (result == null) return null;
            
            return result.Tables[0];

        }

        public object CreateJob(JobDetailsInput input)
        {
            var parameterList = new List<SqlParameter>
           {
               new SqlParameter("@title",input.title),
               new SqlParameter("@description", input.description),
               new SqlParameter("@locationId", input.locatioId),
               new SqlParameter("@departmentId", input.departmentId),
               new SqlParameter("@closingDate", input.closingDate)



           };
            DataSet result = ExecuteSpGet(parameterList.ToArray(), SprCreateJobsDetails);
            if (result == null) return null;

            return  result.Tables[0];
        }

        public int PutJobDetails(PutJobInput input,int id)
        {
            var parameterList = new List<SqlParameter>
           {
               new SqlParameter("@ID",id),
               new SqlParameter("@title",input.title),
               new SqlParameter("@description", input.description),
               new SqlParameter("@locationId", input.locatioId),
               new SqlParameter("@departmentId", input.departmentId),
               new SqlParameter("@closingDate", input.closingDate)


           };
            int result = ExecuteSpPut(parameterList.ToArray(), SprPutJobsDetails);

            return result;
        }

        public DataSet PostList(PostListInput input)
        {
            var parameterList = new List<SqlParameter>
           {
               new SqlParameter("@q",input.q),
               new SqlParameter("@pageNo", input.pageNo),
               new SqlParameter("@pageSize", input.pageSize),
               new SqlParameter("@locationId", input.locationId),
               new SqlParameter("@departmentId", input.departmentId)


           };
            DataSet result = ExecuteSpGet(parameterList.ToArray(), SprPostList);

            return result; 
        }

        public object CreateDepartment(CreateDepartmentInput input)
        {
            var parameterList = new List<SqlParameter>
           {
               new SqlParameter("@title",input.Title)


           };
            DataSet result = ExecuteSpGet(parameterList.ToArray(), SprCreatedepart);
            if (result == null) return null;

            return result.Tables[0];
        }


        public int PutDepartment(PutDepartmentInput input, int id)
        {
            var parameterList = new List<SqlParameter>
           {
               new SqlParameter("@ID",id),
               new SqlParameter("@title",input.Title)


           };
            int result = ExecuteSpPut(parameterList.ToArray(), SprPutDepartment);

            return result;
        }

        public object GetDepartment(int id)
        {
            var parameterList = new List<SqlParameter>
           {
               new SqlParameter("@ID",id)
           };
            DataSet result = ExecuteSpGet(parameterList.ToArray(), SprGetDepartment);
            if (result == null) return null;

            return result.Tables[0];

        }

        public object CreateLocation(CreateLocationInput input)
        {
            var parameterList = new List<SqlParameter>
           {
               new SqlParameter("@locTitle",input.Title),
               new SqlParameter("@city",input.City),
               new SqlParameter("@state",input.State),
               new SqlParameter("@country",input.Country),
               new SqlParameter("@zip",input.Zip)

           };
            DataSet result = ExecuteSpGet(parameterList.ToArray(), SprCreateLocation);
            if (result == null) return null;

            return result.Tables[0];
        }


        public int PutLocation(PutLocationInput input, int id)
        {
            var parameterList = new List<SqlParameter>
           {
               new SqlParameter("@ID",id),
               new SqlParameter("@locTitle",input.Title),
               new SqlParameter("@city",input.City),
               new SqlParameter("@state",input.State),
               new SqlParameter("@country",input.Country),
               new SqlParameter("@zip",input.Zip)


           };
            int result = ExecuteSpPut(parameterList.ToArray(), SprPutLocation);

            return result;
        }

        public object GetLocation(int id)
        {
            var parameterList = new List<SqlParameter>
           {
               new SqlParameter("@ID",id)
           };
            DataSet result = ExecuteSpGet(parameterList.ToArray(), SprGetLocation);
            if (result == null) return null;

            return result.Tables[0];

        }


    }
}
