namespace AlarmService.Client;

public interface IAlarmServiceClient
{
    Task<bool> PostAlarm(string alarmData);
}