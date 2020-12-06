using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASBbackend.Models
{
    // Documentation: https://docs.microsoft.com/en-us/aspnet/core/mvc/models/validation

    public class CreditCard : IValidatableObject
    {
        /// <summary>
        /// The id of the Credit card
        /// </summary>
        /// <example>Rodrigo</example>
        public Guid Id { get; set; }

        /// <summary>
        /// The name of the Credit card's owner
        /// </summary>
        /// <example>Rodrigo</example>
        [Required]
        [StringLength(50, ErrorMessage = "Name length can't be more than 50.")]
        public string Name { get; set; }

        /// <summary>
        /// The number of the Credit card
        /// </summary>
        /// <example>1111222233334444</example>
        [Required]
        [Range(0, long.MaxValue, ErrorMessage = "Number can't be negative")]
        public long Number { get; set; }

        /// <summary>
        /// The CVC of the Credit card
        /// </summary>
        /// <example>123</example>
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "CVC can't be negative")]
        public int CVC { get; set; }

        /// <summary>
        /// The expiry date of the Credit card
        /// </summary>
        /// <example>2021-11-13</example>
        [Required]
        public DateTime Expires { get; set; }

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            if (Expires < DateTime.Now)
            {
                yield return new ValidationResult("Expires date must be later than today.");
            }
            if (!Name.All(char.IsLetterOrDigit))
            {
                yield return new ValidationResult("Name must be alphanumeric.");
            }
        }
    }
}
