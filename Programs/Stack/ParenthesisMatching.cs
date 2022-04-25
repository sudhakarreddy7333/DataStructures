using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgorithms.Programs.Stack
{
    //ParenthesisMatching pm = new ParenthesisMatching();
    //Console.WriteLine(pm.IsMatching("(a + b) + (c+ (d *  2))")); //true
    //Console.WriteLine(pm.IsMatching("(a + b) + (c+ (d *  2)")); //false
    //Console.WriteLine(pm.IsMatching("(a + b) + (c+ (d *  2)))")); //false
    //Console.WriteLine(pm.IsMatching("(a + b) + (c+ (d *  2))(")); //false 
    //Console.WriteLine(pm.IsMatching("((a + b) + c) + (c+ (d *  2))")); //true
    public class ParenthesisMatching
    {
        
        public bool IsMatching(string expression)
        {
            if (expression == null)
                return false;

            char[] expChars = expression.ToCharArray();
            StackLinkedList<char> ls = new StackLinkedList<char>();

            foreach (char c in expChars)
            {
                if(c == '(')
                {
                    ls.Push(c);
                }
                else if(c == ')')
                {
                    if (ls.IsEmpty() == true)
                        return false;

                    ls.Pop();
                }
            }

            return ls.IsEmpty();
        }

        //Console.WriteLine(pm.IsMatchingBrackets("[(a + b) + (c+d)]")); //true
        //Console.WriteLine(pm.IsMatchingBrackets("[(a + b] + (c+d)")); //false
        //Console.WriteLine(pm.IsMatchingBrackets("[(a + b]} + (c+d)")); //false
        //Console.WriteLine(pm.IsMatchingBrackets("[{(a + b)}] + (c+d)")); //true
        //Console.WriteLine(pm.IsMatchingBrackets("[{(a + b)}] + {{c+d}")); //false
        public bool IsMatchingBrackets(string expression)
        {
            if (expression == null)
                return false;

            char[] expChars = expression.ToCharArray();
            StackLinkedList<char> ls = new StackLinkedList<char>();

            foreach (char c in expChars)
            {
                if (c == 40 || c == 91 || c== 123) //Ascii 40 {, 91 [, 123 {
                {
                    ls.Push(c);
                }
                else if (c == 41 || c == 93 || c == 125)
                {
                    if (ls.IsEmpty() == true)
                        return false;

                    var p = ls.Pop();

                    int diff = c - p;

                    bool v = diff == 1 || diff == 2 || diff == 3; // comparing ascii values of parenthesis to identify if popped out element is a matched parenthesis.
                    if (!v)
                    {
                        return false;
                    }
                }
            }

            return ls.IsEmpty();
        }
    }
}
