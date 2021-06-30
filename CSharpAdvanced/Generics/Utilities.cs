using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAdvanced.Generics
{
    // adding constraints - 5 types
    // where T : IComparable - applying to the interface
    // where T : Product - applying to a class
    // where T : struct - to be value type
    // where T : class - reference type
    // where T : new() - default construtor

    public class Utilities<T> where T : IComparable, new()
    {
        public int Max(int a, int b)
        {
            return a > b ? a : b;
        }

        public void DoSomething(T value)
        {
            var obj = new T(); //implement default constructor to the class- new()
        }

        //Generic version of above method
        /*public T Max<T>(T a, T b) where T : IComparable*/
        public T Max(T a, T b) 
        {
            return a.CompareTo(b) > 0 ? a : b;
        }
    }
}
