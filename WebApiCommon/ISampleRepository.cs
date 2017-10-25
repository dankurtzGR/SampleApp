using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiRepository
{
    public interface ISampleRepository
    {
        string GetMessage(int id);

        bool SaveMessage(string message);
    }
}
