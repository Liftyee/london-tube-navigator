# IO.Swagger - the C# library for the Transport for London Unified API

No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)

This C# SDK is automatically generated by the [Swagger Codegen](https://github.com/swagger-api/swagger-codegen) project:

- API version: v1
- SDK version: 1.0.0
- Build package: io.swagger.codegen.languages.CSharpClientCodegen

<a name="frameworks-supported"></a>
## Frameworks supported
- .NET 4.0 or later
- Windows Phone 7.1 (Mango)

<a name="dependencies"></a>
## Dependencies
- [RestSharp](https://www.nuget.org/packages/RestSharp) - 105.1.0 or later
- [Json.NET](https://www.nuget.org/packages/Newtonsoft.Json/) - 7.0.0 or later
- [JsonSubTypes](https://www.nuget.org/packages/JsonSubTypes/) - 1.2.0 or later

The DLLs included in the package may not be the latest version. We recommend using [NuGet](https://docs.nuget.org/consume/installing-nuget) to obtain the latest version of the packages:
```
Install-Package RestSharp
Install-Package Newtonsoft.Json
Install-Package JsonSubTypes
```

NOTE: RestSharp versions greater than 105.1.0 have a bug which causes file uploads to fail. See [RestSharp#742](https://github.com/restsharp/RestSharp/issues/742)

<a name="installation"></a>
## Installation
Run the following command to generate the DLL
- [Mac/Linux] `/bin/sh build.sh`
- [Windows] `build.bat`

Then include the DLL (under the `bin` folder) in the C# project, and use the namespaces:
```csharp
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;
```
<a name="packaging"></a>
## Packaging

A `.nuspec` is included with the project. You can follow the Nuget quickstart to [create](https://docs.microsoft.com/en-us/nuget/quickstart/create-and-publish-a-package#create-the-package) and [publish](https://docs.microsoft.com/en-us/nuget/quickstart/create-and-publish-a-package#publish-the-package) packages.

This `.nuspec` uses placeholders from the `.csproj`, so build the `.csproj` directly:

```
nuget pack -Build -OutputDirectory out IO.Swagger.csproj
```

Then, publish to a [local feed](https://docs.microsoft.com/en-us/nuget/hosting-packages/local-feeds) or [other host](https://docs.microsoft.com/en-us/nuget/hosting-packages/overview) and consume the new package via Nuget as usual.

<a name="getting-started"></a>
## Getting Started

```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class Example
    {
        public void main()
        {

            var apiInstance = new AccidentStatsApi();
            var year = 56;  // int? | The year for which to filter the accidents on.

            try
            {
                // Gets all accident details for accidents occuring in the specified year
                List<TflApiPresentationEntitiesAccidentStatsAccidentDetail> result = apiInstance.AccidentStatsGet(year);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AccidentStatsApi.AccidentStatsGet: " + e.Message );
            }

        }
    }
}
```

<a name="documentation-for-api-endpoints"></a>
## Documentation for API Endpoints

All URIs are relative to *https://api.digital.tfl.gov.uk*

Class | Method | HTTP request | Description
------------ | ------------- | ------------- | -------------
*AccidentStatsApi* | [**AccidentStatsGet**](docs/AccidentStatsApi.md#accidentstatsget) | **GET** /AccidentStats/{year} | Gets all accident details for accidents occuring in the specified year
*AirQualityApi* | [**AirQualityGet**](docs/AirQualityApi.md#airqualityget) | **GET** /AirQuality | Gets air quality data feed
*BikePointApi* | [**BikePointGet**](docs/BikePointApi.md#bikepointget) | **GET** /BikePoint/{id} | Gets the bike point with the given id.
*BikePointApi* | [**BikePointGetAll**](docs/BikePointApi.md#bikepointgetall) | **GET** /BikePoint | Gets all bike point locations. The Place object has an addtionalProperties array which contains the nbBikes, nbDocks and nbSpaces              numbers which give the status of the BikePoint. A mismatch in these numbers i.e. nbDocks - (nbBikes + nbSpaces) != 0 indicates broken docks.
*BikePointApi* | [**BikePointSearch**](docs/BikePointApi.md#bikepointsearch) | **GET** /BikePoint/Search | Search for bike stations by their name, a bike point's name often contains information about the name of the street              or nearby landmarks, for example. Note that the search result does not contain the PlaceProperties i.e. the status              or occupancy of the BikePoint, to get that information you should retrieve the BikePoint by its id on /BikePoint/id.
*CabwiseApi* | [**CabwiseGet**](docs/CabwiseApi.md#cabwiseget) | **GET** /Cabwise/search | Gets taxis and minicabs contact information
*JourneyApi* | [**JourneyJourneyResults**](docs/JourneyApi.md#journeyjourneyresults) | **GET** /Journey/JourneyResults/{from}/to/{to} | Perform a Journey Planner search from the parameters specified in simple types
*JourneyApi* | [**JourneyMeta**](docs/JourneyApi.md#journeymeta) | **GET** /Journey/Meta/Modes | Gets a list of all of the available journey planner modes
*LineApi* | [**LineArrivals**](docs/LineApi.md#linearrivals) | **GET** /Line/{ids}/Arrivals/{stopPointId} | Get the list of arrival predictions for given line ids based at the given stop
*LineApi* | [**LineDisruption**](docs/LineApi.md#linedisruption) | **GET** /Line/{ids}/Disruption | Get disruptions for the given line ids
*LineApi* | [**LineDisruptionByMode**](docs/LineApi.md#linedisruptionbymode) | **GET** /Line/Mode/{modes}/Disruption | Get disruptions for all lines of the given modes.
*LineApi* | [**LineGet**](docs/LineApi.md#lineget) | **GET** /Line/{ids} | Gets lines that match the specified line ids.
*LineApi* | [**LineGetByMode**](docs/LineApi.md#linegetbymode) | **GET** /Line/Mode/{modes} | Gets lines that serve the given modes.
*LineApi* | [**LineLineRoutesByIds**](docs/LineApi.md#linelineroutesbyids) | **GET** /Line/{ids}/Route | Get all valid routes for given line ids, including the name and id of the originating and terminating stops for each route.
*LineApi* | [**LineMetaDisruptionCategories**](docs/LineApi.md#linemetadisruptioncategories) | **GET** /Line/Meta/DisruptionCategories | Gets a list of valid disruption categories
*LineApi* | [**LineMetaModes**](docs/LineApi.md#linemetamodes) | **GET** /Line/Meta/Modes | Gets a list of valid modes
*LineApi* | [**LineMetaServiceTypes**](docs/LineApi.md#linemetaservicetypes) | **GET** /Line/Meta/ServiceTypes | Gets a list of valid ServiceTypes to filter on
*LineApi* | [**LineMetaSeverity**](docs/LineApi.md#linemetaseverity) | **GET** /Line/Meta/Severity | Gets a list of valid severity codes
*LineApi* | [**LineRoute**](docs/LineApi.md#lineroute) | **GET** /Line/Route | Get all valid routes for all lines, including the name and id of the originating and terminating stops for each route.
*LineApi* | [**LineRouteByMode**](docs/LineApi.md#lineroutebymode) | **GET** /Line/Mode/{modes}/Route | Gets all lines and their valid routes for given modes, including the name and id of the originating and terminating stops for each route
*LineApi* | [**LineRouteSequence**](docs/LineApi.md#lineroutesequence) | **GET** /Line/{id}/Route/Sequence/{direction} | Gets all valid routes for given line id, including the sequence of stops on each route.
*LineApi* | [**LineSearch**](docs/LineApi.md#linesearch) | **GET** /Line/Search/{query} | Search for lines or routes matching the query string
*LineApi* | [**LineStatus**](docs/LineApi.md#linestatus) | **GET** /Line/{ids}/Status/{StartDate}/to/{EndDate} | Gets the line status for given line ids during the provided dates e.g Minor Delays
*LineApi* | [**LineStatusByIds**](docs/LineApi.md#linestatusbyids) | **GET** /Line/{ids}/Status | Gets the line status of for given line ids e.g Minor Delays
*LineApi* | [**LineStatusByMode**](docs/LineApi.md#linestatusbymode) | **GET** /Line/Mode/{modes}/Status | Gets the line status of for all lines for the given modes
*LineApi* | [**LineStatusBySeverity**](docs/LineApi.md#linestatusbyseverity) | **GET** /Line/Status/{severity} | Gets the line status for all lines with a given severity              A list of valid severity codes can be obtained from a call to Line/Meta/Severity
*LineApi* | [**LineStopPoints**](docs/LineApi.md#linestoppoints) | **GET** /Line/{id}/StopPoints | Gets a list of the stations that serve the given line id
*LineApi* | [**LineTimetable**](docs/LineApi.md#linetimetable) | **GET** /Line/{id}/Timetable/{fromStopPointId} | Gets the timetable for a specified station on the give line
*LineApi* | [**LineTimetableTo**](docs/LineApi.md#linetimetableto) | **GET** /Line/{id}/Timetable/{fromStopPointId}/to/{toStopPointId} | Gets the timetable for a specified station on the give line with specified destination
*ModeApi* | [**ModeArrivals**](docs/ModeApi.md#modearrivals) | **GET** /Mode/{mode}/Arrivals | Gets the next arrival predictions for all stops of a given mode
*ModeApi* | [**ModeGetActiveServiceTypes**](docs/ModeApi.md#modegetactiveservicetypes) | **GET** /Mode/ActiveServiceTypes | Returns the service type active for a mode.              Currently only supports tube
*OccupancyApi* | [**OccupancyGet**](docs/OccupancyApi.md#occupancyget) | **GET** /Occupancy/CarPark/{id} | Gets the occupancy for a car park with a given id
*OccupancyApi* | [**OccupancyGetAllChargeConnectorStatus**](docs/OccupancyApi.md#occupancygetallchargeconnectorstatus) | **GET** /Occupancy/ChargeConnector | Gets the occupancy for all charge connectors
*OccupancyApi* | [**OccupancyGetBikePointsOccupancies**](docs/OccupancyApi.md#occupancygetbikepointsoccupancies) | **GET** /Occupancy/BikePoints/{ids} | Get the occupancy for bike points.
*OccupancyApi* | [**OccupancyGetChargeConnectorStatus**](docs/OccupancyApi.md#occupancygetchargeconnectorstatus) | **GET** /Occupancy/ChargeConnector/{ids} | Gets the occupancy for a charge connectors with a given id (sourceSystemPlaceId)
*OccupancyApi* | [**OccupancyGet_0**](docs/OccupancyApi.md#occupancyget_0) | **GET** /Occupancy/CarPark | Gets the occupancy for all car parks that have occupancy data
*PlaceApi* | [**PlaceGet**](docs/PlaceApi.md#placeget) | **GET** /Place/{id} | Gets the place with the given id.
*PlaceApi* | [**PlaceGetAt**](docs/PlaceApi.md#placegetat) | **GET** /Place/{type}/At/{Lat}/{Lon} | Gets any places of the given type whose geography intersects the given latitude and longitude. In practice this means the Place              must be polygonal e.g. a BoroughBoundary.
*PlaceApi* | [**PlaceGetByGeo**](docs/PlaceApi.md#placegetbygeo) | **GET** /Place | Gets the places that lie within a geographic region. The geographic region of interest can either be specified              by using a lat/lon geo-point and a radius in metres to return places within the locus defined by the lat/lon of              its centre or alternatively, by the use of a bounding box defined by the lat/lon of its north-west and south-east corners.              Optionally filters on type and can strip properties for a smaller payload.
*PlaceApi* | [**PlaceGetByType**](docs/PlaceApi.md#placegetbytype) | **GET** /Place/Type/{types} | Gets all places of a given type
*PlaceApi* | [**PlaceGetOverlay**](docs/PlaceApi.md#placegetoverlay) | **GET** /Place/{type}/overlay/{z}/{Lat}/{Lon}/{width}/{height} | Gets the place overlay for a given set of co-ordinates and a given width/height.
*PlaceApi* | [**PlaceGetStreetsByPostCode**](docs/PlaceApi.md#placegetstreetsbypostcode) | **GET** /Place/Address/Streets/{Postcode} | Gets the set of streets associated with a post code.
*PlaceApi* | [**PlaceMetaCategories**](docs/PlaceApi.md#placemetacategories) | **GET** /Place/Meta/Categories | Gets a list of all of the available place property categories and keys.
*PlaceApi* | [**PlaceMetaPlaceTypes**](docs/PlaceApi.md#placemetaplacetypes) | **GET** /Place/Meta/PlaceTypes | Gets a list of the available types of Place.
*PlaceApi* | [**PlaceSearch**](docs/PlaceApi.md#placesearch) | **GET** /Place/Search | Gets all places that matches the given query
*RoadApi* | [**RoadDisruptedStreets**](docs/RoadApi.md#roaddisruptedstreets) | **GET** /Road/all/Street/Disruption | Gets a list of disrupted streets. If no date filters are provided, current disruptions are returned.
*RoadApi* | [**RoadDisruption**](docs/RoadApi.md#roaddisruption) | **GET** /Road/{ids}/Disruption | Get active disruptions, filtered by road ids
*RoadApi* | [**RoadDisruptionById**](docs/RoadApi.md#roaddisruptionbyid) | **GET** /Road/all/Disruption/{disruptionIds} | Gets a list of active disruptions filtered by disruption Ids.
*RoadApi* | [**RoadGet**](docs/RoadApi.md#roadget) | **GET** /Road | Gets all roads managed by TfL
*RoadApi* | [**RoadGet_0**](docs/RoadApi.md#roadget_0) | **GET** /Road/{ids} | Gets the road with the specified id (e.g. A1)
*RoadApi* | [**RoadMetaCategories**](docs/RoadApi.md#roadmetacategories) | **GET** /Road/Meta/Categories | Gets a list of valid RoadDisruption categories
*RoadApi* | [**RoadMetaSeverities**](docs/RoadApi.md#roadmetaseverities) | **GET** /Road/Meta/Severities | Gets a list of valid RoadDisruption severity codes
*RoadApi* | [**RoadStatus**](docs/RoadApi.md#roadstatus) | **GET** /Road/{ids}/Status | Gets the specified roads with the status aggregated over the date range specified, or now until the end of today if no dates are passed.
*SearchApi* | [**SearchBusSchedules**](docs/SearchApi.md#searchbusschedules) | **GET** /Search/BusSchedules | Searches the bus schedules folder on S3 for a given bus number.
*SearchApi* | [**SearchGet**](docs/SearchApi.md#searchget) | **GET** /Search | Search the site for occurrences of the query string. The maximum number of results returned is equal to the maximum page size              of 100. To return subsequent pages, use the paginated overload.
*SearchApi* | [**SearchMetaCategories**](docs/SearchApi.md#searchmetacategories) | **GET** /Search/Meta/Categories | Gets the available search categories.
*SearchApi* | [**SearchMetaSearchProviders**](docs/SearchApi.md#searchmetasearchproviders) | **GET** /Search/Meta/SearchProviders | Gets the available searchProvider names.
*SearchApi* | [**SearchMetaSorts**](docs/SearchApi.md#searchmetasorts) | **GET** /Search/Meta/Sorts | Gets the available sorting options.
*StopPointApi* | [**StopPointArrivalDepartures**](docs/StopPointApi.md#stoppointarrivaldepartures) | **GET** /StopPoint/{id}/ArrivalDepartures | Gets the list of arrival and departure predictions for the given stop point id (overground, Elizabeth line and thameslink only)
*StopPointApi* | [**StopPointArrivals**](docs/StopPointApi.md#stoppointarrivals) | **GET** /StopPoint/{id}/Arrivals | Gets the list of arrival predictions for the given stop point id
*StopPointApi* | [**StopPointCrowding**](docs/StopPointApi.md#stoppointcrowding) | **GET** /StopPoint/{id}/Crowding/{line} | Gets all the Crowding data (static) for the StopPointId, plus crowding data for a given line and optionally a particular direction.
*StopPointApi* | [**StopPointDirection**](docs/StopPointApi.md#stoppointdirection) | **GET** /StopPoint/{id}/DirectionTo/{toStopPointId} | Returns the canonical direction, \"inbound\" or \"outbound\", for a given pair of stop point Ids in the direction from -&gt; to.
*StopPointApi* | [**StopPointDisruption**](docs/StopPointApi.md#stoppointdisruption) | **GET** /StopPoint/{ids}/Disruption | Gets all disruptions for the specified StopPointId, plus disruptions for any child Naptan records it may have.
*StopPointApi* | [**StopPointDisruptionByMode**](docs/StopPointApi.md#stoppointdisruptionbymode) | **GET** /StopPoint/Mode/{modes}/Disruption | Gets a distinct list of disrupted stop points for the given modes
*StopPointApi* | [**StopPointGet**](docs/StopPointApi.md#stoppointget) | **GET** /StopPoint/{id}/placeTypes | Get a list of places corresponding to a given id and place types.
*StopPointApi* | [**StopPointGetByGeoPoint**](docs/StopPointApi.md#stoppointgetbygeopoint) | **GET** /StopPoint | Gets a list of StopPoints within {radius} by the specified criteria
*StopPointApi* | [**StopPointGetByMode**](docs/StopPointApi.md#stoppointgetbymode) | **GET** /StopPoint/Mode/{modes} | Gets a list of StopPoints filtered by the modes available at that StopPoint.
*StopPointApi* | [**StopPointGetBySms**](docs/StopPointApi.md#stoppointgetbysms) | **GET** /StopPoint/Sms/{id} | Gets a StopPoint for a given sms code.
*StopPointApi* | [**StopPointGetByType**](docs/StopPointApi.md#stoppointgetbytype) | **GET** /StopPoint/Type/{types} | Gets all stop points of a given type
*StopPointApi* | [**StopPointGetByTypeWithPagination**](docs/StopPointApi.md#stoppointgetbytypewithpagination) | **GET** /StopPoint/Type/{types}/page/{page} | Gets all the stop points of given type(s) with a page number
*StopPointApi* | [**StopPointGetCarParksById**](docs/StopPointApi.md#stoppointgetcarparksbyid) | **GET** /StopPoint/{stopPointId}/CarParks | Get car parks corresponding to the given stop point id.
*StopPointApi* | [**StopPointGetId**](docs/StopPointApi.md#stoppointgetid) | **GET** /StopPoint/{ids} | Gets a list of StopPoints corresponding to the given list of stop ids.
*StopPointApi* | [**StopPointGetServiceTypes**](docs/StopPointApi.md#stoppointgetservicetypes) | **GET** /StopPoint/ServiceTypes | Gets the service types for a given stoppoint
*StopPointApi* | [**StopPointGetTaxiRanksByIds**](docs/StopPointApi.md#stoppointgettaxiranksbyids) | **GET** /StopPoint/{stopPointId}/TaxiRanks | Gets a list of taxi ranks corresponding to the given stop point id.
*StopPointApi* | [**StopPointMetaCategories**](docs/StopPointApi.md#stoppointmetacategories) | **GET** /StopPoint/Meta/Categories | Gets the list of available StopPoint additional information categories
*StopPointApi* | [**StopPointMetaModes**](docs/StopPointApi.md#stoppointmetamodes) | **GET** /StopPoint/Meta/Modes | Gets the list of available StopPoint modes
*StopPointApi* | [**StopPointMetaStopTypes**](docs/StopPointApi.md#stoppointmetastoptypes) | **GET** /StopPoint/Meta/StopTypes | Gets the list of available StopPoint types
*StopPointApi* | [**StopPointReachableFrom**](docs/StopPointApi.md#stoppointreachablefrom) | **GET** /StopPoint/{id}/CanReachOnLine/{lineId} | Gets Stopoints that are reachable from a station/line combination.
*StopPointApi* | [**StopPointRoute**](docs/StopPointApi.md#stoppointroute) | **GET** /StopPoint/{id}/Route | Returns the route sections for all the lines that service the given stop point ids
*StopPointApi* | [**StopPointSearch**](docs/StopPointApi.md#stoppointsearch) | **GET** /StopPoint/Search/{query} | Search StopPoints by their common name, or their 5-digit Countdown Bus Stop Code.
*StopPointApi* | [**StopPointSearch_0**](docs/StopPointApi.md#stoppointsearch_0) | **GET** /StopPoint/Search | Search StopPoints by their common name, or their 5-digit Countdown Bus Stop Code.
*TravelTimeApi* | [**TravelTimeGetCompareOverlay**](docs/TravelTimeApi.md#traveltimegetcompareoverlay) | **GET** /TravelTimes/compareOverlay/{z}/mapcenter/{mapCenterLat}/{mapCenterLon}/pinlocation/{pinLat}/{pinLon}/dimensions/{width}/{height} | Gets the TravelTime overlay.
*TravelTimeApi* | [**TravelTimeGetOverlay**](docs/TravelTimeApi.md#traveltimegetoverlay) | **GET** /TravelTimes/overlay/{z}/mapcenter/{mapCenterLat}/{mapCenterLon}/pinlocation/{pinLat}/{pinLon}/dimensions/{width}/{height} | Gets the TravelTime overlay.
*VehicleApi* | [**VehicleGet**](docs/VehicleApi.md#vehicleget) | **GET** /Vehicle/{ids}/Arrivals | Gets the predictions for a given list of vehicle Id's.


<a name="documentation-for-models"></a>
## Documentation for Models

 - [Model.SystemDataSpatialDbGeography](docs/SystemDataSpatialDbGeography.md)
 - [Model.SystemDataSpatialDbGeographyWellKnownValue](docs/SystemDataSpatialDbGeographyWellKnownValue.md)
 - [Model.SystemObject](docs/SystemObject.md)
 - [Model.TflApiCommonApiVersionInfo](docs/TflApiCommonApiVersionInfo.md)
 - [Model.TflApiCommonDateRange](docs/TflApiCommonDateRange.md)
 - [Model.TflApiCommonDateRangeNullable](docs/TflApiCommonDateRangeNullable.md)
 - [Model.TflApiCommonGeoPoint](docs/TflApiCommonGeoPoint.md)
 - [Model.TflApiCommonJourneyPlannerJpElevation](docs/TflApiCommonJourneyPlannerJpElevation.md)
 - [Model.TflApiCommonPlaceGeo](docs/TflApiCommonPlaceGeo.md)
 - [Model.TflApiCommonPostcodeInput](docs/TflApiCommonPostcodeInput.md)
 - [Model.TflApiPresentationEntitiesAccidentStatsAccidentDetail](docs/TflApiPresentationEntitiesAccidentStatsAccidentDetail.md)
 - [Model.TflApiPresentationEntitiesAccidentStatsAccidentStatsOrderedSummary](docs/TflApiPresentationEntitiesAccidentStatsAccidentStatsOrderedSummary.md)
 - [Model.TflApiPresentationEntitiesAccidentStatsCasualty](docs/TflApiPresentationEntitiesAccidentStatsCasualty.md)
 - [Model.TflApiPresentationEntitiesAccidentStatsVehicle](docs/TflApiPresentationEntitiesAccidentStatsVehicle.md)
 - [Model.TflApiPresentationEntitiesActiveServiceType](docs/TflApiPresentationEntitiesActiveServiceType.md)
 - [Model.TflApiPresentationEntitiesAdditionalProperties](docs/TflApiPresentationEntitiesAdditionalProperties.md)
 - [Model.TflApiPresentationEntitiesArrivalDeparture](docs/TflApiPresentationEntitiesArrivalDeparture.md)
 - [Model.TflApiPresentationEntitiesArrivalDepartureWithLine](docs/TflApiPresentationEntitiesArrivalDepartureWithLine.md)
 - [Model.TflApiPresentationEntitiesBay](docs/TflApiPresentationEntitiesBay.md)
 - [Model.TflApiPresentationEntitiesBikePointOccupancy](docs/TflApiPresentationEntitiesBikePointOccupancy.md)
 - [Model.TflApiPresentationEntitiesCarParkOccupancy](docs/TflApiPresentationEntitiesCarParkOccupancy.md)
 - [Model.TflApiPresentationEntitiesChargeConnectorOccupancy](docs/TflApiPresentationEntitiesChargeConnectorOccupancy.md)
 - [Model.TflApiPresentationEntitiesCoordinate](docs/TflApiPresentationEntitiesCoordinate.md)
 - [Model.TflApiPresentationEntitiesCrowding](docs/TflApiPresentationEntitiesCrowding.md)
 - [Model.TflApiPresentationEntitiesCycleSuperhighway](docs/TflApiPresentationEntitiesCycleSuperhighway.md)
 - [Model.TflApiPresentationEntitiesDisruptedPoint](docs/TflApiPresentationEntitiesDisruptedPoint.md)
 - [Model.TflApiPresentationEntitiesDisruptedRoute](docs/TflApiPresentationEntitiesDisruptedRoute.md)
 - [Model.TflApiPresentationEntitiesDisruption](docs/TflApiPresentationEntitiesDisruption.md)
 - [Model.TflApiPresentationEntitiesFaresFare](docs/TflApiPresentationEntitiesFaresFare.md)
 - [Model.TflApiPresentationEntitiesFaresFareBounds](docs/TflApiPresentationEntitiesFaresFareBounds.md)
 - [Model.TflApiPresentationEntitiesFaresFareDetails](docs/TflApiPresentationEntitiesFaresFareDetails.md)
 - [Model.TflApiPresentationEntitiesFaresFareStation](docs/TflApiPresentationEntitiesFaresFareStation.md)
 - [Model.TflApiPresentationEntitiesFaresFaresMode](docs/TflApiPresentationEntitiesFaresFaresMode.md)
 - [Model.TflApiPresentationEntitiesFaresFaresPeriod](docs/TflApiPresentationEntitiesFaresFaresPeriod.md)
 - [Model.TflApiPresentationEntitiesFaresFaresSection](docs/TflApiPresentationEntitiesFaresFaresSection.md)
 - [Model.TflApiPresentationEntitiesFaresJourney](docs/TflApiPresentationEntitiesFaresJourney.md)
 - [Model.TflApiPresentationEntitiesFaresPassengerType](docs/TflApiPresentationEntitiesFaresPassengerType.md)
 - [Model.TflApiPresentationEntitiesFaresRecommendation](docs/TflApiPresentationEntitiesFaresRecommendation.md)
 - [Model.TflApiPresentationEntitiesFaresRecommendationResponse](docs/TflApiPresentationEntitiesFaresRecommendationResponse.md)
 - [Model.TflApiPresentationEntitiesFaresTicket](docs/TflApiPresentationEntitiesFaresTicket.md)
 - [Model.TflApiPresentationEntitiesFaresTicketTime](docs/TflApiPresentationEntitiesFaresTicketTime.md)
 - [Model.TflApiPresentationEntitiesFaresTicketType](docs/TflApiPresentationEntitiesFaresTicketType.md)
 - [Model.TflApiPresentationEntitiesGeoCodeSearchMatch](docs/TflApiPresentationEntitiesGeoCodeSearchMatch.md)
 - [Model.TflApiPresentationEntitiesIdentifier](docs/TflApiPresentationEntitiesIdentifier.md)
 - [Model.TflApiPresentationEntitiesInstruction](docs/TflApiPresentationEntitiesInstruction.md)
 - [Model.TflApiPresentationEntitiesInstructionStep](docs/TflApiPresentationEntitiesInstructionStep.md)
 - [Model.TflApiPresentationEntitiesInterval](docs/TflApiPresentationEntitiesInterval.md)
 - [Model.TflApiPresentationEntitiesJourneyPlannerFare](docs/TflApiPresentationEntitiesJourneyPlannerFare.md)
 - [Model.TflApiPresentationEntitiesJourneyPlannerFareCaveat](docs/TflApiPresentationEntitiesJourneyPlannerFareCaveat.md)
 - [Model.TflApiPresentationEntitiesJourneyPlannerFareTap](docs/TflApiPresentationEntitiesJourneyPlannerFareTap.md)
 - [Model.TflApiPresentationEntitiesJourneyPlannerFareTapDetails](docs/TflApiPresentationEntitiesJourneyPlannerFareTapDetails.md)
 - [Model.TflApiPresentationEntitiesJourneyPlannerItineraryResult](docs/TflApiPresentationEntitiesJourneyPlannerItineraryResult.md)
 - [Model.TflApiPresentationEntitiesJourneyPlannerJourney](docs/TflApiPresentationEntitiesJourneyPlannerJourney.md)
 - [Model.TflApiPresentationEntitiesJourneyPlannerJourneyFare](docs/TflApiPresentationEntitiesJourneyPlannerJourneyFare.md)
 - [Model.TflApiPresentationEntitiesJourneyPlannerJourneyPlannerCycleHireDockingStationData](docs/TflApiPresentationEntitiesJourneyPlannerJourneyPlannerCycleHireDockingStationData.md)
 - [Model.TflApiPresentationEntitiesJourneyPlannerJourneyVector](docs/TflApiPresentationEntitiesJourneyPlannerJourneyVector.md)
 - [Model.TflApiPresentationEntitiesJourneyPlannerLeg](docs/TflApiPresentationEntitiesJourneyPlannerLeg.md)
 - [Model.TflApiPresentationEntitiesJourneyPlannerObstacle](docs/TflApiPresentationEntitiesJourneyPlannerObstacle.md)
 - [Model.TflApiPresentationEntitiesJourneyPlannerPath](docs/TflApiPresentationEntitiesJourneyPlannerPath.md)
 - [Model.TflApiPresentationEntitiesJourneyPlannerPlannedWork](docs/TflApiPresentationEntitiesJourneyPlannerPlannedWork.md)
 - [Model.TflApiPresentationEntitiesJourneyPlannerRouteOption](docs/TflApiPresentationEntitiesJourneyPlannerRouteOption.md)
 - [Model.TflApiPresentationEntitiesJourneyPlannerSearchCriteria](docs/TflApiPresentationEntitiesJourneyPlannerSearchCriteria.md)
 - [Model.TflApiPresentationEntitiesJourneyPlannerTimeAdjustment](docs/TflApiPresentationEntitiesJourneyPlannerTimeAdjustment.md)
 - [Model.TflApiPresentationEntitiesJourneyPlannerTimeAdjustments](docs/TflApiPresentationEntitiesJourneyPlannerTimeAdjustments.md)
 - [Model.TflApiPresentationEntitiesKnownJourney](docs/TflApiPresentationEntitiesKnownJourney.md)
 - [Model.TflApiPresentationEntitiesLine](docs/TflApiPresentationEntitiesLine.md)
 - [Model.TflApiPresentationEntitiesLineGroup](docs/TflApiPresentationEntitiesLineGroup.md)
 - [Model.TflApiPresentationEntitiesLineModeGroup](docs/TflApiPresentationEntitiesLineModeGroup.md)
 - [Model.TflApiPresentationEntitiesLineRouteSection](docs/TflApiPresentationEntitiesLineRouteSection.md)
 - [Model.TflApiPresentationEntitiesLineServiceType](docs/TflApiPresentationEntitiesLineServiceType.md)
 - [Model.TflApiPresentationEntitiesLineServiceTypeInfo](docs/TflApiPresentationEntitiesLineServiceTypeInfo.md)
 - [Model.TflApiPresentationEntitiesLineSpecificServiceType](docs/TflApiPresentationEntitiesLineSpecificServiceType.md)
 - [Model.TflApiPresentationEntitiesLineStatus](docs/TflApiPresentationEntitiesLineStatus.md)
 - [Model.TflApiPresentationEntitiesMatchedRoute](docs/TflApiPresentationEntitiesMatchedRoute.md)
 - [Model.TflApiPresentationEntitiesMatchedRouteSections](docs/TflApiPresentationEntitiesMatchedRouteSections.md)
 - [Model.TflApiPresentationEntitiesMatchedStop](docs/TflApiPresentationEntitiesMatchedStop.md)
 - [Model.TflApiPresentationEntitiesMessage](docs/TflApiPresentationEntitiesMessage.md)
 - [Model.TflApiPresentationEntitiesMode](docs/TflApiPresentationEntitiesMode.md)
 - [Model.TflApiPresentationEntitiesNetworkStatus](docs/TflApiPresentationEntitiesNetworkStatus.md)
 - [Model.TflApiPresentationEntitiesOrderedRoute](docs/TflApiPresentationEntitiesOrderedRoute.md)
 - [Model.TflApiPresentationEntitiesPassengerFlow](docs/TflApiPresentationEntitiesPassengerFlow.md)
 - [Model.TflApiPresentationEntitiesPathAttribute](docs/TflApiPresentationEntitiesPathAttribute.md)
 - [Model.TflApiPresentationEntitiesPeriod](docs/TflApiPresentationEntitiesPeriod.md)
 - [Model.TflApiPresentationEntitiesPlace](docs/TflApiPresentationEntitiesPlace.md)
 - [Model.TflApiPresentationEntitiesPlaceCategory](docs/TflApiPresentationEntitiesPlaceCategory.md)
 - [Model.TflApiPresentationEntitiesPlacePolygon](docs/TflApiPresentationEntitiesPlacePolygon.md)
 - [Model.TflApiPresentationEntitiesPoint](docs/TflApiPresentationEntitiesPoint.md)
 - [Model.TflApiPresentationEntitiesPrediction](docs/TflApiPresentationEntitiesPrediction.md)
 - [Model.TflApiPresentationEntitiesPredictionTiming](docs/TflApiPresentationEntitiesPredictionTiming.md)
 - [Model.TflApiPresentationEntitiesRedirect](docs/TflApiPresentationEntitiesRedirect.md)
 - [Model.TflApiPresentationEntitiesRoadCorridor](docs/TflApiPresentationEntitiesRoadCorridor.md)
 - [Model.TflApiPresentationEntitiesRoadDisruption](docs/TflApiPresentationEntitiesRoadDisruption.md)
 - [Model.TflApiPresentationEntitiesRoadDisruptionImpactArea](docs/TflApiPresentationEntitiesRoadDisruptionImpactArea.md)
 - [Model.TflApiPresentationEntitiesRoadDisruptionLine](docs/TflApiPresentationEntitiesRoadDisruptionLine.md)
 - [Model.TflApiPresentationEntitiesRoadDisruptionSchedule](docs/TflApiPresentationEntitiesRoadDisruptionSchedule.md)
 - [Model.TflApiPresentationEntitiesRoadProject](docs/TflApiPresentationEntitiesRoadProject.md)
 - [Model.TflApiPresentationEntitiesRouteSearchMatch](docs/TflApiPresentationEntitiesRouteSearchMatch.md)
 - [Model.TflApiPresentationEntitiesRouteSearchResponse](docs/TflApiPresentationEntitiesRouteSearchResponse.md)
 - [Model.TflApiPresentationEntitiesRouteSectionNaptanEntrySequence](docs/TflApiPresentationEntitiesRouteSectionNaptanEntrySequence.md)
 - [Model.TflApiPresentationEntitiesRouteSequence](docs/TflApiPresentationEntitiesRouteSequence.md)
 - [Model.TflApiPresentationEntitiesSchedule](docs/TflApiPresentationEntitiesSchedule.md)
 - [Model.TflApiPresentationEntitiesSearchMatch](docs/TflApiPresentationEntitiesSearchMatch.md)
 - [Model.TflApiPresentationEntitiesSearchResponse](docs/TflApiPresentationEntitiesSearchResponse.md)
 - [Model.TflApiPresentationEntitiesServiceFrequency](docs/TflApiPresentationEntitiesServiceFrequency.md)
 - [Model.TflApiPresentationEntitiesStationInterval](docs/TflApiPresentationEntitiesStationInterval.md)
 - [Model.TflApiPresentationEntitiesStatusSeverity](docs/TflApiPresentationEntitiesStatusSeverity.md)
 - [Model.TflApiPresentationEntitiesStopPoint](docs/TflApiPresentationEntitiesStopPoint.md)
 - [Model.TflApiPresentationEntitiesStopPointCategory](docs/TflApiPresentationEntitiesStopPointCategory.md)
 - [Model.TflApiPresentationEntitiesStopPointRouteSection](docs/TflApiPresentationEntitiesStopPointRouteSection.md)
 - [Model.TflApiPresentationEntitiesStopPointSequence](docs/TflApiPresentationEntitiesStopPointSequence.md)
 - [Model.TflApiPresentationEntitiesStopPointsResponse](docs/TflApiPresentationEntitiesStopPointsResponse.md)
 - [Model.TflApiPresentationEntitiesStreet](docs/TflApiPresentationEntitiesStreet.md)
 - [Model.TflApiPresentationEntitiesStreetSegment](docs/TflApiPresentationEntitiesStreetSegment.md)
 - [Model.TflApiPresentationEntitiesTimetable](docs/TflApiPresentationEntitiesTimetable.md)
 - [Model.TflApiPresentationEntitiesTimetableResponse](docs/TflApiPresentationEntitiesTimetableResponse.md)
 - [Model.TflApiPresentationEntitiesTimetableRoute](docs/TflApiPresentationEntitiesTimetableRoute.md)
 - [Model.TflApiPresentationEntitiesTimetablesDisambiguation](docs/TflApiPresentationEntitiesTimetablesDisambiguation.md)
 - [Model.TflApiPresentationEntitiesTimetablesDisambiguationOption](docs/TflApiPresentationEntitiesTimetablesDisambiguationOption.md)
 - [Model.TflApiPresentationEntitiesTrainLoading](docs/TflApiPresentationEntitiesTrainLoading.md)
 - [Model.TflApiPresentationEntitiesTwentyFourHourClockTime](docs/TflApiPresentationEntitiesTwentyFourHourClockTime.md)
 - [Model.TflApiPresentationEntitiesValidityPeriod](docs/TflApiPresentationEntitiesValidityPeriod.md)


<a name="documentation-for-authorization"></a>
## Documentation for Authorization

<a name="apiKey"></a>
### apiKey

- **Type**: API key
- **API key parameter name**: app_key
- **Location**: URL query string

<a name="appId"></a>
### appId

- **Type**: API key
- **API key parameter name**: app_id
- **Location**: URL query string
