using System.IO;
using Helpers;

string? cntStr = new("Lorem ipsum dolor sit amet,consectetur adipiscing elit. Nunc accumsan sem ut ligula scelerisque sollicitudin. Ut at sagittis augue. Praesent quis rhoncus justo. Aliquam erat volutpat. Donec sit amet suscipit metus, non lobortis massa. Vestibulum augue ex, dapibus ac suscipit vel, volutpat eget massa. Donec nec velit non ligula efficitur luctus.");
string? filePath = @$"{Directory.GetCurrentDirectory()}\test.txt";
string? userInput;
Counter cntr = new();

Console.WriteLine("Read from file [n]? ");
userInput = Console.ReadLine();
if (userInput.Length == 0 || userInput.ToLower().Contains('n')) {
    Console.WriteLine("Enter string: ");
    userInput = Console.ReadLine();
    if ((userInput != null
          && !String.Equals(userInput, ""))) {
        cntStr = userInput;
    }
    cntr.Add(cntStr);
} else {
    Console.WriteLine("Enter file path: ");
    userInput = Console.ReadLine();
    if (userInput != null && !String.Equals(userInput, "")) {
        filePath = userInput;
    }
    if (!File.Exists(filePath)) {
        Console.WriteLine($"Sorry could not find '{filePath}'.");
        return;
    }
    using StreamReader sr = File.OpenText(filePath);
    cntStr = sr.ReadLine();
    while (cntStr != null) {
        cntr.Add(cntStr);
        cntStr = sr.ReadLine();
    }
}

Console.WriteLine(cntr.ToSB());