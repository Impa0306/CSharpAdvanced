using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAdvanced.ExceptionHandling
{
    public class Calculator
    {
        public int Divide(int numerator, int denomenator)
        {
            return numerator / denomenator; //System.DivideByZeroException: 'Attempted to divide by zero.'

        }
    }
}
