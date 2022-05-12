using SlotErrorTrackerLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SlotErrorTrackerLibrary.Data
{
    public interface ISQLData
    {
        Task CreateCabinetByManufacturerAsync(string cabinet, string manufacturer);
        Task CreateErrorDescriptionByCabinetAsync(string description, string cabinet);
        Task CreateManufacturerAsync(string manufacturer);
        Task CreateSolutionByErrorDescriptionAsync(string solution, string description, string cabinet);
        Task<List<CabinetPlatformModel>> GetCabinetsByManufacturerAsync(string manufacturer);
        Task<List<ErrorModel>> GetErrorsByCabinetAsync(string cabinet);
        Task<List<ManufacturerModel>> GetManufacturersAsync();
        Task<List<SolutionModel>> GetSolutionsByErrorDescriptionAsync(string description, string cabinet);
        void SetConnectionString();
        Task<List<SolutionModel>> GetAllSolutionsAsync();
        Task<List<ErrorModel>> GetAllErrorsAsync();
    }
}