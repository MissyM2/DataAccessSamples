using System;
using System.Text.Json;

namespace DataAccessSamples.Services
{
    public class StudentCaseService
    {

        public StudentCaseService()
        {
        }

        List<StudentCase> studentCaseList;

        public async Task<List<StudentCase>> GetStudentCases()
        {
            if (studentCaseList?.Count > 0)
                return studentCaseList;

            using var stream = await FileSystem.OpenAppPackageFileAsync("studentcasedata.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            studentCaseList = JsonSerializer.Deserialize<List<StudentCase>>(contents);

            return studentCaseList;
        }


    }
}
