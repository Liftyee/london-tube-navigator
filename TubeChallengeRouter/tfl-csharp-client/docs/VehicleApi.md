# IO.Swagger.Api.VehicleApi

All URIs are relative to *https://api.digital.tfl.gov.uk*

Method | HTTP request | Description
------------- | ------------- | -------------
[**VehicleGet**](VehicleApi.md#vehicleget) | **GET** /Vehicle/{ids}/Arrivals | Gets the predictions for a given list of vehicle Id&#39;s.


<a name="vehicleget"></a>
# **VehicleGet**
> List<TflApiPresentationEntitiesPrediction> VehicleGet (List<string> ids)

Gets the predictions for a given list of vehicle Id's.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class VehicleGetExample
    {
        public void main()
        {
            var apiInstance = new VehicleApi();
            var ids = new List<string>(); // List<string> | A comma-separated list of vehicle ids e.g. LX58CFV,LX11AZB,LX58CFE. Max approx. 25 ids.

            try
            {
                // Gets the predictions for a given list of vehicle Id's.
                List&lt;TflApiPresentationEntitiesPrediction&gt; result = apiInstance.VehicleGet(ids);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling VehicleApi.VehicleGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ids** | [**List&lt;string&gt;**](string.md)| A comma-separated list of vehicle ids e.g. LX58CFV,LX11AZB,LX58CFE. Max approx. 25 ids. | 

### Return type

[**List<TflApiPresentationEntitiesPrediction>**](TflApiPresentationEntitiesPrediction.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

