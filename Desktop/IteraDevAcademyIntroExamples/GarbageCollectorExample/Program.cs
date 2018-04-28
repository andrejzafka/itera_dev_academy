/// Author: Jana Michalkova, jana.michalkova@itera.no
/// Date: 4/19/2018
/// Version: 1.0.0
/// 
/// This is example project about managing garbage collection of unmanaged resources.
/// For more information about garbage collection in .NET go to https://docs.microsoft.com/en-us/dotnet/standard/garbage-collection/.
/// 

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarbageCollectorExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join("\n", GetAllPostsFromDB()));

            Console.WriteLine(string.Join("\n", GetAllPostsFromDBTryFinally()));
            
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        // Managing Entity Framework database connection with C# keyword using.
        // On compilation using is rewriten into try/finally shown below.
        private static List<Post> GetAllPostsFromDB()
        {
            using (var context = new PostsContext())
            {
                return context.Posts.ToList();
            }
        }

        // Managing database connection with try/catch/finally
        private static List<Post> GetAllPostsFromDBTryFinally()
        {
            PostsContext context = null;
            try
            {
                // in case of fail the DBContext will be disposed in finally block
                context = new PostsContext();
                return context.Posts.ToList();
            }
            catch (SqlException exception)
            {
                // Log exception
                throw;
            }            
            finally
            {
                if(context != null)
                {
                    // DBContext implements IDisposable and must be manually disposed
                    ((IDisposable)context).Dispose();
                }
            }
        }
    }
}
