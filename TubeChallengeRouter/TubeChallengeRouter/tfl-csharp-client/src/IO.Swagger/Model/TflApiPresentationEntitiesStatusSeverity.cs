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
    /// TflApiPresentationEntitiesStatusSeverity
    /// </summary>
    [DataContract]
    public partial class TflApiPresentationEntitiesStatusSeverity :  IEquatable<TflApiPresentationEntitiesStatusSeverity>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TflApiPresentationEntitiesStatusSeverity" /> class.
        /// </summary>
        /// <param name="modeName">modeName.</param>
        /// <param name="severityLevel">severityLevel.</param>
        /// <param name="description">description.</param>
        public TflApiPresentationEntitiesStatusSeverity(string modeName = default(string), int? severityLevel = default(int?), string description = default(string))
        {
            this.ModeName = modeName;
            this.SeverityLevel = severityLevel;
            this.Description = description;
        }
        
        /// <summary>
        /// Gets or Sets ModeName
        /// </summary>
        [DataMember(Name="modeName", EmitDefaultValue=false)]
        public string ModeName { get; set; }

        /// <summary>
        /// Gets or Sets SeverityLevel
        /// </summary>
        [DataMember(Name="severityLevel", EmitDefaultValue=false)]
        public int? SeverityLevel { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TflApiPresentationEntitiesStatusSeverity {\n");
            sb.Append("  ModeName: ").Append(ModeName).Append("\n");
            sb.Append("  SeverityLevel: ").Append(SeverityLevel).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
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
            return this.Equals(input as TflApiPresentationEntitiesStatusSeverity);
        }

        /// <summary>
        /// Returns true if TflApiPresentationEntitiesStatusSeverity instances are equal
        /// </summary>
        /// <param name="input">Instance of TflApiPresentationEntitiesStatusSeverity to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TflApiPresentationEntitiesStatusSeverity input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.ModeName == input.ModeName ||
                    (this.ModeName != null &&
                    this.ModeName.Equals(input.ModeName))
                ) && 
                (
                    this.SeverityLevel == input.SeverityLevel ||
                    (this.SeverityLevel != null &&
                    this.SeverityLevel.Equals(input.SeverityLevel))
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
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
                if (this.ModeName != null)
                    hashCode = hashCode * 59 + this.ModeName.GetHashCode();
                if (this.SeverityLevel != null)
                    hashCode = hashCode * 59 + this.SeverityLevel.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
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
