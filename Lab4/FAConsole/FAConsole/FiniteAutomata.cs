namespace FAConsole
{
    public class FiniteAutomata
    {
        public List<string> Q { get; set; }
        public List<string> E { get; set; }
        public string q0 { get; set; }
        public List<string> F { get; set; }
        public Dictionary<(string, string), List<string>> S { get; set; }

        public FiniteAutomata(List<string> Q, List<string> E, string q0, List<string> F, Dictionary<(string, string), List<string>> S)
        {
            this.Q = Q;
            this.E = E;
            this.q0 = q0;
            this.F = F;
            this.S = S;
        }

        public static List<string> GetLine(string line)
        {
            return line.Trim().Split(' ').Skip(2).ToList();
        }

        public static bool Validate(List<string> Q, List<string> E, string q0, List<string> F, Dictionary<(string, string), List<string>> S)
        {
            if (!Q.Contains(q0))
                return false;

            foreach (var f in F)
            {
                if (!Q.Contains(f))
                    return false;
            }

            foreach (var key in S.Keys)
            {
                var state = key.Item1;
                var symbol = key.Item2;

                if (!Q.Contains(state) || !E.Contains(symbol))
                    return false;

                foreach (var dest in S[key])
                {
                    if (!Q.Contains(dest))
                        return false;
                }
            }

            return true;
        }

        public static FiniteAutomata ReadFromFile(string fileName)
        {
            using (StreamReader file = new StreamReader(fileName))
            {
                List<string> Q = GetLine(file.ReadLine());
                List<string> E = GetLine(file.ReadLine());
                string q0 = GetLine(file.ReadLine())[0];
                List<string> F = GetLine(file.ReadLine());

                file.ReadLine();

                Dictionary<(string, string), List<string>> S = new Dictionary<(string, string), List<string>>();
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    var src = line.Trim().Split("->")[0].Trim().Replace("(", "").Replace(")", "").Split(",")[0];
                    var route = line.Trim().Split("->")[0].Trim().Replace("(", "").Replace(")", "").Split(",")[1];
                    var dst = line.Trim().Split("->")[1].Trim();

                    var key = (src, route);
                    if (S.ContainsKey(key))
                    {
                        S[key].Add(dst);
                    }
                    else
                    {
                        S[key] = new List<string> { dst };
                    }
                }

                if (!Validate(Q, E, q0, F, S))
                {
                    throw new Exception("Wrong input file.");
                }

                return new FiniteAutomata(Q, E, q0, F, S);
            }
        }

        public bool IsDfa()
        {
            foreach (var k in S.Keys)
            {
                if (S[k].Count > 1)
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsAccepted(string seq)
        {
            if (IsDfa())
            {
                var crt = q0;
                foreach (var symbol in seq)
                {
                    var key = (crt, symbol.ToString());
                    if (S.ContainsKey(key))
                    {
                        crt = S[key][0];
                    }
                    else
                    {
                        return false;
                    }
                }
                return F.Contains(crt);
            }
            return false;
        }

        public override string ToString()
        {
            return "Q = { " + string.Join(", ", Q) + " }\n" +
                   "E = { " + string.Join(", ", E) + " }\n" +
                   "q0 = { " + q0 + " }\n" +
                   "F = { " + string.Join(", ", F) + " }\n" +
                   "S = { " + SToString() + " } ";
        }

        private string SToString()
        {
            List<string> entries = new List<string>();
            foreach (var entry in S)
            {
                var key = entry.Key;
                var value = entry.Value;
                entries.Add($"({key.Item1}, {key.Item2}) -> {string.Join(", ", value)}");
            }
            return string.Join(", ", entries);
        }
    }
}
