using Ganss.Excel;

namespace Legacy_Order_Validator
{
    public class Order
    {
        [Column("Purchase Date")]
        public required string PurchaseDate { get; set; }
        [Column("Order #")]
        public string? OrderID { get; set; }
        [Column("Student First Name")]
        public required string FirstName { get; set; }
        [Column("Student Last Name")]
        public required string LastName { get; set; }
        [Column("Image Number")]
        public required string ImageName { get; set; }
        [Column("Grade")]
        public required string Grade { get; set; }
        [Column("School Name")]
        public required string SchoolName { get; set; }
        [Column("School Code")]
        public required string SchoolCode { get; set; }
        [Column("City (School)")]
        public required string City { get; set; }
        [Column("State (School)")]
        public required string State { get; set; }
        [Column("BYO Bundle")]
        public required string BYO_Bundle { get; set; }
        [Column("Product title")]
        public required string ProductTitle { get; set; }
        [Column("Background & Sizes")]
        public required string BackgroundAndSizes { get; set; }
        [Column("Quantity")]
        public required string Quantity { get; set; }
        [Column("Product name")]
        public required string ProductName { get; set; }
    }
}
