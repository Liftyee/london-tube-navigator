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
    /// TflApiPresentationEntitiesLineGroup
    /// </summary>
    [DataContract]
    public partial class TflApiPresentationEntitiesLineGroup :  IEquatable<TflApiPresentationEntitiesLineGroup>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TflApiPresentationEntitiesLineGroup" /> class.
        /// </summary>
        /// <param name="naptanIdReference">naptanIdReference.</param>
        /// <param name="stationAtcoCode">stationAtcoCode.</param>
        /// <param name="lineIdentifier">lineIdentifier.</param>
        public TflApiPresentationEntitiesLineGroup(string naptanIdReference = default(string), string stationAtcoCode = default(string), List<string> lineIdentifier = default(List<string>))
        {
            this.NaptanIdReference = naptanIdReference;
            this.StationAtcoCode = stationAtcoCode;
            this.LineIdentifier = lineIdentifier;
        }
        
        /// <summary>
        /// Gets or Sets NaptanIdReference
        /// </summary>
        [DataMember(Name="naptanIdReference", EmitDefaultValue=false)]
        public string NaptanIdReference { get; set; }

        /// <summary>
        /// Gets or Sets StationAtcoCode
        /// </summary>
        [DataMember(Name="stationAtcoCode", EmitDefaultValue=false)]
        public string StationAtcoCode { get; set; }

        /// <summary>
        /// Gets or Sets LineIdentifier
        /// </summary>
        [DataMember(Name="lineIdentifier", EmitDefaultValue=false)]
        public List<string> LineIdentifier { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TflApiPresentationEntitiesLineGroup {\n");
            sb.Append("  NaptanIdReference: ").Append(NaptanIdReference).Append("\n");
            sb.Append("  StationAtcoCode: ").Append(StationAtcoCode).Append("\n");
            sb.Append("  LineIdentifier: ").Append(LineIdentifier).Append("\n");
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
            return this.Equals(input as TflApiPresentationEntitiesLineGroup);
        }

        /// <summary>
        /// Returns true if TflApiPresentationEntitiesLineGroup instances are equal
        /// </summary>
        /// <param name="input">Instance of TflApiPresentationEntitiesLineGroup to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TflApiPresentationEntitiesLineGroup input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.NaptanIdReference == input.NaptanIdReference ||
                    (this.NaptanIdReference != null &&
                    this.NaptanIdReference.Equals(input.NaptanIdReference))
                ) && 
                (
                    this.StationAtcoCode == input.StationAtcoCode ||
                    (this.StationAtcoCode != null &&
                    this.StationAtcoCode.Equals(input.StationAtcoCode))
                ) && 
                (
                    this.LineIdentifier == input.LineIdentifier ||
                    this.LineIdentifier != null &&
                    this.LineIdentifier.SequenceEqual(input.LineIdentifier)
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
                if (this.NaptanIdReference != null)
                    hashCode = hashCode * 59 + this.NaptanIdReference.GetHashCode();
                if (this.StationAtcoCode != null)
                    hashCode = hashCode * 59 + this.StationAtcoCode.GetHashCode();
                if (this.LineIdentifier != null)
                    hashCode = hashCode * 59 + this.LineIdentifier.GetHashCode();
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