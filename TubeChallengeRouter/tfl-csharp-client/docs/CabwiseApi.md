# IO.Swagger.Api.CabwiseApi

All URIs are relative to *https://api.digital.tfl.gov.uk*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CabwiseGet**](CabwiseApi.md#cabwiseget) | **GET** /Cabwise/search | Gets taxis and minicabs contact information


<a name="cabwiseget"></a>
# **CabwiseGet**
> SystemObject CabwiseGet (double? lat, double? lon, string optype = null, string wc = null, double? radius = null, string name = null, int? maxResults = null, bool? legacyFormat = null, bool? forceXml = null, bool? twentyFourSevenOnly = null)

Gets taxis and minicabs contact information

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class CabwiseGetExample
    {
        public void main()
        {
            var apiInstance = new CabwiseApi();
            var lat = 1.2;  // double? | Latitude
            var lon = 1.2;  // double? | Longitude
            var optype = optype_example;  // string | Operator Type e.g Minicab, Executive, Limousine (optional) 
            var wc = wc_example;  // string | Wheelchair accessible (optional) 
            var radius = 1.2;  // double? | The radius of the bounding circle in metres (optional) 
            var name = name_example;  // string | Trading name of operating company (optional) 
            var maxResults = 56;  // int? | An optional parameter to limit the number of results return. Default and maximum is 20. (optional) 
            var legacyFormat = true;  // bool? | Legacy Format (optional) 
            var forceXml = true;  // bool? | Force Xml (optional) 
            var twentyFourSevenOnly = true;  // bool? | Twenty Four Seven Only (optional) 

            try
            {
                // Gets taxis and minicabs contact information
                SystemObject result = apiInstance.CabwiseGet(lat, lon, optype, wc, radius, name, maxResults, legacyFormat, forceXml, twentyFourSevenOnly);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CabwiseApi.CabwiseGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **lat** | **double?**| Latitude | 
 **lon** | **double?**| Longitude | 
 **optype** | **string**| Operator Type e.g Minicab, Executive, Limousine | [optional] 
 **wc** | **string**| Wheelchair accessible | [optional] 
 **radius** | **double?**| The radius of the bounding circle in metres | [optional] 
 **name** | **string**| Trading name of operating company | [optional] 
 **maxResults** | **int?**| An optional parameter to limit the number of results return. Default and maximum is 20. | [optional] 
 **legacyFormat** | **bool?**| Legacy Format | [optional] 
 **forceXml** | **bool?**| Force Xml | [optional] 
 **twentyFourSevenOnly** | **bool?**| Twenty Four Seven Only | [optional] 

### Return type

[**SystemObject**](SystemObject.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

