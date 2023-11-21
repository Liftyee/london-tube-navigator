# IO.Swagger.Api.ModeApi

All URIs are relative to *https://api.digital.tfl.gov.uk*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ModeArrivals**](ModeApi.md#modearrivals) | **GET** /Mode/{mode}/Arrivals | Gets the next arrival predictions for all stops of a given mode
[**ModeGetActiveServiceTypes**](ModeApi.md#modegetactiveservicetypes) | **GET** /Mode/ActiveServiceTypes | Returns the service type active for a mode.              Currently only supports tube


<a name="modearrivals"></a>
# **ModeArrivals**
> List<TflApiPresentationEntitiesPrediction> ModeArrivals (string mode, int? count = null)

Gets the next arrival predictions for all stops of a given mode

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ModeArrivalsExample
    {
        public void main()
        {
            var apiInstance = new ModeApi();
            var mode = mode_example;  // string | A mode name e.g. tube, dlr
            var count = 56;  // int? | A number of arrivals to return for each stop, -1 to return all available. (optional) 

            try
            {
                // Gets the next arrival predictions for all stops of a given mode
                List&lt;TflApiPresentationEntitiesPrediction&gt; result = apiInstance.ModeArrivals(mode, count);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ModeApi.ModeArrivals: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **mode** | **string**| A mode name e.g. tube, dlr | 
 **count** | **int?**| A number of arrivals to return for each stop, -1 to return all available. | [optional] 

### Return type

[**List<TflApiPresentationEntitiesPrediction>**](TflApiPresentationEntitiesPrediction.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="modegetactiveservicetypes"></a>
# **ModeGetActiveServiceTypes**
> List<TflApiPresentationEntitiesActiveServiceType> ModeGetActiveServiceTypes ()

Returns the service type active for a mode.              Currently only supports tube

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ModeGetActiveServiceTypesExample
    {
        public void main()
        {
            var apiInstance = new ModeApi();

            try
            {
                // Returns the service type active for a mode.              Currently only supports tube
                List&lt;TflApiPresentationEntitiesActiveServiceType&gt; result = apiInstance.ModeGetActiveServiceTypes();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ModeApi.ModeGetActiveServiceTypes: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**List<TflApiPresentationEntitiesActiveServiceType>**](TflApiPresentationEntitiesActiveServiceType.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

