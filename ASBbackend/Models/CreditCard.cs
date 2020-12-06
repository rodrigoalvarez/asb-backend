using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASBbackend.Models
{
    // Documentation: https://docs.microsoft.com/en-us/aspnet/core/mvc/models/validation

    public class CreditCard
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public long Number { get; set; }

        public int CVC { get; set; }

        public DateTime Expires { get; set; }
    }
}
