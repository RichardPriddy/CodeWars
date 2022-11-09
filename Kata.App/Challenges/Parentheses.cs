namespace CodeWars.App.Challenges
{
    public class Parentheses
    {
        public static bool ValidParentheses(string input)
        {
            var mem = 0;
            foreach (var x in input.ToCharArray())
            {
                if (x == '(') mem++;
                else if (x == ')') mem--;

                if (mem < 0) return false;
            }
            return mem == 0;
        }
    }
}
