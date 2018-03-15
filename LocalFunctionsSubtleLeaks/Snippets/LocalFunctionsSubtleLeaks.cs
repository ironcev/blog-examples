using System;
using System.Linq;
using static System.Console;

namespace Snippets
{
    class LocalFunctionThatDoNotUseLocalVariables
    {
        void Method()
        {
            int a = 0;
            WriteLine(a);

            LocalFunction();

            void LocalFunction()
            {
                WriteLine("I do not use local variables.");
            }
        }
    }

    class LocalFunctionThatUseLocalVariables
    {
        void Method()
        {
            int a = 0;
            string s = a.ToString();

            LocalFunction();
            LocalFunctionWithParameters(a, s);

            void LocalFunction()
            {
                WriteLine($"I use local variables {a} and {s}.");
            }

            void LocalFunctionWithParameters(int number, string text)
            {
                WriteLine($"I use local variables {a} and {s}.");
            }
        }
    }

    class LocalFunctionThatUseLocalVariablesAndClassInstanceMembers
    {
        private int _intField = 0;
        public string StringProperty => "";
        int SomeInstanceMethod() => 0;

        void Method()
        {
            int a = 0;
            string s = a.ToString();
            WriteLine(s);

            LocalFunction();

            void LocalFunction()
            {
                WriteLine($"I use local variables {a} and {s}.");
                WriteLine($"I use instance field {_intField}.");
                WriteLine($"I use instance property {StringProperty}.");
                WriteLine($"I call instance method {SomeInstanceMethod()}.");
            }
        }
    }

    class LocalFunctionThatUseLocalVariablesAndIsUsedInLambdaExpressions
    {
        void Method()
        {
            int a = 0;
            string s = a.ToString();
            WriteLine(s);

            Enumerable.Range(0, 10).Where(i => !LocalFunction());

            bool LocalFunction()
            {
                WriteLine($"I use local variables {a} and {s}.");
                return true;
            }
        }
    }

    class LocalFunctionThatUseOnlySomeLocalVariables
    {
        void Method()
        {
            int a = 0;
            string s = a.ToString();
            WriteLine(s);

            LocalFunction();

            void LocalFunction()
            {
                WriteLine($"I use only the local variable {a}.");
            }
        }
    }

    class LocalFunctionThatUseLocalVariablesDifferentThanThoseUsedInALambdaExpression
    {
        void Method()
        {
            int a = 0;
            string s = a.ToString();

            Action lambdaThatUsesOtherLocalVariable =() => WriteLine(s);

            LocalFunction();

            void LocalFunction()
            {
                WriteLine($"I use only the local variable {a}.");
            }
        }
    }
}