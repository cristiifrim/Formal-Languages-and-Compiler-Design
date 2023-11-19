using iProVLanguage.Utils;
using System.Text.RegularExpressions;

namespace iProVLanguage.Scanner
{
    public class Scanner
    {
        public string[] Cases { get; } = new string[] { "=+", "<+", ">+", "<=+", ">=+", "==+", "!=+", "=-", "<-", ">-", "<=-", ">=-", "==-", "!=-" };

        public Tuple<string, int> GetStringToken(string line, int index)
        {
            var token = "";
            var quotes = 0;

            while (index < line.Length && quotes < 2)
            {
                if (line[index] == '\'')
                {
                    quotes += 1;
                }
                token += line[index];
                index += 1;
            }

            return Tuple.Create(token, index);
        }

        public bool IsPartOfOperator(char character)
        {
            foreach (var op in LanguageSymbols.Operators)
            {
                if (op.Contains(character))
                {
                    return true;
                }
            }
            return false;
        }

        public Tuple<string, int> GetOperatorToken(string line, int index)
        {
            var token = "";

            while (index < line.Length && IsPartOfOperator(line[index]))
            {
                token += line[index];
                index += 1;
            }

            return Tuple.Create(token, index);
        }

        public List<string> Tokenize(string line)
        {
            var token = "";
            var index = 0;
            var tokens = new List<string>();

            while (index < line.Length)
            {
                if (IsPartOfOperator(line[index]))
                {
                    if (!string.IsNullOrEmpty(token))
                    {
                        tokens.Add(token);
                    }
                    var result = GetOperatorToken(line, index);
                    token = result.Item1;
                    index = result.Item2;
                    tokens.Add(token);
                    token = "";
                }
                else if (line[index] == '\'')
                {
                    if (!string.IsNullOrEmpty(token))
                    {
                        tokens.Add(token);
                    }
                    var result = GetStringToken(line, index);
                    token = result.Item1;
                    index = result.Item2;
                    tokens.Add(token);
                    token = "";
                }
                else if (LanguageSymbols.Separators.Contains(line[index].ToString()))
                {
                    if (!string.IsNullOrEmpty(token))
                    {
                        tokens.Add(token);
                    }
                    token = line[index].ToString();
                    index += 1;
                    tokens.Add(token);
                    token = "";
                }
                else
                {
                    token += line[index];
                    index += 1;
                }
            }

            if (!string.IsNullOrEmpty(token))
            {
                tokens.Add(token);
            }

            return tokens;
        }

        public bool IsIdentifier(string token)
        {
            return Regex.IsMatch(token, @"^[a-z]([a-zA-Z]|[0-9])*$");
        }

        public bool IsConstant(string token)
        {
            return Regex.IsMatch(token, @"^(0|[+-]?[1-9][0-9]*)$|^\'.\'$|^\'.*\'$");
        }
    }

    public class LanguageSymbols
    {
        public static List<string> ReservedWords = new List<string>();
        public static List<string> Separators = new List<string>();
        public static List<string> Operators = new List<string>();

        public static void ReadFile()
        {
            using (StreamReader reader = new StreamReader(InputPaths.Tokens))
            {
                reader.ReadLine();
                for (int i = 0; i < 11; i++)
                {
                    string separator = reader.ReadLine().Trim();
                    if (separator == "<space>")
                    {
                        separator = " ";
                    }
                    Separators.Add(separator);
                }

                for (int i = 0; i < 14; i++)
                {
                    Operators.Add(reader.ReadLine().Trim());
                }

                for (int i = 0; i < 13; i++)
                {
                    ReservedWords.Add(reader.ReadLine().Trim());
                }
            }
        }
    }
}