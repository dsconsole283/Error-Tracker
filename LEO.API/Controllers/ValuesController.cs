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

        [Route("/GetManufacturers")]
        [HttpGet]
        public async Task<List<ManufacturerModel>> GetManufacturersAsync()
        {
            var manufacturers = await data.GetManufacturersAsync();
            return manufacturers;
        }

        [Route("/GetErrorsByCabinet")]
        [HttpGet]
        public async Task<List<ErrorModel>> GetErrorsByCabinetAsync(string cabinet)
        {
            var errors = await data.GetErrorsByCabinetAsync(cabinet);
            return errors;
        }

        [Route("/GetCabinetsByManufacturer")]
        [HttpGet]
        public async Task<List<CabinetPlatformModel>> GetCabinetsByManufacturerAsync(string manufacturer)
        {
            var cabinets = await data.GetCabinetsByManufacturerAsync(manufacturer);
            return cabinets;
        }

        [Route("/GetSolutionByErrorDescription")]
        [HttpGet]
        public async Task<List<SolutionModel>> GetSolutionByErrorDescriptionAsync(string ed, string cabinet)
        {
            var solutions = await data.GetSolutionsByErrorDescriptionAsync(ed, cabinet);
            return solutions;
        }

        [Route("/GetAllErrors")]
        [HttpGet]
        public async Task<List<ErrorModel>> GetAllErrorsAsync()
        {
            var errors = await data.GetAllErrorsAsync();
            return errors;
        }

        [Route("/GetAllSolutions")]
        [HttpGet]
        public async Task<List<SolutionModel>> GetAllSolutionsAsync()
        {
            var solutions = await data.GetAllSolutionsAsync();
            return solutions;
        }

        [Route("/CreateCabinetByManufacturer")]
        [HttpPost]
        public async Task CreateCabinetByManufacturerAsync(string cabinet, string manufacturer)
        {
            await data.CreateCabinetByManufacturerAsync(cabinet, manufacturer);
        }

        [Route("/CreateErrorDescriptionByCabinet")]
        [HttpPost]
        public async Task CreateEDByCabinetAsync(string ed, string cabinet)
        {
            await data.CreateErrorDescriptionByCabinetAsync(ed, cabinet);
        }

        [Route("/CreateManufacturer")]
        [HttpPost]
        public async Task CreateManufacturerAsync(string manufacturer)
        {
            await data.CreateManufacturerAsync(manufacturer);
        }

        [Route("/CreateSolutionByErrorDescription")]
        [HttpPost]
        public async Task CreateSolutionByEDAsync(string solution, string ed, string cabinet)
        {
            await data.CreateSolutionByErrorDescriptionAsync(solution, ed, cabinet);
        }
    }
}
