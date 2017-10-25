using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApiRepository;

namespace DanKurtzWebApi.Controllers
{
    /// <summary>
    /// Web api example for use with hello world console app or other applications
    /// </summary>
    [Route("api/helloworld")]
    public class HelloWorldController : Controller
    {
        ILogger logger;
        ISampleRepository repository;

        /// <summary>
        /// Constructor
        /// Inject db context and logger
        /// </summary>
        /// <param name="log"></param>
        /// <param name="repo"></param>
        public HelloWorldController(ILogger<HelloWorldController> log, ISampleRepository repo)
        {
            logger = log;
            repository = repo;
        }


        /// <summary>
        /// Gets previously saved message
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public string Get(int id)
        {
            

            try
            {
                string response = "";

                logger.LogInformation("Log request " + id.ToString());

                // example code that all the repository directly
                response = repository.GetMessage(id);

                // add logic for if not found - return 404 etc.

                logger.LogInformation("Log response " + response);

                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error saving", new object[] { id });
                return "Sorry, an error occurred when retrieving the value";
            }
        }

        /// <summary>
        /// Save a message
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public void Post([FromBody]string value)
        {
            try
            {
                logger.LogInformation("Log request " + value);

                // example code that all the repository directly - could add business logic, validation etc
                bool success = repository.SaveMessage(value);

                logger.LogInformation("Log response :  Success -" + success.ToString());
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error saving", new object[] { value });
            }
        }

      
    }
}
