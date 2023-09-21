using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NailDown.Server.Data;
using NailDown.Shared.Model;

namespace NailDown.Server.Repository {
    public class Job : IJob {
        private readonly AppDBContext _context;

        public Job(AppDBContext context) {
            _context = context;
        }

        [HttpPost(nameof(Create))]
        public async Task<JobModel> Create(JobModel job) {
            job.Status = JobStatus.Todo;
            job.LastEditDate = DateTime.Now;

            var model = await _context.Jobs.AddAsync(job);

            return model.Entity;
        }

        public async Task<bool> Edit(uint id, JobModel job) {
            var result = await _context.Jobs.FindAsync(id);

            if (result != null) {
                result.Title = job.Title;
                result.Description = job.Description;
                result.Status = job.Status;
                result.LastEditDate = DateTime.Now;

                _context.Entry(result).State = EntityState.Modified;
                _context.SaveChanges();

                return true;
            }
            else {
                return false;
            }
        }

        [HttpPut(nameof(Delete))]
        public async Task<bool> Delete(uint id) {
            var result = await _context.Jobs.FindAsync(id);

            if (result != null) {
                _context.Jobs.Remove(result);
                _context.SaveChanges();

                return true;
            }
            else {
                return false;
            }
        }

        [HttpGet(nameof(GetJob))]
        public async Task<JobModel> GetJob(uint id) {
            return await _context.Jobs.FirstOrDefaultAsync(j => j.Id == id) ?? JobModel.GetDefault();
        }

        [HttpGet]
        public async Task<List<JobModel>> GetJobs() {
            return await _context.Jobs.ToListAsync();
        }
    }
}
