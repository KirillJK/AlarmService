using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace AlarmService.Client
{
    public class AlarmServiceClient:IAlarmServiceClient
    {
        private readonly HttpClient _httpClient;

        private IOptions<AlarmServiceOptions> _options;

        public AlarmServiceClient(IOptions<AlarmServiceOptions> options)
        {
            _options = options;
            var handler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };
            _httpClient = new HttpClient (handler) { BaseAddress = new Uri(_options.Value.BaseUrl) };
        }

        public async Task<bool> PostAlarm(string alarmData)
        {
            var content = new StringContent(JsonConvert.SerializeObject(alarmData), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/alarm/post", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<bool>(responseContent);
            }

            throw new Exception($"Failed to post alarm: {response.StatusCode}");
        }
    }
}