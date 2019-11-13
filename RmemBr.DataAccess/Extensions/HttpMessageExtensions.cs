using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RmemBr.DataAccess.Extensions
{
  public static class HttpMessageExtensions
  {
    public static async Task<ExceptionResponse> ExceptionResponse(this HttpResponseMessage httpResponseMessage)
    {
      try
      {
        string responseContent = await httpResponseMessage.Content.ReadAsStringAsync();
        ExceptionResponse exceptionResponse = JsonConvert.DeserializeObject<ExceptionResponse>(responseContent);
        return exceptionResponse;
      }
      catch (Exception e)
      {
        throw new HttpRequestException("Unexpected error" , e);
      }
    }
  }
  public class ExceptionResponse
  {
    public int StatusCode { get; set; }
    public string Message { get; set; }
  }
}
