using Microsoft.EntityFrameworkCore;
using NailDown.Server.Data;
using NailDown.Shared.Model;

namespace NailDown.Server.Repository {
    public class Job : IJob {
        private readonly AppDBContext _context;

        public Job(AppDBContext context) {
            _context = context;
        }

        public async Task<bool> Create(JobModel job) {
            var entity = await _context.Jobs.AddAsync(job);
            _context.SaveChanges();

            return entity.State == EntityState.Added;
        }

        public async Task<bool> Edit(uint id, JobModel job) {
            var entity = await _context.Jobs.FindAsync(id);

            if (entity != null) {
                entity.Title = job.Title;
                entity.Description = job.Description;
                entity.Status = job.Status;
                entity.LastEditDate = DateTime.Now;

                _context.SaveChanges();

                return true;
            }
            else {
                return false;
            }
        }

        public async Task<bool> Delete(uint id) {
            var entity = await _context.Jobs.FindAsync(id);

            if (entity != null) {
                _context.Jobs.Remove(entity);
                _context.SaveChanges();

                return true;
            }
            else {
                return false;
            }
        }

        public async Task<JobModel> GetJob(uint id) {
            return await _context.Jobs.FirstOrDefaultAsync(j => j.Id == id) ?? JobModel.GetDefault();
        }

        public async IAsyncEnumerable<JobModel> GetJobs() {
            await foreach (var job in _context.Jobs.AsAsyncEnumerable()) {
                yield return job;
            }
        }
    }
}
