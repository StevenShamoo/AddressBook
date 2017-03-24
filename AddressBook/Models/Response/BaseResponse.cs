using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AddressBook.Models.Response
{
    public abstract class BaseResponse
    {
        public bool IsSuccessful { get; set; }

    }
}