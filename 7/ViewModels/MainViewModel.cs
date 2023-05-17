using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using _7.Models;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using MvvmHelpers;

namespace _7.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private string _newReminderTitle;
        private DateTime _newReminderDate;
        private TimeSpan _newReminderTime;
        private ObservableCollection<ReminderModel> _reminders;
        private ReminderModel _selectedReminder;

        public MainViewModel()
        {
            _reminders = new ObservableCollection<ReminderModel>();

            AddReminderCommand = new RelayCommand(AddReminder);
            CompleteReminderCommand = new RelayCommand(CompleteReminder);
            DeleteReminderCommand = new RelayCommand(DeleteReminder);
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

        public DateTime NewReminderDate
        {
            get { return _newReminderDate; }
            set
            {
                if (_newReminderDate != value)
                {
                    _newReminderDate = value;
                    OnPropertyChanged();
                }
            }
        }

        public TimeSpan NewReminderTime
        {
            get { return _newReminderTime; }
            set
            {
                if (_newReminderTime != value)
                {
                    _newReminderTime = value;
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
        public ICommand CompleteReminderCommand { get; }
        public ICommand DeleteReminderCommand { get; }

        private void AddReminder()
        {
            if (!string.IsNullOrEmpty(NewReminderTitle) && NewReminderDate != default && NewReminderTime != default)
            {
                DateTime reminderDateTime = NewReminderDate.Date + NewReminderTime;
                ReminderModel newReminder = new ReminderModel { Title = NewReminderTitle, Time = reminderDateTime };

                Reminders.Add(newReminder);
                NewReminderTitle = string.Empty; 
                NewReminderDate = default; 
                NewReminderTime = default; 

                ScheduleNotification(newReminder);
            }
        }

        private void CompleteReminder()
        {
            if (SelectedReminder != null)
            {
                SelectedReminder.IsCompleted = true;
            }
        }

        private void DeleteReminder()
        {
            if (SelectedReminder != null)
            {
                Reminders.Remove(SelectedReminder);
                SelectedReminder = null;
            }
        }

        private void ScheduleNotification(ReminderModel reminder)
        {
            MessageBox.Show($"Reminder: {reminder.Title}", "Reminder App", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
