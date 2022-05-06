using Microsoft.Extensions.Configuration;
using SlotErrorTrackerLibrary.Databases;
using SlotErrorTrackerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SlotErrorTrackerLibrary.Data
{

    public class SQLData : ISQLData
    {
        private readonly ISQLDataAccess _db = new SQLDataAccess();
        private readonly IConfiguration _configuration;
        private string _connectionString;

        public SQLData(IConfiguration configuration)
        {
            _configuration = configuration;
            SetConnectionString();
        }
        public void SetConnectionString()
        {
            var resources = Properties.Resources.ResourceManager;
            string output = "";
            output = resources.GetString("DefaultConnection");
            _connectionString = output;
        }

        public async Task<List<ManufacturerModel>> GetManufacturers()
        {
            return await _db.LoadDataAsync<ManufacturerModel, dynamic>("dbo.spGetManufacturers",
                                                            new { },
                                                            _connectionString,
                                                            true);
        }

        public async Task CreateCabinetByManufacturer(string cabinet,
                                                string manufacturer)
        {
            await _db.SaveDataAsync("dbo.spCreateCabinetByManufacturer",
                          new
                          {
                              Cabinet = cabinet.ToUpper(),
                              Manufacturer = manufacturer.ToUpper()
                          },
                          _connectionString,
                          true);
        }

        public async Task CreateErrorDescriptionByCabinet(string description,
                                                    string cabinet)
        {
            await _db.SaveDataAsync("dbo.spCreateEDByCabinet",
                          new
                          {
                              Description = description,
                              Cabinet = cabinet.ToUpper()
                          },
                          _connectionString,
                          true);
        }

        public async Task CreateSolutionByErrorDescription(string solution,
                                                     string description,
                                                     string cabinet)
        {
            await _db.SaveDataAsync("dbo.spCreateSolutionByED",
                         new
                         {
                             Solution = solution,
                             Description = description,
                             Cabinet = cabinet.ToUpper()
                         },
                         _connectionString,
                         true);
        }

        public async Task<List<CabinetPlatformModel>> GetCabinetsByManufacturer(string manufacturer)
        {
            return await _db.LoadDataAsync<CabinetPlatformModel, dynamic>("dbo.spGetCabinetsByManufacturer",
                                                                new
                                                                {
                                                                    Manufacturer = manufacturer.ToUpper()
                                                                },
                                                                _connectionString,
                                                                true);
        }

        public async Task<List<ErrorModel>> GetErrorsByCabinet(string cabinet)
        {
            return await _db.LoadDataAsync<ErrorModel, dynamic>("dbo.spGetErrorsByCabinet",
                                                     new
                                                     {
                                                         Cabinet = cabinet.ToUpper()
                                                     },
                                                     _connectionString,
                                                     true);
        }

        public async Task<List<SolutionModel>> GetSolutionsByErrorDescription(string description,
                                                                  string cabinet)
        {
            return await _db.LoadDataAsync<SolutionModel, dynamic>("dbo.spGetSolutionByErrorDescription",
                                                        new { Description = description, Cabinet = cabinet },
                                                        _connectionString,
                                                        true);
        }

        public async Task CreateManufacturer(string manufacturer)
        {
            await _db.SaveDataAsync("dbo.spCreateManufacturer",
                         new { Manufacturer = manufacturer.ToUpper() },
                         _connectionString,
                         true);
        }

        public async Task UpdateExistingErrorDescriptionByCabinet(string cabinet,
                                                            string errorDescription)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateExistingPotentialSolutionByErrorDesc(string potentialSolution,
                                                               string errorDescription)
        {
            throw new NotImplementedException();
        }
        //public void CreateErrorDescription(string errorDescription)
        //{
        //    _db.SaveData("dbo.spCreateErrorDescription", new { errorDescription }, _connectionString, true);
        //}
        //public void CreatePotentialSolution(string potentialSolution)
        //{
        //    _db.SaveData("dbo.spCreatePotentialSolution", new { potentialSolution }, _connectionString, true);
        //}
        //public void DeleteManufacturer(string manufacturer)
        //{
        //    //Must delete all associated cabinets and update link tables as well
        //    throw new NotImplementedException();
        //}
        //public void DeleteCabinetByManufacturer(string cabinet,
        //                                        string manufacturer)
        //{
        //    //Must update error description link table as well
        //    throw new NotImplementedException();
        //}
        //public void DeleteErrorDescription(string errorDescription)
        //{
        //    //Must update link table as well
        //    throw new NotImplementedException();
        //}
        //public void AssignExistingErrorDescToCabinet(string cabinet,
        //                                             string errorDescription)
        //{
        //    throw new NotImplementedException();
        //}
        //public void AssignExistingSolutionToErrorDesc(string potentialSolution,
        //                                             string errorDescription)
        //{
        //    throw new NotImplementedException();
        //}
        //public void DeleteErrorDescriptionByCabinet(string cabinet,
        //                                            string errorDescription)
        //{
        //    //Must update link tables as well
        //    throw new NotImplementedException();
        //}
        //public void DeletePotentialSolutionByErrorDesc(string potentialSolution,
        //                                               string errorDescription)
        //{
        //    //Must update link tables as well
        //    throw new NotImplementedException();
        //}
        //public void UpdateExistingManufacturer(string manufacturer)
        //{
        //    throw new NotImplementedException();
        //}
        //public void UpdateExistingCabinetByManufacturer(string cabinet,
        //                                                string manufacturer)
        //{
        //    throw new NotImplementedException();
        //}
        //public void UpdateExistingErrorDescription(string errorDescription)
        //{
        //    throw new NotImplementedException();
        //}
        //public void UpdateExistingPotentialSolution(string potentialSolution)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
