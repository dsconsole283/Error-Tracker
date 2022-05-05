using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SlotErrorTrackerLibrary.Data;
using SlotErrorTrackerLibrary.Models;

namespace ErrorTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ISQLData data;

        public ValuesController(ISQLData data)
        {
            this.data = data;
        }

        [Route("/Get Manufacturers")]
        [HttpGet]
        public List<ManufacturerModel> GetManufacturers()
        {
            List<ManufacturerModel> manufacturers = data.GetManufacturers();
            return manufacturers;
        }

        [Route("/Get Errors By Cabinet")]
        [HttpGet]
        public List<ErrorModel> GetErrorsByCabinet(string cabinet)
        {
            List<ErrorModel> errors = data.GetErrorsByCabinet(cabinet);
            return errors;
        }
    }
}
