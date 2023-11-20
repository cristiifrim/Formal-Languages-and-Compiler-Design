namespace iProVLanguage.Utils
{
    public class ProgramInternalForm
    {
        private List<Tuple<string, int>> _content;

        public ProgramInternalForm()
        {
            _content = new List<Tuple<string, int>>();
        }

        public void Add(string token, int pos)
        {
            _content.Add(new Tuple<string, int>(token, pos));
        }

        public override string ToString()
        {
            string result = "";
            foreach (var pair in _content)
            {
                result += pair.Item1 + "->" + pair.Item2 + "\n";
            }
            return result;
        }
    }
}
