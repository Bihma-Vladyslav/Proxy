using System;

namespace Proxy
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            IFile file = new ProxyFile("test.txt");

            // Open file
            file.Open();

            // Close file
            file.Close();

            // Wait for user input
            Console.ReadKey();
        }
    }

    public interface IFile
    {
        void Open();
        void Close();
    }

    public class File : IFile
    {
        private string fileName;

        public File(string fileName)
        {
            this.fileName = fileName;
            LoadFileFromDisk();
        }

        public void Open()
        {
            Console.WriteLine("Opening file: " + fileName);
        }

        public void Close()
        {
            Console.WriteLine("Closing file: " + fileName);
        }

        private void LoadFileFromDisk()
        {
            Console.WriteLine("Loading file " + fileName + " from disk");
        }
    }

    public class ProxyFile : IFile
    {
        private string fileName;
        private File file;

        public ProxyFile(string fileName)
        {
            this.fileName = fileName;
        }

        public void Open()
        {
            if (file == null)
            {
                file = new File(fileName);
            }

            file.Open();
        }

        public void Close()
        {
            if (file != null)
            {
                file.Close();
            }
        }
    }
}


