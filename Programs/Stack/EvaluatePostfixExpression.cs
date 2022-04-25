using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgorithms.Programs.Stack
{
    //InfixToPostfixConversion infixToPostfix = new InfixToPostfixConversion();
    //string post = infixToPostfix.ConvertWithBrackets("6+2+2^3");

    //EvaluatePostfixExpression p = new EvaluatePostfixExpression();
    //Console.WriteLine(p.EvaluatePostfix(post));
    public class EvaluatePostfixExpression
    {
        public int EvaluatePostfix(string postfixExpression)
        {
            StackLinkedList<int> stack = new StackLinkedList<int>();

            foreach (char c in postfixExpression)
            {
                if (IsOperand(c))
                {
                    int.TryParse(c.ToString(), out int o);
                    stack.Push(o);
                }
                else
                {
                    int.TryParse(stack.Pop().ToString(), out int operand2); //convert stored ascii characters in stack to integers. 
                    int.TryParse(stack.Pop().ToString(), out int operand1);

                    switch (c)
                    {
                        case '+':
                            int a = operand1 + operand2;
                            stack.Push(a);
                            break;
                        case '-':
                            char s = (char)(operand1 - operand2);
                            stack.Push(s);
                            break;
                        case '*':
                            int m = operand1 * operand2;
                            stack.Push(m);
                            break;
                        case '/':
                            int d = operand1 / operand2;
                            stack.Push(d);
                            break;
                        case '^':
                            int p = (int)Math.Pow(operand1, operand2);
                            stack.Push(p);
                            break;
                    }
                }
            }

            return stack.Pop();
        }

        private bool IsOperand(char element)
        {
            if (element == '!' || element == '+' || element == '-' || element == '/' || element == '*' || element == '^')
                return false;

            return true;
        }
    }
}
