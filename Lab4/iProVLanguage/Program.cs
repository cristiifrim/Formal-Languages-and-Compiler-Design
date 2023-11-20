using iProVLanguage.Scanner;
using iProVLanguage.Table;
using iProVLanguage.Utils;
using System.Text.RegularExpressions;

BaseProgram main = new BaseProgram();
main.Run();

public class BaseProgram
{
    private SymbolTable identifierSymbolTable;
    private SymbolTable constantSymbolTable;
    private ProgramInternalForm pif;
    private Scanner scanner;

    public BaseProgram()
    {
        identifierSymbolTable = new SymbolTable();
        constantSymbolTable = new SymbolTable();
        pif = new ProgramInternalForm();
        scanner = new Scanner();
    }

    public void Run()
    {
        LanguageSymbols.ReadFile();
        string fileName = ProgramPaths.Problem3;
        string exceptionMessage = "";
        FiniteAutomata faConstants = FiniteAutomata.ReadFromFile(InputPaths.FiniteAutomataConstants);
        FiniteAutomata faIdentifiers = FiniteAutomata.ReadFromFile(InputPaths.FiniteAutomataIdentifiers);

        using (StreamReader file = new StreamReader(fileName))
        {
            int lineCounter = 0;
            string line;
            while ((line = file.ReadLine()) != null)
            {
                lineCounter++;
                string[] tokens = scanner.Tokenize(line.Trim()).ToArray();
                string extra = "";
                for (int i = 0; i < tokens.Length; i++)
                {
                    if (LanguageSymbols.ReservedWords.Contains(tokens[i]) || LanguageSymbols.Separators.Contains(tokens[i]) || LanguageSymbols.Operators.Contains(tokens[i]))
                    {
                        if (tokens[i] == " ")
                            continue;

                        pif.Add(tokens[i], -1);
                    }
                    else if (Array.Exists(scanner.Cases, element => element == tokens[i]) && i < tokens.Length - 1)
                    {
                        if (Regex.IsMatch(tokens[i + 1], "[1-9]"))
                        {
                            pif.Add(tokens[i].Substring(0, tokens[i].Length - 1), -1);
                            extra = tokens[i][^1..];
                            continue;
                        }
                        else
                        {
                            exceptionMessage += $"Lexical error at token {tokens[i]}, at line {lineCounter}\n";
                        }
                    }
                    else if (faIdentifiers.IsAccepted(tokens[i]))
                    {
                        identifierSymbolTable.AddSymbol(tokens[i]);
                        pif.Add("id", identifierSymbolTable.GetSymbolValue(tokens[1]));
                    }
                    else if (faConstants.IsAccepted(tokens[i]))
                    {
                        constantSymbolTable.AddSymbol(extra + tokens[i]);
                        int constant = identifierSymbolTable.GetSymbolValue(extra + tokens[i]);
                        extra = "";
                        pif.Add("const", constant);
                    }
                    else
                    {
                        exceptionMessage += $"Lexical error at token {tokens[i]}, at line {lineCounter}\n";
                    }
                }
            }
        }

        using (StreamWriter writer = new StreamWriter(OutputPaths.SymbolTable))
        {
            writer.Write(identifierSymbolTable.ToString());
        }

        using (StreamWriter writer = new StreamWriter(OutputPaths.SymbolTable, true))
        {
            writer.Write(constantSymbolTable.ToString());
        }

        using (StreamWriter writer = new StreamWriter(OutputPaths.ProgramInternalForm))
        {
            writer.Write(pif.ToString());
        }

        if (string.IsNullOrEmpty(exceptionMessage))
        {
            Console.WriteLine("Lexically correct");
        }
        else
        {
            Console.WriteLine(exceptionMessage);
        }
    }
}
