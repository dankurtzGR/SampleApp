using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiRepository
{
    /// <summary>
    /// Repository pattern allowing for different types of repositories sql, oracle etc.
    /// </summary>
    public class SampleDBRepository : ISampleRepository
    {
        SampleDbContext dbContext = new SampleDbContext();

        public SampleDBRepository()
        {
            
        }

        public string GetMessage(int id)
        {
            return dbContext.Get(id);
        }

        public bool SaveMessage(string message)
        {
            return dbContext.Save(message);
        }
    }
}
