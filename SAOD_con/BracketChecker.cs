namespace SAOD_con
{

    public class BracketChecker
    {
        public static bool Check(string text)
        {
            MyStack<char> stack = new MyStack<char>(text.Length);

            for (int i = 0; i <= text.Length - 1; i++)
            {
                switch (text[i])
                {
                    case '(':
                    case '{':
                    case '[':
                    case '<':
                        stack.Push(text[i]);
                        break;

                    case ')':
                        if (stack.GetLength() == 0) return false;
                        if (stack.Pop() != '(') return false;
                        break;

                    case '}':
                        if (stack.GetLength() == 0) return false;
                        if (stack.Pop() != '{') return false;
                        break;

                    case ']':
                        if (stack.GetLength() == 0) return false;
                        if (stack.Pop() != '[') return false;
                        break;

                    case '>':
                        if (stack.GetLength() == 0) return false;
                        if (stack.Pop() != '<') return false;
                        break;

                    default:
                        break;
                }
            }

            return stack.GetLength() == 0;
        }
    }
}