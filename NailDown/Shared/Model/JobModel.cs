using System.ComponentModel.DataAnnotations;

namespace NailDown.Shared.Model {
    public class JobModel {
        [Key]
        public uint Id { get; set; }
        [Required]
        public string Title { get; set; } = "";
        public string? Description { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public TimeSpan RelativeTime { get => DateTime.Now - CreatedDate; }
    }
}
