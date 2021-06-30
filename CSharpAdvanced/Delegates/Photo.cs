using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAdvanced.Delegates
{
    class Photo
    {
        public static Photo Load(string path)
        {
            return new Photo();
        }

        public void Save()
        {
            //Console.WriteLine("Save photo");
        }
    }
}
