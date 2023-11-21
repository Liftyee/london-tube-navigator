# IO.Swagger.Api.StopPointApi

All URIs are relative to *https://api.digital.tfl.gov.uk*

Method | HTTP request | Description
------------- | ------------- | -------------
[**StopPointArrivalDepartures**](StopPointApi.md#stoppointarrivaldepartures) | **GET** /StopPoint/{id}/ArrivalDepartures | Gets the list of arrival and departure predictions for the given stop point id (overground, Elizabeth line and thameslink only)
[**StopPointArrivals**](StopPointApi.md#stoppointarrivals) | **GET** /StopPoint/{id}/Arrivals | Gets the list of arrival predictions for the given stop point id
[**StopPointCrowding**](StopPointApi.md#stoppointcrowding) | **GET** /StopPoint/{id}/Crowding/{line} | Gets all the Crowding data (static) for the StopPointId, plus crowding data for a given line and optionally a particular direction.
[**StopPointDirection**](StopPointApi.md#stoppointdirection) | **GET** /StopPoint/{id}/DirectionTo/{toStopPointId} | Returns the canonical direction, \&quot;inbound\&quot; or \&quot;outbound\&quot;, for a given pair of stop point Ids in the direction from -&amp;gt; to.
[**StopPointDisruption**](StopPointApi.md#stoppointdisruption) | **GET** /StopPoint/{ids}/Disruption | Gets all disruptions for the specified StopPointId, plus disruptions for any child Naptan records it may have.
[**StopPointDisruptionByMode**](StopPointApi.md#stoppointdisruptionbymode) | **GET** /StopPoint/Mode/{modes}/Disruption | Gets a distinct list of disrupted stop points for the given modes
[**StopPointGet**](StopPointApi.md#stoppointget) | **GET** /StopPoint/{id}/placeTypes | Get a list of places corresponding to a given id and place types.
[**StopPointGetByGeoPoint**](StopPointApi.md#stoppointgetbygeopoint) | **GET** /StopPoint | Gets a list of StopPoints within {radius} by the specified criteria
[**StopPointGetByMode**](StopPointApi.md#stoppointgetbymode) | **GET** /StopPoint/Mode/{modes} | Gets a list of StopPoints filtered by the modes available at that StopPoint.
[**StopPointGetBySms**](StopPointApi.md#stoppointgetbysms) | **GET** /StopPoint/Sms/{id} | Gets a StopPoint for a given sms code.
[**StopPointGetByType**](StopPointApi.md#stoppointgetbytype) | **GET** /StopPoint/Type/{types} | Gets all stop points of a given type
[**StopPointGetByTypeWithPagination**](StopPointApi.md#stoppointgetbytypewithpagination) | **GET** /StopPoint/Type/{types}/page/{page} | Gets all the stop points of given type(s) with a page number
[**StopPointGetCarParksById**](StopPointApi.md#stoppointgetcarparksbyid) | **GET** /StopPoint/{stopPointId}/CarParks | Get car parks corresponding to the given stop point id.
[**StopPointGetId**](StopPointApi.md#stoppointgetid) | **GET** /StopPoint/{ids} | Gets a list of StopPoints corresponding to the given list of stop ids.
[**StopPointGetServiceTypes**](StopPointApi.md#stoppointgetservicetypes) | **GET** /StopPoint/ServiceTypes | Gets the service types for a given stoppoint
[**StopPointGetTaxiRanksByIds**](StopPointApi.md#stoppointgettaxiranksbyids) | **GET** /StopPoint/{stopPointId}/TaxiRanks | Gets a list of taxi ranks corresponding to the given stop point id.
[**StopPointMetaCategories**](StopPointApi.md#stoppointmetacategories) | **GET** /StopPoint/Meta/Categories | Gets the list of available StopPoint additional information categories
[**StopPointMetaModes**](StopPointApi.md#stoppointmetamodes) | **GET** /StopPoint/Meta/Modes | Gets the list of available StopPoint modes
[**StopPointMetaStopTypes**](StopPointApi.md#stoppointmetastoptypes) | **GET** /StopPoint/Meta/StopTypes | Gets the list of available StopPoint types
[**StopPointReachableFrom**](StopPointApi.md#stoppointreachablefrom) | **GET** /StopPoint/{id}/CanReachOnLine/{lineId} | Gets Stopoints that are reachable from a station/line combination.
[**StopPointRoute**](StopPointApi.md#stoppointroute) | **GET** /StopPoint/{id}/Route | Returns the route sections for all the lines that service the given stop point ids
[**StopPointSearch**](StopPointApi.md#stoppointsearch) | **GET** /StopPoint/Search/{query} | Search StopPoints by their common name, or their 5-digit Countdown Bus Stop Code.
[**StopPointSearch_0**](StopPointApi.md#stoppointsearch_0) | **GET** /StopPoint/Search | Search StopPoints by their common name, or their 5-digit Countdown Bus Stop Code.


<a name="stoppointarrivaldepartures"></a>
# **StopPointArrivalDepartures**
> List<TflApiPresentationEntitiesArrivalDeparture> StopPointArrivalDepartures (string id, List<string> lineIds)

Gets the list of arrival and departure predictions for the given stop point id (overground, Elizabeth line and thameslink only)

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class StopPointArrivalDeparturesExample
    {
        public void main()
        {
            var apiInstance = new StopPointApi();
            var id = id_example;  // string | A StopPoint id (station naptan code e.g. 940GZZLUASL, you can use /StopPoint/Search/{query} endpoint to find a stop point id from a station name)
            var lineIds = new List<string>(); // List<string> | A comma-separated list of line ids e.g. elizabeth, london-overground, thameslink

            try
            {
                // Gets the list of arrival and departure predictions for the given stop point id (overground, Elizabeth line and thameslink only)
                List&lt;TflApiPresentationEntitiesArrivalDeparture&gt; result = apiInstance.StopPointArrivalDepartures(id, lineIds);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling StopPointApi.StopPointArrivalDepartures: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**| A StopPoint id (station naptan code e.g. 940GZZLUASL, you can use /StopPoint/Search/{query} endpoint to find a stop point id from a station name) | 
 **lineIds** | [**List&lt;string&gt;**](string.md)| A comma-separated list of line ids e.g. elizabeth, london-overground, thameslink | 

### Return type

[**List<TflApiPresentationEntitiesArrivalDeparture>**](TflApiPresentationEntitiesArrivalDeparture.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="stoppointarrivals"></a>
# **StopPointArrivals**
> List<TflApiPresentationEntitiesPrediction> StopPointArrivals (string id)

Gets the list of arrival predictions for the given stop point id

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class StopPointArrivalsExample
    {
        public void main()
        {
            var apiInstance = new StopPointApi();
            var id = id_example;  // string | A StopPoint id (station naptan code e.g. 940GZZLUASL, you can use /StopPoint/Search/{query} endpoint to find a stop point id from a station name)

            try
            {
                // Gets the list of arrival predictions for the given stop point id
                List&lt;TflApiPresentationEntitiesPrediction&gt; result = apiInstance.StopPointArrivals(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling StopPointApi.StopPointArrivals: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**| A StopPoint id (station naptan code e.g. 940GZZLUASL, you can use /StopPoint/Search/{query} endpoint to find a stop point id from a station name) | 

### Return type

[**List<TflApiPresentationEntitiesPrediction>**](TflApiPresentationEntitiesPrediction.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="stoppointcrowding"></a>
# **StopPointCrowding**
> List<TflApiPresentationEntitiesStopPoint> StopPointCrowding (string id, string line, string direction)

Gets all the Crowding data (static) for the StopPointId, plus crowding data for a given line and optionally a particular direction.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class StopPointCrowdingExample
    {
        public void main()
        {
            var apiInstance = new StopPointApi();
            var id = id_example;  // string | The Naptan id of the stop
            var line = line_example;  // string | A particular line e.g. victoria, circle, northern etc.
            var direction = direction_example;  // string | The direction of travel. Can be inbound or outbound.

            try
            {
                // Gets all the Crowding data (static) for the StopPointId, plus crowding data for a given line and optionally a particular direction.
                List&lt;TflApiPresentationEntitiesStopPoint&gt; result = apiInstance.StopPointCrowding(id, line, direction);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling StopPointApi.StopPointCrowding: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**| The Naptan id of the stop | 
 **line** | **string**| A particular line e.g. victoria, circle, northern etc. | 
 **direction** | **string**| The direction of travel. Can be inbound or outbound. | 

### Return type

[**List<TflApiPresentationEntitiesStopPoint>**](TflApiPresentationEntitiesStopPoint.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="stoppointdirection"></a>
# **StopPointDirection**
> string StopPointDirection (string id, string toStopPointId, string lineId = null)

Returns the canonical direction, \"inbound\" or \"outbound\", for a given pair of stop point Ids in the direction from -&gt; to.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class StopPointDirectionExample
    {
        public void main()
        {
            var apiInstance = new StopPointApi();
            var id = id_example;  // string | Originating stop id (station naptan code e.g. 940GZZLUASL, you can use /StopPoint/Search/{query} endpoint to find a stop point id from a station name)
            var toStopPointId = toStopPointId_example;  // string | Destination stop id (station naptan code e.g. 940GZZLUASL, you can use /StopPoint/Search/{query} endpoint to find a stop point id from a station name)
            var lineId = lineId_example;  // string | Optional line id filter e.g. victoria (optional) 

            try
            {
                // Returns the canonical direction, \"inbound\" or \"outbound\", for a given pair of stop point Ids in the direction from -&gt; to.
                string result = apiInstance.StopPointDirection(id, toStopPointId, lineId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling StopPointApi.StopPointDirection: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**| Originating stop id (station naptan code e.g. 940GZZLUASL, you can use /StopPoint/Search/{query} endpoint to find a stop point id from a station name) | 
 **toStopPointId** | **string**| Destination stop id (station naptan code e.g. 940GZZLUASL, you can use /StopPoint/Search/{query} endpoint to find a stop point id from a station name) | 
 **lineId** | **string**| Optional line id filter e.g. victoria | [optional] 

### Return type

**string**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="stoppointdisruption"></a>
# **StopPointDisruption**
> List<TflApiPresentationEntitiesDisruptedPoint> StopPointDisruption (List<string> ids, bool? getFamily = null, bool? includeRouteBlockedStops = null, bool? flattenResponse = null)

Gets all disruptions for the specified StopPointId, plus disruptions for any child Naptan records it may have.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class StopPointDisruptionExample
    {
        public void main()
        {
            var apiInstance = new StopPointApi();
            var ids = new List<string>(); // List<string> | A comma-seperated list of stop point ids. Max. approx. 20 ids.              You can use /StopPoint/Search/{query} endpoint to find a stop point id from a station name.
            var getFamily = true;  // bool? | Specify true to return disruptions for entire family, or false to return disruptions for just this stop point. Defaults to false. (optional) 
            var includeRouteBlockedStops = true;  // bool? |  (optional) 
            var flattenResponse = true;  // bool? | Specify true to associate all disruptions with parent stop point. (Only applicable when getFamily is true). (optional) 

            try
            {
                // Gets all disruptions for the specified StopPointId, plus disruptions for any child Naptan records it may have.
                List&lt;TflApiPresentationEntitiesDisruptedPoint&gt; result = apiInstance.StopPointDisruption(ids, getFamily, includeRouteBlockedStops, flattenResponse);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling StopPointApi.StopPointDisruption: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ids** | [**List&lt;string&gt;**](string.md)| A comma-seperated list of stop point ids. Max. approx. 20 ids.              You can use /StopPoint/Search/{query} endpoint to find a stop point id from a station name. | 
 **getFamily** | **bool?**| Specify true to return disruptions for entire family, or false to return disruptions for just this stop point. Defaults to false. | [optional] 
 **includeRouteBlockedStops** | **bool?**|  | [optional] 
 **flattenResponse** | **bool?**| Specify true to associate all disruptions with parent stop point. (Only applicable when getFamily is true). | [optional] 

### Return type

[**List<TflApiPresentationEntitiesDisruptedPoint>**](TflApiPresentationEntitiesDisruptedPoint.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="stoppointdisruptionbymode"></a>
# **StopPointDisruptionByMode**
> List<TflApiPresentationEntitiesDisruptedPoint> StopPointDisruptionByMode (List<string> modes, bool? includeRouteBlockedStops = null)

Gets a distinct list of disrupted stop points for the given modes

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class StopPointDisruptionByModeExample
    {
        public void main()
        {
            var apiInstance = new StopPointApi();
            var modes = new List<string>(); // List<string> | A comma-seperated list of modes e.g. tube,dlr
            var includeRouteBlockedStops = true;  // bool? |  (optional) 

            try
            {
                // Gets a distinct list of disrupted stop points for the given modes
                List&lt;TflApiPresentationEntitiesDisruptedPoint&gt; result = apiInstance.StopPointDisruptionByMode(modes, includeRouteBlockedStops);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling StopPointApi.StopPointDisruptionByMode: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **modes** | [**List&lt;string&gt;**](string.md)| A comma-seperated list of modes e.g. tube,dlr | 
 **includeRouteBlockedStops** | **bool?**|  | [optional] 

### Return type

[**List<TflApiPresentationEntitiesDisruptedPoint>**](TflApiPresentationEntitiesDisruptedPoint.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="stoppointget"></a>
# **StopPointGet**
> List<TflApiPresentationEntitiesPlace> StopPointGet (string id, List<string> placeTypes)

Get a list of places corresponding to a given id and place types.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class StopPointGetExample
    {
        public void main()
        {
            var apiInstance = new StopPointApi();
            var id = id_example;  // string | A naptan id for a stop point (station naptan code e.g. 940GZZLUASL).
            var placeTypes = new List<string>(); // List<string> | A comcomma-separated value representing the place types.

            try
            {
                // Get a list of places corresponding to a given id and place types.
                List&lt;TflApiPresentationEntitiesPlace&gt; result = apiInstance.StopPointGet(id, placeTypes);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling StopPointApi.StopPointGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**| A naptan id for a stop point (station naptan code e.g. 940GZZLUASL). | 
 **placeTypes** | [**List&lt;string&gt;**](string.md)| A comcomma-separated value representing the place types. | 

### Return type

[**List<TflApiPresentationEntitiesPlace>**](TflApiPresentationEntitiesPlace.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="stoppointgetbygeopoint"></a>
# **StopPointGetByGeoPoint**
> TflApiPresentationEntitiesStopPointsResponse StopPointGetByGeoPoint (List<string> stopTypes, double? locationLat, double? locationLon, int? radius = null, bool? useStopPointHierarchy = null, List<string> modes = null, List<string> categories = null, bool? returnLines = null)

Gets a list of StopPoints within {radius} by the specified criteria

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class StopPointGetByGeoPointExample
    {
        public void main()
        {
            var apiInstance = new StopPointApi();
            var stopTypes = new List<string>(); // List<string> | a list of stopTypes that should be returned (a list of valid stop types can be obtained from the StopPoint/meta/stoptypes endpoint)
            var locationLat = 1.2;  // double? | 
            var locationLon = 1.2;  // double? | 
            var radius = 56;  // int? | the radius of the bounding circle in metres (default : 200) (optional) 
            var useStopPointHierarchy = true;  // bool? | Re-arrange the output into a parent/child hierarchy (optional) 
            var modes = new List<string>(); // List<string> | the list of modes to search (comma separated mode names e.g. tube,dlr) (optional) 
            var categories = new List<string>(); // List<string> | an optional list of comma separated property categories to return in the StopPoint's property bag. If null or empty, all categories of property are returned. Pass the keyword \"none\" to return no properties (a valid list of categories can be obtained from the /StopPoint/Meta/categories endpoint) (optional) 
            var returnLines = true;  // bool? | true to return the lines that each stop point serves as a nested resource (optional) 

            try
            {
                // Gets a list of StopPoints within {radius} by the specified criteria
                TflApiPresentationEntitiesStopPointsResponse result = apiInstance.StopPointGetByGeoPoint(stopTypes, locationLat, locationLon, radius, useStopPointHierarchy, modes, categories, returnLines);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling StopPointApi.StopPointGetByGeoPoint: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **stopTypes** | [**List&lt;string&gt;**](string.md)| a list of stopTypes that should be returned (a list of valid stop types can be obtained from the StopPoint/meta/stoptypes endpoint) | 
 **locationLat** | **double?**|  | 
 **locationLon** | **double?**|  | 
 **radius** | **int?**| the radius of the bounding circle in metres (default : 200) | [optional] 
 **useStopPointHierarchy** | **bool?**| Re-arrange the output into a parent/child hierarchy | [optional] 
 **modes** | [**List&lt;string&gt;**](string.md)| the list of modes to search (comma separated mode names e.g. tube,dlr) | [optional] 
 **categories** | [**List&lt;string&gt;**](string.md)| an optional list of comma separated property categories to return in the StopPoint&#39;s property bag. If null or empty, all categories of property are returned. Pass the keyword \&quot;none\&quot; to return no properties (a valid list of categories can be obtained from the /StopPoint/Meta/categories endpoint) | [optional] 
 **returnLines** | **bool?**| true to return the lines that each stop point serves as a nested resource | [optional] 

### Return type

[**TflApiPresentationEntitiesStopPointsResponse**](TflApiPresentationEntitiesStopPointsResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="stoppointgetbymode"></a>
# **StopPointGetByMode**
> TflApiPresentationEntitiesStopPointsResponse StopPointGetByMode (List<string> modes, int? page = null)

Gets a list of StopPoints filtered by the modes available at that StopPoint.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class StopPointGetByModeExample
    {
        public void main()
        {
            var apiInstance = new StopPointApi();
            var modes = new List<string>(); // List<string> | A comma-seperated list of modes e.g. tube,dlr
            var page = 56;  // int? | The data set page to return. Page 1 equates to the first 1000 stop points, page 2 equates to 1001-2000 etc. Must be entered for bus mode as data set is too large. (optional) 

            try
            {
                // Gets a list of StopPoints filtered by the modes available at that StopPoint.
                TflApiPresentationEntitiesStopPointsResponse result = apiInstance.StopPointGetByMode(modes, page);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling StopPointApi.StopPointGetByMode: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **modes** | [**List&lt;string&gt;**](string.md)| A comma-seperated list of modes e.g. tube,dlr | 
 **page** | **int?**| The data set page to return. Page 1 equates to the first 1000 stop points, page 2 equates to 1001-2000 etc. Must be entered for bus mode as data set is too large. | [optional] 

### Return type

[**TflApiPresentationEntitiesStopPointsResponse**](TflApiPresentationEntitiesStopPointsResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="stoppointgetbysms"></a>
# **StopPointGetBySms**
> SystemObject StopPointGetBySms (string id, string output = null)

Gets a StopPoint for a given sms code.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class StopPointGetBySmsExample
    {
        public void main()
        {
            var apiInstance = new StopPointApi();
            var id = id_example;  // string | A 5-digit Countdown Bus Stop Code e.g. 73241, 50435, 56334.
            var output = output_example;  // string | If set to \"web\", a 302 redirect to relevant website bus stop page is returned. Valid values are : web. All other values are ignored. (optional) 

            try
            {
                // Gets a StopPoint for a given sms code.
                SystemObject result = apiInstance.StopPointGetBySms(id, output);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling StopPointApi.StopPointGetBySms: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**| A 5-digit Countdown Bus Stop Code e.g. 73241, 50435, 56334. | 
 **output** | **string**| If set to \&quot;web\&quot;, a 302 redirect to relevant website bus stop page is returned. Valid values are : web. All other values are ignored. | [optional] 

### Return type

[**SystemObject**](SystemObject.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="stoppointgetbytype"></a>
# **StopPointGetByType**
> List<TflApiPresentationEntitiesStopPoint> StopPointGetByType (List<string> types)

Gets all stop points of a given type

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class StopPointGetByTypeExample
    {
        public void main()
        {
            var apiInstance = new StopPointApi();
            var types = new List<string>(); // List<string> | A comma-separated list of the types to return. Max. approx. 12 types.               A list of valid stop types can be obtained from the StopPoint/meta/stoptypes endpoint.

            try
            {
                // Gets all stop points of a given type
                List&lt;TflApiPresentationEntitiesStopPoint&gt; result = apiInstance.StopPointGetByType(types);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling StopPointApi.StopPointGetByType: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **types** | [**List&lt;string&gt;**](string.md)| A comma-separated list of the types to return. Max. approx. 12 types.               A list of valid stop types can be obtained from the StopPoint/meta/stoptypes endpoint. | 

### Return type

[**List<TflApiPresentationEntitiesStopPoint>**](TflApiPresentationEntitiesStopPoint.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="stoppointgetbytypewithpagination"></a>
# **StopPointGetByTypeWithPagination**
> List<TflApiPresentationEntitiesStopPoint> StopPointGetByTypeWithPagination (List<string> types, int? page)

Gets all the stop points of given type(s) with a page number

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class StopPointGetByTypeWithPaginationExample
    {
        public void main()
        {
            var apiInstance = new StopPointApi();
            var types = new List<string>(); // List<string> | 
            var page = 56;  // int? | 

            try
            {
                // Gets all the stop points of given type(s) with a page number
                List&lt;TflApiPresentationEntitiesStopPoint&gt; result = apiInstance.StopPointGetByTypeWithPagination(types, page);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling StopPointApi.StopPointGetByTypeWithPagination: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **types** | [**List&lt;string&gt;**](string.md)|  | 
 **page** | **int?**|  | 

### Return type

[**List<TflApiPresentationEntitiesStopPoint>**](TflApiPresentationEntitiesStopPoint.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="stoppointgetcarparksbyid"></a>
# **StopPointGetCarParksById**
> List<TflApiPresentationEntitiesPlace> StopPointGetCarParksById (string stopPointId)

Get car parks corresponding to the given stop point id.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class StopPointGetCarParksByIdExample
    {
        public void main()
        {
            var apiInstance = new StopPointApi();
            var stopPointId = stopPointId_example;  // string | stopPointId is required to get the car parks.

            try
            {
                // Get car parks corresponding to the given stop point id.
                List&lt;TflApiPresentationEntitiesPlace&gt; result = apiInstance.StopPointGetCarParksById(stopPointId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling StopPointApi.StopPointGetCarParksById: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **stopPointId** | **string**| stopPointId is required to get the car parks. | 

### Return type

[**List<TflApiPresentationEntitiesPlace>**](TflApiPresentationEntitiesPlace.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="stoppointgetid"></a>
# **StopPointGetId**
> List<TflApiPresentationEntitiesStopPoint> StopPointGetId (List<string> ids, bool? includeCrowdingData = null)

Gets a list of StopPoints corresponding to the given list of stop ids.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class StopPointGetIdExample
    {
        public void main()
        {
            var apiInstance = new StopPointApi();
            var ids = new List<string>(); // List<string> | A comma-separated list of stop point ids (station naptan code e.g. 940GZZLUASL). Max. approx. 20 ids.              You can use /StopPoint/Search/{query} endpoint to find a stop point id from a station name.
            var includeCrowdingData = true;  // bool? | Include the crowding data (static). To Filter further use: /StopPoint/{ids}/Crowding/{line} (optional) 

            try
            {
                // Gets a list of StopPoints corresponding to the given list of stop ids.
                List&lt;TflApiPresentationEntitiesStopPoint&gt; result = apiInstance.StopPointGetId(ids, includeCrowdingData);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling StopPointApi.StopPointGetId: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ids** | [**List&lt;string&gt;**](string.md)| A comma-separated list of stop point ids (station naptan code e.g. 940GZZLUASL). Max. approx. 20 ids.              You can use /StopPoint/Search/{query} endpoint to find a stop point id from a station name. | 
 **includeCrowdingData** | **bool?**| Include the crowding data (static). To Filter further use: /StopPoint/{ids}/Crowding/{line} | [optional] 

### Return type

[**List<TflApiPresentationEntitiesStopPoint>**](TflApiPresentationEntitiesStopPoint.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="stoppointgetservicetypes"></a>
# **StopPointGetServiceTypes**
> List<TflApiPresentationEntitiesLineServiceType> StopPointGetServiceTypes (string id, List<string> lineIds = null, List<string> modes = null)

Gets the service types for a given stoppoint

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class StopPointGetServiceTypesExample
    {
        public void main()
        {
            var apiInstance = new StopPointApi();
            var id = id_example;  // string | The Naptan id of the stop
            var lineIds = new List<string>(); // List<string> | The lines which contain the given Naptan id (all lines relevant to the given stoppoint if empty) (optional) 
            var modes = new List<string>(); // List<string> | The modes which the lines are relevant to (all if empty) (optional) 

            try
            {
                // Gets the service types for a given stoppoint
                List&lt;TflApiPresentationEntitiesLineServiceType&gt; result = apiInstance.StopPointGetServiceTypes(id, lineIds, modes);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling StopPointApi.StopPointGetServiceTypes: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**| The Naptan id of the stop | 
 **lineIds** | [**List&lt;string&gt;**](string.md)| The lines which contain the given Naptan id (all lines relevant to the given stoppoint if empty) | [optional] 
 **modes** | [**List&lt;string&gt;**](string.md)| The modes which the lines are relevant to (all if empty) | [optional] 

### Return type

[**List<TflApiPresentationEntitiesLineServiceType>**](TflApiPresentationEntitiesLineServiceType.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="stoppointgettaxiranksbyids"></a>
# **StopPointGetTaxiRanksByIds**
> List<TflApiPresentationEntitiesPlace> StopPointGetTaxiRanksByIds (string stopPointId)

Gets a list of taxi ranks corresponding to the given stop point id.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class StopPointGetTaxiRanksByIdsExample
    {
        public void main()
        {
            var apiInstance = new StopPointApi();
            var stopPointId = stopPointId_example;  // string | stopPointId is required to get the taxi ranks.

            try
            {
                // Gets a list of taxi ranks corresponding to the given stop point id.
                List&lt;TflApiPresentationEntitiesPlace&gt; result = apiInstance.StopPointGetTaxiRanksByIds(stopPointId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling StopPointApi.StopPointGetTaxiRanksByIds: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **stopPointId** | **string**| stopPointId is required to get the taxi ranks. | 

### Return type

[**List<TflApiPresentationEntitiesPlace>**](TflApiPresentationEntitiesPlace.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="stoppointmetacategories"></a>
# **StopPointMetaCategories**
> List<TflApiPresentationEntitiesStopPointCategory> StopPointMetaCategories ()

Gets the list of available StopPoint additional information categories

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class StopPointMetaCategoriesExample
    {
        public void main()
        {
            var apiInstance = new StopPointApi();

            try
            {
                // Gets the list of available StopPoint additional information categories
                List&lt;TflApiPresentationEntitiesStopPointCategory&gt; result = apiInstance.StopPointMetaCategories();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling StopPointApi.StopPointMetaCategories: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**List<TflApiPresentationEntitiesStopPointCategory>**](TflApiPresentationEntitiesStopPointCategory.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="stoppointmetamodes"></a>
# **StopPointMetaModes**
> List<TflApiPresentationEntitiesMode> StopPointMetaModes ()

Gets the list of available StopPoint modes

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class StopPointMetaModesExample
    {
        public void main()
        {
            var apiInstance = new StopPointApi();

            try
            {
                // Gets the list of available StopPoint modes
                List&lt;TflApiPresentationEntitiesMode&gt; result = apiInstance.StopPointMetaModes();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling StopPointApi.StopPointMetaModes: " + e.Message );
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

<a name="stoppointmetastoptypes"></a>
# **StopPointMetaStopTypes**
> List<string> StopPointMetaStopTypes ()

Gets the list of available StopPoint types

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class StopPointMetaStopTypesExample
    {
        public void main()
        {
            var apiInstance = new StopPointApi();

            try
            {
                // Gets the list of available StopPoint types
                List&lt;string&gt; result = apiInstance.StopPointMetaStopTypes();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling StopPointApi.StopPointMetaStopTypes: " + e.Message );
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

<a name="stoppointreachablefrom"></a>
# **StopPointReachableFrom**
> List<TflApiPresentationEntitiesStopPoint> StopPointReachableFrom (string id, string lineId, List<string> serviceTypes = null)

Gets Stopoints that are reachable from a station/line combination.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class StopPointReachableFromExample
    {
        public void main()
        {
            var apiInstance = new StopPointApi();
            var id = id_example;  // string | The id (station naptan code e.g. 940GZZLUASL, you can use /StopPoint/Search/{query} endpoint to find a stop point id from a station name) of the stop point to filter by
            var lineId = lineId_example;  // string | Line id of the line to filter by (e.g. victoria)
            var serviceTypes = serviceTypes_example;  // List<string> | A comma-separated list of service types to filter on. If not specified. Supported values: Regular, Night. Defaulted to 'Regular' if not specified (optional) 

            try
            {
                // Gets Stopoints that are reachable from a station/line combination.
                List&lt;TflApiPresentationEntitiesStopPoint&gt; result = apiInstance.StopPointReachableFrom(id, lineId, serviceTypes);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling StopPointApi.StopPointReachableFrom: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**| The id (station naptan code e.g. 940GZZLUASL, you can use /StopPoint/Search/{query} endpoint to find a stop point id from a station name) of the stop point to filter by | 
 **lineId** | **string**| Line id of the line to filter by (e.g. victoria) | 
 **serviceTypes** | **List&lt;string&gt;**| A comma-separated list of service types to filter on. If not specified. Supported values: Regular, Night. Defaulted to &#39;Regular&#39; if not specified | [optional] 

### Return type

[**List<TflApiPresentationEntitiesStopPoint>**](TflApiPresentationEntitiesStopPoint.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="stoppointroute"></a>
# **StopPointRoute**
> List<TflApiPresentationEntitiesStopPointRouteSection> StopPointRoute (string id, List<string> serviceTypes = null)

Returns the route sections for all the lines that service the given stop point ids

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class StopPointRouteExample
    {
        public void main()
        {
            var apiInstance = new StopPointApi();
            var id = id_example;  // string | A stop point id (station naptan codes e.g. 940GZZLUASL, you can use /StopPoint/Search/{query} endpoint to find a stop point id from a station name)
            var serviceTypes = serviceTypes_example;  // List<string> | A comma-separated list of service types to filter on. If not specified. Supported values: Regular, Night. Defaulted to 'Regular' if not specified (optional) 

            try
            {
                // Returns the route sections for all the lines that service the given stop point ids
                List&lt;TflApiPresentationEntitiesStopPointRouteSection&gt; result = apiInstance.StopPointRoute(id, serviceTypes);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling StopPointApi.StopPointRoute: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**| A stop point id (station naptan codes e.g. 940GZZLUASL, you can use /StopPoint/Search/{query} endpoint to find a stop point id from a station name) | 
 **serviceTypes** | **List&lt;string&gt;**| A comma-separated list of service types to filter on. If not specified. Supported values: Regular, Night. Defaulted to &#39;Regular&#39; if not specified | [optional] 

### Return type

[**List<TflApiPresentationEntitiesStopPointRouteSection>**](TflApiPresentationEntitiesStopPointRouteSection.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="stoppointsearch"></a>
# **StopPointSearch**
> TflApiPresentationEntitiesSearchResponse StopPointSearch (string query, List<string> modes = null, bool? faresOnly = null, int? maxResults = null, List<string> lines = null, bool? includeHubs = null, bool? tflOperatedNationalRailStationsOnly = null)

Search StopPoints by their common name, or their 5-digit Countdown Bus Stop Code.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class StopPointSearchExample
    {
        public void main()
        {
            var apiInstance = new StopPointApi();
            var query = query_example;  // string | The query string, case-insensitive. Leading and trailing wildcards are applied automatically.
            var modes = new List<string>(); // List<string> | An optional, parameter separated list of the modes to filter by (optional) 
            var faresOnly = true;  // bool? | True to only return stations in that have Fares data available for single fares to another station. (optional) 
            var maxResults = 56;  // int? | An optional result limit, defaulting to and with a maximum of 50. Since children of the stop point heirarchy are returned for matches,              it is possible that the flattened result set will contain more than 50 items. (optional) 
            var lines = new List<string>(); // List<string> | An optional, parameter separated list of the lines to filter by (optional) 
            var includeHubs = true;  // bool? | If true, returns results including HUBs. (optional) 
            var tflOperatedNationalRailStationsOnly = true;  // bool? | If the national-rail mode is included, this flag will filter the national rail stations so that only those operated by TfL are returned (optional) 

            try
            {
                // Search StopPoints by their common name, or their 5-digit Countdown Bus Stop Code.
                TflApiPresentationEntitiesSearchResponse result = apiInstance.StopPointSearch(query, modes, faresOnly, maxResults, lines, includeHubs, tflOperatedNationalRailStationsOnly);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling StopPointApi.StopPointSearch: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **query** | **string**| The query string, case-insensitive. Leading and trailing wildcards are applied automatically. | 
 **modes** | [**List&lt;string&gt;**](string.md)| An optional, parameter separated list of the modes to filter by | [optional] 
 **faresOnly** | **bool?**| True to only return stations in that have Fares data available for single fares to another station. | [optional] 
 **maxResults** | **int?**| An optional result limit, defaulting to and with a maximum of 50. Since children of the stop point heirarchy are returned for matches,              it is possible that the flattened result set will contain more than 50 items. | [optional] 
 **lines** | [**List&lt;string&gt;**](string.md)| An optional, parameter separated list of the lines to filter by | [optional] 
 **includeHubs** | **bool?**| If true, returns results including HUBs. | [optional] 
 **tflOperatedNationalRailStationsOnly** | **bool?**| If the national-rail mode is included, this flag will filter the national rail stations so that only those operated by TfL are returned | [optional] 

### Return type

[**TflApiPresentationEntitiesSearchResponse**](TflApiPresentationEntitiesSearchResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="stoppointsearch_0"></a>
# **StopPointSearch_0**
> TflApiPresentationEntitiesSearchResponse StopPointSearch_0 (string query, List<string> modes = null, bool? faresOnly = null, int? maxResults = null, List<string> lines = null, bool? includeHubs = null, bool? tflOperatedNationalRailStationsOnly = null)

Search StopPoints by their common name, or their 5-digit Countdown Bus Stop Code.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class StopPointSearch_0Example
    {
        public void main()
        {
            var apiInstance = new StopPointApi();
            var query = query_example;  // string | The query string, case-insensitive. Leading and trailing wildcards are applied automatically.
            var modes = new List<string>(); // List<string> | An optional, parameter separated list of the modes to filter by (optional) 
            var faresOnly = true;  // bool? | True to only return stations in that have Fares data available for single fares to another station. (optional) 
            var maxResults = 56;  // int? | An optional result limit, defaulting to and with a maximum of 50. Since children of the stop point heirarchy are returned for matches,              it is possible that the flattened result set will contain more than 50 items. (optional) 
            var lines = new List<string>(); // List<string> | An optional, parameter separated list of the lines to filter by (optional) 
            var includeHubs = true;  // bool? | If true, returns results including HUBs. (optional) 
            var tflOperatedNationalRailStationsOnly = true;  // bool? | If the national-rail mode is included, this flag will filter the national rail stations so that only those operated by TfL are returned (optional) 

            try
            {
                // Search StopPoints by their common name, or their 5-digit Countdown Bus Stop Code.
                TflApiPresentationEntitiesSearchResponse result = apiInstance.StopPointSearch_0(query, modes, faresOnly, maxResults, lines, includeHubs, tflOperatedNationalRailStationsOnly);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling StopPointApi.StopPointSearch_0: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **query** | **string**| The query string, case-insensitive. Leading and trailing wildcards are applied automatically. | 
 **modes** | [**List&lt;string&gt;**](string.md)| An optional, parameter separated list of the modes to filter by | [optional] 
 **faresOnly** | **bool?**| True to only return stations in that have Fares data available for single fares to another station. | [optional] 
 **maxResults** | **int?**| An optional result limit, defaulting to and with a maximum of 50. Since children of the stop point heirarchy are returned for matches,              it is possible that the flattened result set will contain more than 50 items. | [optional] 
 **lines** | [**List&lt;string&gt;**](string.md)| An optional, parameter separated list of the lines to filter by | [optional] 
 **includeHubs** | **bool?**| If true, returns results including HUBs. | [optional] 
 **tflOperatedNationalRailStationsOnly** | **bool?**| If the national-rail mode is included, this flag will filter the national rail stations so that only those operated by TfL are returned | [optional] 

### Return type

[**TflApiPresentationEntitiesSearchResponse**](TflApiPresentationEntitiesSearchResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

