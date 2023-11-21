# IO.Swagger.Api.RoadApi

All URIs are relative to *https://api.digital.tfl.gov.uk*

Method | HTTP request | Description
------------- | ------------- | -------------
[**RoadDisruptedStreets**](RoadApi.md#roaddisruptedstreets) | **GET** /Road/all/Street/Disruption | Gets a list of disrupted streets. If no date filters are provided, current disruptions are returned.
[**RoadDisruption**](RoadApi.md#roaddisruption) | **GET** /Road/{ids}/Disruption | Get active disruptions, filtered by road ids
[**RoadDisruptionById**](RoadApi.md#roaddisruptionbyid) | **GET** /Road/all/Disruption/{disruptionIds} | Gets a list of active disruptions filtered by disruption Ids.
[**RoadGet**](RoadApi.md#roadget) | **GET** /Road | Gets all roads managed by TfL
[**RoadGet_0**](RoadApi.md#roadget_0) | **GET** /Road/{ids} | Gets the road with the specified id (e.g. A1)
[**RoadMetaCategories**](RoadApi.md#roadmetacategories) | **GET** /Road/Meta/Categories | Gets a list of valid RoadDisruption categories
[**RoadMetaSeverities**](RoadApi.md#roadmetaseverities) | **GET** /Road/Meta/Severities | Gets a list of valid RoadDisruption severity codes
[**RoadStatus**](RoadApi.md#roadstatus) | **GET** /Road/{ids}/Status | Gets the specified roads with the status aggregated over the date range specified, or now until the end of today if no dates are passed.


<a name="roaddisruptedstreets"></a>
# **RoadDisruptedStreets**
> SystemObject RoadDisruptedStreets (DateTime? startDate, DateTime? endDate)

Gets a list of disrupted streets. If no date filters are provided, current disruptions are returned.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class RoadDisruptedStreetsExample
    {
        public void main()
        {
            var apiInstance = new RoadApi();
            var startDate = 2013-10-20T19:20:30+01:00;  // DateTime? | Optional, the start time to filter on.
            var endDate = 2013-10-20T19:20:30+01:00;  // DateTime? | Optional, The end time to filter on.

            try
            {
                // Gets a list of disrupted streets. If no date filters are provided, current disruptions are returned.
                SystemObject result = apiInstance.RoadDisruptedStreets(startDate, endDate);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling RoadApi.RoadDisruptedStreets: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **startDate** | **DateTime?**| Optional, the start time to filter on. | 
 **endDate** | **DateTime?**| Optional, The end time to filter on. | 

### Return type

[**SystemObject**](SystemObject.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="roaddisruption"></a>
# **RoadDisruption**
> List<TflApiPresentationEntitiesRoadDisruption> RoadDisruption (List<string> ids, bool? stripContent = null, List<string> severities = null, List<string> categories = null, bool? closures = null)

Get active disruptions, filtered by road ids

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class RoadDisruptionExample
    {
        public void main()
        {
            var apiInstance = new RoadApi();
            var ids = new List<string>(); // List<string> | Comma-separated list of road identifiers e.g. \"A406, A2\" use all for all to ignore id filter (a full list of supported road identifiers can be found at the /Road/ endpoint)
            var stripContent = true;  // bool? | Optional, defaults to false. When true, removes every property/node except for id, point, severity, severityDescription, startDate, endDate, corridor details, location, comments and streets (optional) 
            var severities = new List<string>(); // List<string> | an optional list of Severity names to filter on (a valid list of severities can be obtained from the /Road/Meta/severities endpoint) (optional) 
            var categories = new List<string>(); // List<string> | an optional list of category names to filter on (a valid list of categories can be obtained from the /Road/Meta/categories endpoint) (optional) 
            var closures = true;  // bool? | Optional, defaults to true. When true, always includes disruptions that have road closures, regardless of the severity filter. When false, the severity filter works as normal. (optional) 

            try
            {
                // Get active disruptions, filtered by road ids
                List&lt;TflApiPresentationEntitiesRoadDisruption&gt; result = apiInstance.RoadDisruption(ids, stripContent, severities, categories, closures);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling RoadApi.RoadDisruption: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ids** | [**List&lt;string&gt;**](string.md)| Comma-separated list of road identifiers e.g. \&quot;A406, A2\&quot; use all for all to ignore id filter (a full list of supported road identifiers can be found at the /Road/ endpoint) | 
 **stripContent** | **bool?**| Optional, defaults to false. When true, removes every property/node except for id, point, severity, severityDescription, startDate, endDate, corridor details, location, comments and streets | [optional] 
 **severities** | [**List&lt;string&gt;**](string.md)| an optional list of Severity names to filter on (a valid list of severities can be obtained from the /Road/Meta/severities endpoint) | [optional] 
 **categories** | [**List&lt;string&gt;**](string.md)| an optional list of category names to filter on (a valid list of categories can be obtained from the /Road/Meta/categories endpoint) | [optional] 
 **closures** | **bool?**| Optional, defaults to true. When true, always includes disruptions that have road closures, regardless of the severity filter. When false, the severity filter works as normal. | [optional] 

### Return type

[**List<TflApiPresentationEntitiesRoadDisruption>**](TflApiPresentationEntitiesRoadDisruption.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml, application/geo+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="roaddisruptionbyid"></a>
# **RoadDisruptionById**
> TflApiPresentationEntitiesRoadDisruption RoadDisruptionById (List<string> disruptionIds, bool? stripContent = null)

Gets a list of active disruptions filtered by disruption Ids.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class RoadDisruptionByIdExample
    {
        public void main()
        {
            var apiInstance = new RoadApi();
            var disruptionIds = new List<string>(); // List<string> | Comma-separated list of disruption identifiers to filter by.
            var stripContent = true;  // bool? | Optional, defaults to false. When true, removes every property/node except for id, point, severity, severityDescription, startDate, endDate, corridor details, location and comments. (optional) 

            try
            {
                // Gets a list of active disruptions filtered by disruption Ids.
                TflApiPresentationEntitiesRoadDisruption result = apiInstance.RoadDisruptionById(disruptionIds, stripContent);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling RoadApi.RoadDisruptionById: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **disruptionIds** | [**List&lt;string&gt;**](string.md)| Comma-separated list of disruption identifiers to filter by. | 
 **stripContent** | **bool?**| Optional, defaults to false. When true, removes every property/node except for id, point, severity, severityDescription, startDate, endDate, corridor details, location and comments. | [optional] 

### Return type

[**TflApiPresentationEntitiesRoadDisruption**](TflApiPresentationEntitiesRoadDisruption.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml, application/geo+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="roadget"></a>
# **RoadGet**
> List<TflApiPresentationEntitiesRoadCorridor> RoadGet ()

Gets all roads managed by TfL

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class RoadGetExample
    {
        public void main()
        {
            var apiInstance = new RoadApi();

            try
            {
                // Gets all roads managed by TfL
                List&lt;TflApiPresentationEntitiesRoadCorridor&gt; result = apiInstance.RoadGet();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling RoadApi.RoadGet: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**List<TflApiPresentationEntitiesRoadCorridor>**](TflApiPresentationEntitiesRoadCorridor.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="roadget_0"></a>
# **RoadGet_0**
> List<TflApiPresentationEntitiesRoadCorridor> RoadGet_0 (List<string> ids)

Gets the road with the specified id (e.g. A1)

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class RoadGet_0Example
    {
        public void main()
        {
            var apiInstance = new RoadApi();
            var ids = new List<string>(); // List<string> | Comma-separated list of road identifiers e.g. \"A406, A2\" (a full list of supported road identifiers can be found at the /Road/ endpoint)

            try
            {
                // Gets the road with the specified id (e.g. A1)
                List&lt;TflApiPresentationEntitiesRoadCorridor&gt; result = apiInstance.RoadGet_0(ids);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling RoadApi.RoadGet_0: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ids** | [**List&lt;string&gt;**](string.md)| Comma-separated list of road identifiers e.g. \&quot;A406, A2\&quot; (a full list of supported road identifiers can be found at the /Road/ endpoint) | 

### Return type

[**List<TflApiPresentationEntitiesRoadCorridor>**](TflApiPresentationEntitiesRoadCorridor.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="roadmetacategories"></a>
# **RoadMetaCategories**
> List<string> RoadMetaCategories ()

Gets a list of valid RoadDisruption categories

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class RoadMetaCategoriesExample
    {
        public void main()
        {
            var apiInstance = new RoadApi();

            try
            {
                // Gets a list of valid RoadDisruption categories
                List&lt;string&gt; result = apiInstance.RoadMetaCategories();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling RoadApi.RoadMetaCategories: " + e.Message );
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

<a name="roadmetaseverities"></a>
# **RoadMetaSeverities**
> List<TflApiPresentationEntitiesStatusSeverity> RoadMetaSeverities ()

Gets a list of valid RoadDisruption severity codes

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class RoadMetaSeveritiesExample
    {
        public void main()
        {
            var apiInstance = new RoadApi();

            try
            {
                // Gets a list of valid RoadDisruption severity codes
                List&lt;TflApiPresentationEntitiesStatusSeverity&gt; result = apiInstance.RoadMetaSeverities();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling RoadApi.RoadMetaSeverities: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**List<TflApiPresentationEntitiesStatusSeverity>**](TflApiPresentationEntitiesStatusSeverity.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="roadstatus"></a>
# **RoadStatus**
> List<TflApiPresentationEntitiesRoadCorridor> RoadStatus (List<string> ids, DateTime? dateRangeNullableStartDate = null, DateTime? dateRangeNullableEndDate = null)

Gets the specified roads with the status aggregated over the date range specified, or now until the end of today if no dates are passed.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class RoadStatusExample
    {
        public void main()
        {
            var apiInstance = new RoadApi();
            var ids = new List<string>(); // List<string> | Comma-separated list of road identifiers e.g. \"A406, A2\" or use \"all\" to ignore id filter (a full list of supported road identifiers can be found at the /Road/ endpoint)
            var dateRangeNullableStartDate = 2013-10-20T19:20:30+01:00;  // DateTime? |  (optional) 
            var dateRangeNullableEndDate = 2013-10-20T19:20:30+01:00;  // DateTime? |  (optional) 

            try
            {
                // Gets the specified roads with the status aggregated over the date range specified, or now until the end of today if no dates are passed.
                List&lt;TflApiPresentationEntitiesRoadCorridor&gt; result = apiInstance.RoadStatus(ids, dateRangeNullableStartDate, dateRangeNullableEndDate);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling RoadApi.RoadStatus: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ids** | [**List&lt;string&gt;**](string.md)| Comma-separated list of road identifiers e.g. \&quot;A406, A2\&quot; or use \&quot;all\&quot; to ignore id filter (a full list of supported road identifiers can be found at the /Road/ endpoint) | 
 **dateRangeNullableStartDate** | **DateTime?**|  | [optional] 
 **dateRangeNullableEndDate** | **DateTime?**|  | [optional] 

### Return type

[**List<TflApiPresentationEntitiesRoadCorridor>**](TflApiPresentationEntitiesRoadCorridor.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

