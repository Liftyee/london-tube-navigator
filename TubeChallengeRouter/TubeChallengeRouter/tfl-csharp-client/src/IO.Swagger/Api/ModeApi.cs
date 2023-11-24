/* 
 * Transport for London Unified API
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: v1
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using RestSharp;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace IO.Swagger.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IModeApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Gets the next arrival predictions for all stops of a given mode
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="mode">A mode name e.g. tube, dlr</param>
        /// <param name="count">A number of arrivals to return for each stop, -1 to return all available. (optional)</param>
        /// <returns>List&lt;TflApiPresentationEntitiesPrediction&gt;</returns>
        List<TflApiPresentationEntitiesPrediction> ModeArrivals (string mode, int? count = null);

        /// <summary>
        /// Gets the next arrival predictions for all stops of a given mode
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="mode">A mode name e.g. tube, dlr</param>
        /// <param name="count">A number of arrivals to return for each stop, -1 to return all available. (optional)</param>
        /// <returns>ApiResponse of List&lt;TflApiPresentationEntitiesPrediction&gt;</returns>
        ApiResponse<List<TflApiPresentationEntitiesPrediction>> ModeArrivalsWithHttpInfo (string mode, int? count = null);
        /// <summary>
        /// Returns the service type active for a mode.              Currently only supports tube
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>List&lt;TflApiPresentationEntitiesActiveServiceType&gt;</returns>
        List<TflApiPresentationEntitiesActiveServiceType> ModeGetActiveServiceTypes ();

        /// <summary>
        /// Returns the service type active for a mode.              Currently only supports tube
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of List&lt;TflApiPresentationEntitiesActiveServiceType&gt;</returns>
        ApiResponse<List<TflApiPresentationEntitiesActiveServiceType>> ModeGetActiveServiceTypesWithHttpInfo ();
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// Gets the next arrival predictions for all stops of a given mode
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="mode">A mode name e.g. tube, dlr</param>
        /// <param name="count">A number of arrivals to return for each stop, -1 to return all available. (optional)</param>
        /// <returns>Task of List&lt;TflApiPresentationEntitiesPrediction&gt;</returns>
        System.Threading.Tasks.Task<List<TflApiPresentationEntitiesPrediction>> ModeArrivalsAsync (string mode, int? count = null);

        /// <summary>
        /// Gets the next arrival predictions for all stops of a given mode
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="mode">A mode name e.g. tube, dlr</param>
        /// <param name="count">A number of arrivals to return for each stop, -1 to return all available. (optional)</param>
        /// <returns>Task of ApiResponse (List&lt;TflApiPresentationEntitiesPrediction&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<TflApiPresentationEntitiesPrediction>>> ModeArrivalsAsyncWithHttpInfo (string mode, int? count = null);
        /// <summary>
        /// Returns the service type active for a mode.              Currently only supports tube
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of List&lt;TflApiPresentationEntitiesActiveServiceType&gt;</returns>
        System.Threading.Tasks.Task<List<TflApiPresentationEntitiesActiveServiceType>> ModeGetActiveServiceTypesAsync ();

        /// <summary>
        /// Returns the service type active for a mode.              Currently only supports tube
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (List&lt;TflApiPresentationEntitiesActiveServiceType&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<TflApiPresentationEntitiesActiveServiceType>>> ModeGetActiveServiceTypesAsyncWithHttpInfo ();
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class ModeApi : IModeApi
    {
        private IO.Swagger.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModeApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ModeApi(String basePath)
        {
            this.Configuration = new IO.Swagger.Client.Configuration { BasePath = basePath };

            ExceptionFactory = IO.Swagger.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModeApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public ModeApi(IO.Swagger.Client.Configuration configuration = null)
        {
            if (configuration == null) // use the default one in Configuration
                this.Configuration = IO.Swagger.Client.Configuration.Default;
            else
                this.Configuration = configuration;

            ExceptionFactory = IO.Swagger.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public String GetBasePath()
        {
            return this.Configuration.ApiClient.RestClient.BaseUrl.ToString();
        }

        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        [Obsolete("SetBasePath is deprecated, please do 'Configuration.ApiClient = new ApiClient(\"http://new-path\")' instead.")]
        public void SetBasePath(String basePath)
        {
            // do nothing
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public IO.Swagger.Client.Configuration Configuration {get; set;}

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public IO.Swagger.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// Gets the default header.
        /// </summary>
        /// <returns>Dictionary of HTTP header</returns>
        [Obsolete("DefaultHeader is deprecated, please use Configuration.DefaultHeader instead.")]
        public IDictionary<String, String> DefaultHeader()
        {
            return new ReadOnlyDictionary<string, string>(this.Configuration.DefaultHeader);
        }

        /// <summary>
        /// Add default header.
        /// </summary>
        /// <param name="key">Header field name.</param>
        /// <param name="value">Header field value.</param>
        /// <returns></returns>
        [Obsolete("AddDefaultHeader is deprecated, please use Configuration.AddDefaultHeader instead.")]
        public void AddDefaultHeader(string key, string value)
        {
            this.Configuration.AddDefaultHeader(key, value);
        }

        /// <summary>
        /// Gets the next arrival predictions for all stops of a given mode 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="mode">A mode name e.g. tube, dlr</param>
        /// <param name="count">A number of arrivals to return for each stop, -1 to return all available. (optional)</param>
        /// <returns>List&lt;TflApiPresentationEntitiesPrediction&gt;</returns>
        public List<TflApiPresentationEntitiesPrediction> ModeArrivals (string mode, int? count = null)
        {
             ApiResponse<List<TflApiPresentationEntitiesPrediction>> localVarResponse = ModeArrivalsWithHttpInfo(mode, count);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Gets the next arrival predictions for all stops of a given mode 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="mode">A mode name e.g. tube, dlr</param>
        /// <param name="count">A number of arrivals to return for each stop, -1 to return all available. (optional)</param>
        /// <returns>ApiResponse of List&lt;TflApiPresentationEntitiesPrediction&gt;</returns>
        public ApiResponse< List<TflApiPresentationEntitiesPrediction> > ModeArrivalsWithHttpInfo (string mode, int? count = null)
        {
            // verify the required parameter 'mode' is set
            if (mode == null)
                throw new ApiException(400, "Missing required parameter 'mode' when calling ModeApi->ModeArrivals");

            var localVarPath = "/Mode/{mode}/Arrivals";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json",
                "text/json",
                "application/xml",
                "text/xml"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (mode != null) localVarPathParams.Add("mode", this.Configuration.ApiClient.ParameterToString(mode)); // path parameter
            if (count != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "count", count)); // query parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("ModeArrivals", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<TflApiPresentationEntitiesPrediction>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<TflApiPresentationEntitiesPrediction>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<TflApiPresentationEntitiesPrediction>)));
        }

        /// <summary>
        /// Gets the next arrival predictions for all stops of a given mode 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="mode">A mode name e.g. tube, dlr</param>
        /// <param name="count">A number of arrivals to return for each stop, -1 to return all available. (optional)</param>
        /// <returns>Task of List&lt;TflApiPresentationEntitiesPrediction&gt;</returns>
        public async System.Threading.Tasks.Task<List<TflApiPresentationEntitiesPrediction>> ModeArrivalsAsync (string mode, int? count = null)
        {
             ApiResponse<List<TflApiPresentationEntitiesPrediction>> localVarResponse = await ModeArrivalsAsyncWithHttpInfo(mode, count);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Gets the next arrival predictions for all stops of a given mode 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="mode">A mode name e.g. tube, dlr</param>
        /// <param name="count">A number of arrivals to return for each stop, -1 to return all available. (optional)</param>
        /// <returns>Task of ApiResponse (List&lt;TflApiPresentationEntitiesPrediction&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<TflApiPresentationEntitiesPrediction>>> ModeArrivalsAsyncWithHttpInfo (string mode, int? count = null)
        {
            // verify the required parameter 'mode' is set
            if (mode == null)
                throw new ApiException(400, "Missing required parameter 'mode' when calling ModeApi->ModeArrivals");

            var localVarPath = "/Mode/{mode}/Arrivals";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json",
                "text/json",
                "application/xml",
                "text/xml"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (mode != null) localVarPathParams.Add("mode", this.Configuration.ApiClient.ParameterToString(mode)); // path parameter
            if (count != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "count", count)); // query parameter


            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("ModeArrivals", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<TflApiPresentationEntitiesPrediction>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<TflApiPresentationEntitiesPrediction>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<TflApiPresentationEntitiesPrediction>)));
        }

        /// <summary>
        /// Returns the service type active for a mode.              Currently only supports tube 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>List&lt;TflApiPresentationEntitiesActiveServiceType&gt;</returns>
        public List<TflApiPresentationEntitiesActiveServiceType> ModeGetActiveServiceTypes ()
        {
             ApiResponse<List<TflApiPresentationEntitiesActiveServiceType>> localVarResponse = ModeGetActiveServiceTypesWithHttpInfo();
             return localVarResponse.Data;
        }

        /// <summary>
        /// Returns the service type active for a mode.              Currently only supports tube 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of List&lt;TflApiPresentationEntitiesActiveServiceType&gt;</returns>
        public ApiResponse< List<TflApiPresentationEntitiesActiveServiceType> > ModeGetActiveServiceTypesWithHttpInfo ()
        {

            var localVarPath = "/Mode/ActiveServiceTypes";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json",
                "text/json",
                "application/xml",
                "text/xml"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);



            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("ModeGetActiveServiceTypes", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<TflApiPresentationEntitiesActiveServiceType>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<TflApiPresentationEntitiesActiveServiceType>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<TflApiPresentationEntitiesActiveServiceType>)));
        }

        /// <summary>
        /// Returns the service type active for a mode.              Currently only supports tube 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of List&lt;TflApiPresentationEntitiesActiveServiceType&gt;</returns>
        public async System.Threading.Tasks.Task<List<TflApiPresentationEntitiesActiveServiceType>> ModeGetActiveServiceTypesAsync ()
        {
             ApiResponse<List<TflApiPresentationEntitiesActiveServiceType>> localVarResponse = await ModeGetActiveServiceTypesAsyncWithHttpInfo();
             return localVarResponse.Data;

        }

        /// <summary>
        /// Returns the service type active for a mode.              Currently only supports tube 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (List&lt;TflApiPresentationEntitiesActiveServiceType&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<TflApiPresentationEntitiesActiveServiceType>>> ModeGetActiveServiceTypesAsyncWithHttpInfo ()
        {

            var localVarPath = "/Mode/ActiveServiceTypes";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json",
                "text/json",
                "application/xml",
                "text/xml"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);



            // make the HTTP request
            RestResponse localVarResponse = (RestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("ModeGetActiveServiceTypes", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<TflApiPresentationEntitiesActiveServiceType>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<TflApiPresentationEntitiesActiveServiceType>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<TflApiPresentationEntitiesActiveServiceType>)));
        }

    }
}
