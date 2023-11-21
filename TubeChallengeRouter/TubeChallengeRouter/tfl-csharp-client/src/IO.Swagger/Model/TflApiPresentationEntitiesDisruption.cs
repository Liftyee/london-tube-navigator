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
    /// Represents a disruption to a route within the transport network.
    /// </summary>
    [DataContract]
    public partial class TflApiPresentationEntitiesDisruption :  IEquatable<TflApiPresentationEntitiesDisruption>, IValidatableObject
    {
        /// <summary>
        /// Gets or sets the category of this dispruption.
        /// </summary>
        /// <value>Gets or sets the category of this dispruption.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum CategoryEnum
        {
            
            /// <summary>
            /// Enum Undefined for value: Undefined
            /// </summary>
            [EnumMember(Value = "Undefined")]
            Undefined = 1,
            
            /// <summary>
            /// Enum RealTime for value: RealTime
            /// </summary>
            [EnumMember(Value = "RealTime")]
            RealTime = 2,
            
            /// <summary>
            /// Enum PlannedWork for value: PlannedWork
            /// </summary>
            [EnumMember(Value = "PlannedWork")]
            PlannedWork = 3,
            
            /// <summary>
            /// Enum Information for value: Information
            /// </summary>
            [EnumMember(Value = "Information")]
            Information = 4,
            
            /// <summary>
            /// Enum Event for value: Event
            /// </summary>
            [EnumMember(Value = "Event")]
            Event = 5,
            
            /// <summary>
            /// Enum Crowding for value: Crowding
            /// </summary>
            [EnumMember(Value = "Crowding")]
            Crowding = 6,
            
            /// <summary>
            /// Enum StatusAlert for value: StatusAlert
            /// </summary>
            [EnumMember(Value = "StatusAlert")]
            StatusAlert = 7
        }

        /// <summary>
        /// Gets or sets the category of this dispruption.
        /// </summary>
        /// <value>Gets or sets the category of this dispruption.</value>
        [DataMember(Name="category", EmitDefaultValue=false)]
        public CategoryEnum? Category { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="TflApiPresentationEntitiesDisruption" /> class.
        /// </summary>
        /// <param name="category">Gets or sets the category of this dispruption..</param>
        /// <param name="type">Gets or sets the disruption type of this dispruption..</param>
        /// <param name="categoryDescription">Gets or sets the description of the category..</param>
        /// <param name="description">Gets or sets the description of this disruption..</param>
        /// <param name="summary">Gets or sets the summary of this disruption..</param>
        /// <param name="additionalInfo">Gets or sets the additionaInfo of this disruption..</param>
        /// <param name="created">Gets or sets the date/time when this disruption was created..</param>
        /// <param name="lastUpdate">Gets or sets the date/time when this disruption was last updated..</param>
        /// <param name="affectedRoutes">Gets or sets the routes affected by this disruption.</param>
        /// <param name="affectedStops">Gets or sets the stops affected by this disruption.</param>
        /// <param name="closureText">Text describing the closure type.</param>
        public TflApiPresentationEntitiesDisruption(CategoryEnum? category = default(CategoryEnum?), string type = default(string), string categoryDescription = default(string), string description = default(string), string summary = default(string), string additionalInfo = default(string), DateTime? created = default(DateTime?), DateTime? lastUpdate = default(DateTime?), List<TflApiPresentationEntitiesDisruptedRoute> affectedRoutes = default(List<TflApiPresentationEntitiesDisruptedRoute>), List<TflApiPresentationEntitiesStopPoint> affectedStops = default(List<TflApiPresentationEntitiesStopPoint>), string closureText = default(string))
        {
            this.Category = category;
            this.Type = type;
            this.CategoryDescription = categoryDescription;
            this.Description = description;
            this.Summary = summary;
            this.AdditionalInfo = additionalInfo;
            this.Created = created;
            this.LastUpdate = lastUpdate;
            this.AffectedRoutes = affectedRoutes;
            this.AffectedStops = affectedStops;
            this.ClosureText = closureText;
        }
        

        /// <summary>
        /// Gets or sets the disruption type of this dispruption.
        /// </summary>
        /// <value>Gets or sets the disruption type of this dispruption.</value>
        [DataMember(Name="type", EmitDefaultValue=false)]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the description of the category.
        /// </summary>
        /// <value>Gets or sets the description of the category.</value>
        [DataMember(Name="categoryDescription", EmitDefaultValue=false)]
        public string CategoryDescription { get; set; }

        /// <summary>
        /// Gets or sets the description of this disruption.
        /// </summary>
        /// <value>Gets or sets the description of this disruption.</value>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the summary of this disruption.
        /// </summary>
        /// <value>Gets or sets the summary of this disruption.</value>
        [DataMember(Name="summary", EmitDefaultValue=false)]
        public string Summary { get; set; }

        /// <summary>
        /// Gets or sets the additionaInfo of this disruption.
        /// </summary>
        /// <value>Gets or sets the additionaInfo of this disruption.</value>
        [DataMember(Name="additionalInfo", EmitDefaultValue=false)]
        public string AdditionalInfo { get; set; }

        /// <summary>
        /// Gets or sets the date/time when this disruption was created.
        /// </summary>
        /// <value>Gets or sets the date/time when this disruption was created.</value>
        [DataMember(Name="created", EmitDefaultValue=false)]
        public DateTime? Created { get; set; }

        /// <summary>
        /// Gets or sets the date/time when this disruption was last updated.
        /// </summary>
        /// <value>Gets or sets the date/time when this disruption was last updated.</value>
        [DataMember(Name="lastUpdate", EmitDefaultValue=false)]
        public DateTime? LastUpdate { get; set; }

        /// <summary>
        /// Gets or sets the routes affected by this disruption
        /// </summary>
        /// <value>Gets or sets the routes affected by this disruption</value>
        [DataMember(Name="affectedRoutes", EmitDefaultValue=false)]
        public List<TflApiPresentationEntitiesDisruptedRoute> AffectedRoutes { get; set; }

        /// <summary>
        /// Gets or sets the stops affected by this disruption
        /// </summary>
        /// <value>Gets or sets the stops affected by this disruption</value>
        [DataMember(Name="affectedStops", EmitDefaultValue=false)]
        public List<TflApiPresentationEntitiesStopPoint> AffectedStops { get; set; }

        /// <summary>
        /// Text describing the closure type
        /// </summary>
        /// <value>Text describing the closure type</value>
        [DataMember(Name="closureText", EmitDefaultValue=false)]
        public string ClosureText { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TflApiPresentationEntitiesDisruption {\n");
            sb.Append("  Category: ").Append(Category).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  CategoryDescription: ").Append(CategoryDescription).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Summary: ").Append(Summary).Append("\n");
            sb.Append("  AdditionalInfo: ").Append(AdditionalInfo).Append("\n");
            sb.Append("  Created: ").Append(Created).Append("\n");
            sb.Append("  LastUpdate: ").Append(LastUpdate).Append("\n");
            sb.Append("  AffectedRoutes: ").Append(AffectedRoutes).Append("\n");
            sb.Append("  AffectedStops: ").Append(AffectedStops).Append("\n");
            sb.Append("  ClosureText: ").Append(ClosureText).Append("\n");
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
            return this.Equals(input as TflApiPresentationEntitiesDisruption);
        }

        /// <summary>
        /// Returns true if TflApiPresentationEntitiesDisruption instances are equal
        /// </summary>
        /// <param name="input">Instance of TflApiPresentationEntitiesDisruption to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TflApiPresentationEntitiesDisruption input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Category == input.Category ||
                    (this.Category != null &&
                    this.Category.Equals(input.Category))
                ) && 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
                ) && 
                (
                    this.CategoryDescription == input.CategoryDescription ||
                    (this.CategoryDescription != null &&
                    this.CategoryDescription.Equals(input.CategoryDescription))
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.Summary == input.Summary ||
                    (this.Summary != null &&
                    this.Summary.Equals(input.Summary))
                ) && 
                (
                    this.AdditionalInfo == input.AdditionalInfo ||
                    (this.AdditionalInfo != null &&
                    this.AdditionalInfo.Equals(input.AdditionalInfo))
                ) && 
                (
                    this.Created == input.Created ||
                    (this.Created != null &&
                    this.Created.Equals(input.Created))
                ) && 
                (
                    this.LastUpdate == input.LastUpdate ||
                    (this.LastUpdate != null &&
                    this.LastUpdate.Equals(input.LastUpdate))
                ) && 
                (
                    this.AffectedRoutes == input.AffectedRoutes ||
                    this.AffectedRoutes != null &&
                    this.AffectedRoutes.SequenceEqual(input.AffectedRoutes)
                ) && 
                (
                    this.AffectedStops == input.AffectedStops ||
                    this.AffectedStops != null &&
                    this.AffectedStops.SequenceEqual(input.AffectedStops)
                ) && 
                (
                    this.ClosureText == input.ClosureText ||
                    (this.ClosureText != null &&
                    this.ClosureText.Equals(input.ClosureText))
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
                if (this.Category != null)
                    hashCode = hashCode * 59 + this.Category.GetHashCode();
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
                if (this.CategoryDescription != null)
                    hashCode = hashCode * 59 + this.CategoryDescription.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                if (this.Summary != null)
                    hashCode = hashCode * 59 + this.Summary.GetHashCode();
                if (this.AdditionalInfo != null)
                    hashCode = hashCode * 59 + this.AdditionalInfo.GetHashCode();
                if (this.Created != null)
                    hashCode = hashCode * 59 + this.Created.GetHashCode();
                if (this.LastUpdate != null)
                    hashCode = hashCode * 59 + this.LastUpdate.GetHashCode();
                if (this.AffectedRoutes != null)
                    hashCode = hashCode * 59 + this.AffectedRoutes.GetHashCode();
                if (this.AffectedStops != null)
                    hashCode = hashCode * 59 + this.AffectedStops.GetHashCode();
                if (this.ClosureText != null)
                    hashCode = hashCode * 59 + this.ClosureText.GetHashCode();
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
