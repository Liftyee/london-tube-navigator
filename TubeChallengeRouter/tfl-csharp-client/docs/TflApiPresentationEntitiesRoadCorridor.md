# IO.Swagger.Model.TflApiPresentationEntitiesRoadCorridor
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | **string** | The Id of the Corridor e.g. \&quot;A406\&quot; | [optional] 
**DisplayName** | **string** | The display name of the Corridor e.g. \&quot;North Circular (A406)\&quot;. This              may be identical to the Id. | [optional] 
**Group** | **string** | The group name of the Corridor e.g. \&quot;Central London\&quot;. Most corridors are not grouped, in which case this field can be null. | [optional] 
**StatusSeverity** | **string** | Standard multi-mode status severity code | [optional] 
**StatusSeverityDescription** | **string** | Description of the status severity as applied to RoadCorridors | [optional] 
**Bounds** | **string** | The Bounds of the Corridor, given by the south-east followed by the north-west co-ordinate              pair in geoJSON format e.g. \&quot;[[-1.241531,51.242151],[1.641223,53.765721]]\&quot; | [optional] 
**Envelope** | **string** | The Envelope of the Corridor, given by the corner co-ordinates of a rectangular (four-point) polygon              in geoJSON format e.g. \&quot;[[-1.241531,51.242151],[-1.241531,53.765721],[1.641223,53.765721],[1.641223,51.242151]]\&quot; | [optional] 
**StatusAggregationStartDate** | **DateTime?** | The start of the period over which status has been aggregated, or null if this is the current corridor status. | [optional] 
**StatusAggregationEndDate** | **DateTime?** | The end of the period over which status has been aggregated, or null if this is the current corridor status. | [optional] 
**Url** | **string** | URL to retrieve this Corridor. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

