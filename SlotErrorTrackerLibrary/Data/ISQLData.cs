using SlotErrorTrackerLibrary.Models;
using System.Collections.Generic;

namespace SlotErrorTrackerLibrary.Data
{
    public interface ISQLData
    {
        void AssignExistingErrorDescToCabinet(string cabinet, string errorDescription);
        void AssignExistingSolutionToErrorDesc(string potentialSolution, string errorDescription);
        void CreateCabinetByManufacturer(string cabinet, string manufacturer);
        void CreateErrorDescription(string errorDescription);
        void CreateErrorDescriptionByCabinet(string description, string cabinet);
        void CreateManufacturer(string manufacturer);
        void CreatePotentialSolution(string potentialSolution);
        void CreateSolutionByErrorDescription(string solution, string description, string cabinet);
        void DeleteCabinetByManufacturer(string cabinet, string manufacturer);
        void DeleteErrorDescription(string errorDescription);
        void DeleteErrorDescriptionByCabinet(string cabinet, string errorDescription);
        void DeleteManufacturer(string manufacturer);
        void DeletePotentialSolutionByErrorDesc(string potentialSolution, string errorDescription);
        List<CabinetPlatformModel> GetCabinetsByManufacturer(string manufacturer);
        List<ErrorModel> GetErrorsByCabinet(string cabinet);
        List<ManufacturerModel> GetManufacturers();
        List<SolutionModel> GetSolutionsByErrorDescription(string description, string cabinet);
        void UpdateExistingCabinetByManufacturer(string cabinet, string manufacturer);
        void UpdateExistingErrorDescription(string errorDescription);
        void UpdateExistingErrorDescriptionByCabinet(string cabinet, string errorDescription);
        void UpdateExistingManufacturer(string manufacturer);
        void UpdateExistingPotentialSolution(string potentialSolution);
        void UpdateExistingPotentialSolutionByErrorDesc(string potentialSolution, string errorDescription);
    }
}