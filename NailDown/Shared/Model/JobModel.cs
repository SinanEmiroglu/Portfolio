using System.ComponentModel.DataAnnotations;

namespace NailDown.Shared.Model {
    public enum JobStatus {
        Todo,
        Doing,
        Done
    }

    public class JobModel {
        [Key]
        public uint Id { get; set; }
        [Required]
        public string Title { get; set; } = "";
        public string? Description { get; set; }
        [Required]
        public JobStatus Status { get; set; } = JobStatus.Todo;
        [Required]
        public DateTime LastEditDate { get; set; }
        public TimeSpan RelativeTime { get => DateTime.Now - LastEditDate; }

        public static JobModel GetDefault() {
            JobModel model = new JobModel();
            model.Id = 0;
            model.Title = "Default";
            model.Description = null;
            model.Status = JobStatus.Todo;
            model.LastEditDate = DateTime.Now;

            return model;
        }
    }
}
