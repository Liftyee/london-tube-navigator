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
    /// TflApiPresentationEntitiesMessage
    /// </summary>
    [DataContract]
    public partial class TflApiPresentationEntitiesMessage :  IEquatable<TflApiPresentationEntitiesMessage>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TflApiPresentationEntitiesMessage" /> class.
        /// </summary>
        /// <param name="bulletOrder">bulletOrder.</param>
        /// <param name="header">header.</param>
        /// <param name="messageText">messageText.</param>
        /// <param name="linkText">linkText.</param>
        /// <param name="url">url.</param>
        public TflApiPresentationEntitiesMessage(int? bulletOrder = default(int?), bool? header = default(bool?), string messageText = default(string), string linkText = default(string), string url = default(string))
        {
            this.BulletOrder = bulletOrder;
            this.Header = header;
            this.MessageText = messageText;
            this.LinkText = linkText;
            this.Url = url;
        }
        
        /// <summary>
        /// Gets or Sets BulletOrder
        /// </summary>
        [DataMember(Name="bulletOrder", EmitDefaultValue=false)]
        public int? BulletOrder { get; set; }

        /// <summary>
        /// Gets or Sets Header
        /// </summary>
        [DataMember(Name="header", EmitDefaultValue=false)]
        public bool? Header { get; set; }

        /// <summary>
        /// Gets or Sets MessageText
        /// </summary>
        [DataMember(Name="messageText", EmitDefaultValue=false)]
        public string MessageText { get; set; }

        /// <summary>
        /// Gets or Sets LinkText
        /// </summary>
        [DataMember(Name="linkText", EmitDefaultValue=false)]
        public string LinkText { get; set; }

        /// <summary>
        /// Gets or Sets Url
        /// </summary>
        [DataMember(Name="url", EmitDefaultValue=false)]
        public string Url { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TflApiPresentationEntitiesMessage {\n");
            sb.Append("  BulletOrder: ").Append(BulletOrder).Append("\n");
            sb.Append("  Header: ").Append(Header).Append("\n");
            sb.Append("  MessageText: ").Append(MessageText).Append("\n");
            sb.Append("  LinkText: ").Append(LinkText).Append("\n");
            sb.Append("  Url: ").Append(Url).Append("\n");
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
            return this.Equals(input as TflApiPresentationEntitiesMessage);
        }

        /// <summary>
        /// Returns true if TflApiPresentationEntitiesMessage instances are equal
        /// </summary>
        /// <param name="input">Instance of TflApiPresentationEntitiesMessage to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TflApiPresentationEntitiesMessage input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.BulletOrder == input.BulletOrder ||
                    (this.BulletOrder != null &&
                    this.BulletOrder.Equals(input.BulletOrder))
                ) && 
                (
                    this.Header == input.Header ||
                    (this.Header != null &&
                    this.Header.Equals(input.Header))
                ) && 
                (
                    this.MessageText == input.MessageText ||
                    (this.MessageText != null &&
                    this.MessageText.Equals(input.MessageText))
                ) && 
                (
                    this.LinkText == input.LinkText ||
                    (this.LinkText != null &&
                    this.LinkText.Equals(input.LinkText))
                ) && 
                (
                    this.Url == input.Url ||
                    (this.Url != null &&
                    this.Url.Equals(input.Url))
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
                if (this.BulletOrder != null)
                    hashCode = hashCode * 59 + this.BulletOrder.GetHashCode();
                if (this.Header != null)
                    hashCode = hashCode * 59 + this.Header.GetHashCode();
                if (this.MessageText != null)
                    hashCode = hashCode * 59 + this.MessageText.GetHashCode();
                if (this.LinkText != null)
                    hashCode = hashCode * 59 + this.LinkText.GetHashCode();
                if (this.Url != null)
                    hashCode = hashCode * 59 + this.Url.GetHashCode();
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
