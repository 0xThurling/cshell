using System.Net;
using System.Net.Sockets;

// Wait for user input
while (true)
{
    // Uncomment this line to pass the first stage
    Console.Write("$ ");
    
    string? userInput = Console.ReadLine();

    Console.WriteLine($"{userInput}: command not found");    
}
