using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppBusinessLogic
{
    public class WriteHelloWorld
    {
        private IWriter outputWriter;


        /// <summary>
        /// Creates a hello world writer class that takes a writer object
        /// </summary>
        /// <param name="writer"></param>
        public WriteHelloWorld(IWriter writer)
        {
            outputWriter = writer;
        }

        /// <summary>
        /// Writes the message to the appropriate output
        /// </summary>
        /// <param name="message"></param>
        public bool Write(string message)
        {
            bool isValid = ValidateHelloWorld(message);

            bool success = false;

            if (isValid)
            {
                outputWriter.Write(message);
                success = true;
            }

            return success;

        }

        /// <summary>
        /// Sample validation method
        ///   a more realistic example would be validating a class or model.  The model could be validated using data annotations for example 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool ValidateHelloWorld(string message)
        {
            bool isValid = true;

            if (message != "Hello World")
            {
                isValid = false;
            }

            return isValid;
        }
    }
}
