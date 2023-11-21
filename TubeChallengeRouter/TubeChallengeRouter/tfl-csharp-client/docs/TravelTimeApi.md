# IO.Swagger.Api.TravelTimeApi

All URIs are relative to *https://api.digital.tfl.gov.uk*

Method | HTTP request | Description
------------- | ------------- | -------------
[**TravelTimeGetCompareOverlay**](TravelTimeApi.md#traveltimegetcompareoverlay) | **GET** /TravelTimes/compareOverlay/{z}/mapcenter/{mapCenterLat}/{mapCenterLon}/pinlocation/{pinLat}/{pinLon}/dimensions/{width}/{height} | Gets the TravelTime overlay.
[**TravelTimeGetOverlay**](TravelTimeApi.md#traveltimegetoverlay) | **GET** /TravelTimes/overlay/{z}/mapcenter/{mapCenterLat}/{mapCenterLon}/pinlocation/{pinLat}/{pinLon}/dimensions/{width}/{height} | Gets the TravelTime overlay.


<a name="traveltimegetcompareoverlay"></a>
# **TravelTimeGetCompareOverlay**
> SystemObject TravelTimeGetCompareOverlay (int? z, double? pinLat, double? pinLon, double? mapCenterLat, double? mapCenterLon, string scenarioTitle, string timeOfDayId, string modeId, int? width, int? height, string direction, int? travelTimeInterval, string compareType, string compareValue)

Gets the TravelTime overlay.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class TravelTimeGetCompareOverlayExample
    {
        public void main()
        {
            var apiInstance = new TravelTimeApi();
            var z = 56;  // int? | The zoom level.
            var pinLat = 1.2;  // double? | The latitude of the pin.
            var pinLon = 1.2;  // double? | The longitude of the pin.
            var mapCenterLat = 1.2;  // double? | The map center latitude.
            var mapCenterLon = 1.2;  // double? | The map center longitude.
            var scenarioTitle = scenarioTitle_example;  // string | The title of the scenario.
            var timeOfDayId = timeOfDayId_example;  // string | The id for the time of day (AM/INTER/PM)
            var modeId = modeId_example;  // string | The id of the mode.
            var width = 56;  // int? | The width of the requested overlay.
            var height = 56;  // int? | The height of the requested overlay.
            var direction = direction_example;  // string | The direction of travel.
            var travelTimeInterval = 56;  // int? | The total minutes between the travel time bands
            var compareType = compareType_example;  // string | 
            var compareValue = compareValue_example;  // string | 

            try
            {
                // Gets the TravelTime overlay.
                SystemObject result = apiInstance.TravelTimeGetCompareOverlay(z, pinLat, pinLon, mapCenterLat, mapCenterLon, scenarioTitle, timeOfDayId, modeId, width, height, direction, travelTimeInterval, compareType, compareValue);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TravelTimeApi.TravelTimeGetCompareOverlay: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **z** | **int?**| The zoom level. | 
 **pinLat** | **double?**| The latitude of the pin. | 
 **pinLon** | **double?**| The longitude of the pin. | 
 **mapCenterLat** | **double?**| The map center latitude. | 
 **mapCenterLon** | **double?**| The map center longitude. | 
 **scenarioTitle** | **string**| The title of the scenario. | 
 **timeOfDayId** | **string**| The id for the time of day (AM/INTER/PM) | 
 **modeId** | **string**| The id of the mode. | 
 **width** | **int?**| The width of the requested overlay. | 
 **height** | **int?**| The height of the requested overlay. | 
 **direction** | **string**| The direction of travel. | 
 **travelTimeInterval** | **int?**| The total minutes between the travel time bands | 
 **compareType** | **string**|  | 
 **compareValue** | **string**|  | 

### Return type

[**SystemObject**](SystemObject.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="traveltimegetoverlay"></a>
# **TravelTimeGetOverlay**
> SystemObject TravelTimeGetOverlay (int? z, double? pinLat, double? pinLon, double? mapCenterLat, double? mapCenterLon, string scenarioTitle, string timeOfDayId, string modeId, int? width, int? height, string direction, int? travelTimeInterval)

Gets the TravelTime overlay.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class TravelTimeGetOverlayExample
    {
        public void main()
        {
            var apiInstance = new TravelTimeApi();
            var z = 56;  // int? | The zoom level.
            var pinLat = 1.2;  // double? | The latitude of the pin.
            var pinLon = 1.2;  // double? | The longitude of the pin.
            var mapCenterLat = 1.2;  // double? | The map center latitude.
            var mapCenterLon = 1.2;  // double? | The map center longitude.
            var scenarioTitle = scenarioTitle_example;  // string | The title of the scenario.
            var timeOfDayId = timeOfDayId_example;  // string | The id for the time of day (AM/INTER/PM)
            var modeId = modeId_example;  // string | The id of the mode.
            var width = 56;  // int? | The width of the requested overlay.
            var height = 56;  // int? | The height of the requested overlay.
            var direction = direction_example;  // string | The direction of travel.
            var travelTimeInterval = 56;  // int? | The total minutes between the travel time bands

            try
            {
                // Gets the TravelTime overlay.
                SystemObject result = apiInstance.TravelTimeGetOverlay(z, pinLat, pinLon, mapCenterLat, mapCenterLon, scenarioTitle, timeOfDayId, modeId, width, height, direction, travelTimeInterval);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TravelTimeApi.TravelTimeGetOverlay: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **z** | **int?**| The zoom level. | 
 **pinLat** | **double?**| The latitude of the pin. | 
 **pinLon** | **double?**| The longitude of the pin. | 
 **mapCenterLat** | **double?**| The map center latitude. | 
 **mapCenterLon** | **double?**| The map center longitude. | 
 **scenarioTitle** | **string**| The title of the scenario. | 
 **timeOfDayId** | **string**| The id for the time of day (AM/INTER/PM) | 
 **modeId** | **string**| The id of the mode. | 
 **width** | **int?**| The width of the requested overlay. | 
 **height** | **int?**| The height of the requested overlay. | 
 **direction** | **string**| The direction of travel. | 
 **travelTimeInterval** | **int?**| The total minutes between the travel time bands | 

### Return type

[**SystemObject**](SystemObject.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

