using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using static System.Console;

namespace Snippets.CompilerGenerated
{
    // See: https://sharplab.io/#v2:CYLg1APgAgDABFAjANgYgdAYQPYDsDO2ANgKYDcAsAFDVQBMcAMtgMYCGRUArAC4CWefABUAFmx4ARbADlsPAKr4SzdkQBqbAE582AI1L4AgrmCYibfPgCSBHm1wsSAWRIBbXSU35qAb2pwAhAAWOBceEWxgAAoASn9AvypA5Lg+XB44IlYODW09UjgAXjgYSiSUgIB1bR5lNJIorNVcnX0SGLL4ipUObn48WM7yiqgQns5eAVxYrpTEiorqvlrGeqiAIis4YGw4XDk4AFclTOyiOAA3LVaDdHWO2YW4JZW1ze3d/YzjkgQGNPwdgcv1cbg8XjuD2GKQAvrM4VQYUA==
    class LocalFunctionsThatDoNotUseLocalVariablesAndClassInstanceMembers
    {
        void Method()
        {
            int value = 0;
            WriteLine(value);
            LocalFunction();
        }

        [CompilerGenerated]
        internal static void LocalFunction()
        {
            WriteLine("I do not use local variables.");
            WriteLine("I do not use class instance members.");
        }
    }

    // See: https://sharplab.io/#v2:CYLg1APgAgDABFAjANgYgdAYQPYDsDO2ANgKYDcAsAFDVQBMcAMtgMYCGRUArAC4CWefABUAFmx4BVfCWbsiANTYAnPmwBGpfNQDe1OPoQAWOAFkSPEdmAAKAJR6DuqgZdw+uHnCKsOiletI4AF44GEpnV30keGwLEiVZX2VVDRJgrx8FZICSdCFsAGUeFVwAcztwh0jEzl4BXAqq1xrufjwAdT4LAAVlNgBbc3j8a285PxTSABo4WJF4momc20qIyKhjFrq8OyaXJ0jI9pUeGXcSawASACIASTgAV2k4bTGk/1SAXzg2XGAXuYLTJLL7oa4rPYGT7USFRTaZVr1To9PqDU5KEbuTy4B79NTxGbROCnAAePHsa1cB0OLmOXTOuAuN3uTzSr2B2S+Pz+ALiCQ5H1InzBEMpLmhlIlnyAA
    class LocalFunctionsThatUseLocalVariables
    {
        [CompilerGenerated]
        [StructLayout(LayoutKind.Auto)]
        internal struct CapturedVariables
        {
            public int localVariable;
            public string otherLocalVariable;
        }

        void Method()
        {
            CapturedVariables capturedVariables;
            capturedVariables.localVariable = 0;
            capturedVariables.otherLocalVariable = capturedVariables.localVariable.ToString();

            LocalFunction(ref capturedVariables);
            LocalFunctionWithParameters(capturedVariables.localVariable, capturedVariables.otherLocalVariable, ref capturedVariables);
        }

        [CompilerGenerated]
        internal static void LocalFunction(ref CapturedVariables ptr)
        {
            WriteLine($"I use {ptr.localVariable} and {ptr.otherLocalVariable}.");
        }

        [CompilerGenerated]
        internal static void LocalFunctionWithParameters(int number, string text, ref CapturedVariables ptr)
        {
            WriteLine($"I use {ptr.localVariable} and {ptr.otherLocalVariable}.");
        }
    }

    // See: https://sharplab.io/#v2:CYLg1APgAgDABFAjANgYgdAYQPYDsDO2ANgKYDcAsAFDVQBMcAMtgMYCGRUArAC4CWefABUAFmx4BVfCQDyuIgE8AytgC2JZuyIA1NgCc+bAEal81AN7U41hABY4AWRI8R2YAAoAlFZuWqNgLg+XB44IlYOXQNjUjgAXjgYSn9A6yR4bBcSPU1I/UMTEniwiJ18mJJ0IWwlHgNcAHMvZNTrAHUDHg1gkndMkWzcsujCz2SfVKHufjxm6gnAqHsp3gFcLwWAv1bAjr4uxh73ABIAIgBJOABXaTg8RTgskq04ADdywrhzcK0ogtIAL7oU5jTY2AELCFUAFAA==
    internal class LocalFunctionsThatUseOnlySomeLocalVariables
    {
        [CompilerGenerated]
        [StructLayout(LayoutKind.Auto)]
        internal struct CapturedVariables
        {
            public int localVariable;
        }

        void Method()
        {
            CapturedVariables capturedVariables;
            capturedVariables.localVariable = 0;

            string otherLocalVariable = capturedVariables.localVariable.ToString();

            WriteLine(otherLocalVariable);

            LocalFunction(ref capturedVariables);
        }

        [CompilerGenerated]
        internal static void LocalFunction(ref CapturedVariables ptr)
        {
            WriteLine($"I use only the local variable {ptr.localVariable}.");
        }
    }

    // See: https://sharplab.io/#v2:CYLg1APgAgDABFAjANgYgdAYQPYDsDO2ANgKYDcAsAFDVQBMcAMtgMYCGRUArAC4CWefABUAFmx4BVfCQDyuIgE9MRNvnwBJAjza4WJALIkAtgCMSAJ3zUA3tTj24AB3N8AbuJJw+uHnAD63vjauiQAYnwkRMBwALxwMJRUDggAzGjwmkE6egAK5tiOFjwKsQB8cABEFYnJ3r6ZwXqGPCLYwAAUAJRl8Yl2DlAALHDNrR2d/fa2SckOzOycvAK4XX0zswjD8xzc/Hhdk7PTGxsA6i48JIzeJO0AJBXqcACu0nDWAVrZYRFRAL7oCqdGonZLnPiXa64W4PJ6vTzWBrfPIFIoKAFAkGg+zgyE3e6POALIjvJEhUZtLoY4GHZJ/Q70qh/IA
    class LocalFunctionsThatUseOnlyClassInstanceMembers
    {
        private int _instanceField = 0;

        public string InstanceProperty => "";

        private int InstanceMethod() => 0;

        void Method()
        {
            LocalFunction();
        }

        [CompilerGenerated]
        private void LocalFunction()
        {
            WriteLine($"I use {_instanceField}.");
            WriteLine($"I use {InstanceProperty}.");
            WriteLine($"I call {InstanceMethod()}.");
        }
    }

    // See: https://sharplab.io/#v2:CYLg1APgAgDABFAjANgYgdAYQPYDsDO2ANgKYDcAsAFDVQBMcAMtgMYCGRUArAC4CWefABUAFmx4BVfCWbsiANTYAnPmwBGpfAEFcwTETb58ASQI82uFiQCyJALZqSS/NQDe1OJ7gAHFQDdxEjg+XB44AH0Q/HNLEgAxPhIiYDgAXjgYSiovBABmNHhTaIsrAAUlbG8nHgBPNIA+OAAiJqyckLCimKtbHhFsYAAKAEoGjKyPLygAFjhe/qHhyc93bJyvDrgiVg5FFXVSNPHl9aR4bD6nWV3lVQ0g9O25PbvSdCFsAGUeFVwAcxGbXWngA6ioeDIQiRBhcRFcdgpbgcSMMJmtgddOLwBLhAdQTjkZkwEdx+HgRgSvKtgcCwXwIYwoYMACRNYxwACu0jgrieN329wAvnALClXLD4c8kUL0E1UZTaeDIbhoaz2Vygq5ImYSvFEslBbL5eiaaClYyVSy2Zzua4urrypVqjVDXKgaazfTlarrXIiDz7bF5gMRq7jabBSdI1Ro0A==
    class LocalFunctionsThatUseLocalVariablesAndClassInstanceMembers
    {
        [CompilerGenerated]
        [StructLayout(LayoutKind.Auto)]
        internal struct CapturedVariables
        {
            public int localVariable;
            public string otherLocalVariable;
            public LocalFunctionsThatUseLocalVariablesAndClassInstanceMembers @this;
        }

        private int _instanceField = 0;
        public string InstanceProperty => "";
        private int InstanceMethod() => 0;

        void Method()
        {
            CapturedVariables capturedVariables;
            capturedVariables.@this = this;
            capturedVariables.localVariable = 0;
            capturedVariables.otherLocalVariable = capturedVariables.localVariable.ToString();
            WriteLine(capturedVariables.otherLocalVariable);

            LocalFunction(ref capturedVariables);
        }

        [CompilerGenerated]
        internal static void LocalFunction(ref CapturedVariables ptr)
        {
            WriteLine($"I use {ptr.localVariable} and {ptr.otherLocalVariable}.");
            WriteLine($"I use {ptr.@this._instanceField}.");
            WriteLine($"I use {ptr.@this.InstanceProperty}.");
            WriteLine($"I call {ptr.@this.InstanceMethod()}.");
        }

        // -------------------- Expected code --------------------
        [CompilerGenerated]
        [StructLayout(LayoutKind.Auto)]
        internal struct ExpectedCapturedVariables
        {
            public int localVariable;
            public string otherLocalVariable;
        }

        void ExpectedMethod()
        {
            ExpectedCapturedVariables expectedCapturedVariables;
            expectedCapturedVariables.localVariable = 0;
            expectedCapturedVariables.otherLocalVariable = expectedCapturedVariables.localVariable.ToString();
            WriteLine(expectedCapturedVariables.otherLocalVariable);

            ExpectedLocalFunction(ref expectedCapturedVariables);
        }

        private void ExpectedLocalFunction(ref ExpectedCapturedVariables ptr)
        {
            WriteLine($"I use {ptr.localVariable} and {ptr.otherLocalVariable}.");
            WriteLine($"I use {this._instanceField}.");
            WriteLine($"I use {this.InstanceProperty}.");
            WriteLine($"I call {this.InstanceMethod()}.");
        }
    }

    // See: https://sharplab.io/#v2:CYLg1APgAgDABFAjAOgDIEsB2BHA3AWAChYFEA2U5AYQHtMBnGgGwFMDCioAmOVGgYwCGTKAFYALujr0AKgAtB4gKr0WfIUwBqggE7pBAI1b0AgpmAmdLFS2ABJTKkEBbA8EEBRAB4AHK/XopBiIAbyI4CIQAFjgAWRZxORpgAAoASnDIsMJI3LgscTgmAWFtPUNWOABeOBh2PMikeBpElh11Ut19IxZqopKtLoqWZBkaAGVxPUwAc3T6hrgAdT1xNSwWFJa5No7B8p609kyGj0wAV2c24eQAJUFZzZgAGjhEGDTkJZ2rFPRqgB8cAAhHsxJI6OkjkQTnkDDRmLwBuCgulYblsos8it0GsMJhNgASABEdjg51UcBCxQ0ZW6rAAvnAHsAqdtdgM6cMGchidCcljGgB2OBTc5sdGRBmw6WEWVAA===
    class LocalFunctionsThatUseLocalVariablesAndAreUsedInLambdaExpressions
    {
        [CompilerGenerated]
        private sealed class Closure
        {
            public int localVariable;
            public string otherLocalVariable;

            internal bool Lambda(int i) => !LocalFunction();

            internal bool LocalFunction()
            {
                WriteLine($"I use {this.localVariable} and {this.otherLocalVariable}.");
                return true;
            }
        }

        private void Method()
        {
            Closure closure = new Closure();
            closure.localVariable = 0;
            closure.otherLocalVariable = closure.localVariable.ToString();
            WriteLine(closure.otherLocalVariable);
            Enumerable.Range(0, 10).Where(closure.Lambda);
        }
    }

    // See: https://sharplab.io/#v2:CYLg1APgAgDABFAjAbgLAChYMQNmwOgGEB7AOwGdiAbAUzXQygCY4AZYgYwEMqoBWAC4BLMuQAqACy4CAquRrtuVAGpcATkK4AjWuQAiQgGaGaamqQGSupScXlyawAJKkAgqy4BbLcC4BRAA8ABzNychFSDABvDDg4hAAWOABZGgEJYmAACgBKWPiY9HjiuCELOCpOHlUNbVo4AF44GHoS+KR4YnTTRWr1TR0aRoqqlX66mnwxYgBlAQ1SAHNc+ny2pBYqLx8uK1l5cgB5brVesdrB4dzGgD44AHUNAQUymiyuiR7RmoHaHNWim02KN+MIyCsMGsSlAkmdQRFclDioUgSVHkJnqxXlkACQAIiccAArvI4GQqABPODdEZKOAAN3GlyilSUPwmAF98Hj/kj4hyoQL0BygA
    class LocalFunctionsThatUseLocalVariablesDifferentThanThoseUsedInALambdaExpression
    {
        [CompilerGenerated]
        private sealed class Closure
        {
            public string otherLocalVariable;
            public int localVariable;

            internal void Lambda()
            {
                WriteLine(this.otherLocalVariable);
            }

            internal void LocalFunction()
            {
                WriteLine($"I use only the local variable {this.localVariable}.");
            }
        }

        void Method()
        {
            Closure closure = new Closure();
            closure.localVariable = 0;
            closure.otherLocalVariable = closure.localVariable.ToString();

            Action lambdaThatUsesOtherLocalVariable = new Action(closure.Lambda);

            closure.LocalFunction();
        }

        // -------------------- Expected code --------------------

        [CompilerGenerated]
        private sealed class ExpectedClosure
        {
            public string otherLocalVariable;

            internal void Lambda()
            {
                WriteLine(this.otherLocalVariable);
            }
        }

        [CompilerGenerated]
        [StructLayout(LayoutKind.Auto)]
        internal struct ExpectedCapturedVariables
        {
            public int localVariable;
        }

        void ExpectedMethod()
        {
            ExpectedCapturedVariables expectedCapturedVariables;
            ExpectedClosure closure = new ExpectedClosure();
            expectedCapturedVariables.localVariable = 0;
            closure.otherLocalVariable = expectedCapturedVariables.localVariable.ToString();

            Action lambdaThatUsesOtherLocalVariable = new Action(closure.Lambda);

            ExpectedLocalFunction(ref expectedCapturedVariables);
        }

        [CompilerGenerated]
        internal static void ExpectedLocalFunction(ref ExpectedCapturedVariables ptr)
        {
            WriteLine($"I use only the local variable {ptr.localVariable}.");
        }
    }

    // See: https://sharplab.io/#v2:CYLg1APgAgDABFAjAbgLAChYMQNmwOgGEB7AOwGdiAbAUzXQygCY4BlAVwCMAXWgWRoBbYgCcAngBkaAQwDWGAN4Y4KuAAcRASwBu07jQQsASjUrsRAYxoARIdNLBNpAOaEq08uTgK4AXwzKqkgsAtwAFsTAABQAlIEqSuiqyXC6InAipsTmVraC9o4uAPKcAFY0FtxwALxwpDQA7nAmZpY2dg5Oru6esfQpQYjwlII0EsQW0lQAatJa0py0NXAARCv08SnBcO6CnMDSACphegCq5KasxKPjkzNzmgtLtbE1AHxwAOpa+hJONFERmMJlNZvNFjQYhskgM4LcplAAKzcTRkY5nC7kY40FrZNp5ApdErlSp9AIwgZQADsO2kewO6O450u12BdzBjwh0NhCAALHCQVQkSi0ScmZjsbicu18p1imUKtxYptkokeclvppfv8ogASFYASTg7AucHCBgUmVauQ6hWcxMVvnwKyhKtU/gpfgwviAA===
    class SubtleMemoryLeak
    {
        private class ResourceDemandingClass { }

        [CompilerGenerated]
        private sealed class Closure
        {
            public string someLocalVariable;
            public ResourceDemandingClass resourceDemandingObject;
            internal void Lambda()
            {
                WriteLine(this.someLocalVariable);
            }

            internal void LocalFunctionThatUsesTheResourceDemandingObject()
            {
                WriteLine($"I use the {this.resourceDemandingObject}.");
            }
        }

        private Action Method()
        {
            Closure closure = new Closure();
            closure.resourceDemandingObject = new ResourceDemandingClass();
            closure.someLocalVariable = "";

            Action result = new Action(closure.Lambda);

            closure.LocalFunctionThatUsesTheResourceDemandingObject();

            return result;
        }
    }
}