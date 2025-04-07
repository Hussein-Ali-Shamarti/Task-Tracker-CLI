using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using TaskTracker.Models; // Importing TaskItem and Status from TaskTracker.Models

namespace TaskTracker.Services
{
    public class TaskManager
    {
        private List<TaskItem> tasks = new();
        private const string FileName = "tasks.json";
        private int nextId = 1;

        public TaskManager()
        {
            if (File.Exists(FileName))
            {
                var json = File.ReadAllText(FileName);

                // Deserialize with enum handling
                tasks = JsonSerializer.Deserialize<List<TaskItem>>(json, new JsonSerializerOptions
                {
                    Converters = { new JsonStringEnumConverter() }
                }) ?? new List<TaskItem>();
            }
        }

        private void Save() =>
            // Serialize with enum handling
            File.WriteAllText(FileName, JsonSerializer.Serialize(tasks, new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters = { new JsonStringEnumConverter() } // Adding converter for proper enum handling
            }));

        private TaskItem? GetById(int id) => tasks.FirstOrDefault(t => t.Id == id);

        public void Add(string description)
        {
            var task = new TaskItem
            {
                Id = tasks.Count > 0 ? tasks.Max(t => t.Id) + 1 : 1,
                Description = description,
                Status = Status.Todo, // Default status is Todo
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            tasks.Add(task);
            Save();
            Console.WriteLine($"Task added successfully (ID: {task.Id})");
        }

        public void Update(int id, string newDescription)
        {
            var task = GetById(id);
            if (task == null) { Console.WriteLine("Task not found."); return; }

            task.Description = newDescription;
            task.UpdatedAt = DateTime.Now;
            Save();
            Console.WriteLine("Task updated successfully.");
        }

        public void Delete(int id)
        {
            var task = GetById(id);
            if (task == null) { Console.WriteLine("Task not found."); return; }

            tasks.Remove(task);
            Save();
            Console.WriteLine("Task deleted.");
        }

        public void Mark(int id, Status status)
        {
            var task = GetById(id);
            if (task == null) { Console.WriteLine("Task not found."); return; }

            task.Status = status;
            task.UpdatedAt = DateTime.Now;
            Save();
            Console.WriteLine($"Task marked as {status}.");
        }

        public void List(string? filter = null)
        {
            var filteredTasks = filter switch
            {
                "done" => tasks.Where(t => t.Status == Status.Complete),
                "in-progress" => tasks.Where(t => t.Status == Status.InProgress),
                "todo" => tasks.Where(t => t.Status == Status.Todo),
                _ => tasks
            };

            foreach (var task in filteredTasks)
            {
                Console.WriteLine($"[{task.Id}] {task.Description} - {task.Status.ToString().ToUpper()} (Created: {task.CreatedAt}, Updated: {task.UpdatedAt})");
            }
        }
    }
}
