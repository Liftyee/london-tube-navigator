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
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace IO.Swagger.Model
{
    /// <summary>
    /// TflApiPresentationEntitiesStopPointSequence
    /// </summary>
    [DataContract]
    public partial class TflApiPresentationEntitiesStopPointSequence :  IEquatable<TflApiPresentationEntitiesStopPointSequence>, IValidatableObject
    {
        /// <summary>
        /// Defines ServiceType
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ServiceTypeEnum
        {
            
            /// <summary>
            /// Enum Regular for value: Regular
            /// </summary>
            [EnumMember(Value = "Regular")]
            Regular = 1,
            
            /// <summary>
            /// Enum Night for value: Night
            /// </summary>
            [EnumMember(Value = "Night")]
            Night = 2
        }

        /// <summary>
        /// Gets or Sets ServiceType
        /// </summary>
        [DataMember(Name="serviceType", EmitDefaultValue=false)]
        public ServiceTypeEnum? ServiceType { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="TflApiPresentationEntitiesStopPointSequence" /> class.
        /// </summary>
        /// <param name="lineId">lineId.</param>
        /// <param name="lineName">lineName.</param>
        /// <param name="direction">direction.</param>
        /// <param name="branchId">The id of this branch..</param>
        /// <param name="nextBranchIds">The ids of the next branch(es) in the sequence. Note that the next and previous branch id can be              identical in the case of a looped route e.g. the Circle line..</param>
        /// <param name="prevBranchIds">The ids of the previous branch(es) in the sequence. Note that the next and previous branch id can be              identical in the case of a looped route e.g. the Circle line..</param>
        /// <param name="stopPoint">stopPoint.</param>
        /// <param name="serviceType">serviceType.</param>
        public TflApiPresentationEntitiesStopPointSequence(string lineId = default(string), string lineName = default(string), string direction = default(string), int? branchId = default(int?), List<int?> nextBranchIds = default(List<int?>), List<int?> prevBranchIds = default(List<int?>), List<TflApiPresentationEntitiesMatchedStop> stopPoint = default(List<TflApiPresentationEntitiesMatchedStop>), ServiceTypeEnum? serviceType = default(ServiceTypeEnum?))
        {
            this.LineId = lineId;
            this.LineName = lineName;
            this.Direction = direction;
            this.BranchId = branchId;
            this.NextBranchIds = nextBranchIds;
            this.PrevBranchIds = prevBranchIds;
            this.StopPoint = stopPoint;
            this.ServiceType = serviceType;
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
        /// The id of this branch.
        /// </summary>
        /// <value>The id of this branch.</value>
        [DataMember(Name="branchId", EmitDefaultValue=false)]
        public int? BranchId { get; set; }

        /// <summary>
        /// The ids of the next branch(es) in the sequence. Note that the next and previous branch id can be              identical in the case of a looped route e.g. the Circle line.
        /// </summary>
        /// <value>The ids of the next branch(es) in the sequence. Note that the next and previous branch id can be              identical in the case of a looped route e.g. the Circle line.</value>
        [DataMember(Name="nextBranchIds", EmitDefaultValue=false)]
        public List<int?> NextBranchIds { get; set; }

        /// <summary>
        /// The ids of the previous branch(es) in the sequence. Note that the next and previous branch id can be              identical in the case of a looped route e.g. the Circle line.
        /// </summary>
        /// <value>The ids of the previous branch(es) in the sequence. Note that the next and previous branch id can be              identical in the case of a looped route e.g. the Circle line.</value>
        [DataMember(Name="prevBranchIds", EmitDefaultValue=false)]
        public List<int?> PrevBranchIds { get; set; }

        /// <summary>
        /// Gets or Sets StopPoint
        /// </summary>
        [DataMember(Name="stopPoint", EmitDefaultValue=false)]
        public List<TflApiPresentationEntitiesMatchedStop> StopPoint { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TflApiPresentationEntitiesStopPointSequence {\n");
            sb.Append("  LineId: ").Append(LineId).Append("\n");
            sb.Append("  LineName: ").Append(LineName).Append("\n");
            sb.Append("  Direction: ").Append(Direction).Append("\n");
            sb.Append("  BranchId: ").Append(BranchId).Append("\n");
            sb.Append("  NextBranchIds: ").Append(NextBranchIds).Append("\n");
            sb.Append("  PrevBranchIds: ").Append(PrevBranchIds).Append("\n");
            sb.Append("  StopPoint: ").Append(StopPoint).Append("\n");
            sb.Append("  ServiceType: ").Append(ServiceType).Append("\n");
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
            return this.Equals(input as TflApiPresentationEntitiesStopPointSequence);
        }

        /// <summary>
        /// Returns true if TflApiPresentationEntitiesStopPointSequence instances are equal
        /// </summary>
        /// <param name="input">Instance of TflApiPresentationEntitiesStopPointSequence to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TflApiPresentationEntitiesStopPointSequence input)
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
                    this.BranchId == input.BranchId ||
                    (this.BranchId != null &&
                    this.BranchId.Equals(input.BranchId))
                ) && 
                (
                    this.NextBranchIds == input.NextBranchIds ||
                    this.NextBranchIds != null &&
                    this.NextBranchIds.SequenceEqual(input.NextBranchIds)
                ) && 
                (
                    this.PrevBranchIds == input.PrevBranchIds ||
                    this.PrevBranchIds != null &&
                    this.PrevBranchIds.SequenceEqual(input.PrevBranchIds)
                ) && 
                (
                    this.StopPoint == input.StopPoint ||
                    this.StopPoint != null &&
                    this.StopPoint.SequenceEqual(input.StopPoint)
                ) && 
                (
                    this.ServiceType == input.ServiceType ||
                    (this.ServiceType != null &&
                    this.ServiceType.Equals(input.ServiceType))
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
                if (this.BranchId != null)
                    hashCode = hashCode * 59 + this.BranchId.GetHashCode();
                if (this.NextBranchIds != null)
                    hashCode = hashCode * 59 + this.NextBranchIds.GetHashCode();
                if (this.PrevBranchIds != null)
                    hashCode = hashCode * 59 + this.PrevBranchIds.GetHashCode();
                if (this.StopPoint != null)
                    hashCode = hashCode * 59 + this.StopPoint.GetHashCode();
                if (this.ServiceType != null)
                    hashCode = hashCode * 59 + this.ServiceType.GetHashCode();
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
