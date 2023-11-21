# IO.Swagger.Model.TflApiPresentationEntitiesPlace
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
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

