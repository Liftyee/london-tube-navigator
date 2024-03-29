/* 
 * Transport for London Unified API
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: v1
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace IO.Swagger.Model
{
    /// <summary>
    /// TflApiPresentationEntitiesStopPoint
    /// </summary>
    [DataContract]
    public partial class TflApiPresentationEntitiesStopPoint :  IEquatable<TflApiPresentationEntitiesStopPoint>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TflApiPresentationEntitiesStopPoint" /> class.
        /// </summary>
        /// <param name="naptanId">naptanId.</param>
        /// <param name="platformName">platformName.</param>
        /// <param name="indicator">The indicator of the stop point e.g. \&quot;Stop K\&quot;.</param>
        /// <param name="stopLetter">The stop letter, if it could be cleansed from the Indicator e.g. \&quot;K\&quot;.</param>
        /// <param name="modes">modes.</param>
        /// <param name="icsCode">icsCode.</param>
        /// <param name="smsCode">smsCode.</param>
        /// <param name="stopType">stopType.</param>
        /// <param name="stationNaptan">stationNaptan.</param>
        /// <param name="accessibilitySummary">accessibilitySummary.</param>
        /// <param name="hubNaptanCode">hubNaptanCode.</param>
        /// <param name="lines">lines.</param>
        /// <param name="lineGroup">lineGroup.</param>
        /// <param name="lineModeGroups">lineModeGroups.</param>
        /// <param name="fullName">fullName.</param>
        /// <param name="naptanMode">naptanMode.</param>
        /// <param name="status">status.</param>
        /// <param name="individualStopId">individualStopId.</param>
        /// <param name="id">A unique identifier..</param>
        /// <param name="url">The unique location of this resource..</param>
        /// <param name="commonName">A human readable name..</param>
        /// <param name="distance">The distance of the place from its search point, if this is the result              of a geographical search, otherwise zero..</param>
        /// <param name="placeType">The type of Place. See /Place/Meta/placeTypes for possible values..</param>
        /// <param name="additionalProperties">A bag of additional key/value pairs with extra information about this place..</param>
        /// <param name="children">children.</param>
        /// <param name="childrenUrls">childrenUrls.</param>
        /// <param name="lat">WGS84 latitude of the location..</param>
        /// <param name="lon">WGS84 longitude of the location..</param>
        public TflApiPresentationEntitiesStopPoint(string naptanId = default(string), string platformName = default(string), string indicator = default(string), string stopLetter = default(string), List<string> modes = default(List<string>), string icsCode = default(string), string smsCode = default(string), string stopType = default(string), string stationNaptan = default(string), string accessibilitySummary = default(string), string hubNaptanCode = default(string), List<TflApiPresentationEntitiesIdentifier> lines = default(List<TflApiPresentationEntitiesIdentifier>), List<TflApiPresentationEntitiesLineGroup> lineGroup = default(List<TflApiPresentationEntitiesLineGroup>), List<TflApiPresentationEntitiesLineModeGroup> lineModeGroups = default(List<TflApiPresentationEntitiesLineModeGroup>), string fullName = default(string), string naptanMode = default(string), bool? status = default(bool?), string individualStopId = default(string), string id = default(string), string url = default(string), string commonName = default(string), double? distance = default(double?), string placeType = default(string), List<TflApiPresentationEntitiesAdditionalProperties> additionalProperties = default(List<TflApiPresentationEntitiesAdditionalProperties>), List<TflApiPresentationEntitiesPlace> children = default(List<TflApiPresentationEntitiesPlace>), List<string> childrenUrls = default(List<string>), double? lat = default(double?), double? lon = default(double?))
        {
            this.NaptanId = naptanId;
            this.PlatformName = platformName;
            this.Indicator = indicator;
            this.StopLetter = stopLetter;
            this.Modes = modes;
            this.IcsCode = icsCode;
            this.SmsCode = smsCode;
            this.StopType = stopType;
            this.StationNaptan = stationNaptan;
            this.AccessibilitySummary = accessibilitySummary;
            this.HubNaptanCode = hubNaptanCode;
            this.Lines = lines;
            this.LineGroup = lineGroup;
            this.LineModeGroups = lineModeGroups;
            this.FullName = fullName;
            this.NaptanMode = naptanMode;
            this.Status = status;
            this.IndividualStopId = individualStopId;
            this.Id = id;
            this.Url = url;
            this.CommonName = commonName;
            this.Distance = distance;
            this.PlaceType = placeType;
            this.AdditionalProperties = additionalProperties;
            this.Children = children;
            this.ChildrenUrls = childrenUrls;
            this.Lat = lat;
            this.Lon = lon;
        }
        
        /// <summary>
        /// Gets or Sets NaptanId
        /// </summary>
        [DataMember(Name="naptanId", EmitDefaultValue=false)]
        public string NaptanId { get; set; }

        /// <summary>
        /// Gets or Sets PlatformName
        /// </summary>
        [DataMember(Name="platformName", EmitDefaultValue=false)]
        public string PlatformName { get; set; }

        /// <summary>
        /// The indicator of the stop point e.g. \&quot;Stop K\&quot;
        /// </summary>
        /// <value>The indicator of the stop point e.g. \&quot;Stop K\&quot;</value>
        [DataMember(Name="indicator", EmitDefaultValue=false)]
        public string Indicator { get; set; }

        /// <summary>
        /// The stop letter, if it could be cleansed from the Indicator e.g. \&quot;K\&quot;
        /// </summary>
        /// <value>The stop letter, if it could be cleansed from the Indicator e.g. \&quot;K\&quot;</value>
        [DataMember(Name="stopLetter", EmitDefaultValue=false)]
        public string StopLetter { get; set; }

        /// <summary>
        /// Gets or Sets Modes
        /// </summary>
        [DataMember(Name="modes", EmitDefaultValue=false)]
        public List<string> Modes { get; set; }

        /// <summary>
        /// Gets or Sets IcsCode
        /// </summary>
        [DataMember(Name="icsCode", EmitDefaultValue=false)]
        public string IcsCode { get; set; }

        /// <summary>
        /// Gets or Sets SmsCode
        /// </summary>
        [DataMember(Name="smsCode", EmitDefaultValue=false)]
        public string SmsCode { get; set; }

        /// <summary>
        /// Gets or Sets StopType
        /// </summary>
        [DataMember(Name="stopType", EmitDefaultValue=false)]
        public string StopType { get; set; }

        /// <summary>
        /// Gets or Sets StationNaptan
        /// </summary>
        [DataMember(Name="stationNaptan", EmitDefaultValue=false)]
        public string StationNaptan { get; set; }

        /// <summary>
        /// Gets or Sets AccessibilitySummary
        /// </summary>
        [DataMember(Name="accessibilitySummary", EmitDefaultValue=false)]
        public string AccessibilitySummary { get; set; }

        /// <summary>
        /// Gets or Sets HubNaptanCode
        /// </summary>
        [DataMember(Name="hubNaptanCode", EmitDefaultValue=false)]
        public string HubNaptanCode { get; set; }

        /// <summary>
        /// Gets or Sets Lines
        /// </summary>
        [DataMember(Name="lines", EmitDefaultValue=false)]
        public List<TflApiPresentationEntitiesIdentifier> Lines { get; set; }

        /// <summary>
        /// Gets or Sets LineGroup
        /// </summary>
        [DataMember(Name="lineGroup", EmitDefaultValue=false)]
        public List<TflApiPresentationEntitiesLineGroup> LineGroup { get; set; }

        /// <summary>
        /// Gets or Sets LineModeGroups
        /// </summary>
        [DataMember(Name="lineModeGroups", EmitDefaultValue=false)]
        public List<TflApiPresentationEntitiesLineModeGroup> LineModeGroups { get; set; }

        /// <summary>
        /// Gets or Sets FullName
        /// </summary>
        [DataMember(Name="fullName", EmitDefaultValue=false)]
        public string FullName { get; set; }

        /// <summary>
        /// Gets or Sets NaptanMode
        /// </summary>
        [DataMember(Name="naptanMode", EmitDefaultValue=false)]
        public string NaptanMode { get; set; }

        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        [DataMember(Name="status", EmitDefaultValue=false)]
        public bool? Status { get; set; }

        /// <summary>
        /// Gets or Sets IndividualStopId
        /// </summary>
        [DataMember(Name="individualStopId", EmitDefaultValue=false)]
        public string IndividualStopId { get; set; }

        /// <summary>
        /// A unique identifier.
        /// </summary>
        /// <value>A unique identifier.</value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }

        /// <summary>
        /// The unique location of this resource.
        /// </summary>
        /// <value>The unique location of this resource.</value>
        [DataMember(Name="url", EmitDefaultValue=false)]
        public string Url { get; set; }

        /// <summary>
        /// A human readable name.
        /// </summary>
        /// <value>A human readable name.</value>
        [DataMember(Name="commonName", EmitDefaultValue=false)]
        public string CommonName { get; set; }

        /// <summary>
        /// The distance of the place from its search point, if this is the result              of a geographical search, otherwise zero.
        /// </summary>
        /// <value>The distance of the place from its search point, if this is the result              of a geographical search, otherwise zero.</value>
        [DataMember(Name="distance", EmitDefaultValue=false)]
        public double? Distance { get; set; }

        /// <summary>
        /// The type of Place. See /Place/Meta/placeTypes for possible values.
        /// </summary>
        /// <value>The type of Place. See /Place/Meta/placeTypes for possible values.</value>
        [DataMember(Name="placeType", EmitDefaultValue=false)]
        public string PlaceType { get; set; }

        /// <summary>
        /// A bag of additional key/value pairs with extra information about this place.
        /// </summary>
        /// <value>A bag of additional key/value pairs with extra information about this place.</value>
        [DataMember(Name="additionalProperties", EmitDefaultValue=false)]
        public List<TflApiPresentationEntitiesAdditionalProperties> AdditionalProperties { get; set; }

        /// <summary>
        /// Gets or Sets Children
        /// </summary>
        [DataMember(Name="children", EmitDefaultValue=false)]
        public List<TflApiPresentationEntitiesPlace> Children { get; set; }

        /// <summary>
        /// Gets or Sets ChildrenUrls
        /// </summary>
        [DataMember(Name="childrenUrls", EmitDefaultValue=false)]
        public List<string> ChildrenUrls { get; set; }

        /// <summary>
        /// WGS84 latitude of the location.
        /// </summary>
        /// <value>WGS84 latitude of the location.</value>
        [DataMember(Name="lat", EmitDefaultValue=false)]
        public double? Lat { get; set; }

        /// <summary>
        /// WGS84 longitude of the location.
        /// </summary>
        /// <value>WGS84 longitude of the location.</value>
        [DataMember(Name="lon", EmitDefaultValue=false)]
        public double? Lon { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TflApiPresentationEntitiesStopPoint {\n");
            sb.Append("  NaptanId: ").Append(NaptanId).Append("\n");
            sb.Append("  PlatformName: ").Append(PlatformName).Append("\n");
            sb.Append("  Indicator: ").Append(Indicator).Append("\n");
            sb.Append("  StopLetter: ").Append(StopLetter).Append("\n");
            sb.Append("  Modes: ").Append(Modes).Append("\n");
            sb.Append("  IcsCode: ").Append(IcsCode).Append("\n");
            sb.Append("  SmsCode: ").Append(SmsCode).Append("\n");
            sb.Append("  StopType: ").Append(StopType).Append("\n");
            sb.Append("  StationNaptan: ").Append(StationNaptan).Append("\n");
            sb.Append("  AccessibilitySummary: ").Append(AccessibilitySummary).Append("\n");
            sb.Append("  HubNaptanCode: ").Append(HubNaptanCode).Append("\n");
            sb.Append("  Lines: ").Append(Lines).Append("\n");
            sb.Append("  LineGroup: ").Append(LineGroup).Append("\n");
            sb.Append("  LineModeGroups: ").Append(LineModeGroups).Append("\n");
            sb.Append("  FullName: ").Append(FullName).Append("\n");
            sb.Append("  NaptanMode: ").Append(NaptanMode).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  IndividualStopId: ").Append(IndividualStopId).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Url: ").Append(Url).Append("\n");
            sb.Append("  CommonName: ").Append(CommonName).Append("\n");
            sb.Append("  Distance: ").Append(Distance).Append("\n");
            sb.Append("  PlaceType: ").Append(PlaceType).Append("\n");
            sb.Append("  AdditionalProperties: ").Append(AdditionalProperties).Append("\n");
            sb.Append("  Children: ").Append(Children).Append("\n");
            sb.Append("  ChildrenUrls: ").Append(ChildrenUrls).Append("\n");
            sb.Append("  Lat: ").Append(Lat).Append("\n");
            sb.Append("  Lon: ").Append(Lon).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as TflApiPresentationEntitiesStopPoint);
        }

        /// <summary>
        /// Returns true if TflApiPresentationEntitiesStopPoint instances are equal
        /// </summary>
        /// <param name="input">Instance of TflApiPresentationEntitiesStopPoint to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TflApiPresentationEntitiesStopPoint input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.NaptanId == input.NaptanId ||
                    (this.NaptanId != null &&
                    this.NaptanId.Equals(input.NaptanId))
                ) && 
                (
                    this.PlatformName == input.PlatformName ||
                    (this.PlatformName != null &&
                    this.PlatformName.Equals(input.PlatformName))
                ) && 
                (
                    this.Indicator == input.Indicator ||
                    (this.Indicator != null &&
                    this.Indicator.Equals(input.Indicator))
                ) && 
                (
                    this.StopLetter == input.StopLetter ||
                    (this.StopLetter != null &&
                    this.StopLetter.Equals(input.StopLetter))
                ) && 
                (
                    this.Modes == input.Modes ||
                    this.Modes != null &&
                    this.Modes.SequenceEqual(input.Modes)
                ) && 
                (
                    this.IcsCode == input.IcsCode ||
                    (this.IcsCode != null &&
                    this.IcsCode.Equals(input.IcsCode))
                ) && 
                (
                    this.SmsCode == input.SmsCode ||
                    (this.SmsCode != null &&
                    this.SmsCode.Equals(input.SmsCode))
                ) && 
                (
                    this.StopType == input.StopType ||
                    (this.StopType != null &&
                    this.StopType.Equals(input.StopType))
                ) && 
                (
                    this.StationNaptan == input.StationNaptan ||
                    (this.StationNaptan != null &&
                    this.StationNaptan.Equals(input.StationNaptan))
                ) && 
                (
                    this.AccessibilitySummary == input.AccessibilitySummary ||
                    (this.AccessibilitySummary != null &&
                    this.AccessibilitySummary.Equals(input.AccessibilitySummary))
                ) && 
                (
                    this.HubNaptanCode == input.HubNaptanCode ||
                    (this.HubNaptanCode != null &&
                    this.HubNaptanCode.Equals(input.HubNaptanCode))
                ) && 
                (
                    this.Lines == input.Lines ||
                    this.Lines != null &&
                    this.Lines.SequenceEqual(input.Lines)
                ) && 
                (
                    this.LineGroup == input.LineGroup ||
                    this.LineGroup != null &&
                    this.LineGroup.SequenceEqual(input.LineGroup)
                ) && 
                (
                    this.LineModeGroups == input.LineModeGroups ||
                    this.LineModeGroups != null &&
                    this.LineModeGroups.SequenceEqual(input.LineModeGroups)
                ) && 
                (
                    this.FullName == input.FullName ||
                    (this.FullName != null &&
                    this.FullName.Equals(input.FullName))
                ) && 
                (
                    this.NaptanMode == input.NaptanMode ||
                    (this.NaptanMode != null &&
                    this.NaptanMode.Equals(input.NaptanMode))
                ) && 
                (
                    this.Status == input.Status ||
                    (this.Status != null &&
                    this.Status.Equals(input.Status))
                ) && 
                (
                    this.IndividualStopId == input.IndividualStopId ||
                    (this.IndividualStopId != null &&
                    this.IndividualStopId.Equals(input.IndividualStopId))
                ) && 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.Url == input.Url ||
                    (this.Url != null &&
                    this.Url.Equals(input.Url))
                ) && 
                (
                    this.CommonName == input.CommonName ||
                    (this.CommonName != null &&
                    this.CommonName.Equals(input.CommonName))
                ) && 
                (
                    this.Distance == input.Distance ||
                    (this.Distance != null &&
                    this.Distance.Equals(input.Distance))
                ) && 
                (
                    this.PlaceType == input.PlaceType ||
                    (this.PlaceType != null &&
                    this.PlaceType.Equals(input.PlaceType))
                ) && 
                (
                    this.AdditionalProperties == input.AdditionalProperties ||
                    this.AdditionalProperties != null &&
                    this.AdditionalProperties.SequenceEqual(input.AdditionalProperties)
                ) && 
                (
                    this.Children == input.Children ||
                    this.Children != null &&
                    this.Children.SequenceEqual(input.Children)
                ) && 
                (
                    this.ChildrenUrls == input.ChildrenUrls ||
                    this.ChildrenUrls != null &&
                    this.ChildrenUrls.SequenceEqual(input.ChildrenUrls)
                ) && 
                (
                    this.Lat == input.Lat ||
                    (this.Lat != null &&
                    this.Lat.Equals(input.Lat))
                ) && 
                (
                    this.Lon == input.Lon ||
                    (this.Lon != null &&
                    this.Lon.Equals(input.Lon))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.NaptanId != null)
                    hashCode = hashCode * 59 + this.NaptanId.GetHashCode();
                if (this.PlatformName != null)
                    hashCode = hashCode * 59 + this.PlatformName.GetHashCode();
                if (this.Indicator != null)
                    hashCode = hashCode * 59 + this.Indicator.GetHashCode();
                if (this.StopLetter != null)
                    hashCode = hashCode * 59 + this.StopLetter.GetHashCode();
                if (this.Modes != null)
                    hashCode = hashCode * 59 + this.Modes.GetHashCode();
                if (this.IcsCode != null)
                    hashCode = hashCode * 59 + this.IcsCode.GetHashCode();
                if (this.SmsCode != null)
                    hashCode = hashCode * 59 + this.SmsCode.GetHashCode();
                if (this.StopType != null)
                    hashCode = hashCode * 59 + this.StopType.GetHashCode();
                if (this.StationNaptan != null)
                    hashCode = hashCode * 59 + this.StationNaptan.GetHashCode();
                if (this.AccessibilitySummary != null)
                    hashCode = hashCode * 59 + this.AccessibilitySummary.GetHashCode();
                if (this.HubNaptanCode != null)
                    hashCode = hashCode * 59 + this.HubNaptanCode.GetHashCode();
                if (this.Lines != null)
                    hashCode = hashCode * 59 + this.Lines.GetHashCode();
                if (this.LineGroup != null)
                    hashCode = hashCode * 59 + this.LineGroup.GetHashCode();
                if (this.LineModeGroups != null)
                    hashCode = hashCode * 59 + this.LineModeGroups.GetHashCode();
                if (this.FullName != null)
                    hashCode = hashCode * 59 + this.FullName.GetHashCode();
                if (this.NaptanMode != null)
                    hashCode = hashCode * 59 + this.NaptanMode.GetHashCode();
                if (this.Status != null)
                    hashCode = hashCode * 59 + this.Status.GetHashCode();
                if (this.IndividualStopId != null)
                    hashCode = hashCode * 59 + this.IndividualStopId.GetHashCode();
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this.Url != null)
                    hashCode = hashCode * 59 + this.Url.GetHashCode();
                if (this.CommonName != null)
                    hashCode = hashCode * 59 + this.CommonName.GetHashCode();
                if (this.Distance != null)
                    hashCode = hashCode * 59 + this.Distance.GetHashCode();
                if (this.PlaceType != null)
                    hashCode = hashCode * 59 + this.PlaceType.GetHashCode();
                if (this.AdditionalProperties != null)
                    hashCode = hashCode * 59 + this.AdditionalProperties.GetHashCode();
                if (this.Children != null)
                    hashCode = hashCode * 59 + this.Children.GetHashCode();
                if (this.ChildrenUrls != null)
                    hashCode = hashCode * 59 + this.ChildrenUrls.GetHashCode();
                if (this.Lat != null)
                    hashCode = hashCode * 59 + this.Lat.GetHashCode();
                if (this.Lon != null)
                    hashCode = hashCode * 59 + this.Lon.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
