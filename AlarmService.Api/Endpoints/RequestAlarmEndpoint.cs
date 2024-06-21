using AlarmService.Api.Services;
using FastEndpoints;

namespace AlarmService.Endpoints
{
 
    public class RequestAlarmEndpoint: Endpoint<string>
    {
        private IAlarmService _alarmService;

        public RequestAlarmEndpoint(IAlarmService alarmService)
        {
            _alarmService = alarmService;
        }

        public override void Configure()
        {
            Get("/api/alarm/request");
            AllowAnonymous();
        }

        public override async Task HandleAsync(string req, CancellationToken ct)
        {
            var alarmMessage = await _alarmService.GetAlarm();
            await SendAsync(alarmMessage);
        }
    
    
    }
}