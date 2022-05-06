using SlotErrorTrackerLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SlotErrorTrackerLibrary.Data
{
    public interface ISQLData
    {
        Task CreateCabinetByManufacturer(string cabinet, string manufacturer);
        Task CreateErrorDescriptionByCabinet(string description, string cabinet);
        Task CreateManufacturer(string manufacturer);
        Task CreateSolutionByErrorDescription(string solution, string description, string cabinet);
        Task<List<CabinetPlatformModel>> GetCabinetsByManufacturer(string manufacturer);
        Task<List<ErrorModel>> GetErrorsByCabinet(string cabinet);
        Task<List<ManufacturerModel>> GetManufacturers();
        Task<List<SolutionModel>> GetSolutionsByErrorDescription(string description, string cabinet);
        void SetConnectionString();
        Task UpdateExistingErrorDescriptionByCabinet(string cabinet, string errorDescription);
        Task UpdateExistingPotentialSolutionByErrorDesc(string potentialSolution, string errorDescription);
    }
}