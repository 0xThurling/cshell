// Wait for user input
while (true)
{
    // Uncomment this line to pass the first stage
    Console.Write("$ ");
    
    string? userInput = Console.ReadLine();

    if (!string.IsNullOrEmpty(userInput))
    {
        string[] commandArguments = userInput.Split(' ');

        if (commandArguments[0].Equals("exit"))
        {
            Environment.Exit(int.Parse(commandArguments.Last()));
        }
        
        Console.WriteLine($"{userInput}: command not found");
    }
}
