using ErrorTrackerAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ErrorTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet(Name = "Get Manufacturers")]
        public List<ManufacturerModel> GetManufacturers()
        {
            return new List<ManufacturerModel>() 
            { 
                new ManufacturerModel() 
                { 
                    Manufacturer = "Aristocrat"
                } 
            };            
        }
    }
}
