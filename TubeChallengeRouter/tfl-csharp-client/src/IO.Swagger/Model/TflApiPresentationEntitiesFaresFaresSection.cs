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
    /// TflApiPresentationEntitiesFaresFaresSection
    /// </summary>
    [DataContract]
    public partial class TflApiPresentationEntitiesFaresFaresSection :  IEquatable<TflApiPresentationEntitiesFaresFaresSection>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TflApiPresentationEntitiesFaresFaresSection" /> class.
        /// </summary>
        /// <param name="header">header.</param>
        /// <param name="index">index.</param>
        /// <param name="journey">journey.</param>
        /// <param name="rows">rows.</param>
        /// <param name="messages">messages.</param>
        public TflApiPresentationEntitiesFaresFaresSection(string header = default(string), int? index = default(int?), TflApiPresentationEntitiesFaresJourney journey = default(TflApiPresentationEntitiesFaresJourney), List<TflApiPresentationEntitiesFaresFareDetails> rows = default(List<TflApiPresentationEntitiesFaresFareDetails>), List<TflApiPresentationEntitiesMessage> messages = default(List<TflApiPresentationEntitiesMessage>))
        {
            this.Header = header;
            this.Index = index;
            this.Journey = journey;
            this.Rows = rows;
            this.Messages = messages;
        }
        
        /// <summary>
        /// Gets or Sets Header
        /// </summary>
        [DataMember(Name="header", EmitDefaultValue=false)]
        public string Header { get; set; }

        /// <summary>
        /// Gets or Sets Index
        /// </summary>
        [DataMember(Name="index", EmitDefaultValue=false)]
        public int? Index { get; set; }

        /// <summary>
        /// Gets or Sets Journey
        /// </summary>
        [DataMember(Name="journey", EmitDefaultValue=false)]
        public TflApiPresentationEntitiesFaresJourney Journey { get; set; }

        /// <summary>
        /// Gets or Sets Rows
        /// </summary>
        [DataMember(Name="rows", EmitDefaultValue=false)]
        public List<TflApiPresentationEntitiesFaresFareDetails> Rows { get; set; }

        /// <summary>
        /// Gets or Sets Messages
        /// </summary>
        [DataMember(Name="messages", EmitDefaultValue=false)]
        public List<TflApiPresentationEntitiesMessage> Messages { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TflApiPresentationEntitiesFaresFaresSection {\n");
            sb.Append("  Header: ").Append(Header).Append("\n");
            sb.Append("  Index: ").Append(Index).Append("\n");
            sb.Append("  Journey: ").Append(Journey).Append("\n");
            sb.Append("  Rows: ").Append(Rows).Append("\n");
            sb.Append("  Messages: ").Append(Messages).Append("\n");
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
            return this.Equals(input as TflApiPresentationEntitiesFaresFaresSection);
        }

        /// <summary>
        /// Returns true if TflApiPresentationEntitiesFaresFaresSection instances are equal
        /// </summary>
        /// <param name="input">Instance of TflApiPresentationEntitiesFaresFaresSection to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TflApiPresentationEntitiesFaresFaresSection input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Header == input.Header ||
                    (this.Header != null &&
                    this.Header.Equals(input.Header))
                ) && 
                (
                    this.Index == input.Index ||
                    (this.Index != null &&
                    this.Index.Equals(input.Index))
                ) && 
                (
                    this.Journey == input.Journey ||
                    (this.Journey != null &&
                    this.Journey.Equals(input.Journey))
                ) && 
                (
                    this.Rows == input.Rows ||
                    this.Rows != null &&
                    this.Rows.SequenceEqual(input.Rows)
                ) && 
                (
                    this.Messages == input.Messages ||
                    this.Messages != null &&
                    this.Messages.SequenceEqual(input.Messages)
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
                if (this.Header != null)
                    hashCode = hashCode * 59 + this.Header.GetHashCode();
                if (this.Index != null)
                    hashCode = hashCode * 59 + this.Index.GetHashCode();
                if (this.Journey != null)
                    hashCode = hashCode * 59 + this.Journey.GetHashCode();
                if (this.Rows != null)
                    hashCode = hashCode * 59 + this.Rows.GetHashCode();
                if (this.Messages != null)
                    hashCode = hashCode * 59 + this.Messages.GetHashCode();
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