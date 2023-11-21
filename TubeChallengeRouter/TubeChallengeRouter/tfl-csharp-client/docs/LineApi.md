# IO.Swagger.Api.LineApi

All URIs are relative to *https://api.digital.tfl.gov.uk*

Method | HTTP request | Description
------------- | ------------- | -------------
[**LineArrivals**](LineApi.md#linearrivals) | **GET** /Line/{ids}/Arrivals/{stopPointId} | Get the list of arrival predictions for given line ids based at the given stop
[**LineDisruption**](LineApi.md#linedisruption) | **GET** /Line/{ids}/Disruption | Get disruptions for the given line ids
[**LineDisruptionByMode**](LineApi.md#linedisruptionbymode) | **GET** /Line/Mode/{modes}/Disruption | Get disruptions for all lines of the given modes.
[**LineGet**](LineApi.md#lineget) | **GET** /Line/{ids} | Gets lines that match the specified line ids.
[**LineGetByMode**](LineApi.md#linegetbymode) | **GET** /Line/Mode/{modes} | Gets lines that serve the given modes.
[**LineLineRoutesByIds**](LineApi.md#linelineroutesbyids) | **GET** /Line/{ids}/Route | Get all valid routes for given line ids, including the name and id of the originating and terminating stops for each route.
[**LineMetaDisruptionCategories**](LineApi.md#linemetadisruptioncategories) | **GET** /Line/Meta/DisruptionCategories | Gets a list of valid disruption categories
[**LineMetaModes**](LineApi.md#linemetamodes) | **GET** /Line/Meta/Modes | Gets a list of valid modes
[**LineMetaServiceTypes**](LineApi.md#linemetaservicetypes) | **GET** /Line/Meta/ServiceTypes | Gets a list of valid ServiceTypes to filter on
[**LineMetaSeverity**](LineApi.md#linemetaseverity) | **GET** /Line/Meta/Severity | Gets a list of valid severity codes
[**LineRoute**](LineApi.md#lineroute) | **GET** /Line/Route | Get all valid routes for all lines, including the name and id of the originating and terminating stops for each route.
[**LineRouteByMode**](LineApi.md#lineroutebymode) | **GET** /Line/Mode/{modes}/Route | Gets all lines and their valid routes for given modes, including the name and id of the originating and terminating stops for each route
[**LineRouteSequence**](LineApi.md#lineroutesequence) | **GET** /Line/{id}/Route/Sequence/{direction} | Gets all valid routes for given line id, including the sequence of stops on each route.
[**LineSearch**](LineApi.md#linesearch) | **GET** /Line/Search/{query} | Search for lines or routes matching the query string
[**LineStatus**](LineApi.md#linestatus) | **GET** /Line/{ids}/Status/{StartDate}/to/{EndDate} | Gets the line status for given line ids during the provided dates e.g Minor Delays
[**LineStatusByIds**](LineApi.md#linestatusbyids) | **GET** /Line/{ids}/Status | Gets the line status of for given line ids e.g Minor Delays
[**LineStatusByMode**](LineApi.md#linestatusbymode) | **GET** /Line/Mode/{modes}/Status | Gets the line status of for all lines for the given modes
[**LineStatusBySeverity**](LineApi.md#linestatusbyseverity) | **GET** /Line/Status/{severity} | Gets the line status for all lines with a given severity              A list of valid severity codes can be obtained from a call to Line/Meta/Severity
[**LineStopPoints**](LineApi.md#linestoppoints) | **GET** /Line/{id}/StopPoints | Gets a list of the stations that serve the given line id
[**LineTimetable**](LineApi.md#linetimetable) | **GET** /Line/{id}/Timetable/{fromStopPointId} | Gets the timetable for a specified station on the give line
[**LineTimetableTo**](LineApi.md#linetimetableto) | **GET** /Line/{id}/Timetable/{fromStopPointId}/to/{toStopPointId} | Gets the timetable for a specified station on the give line with specified destination


<a name="linearrivals"></a>
# **LineArrivals**
> List<TflApiPresentationEntitiesPrediction> LineArrivals (List<string> ids, string stopPointId, string direction = null, string destinationStationId = null)

Get the list of arrival predictions for given line ids based at the given stop

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class LineArrivalsExample
    {
        public void main()
        {
            var apiInstance = new LineApi();
            var ids = new List<string>(); // List<string> | A comma-separated list of line ids e.g. victoria,circle,N133. Max. approx. 20 ids.
            var stopPointId = stopPointId_example;  // string | Optional. Id of stop to get arrival predictions for (station naptan code e.g. 940GZZLUASL, you can use /StopPoint/Search/{query} endpoint to find a stop point id from a station name)
            var direction = direction_example;  // string | Optional. The direction of travel. Can be inbound or outbound or all. If left blank, and destinationStopId is set, will default to all (optional) 
            var destinationStationId = destinationStationId_example;  // string | Optional. Id of destination stop (optional) 

            try
            {
                // Get the list of arrival predictions for given line ids based at the given stop
                List&lt;TflApiPresentationEntitiesPrediction&gt; result = apiInstance.LineArrivals(ids, stopPointId, direction, destinationStationId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling LineApi.LineArrivals: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ids** | [**List&lt;string&gt;**](string.md)| A comma-separated list of line ids e.g. victoria,circle,N133. Max. approx. 20 ids. | 
 **stopPointId** | **string**| Optional. Id of stop to get arrival predictions for (station naptan code e.g. 940GZZLUASL, you can use /StopPoint/Search/{query} endpoint to find a stop point id from a station name) | 
 **direction** | **string**| Optional. The direction of travel. Can be inbound or outbound or all. If left blank, and destinationStopId is set, will default to all | [optional] 
 **destinationStationId** | **string**| Optional. Id of destination stop | [optional] 

### Return type

[**List<TflApiPresentationEntitiesPrediction>**](TflApiPresentationEntitiesPrediction.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="linedisruption"></a>
# **LineDisruption**
> List<TflApiPresentationEntitiesDisruption> LineDisruption (List<string> ids)

Get disruptions for the given line ids

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class LineDisruptionExample
    {
        public void main()
        {
            var apiInstance = new LineApi();
            var ids = new List<string>(); // List<string> | A comma-separated list of line ids e.g. victoria,circle,N133. Max. approx. 20 ids.

            try
            {
                // Get disruptions for the given line ids
                List&lt;TflApiPresentationEntitiesDisruption&gt; result = apiInstance.LineDisruption(ids);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling LineApi.LineDisruption: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ids** | [**List&lt;string&gt;**](string.md)| A comma-separated list of line ids e.g. victoria,circle,N133. Max. approx. 20 ids. | 

### Return type

[**List<TflApiPresentationEntitiesDisruption>**](TflApiPresentationEntitiesDisruption.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="linedisruptionbymode"></a>
# **LineDisruptionByMode**
> List<TflApiPresentationEntitiesDisruption> LineDisruptionByMode (List<string> modes)

Get disruptions for all lines of the given modes.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class LineDisruptionByModeExample
    {
        public void main()
        {
            var apiInstance = new LineApi();
            var modes = new List<string>(); // List<string> | A comma-separated list of modes e.g. tube,dlr

            try
            {
                // Get disruptions for all lines of the given modes.
                List&lt;TflApiPresentationEntitiesDisruption&gt; result = apiInstance.LineDisruptionByMode(modes);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling LineApi.LineDisruptionByMode: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **modes** | [**List&lt;string&gt;**](string.md)| A comma-separated list of modes e.g. tube,dlr | 

### Return type

[**List<TflApiPresentationEntitiesDisruption>**](TflApiPresentationEntitiesDisruption.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="lineget"></a>
# **LineGet**
> List<TflApiPresentationEntitiesLine> LineGet (List<string> ids)

Gets lines that match the specified line ids.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class LineGetExample
    {
        public void main()
        {
            var apiInstance = new LineApi();
            var ids = new List<string>(); // List<string> | A comma-separated list of line ids e.g. victoria,circle,N133. Max. approx. 20 ids.

            try
            {
                // Gets lines that match the specified line ids.
                List&lt;TflApiPresentationEntitiesLine&gt; result = apiInstance.LineGet(ids);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling LineApi.LineGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ids** | [**List&lt;string&gt;**](string.md)| A comma-separated list of line ids e.g. victoria,circle,N133. Max. approx. 20 ids. | 

### Return type

[**List<TflApiPresentationEntitiesLine>**](TflApiPresentationEntitiesLine.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="linegetbymode"></a>
# **LineGetByMode**
> List<TflApiPresentationEntitiesLine> LineGetByMode (List<string> modes)

Gets lines that serve the given modes.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class LineGetByModeExample
    {
        public void main()
        {
            var apiInstance = new LineApi();
            var modes = new List<string>(); // List<string> | A comma-separated list of modes e.g. tube,dlr

            try
            {
                // Gets lines that serve the given modes.
                List&lt;TflApiPresentationEntitiesLine&gt; result = apiInstance.LineGetByMode(modes);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling LineApi.LineGetByMode: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **modes** | [**List&lt;string&gt;**](string.md)| A comma-separated list of modes e.g. tube,dlr | 

### Return type

[**List<TflApiPresentationEntitiesLine>**](TflApiPresentationEntitiesLine.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="linelineroutesbyids"></a>
# **LineLineRoutesByIds**
> List<TflApiPresentationEntitiesLine> LineLineRoutesByIds (List<string> ids, List<string> serviceTypes = null)

Get all valid routes for given line ids, including the name and id of the originating and terminating stops for each route.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class LineLineRoutesByIdsExample
    {
        public void main()
        {
            var apiInstance = new LineApi();
            var ids = new List<string>(); // List<string> | A comma-separated list of line ids e.g. victoria,circle,N133. Max. approx. 20 ids.
            var serviceTypes = serviceTypes_example;  // List<string> | A comma seperated list of service types to filter on. Supported values: Regular, Night. Defaulted to 'Regular' if not specified (optional) 

            try
            {
                // Get all valid routes for given line ids, including the name and id of the originating and terminating stops for each route.
                List&lt;TflApiPresentationEntitiesLine&gt; result = apiInstance.LineLineRoutesByIds(ids, serviceTypes);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling LineApi.LineLineRoutesByIds: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ids** | [**List&lt;string&gt;**](string.md)| A comma-separated list of line ids e.g. victoria,circle,N133. Max. approx. 20 ids. | 
 **serviceTypes** | **List&lt;string&gt;**| A comma seperated list of service types to filter on. Supported values: Regular, Night. Defaulted to &#39;Regular&#39; if not specified | [optional] 

### Return type

[**List<TflApiPresentationEntitiesLine>**](TflApiPresentationEntitiesLine.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="linemetadisruptioncategories"></a>
# **LineMetaDisruptionCategories**
> List<string> LineMetaDisruptionCategories ()

Gets a list of valid disruption categories

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class LineMetaDisruptionCategoriesExample
    {
        public void main()
        {
            var apiInstance = new LineApi();

            try
            {
                // Gets a list of valid disruption categories
                List&lt;string&gt; result = apiInstance.LineMetaDisruptionCategories();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling LineApi.LineMetaDisruptionCategories: " + e.Message );
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

<a name="linemetamodes"></a>
# **LineMetaModes**
> List<TflApiPresentationEntitiesMode> LineMetaModes ()

Gets a list of valid modes

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class LineMetaModesExample
    {
        public void main()
        {
            var apiInstance = new LineApi();

            try
            {
                // Gets a list of valid modes
                List&lt;TflApiPresentationEntitiesMode&gt; result = apiInstance.LineMetaModes();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling LineApi.LineMetaModes: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**List<TflApiPresentationEntitiesMode>**](TflApiPresentationEntitiesMode.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="linemetaservicetypes"></a>
# **LineMetaServiceTypes**
> List<string> LineMetaServiceTypes ()

Gets a list of valid ServiceTypes to filter on

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class LineMetaServiceTypesExample
    {
        public void main()
        {
            var apiInstance = new LineApi();

            try
            {
                // Gets a list of valid ServiceTypes to filter on
                List&lt;string&gt; result = apiInstance.LineMetaServiceTypes();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling LineApi.LineMetaServiceTypes: " + e.Message );
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

<a name="linemetaseverity"></a>
# **LineMetaSeverity**
> List<TflApiPresentationEntitiesStatusSeverity> LineMetaSeverity ()

Gets a list of valid severity codes

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class LineMetaSeverityExample
    {
        public void main()
        {
            var apiInstance = new LineApi();

            try
            {
                // Gets a list of valid severity codes
                List&lt;TflApiPresentationEntitiesStatusSeverity&gt; result = apiInstance.LineMetaSeverity();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling LineApi.LineMetaSeverity: " + e.Message );
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

<a name="lineroute"></a>
# **LineRoute**
> List<TflApiPresentationEntitiesLine> LineRoute (List<string> serviceTypes = null)

Get all valid routes for all lines, including the name and id of the originating and terminating stops for each route.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class LineRouteExample
    {
        public void main()
        {
            var apiInstance = new LineApi();
            var serviceTypes = serviceTypes_example;  // List<string> | A comma seperated list of service types to filter on. Supported values: Regular, Night. Defaulted to 'Regular' if not specified (optional) 

            try
            {
                // Get all valid routes for all lines, including the name and id of the originating and terminating stops for each route.
                List&lt;TflApiPresentationEntitiesLine&gt; result = apiInstance.LineRoute(serviceTypes);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling LineApi.LineRoute: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **serviceTypes** | **List&lt;string&gt;**| A comma seperated list of service types to filter on. Supported values: Regular, Night. Defaulted to &#39;Regular&#39; if not specified | [optional] 

### Return type

[**List<TflApiPresentationEntitiesLine>**](TflApiPresentationEntitiesLine.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="lineroutebymode"></a>
# **LineRouteByMode**
> List<TflApiPresentationEntitiesLine> LineRouteByMode (List<string> modes, List<string> serviceTypes = null)

Gets all lines and their valid routes for given modes, including the name and id of the originating and terminating stops for each route

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class LineRouteByModeExample
    {
        public void main()
        {
            var apiInstance = new LineApi();
            var modes = new List<string>(); // List<string> | A comma-separated list of modes e.g. tube,dlr
            var serviceTypes = serviceTypes_example;  // List<string> | A comma seperated list of service types to filter on. Supported values: Regular, Night. Defaulted to 'Regular' if not specified (optional) 

            try
            {
                // Gets all lines and their valid routes for given modes, including the name and id of the originating and terminating stops for each route
                List&lt;TflApiPresentationEntitiesLine&gt; result = apiInstance.LineRouteByMode(modes, serviceTypes);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling LineApi.LineRouteByMode: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **modes** | [**List&lt;string&gt;**](string.md)| A comma-separated list of modes e.g. tube,dlr | 
 **serviceTypes** | **List&lt;string&gt;**| A comma seperated list of service types to filter on. Supported values: Regular, Night. Defaulted to &#39;Regular&#39; if not specified | [optional] 

### Return type

[**List<TflApiPresentationEntitiesLine>**](TflApiPresentationEntitiesLine.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="lineroutesequence"></a>
# **LineRouteSequence**
> TflApiPresentationEntitiesRouteSequence LineRouteSequence (string id, string direction, List<string> serviceTypes = null, bool? excludeCrowding = null)

Gets all valid routes for given line id, including the sequence of stops on each route.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class LineRouteSequenceExample
    {
        public void main()
        {
            var apiInstance = new LineApi();
            var id = id_example;  // string | A single line id e.g. victoria
            var direction = direction_example;  // string | The direction of travel. Can be inbound or outbound.
            var serviceTypes = serviceTypes_example;  // List<string> | A comma seperated list of service types to filter on. Supported values: Regular, Night. Defaulted to 'Regular' if not specified (optional) 
            var excludeCrowding = true;  // bool? | That excludes crowding from line disruptions. Can be true or false. (optional) 

            try
            {
                // Gets all valid routes for given line id, including the sequence of stops on each route.
                TflApiPresentationEntitiesRouteSequence result = apiInstance.LineRouteSequence(id, direction, serviceTypes, excludeCrowding);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling LineApi.LineRouteSequence: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**| A single line id e.g. victoria | 
 **direction** | **string**| The direction of travel. Can be inbound or outbound. | 
 **serviceTypes** | **List&lt;string&gt;**| A comma seperated list of service types to filter on. Supported values: Regular, Night. Defaulted to &#39;Regular&#39; if not specified | [optional] 
 **excludeCrowding** | **bool?**| That excludes crowding from line disruptions. Can be true or false. | [optional] 

### Return type

[**TflApiPresentationEntitiesRouteSequence**](TflApiPresentationEntitiesRouteSequence.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="linesearch"></a>
# **LineSearch**
> TflApiPresentationEntitiesRouteSearchResponse LineSearch (string query, List<string> modes = null, List<string> serviceTypes = null)

Search for lines or routes matching the query string

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class LineSearchExample
    {
        public void main()
        {
            var apiInstance = new LineApi();
            var query = query_example;  // string | Search term e.g victoria
            var modes = new List<string>(); // List<string> | Optionally filter by the specified modes (optional) 
            var serviceTypes = serviceTypes_example;  // List<string> | A comma seperated list of service types to filter on. Supported values: Regular, Night. Defaulted to 'Regular' if not specified (optional) 

            try
            {
                // Search for lines or routes matching the query string
                TflApiPresentationEntitiesRouteSearchResponse result = apiInstance.LineSearch(query, modes, serviceTypes);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling LineApi.LineSearch: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **query** | **string**| Search term e.g victoria | 
 **modes** | [**List&lt;string&gt;**](string.md)| Optionally filter by the specified modes | [optional] 
 **serviceTypes** | **List&lt;string&gt;**| A comma seperated list of service types to filter on. Supported values: Regular, Night. Defaulted to &#39;Regular&#39; if not specified | [optional] 

### Return type

[**TflApiPresentationEntitiesRouteSearchResponse**](TflApiPresentationEntitiesRouteSearchResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="linestatus"></a>
# **LineStatus**
> List<TflApiPresentationEntitiesLine> LineStatus (List<string> ids, string startDate, string endDate, bool? detail = null, DateTime? dateRangeStartDate = null, DateTime? dateRangeEndDate = null)

Gets the line status for given line ids during the provided dates e.g Minor Delays

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class LineStatusExample
    {
        public void main()
        {
            var apiInstance = new LineApi();
            var ids = new List<string>(); // List<string> | A comma-separated list of line ids e.g. victoria,circle,N133. Max. approx. 20 ids.
            var startDate = startDate_example;  // string | 
            var endDate = endDate_example;  // string | 
            var detail = true;  // bool? | Include details of the disruptions that are causing the line status including the affected stops and routes (optional) 
            var dateRangeStartDate = 2013-10-20T19:20:30+01:00;  // DateTime? |  (optional) 
            var dateRangeEndDate = 2013-10-20T19:20:30+01:00;  // DateTime? |  (optional) 

            try
            {
                // Gets the line status for given line ids during the provided dates e.g Minor Delays
                List&lt;TflApiPresentationEntitiesLine&gt; result = apiInstance.LineStatus(ids, startDate, endDate, detail, dateRangeStartDate, dateRangeEndDate);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling LineApi.LineStatus: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ids** | [**List&lt;string&gt;**](string.md)| A comma-separated list of line ids e.g. victoria,circle,N133. Max. approx. 20 ids. | 
 **startDate** | **string**|  | 
 **endDate** | **string**|  | 
 **detail** | **bool?**| Include details of the disruptions that are causing the line status including the affected stops and routes | [optional] 
 **dateRangeStartDate** | **DateTime?**|  | [optional] 
 **dateRangeEndDate** | **DateTime?**|  | [optional] 

### Return type

[**List<TflApiPresentationEntitiesLine>**](TflApiPresentationEntitiesLine.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="linestatusbyids"></a>
# **LineStatusByIds**
> List<TflApiPresentationEntitiesLine> LineStatusByIds (List<string> ids, bool? detail = null)

Gets the line status of for given line ids e.g Minor Delays

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class LineStatusByIdsExample
    {
        public void main()
        {
            var apiInstance = new LineApi();
            var ids = new List<string>(); // List<string> | A comma-separated list of line ids e.g. victoria,circle,N133. Max. approx. 20 ids.
            var detail = true;  // bool? | Include details of the disruptions that are causing the line status including the affected stops and routes (optional) 

            try
            {
                // Gets the line status of for given line ids e.g Minor Delays
                List&lt;TflApiPresentationEntitiesLine&gt; result = apiInstance.LineStatusByIds(ids, detail);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling LineApi.LineStatusByIds: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ids** | [**List&lt;string&gt;**](string.md)| A comma-separated list of line ids e.g. victoria,circle,N133. Max. approx. 20 ids. | 
 **detail** | **bool?**| Include details of the disruptions that are causing the line status including the affected stops and routes | [optional] 

### Return type

[**List<TflApiPresentationEntitiesLine>**](TflApiPresentationEntitiesLine.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="linestatusbymode"></a>
# **LineStatusByMode**
> List<TflApiPresentationEntitiesLine> LineStatusByMode (List<string> modes, bool? detail = null, string severityLevel = null)

Gets the line status of for all lines for the given modes

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class LineStatusByModeExample
    {
        public void main()
        {
            var apiInstance = new LineApi();
            var modes = new List<string>(); // List<string> | A comma-separated list of modes to filter by. e.g. tube,dlr
            var detail = true;  // bool? | Include details of the disruptions that are causing the line status including the affected stops and routes (optional) 
            var severityLevel = severityLevel_example;  // string | If specified, ensures that only those line status(es) are returned within the lines that have disruptions with the matching severity level. (optional) 

            try
            {
                // Gets the line status of for all lines for the given modes
                List&lt;TflApiPresentationEntitiesLine&gt; result = apiInstance.LineStatusByMode(modes, detail, severityLevel);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling LineApi.LineStatusByMode: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **modes** | [**List&lt;string&gt;**](string.md)| A comma-separated list of modes to filter by. e.g. tube,dlr | 
 **detail** | **bool?**| Include details of the disruptions that are causing the line status including the affected stops and routes | [optional] 
 **severityLevel** | **string**| If specified, ensures that only those line status(es) are returned within the lines that have disruptions with the matching severity level. | [optional] 

### Return type

[**List<TflApiPresentationEntitiesLine>**](TflApiPresentationEntitiesLine.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="linestatusbyseverity"></a>
# **LineStatusBySeverity**
> List<TflApiPresentationEntitiesLine> LineStatusBySeverity (int? severity)

Gets the line status for all lines with a given severity              A list of valid severity codes can be obtained from a call to Line/Meta/Severity

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class LineStatusBySeverityExample
    {
        public void main()
        {
            var apiInstance = new LineApi();
            var severity = 56;  // int? | The level of severity (eg: a number from 0 to 14)

            try
            {
                // Gets the line status for all lines with a given severity              A list of valid severity codes can be obtained from a call to Line/Meta/Severity
                List&lt;TflApiPresentationEntitiesLine&gt; result = apiInstance.LineStatusBySeverity(severity);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling LineApi.LineStatusBySeverity: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **severity** | **int?**| The level of severity (eg: a number from 0 to 14) | 

### Return type

[**List<TflApiPresentationEntitiesLine>**](TflApiPresentationEntitiesLine.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="linestoppoints"></a>
# **LineStopPoints**
> List<TflApiPresentationEntitiesStopPoint> LineStopPoints (string id, bool? tflOperatedNationalRailStationsOnly = null)

Gets a list of the stations that serve the given line id

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class LineStopPointsExample
    {
        public void main()
        {
            var apiInstance = new LineApi();
            var id = id_example;  // string | A single line id e.g. victoria
            var tflOperatedNationalRailStationsOnly = true;  // bool? | If the national-rail line is requested, this flag will filter the national rail stations so that only those operated by TfL are returned (optional) 

            try
            {
                // Gets a list of the stations that serve the given line id
                List&lt;TflApiPresentationEntitiesStopPoint&gt; result = apiInstance.LineStopPoints(id, tflOperatedNationalRailStationsOnly);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling LineApi.LineStopPoints: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**| A single line id e.g. victoria | 
 **tflOperatedNationalRailStationsOnly** | **bool?**| If the national-rail line is requested, this flag will filter the national rail stations so that only those operated by TfL are returned | [optional] 

### Return type

[**List<TflApiPresentationEntitiesStopPoint>**](TflApiPresentationEntitiesStopPoint.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="linetimetable"></a>
# **LineTimetable**
> TflApiPresentationEntitiesTimetableResponse LineTimetable (string fromStopPointId, string id)

Gets the timetable for a specified station on the give line

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class LineTimetableExample
    {
        public void main()
        {
            var apiInstance = new LineApi();
            var fromStopPointId = fromStopPointId_example;  // string | The originating station's stop point id (station naptan code e.g. 940GZZLUASL, you can use /StopPoint/Search/{query} endpoint to find a stop point id from a station name)
            var id = id_example;  // string | A single line id e.g. victoria

            try
            {
                // Gets the timetable for a specified station on the give line
                TflApiPresentationEntitiesTimetableResponse result = apiInstance.LineTimetable(fromStopPointId, id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling LineApi.LineTimetable: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **fromStopPointId** | **string**| The originating station&#39;s stop point id (station naptan code e.g. 940GZZLUASL, you can use /StopPoint/Search/{query} endpoint to find a stop point id from a station name) | 
 **id** | **string**| A single line id e.g. victoria | 

### Return type

[**TflApiPresentationEntitiesTimetableResponse**](TflApiPresentationEntitiesTimetableResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="linetimetableto"></a>
# **LineTimetableTo**
> TflApiPresentationEntitiesTimetableResponse LineTimetableTo (string fromStopPointId, string id, string toStopPointId)

Gets the timetable for a specified station on the give line with specified destination

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class LineTimetableToExample
    {
        public void main()
        {
            var apiInstance = new LineApi();
            var fromStopPointId = fromStopPointId_example;  // string | The originating station's stop point id (station naptan code e.g. 940GZZLUASL, you can use /StopPoint/Search/{query} endpoint to find a stop point id from a station name)
            var id = id_example;  // string | A single line id e.g. victoria
            var toStopPointId = toStopPointId_example;  // string | The destination stations's Naptan code

            try
            {
                // Gets the timetable for a specified station on the give line with specified destination
                TflApiPresentationEntitiesTimetableResponse result = apiInstance.LineTimetableTo(fromStopPointId, id, toStopPointId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling LineApi.LineTimetableTo: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **fromStopPointId** | **string**| The originating station&#39;s stop point id (station naptan code e.g. 940GZZLUASL, you can use /StopPoint/Search/{query} endpoint to find a stop point id from a station name) | 
 **id** | **string**| A single line id e.g. victoria | 
 **toStopPointId** | **string**| The destination stations&#39;s Naptan code | 

### Return type

[**TflApiPresentationEntitiesTimetableResponse**](TflApiPresentationEntitiesTimetableResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

