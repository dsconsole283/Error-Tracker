using SlotErrorTrackerLibrary.Models;
using System.Collections.Generic;

namespace SlotErrorTrackerLibrary.Data
{
    public interface ISQLData
    {
        void CreateCabinetByManufacturer(string cabinet, string manufacturer);
        void CreateErrorDescriptionByCabinet(string description, string cabinet);
        void CreateManufacturer(string manufacturer);
        void CreateSolutionByErrorDescription(string solution, string description, string cabinet);
        List<CabinetPlatformModel> GetCabinetsByManufacturer(string manufacturer);
        List<ErrorModel> GetErrorsByCabinet(string cabinet);
        List<ManufacturerModel> GetManufacturers();
        List<SolutionModel> GetSolutionsByErrorDescription(string description, string cabinet);
        void SetConnectionString();
        void UpdateExistingErrorDescriptionByCabinet(string cabinet, string errorDescription);
        void UpdateExistingPotentialSolutionByErrorDesc(string potentialSolution, string errorDescription);
    }
}