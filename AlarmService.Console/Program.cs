// See https://aka.ms/new-console-template for more information

using AlarmService.Client;
using Microsoft.Extensions.Options;

//alarmServiceOptions
AlarmServiceOptions alarmServiceOptions = new AlarmServiceOptions()
{
    BaseUrl = "http://localhost:7232/"
};
IOptions<AlarmServiceOptions> options = Options.Create(alarmServiceOptions);
AlarmServiceClient client = new AlarmServiceClient(options);
await client.PostAlarm("ALARM!");