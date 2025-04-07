# Task-Tracker-CLI
Task tracker is a project used to track and manage your tasks.

Project Task URL: [Task Tracker Roadmap](https://roadmap.sh/projects/task-tracker)
GitHub Repository: [Task Tracker CLI GitHub](https://github.com/Hussein-Ali-Shamarti/Task-Tracker-CLI)

Task Tracker is a simple command-line interface (CLI) tool used to track and manage your tasks. This project allows you to add, update, delete, mark, and list tasks, all from the command line. The tasks are stored in a JSON file, which is automatically created if it does not already exist.

Installation
Follow these steps to run the application:

Clone the repo:


Rediger
git clone https://github.com/Hussein-Ali-Shamarti/Task-Tracker-CLI.git
Navigate to the project folder:


cd Task-Tracker-CLI
Build the project:

dotnet build
Run the project:


dotnet run
Features
Add, update, and delete tasks.

Mark tasks as in-progress or complete.

List all tasks, or filter tasks by status (complete, todo, in-progress).

Requirements
The application should run from the command line and accept user actions and inputs as arguments.

Uses a JSON file (tasks.json) to store tasks in the current directory.

If the JSON file does not exist, it will be automatically created.

The application utilizes the .NET System.Text.Json module to serialize and deserialize data.

TaskItem Model
The tasks are represented by the TaskItem class, which includes the following properties:

Id: Unique identifier for each task.

Description: A brief description of the task.

Status: Represents the status of the task, which is an enum with three possible values:

Todo (0) - The task is not started yet.

InProgress (1) - The task is being worked on.

Complete (2) - The task is completed.

CreatedAt: The timestamp when the task was created.

UpdatedAt: The timestamp when the task was last updated.

Example of a TaskItem in JSON format:
{
    "Id": 1,
    "Description": "Complete the project documentation",
    "Status": 0,  // Status: 0 represents "Todo"
    "CreatedAt": "2025-04-07T12:47:37.409378+02:00",
    "UpdatedAt": "2025-04-07T12:48:34.073923+02:00"
}
Commands
Here is a list of available commands and their usage:

Adding a New Task
Adds a new task with a description.


task-cli add "Buy groceries"
Updating and Deleting Tasks
Update a task: Changes the description of an existing task by its ID.


task-cli update 1 "Buy groceries and cook dinner"
Delete a task: Deletes a task by its ID.


task-cli delete 1
Marking a Task as In Progress, Complete, or Todo
You can update the status of a task using the following commands:

Mark a task as "In Progress": Updates the task status to InProgress.


task-cli mark-in-progress 1
Mark a task as "Complete": Updates the task status to Complete.

task-cli mark-complete 1
Mark a task as "Todo": Updates the task status to Todo.


task-cli mark-todo 1
Listing Tasks
List all tasks: Displays all tasks.


task-cli list
List tasks by status: Filter tasks by status (complete, todo, in-progress).


task-cli list complete
task-cli list todo
task-cli list in-progress
Example Usage
Add a new task:


task-cli add "Complete the assignment"
List all tasks:


task-cli list
Mark a task as "In Progress":


task-cli mark-in-progress 1
Update a task:


task-cli update 1 "Complete the assignment and submit"
Delete a task:


task-cli delete 1
File Structure
The application relies on the following file structure:

tasks.json: The JSON file where the tasks are stored.

