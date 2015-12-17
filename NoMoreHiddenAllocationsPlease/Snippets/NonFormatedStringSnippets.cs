using System;
using System.IO;
using SwissKnife;

// ReSharper disable once CheckNamespace
namespace Snippets.FormattedStringSnippets
{
    // ReSharper disable UnusedParameter.Local
    public class WithoutArgumentClass
    {
        public void SomePublicMethod(string key, object value, string fileName)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Key cannot be null or whitespace.", "key");
            if (value == null)
                throw new ArgumentNullException("value");
            if (string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentException("File name cannot be null or whitespace.", "fileName");
            if (!File.Exists(fileName))
                throw new ArgumentException("File does not exist.", "fileName");

            // Do something useful here.
        }
    }

    public class ArgumentClassWithOptions
    {
        //  IL_0000:  ldarg.1
        //  IL_0001:  ldstr      "key"
        //  IL_0006:  call       valuetype Option`1<!0> valuetype Option`1<string>::op_Implicit(!0)
        //  IL_000b:  call       void Argument::IsNotNullOrWhitespace(string, valuetype Option`1<string>)

        public void SomePublicMethod(string key, object value, string fileName)
        {
            Argument.IsNotNullOrWhitespace(key, "key");
            Argument.IsNotNull(value, "value");
            Argument.IsNotNullOrWhitespace(fileName, "fileName");
            Argument.IsValid(File.Exists(fileName), "File does not exist.", "fileName");

            // Do something useful here.
        }

        private static class Argument
        {
            public static void IsNotNullOrWhitespace(string parameterValue, Option<string> parameterName)
            {
                IsNotNullOrEmpty(parameterValue, parameterName);
                if (string.IsNullOrWhiteSpace(parameterValue)) // Argument is surely not null or empty. We are actually checking for white spaces.
                    throw new ArgumentException("Parameter value must not be white space.", parameterName.ValueOrNull);
            }

            private static void IsNotNullOrEmpty(string parameterValue, Option<string> parameterName)
            {
                IsNotNull(parameterValue, parameterName);
                if (string.IsNullOrEmpty(parameterValue)) // Argument is surely not null. We are actually checking for empty string.
                    throw new ArgumentException("Parameter value must not be empty string.", parameterName.ValueOrNull);
            }

            public static void IsNotNull(object parameterValue, Option<string> parameterName)
            {
                if (parameterValue == null)
                    throw new ArgumentNullException(parameterName.ValueOrNull);
            }

            public static void IsValid(bool validityCondition, Option<string> exceptionMessage, Option<string> parameterName)
            {
                if (!validityCondition)
                    throw new ArgumentException(exceptionMessage.ValueOrNull, parameterName.ValueOrNull);
            }
        }
    }

    public class ArgumentClassWithStrings
    {
        //  IL_0000:  ldarg.1
        //  IL_0001:  ldstr      "key"
        //  IL_0006:  call       void Argument::IsNotNullOrWhitespace(string, string)

        public void SomePublicMethod(string key, object value, string fileName)
        {
            Argument.IsNotNullOrWhitespace(key, "key");
            Argument.IsNotNull(value, "value");
            Argument.IsNotNullOrWhitespace(fileName, "fileName");
            Argument.IsValid(File.Exists(fileName), "File does not exist.", "fileName");

            // Do something useful here.
        }

        private static class Argument
        {
            public static void IsNotNullOrWhitespace(string parameterValue, string parameterName)
            {
                IsNotNullOrEmpty(parameterValue, parameterName);
                if (string.IsNullOrWhiteSpace(parameterValue)) // Argument is surely not null or empty. We are actually checking for white spaces.
                    throw new ArgumentException("Parameter value must not be white space.", parameterName);
            }

            private static void IsNotNullOrEmpty(string parameterValue, string parameterName)
            {
                IsNotNull(parameterValue, parameterName);
                if (string.IsNullOrEmpty(parameterValue)) // Argument is surely not null. We are actually checking for empty string.
                    throw new ArgumentException("Parameter value must not be empty string.", parameterName);
            }

            public static void IsNotNull(object parameterValue, string parameterName)
            {
                if (parameterValue == null)
                    throw new ArgumentNullException(parameterName);
            }

            public static void IsValid(bool validityCondition, string exceptionMessage, string parameterName)
            {
                if (!validityCondition)
                    throw new ArgumentException(exceptionMessage, parameterName);
            }
        }
    }    
    // ReSharper restore UnusedParameter.Local
}
