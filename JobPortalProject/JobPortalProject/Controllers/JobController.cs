using Microsoft.AspNetCore.Mvc;
using JobPortalProject.Model;
using JobPortalProject.Repository;
using JobPortalProject.Interface;
namespace JobPortalProject.Controllers
{
    [ApiController]    
    public class JobController : Controller
    {
        private readonly IService _Service;
        public JobController(IService Service)
        {
           _Service = Service;
        }
        [HttpGet]
        [Route("v1/job/{id:int}")]
        public async Task<IActionResult> GetJob(int id)
        {
            List<JobModel> dr = _Service.GetJobDetails(id);
            return Ok(await Task.FromResult(dr));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [Route("v1/job/create")]
        public async Task<IActionResult> CreateJob([FromBody]JobDetailsInput input)
        {
            CreateJobSaveModel dr = _Service.CreateJobDetails(input);
            return Ok(await Task.FromResult(dr));
        }

        [HttpPut]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [Route("v1/job/update")]
        public async Task<IActionResult> PutJob([FromBody] PutJobInput input,[FromQuery] int id)
        {
            int dr = _Service.PutJobDetails(input,id);
            return Ok();
        }
        
        [HttpPost]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [Route("v1/job/list")]
        public async Task<IActionResult> PostListJob([FromBody] PostListInput input)
        {
            List<PostListModel> dr = _Service.PostList(input);
            return Ok(await Task.FromResult(dr));
        }
       
    }
}
