using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Framework.Models
{
    public class Products
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Product name should not be more then 30 character")]
        public string ProductName { get; set; }

        public string ShortDescription { get; set; }
        public string DetailDescription { get; set; }

        public string catagory { get; set; }
        public int StartPrice { get; set; }

        public DateTime? BidEndDT { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "First name should be more then 5 and less then 30 characters")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "First name should be more then 5 and less then 30 characters")]
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Contact number should have minimum 10 digits")]
        [Range(0,Int64.MaxValue)]
        public string  PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

    }
}
