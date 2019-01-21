using System;
using System.IO.Abstractions;
using Unity;

namespace CodingExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            //Register dependencies
            IUnityContainer container = new UnityContainer();
            container.RegisterType<Process>();
            container.RegisterType<IProximitySearch, ProximitySearch>();
            container.RegisterType<IFileSystem,FileSystem>();
            var process = container.Resolve<Process>();
            try
            {
                int output = process.Start(args);
                Console.Write(output);
            }
            catch(Exception)
            {
                return;
            }

        }
        
    }
}
