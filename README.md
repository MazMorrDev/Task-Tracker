# TaskTracker CLI by MazMorrDev

Welcome my friend :D, this is a little project to get familiar with the .NET CLI. You are free to follow the Quick Start section to test the project

## Quick Start

 1 - You just need .NET 9.0 installed in your device.

 2 - Clone the project

```bash
git clone 'https://github.com/MazMorrDev/Task-Tracker.git'
```

3 - Then just run:

```bash
dotnet run
```

## Available Commands

```bash
help - Show available commands

create 'description' - Create a new task

edit <id> 'new description' - Edit a task

delete <id> - Delete a task

update -p <id> - Update task to "In Progress"

update -c <id> - Update task to "Completed"

list - List all tasks

list -h - List "To Do" tasks

list -p - List "In Progress" tasks

list -c - List "Completed" tasks

exit - Exit the application
```

## Usage Examples

```bash
create 'Buy groceries'
edit 1 'Buy groceries and cook dinner'
delete 2
update -p 1
update -c 1
list -p
```

## Requirements

- .NET 9.0 SDK

### Any suggestion will be helpful :D
