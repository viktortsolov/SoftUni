using System;
using System.IO.Compression;

namespace ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            ZipFile.CreateFromDirectory(@"D:\ZipFileDemo1", @"D:\ZipFileDemo2\myZipFile.zip");
            ZipFile.ExtractToDirectory(@"D:\ZipFileDemo2\myZipFile.zip", @"D:\ZipFileDemoResult");
        }
    }
}
