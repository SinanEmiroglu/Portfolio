using NailDown.Shared.Model;

namespace NailDown.Server.Repository {
    public interface IJob {
        public Task<bool> Create(JobModel job);
        public Task<bool> Edit(uint id, JobModel job);
        public Task<bool> Delete(uint id);
        public Task<JobModel> GetJob(uint id);
        public IAsyncEnumerable<JobModel> GetJobs();
    }
}
