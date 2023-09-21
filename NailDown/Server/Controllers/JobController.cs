using Microsoft.AspNetCore.Mvc;
using NailDown.Server.Repository;
using NailDown.Shared.Model;

namespace NailDown.Server.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase {
        private readonly IJob _job;

        public JobController(IJob job) {
            _job = job;
        }

        [HttpGet("job/create")]
        public async Task<JobModel> CreateJob(JobModel job) {
            return await _job.Create(job);
        }

        [HttpGet("job/edit/{id}")]
        public async Task<bool> EditJob(uint id, JobModel job) {
            return await _job.Edit(id, job);
        }

        [HttpPut("job/delete/{id}")]
        public async Task<bool> DeleteJob(uint id) {
            return await _job.Delete(id);
        }

        [HttpGet("job/{id}")]
        public async Task<JobModel> GetJob(uint id) {
            return await _job.GetJob(id);
        }

        [HttpGet]
        public async Task<List<JobModel>> GetJobs() {
            return await _job.GetJobs();
        }
    }
}
