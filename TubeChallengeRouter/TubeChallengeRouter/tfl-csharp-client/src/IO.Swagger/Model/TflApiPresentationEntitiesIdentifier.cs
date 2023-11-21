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
    /// TflApiPresentationEntitiesIdentifier
    /// </summary>
    [DataContract]
    public partial class TflApiPresentationEntitiesIdentifier :  IEquatable<TflApiPresentationEntitiesIdentifier>, IValidatableObject
    {
        /// <summary>
        /// Defines RouteType
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum RouteTypeEnum
        {
            
            /// <summary>
            /// Enum Unknown for value: Unknown
            /// </summary>
            [EnumMember(Value = "Unknown")]
            Unknown = 1,
            
            /// <summary>
            /// Enum All for value: All
            /// </summary>
            [EnumMember(Value = "All")]
            All = 2,
            
            /// <summary>
            /// Enum CycleSuperhighways for value: Cycle Superhighways
            /// </summary>
            [EnumMember(Value = "Cycle Superhighways")]
            CycleSuperhighways = 3,
            
            /// <summary>
            /// Enum Quietways for value: Quietways
            /// </summary>
            [EnumMember(Value = "Quietways")]
            Quietways = 4,
            
            /// <summary>
            /// Enum Cycleways for value: Cycleways
            /// </summary>
            [EnumMember(Value = "Cycleways")]
            Cycleways = 5,
            
            /// <summary>
            /// Enum MiniHollands for value: Mini-Hollands
            /// </summary>
            [EnumMember(Value = "Mini-Hollands")]
            MiniHollands = 6,
            
            /// <summary>
            /// Enum CentralLondonGrid for value: Central London Grid
            /// </summary>
            [EnumMember(Value = "Central London Grid")]
            CentralLondonGrid = 7,
            
            /// <summary>
            /// Enum StreetspaceRoute for value: Streetspace Route
            /// </summary>
            [EnumMember(Value = "Streetspace Route")]
            StreetspaceRoute = 8
        }

        /// <summary>
        /// Gets or Sets RouteType
        /// </summary>
        [DataMember(Name="routeType", EmitDefaultValue=false)]
        public RouteTypeEnum? RouteType { get; set; }
        /// <summary>
        /// Defines Status
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusEnum
        {
            
            /// <summary>
            /// Enum Unknown for value: Unknown
            /// </summary>
            [EnumMember(Value = "Unknown")]
            Unknown = 1,
            
            /// <summary>
            /// Enum All for value: All
            /// </summary>
            [EnumMember(Value = "All")]
            All = 2,
            
            /// <summary>
            /// Enum Open for value: Open
            /// </summary>
            [EnumMember(Value = "Open")]
            Open = 3,
            
            /// <summary>
            /// Enum InProgress for value: In Progress
            /// </summary>
            [EnumMember(Value = "In Progress")]
            InProgress = 4,
            
            /// <summary>
            /// Enum Planned for value: Planned
            /// </summary>
            [EnumMember(Value = "Planned")]
            Planned = 5,
            
            /// <summary>
            /// Enum PlannedSubjecttofeasibilityandconsultation for value: Planned - Subject to feasibility and consultation.
            /// </summary>
            [EnumMember(Value = "Planned - Subject to feasibility and consultation.")]
            PlannedSubjecttofeasibilityandconsultation = 6,
            
            /// <summary>
            /// Enum NotOpen for value: Not Open
            /// </summary>
            [EnumMember(Value = "Not Open")]
            NotOpen = 7
        }

        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        [DataMember(Name="status", EmitDefaultValue=false)]
        public StatusEnum? Status { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="TflApiPresentationEntitiesIdentifier" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="name">name.</param>
        /// <param name="uri">uri.</param>
        /// <param name="fullName">fullName.</param>
        /// <param name="type">type.</param>
        /// <param name="crowding">crowding.</param>
        /// <param name="routeType">routeType.</param>
        /// <param name="status">status.</param>
        /// <param name="motType">motType.</param>
        /// <param name="network">network.</param>
        public TflApiPresentationEntitiesIdentifier(string id = default(string), string name = default(string), string uri = default(string), string fullName = default(string), string type = default(string), TflApiPresentationEntitiesCrowding crowding = default(TflApiPresentationEntitiesCrowding), RouteTypeEnum? routeType = default(RouteTypeEnum?), StatusEnum? status = default(StatusEnum?), string motType = default(string), string network = default(string))
        {
            this.Id = id;
            this.Name = name;
            this.Uri = uri;
            this.FullName = fullName;
            this.Type = type;
            this.Crowding = crowding;
            this.RouteType = routeType;
            this.Status = status;
            this.MotType = motType;
            this.Network = network;
        }
        
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Uri
        /// </summary>
        [DataMember(Name="uri", EmitDefaultValue=false)]
        public string Uri { get; set; }

        /// <summary>
        /// Gets or Sets FullName
        /// </summary>
        [DataMember(Name="fullName", EmitDefaultValue=false)]
        public string FullName { get; set; }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name="type", EmitDefaultValue=false)]
        public string Type { get; set; }

        /// <summary>
        /// Gets or Sets Crowding
        /// </summary>
        [DataMember(Name="crowding", EmitDefaultValue=false)]
        public TflApiPresentationEntitiesCrowding Crowding { get; set; }



        /// <summary>
        /// Gets or Sets MotType
        /// </summary>
        [DataMember(Name="motType", EmitDefaultValue=false)]
        public string MotType { get; set; }

        /// <summary>
        /// Gets or Sets Network
        /// </summary>
        [DataMember(Name="network", EmitDefaultValue=false)]
        public string Network { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TflApiPresentationEntitiesIdentifier {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Uri: ").Append(Uri).Append("\n");
            sb.Append("  FullName: ").Append(FullName).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Crowding: ").Append(Crowding).Append("\n");
            sb.Append("  RouteType: ").Append(RouteType).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  MotType: ").Append(MotType).Append("\n");
            sb.Append("  Network: ").Append(Network).Append("\n");
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
            return this.Equals(input as TflApiPresentationEntitiesIdentifier);
        }

        /// <summary>
        /// Returns true if TflApiPresentationEntitiesIdentifier instances are equal
        /// </summary>
        /// <param name="input">Instance of TflApiPresentationEntitiesIdentifier to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TflApiPresentationEntitiesIdentifier input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.Uri == input.Uri ||
                    (this.Uri != null &&
                    this.Uri.Equals(input.Uri))
                ) && 
                (
                    this.FullName == input.FullName ||
                    (this.FullName != null &&
                    this.FullName.Equals(input.FullName))
                ) && 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
                ) && 
                (
                    this.Crowding == input.Crowding ||
                    (this.Crowding != null &&
                    this.Crowding.Equals(input.Crowding))
                ) && 
                (
                    this.RouteType == input.RouteType ||
                    (this.RouteType != null &&
                    this.RouteType.Equals(input.RouteType))
                ) && 
                (
                    this.Status == input.Status ||
                    (this.Status != null &&
                    this.Status.Equals(input.Status))
                ) && 
                (
                    this.MotType == input.MotType ||
                    (this.MotType != null &&
                    this.MotType.Equals(input.MotType))
                ) && 
                (
                    this.Network == input.Network ||
                    (this.Network != null &&
                    this.Network.Equals(input.Network))
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
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.Uri != null)
                    hashCode = hashCode * 59 + this.Uri.GetHashCode();
                if (this.FullName != null)
                    hashCode = hashCode * 59 + this.FullName.GetHashCode();
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
                if (this.Crowding != null)
                    hashCode = hashCode * 59 + this.Crowding.GetHashCode();
                if (this.RouteType != null)
                    hashCode = hashCode * 59 + this.RouteType.GetHashCode();
                if (this.Status != null)
                    hashCode = hashCode * 59 + this.Status.GetHashCode();
                if (this.MotType != null)
                    hashCode = hashCode * 59 + this.MotType.GetHashCode();
                if (this.Network != null)
                    hashCode = hashCode * 59 + this.Network.GetHashCode();
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
