using FAConsole;

UserInterface userInterface = new UserInterface();
userInterface.Run();

class UserInterface
{
    private FiniteAutomata fa;

    private void ReadFA()
    {
        fa = FiniteAutomata.ReadFromFile(InputPaths.FiniteAutomata);
    }

    private void DisplayAll()
    {
        Console.WriteLine(fa);
    }

    private void DisplayStates()
    {
        Console.WriteLine(string.Join(", ", fa.Q));
    }

    private void DisplayAlphabet()
    {
        Console.WriteLine(string.Join(", ", fa.E));
    }

    private void DisplayTransitions()
    {
        foreach (var (key, value) in fa.S)
        {
            Console.WriteLine($"{key}: {string.Join(", ", value)}");
        }
    }

    private void DisplayFinalStates()
    {
        Console.WriteLine(string.Join(", ", fa.F));
    }

    private void CheckDFA()
    {
        Console.WriteLine(fa.IsDfa());
    }

    private void CheckAccepted()
    {
        Console.Write("Enter sequence: ");
        string seq = Console.ReadLine();
        Console.WriteLine(fa.IsAccepted(seq));
    }

    private void DisplayMenu()
    {
        Console.WriteLine("1. Read FA from file");
        Console.WriteLine("2. Display FA");
        Console.WriteLine("3. Display FA States");
        Console.WriteLine("4. Display FA Alphabet");
        Console.WriteLine("5. Display FA transitions");
        Console.WriteLine("6. Display FA final states");
        Console.WriteLine("7. Check DFA");
        Console.WriteLine("8. Check accepted sequence");
    }

    public void Run()
    {
        Dictionary<string, Action> commands = new Dictionary<string, Action>
        {
            {"1", ReadFA},
            {"2", DisplayAll},
            {"3", DisplayStates},
            {"4", DisplayAlphabet},
            {"5", DisplayTransitions},
            {"6", DisplayFinalStates},
            {"7", CheckDFA},
            {"8", CheckAccepted}
        };

        while (true)
        {
            DisplayMenu();
            Console.Write(">> ");
            string command = Console.ReadLine();

            if (commands.ContainsKey(command))
            {
                commands[command]();
            }
            else if (command == "exit")
            {
                break;
            }
        }
    }
}
