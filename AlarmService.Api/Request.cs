using FastEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace AlarmService.Api;

public class MyRequest
{
    [FromForm]
    public string FirstName { get; set; }
    [FromForm]
    public string LastName { get; set; }
    [FromForm]
    public int Age { get; set; }
}

public class MyResponse
{
    public string FullName { get; set; }
    public bool IsOver18 { get; set; }
}

public class MyEndpoint : Endpoint<MyRequest, MyResponse>
{
    public override void Configure()
    {
        Post("/api/user/create");
        AllowFormData();
        AllowAnonymous();
    }

    public override async Task HandleAsync(MyRequest req, CancellationToken ct)
    {
        await SendAsync(new()
        {
            FullName = req.FirstName + " " + req.LastName,
            IsOver18 = req.Age > 18
        });
    }
}