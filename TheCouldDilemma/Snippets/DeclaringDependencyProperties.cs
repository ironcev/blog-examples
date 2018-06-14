using System.Windows;

namespace Snippets
{
    class MyClass
    {
        private int firstField, secondField, thirdField;

        static readonly DependencyProperty MyDependencyProperty =
            DependencyProperty.Register
            (
                "MyDependency", typeof(int), typeof(MyClass)
            );

        static readonly DependencyProperty MyOtherDependencyProperty;

        static readonly DependencyProperty
            MyFirstDependencyProperty = DependencyProperty.Register
            (
                "MyFirstDependency", typeof(int), typeof(MyClass)
            ),

            MySecondDependencyProperty = DependencyProperty.Register
            (
                "MySecondDependency", typeof(int), typeof(MyClass)
            ),

            MyThirdDependencyProperty = DependencyProperty.Register
            (
                "MyThirdDependency", typeof(int), typeof(MyClass)
            );

        static MyClass()
        {
            MyOtherDependencyProperty = DependencyProperty.Register
                (
                    "MyOtherDependency", typeof(int), typeof(MyClass)
                );
        }
    }
}