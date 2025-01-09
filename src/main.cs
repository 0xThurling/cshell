// Wait for user input
while (true)
{
    // Uncomment this line to pass the first stage
    Console.Write("$ ");
    
    string? userInput = Console.ReadLine();

    if (!string.IsNullOrEmpty(userInput))
    {
        string[] commandArguments = userInput.Split(' ');

        switch (commandArguments[0])
        {
            case "exit":
                Environment.Exit(int.Parse(commandArguments.Last()));
                break;
            case "echo":
                Console.WriteLine(string.Join(' ', commandArguments[1..]));
                break;
            case "type":
                HandleTypeCommand(commandArguments[1]);
                break;
            default:
                Console.WriteLine($"{commandArguments[0]}: command not found");
                break;
        }
    }
}

void HandleTypeCommand(string command)
{
    if (Constants.Commands.Any(c => c.Name.Equals(command) && c.Type.Equals("builtin")))
    {
        Command selectedCommand = Constants.Commands.FirstOrDefault(c => c.Name.Equals(command));
        
        Console.WriteLine($"{selectedCommand.Name} is a shell {selectedCommand.Type}");
    } else if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("PATH")))
    {
        string path = Environment.GetEnvironmentVariable("PATH")!;

        string[] paths = path!.Split(':');
        foreach (var p in paths)
        {
            string filePath = Path.Combine(p, command);
            if (File.Exists(filePath))
            {
                Console.WriteLine($"{command} is ${p}");
                return;
            }
        }
        
        Console.WriteLine($"{command}: not found");
    }
}
