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
        [HttpGet(Name = "Get Manufacturers")]
        public List<ManufacturerModel> GetManufacturers()
        {
            List<ManufacturerModel> manufacturers = data.GetManufacturers();
            return manufacturers;
        }
    }
}
