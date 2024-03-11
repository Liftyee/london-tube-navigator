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
    /// TflApiPresentationEntitiesTrainLoading
    /// </summary>
    [DataContract]
    public partial class TflApiPresentationEntitiesTrainLoading :  IEquatable<TflApiPresentationEntitiesTrainLoading>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TflApiPresentationEntitiesTrainLoading" /> class.
        /// </summary>
        /// <param name="line">The Line Name e.g. \&quot;Victoria\&quot;.</param>
        /// <param name="lineDirection">Direction of the Line e.g. NB, SB, WB etc..</param>
        /// <param name="platformDirection">Direction displayed on the platform e.g. NB, SB, WB etc..</param>
        /// <param name="direction">Direction in regards to Journey Planner i.e. inbound or outbound.</param>
        /// <param name="naptanTo">Naptan of the adjacent station.</param>
        /// <param name="timeSlice">Time in 24hr format with 15 minute intervals e.g. 0500-0515, 0515-0530 etc..</param>
        /// <param name="value">Scale between 1-6,                1 &#x3D; Very quiet, 2 &#x3D; Quiet, 3 &#x3D; Fairly busy, 4 &#x3D; Busy, 5 &#x3D; Very busy, 6 &#x3D; Exceptionally busy.</param>
        public TflApiPresentationEntitiesTrainLoading(string line = default(string), string lineDirection = default(string), string platformDirection = default(string), string direction = default(string), string naptanTo = default(string), string timeSlice = default(string), int? value = default(int?))
        {
            this.Line = line;
            this.LineDirection = lineDirection;
            this.PlatformDirection = platformDirection;
            this.Direction = direction;
            this.NaptanTo = naptanTo;
            this.TimeSlice = timeSlice;
            this.Value = value;
        }
        
        /// <summary>
        /// The Line Name e.g. \&quot;Victoria\&quot;
        /// </summary>
        /// <value>The Line Name e.g. \&quot;Victoria\&quot;</value>
        [DataMember(Name="line", EmitDefaultValue=false)]
        public string Line { get; set; }

        /// <summary>
        /// Direction of the Line e.g. NB, SB, WB etc.
        /// </summary>
        /// <value>Direction of the Line e.g. NB, SB, WB etc.</value>
        [DataMember(Name="lineDirection", EmitDefaultValue=false)]
        public string LineDirection { get; set; }

        /// <summary>
        /// Direction displayed on the platform e.g. NB, SB, WB etc.
        /// </summary>
        /// <value>Direction displayed on the platform e.g. NB, SB, WB etc.</value>
        [DataMember(Name="platformDirection", EmitDefaultValue=false)]
        public string PlatformDirection { get; set; }

        /// <summary>
        /// Direction in regards to Journey Planner i.e. inbound or outbound
        /// </summary>
        /// <value>Direction in regards to Journey Planner i.e. inbound or outbound</value>
        [DataMember(Name="direction", EmitDefaultValue=false)]
        public string Direction { get; set; }

        /// <summary>
        /// Naptan of the adjacent station
        /// </summary>
        /// <value>Naptan of the adjacent station</value>
        [DataMember(Name="naptanTo", EmitDefaultValue=false)]
        public string NaptanTo { get; set; }

        /// <summary>
        /// Time in 24hr format with 15 minute intervals e.g. 0500-0515, 0515-0530 etc.
        /// </summary>
        /// <value>Time in 24hr format with 15 minute intervals e.g. 0500-0515, 0515-0530 etc.</value>
        [DataMember(Name="timeSlice", EmitDefaultValue=false)]
        public string TimeSlice { get; set; }

        /// <summary>
        /// Scale between 1-6,                1 &#x3D; Very quiet, 2 &#x3D; Quiet, 3 &#x3D; Fairly busy, 4 &#x3D; Busy, 5 &#x3D; Very busy, 6 &#x3D; Exceptionally busy
        /// </summary>
        /// <value>Scale between 1-6,                1 &#x3D; Very quiet, 2 &#x3D; Quiet, 3 &#x3D; Fairly busy, 4 &#x3D; Busy, 5 &#x3D; Very busy, 6 &#x3D; Exceptionally busy</value>
        [DataMember(Name="value", EmitDefaultValue=false)]
        public int? Value { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TflApiPresentationEntitiesTrainLoading {\n");
            sb.Append("  Line: ").Append(Line).Append("\n");
            sb.Append("  LineDirection: ").Append(LineDirection).Append("\n");
            sb.Append("  PlatformDirection: ").Append(PlatformDirection).Append("\n");
            sb.Append("  Direction: ").Append(Direction).Append("\n");
            sb.Append("  NaptanTo: ").Append(NaptanTo).Append("\n");
            sb.Append("  TimeSlice: ").Append(TimeSlice).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
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
            return this.Equals(input as TflApiPresentationEntitiesTrainLoading);
        }

        /// <summary>
        /// Returns true if TflApiPresentationEntitiesTrainLoading instances are equal
        /// </summary>
        /// <param name="input">Instance of TflApiPresentationEntitiesTrainLoading to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TflApiPresentationEntitiesTrainLoading input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Line == input.Line ||
                    (this.Line != null &&
                    this.Line.Equals(input.Line))
                ) && 
                (
                    this.LineDirection == input.LineDirection ||
                    (this.LineDirection != null &&
                    this.LineDirection.Equals(input.LineDirection))
                ) && 
                (
                    this.PlatformDirection == input.PlatformDirection ||
                    (this.PlatformDirection != null &&
                    this.PlatformDirection.Equals(input.PlatformDirection))
                ) && 
                (
                    this.Direction == input.Direction ||
                    (this.Direction != null &&
                    this.Direction.Equals(input.Direction))
                ) && 
                (
                    this.NaptanTo == input.NaptanTo ||
                    (this.NaptanTo != null &&
                    this.NaptanTo.Equals(input.NaptanTo))
                ) && 
                (
                    this.TimeSlice == input.TimeSlice ||
                    (this.TimeSlice != null &&
                    this.TimeSlice.Equals(input.TimeSlice))
                ) && 
                (
                    this.Value == input.Value ||
                    (this.Value != null &&
                    this.Value.Equals(input.Value))
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
                if (this.Line != null)
                    hashCode = hashCode * 59 + this.Line.GetHashCode();
                if (this.LineDirection != null)
                    hashCode = hashCode * 59 + this.LineDirection.GetHashCode();
                if (this.PlatformDirection != null)
                    hashCode = hashCode * 59 + this.PlatformDirection.GetHashCode();
                if (this.Direction != null)
                    hashCode = hashCode * 59 + this.Direction.GetHashCode();
                if (this.NaptanTo != null)
                    hashCode = hashCode * 59 + this.NaptanTo.GetHashCode();
                if (this.TimeSlice != null)
                    hashCode = hashCode * 59 + this.TimeSlice.GetHashCode();
                if (this.Value != null)
                    hashCode = hashCode * 59 + this.Value.GetHashCode();
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
