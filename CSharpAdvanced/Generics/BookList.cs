using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAdvanced.Generics
{
    class BookList
    {
        //Generics

        /*public class BookList { 

            public void Add(Book book)
            {
                throw new NotImplementedException();
            }

            public Book this[int index]
            {
                get { throw new NotImplementedException();  }
            }
        }*/

        //Object is a parent class for every class in .NET
        //But this has a performance penalty - due to object store / boxing , casting
        /*public class ObjectList
        {
            public void Add(object value)
            {

            }

            public object this[int index]
            {
                get { throw new NotImplementedException();  }
            }
        }*/

        public class GenericDictionary<TKey, TValue>
        {
            public void Add(TKey key, TValue value)
            {

            }
        }

        public class GenericList<T>
            {
                public void Add(T value)
                {

                }

                public T this[int index]
                {
                    get { throw new NotImplementedException(); }
                }
            }
        }
}
