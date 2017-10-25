using Microsoft.EntityFrameworkCore;
using System;

namespace WebApiRepository
{
    public class SampleDbContext : DbContext
    {
        public SampleDbContext()
        {
            // set connection string etc.
        }

        public string Get(int id)
        {
            // EF etc db call to get data
            return "Hello World";
        }

        public bool Save(string message)
        {
            return true;
        }
    }
}

