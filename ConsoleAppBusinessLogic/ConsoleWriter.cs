using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppBusinessLogic
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string content)
        {
            Console.WriteLine(content);
        }
    }
}
