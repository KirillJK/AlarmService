using AlarmService.Api.Services;
using FastEndpoints;

namespace AlarmService.Api.Endpoints;

public class PostAlarmEndpoint: Endpoint<string, bool>
{
    private IAlarmService _alarmService;

    public PostAlarmEndpoint(IAlarmService alarmService)
    {
        _alarmService = alarmService;
    }

    public override void Configure()
    {
        Post("/api/alarm/post");
        AllowAnonymous();
    }

    public override async Task HandleAsync(string req, CancellationToken ct)
    {
        await _alarmService.PostAlarm(req);
        await SendAsync(true);
    }
    
    
}