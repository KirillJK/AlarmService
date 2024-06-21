namespace AlarmService.Api.Services
{
    public interface IAlarmService
    {
        public Task PostAlarm(string alarmMessage);
        public Task<string> GetAlarm();
    
    }

    public class AlarmService:IAlarmService
    {
        private static string _alarmMessage = string.Empty;
        public async Task PostAlarm(string alarmMessage)
        {
            _alarmMessage = alarmMessage;
        }

        public async Task<string> GetAlarm()
        {
            var message = _alarmMessage;
            _alarmMessage = string.Empty;
            return message;
        }
    }
}