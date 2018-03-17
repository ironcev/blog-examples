using System;
using System.Linq;
using static System.Console;

namespace Snippets
{
    class LocalFunctionsThatDoNotUseLocalVariables
    {
        void Method()
        {
            int localVariable = 0;
            WriteLine(localVariable);

            LocalFunction();

            void LocalFunction()
            {
                WriteLine("I do not use local variables.");
            }
        }
    }

    class LocalFunctionsThatUseLocalVariables
    {
        void Method()
        {
            int localVariable = 0;
            string otherLocalVariable = localVariable.ToString();

            LocalFunction();
            LocalFunctionWithParameters(localVariable, otherLocalVariable);

            void LocalFunction()
            {
                WriteLine($"I use {localVariable} and {otherLocalVariable}.");
            }

            void LocalFunctionWithParameters(int number, string text)
            {
                WriteLine($"I use {localVariable} and {otherLocalVariable}.");
            }
        }
    }

    class LocalFunctionsThatUseLocalVariablesAndClassInstanceMembers
    {
        private int _instanceField = 0;
        public string InstanceProperty => "";
        int InstanceMethod() => 0;

        void Method()
        {
            int localVariable = 0;
            string otherLocalVariable = localVariable.ToString();
            WriteLine(otherLocalVariable);

            LocalFunction();

            void LocalFunction()
            {
                WriteLine($"I use {localVariable} and {otherLocalVariable}.");
                WriteLine($"I use {_instanceField}.");
                WriteLine($"I use {InstanceProperty}.");
                WriteLine($"I call {InstanceMethod()}.");
            }
        }
    }

    class LocalFunctionsThatUseLocalVariablesAndIsUsedInLambdaExpressions
    {
        void Method()
        {
            int localVariable = 0;
            string otherLocalVariable = localVariable.ToString();
            WriteLine(otherLocalVariable);

            Enumerable.Range(0, 10).Where(i => !LocalFunction());

            bool LocalFunction()
            {
                WriteLine($"I use {localVariable} and {otherLocalVariable}.");
                return true;
            }
        }
    }

    class LocalFunctionsThatUseOnlySomeLocalVariables
    {
        void Method()
        {
            int localVariable = 0;
            string otherLocalVariable = localVariable.ToString();
            WriteLine(otherLocalVariable);

            LocalFunction();

            void LocalFunction()
            {
                WriteLine($"I use only the local variable {localVariable}.");
            }
        }
    }

    class LocalFunctionsThatUseLocalVariablesDifferentThanThoseUsedInALambdaExpression
    {
        void Method()
        {
            int localVariable = 0;
            string otherLocalVariable = localVariable.ToString();

            Action lambdaThatUsesOtherLocalVariable =() => WriteLine(otherLocalVariable);

            LocalFunction();

            void LocalFunction()
            {
                WriteLine($"I use only the local variable {localVariable}.");
            }
        }
    }
}