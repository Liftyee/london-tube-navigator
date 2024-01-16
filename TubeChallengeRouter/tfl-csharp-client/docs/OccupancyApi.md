# IO.Swagger.Api.OccupancyApi

All URIs are relative to *https://api.digital.tfl.gov.uk*

Method | HTTP request | Description
------------- | ------------- | -------------
[**OccupancyGet**](OccupancyApi.md#occupancyget) | **GET** /Occupancy/CarPark/{id} | Gets the occupancy for a car park with a given id
[**OccupancyGetAllChargeConnectorStatus**](OccupancyApi.md#occupancygetallchargeconnectorstatus) | **GET** /Occupancy/ChargeConnector | Gets the occupancy for all charge connectors
[**OccupancyGetBikePointsOccupancies**](OccupancyApi.md#occupancygetbikepointsoccupancies) | **GET** /Occupancy/BikePoints/{ids} | Get the occupancy for bike points.
[**OccupancyGetChargeConnectorStatus**](OccupancyApi.md#occupancygetchargeconnectorstatus) | **GET** /Occupancy/ChargeConnector/{ids} | Gets the occupancy for a charge connectors with a given id (sourceSystemPlaceId)
[**OccupancyGet_0**](OccupancyApi.md#occupancyget_0) | **GET** /Occupancy/CarPark | Gets the occupancy for all car parks that have occupancy data


<a name="occupancyget"></a>
# **OccupancyGet**
> TflApiPresentationEntitiesCarParkOccupancy OccupancyGet (string id)

Gets the occupancy for a car park with a given id

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class OccupancyGetExample
    {
        public void main()
        {
            var apiInstance = new OccupancyApi();
            var id = id_example;  // string | 

            try
            {
                // Gets the occupancy for a car park with a given id
                TflApiPresentationEntitiesCarParkOccupancy result = apiInstance.OccupancyGet(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling OccupancyApi.OccupancyGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**|  | 

### Return type

[**TflApiPresentationEntitiesCarParkOccupancy**](TflApiPresentationEntitiesCarParkOccupancy.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="occupancygetallchargeconnectorstatus"></a>
# **OccupancyGetAllChargeConnectorStatus**
> List<TflApiPresentationEntitiesChargeConnectorOccupancy> OccupancyGetAllChargeConnectorStatus ()

Gets the occupancy for all charge connectors

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class OccupancyGetAllChargeConnectorStatusExample
    {
        public void main()
        {
            var apiInstance = new OccupancyApi();

            try
            {
                // Gets the occupancy for all charge connectors
                List&lt;TflApiPresentationEntitiesChargeConnectorOccupancy&gt; result = apiInstance.OccupancyGetAllChargeConnectorStatus();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling OccupancyApi.OccupancyGetAllChargeConnectorStatus: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**List<TflApiPresentationEntitiesChargeConnectorOccupancy>**](TflApiPresentationEntitiesChargeConnectorOccupancy.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="occupancygetbikepointsoccupancies"></a>
# **OccupancyGetBikePointsOccupancies**
> List<TflApiPresentationEntitiesBikePointOccupancy> OccupancyGetBikePointsOccupancies (List<string> ids)

Get the occupancy for bike points.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class OccupancyGetBikePointsOccupanciesExample
    {
        public void main()
        {
            var apiInstance = new OccupancyApi();
            var ids = new List<string>(); // List<string> | 

            try
            {
                // Get the occupancy for bike points.
                List&lt;TflApiPresentationEntitiesBikePointOccupancy&gt; result = apiInstance.OccupancyGetBikePointsOccupancies(ids);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling OccupancyApi.OccupancyGetBikePointsOccupancies: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ids** | [**List&lt;string&gt;**](string.md)|  | 

### Return type

[**List<TflApiPresentationEntitiesBikePointOccupancy>**](TflApiPresentationEntitiesBikePointOccupancy.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="occupancygetchargeconnectorstatus"></a>
# **OccupancyGetChargeConnectorStatus**
> List<TflApiPresentationEntitiesChargeConnectorOccupancy> OccupancyGetChargeConnectorStatus (List<string> ids)

Gets the occupancy for a charge connectors with a given id (sourceSystemPlaceId)

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class OccupancyGetChargeConnectorStatusExample
    {
        public void main()
        {
            var apiInstance = new OccupancyApi();
            var ids = new List<string>(); // List<string> | 

            try
            {
                // Gets the occupancy for a charge connectors with a given id (sourceSystemPlaceId)
                List&lt;TflApiPresentationEntitiesChargeConnectorOccupancy&gt; result = apiInstance.OccupancyGetChargeConnectorStatus(ids);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling OccupancyApi.OccupancyGetChargeConnectorStatus: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ids** | [**List&lt;string&gt;**](string.md)|  | 

### Return type

[**List<TflApiPresentationEntitiesChargeConnectorOccupancy>**](TflApiPresentationEntitiesChargeConnectorOccupancy.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="occupancyget_0"></a>
# **OccupancyGet_0**
> List<TflApiPresentationEntitiesCarParkOccupancy> OccupancyGet_0 ()

Gets the occupancy for all car parks that have occupancy data

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class OccupancyGet_0Example
    {
        public void main()
        {
            var apiInstance = new OccupancyApi();

            try
            {
                // Gets the occupancy for all car parks that have occupancy data
                List&lt;TflApiPresentationEntitiesCarParkOccupancy&gt; result = apiInstance.OccupancyGet_0();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling OccupancyApi.OccupancyGet_0: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**List<TflApiPresentationEntitiesCarParkOccupancy>**](TflApiPresentationEntitiesCarParkOccupancy.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

