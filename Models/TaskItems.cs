using System;

namespace TaskTracker.Models
{
    public enum Status
    {
        Todo,
        InProgress,
        Complete
    }

    public class TaskItem
    {
        public int Id { get; set; }
        public required string Description { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
