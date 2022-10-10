using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace MyTasks.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {
            Items = new ObservableCollection<string>();
        }

        [ObservableProperty]
        ObservableCollection<string> items;

        [ObservableProperty]
        string newTask;

        [RelayCommand]
        void AddTask()
        {
            if (string.IsNullOrWhiteSpace(NewTask)) return;

            Items.Add(NewTask);
            NewTask = string.Empty;
        }

    }
}
