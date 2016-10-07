using HomeProperty.Settings.Constant;
using HomeProperty.WebApp.Models.Enum;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace HomeProperty.WebApp.Models {
    /// <summary>
    /// Serves the base class for all view model service.
    /// It provides common functionality for all View Model Service 
    /// </summary>
    public class ServiceModelBase {

        /// <summary>
        /// Service token endpont of restful service.
        /// </summary>
        protected string _ServiceTokenEndPoint { get; private set; }
        /// <summary>
        /// Token that authorizes a resource owner to access his/her restful resources.
        /// On Application_Start in Global.asax.cs, we make a call to grab the service account token.
        /// </summary>
        protected string _ServiceAccountToken { get; private set; }
        /// <summary>
        /// The user account token 
        /// </summary>
        protected string _UserAccountToken { get; private set; }
        /// <summary>
        /// The registered username of the authorized user.
        /// When the user sign in, we need the username and password 
        /// for retrieving the token for the user. 
        /// </summary>
        protected string _ServiceUsername { get; set; }
        /// <summary>
        /// The registered password of the authorized user.
        /// </summary>
        protected string _ServicePassword { get; set; }
        /// <summary>
        /// The OAuth2 grant type. We are using password grant for this project.
        /// </summary>
        protected string _GrantType { get; private set; }
        /// <summary>
        /// The restful service endpont 
        /// </summary>
        protected string _ServiceEndPoint { get; private set; }
        /// <summary>
        /// The token request query string parameters for resting token from 
        /// authorization server.
        /// </summary>
        private string _tokenRequestParameters;
        public IList<string> Errors { get; private set; }
        /// <summary>
        /// The response dictionary container to store response from the service
        /// </summary>
        private IDictionary<string, object> _responseDictionary { get; set; }
        /// <summary>
        /// The current culture 
        /// </summary>
        private string _currentCulture;
        /// <summary>
        /// Contructs this ServiceModelBase object with initilization.
        /// </summary>

        protected ICacheManager _CacheManager { get; private set; }

        public ServiceModelBase(ICacheManager cacheManager) {
            _CacheManager = cacheManager;
        }

        public ServiceModelBase()
            : this(ServiceModelFactory.CacheManager) {

            Errors = new List<string>();

            _responseDictionary = new Dictionary<string, object>();

            _ServiceTokenEndPoint = ConfigurationManager.AppSettings.Get("serviceTokenEndPoint");
            _ServiceUsername = ConfigurationManager.AppSettings.Get("serviceUsername");
            _ServicePassword = ConfigurationManager.AppSettings.Get("servicePassword");
            _GrantType = ConfigurationManager.AppSettings.Get("grantType");
            _ServiceEndPoint = ConfigurationManager.AppSettings.Get("serviceEndPoint");

            // Validate required input data 
            ValidateServiceData();

            //if (!string.IsNullOrEmpty(_ServiceTokenEndPoint)
            //    && !string.IsNullOrEmpty(_ServiceUsername)
            //    && !string.IsNullOrEmpty(_ServicePassword))

            _tokenRequestParameters = string.Format("grant_type={0}&username={1}&password={2}",
                _GrantType, _ServiceUsername, _ServicePassword);

            // Get service token
            _ServiceAccountToken = GetServiceToken();
        }

        /// <summary>
        /// Validates required data for restful service operations.
        /// </summary>
        private void ValidateServiceData() {

            if (string.IsNullOrEmpty(_ServiceTokenEndPoint))
                throw new ArgumentException("Service Token Endpoint is required.");

            if (string.IsNullOrEmpty(_ServiceUsername))
                throw new ArgumentException("Service Username is required.");

            if (string.IsNullOrEmpty(_ServicePassword))
                throw new ArgumentException("Service Password is required.");

            if (string.IsNullOrEmpty(_GrantType))
                throw new ArgumentException("Grant Type of OAuth2 is required.");

            if (string.IsNullOrEmpty(_ServiceEndPoint))
                throw new ArgumentException("Service EndPont is required.");
        }

        /// <summary>
        /// Gets current culture.
        /// </summary>
        /// <returns>The current culture as string.</returns>
        protected string GetCurrentCulture() {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["_culture"];
            if (cookie != null)
                return cookie.Value;
            return Constant.EnglishUsCulture;
        }

        /// <summary>
        /// Makes GET service call.
        /// </summary>
        /// <param name="serviceUrl">The service URL</param>
        /// <returns>The json string result</returns>
        protected string MakeServiceRequestCall(string serviceUrl, string queryString = null) {

            if (string.IsNullOrEmpty(_ServiceAccountToken) && string.IsNullOrEmpty(_UserAccountToken))
                throw new ArgumentNullException("Service token is null.");

            if (string.IsNullOrEmpty(_ServiceEndPoint))
                throw new ArgumentNullException("Service end point is null.");

            var result = string.Empty;
            if (!string.IsNullOrEmpty(queryString))
                serviceUrl = string.Format("{0}?{1}", serviceUrl, queryString);

            using (var client = new HttpClient()) {

                client.BaseAddress = new Uri(_ServiceEndPoint);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _ServiceAccountToken);

                var response = client.GetAsync(serviceUrl).Result;

                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                    result = response.Content.ReadAsStringAsync().Result;
            }

            return result;
        }
        /// <summary>
        /// Gets service token for loading application data from secure restful services
        /// </summary>
        public string GetServiceToken() {

            using (var client = new HttpClient()) {

                var response = client.PostAsync(_ServiceTokenEndPoint,
                    new StringContent(_tokenRequestParameters, Encoding.UTF8)).Result;

                var result = response.Content.ReadAsStringAsync().Result;

                var serializer = new JavaScriptSerializer();
                var jsonObject = serializer.Deserialize(result, typeof(object));

                _responseDictionary = (Dictionary<string, object>)jsonObject;

                if (_responseDictionary.ContainsKey("access_token"))
                    return _responseDictionary["access_token"].ToString();

            }
            return string.Empty;
        }

        /// <summary>
        /// Get resources from Cache by culture
        /// </summary>
        /// <param name="key">The cache key</param>
        /// <param name="uri">The restful URI</param>
        /// <returns></returns>
        protected string GetResourceFromCache(string key, string uri) {
            _currentCulture = GetCurrentCulture();
            return _CacheManager.GetOrSet(string.Format("{0}_{1}", key, _currentCulture),
              () => MakeServiceRequestCall(uri,
                   string.Format("culture={0}", _currentCulture)));
        }

        protected string MakeRequestCall(string serviceUrl, string jsonString = null, ApiServiceType apiServiceType = ApiServiceType.Post) {

            var result = string.Empty;

            using (var client = new HttpClient()) {
                client.BaseAddress = new Uri(_ServiceEndPoint);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _ServiceAccountToken);

                HttpResponseMessage response = null;

                switch (apiServiceType) {
                    case ApiServiceType.Delete:
                        response = client.DeleteAsync(serviceUrl).Result;
                        break;
                    case ApiServiceType.Post:
                        response = client.PostAsync(serviceUrl, new StringContent(jsonString, null, "application/json")).Result;
                        break;
                    case ApiServiceType.Put:
                        response = client.PutAsync(serviceUrl, new StringContent(jsonString, null, "application/json")).Result;
                        break;
                }

                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                    result = response.Content.ReadAsStringAsync().Result;
            }

            return result;
        }

        protected string DeleteRequestService(string serviceUrl, string jsonString = null) {
            return MakeRequestCall(serviceUrl, jsonString, ApiServiceType.Delete);
        }

        protected string PostRequestService(string serviceUrl, string jsonString = null) {
            return MakeRequestCall(serviceUrl, jsonString, ApiServiceType.Post);
        }

        protected string PutRequestService(string serviceUrl, string jsonString = null) {
            return MakeRequestCall(serviceUrl, jsonString, ApiServiceType.Put);
        }
    }
}