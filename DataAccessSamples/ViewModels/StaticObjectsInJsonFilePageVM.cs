using System;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace DataAccessSamples.ViewModels
{
    public partial class StaticObjectsInJsonFilePageVM : BaseViewModel
    {
        public ObservableCollection<StudentCase> SourceItems { get; set; } = new();
        public ObservableCollection<StudentCase> SearchResults { get; set; } = new();


        StudentCaseService studentCaseService;

        public StaticObjectsInJsonFilePageVM(StudentCaseService studentCaseService)
        {
            //title = "Student Case Finder";
            this.studentCaseService = studentCaseService;
        }

        public async Task InitializeAsync()
        {
            await GetAllStudentCases();
        }

        [RelayCommand]
        async Task GetAllStudentCases()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                var studentCases = await studentCaseService.GetStudentCases();

                if (SourceItems.Count != 0)
                    SourceItems.Clear();

                if (SearchResults.Count != 0)
                    SearchResults.Clear();

                foreach (var studentCase in studentCases)
                {
                    SourceItems.Add(studentCase);
                    SearchResults.Add(studentCase);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get cases: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }

        }

        [RelayCommand]
        async Task GoToDetails(StudentCase studentCase)
        {
            if (studentCase == null)
                return;

            await Shell.Current.GoToAsync(nameof(StaticObjectsInJsonFileDetailPage), true, new Dictionary<string, object>
            {
                {"StudentCase", studentCase }
            });
        }

        [RelayCommand]
        public async Task PerformSearch(string searchTerm)
        {

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = string.Empty;
            }

            searchTerm = searchTerm.ToLower();
            var filteredItems = SourceItems.Where(value => value.StudentName.ToLower().Contains(searchTerm)).ToList();

            foreach (var value in SourceItems)
            {
                if (!filteredItems.Contains(value))
                {
                    SearchResults.Remove(value);
                }
                else if (!SearchResults.Contains(value))
                {
                    SearchResults.Add(value);
                }
            }


        }
    }

        
}

