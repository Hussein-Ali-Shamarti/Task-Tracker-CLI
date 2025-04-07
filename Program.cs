using System;
using System.Linq;
using TaskTracker.Models; // Importing the TaskTracker.Models namespace to access Status enum
using TaskTracker.Services;

var argsList = args.ToList();
if (argsList.Count == 0)
{
    Console.WriteLine("Usage: task-cli [add|update|delete|mark-todo|mark-in-progress|mark-done|list] ...");
    return;
}

var command = argsList[0];
var taskManager = new TaskManager();

switch (command)
{
    case "add":
        if (argsList.Count < 2) { Console.WriteLine("Description required."); break; }
        taskManager.Add(argsList[1]);
        break;

    case "update":
        if (argsList.Count < 3 || !int.TryParse(argsList[1], out var updId)) { Console.WriteLine("Usage: update [id] [new description]"); break; }
        taskManager.Update(updId, argsList[2]);
        break;

    case "delete":
        if (argsList.Count < 2 || !int.TryParse(argsList[1], out var delId)) { Console.WriteLine("Usage: delete [id]"); break; }
        taskManager.Delete(delId);
        break;

    case "mark-todo":
        if (argsList.Count < 2 || !int.TryParse(argsList[1], out var todoId)) { Console.WriteLine("Usage: mark-todo [id]"); break; }
        taskManager.Mark(todoId, Status.Todo); // Mark as Todo
        break;

    case "mark-in-progress":
        if (argsList.Count < 2 || !int.TryParse(argsList[1], out var progId)) { Console.WriteLine("Usage: mark-in-progress [id]"); break; }
        taskManager.Mark(progId, Status.InProgress); // Mark as InProgress
        break;

    case "mark-done":
        if (argsList.Count < 2 || !int.TryParse(argsList[1], out var doneId)) { Console.WriteLine("Usage: mark-done [id]"); break; }
        taskManager.Mark(doneId, Status.Complete); // Mark as Complete
        break;

    case "list":
        string? filter = argsList.Count > 1 ? argsList[1] : null;
        taskManager.List(filter);
        break;

    default:
        Console.WriteLine("Unknown command.");
        break;
}
