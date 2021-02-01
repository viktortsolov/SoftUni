using Logger.Appenders;
using System;

namespace Logger.Core
{
    public class Engine : IEngine
    {
        public void Run(int countOfAppenders)
        {
            IAppender[] appenders = new IAppender[countOfAppenders];


        }
    }
}