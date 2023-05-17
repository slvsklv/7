using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows.Input;
using _7.Models;
using MvvmHelpers;

namespace _7.ViewModels
{
    public class ReminderViewModel : BaseViewModel
    {
        private string _newReminderTitle;
        private ObservableCollection<ReminderModel> _reminders;
        private ReminderModel _selectedReminder;

        public ReminderViewModel()
        {
            _reminders = new ObservableCollection<ReminderModel>();

            AddReminderCommand = new RelayCommand(AddReminder);
        }

        public string NewReminderTitle
        {
            get { return _newReminderTitle; }
            set
            {
                if (_newReminderTitle != value)
                {
                    _newReminderTitle = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<ReminderModel> Reminders
        {
            get { return _reminders; }
            set
            {
                if (_reminders != value)
                {
                    _reminders = value;
                    OnPropertyChanged();
                }
            }
        }

        public ReminderModel SelectedReminder
        {
            get { return _selectedReminder; }
            set
            {
                if (_selectedReminder != value)
                {
                    _selectedReminder = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand AddReminderCommand { get; }

        private void AddReminder()
        {
            if (!string.IsNullOrEmpty(NewReminderTitle))
            {
                ReminderModel newReminder = new ReminderModel { Title = NewReminderTitle };
                Reminders.Add(newReminder);
                NewReminderTitle = string.Empty; 
            }
        }
    }
}
