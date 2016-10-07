using HomeProperty.Settings.Constant;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace HomeProperty.WebApp {
    public static class ApplicationService {
        public static string ServiceTokenEndPoint { get; private set; }
        public static string Token { get; private set; }
        public static string ServiceUsername { get; private set; }
        public static string ServicePassword { get; private set; }
        public static string GrantType { get; private set; }
        public static string ServiceEndPoint { get; private set; }

        private static string _tokenRequestParameters;
        public static IList<string> Errors { get; private set; }
        private static IDictionary<string, object> _responseDictionary { get; set; }
        private static string _currentCulture;

        private static ICacheManager _cacheManager;

        /// <summary>
        /// The main navigation bar menu
        /// </summary>
        public static string MainNavigationBarMenu {
            get { return GetResourceFromCache("mainNavigationBarMenu", "api/menuItems"); }
        }


        /// <summary>
        /// Get resources from Cache by culture
        /// </summary>
        /// <param name="key">The cache key</param>
        /// <param name="uri">The restful URI</param>
        /// <returns></returns>
        private static string GetResourceFromCache(string key, string uri) {
            _currentCulture = GetCurrentCulture();
            return _cacheManager.GetOrSet(string.Format("{0}_{1}", key, _currentCulture),
              () => MakeGetRequestCall(uri,
                   string.Format("culture={0}", _currentCulture)));
        }

        /// <summary>
        /// Contructor
        /// </summary>
        static ApplicationService() {
            Errors = new List<string>();
            _responseDictionary = new Dictionary<string, object>();
            _cacheManager = new CacheManager();

            ServiceTokenEndPoint = ConfigurationManager.AppSettings.Get("serviceTokenEndPoint");
            ServiceUsername = ConfigurationManager.AppSettings.Get("serviceUsername");
            ServicePassword = ConfigurationManager.AppSettings.Get("servicePassword");
            GrantType = ConfigurationManager.AppSettings.Get("grantType");
            ServiceEndPoint = ConfigurationManager.AppSettings.Get("serviceEndPoint");

            if (!string.IsNullOrEmpty(ServiceTokenEndPoint)
                && !string.IsNullOrEmpty(ServiceUsername)
                && !string.IsNullOrEmpty(ServicePassword))
                _tokenRequestParameters = string.Format("grant_type={0}&username={1}&password={2}",
                    GrantType, ServiceUsername, ServicePassword);
        }

        /// <summary>
        /// Gets current culture
        /// </summary>
        /// <returns></returns>
        private static string GetCurrentCulture() {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["_culture"];
            if (cookie != null)
                return cookie.Value;
            return Constant.EnglishUsCulture;

        }

        /// <summary>
        /// Makes GET service call
        /// </summary>
        /// <param name="serviceUrl">The service URL</param>
        /// <returns>The json string result</returns>
        private static string MakeGetRequestCall(string serviceUrl, string queryString = null) {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(queryString))
                serviceUrl = string.Format("{0}?{1}", serviceUrl, queryString);
            try {
                using (var client = new HttpClient()) {
                    client.BaseAddress = new Uri(ApplicationService.ServiceEndPoint);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApplicationService.Token);
                    var response = client.GetAsync(serviceUrl).Result;
                    response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                        result = response.Content.ReadAsStringAsync().Result;
                }
            } catch (HttpRequestException ex) {
                Errors.Add(ex.Message);
            } catch (Exception ex) {
                Errors.Add(ex.Message);
            }
            return result;
        }
        /// <summary>
        /// Gets service token for loading application data from secure restful services
        /// </summary>
        public static void GetServiceToken() {
            try {
                using (var client = new HttpClient()) {
                    var response = client.PostAsync(ServiceTokenEndPoint, new StringContent(_tokenRequestParameters, Encoding.UTF8)).Result;
                    var jsonString = response.Content.ReadAsStringAsync().Result;
                    var jsonSerializer = new JavaScriptSerializer();
                    var jsonObject = jsonSerializer.Deserialize(jsonString, typeof(object));
                    _responseDictionary = (Dictionary<string, object>)jsonObject;
                    if (_responseDictionary.ContainsKey("access_token"))
                        Token = _responseDictionary["access_token"].ToString();
                }
            } catch (HttpRequestException ex) {
                Errors.Add(ex.Message);
            } catch (Exception ex) {
                Errors.Add(ex.Message);
            }
        }
    }
}