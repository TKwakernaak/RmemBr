using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using RmemBr.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RmemBr.DataAccess
{
  public class BaseApiClient : IBaseApiClient
  {
    private readonly JsonSerializerSettings _serializerSettings;

    public BaseApiClient()
    {
      _serializerSettings = new JsonSerializerSettings
      {
        ContractResolver = new CamelCasePropertyNamesContractResolver(),
        DateTimeZoneHandling = DateTimeZoneHandling.Utc,
        NullValueHandling = NullValueHandling.Include
      };
      _serializerSettings.Converters.Add(new StringEnumConverter());
    }

    public async Task<TResult> GetAsync<TResult>(string uri, string token = "")
    {
      using (HttpClient httpClient = CreateHttpClient(token))
      {
        HttpResponseMessage response = await httpClient.GetAsync(uri);
        await HandleResponse(response);

        string serialized = await response.Content.ReadAsStringAsync();

        TResult result = JsonConvert.DeserializeObject<TResult>(serialized, _serializerSettings);

        return result;
      }
    }

    public async Task<TResult> PostAsync<TResult>(string uri, TResult data, string token = "", string header = "")
    {
      using (HttpClient httpClient = CreateHttpClient(token))
      {
        if (!string.IsNullOrEmpty(header))
        {
          AddHeaderParameter(httpClient, header);
        }

        var content = new StringContent(JsonConvert.SerializeObject(data));
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        HttpResponseMessage response = await httpClient.PostAsync(uri, content);

        await HandleResponse(response);
        string serialized = await response.Content.ReadAsStringAsync();

        TResult result = await Task.Run(() =>
            JsonConvert.DeserializeObject<TResult>(serialized, _serializerSettings));

        return result;
      }
    }

    public async Task<TResult> PutAsync<TResult>(string uri, TResult data, string token = "", string header = "")
    {
      using (HttpClient httpClient = CreateHttpClient(token))
      {
        if (!string.IsNullOrEmpty(header))
          AddHeaderParameter(httpClient, header);

        var content = new StringContent(JsonConvert.SerializeObject(data));
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        HttpResponseMessage response = await httpClient.PutAsync(uri, content);

        await HandleResponse(response);

        string serialized = await response.Content.ReadAsStringAsync();

        TResult result = await Task.Run(() =>
          JsonConvert.DeserializeObject<TResult>(serialized, _serializerSettings));

        return result;
      }
    }



    private void AddHeaderParameter(HttpClient httpClient, string parameter)
    {
      if (httpClient == null)
        return;

      if (string.IsNullOrEmpty(parameter))
        return;

      httpClient.DefaultRequestHeaders.Add(parameter, Guid.NewGuid().ToString());
    }


    private async Task HandleResponse(HttpResponseMessage response)
    {
      if (!response.IsSuccessStatusCode)
      {
        

        if (response.StatusCode == HttpStatusCode.Forbidden ||
           response.StatusCode == HttpStatusCode.Unauthorized)
        {
          throw new ServiceAuthenticationException(content.Message);
        }
        throw new HttpRequestExceptionEx(response.StatusCode, content.Message);
      }
    }


    private HttpClient CreateHttpClient(string token = "")
    {
      var httpClient = new HttpClient();
      httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
      httpClient.DefaultRequestHeaders.Add(HeaderConstants.WMSMEDEWERKERID, UserInfo.WmsMedewerkerId.ToString());
      httpClient.DefaultRequestHeaders.AcceptLanguage.TryParseAdd(CultureInfo.CurrentUICulture.Name);

      if (!string.IsNullOrEmpty(token))
      {
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
      }
      return httpClient;
    }

  }
}
