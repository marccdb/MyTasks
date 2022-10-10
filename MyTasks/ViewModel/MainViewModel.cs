using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace MyTasks.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        IConnectivity connectivity;

        public MainViewModel(IConnectivity connectivity)
        {
            Items = new ObservableCollection<string>();
            this.connectivity = connectivity;
        }

        [ObservableProperty]
        ObservableCollection<string> items;

        [ObservableProperty]
        string newTask;

        [RelayCommand]
        async Task AddTask()
        {
            if (string.IsNullOrWhiteSpace(NewTask)) return;

            if (connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlert("There's an issue!", "Internet is required to save your list", "OK");
                return;
            }

            Items.Add(NewTask);
            NewTask = string.Empty;
        }


        [RelayCommand]
        void Delete(string task)
        {
            if (Items.Contains(task))
            {
                Items.Remove(task);
            }
        }


        [RelayCommand]
        async Task Tap(string task)
        {
            await Shell.Current.GoToAsync($"{nameof(DetailsPage)}?Text= { task }");
        }



    }
}
