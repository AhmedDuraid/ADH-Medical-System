using ADHDataManager.Library.Models;
using System.Collections.Generic;

namespace ADHDataManager.Library.DataAccess
{
    public interface ILabTestData
    {
        void AddNewTest(LabTestModel labTest);
        void DeleteTest(string id);
        List<LabTestModel> GetTestByName(string testName);
        List<LabTestModel> GetTests();
        void UpdateTest(LabTestModel labTest);
    }
}