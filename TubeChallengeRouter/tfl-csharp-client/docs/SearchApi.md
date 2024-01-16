# IO.Swagger.Api.SearchApi

All URIs are relative to *https://api.digital.tfl.gov.uk*

Method | HTTP request | Description
------------- | ------------- | -------------
[**SearchBusSchedules**](SearchApi.md#searchbusschedules) | **GET** /Search/BusSchedules | Searches the bus schedules folder on S3 for a given bus number.
[**SearchGet**](SearchApi.md#searchget) | **GET** /Search | Search the site for occurrences of the query string. The maximum number of results returned is equal to the maximum page size              of 100. To return subsequent pages, use the paginated overload.
[**SearchMetaCategories**](SearchApi.md#searchmetacategories) | **GET** /Search/Meta/Categories | Gets the available search categories.
[**SearchMetaSearchProviders**](SearchApi.md#searchmetasearchproviders) | **GET** /Search/Meta/SearchProviders | Gets the available searchProvider names.
[**SearchMetaSorts**](SearchApi.md#searchmetasorts) | **GET** /Search/Meta/Sorts | Gets the available sorting options.


<a name="searchbusschedules"></a>
# **SearchBusSchedules**
> TflApiPresentationEntitiesSearchResponse SearchBusSchedules (string query)

Searches the bus schedules folder on S3 for a given bus number.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class SearchBusSchedulesExample
    {
        public void main()
        {
            var apiInstance = new SearchApi();
            var query = query_example;  // string | The search query

            try
            {
                // Searches the bus schedules folder on S3 for a given bus number.
                TflApiPresentationEntitiesSearchResponse result = apiInstance.SearchBusSchedules(query);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SearchApi.SearchBusSchedules: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **query** | **string**| The search query | 

### Return type

[**TflApiPresentationEntitiesSearchResponse**](TflApiPresentationEntitiesSearchResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="searchget"></a>
# **SearchGet**
> TflApiPresentationEntitiesSearchResponse SearchGet (string query)

Search the site for occurrences of the query string. The maximum number of results returned is equal to the maximum page size              of 100. To return subsequent pages, use the paginated overload.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class SearchGetExample
    {
        public void main()
        {
            var apiInstance = new SearchApi();
            var query = query_example;  // string | The search query

            try
            {
                // Search the site for occurrences of the query string. The maximum number of results returned is equal to the maximum page size              of 100. To return subsequent pages, use the paginated overload.
                TflApiPresentationEntitiesSearchResponse result = apiInstance.SearchGet(query);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SearchApi.SearchGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **query** | **string**| The search query | 

### Return type

[**TflApiPresentationEntitiesSearchResponse**](TflApiPresentationEntitiesSearchResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="searchmetacategories"></a>
# **SearchMetaCategories**
> List<string> SearchMetaCategories ()

Gets the available search categories.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class SearchMetaCategoriesExample
    {
        public void main()
        {
            var apiInstance = new SearchApi();

            try
            {
                // Gets the available search categories.
                List&lt;string&gt; result = apiInstance.SearchMetaCategories();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SearchApi.SearchMetaCategories: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

**List<string>**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="searchmetasearchproviders"></a>
# **SearchMetaSearchProviders**
> List<string> SearchMetaSearchProviders ()

Gets the available searchProvider names.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class SearchMetaSearchProvidersExample
    {
        public void main()
        {
            var apiInstance = new SearchApi();

            try
            {
                // Gets the available searchProvider names.
                List&lt;string&gt; result = apiInstance.SearchMetaSearchProviders();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SearchApi.SearchMetaSearchProviders: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

**List<string>**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="searchmetasorts"></a>
# **SearchMetaSorts**
> List<string> SearchMetaSorts ()

Gets the available sorting options.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class SearchMetaSortsExample
    {
        public void main()
        {
            var apiInstance = new SearchApi();

            try
            {
                // Gets the available sorting options.
                List&lt;string&gt; result = apiInstance.SearchMetaSorts();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SearchApi.SearchMetaSorts: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

**List<string>**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

