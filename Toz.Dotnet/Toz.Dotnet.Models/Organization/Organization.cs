﻿using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Toz.Dotnet.Models.Organization
{
    public class Organization
    {
        [JsonProperty("name")]
        [RegularExpression(@"(([^\u0000-\u007F]|[a-zA-Z])+[\.\-\']?([^\u0000-\u007F]|[a-zA-Z]|(\s(?!$))+)?[\.]?)*", ErrorMessageResourceType = typeof(Resources.ModelsDataValidation), ErrorMessageResourceName = "InvalidValue")]
        [Required(ErrorMessageResourceType = typeof(Resources.ModelsDataValidation), ErrorMessageResourceName = "EmptyField")]
        public string Name { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("contact")]
        public Contact Contact { get; set; }

        [JsonProperty("bankAccount")]
        public BankAccount BankAccount { get; set; }
    }
}