using JobPortalProject.Repository;
using System.Data.SqlClient;
using System.Data;
using JobPortalProject.Model;
using JobPortalProject.Interface;
namespace JobPortalProject.Service
{
    public class Service : IService
    {
        readonly IRepositoryJob _IRepositoryJob;

        public Service(IRepositoryJob RepositoryJob)
        {
            _IRepositoryJob = RepositoryJob;
        }
        public List<JobModel> GetJobDetails(int id)
        {
            var model = new List<JobModel>();
            locationModel loc = new locationModel();
            DepartmentModel depart = new DepartmentModel();
            DataTable result = (DataTable)_IRepositoryJob.GetJobDetails(id);

            foreach (DataRow dr in result.Rows)
            {
                JobModel details = new JobModel();
                details.Location = loc;
                details.Department = depart;
                details.Id = (Int32)dr["Id"];
                details.Code = dr["Code"].ToString();
                details.Title = dr["Title"].ToString();
                details.Description = dr["Description"].ToString();
                loc.Id = (Int32)dr["locId"];
                loc.Title = dr["locTitle"].ToString();
                loc.City = dr["city"].ToString();
                loc.State = dr["state"].ToString();
                loc.Country = dr["country"].ToString();
                loc.Zip = (Int32)dr["zip"];                
                depart.Id = (Int32)dr["depTID"];
                depart.Title = dr["deptTitle"].ToString();
                details.PostedDate = (DateTime)dr["PostedDate"];
                details.ClosingDate = (DateTime)dr["ClosingDate"];
                model.Add(details);
            }
            return model;
        }

        public CreateJobSaveModel CreateJobDetails(JobDetailsInput input)
        {
            CreateJobSaveModel model = new CreateJobSaveModel();
            DataTable result = (DataTable)_IRepositoryJob.CreateJob(input);

            model.Id = (Int32)result.Rows[0]["Id"];


            return model;
            
        }

        public int PutJobDetails(PutJobInput input, int id)
        {
            int result = _IRepositoryJob.PutJobDetails(input,id);   
            return result;

        }

        public List<PostListModel> PostList(PostListInput input)
        {
            List<PostListModel> modelList = new List<PostListModel>();
            PostListModel model = new PostListModel();
            List<Data> dataList = new List<Data>();
            DataSet result = (DataSet)_IRepositoryJob.PostList(input);

            foreach (DataRow dr in result.Tables[0].Rows)
            {
                model.totalCount = (Int32)dr["Total"];
                model.data = new List<Data>();
                
                foreach (DataRow dataRow in result.Tables[1].Rows)
                {
                    Data data = new Data();
                    data.Id = (Int32)dataRow["Id"];
                    data.Code = dataRow["Code"].ToString();
                    data.Title = dataRow["Title"].ToString();
                    data.Location = dataRow["location"].ToString();
                    data.Department = dataRow["department"].ToString();
                    data.PostedDate = (DateTime)dataRow["PostedDate"];
                    data.ClosingDate = (DateTime)dataRow["ClosingDate"];
                    model.data.Add(data);
                 }
                
                modelList.Add(model);

             }
            return modelList;
        }

        public DepartmentSaveModel CreateDepartment(CreateDepartmentInput input)
        {
            DepartmentSaveModel model = new DepartmentSaveModel();
            DataTable result = (DataTable)_IRepositoryJob.CreateDepartment(input);

            model.Id = (Int32)result.Rows[0]["Id"];


            return model;

        }

        public int PutDepartment(PutDepartmentInput input, int id)
        {
            int result = _IRepositoryJob.PutDepartment(input, id);
            return result;

        }

        public List<DepartmentModel> GetDepartment(int id)
        {
            var model = new List<DepartmentModel>();            
            DataTable result = (DataTable)_IRepositoryJob.GetDepartment(id);

            foreach (DataRow dr in result.Rows)
            {
                DepartmentModel depart = new DepartmentModel();
                depart.Id = (Int32)dr["departmentId"];
                depart.Title = dr["deptTitle"].ToString();
                model.Add(depart);
            }
            return model;
        }

        public LocationSaveModel CreateLocation(CreateLocationInput input)
        {
            LocationSaveModel model = new LocationSaveModel();
            DataTable result = (DataTable)_IRepositoryJob.CreateLocation(input);

            model.Id = (Int32)result.Rows[0]["Id"];



            return model;

        }

        public int PutLocation(PutLocationInput input, int id)
        {
            int result = _IRepositoryJob.PutLocation(input, id);
            return result;

        }

        public List<locationModel> GetLocation(int id)
        {
            var model = new List<locationModel>();
            DataTable result = (DataTable)_IRepositoryJob.GetLocation(id);

            foreach (DataRow dr in result.Rows)
            {
                locationModel loc = new locationModel();
                loc.Id = (Int32)dr["LocationId"];
                loc.Title = dr["locTitle"].ToString();
                loc.City = dr["city"].ToString();
                loc.State = dr["state"].ToString();
                loc.Country = dr["country"].ToString();
                loc.Zip = (Int32)dr["zip"];


                model.Add(loc);
            }
            return model;
        }



    }
}
