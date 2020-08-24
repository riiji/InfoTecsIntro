using System;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;

namespace InfoTecsIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryCopy copy = new DirectoryCopy();
            copy.RecursiveCopyDirectory(new DirectoryInfo("C:\\Users\\riijii\\Downloads"), new DirectoryInfo("C:\\temp"));
        }
    }
}
