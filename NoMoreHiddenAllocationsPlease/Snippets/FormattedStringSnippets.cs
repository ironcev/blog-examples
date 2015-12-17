using System;
using System.Collections.Generic;
using System.IO;

// ReSharper disable once CheckNamespace
namespace Snippets.FormattedStringSnippets
{
    // ReSharper disable UnusedParameter.Local
    public class WithStringFormat
    {
        //  IL_0006:  ldstr      "The directory '{0}' does not exist and something was: {1}."
        //  IL_000b:  ldarg.1
        //  IL_000c:  ldarg.2
        //  IL_000d:  call       string [mscorlib]System.String::Format(string,object,object)
        //  IL_0012:  ldstr      "directory"
        //  IL_0017:  call       void Argument::IsValid(bool,string,string)

        public void SomePublicMethod(string directory, string something)
        {
            Argument.IsValid(Directory.Exists(directory),
                             string.Format("The directory '{0}' does not exist and something was: {1}.", directory, something),
                             "directory");            

            // Do something useful here.
        }

        public void SomePublicMethod(string directory, object userMessage, Solution solution, Project project)
        {
            Argument.IsValid(Directory.Exists(directory),
                             string.Format("The directory '{0}' does not exist.", directory),
                             "directory");
            Argument.IsValid(!(userMessage is WeeklyNewsletter),
                 string.Format("Only simple user messages like e.g. '{1}' can be deleted using the '{2}' command.{0}" +
                               "Weekly newsletter must be deleted by using the '{3}'.",
                               Environment.NewLine,
                               typeof(UserRegistered).Name,
                               typeof(DeleteUserMessageCommand).Name,
                               typeof(WeeklyNewsletterEntityDeleter).Name
                               ),
                 "userMessage");
            Argument.IsValid(solution.Projects.Contains(project),
                 string.Format("The project must be contained in the solution.{0}" +
                               "The solution '{1}' does not contain the project '{2}'.",
                               Environment.NewLine,
                               solution.FileName,
                               project.ProjectName),
                               "project");

            // Do something useful here.
        }

        public class Solution
        {
            public string FileName { get; set; }
            public List<Project> Projects { get; set; }
        }

        public class Project
        {
            public string ProjectName { get; set; }
        }

        private class WeeklyNewsletter { }
        private class UserRegistered { }
        private class DeleteUserMessageCommand { }
        private class WeeklyNewsletterEntityDeleter { }

        private static class Argument
        {
            public static void IsValid(bool validityCondition, string exceptionMessage, string parameterName)
            {
                if (!validityCondition)
                    throw new ArgumentException(exceptionMessage, parameterName);
            }
        }
    }

    public class WithLambdaExpression
    {
        //  .locals init ([0] class '<>c__DisplayClass1' 'CS$<>8__locals2')
        //  IL_0000:  newobj     instance void '<>c__DisplayClass1'::.ctor()
        //  IL_0005:  stloc.0
        //  IL_0006:  ldloc.0
        //  IL_0007:  ldarg.1
        //  IL_0008:  stfld      string '<>c__DisplayClass1'::directory
        //  IL_000d:  ldloc.0
        //  IL_000e:  ldarg.2
        //  IL_000f:  stfld      string '<>c__DisplayClass1'::something
        //  IL_0014:  ldloc.0
        //  IL_0015:  ldfld      string '<>c__DisplayClass1'::directory
        //  IL_001a:  call       bool [mscorlib]System.IO.Directory::Exists(string)
        //  IL_001f:  ldstr      "directory"
        //  IL_0024:  ldloc.0
        //  IL_0025:  ldftn      instance string '<>c__DisplayClass1'::'<SomePublicMethod>b__0'()
        //  IL_002b:  newobj     instance void class [mscorlib]System.Func`1<string>::.ctor(object,native int)
        //  IL_0030:  call       void Argument::IsValid(bool,string,class [mscorlib]System.Func`1<string>)

        public void SomePublicMethod(string directory, string something)
        {
            Argument.IsValid(Directory.Exists(directory),
                             "directory",
                             () => string.Format("The directory '{0}' does not exist and something was: {1}.", directory, something));

            // Do something useful here.
        }

        class CompilerGeneratedClass
        {
            // ReSharper disable InconsistentNaming
            public string directory;
            public string something;
            // ReSharper restore InconsistentNaming

            public string Method()
            {
                return string.Format("The directory '{0}' does not exist and something was: {1}.", directory, something);
            }
        }

        public void SomePublicMethodExplained(string directory, string something)
        {
            var capturedVariables = new CompilerGeneratedClass {directory = directory, something = something};
            var lambda = new Func<string>(capturedVariables.Method);

            Argument.IsValid(Directory.Exists(directory),
                             "directory",
                             lambda);

            // Do something useful here.
        }

        public string Something { get; set; }

        public void SomeOtherPublicMethod(string directory)
        {
            Argument.IsValid(Directory.Exists(directory),
                             "directory",
                             () => string.Format("The directory '{0}' does not exist and something was: {1}.", directory, Something));

            // Do something useful here.
        }

        private static class Argument
        {
            public static void IsValid(bool validityCondition, string parameterName, Func<string> exceptionMessage)
            {
                if (!validityCondition)
                    throw new ArgumentException(exceptionMessage(), parameterName);
            }
        }
    }

    public class WithParams
    {
        //  IL_0006:  ldstr      "directory"
        //  IL_000b:  ldstr      "The directory '{0}' does not exist and something was: {1}."
        //  IL_0010:  ldc.i4.2
        //  IL_0011:  newarr     [mscorlib]System.Object
        //  IL_0016:  stloc.0
        //  IL_0017:  ldloc.0
        //  IL_0018:  ldc.i4.0
        //  IL_0019:  ldarg.1
        //  IL_001a:  stelem.ref
        //  IL_001b:  ldloc.0
        //  IL_001c:  ldc.i4.1
        //  IL_001d:  ldarg.2
        //  IL_001e:  stelem.ref
        //  IL_001f:  ldloc.0
        //  IL_0020:  call       void Argument::IsValid(bool,string,string,object[])
        public void SomePublicMethod(string directory, string something)
        {
            Argument.IsValid(Directory.Exists(directory),
                             "directory",
                             "The directory '{0}' does not exist and something was: {1}.", directory, something);

            // Do something useful here.
        }

        private static class Argument
        {
            public static void IsValid(bool validityCondition, string parameterName, string format, params object[] args)
            {
                if (!validityCondition)
                    throw new ArgumentException(string.Format(format, args), parameterName);
            }            
        }
    }

    public class WithObjectArguments
    {
        //  IL_0006:  ldstr      "directory"
        //  IL_000b:  ldstr      "The directory '{0}' does not exist and something was: {1}."
        //  IL_0010:  ldarg.1
        //  IL_0011:  ldarg.2
        //  IL_0012:  call       void Argument::IsValid(bool,string,string,object,object)

        public void SomePublicMethod(string directory, string something)
        {
            Argument.IsValid(Directory.Exists(directory),
                             "directory",
                             "The directory '{0}' does not exist and something was: {1}.", directory, something);

            // Do something useful here.
        }

        //  IL_0006:  ldstr      "directory"
        //  IL_000b:  ldstr      "The directory '{0}' does not exist and something was: {1}."
        //  IL_0010:  ldarg.1
        //  IL_0011:  ldarg.2
        //  IL_0012:  box        [mscorlib]System.Int32
        //  IL_0017:  call       void Argument::IsValid(bool,string,string,object,object)
        public void SomePublicMethod(string directory, int something)
        {
            Argument.IsValid(Directory.Exists(directory),
                             "directory",
                             "The directory '{0}' does not exist and something was: {1}.", directory, something);

            // Do something useful here.
        }

        private static class Argument
        {
            public static void IsValid(bool validityCondition, string parameterName, string format, object arg0, object arg1)
            {
                if (!validityCondition)
                    throw new ArgumentException(string.Format(format, arg0, arg1), parameterName);
            }
        }
    }

    public class WithGenericArguments
    {
        //  IL_0006:  ldstr      "directory"
        //  IL_000b:  ldstr      "The directory '{0}' does not exist and something was: {1}."
        //  IL_0010:  ldarg.1
        //  IL_0011:  ldarg.2
        //  IL_0012:  call       void Argument::IsValid<string,string>(bool,string,string,!!0,!!1)
        public void SomePublicMethod(string directory, string something)
        {
            Argument.IsValid(Directory.Exists(directory),
                             "directory",
                             "The directory '{0}' does not exist and something was: {1}.", directory, something);

            // Do something useful here.
        }

        //  IL_0006:  ldstr      "directory"
        //  IL_000b:  ldstr      "The directory '{0}' does not exist and something was: {1}."
        //  IL_0010:  ldarg.1
        //  IL_0011:  ldarg.2
        //  IL_0012:  call       void Argument::IsValid<string,int32>(bool,string,string,!!0,!!1)
        public void SomePublicMethod(string directory, int something)
        {
            Argument.IsValid(Directory.Exists(directory),
                             "directory",
                             "The directory '{0}' does not exist and something was: {1}.", directory, something);

            // Do something useful here.
        }

        private static class Argument
        {
            // ReSharper disable once UnusedMember.Local
            public static void IsValid(bool validityCondition, string parameterName, string exceptionMessage)
            {
                if (!validityCondition)
                    throw new ArgumentException(exceptionMessage, parameterName);
            }

            // ReSharper disable once UnusedMember.Local
            public static void IsValid<TArg0>(bool validityCondition, string parameterName, string format, TArg0 arg0)
            {
                if (!validityCondition)
                    throw new ArgumentException(string.Format(format, arg0), parameterName);
            }

            public static void IsValid<TArg0, TArg1>(bool validityCondition, string parameterName, string format, TArg0 arg0, TArg1 arg1)
            {
                if (!validityCondition)
                    throw new ArgumentException(string.Format(format, arg0, arg1), parameterName);
            }
        }
    }

    public class WithDynamicArguments
    {
        public void SomePublicMethod(dynamic argument)
        {
            Argument.IsValid(IsArgumentThisAndThat(argument),
                             "argument",
                             "The argument is not this and that: {0}.", argument);

            // Do something useful here.
        }

        public void SomeOtherPublicMethod(dynamic argument)
        {
            Argument.IsValid(true,
                             "argument",
                             "The argument is not this and that: {0}.", argument);

            // Do something useful here.
        }

        public void SomeOtherPublicMethodWithoutIsValid(dynamic argument)
        {
            if (IsArgumentThisAndThat(argument))
                throw new ArgumentException(string.Format("The argument is not this and that: {0}.", argument), "argument");

            // Do something useful here.
        }

        private bool IsArgumentThisAndThat(dynamic argument)
        {
            return true;
        }

        private static class Argument
        {
            // ReSharper disable once UnusedMember.Local
            public static void IsValid<TArg0>(bool validityCondition, string parameterName, string format, TArg0 arg0)
            {
                if (!validityCondition)
                    throw new ArgumentException(string.Format(format, arg0), parameterName);
            }
        }
    }    
    // ReSharper restore UnusedParameter.Local
}
