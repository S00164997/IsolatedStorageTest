using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO;
using System.IO.IsolatedStorage;
namespace ConsoleAppIsolatedStorage
{   //https://docs.microsoft.com/en-us/dotnet/standard/io/how-to-read-and-write-to-files-in-isolated-storage
    //https://docs.microsoft.com/en-us/dotnet/standard/io/isolated-storage
    class Program
        {
            static void Main(string[] args)
            {
                IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);

                if (isoStore.FileExists("TestStore.txt"))
                {
                    Console.WriteLine("The file already exists!");
                    using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream("TestStore.txt", FileMode.Open, isoStore))
                    {
                        using (StreamReader reader = new StreamReader(isoStream))
                        {
                            Console.WriteLine("Reading contents:");
                            Console.WriteLine(reader.ReadToEnd());
                            Console.Read();
                    }
                    }
                }
                else
                {
                    using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream("TestStore.txt", FileMode.CreateNew, isoStore))
                    {
                        using (StreamWriter writer = new StreamWriter(isoStream))
                        {
                            writer.WriteLine("Hello Isolated Storage");
                            Console.WriteLine("You have written to the file.");
                                Console.Read();
                        }
                    }
                }
            }
        }
    }
