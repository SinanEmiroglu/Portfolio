using Microsoft.AspNetCore.Mvc;
using NailDown.Server.Repository;
using NailDown.Shared.Model;

namespace NailDown.Server.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase {
        private IJob _job;

        public JobController(IJob job) {
            _job = job;
        }

        [HttpPost("create")]
        public async Task<bool> CreateJob(JobModel job) {
            return await _job.Create(job);
        }

        [HttpGet("edit/{id}")]
        public async Task<bool> EditJob(uint id, JobModel job) {
            return await _job.Edit(id, job);
        }

        [HttpPut("delete/{id}")]
        public async Task<bool> DeleteJob(uint id) {
            return await _job.Delete(id);
        }

        [HttpGet("{id}")]
        public async Task<JobModel> GetJob(uint id) {
            return await _job.GetJob(id);
        }

        [HttpGet]
        public async Task<List<JobModel>> GetJobs() {
            return await _job.GetJobs();
        }
    }
}
