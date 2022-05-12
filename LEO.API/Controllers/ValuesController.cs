using Microsoft.AspNetCore.Mvc;
using SlotErrorTrackerLibrary.Data;
using SlotErrorTrackerLibrary.Models;

namespace ErrorTrackerAPI.Controllers
{
    [Route("[controller]")]
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
        public async Task<List<ManufacturerModel>> GetManufacturersAsync()
        {
            var manufacturers = await data.GetManufacturersAsync();
            return manufacturers;
        }

        [Route("/Get Errors By Cabinet")]
        [HttpGet]
        public async Task<List<ErrorModel>> GetErrorsByCabinetAsync(string cabinet)
        {
            var errors = await data.GetErrorsByCabinetAsync(cabinet);
            return errors;
        }

        [Route("/Get Cabinets By Manufacturer")]
        [HttpGet]
        public async Task<List<CabinetPlatformModel>> GetCabinetsByManufacturerAsync(string manufacturer)
        {
            var cabinets = await data.GetCabinetsByManufacturerAsync(manufacturer);
            return cabinets;
        }

        [Route("/Get Solution By Error Description")]
        [HttpGet]
        public async Task<List<SolutionModel>> GetSolutionByErrorDescriptionAsync(string ed, string cabinet)
        {
            var solutions = await data.GetSolutionsByErrorDescriptionAsync(ed, cabinet);
            return solutions;
        }

        [Route("/Get All Errors")]
        [HttpGet]
        public async Task<List<ErrorModel>> GetAllErrorsAsync()
        {
            var errors = await data.GetAllErrorsAsync();
            return errors;
        }

        [Route("/Get All Solutions")]
        [HttpGet]
        public async Task<List<SolutionModel>> GetAllSolutionsAsync()
        {
            var solutions = await data.GetAllSolutionsAsync();
            return solutions;
        }

        [Route("/Create Cabinet By Manufacturer")]
        [HttpPost]
        public async Task CreateCabinetByManufacturerAsync(string cabinet, string manufacturer)
        {
            await data.CreateCabinetByManufacturerAsync(cabinet, manufacturer);
        }

        [Route("/Create Error Description By Cabinet")]
        [HttpPost]
        public async Task CreateEDByCabinetAsync(string ed, string cabinet)
        {
            await data.CreateErrorDescriptionByCabinetAsync(ed, cabinet);
        }

        [Route("/Create Manufacturer")]
        [HttpPost]
        public async Task CreateManufacturerAsync(string manufacturer)
        {
            await data.CreateManufacturerAsync(manufacturer);
        }

        [Route("/Create Solution By Error Description")]
        [HttpPost]
        public async Task CreateSolutionByEDAsync(string solution, string ed, string cabinet)
        {
            await data.CreateSolutionByErrorDescriptionAsync(solution, ed, cabinet);
        }
    }
}
