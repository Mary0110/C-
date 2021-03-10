using System;
using System.Collections.Generic;

namespace Calculator
{
    class Calculator
    {
        private static bool IsOperator(char d)
        {
            bool isOp = false;
            if (d >= '(' && d < '0' && d != '.'|| d == '^')
            {
                isOp = true;
            }
            return isOp;
        }
        private static int Priority(char action)
        {
            int pr = 0;

            switch (action)
            {
                case '^':
                    pr = 5;
                    break;
                case '*':
                case '/':
                    pr = 4;
                    break;
                case '-':
                case '+':
                    pr = 3;
                    break;
                case '(':
                    pr = 2;
                    break;
                case ')':
                    pr = 1;
                    break;
            }
            return pr;
        }
        public static string ToPolishNotation(string exp)
        {
            string cleanExp = string.Empty;
            Stack<char> operators = new Stack<char>();

            for (int i = 0; i < exp.Length; i++)
            {
                if (!IsOperator(exp[i]))      //if number
                {
                   do
                   {
                        cleanExp += exp[i];
                        
                        i++;

                   }while (i != exp.Length &&!IsOperator(exp[i]));
                   cleanExp += ' ';
                    i--;
                }
                else if (IsOperator(exp[i]))        //if operator
                {
                    if (exp[i] == '(')
                    {
                        operators.Push(exp[i]);   
                    }
                    else if (exp[i] == ')')
                    {
                        char c = '0';
                        while(true)
                        {
                            c = operators.Pop();
                            if (c == '(')
                                break;
                            cleanExp += c.ToString();     
                        }
                    }
                    else
                    {
                        if (operators.Count != 0)     
                        {
                            if (Priority(exp[i]) <= Priority(operators.Peek()))  //check for higher priority operators in stack  
                            {
                                cleanExp += operators.Pop().ToString();          //remove operators from stack to string
                            }
                        }
                        operators.Push(exp[i]);
                    }
                }
            }

            while (operators.Count != 0)         //remove all operators from the stack to string
            {
                cleanExp += operators.Pop();
            }
            return cleanExp;
        }
        public static double Calculate(string clExpr)
        {
            Stack<double> st = new Stack<double>(); 

            for (int i = 0; i < clExpr.Length; i++)
            {
                 if (!IsOperator(clExpr[i]))     //if a number
                 {  
                    string num = string.Empty;

                    do
                    {
                        num += clExpr[i];
                        i++;
                    } while (i != clExpr.Length && clExpr[i] != ' ');

                    double number;
                    
                    if (Double.TryParse(num, out number))
                    {
                        st.Push(number);
                    }
                 }

                else if (IsOperator(clExpr[i]))                         //if operator
                {
                    double num1 = double.NaN, num2 = double.NaN;
                    if (st.Count != 0)
                    {
                        num1 = st.Pop();
                        num2 = st.Pop();
                    }
                    double result = double.NaN;

                    switch (clExpr[i]) 
                    {
                        case '+': 
                            result = num2 + num1;
                            break;
                        case '-': 
                            result = num2 - num1;
                            break;
                        case '*': 
                            result = num2 * num1; 
                            break;
                        case '/':
                            if (num1 != 0)
                            {
                                result = num2 / num1;
                            }
                            break;
                        case '^':
                            if (num1 != 0 && num2 != 0)
                            {
                                result = Math.Pow(num2, num1); 
                            }
                            break;
                    }
                    st.Push(result); 
                }
            }
            return st.Peek();
        }
        public static double Summarize(string str)
        {
            string clstr = ToPolishNotation(str);
            double res = Calculate(clstr);
            return res;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;
            Console.WriteLine("Calculating arithmetic expression in C#\n");
            Console.WriteLine("------------------------\n");

            while (!endApp)
            {
                string expr = string.Empty;
                int br1 = 0, br2 = 0;
                Console.Write("Type an expression, and then press Enter:");
                expr = Console.ReadLine();
                for (int i = 0; i < expr.Length; i++)
                {
                    if (!(expr[i] >= '(' && expr[i] <= '9' || expr[i] == '^'))
                    {
                        Console.Write("This is not valid input. Please enter numbers and operators: ");
                        expr = Console.ReadLine();
                        i = -1;

                    }
                         //if ',' is used
                    else if (expr[i] == ',')            
                    {
                        Console.Write("This is not valid input. Please use '.' instead of ',': ");
                        expr = Console.ReadLine();
                        i = -1;
                    }
                         //if two adjusting operators 
                    else if (i > 0 && expr[i] < '0' && expr[i] > ')' && expr[i - 1] < '0' && expr[i - 1] > ')')
                    {
                        Console.Write("This is not valid input. Please do not miss numbers: ");
                        expr = Console.ReadLine();
                        i = -1;
                    }
                    //if first element is operator
                    else if (i == 0 && expr[i] < '0' && expr[i] > '(')
                    {
                        Console.Write("This is not valid input. Please do not begin with operators: ");
                        expr = Console.ReadLine();
                        i = -1;
                    }
                    //if last el is operator
                    else if (i == expr.Length - 1 && (expr[i] < '0'))
                    {
                        Console.Write("This is not valid input. Please do not finish with operators: ");
                        expr = Console.ReadLine();
                        i = -1;
                    }
                    else if(expr[i] == '(')
                    {
                        br1++;
                    }
                    else if (expr[i] == ')')
                    {
                        br2++;
                        if (br1 == 0)
                        {
                            Console.Write("This is not valid input. Please do not begin with ')': ");
                            expr = Console.ReadLine();
                            i = -1;
                        }
                    }
                    else if(i == expr.Length - 1 && br1 != br2)
                    {
                        Console.Write("This is not valid input. Please close all brackets: ");
                        expr = Console.ReadLine();
                        i = -1;
                    }
                }
                
              
                double result = Calculator.Summarize(expr);
                if (double.IsNaN(result))
                {
                    Console.WriteLine("This operation will result in a mathematical error.\n");
                }
                else Console.WriteLine("Your result: " + result);

                Console.WriteLine("------------------------\n");
                
                Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
                if (Console.ReadLine() == "n") endApp = true;

                Console.WriteLine("\n"); 
            }
        }
    }
}