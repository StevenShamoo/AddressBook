using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AddressBook.Models.Request
{
    public class AddressUpdateRequest: AddressAddRequest
    {
        [Required]
        public Guid Id { get; set; }
    }
}