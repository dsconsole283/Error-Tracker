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

        [Route("/Get Cabinets By Manufacturer")]
        [HttpGet]
        public List<CabinetPlatformModel> GetCabinetsByManufacturer(string manufacturer)
        {
            List<CabinetPlatformModel> cabinets = data.GetCabinetsByManufacturer(manufacturer);
            return cabinets;
        }

        [Route("/Get Solution By Error Description")]
        [HttpGet]
        public List<SolutionModel> GetSolutionByErrorDescription(string ed, string cabinet)
        {
            List<SolutionModel> solutions = data.GetSolutionsByErrorDescription(ed, cabinet);
            return solutions;
        }

        [Route("/Create Cabinet By Manufacturer")]
        [HttpPost]
        public void CreateCabinetByManufacturer(string cabinet, string manufacturer)
        {
            data.CreateCabinetByManufacturer(cabinet, manufacturer);
        }

        [Route("/Create Error Description By Cabinet")]
        [HttpPost]
        public void CreateEDByCabinet(string ed, string cabinet)
        {
            data.CreateErrorDescriptionByCabinet(ed, cabinet);
        }

        [Route("/Create Manufacturer")]
        [HttpPost]
        public void CreateManufacturer(string manufacturer)
        {
            data.CreateManufacturer(manufacturer);
        }

        [Route("/Create Solution By Error Description")]
        [HttpPost]
        public void CreateSolutionByED(string solution, string ed, string cabinet)
        {
            data.CreateSolutionByErrorDescription(solution, ed, cabinet);
        }
    }
}
