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
    /// TflApiPresentationEntitiesRouteSequence
    /// </summary>
    [DataContract]
    public partial class TflApiPresentationEntitiesRouteSequence :  IEquatable<TflApiPresentationEntitiesRouteSequence>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TflApiPresentationEntitiesRouteSequence" /> class.
        /// </summary>
        /// <param name="lineId">lineId.</param>
        /// <param name="lineName">lineName.</param>
        /// <param name="direction">direction.</param>
        /// <param name="isOutboundOnly">isOutboundOnly.</param>
        /// <param name="mode">mode.</param>
        /// <param name="lineStrings">lineStrings.</param>
        /// <param name="stations">stations.</param>
        /// <param name="stopPointSequences">stopPointSequences.</param>
        /// <param name="orderedLineRoutes">orderedLineRoutes.</param>
        public TflApiPresentationEntitiesRouteSequence(string lineId = default(string), string lineName = default(string), string direction = default(string), bool? isOutboundOnly = default(bool?), string mode = default(string), List<string> lineStrings = default(List<string>), List<TflApiPresentationEntitiesMatchedStop> stations = default(List<TflApiPresentationEntitiesMatchedStop>), List<TflApiPresentationEntitiesStopPointSequence> stopPointSequences = default(List<TflApiPresentationEntitiesStopPointSequence>), List<TflApiPresentationEntitiesOrderedRoute> orderedLineRoutes = default(List<TflApiPresentationEntitiesOrderedRoute>))
        {
            this.LineId = lineId;
            this.LineName = lineName;
            this.Direction = direction;
            this.IsOutboundOnly = isOutboundOnly;
            this.Mode = mode;
            this.LineStrings = lineStrings;
            this.Stations = stations;
            this.StopPointSequences = stopPointSequences;
            this.OrderedLineRoutes = orderedLineRoutes;
        }
        
        /// <summary>
        /// Gets or Sets LineId
        /// </summary>
        [DataMember(Name="lineId", EmitDefaultValue=false)]
        public string LineId { get; set; }

        /// <summary>
        /// Gets or Sets LineName
        /// </summary>
        [DataMember(Name="lineName", EmitDefaultValue=false)]
        public string LineName { get; set; }

        /// <summary>
        /// Gets or Sets Direction
        /// </summary>
        [DataMember(Name="direction", EmitDefaultValue=false)]
        public string Direction { get; set; }

        /// <summary>
        /// Gets or Sets IsOutboundOnly
        /// </summary>
        [DataMember(Name="isOutboundOnly", EmitDefaultValue=false)]
        public bool? IsOutboundOnly { get; set; }

        /// <summary>
        /// Gets or Sets Mode
        /// </summary>
        [DataMember(Name="mode", EmitDefaultValue=false)]
        public string Mode { get; set; }

        /// <summary>
        /// Gets or Sets LineStrings
        /// </summary>
        [DataMember(Name="lineStrings", EmitDefaultValue=false)]
        public List<string> LineStrings { get; set; }

        /// <summary>
        /// Gets or Sets Stations
        /// </summary>
        [DataMember(Name="stations", EmitDefaultValue=false)]
        public List<TflApiPresentationEntitiesMatchedStop> Stations { get; set; }

        /// <summary>
        /// Gets or Sets StopPointSequences
        /// </summary>
        [DataMember(Name="stopPointSequences", EmitDefaultValue=false)]
        public List<TflApiPresentationEntitiesStopPointSequence> StopPointSequences { get; set; }

        /// <summary>
        /// Gets or Sets OrderedLineRoutes
        /// </summary>
        [DataMember(Name="orderedLineRoutes", EmitDefaultValue=false)]
        public List<TflApiPresentationEntitiesOrderedRoute> OrderedLineRoutes { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TflApiPresentationEntitiesRouteSequence {\n");
            sb.Append("  LineId: ").Append(LineId).Append("\n");
            sb.Append("  LineName: ").Append(LineName).Append("\n");
            sb.Append("  Direction: ").Append(Direction).Append("\n");
            sb.Append("  IsOutboundOnly: ").Append(IsOutboundOnly).Append("\n");
            sb.Append("  Mode: ").Append(Mode).Append("\n");
            sb.Append("  LineStrings: ").Append(LineStrings).Append("\n");
            sb.Append("  Stations: ").Append(Stations).Append("\n");
            sb.Append("  StopPointSequences: ").Append(StopPointSequences).Append("\n");
            sb.Append("  OrderedLineRoutes: ").Append(OrderedLineRoutes).Append("\n");
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
            return this.Equals(input as TflApiPresentationEntitiesRouteSequence);
        }

        /// <summary>
        /// Returns true if TflApiPresentationEntitiesRouteSequence instances are equal
        /// </summary>
        /// <param name="input">Instance of TflApiPresentationEntitiesRouteSequence to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TflApiPresentationEntitiesRouteSequence input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.LineId == input.LineId ||
                    (this.LineId != null &&
                    this.LineId.Equals(input.LineId))
                ) && 
                (
                    this.LineName == input.LineName ||
                    (this.LineName != null &&
                    this.LineName.Equals(input.LineName))
                ) && 
                (
                    this.Direction == input.Direction ||
                    (this.Direction != null &&
                    this.Direction.Equals(input.Direction))
                ) && 
                (
                    this.IsOutboundOnly == input.IsOutboundOnly ||
                    (this.IsOutboundOnly != null &&
                    this.IsOutboundOnly.Equals(input.IsOutboundOnly))
                ) && 
                (
                    this.Mode == input.Mode ||
                    (this.Mode != null &&
                    this.Mode.Equals(input.Mode))
                ) && 
                (
                    this.LineStrings == input.LineStrings ||
                    this.LineStrings != null &&
                    this.LineStrings.SequenceEqual(input.LineStrings)
                ) && 
                (
                    this.Stations == input.Stations ||
                    this.Stations != null &&
                    this.Stations.SequenceEqual(input.Stations)
                ) && 
                (
                    this.StopPointSequences == input.StopPointSequences ||
                    this.StopPointSequences != null &&
                    this.StopPointSequences.SequenceEqual(input.StopPointSequences)
                ) && 
                (
                    this.OrderedLineRoutes == input.OrderedLineRoutes ||
                    this.OrderedLineRoutes != null &&
                    this.OrderedLineRoutes.SequenceEqual(input.OrderedLineRoutes)
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
                if (this.LineId != null)
                    hashCode = hashCode * 59 + this.LineId.GetHashCode();
                if (this.LineName != null)
                    hashCode = hashCode * 59 + this.LineName.GetHashCode();
                if (this.Direction != null)
                    hashCode = hashCode * 59 + this.Direction.GetHashCode();
                if (this.IsOutboundOnly != null)
                    hashCode = hashCode * 59 + this.IsOutboundOnly.GetHashCode();
                if (this.Mode != null)
                    hashCode = hashCode * 59 + this.Mode.GetHashCode();
                if (this.LineStrings != null)
                    hashCode = hashCode * 59 + this.LineStrings.GetHashCode();
                if (this.Stations != null)
                    hashCode = hashCode * 59 + this.Stations.GetHashCode();
                if (this.StopPointSequences != null)
                    hashCode = hashCode * 59 + this.StopPointSequences.GetHashCode();
                if (this.OrderedLineRoutes != null)
                    hashCode = hashCode * 59 + this.OrderedLineRoutes.GetHashCode();
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
