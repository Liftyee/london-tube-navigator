# IO.Swagger.Model.TflApiPresentationEntitiesStopPoint
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**NaptanId** | **string** |  | [optional] 
**PlatformName** | **string** |  | [optional] 
**Indicator** | **string** | The indicator of the stop point e.g. \&quot;Stop K\&quot; | [optional] 
**StopLetter** | **string** | The stop letter, if it could be cleansed from the Indicator e.g. \&quot;K\&quot; | [optional] 
**Modes** | **List&lt;string&gt;** |  | [optional] 
**IcsCode** | **string** |  | [optional] 
**SmsCode** | **string** |  | [optional] 
**StopType** | **string** |  | [optional] 
**StationNaptan** | **string** |  | [optional] 
**AccessibilitySummary** | **string** |  | [optional] 
**HubNaptanCode** | **string** |  | [optional] 
**Lines** | [**List&lt;TflApiPresentationEntitiesIdentifier&gt;**](TflApiPresentationEntitiesIdentifier.md) |  | [optional] 
**LineGroup** | [**List&lt;TflApiPresentationEntitiesLineGroup&gt;**](TflApiPresentationEntitiesLineGroup.md) |  | [optional] 
**LineModeGroups** | [**List&lt;TflApiPresentationEntitiesLineModeGroup&gt;**](TflApiPresentationEntitiesLineModeGroup.md) |  | [optional] 
**FullName** | **string** |  | [optional] 
**NaptanMode** | **string** |  | [optional] 
**Status** | **bool?** |  | [optional] 
**IndividualStopId** | **string** |  | [optional] 
**Id** | **string** | A unique identifier. | [optional] 
**Url** | **string** | The unique location of this resource. | [optional] 
**CommonName** | **string** | A human readable name. | [optional] 
**Distance** | **double?** | The distance of the place from its search point, if this is the result              of a geographical search, otherwise zero. | [optional] 
**PlaceType** | **string** | The type of Place. See /Place/Meta/placeTypes for possible values. | [optional] 
**AdditionalProperties** | [**List&lt;TflApiPresentationEntitiesAdditionalProperties&gt;**](TflApiPresentationEntitiesAdditionalProperties.md) | A bag of additional key/value pairs with extra information about this place. | [optional] 
**Children** | [**List&lt;TflApiPresentationEntitiesPlace&gt;**](TflApiPresentationEntitiesPlace.md) |  | [optional] 
**ChildrenUrls** | **List&lt;string&gt;** |  | [optional] 
**Lat** | **double?** | WGS84 latitude of the location. | [optional] 
**Lon** | **double?** | WGS84 longitude of the location. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

