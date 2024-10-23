namespace ApiTest.Contracts
{
    public class Product : Record
    {
        public required string Name { get; set; }
        public required int Cost { get; set; }
        public string Category { get; set; }
        public string? Brand { get; set; }
    }
}
