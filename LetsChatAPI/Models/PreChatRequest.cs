using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LetsChatAPI.Models
{
    public class PreChatRequest
    {
        [Key]
        [DisplayName("Chat RequestId")]
        [JsonProperty("chatRequestId")]
        public Guid ChatRequestId { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Name")]
        [JsonProperty("name")]
        public string Name { get; set; }

        [StringLength(300)]
        [DisplayName("Email Address")]
        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }

        [StringLength(12)]
        [DisplayName("Reason")]
        [JsonProperty("reason")]
        public string Reason { get; set; }


    }
}