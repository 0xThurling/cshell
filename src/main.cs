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
            default:
                Console.WriteLine($"{commandArguments[0]}: command not found");
                break;
        }
    }
}
