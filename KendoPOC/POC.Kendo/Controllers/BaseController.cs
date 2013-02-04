using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace Poc.Kendo.Controllers
{
    public class BaseController : Controller
    {
        HttpClient _serviceClient = null;

        public BaseController()
        {
            
        }

        public HttpClient ServiceClient
        {
            get
            {
                if (_serviceClient == null)
                {
                    var webApiUrl = HttpContext.Application["WEB_API_URL"] as string;
                    _serviceClient = new HttpClient();
                    _serviceClient.BaseAddress = new Uri(webApiUrl);
                    _serviceClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                }
                return _serviceClient;
            }
        }

        //public string WebApiUrl
        //{
        //    get {  return webApiUrl; }
        //}
    }
}


