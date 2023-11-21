# IO.Swagger.Model.TflApiPresentationEntitiesStopPointSequence
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**LineId** | **string** |  | [optional] 
**LineName** | **string** |  | [optional] 
**Direction** | **string** |  | [optional] 
**BranchId** | **int?** | The id of this branch. | [optional] 
**NextBranchIds** | **List&lt;int?&gt;** | The ids of the next branch(es) in the sequence. Note that the next and previous branch id can be              identical in the case of a looped route e.g. the Circle line. | [optional] 
**PrevBranchIds** | **List&lt;int?&gt;** | The ids of the previous branch(es) in the sequence. Note that the next and previous branch id can be              identical in the case of a looped route e.g. the Circle line. | [optional] 
**StopPoint** | [**List&lt;TflApiPresentationEntitiesMatchedStop&gt;**](TflApiPresentationEntitiesMatchedStop.md) |  | [optional] 
**ServiceType** | **string** |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

