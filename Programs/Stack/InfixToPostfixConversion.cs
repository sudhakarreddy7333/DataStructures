using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgorithms.Programs.Stack
{
    public class InfixToPostfixConversion
    {
        public string Convert(string infixExpression)
        {
            string postFixExpression = null;
            StackLinkedList<char> st = new StackLinkedList<char>();

            foreach(char s in infixExpression)
            {
                if (IsOperand(s) == false)
                {
                    while (st.IsEmpty() == false && GetPreceedence(s) <= GetPreceedence(st.Peek()))
                    {
                        postFixExpression += st.Pop();
                    }
                }
                st.Push(s);
            }

            while (st.IsEmpty() == false)
            {
                postFixExpression += st.Pop();
            }

            return postFixExpression;
        }

        public string ConvertWithBrackets(string infixExpression)
        {
            ParenthesisMatching pm = new ParenthesisMatching();
            bool isMatching = pm.IsMatching(infixExpression);

            if (isMatching == false)
                throw new Exception("Parenthesis not matching");

            string postFixExpression = null;
            StackLinkedList<char> st = new StackLinkedList<char>();

            foreach (char s in infixExpression)
            {
                while (st.IsEmpty() == false && GetOutStackPreceedence(s) <= GetInStackPreceedence(st.Peek()))
                {
                    if(GetInStackPreceedence(st.Peek()) == GetOutStackPreceedence(s))
                    {
                        st.Pop();
                    }
                    else
                    {
                        postFixExpression += st.Pop();
                    }
                }
                if(s != ')')
                {
                    st.Push(s);
                }
            }

            while (st.IsEmpty() == false)
            {
                postFixExpression += st.Pop();
            }

            return postFixExpression;
        }

        private bool IsOperand(char element)
        {
            if (element == '!' || element == '+' || element == '-' || element == '/' || element == '*' || element == '^')
                return false;

            return true;
        }

        private int GetPreceedence(char element)
        {
            if (element == '+' || element == '-')
                return 1;
            else if (element == '*' || element == '/')
                return 2;
            else if (IsOperand(element))
                return 3;

            return 0;
        }


        private int GetOutStackPreceedence(char element)
        {
            if (element == '+' || element == '-')
                return 1;
            else if (element == '*' || element == '/')
                return 3;
            else if (element == '^')
                return 6; //R to L Association
            else if (element == '(')
                return 7;
            else if (element == ')')
                return 0;
            else if (IsOperand(element))
                return 8;

            return -1;
        }

        private int GetInStackPreceedence(char element)
        {
            if (element == '+' || element == '-')
                return 2;
            else if (element == '*' || element == '/')
                return 4;
            else if (element == '^')
                return 5; //R to L Association
            else if (element == '(')
                return 0;
            else if (IsOperand(element))
                return 9;

            return 0;
        }

    }
}
