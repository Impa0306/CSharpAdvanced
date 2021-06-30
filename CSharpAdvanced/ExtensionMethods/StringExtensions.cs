using System;
using System.Linq;

/*namespace CSharpAdvanced.ExtensionMethods*/
namespace System
{
    public static class StringExtensions //Static class
    {
        public static string Shorten(this String str, int numberOfWords) //Static Method with 'this' argument
        {
            if (numberOfWords < 0)
                throw new ArgumentOutOfRangeException("numberOfWords should be greater than or equal to 0!");

            if(numberOfWords == 0)
                return "";

            var words = str.Split(' ');

            if (words.Length <= numberOfWords)
                return str;

            return string.Join(" ", words.Take(numberOfWords)) + "..."; //Take() is an extension method (built-in) that applies on any class that implements IEnnumerable interface
        }
    }
}
