using System;
using System.IO;

namespace CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream reader = new FileStream(@"..\..\..\copyMe.png", FileMode.Open, FileAccess.Read))
            using (FileStream writer = new FileStream(@"..\..\..\newFile.png", FileMode.Create, FileAccess.Write))
            {
                reader.CopyTo(writer);
            }
        }
    }
}
