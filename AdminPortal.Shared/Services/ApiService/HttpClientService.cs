using AdminPortal.Shared.Enums;
using AdminPortal.Shared.Models.CustomSetting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AdminPortal.Shared.Services.ApiService
{
    public class HttpClientService
    {
        private readonly HttpClient _httpClient;
        private readonly HttpContext? _httpContext;
        private readonly CustomSettingModel _customSetting;

        public HttpClientService(HttpClient httpClient,IOptionsMonitor<CustomSettingModel> customSetting,IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContext = httpContextAccessor.HttpContext;
            _customSetting = customSetting.CurrentValue;
            _httpClient.BaseAddress=new Uri(_customSetting.BackendUrl?? string.Empty);
        }
        public async Task<T>ExucuteAsync<T>(string endPoint,EnumHttpMethod httpMethod,object requestModel = null)
        {
            T? model = default;
            var response=await ExecuteHttpResponseAsync<HttpResponseMessage>(endPoint, httpMethod, requestModel);
            var jsonStr = await response.Content.ReadAsStringAsync();
            model= JsonConvert.DeserializeObject<T>(jsonStr);
            return model;
        }
        public async Task<HttpResponseMessage> ExecuteHttpResponseAsync<T>(string endPoint, EnumHttpMethod httpMethod, object requestModel = null)
        {
            HttpResponseMessage httpResponse = null;
            HttpContent content = null;
            if (requestModel != null)
            {
                content = new StringContent(JsonConvert.SerializeObject(requestModel), Encoding.UTF8, "application/json");
            }
            httpResponse = httpMethod switch
            {
                EnumHttpMethod.GET => await _httpClient.GetAsync(endPoint),
                _ => await _httpClient.PostAsync(endPoint, content),
            };
            return httpResponse;
        }
    }
}
