/* 
 * Transport for London Unified API
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: v1
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using SwaggerDateConverter = IO.Swagger.Client.SwaggerDateConverter;

namespace IO.Swagger.Model
{
    /// <summary>
    /// TflApiPresentationEntitiesRouteSectionNaptanEntrySequence
    /// </summary>
    [DataContract]
    public partial class TflApiPresentationEntitiesRouteSectionNaptanEntrySequence :  IEquatable<TflApiPresentationEntitiesRouteSectionNaptanEntrySequence>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TflApiPresentationEntitiesRouteSectionNaptanEntrySequence" /> class.
        /// </summary>
        /// <param name="ordinal">ordinal.</param>
        /// <param name="stopPoint">stopPoint.</param>
        public TflApiPresentationEntitiesRouteSectionNaptanEntrySequence(int? ordinal = default(int?), TflApiPresentationEntitiesStopPoint stopPoint = default(TflApiPresentationEntitiesStopPoint))
        {
            this.Ordinal = ordinal;
            this.StopPoint = stopPoint;
        }
        
        /// <summary>
        /// Gets or Sets Ordinal
        /// </summary>
        [DataMember(Name="ordinal", EmitDefaultValue=false)]
        public int? Ordinal { get; set; }

        /// <summary>
        /// Gets or Sets StopPoint
        /// </summary>
        [DataMember(Name="stopPoint", EmitDefaultValue=false)]
        public TflApiPresentationEntitiesStopPoint StopPoint { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TflApiPresentationEntitiesRouteSectionNaptanEntrySequence {\n");
            sb.Append("  Ordinal: ").Append(Ordinal).Append("\n");
            sb.Append("  StopPoint: ").Append(StopPoint).Append("\n");
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
            return this.Equals(input as TflApiPresentationEntitiesRouteSectionNaptanEntrySequence);
        }

        /// <summary>
        /// Returns true if TflApiPresentationEntitiesRouteSectionNaptanEntrySequence instances are equal
        /// </summary>
        /// <param name="input">Instance of TflApiPresentationEntitiesRouteSectionNaptanEntrySequence to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TflApiPresentationEntitiesRouteSectionNaptanEntrySequence input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Ordinal == input.Ordinal ||
                    (this.Ordinal != null &&
                    this.Ordinal.Equals(input.Ordinal))
                ) && 
                (
                    this.StopPoint == input.StopPoint ||
                    (this.StopPoint != null &&
                    this.StopPoint.Equals(input.StopPoint))
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
                if (this.Ordinal != null)
                    hashCode = hashCode * 59 + this.Ordinal.GetHashCode();
                if (this.StopPoint != null)
                    hashCode = hashCode * 59 + this.StopPoint.GetHashCode();
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
