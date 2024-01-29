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
    /// TflApiPresentationEntitiesAccidentStatsCasualty
    /// </summary>
    [DataContract]
    public partial class TflApiPresentationEntitiesAccidentStatsCasualty :  IEquatable<TflApiPresentationEntitiesAccidentStatsCasualty>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TflApiPresentationEntitiesAccidentStatsCasualty" /> class.
        /// </summary>
        /// <param name="age">age.</param>
        /// <param name="class">_class.</param>
        /// <param name="severity">severity.</param>
        /// <param name="mode">mode.</param>
        /// <param name="ageBand">ageBand.</param>
        public TflApiPresentationEntitiesAccidentStatsCasualty(int? age = default(int?), string @class = default(string), string severity = default(string), string mode = default(string), string ageBand = default(string))
        {
            this.Age = age;
            this.Class = @class;
            this.Severity = severity;
            this.Mode = mode;
            this.AgeBand = ageBand;
        }
        
        /// <summary>
        /// Gets or Sets Age
        /// </summary>
        [DataMember(Name="age", EmitDefaultValue=false)]
        public int? Age { get; set; }

        /// <summary>
        /// Gets or Sets Class
        /// </summary>
        [DataMember(Name="class", EmitDefaultValue=false)]
        public string Class { get; set; }

        /// <summary>
        /// Gets or Sets Severity
        /// </summary>
        [DataMember(Name="severity", EmitDefaultValue=false)]
        public string Severity { get; set; }

        /// <summary>
        /// Gets or Sets Mode
        /// </summary>
        [DataMember(Name="mode", EmitDefaultValue=false)]
        public string Mode { get; set; }

        /// <summary>
        /// Gets or Sets AgeBand
        /// </summary>
        [DataMember(Name="ageBand", EmitDefaultValue=false)]
        public string AgeBand { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TflApiPresentationEntitiesAccidentStatsCasualty {\n");
            sb.Append("  Age: ").Append(Age).Append("\n");
            sb.Append("  Class: ").Append(Class).Append("\n");
            sb.Append("  Severity: ").Append(Severity).Append("\n");
            sb.Append("  Mode: ").Append(Mode).Append("\n");
            sb.Append("  AgeBand: ").Append(AgeBand).Append("\n");
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
            return this.Equals(input as TflApiPresentationEntitiesAccidentStatsCasualty);
        }

        /// <summary>
        /// Returns true if TflApiPresentationEntitiesAccidentStatsCasualty instances are equal
        /// </summary>
        /// <param name="input">Instance of TflApiPresentationEntitiesAccidentStatsCasualty to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TflApiPresentationEntitiesAccidentStatsCasualty input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Age == input.Age ||
                    (this.Age != null &&
                    this.Age.Equals(input.Age))
                ) && 
                (
                    this.Class == input.Class ||
                    (this.Class != null &&
                    this.Class.Equals(input.Class))
                ) && 
                (
                    this.Severity == input.Severity ||
                    (this.Severity != null &&
                    this.Severity.Equals(input.Severity))
                ) && 
                (
                    this.Mode == input.Mode ||
                    (this.Mode != null &&
                    this.Mode.Equals(input.Mode))
                ) && 
                (
                    this.AgeBand == input.AgeBand ||
                    (this.AgeBand != null &&
                    this.AgeBand.Equals(input.AgeBand))
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
                if (this.Age != null)
                    hashCode = hashCode * 59 + this.Age.GetHashCode();
                if (this.Class != null)
                    hashCode = hashCode * 59 + this.Class.GetHashCode();
                if (this.Severity != null)
                    hashCode = hashCode * 59 + this.Severity.GetHashCode();
                if (this.Mode != null)
                    hashCode = hashCode * 59 + this.Mode.GetHashCode();
                if (this.AgeBand != null)
                    hashCode = hashCode * 59 + this.AgeBand.GetHashCode();
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
