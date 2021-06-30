using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using static CSharpAdvanced.Generics.BookList;
//using CSharpAdvanced.Generics.Nullable;
using CSharpAdvanced.Generics;
using CSharpAdvanced.Delegates;
using CSharpAdvanced.LambdaExpressions;
using CSharpAdvanced.EventsAndDelegates;
//using CSharpAdvanced.ExtensionMethods;
using CSharpAdvanced.Linq;
using CSharpAdvanced.ExceptionHandling;
using System.Threading.Tasks;
using System.Net;

namespace CSharpAdvanced
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //================================Generics================================
            var book = new Generics.Book { Isbn = "1111", Title = "C# Advanced" };

            /*var number = new List();
            number.Add(10);

            var books = new BookList();
            books.Add(book);*/

            var numbers = new GenericList<int>();
            numbers.Add(10);

            var books = new GenericList<Generics.Book>();
            books.Add(new Generics.Book());

            var dictionary = new GenericDictionary<string, Generics.Book>();
            dictionary.Add("1234", new Generics.Book());

            var number = new Generics.Nullable<int>(5);
            Console.WriteLine("Has Value ?" + number.HasValue);
            Console.WriteLine("Value : " + number.GetValueOrDefault());

            //================================Delegates================================
            var processor = new PhotoProcessors();
            var filters = new PhotoFilters();

            //PhotoProcessors.PhotoFilterHandler filterHandler = filters.ApplyBrightness;
            Action<Photo> filterHandler = filters.ApplyBrightness;
            filterHandler += filters.ApplyContrast;
            filterHandler += RemoveRedEye;

            processor.Process("photo.jpg", filterHandler);

            //================================Lambda Expression================================
            //Console.WriteLine(Square(5));
            //Using lambda expression ---> args => expression ---> number => number*number
            //Using Delegate ---> Func<int, int> square = Square; OR 
            Func<int, int> square = number => number * number;
            Console.WriteLine(square(5));

            //() => ... OR x => ... OR (x, y, z) => ...
            const int factor = 5;
            Func<int, int> multiplier = n => n * factor;
            var result = multiplier(10);
            Console.WriteLine(result);

            var books1 = new LambdaExpressions.BookRepository().GetBooks();
            //var cheapBooks = books1.FindAll(IsCheaperThan10Dollars);
            var cheapBooks = books1.FindAll(book1 => book1.Price < 10);
            foreach (var book1 in cheapBooks)
            {
                Console.WriteLine(book1.Title);
            }

            //================================Events================================
            var video = new EventsAndDelegates.Video() { Title = "Video 1"};
            var videoEncoder = new VideoEncoder(); //Publisher
            var mailService = new MailService(); //Subscriber
            var messageService = new MessageService();

            //Creating Subscribers
            videoEncoder.VideoEncoded += mailService.OnVideoEncoded; //Not making call to the method, basically assigning a reference / pointer
            videoEncoder.VideoEncoded += messageService.OnVideoEncoded; //publisher.event += how to subscribe 
            videoEncoder.Encode(video);

            //================================Extension Methods================================
            string post = "This is supposed to be a very long long long blog post blah blah blah .......";
            var shortenedPost = post.Shorten(5);
            Console.WriteLine(shortenedPost);

            IEnumerable<int> numbers1 = new List<int>() { 1, 5, 3, 10, 2, 8 };
            var max = numbers1.Max(); //LINQ method to query object
            Console.WriteLine(max);

            //================================Linq================================
            var books12 = new Linq.BookRepository().GetBooks();
            //Without LINQ
            /*var cheapBooks12 = new List<Linq.Book>();
            foreach(var book12 in books12)
            {
                if (book12.Price < 10)
                    cheapBooks12.Add(book12);
            }*/

            //With LINQ ***
            //LINQ Query Operators
            var cheapBooks11 = from b in books12
                               where b.Price < 10
                               orderby b.Title
                               select b.Title;
            //OR
            //LINQ Extension  Methods
            var cheapBooks12 = books12 //Linq + Extension Method + Lambda Expression
                                .Where(b => b.Price < 10) //Filter
                                .OrderBy(b => b.Title) //Sort
                                .Select(b => b.Title); //Fetch

            
            foreach (var book12 in cheapBooks12)
                Console.WriteLine(book12);
            /*Console.WriteLine(book12.Title + " " + book12.Price);*/

            Console.WriteLine(books12.Single(b => b.Title == "ASP.NET MVC").Title);
            //Console.WriteLine(books12.Single(b => b.Title == "ASP.NET MVC ++").Title); ---> Throws an InvalidOperator exception 
            //TO avoid this, we can use SingleOrDefault()
            Console.WriteLine(books12.SingleOrDefault((b => b.Title == "ASP.NET MVC Book")) == null);
            var bookFirst = books12.First(b => b.Title == "C# Advanced Topics");
            Console.WriteLine(bookFirst.Title + " "+ bookFirst.Price);
            //FirstOrDefault , Last , LastOrDefault
            var bookLast = books12.Last(b => b.Title == "C# Advanced Topics");
            Console.WriteLine(bookLast.Title + " " + bookLast.Price);
            //Paging Data - use Skip() & Take()
            var pagedBooks = books12.Skip(2).Take(3);
            foreach (var pagedBook in pagedBooks)
            {
                Console.WriteLine(pagedBook.Title);
            }
            //Aggregator Functions
            Console.WriteLine(books12.Count());
            Console.WriteLine(books12.Max(b => b.Price));
            Console.WriteLine(books12.Min(b => b.Price));
            Console.WriteLine(books12.Sum(b => b.Price));

            //================================Nullable Types================================
            //DateTime date = null; //cannot be set to null
            System.Nullable<DateTime> date1 = null; //OR
            DateTime? date = null;

            Console.WriteLine("Get Value Or Default : " +date.GetValueOrDefault());
            Console.WriteLine("Has Value ? " +date.HasValue);
            //Console.WriteLine("Value : " +date.Value); //Throws an exception - System.InvalidOperationException: 'Nullable object must have a value
            //Wehn you access the value , make sure the object has a value - hence suggested way is to use GetValueOrDefault() instead

            DateTime? date2 = new DateTime(2021, 1, 1);
            //DateTime date3 = date2; //Assigning nullable type to DataTime object throws error
            DateTime date3 = date2.GetValueOrDefault();
            Console.WriteLine(date3);
            DateTime? date4 = date3; //No casting required while assigning an object to nullable type object
            Console.WriteLine(date4);

            //Null Coalescing Operator
            /*DateTime date5;
            if (date1 != null)
                date5 = date1.GetValueOrDefault();
            else
                date5 = DateTime.Today;
            Console.WriteLine(date5);*/
            //OR
            DateTime date5 = date1 ?? DateTime.Today;
            Console.WriteLine(date5);

            //================================Dynamics================================
            object obj = "Impa";
            Console.WriteLine(obj.GetHashCode());

            //Using Reflection ---
            /*var methodInfo = obj.GetType().GetMethod("GetHashCode");
            methodInfo.Invoke(null, null);*/

            //Using Dynamic
            //object excelObj = "Impa";
            /*dynamic excelObj = "Impa";
            excelObj.Optimize();*/ //Above object has no method with signature Optimize() - this is resolved by using 'dynamic' type

            dynamic name = "Impa";
            name = 10;

            dynamic a = 10;
            dynamic b1 = 5;
            var c = a + b1; //c is of type dynamic - implicit conversion from target type

            int i = 5;
            dynamic d = i; //runtime type of d is integer
            long l = d;
            //int ii = (int)l;

            //================================Exceptional Handling================================
            /*var calculator = new Calculator();
            Console.WriteLine(calculator.Divide(5, 0));*/
                        
            try
            {
                var calculator = new Calculator();
                Console.WriteLine(calculator.Divide(5, 0));
            }
            //More Generic Exception
            catch (DivideByZeroException e)
            {
                Console.WriteLine("You cannot divide by 0");
            }
            /*catch (ArithmeticException e)
            {
                Console.WriteLine(e);
            }*/
            catch (Exception e)
            {
                //Recover from error and prevent the application from crashing
                Console.WriteLine("Sorry!!! An unexpected error occured");
                //Throw the error = send the error back to caller of this code
                /*throw;*/
            }
            finally
            {
                //IDisposable
            }

            //StreamReader streamReader = null;
            try
            {
                using (var streamReader = new StreamReader(@"c:\file.zip"))
                {
                    var content = streamReader.ReadToEnd();
                }                                
            }
            catch (Exception)
            {
                Console.WriteLine("Sorry !!! An unexpected error occurred");
                //throw;
            }
            /*finally
            {
                if(streamReader != null)
                    streamReader.Dispose();
            }*/

            try
            {
                var api = new YoutubeApi();
                var videos = api.GetVideos("impa");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                //throw;
            }

            //================================Asynchronous Programming with Async/Await================================
            
        }

        static void RemoveRedEye(Photo photo)
        {
            Console.WriteLine("Apply Remove RedEye");
        }

        /*static int Square(int number)
        {
            return number * number;
        }*/

        /*static bool IsCheaperThan10Dollars(LambdaExpressions.Book book)
        {
            return book.Price < 10;
        }*/

        private void Button_Click(object sender, EventArgs e)
        {
            DownloadHtmlAsync("http://msdn.microsoft.com");
        }

        public async Task DownloadHtmlAsync(string url)
        {
            var webClient = new WebClient();
            var html = await webClient.DownloadStringTaskAsync(url);

            using (var streamWriter = new StreamWriter(@"c:\projects\results.html"))
            {
                await streamWriter.WriteAsync(html);
            }
        }
    }

    /* Cannot be derived from sealed type string
     * public class RichString : String
    {

    }*/

    
    
}
