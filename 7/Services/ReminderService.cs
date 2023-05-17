using System.Collections.Generic;
using _7.Models;


namespace _7.Services
{
    public class ReminderService
    {
        private List<ReminderModel> _reminders;

        public ReminderService()
        {
            _reminders = new List<ReminderModel>();
        }

        public void AddReminder(ReminderModel reminder)
        {
            _reminders.Add(reminder);
        }

        public void RemoveReminder(ReminderModel reminder)
        {
            _reminders.Remove(reminder);
        }
    }
}
