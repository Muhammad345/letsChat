using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace LetsChatAPI.Models
{
    public class Customer
    {
        [Key]
        [DisplayName("Customer Id")]
        [JsonProperty("customerId")]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Name")]
        [JsonProperty("name")]
        public string Name { get; set; }

        [StringLength(300)]
        [DisplayName("Address")]
        [JsonProperty("address")]
        public string Address { get; set; }

        [StringLength(12)]
        [DisplayName("Phone Number")]
        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }


    }
}