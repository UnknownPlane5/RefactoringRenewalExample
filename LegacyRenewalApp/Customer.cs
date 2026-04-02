namespace LegacyRenewalApp
{
    
    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Segment { get; set; } = null;
        public string Country { get; set; } = string.Empty;
        public int YearsWithCompany { get; set; }
        public int LoyaltyPoints { get; set; }
        public bool IsActive { get; set; }
        public decimal taxRating(string country, decimal defaultTaxRate)
        {
            switch (country)
            {
                case "Poland":
                    return 0.23m;
                case "Germany":
                    return 0.19m;
                case "Czech Republic":
                    return 0.21m;
                case "Norway":
                    return 0.25m;
                default: return defaultTaxRate;
            }
        }
    }
    
    public enum Segments
    {
        Silver,
        Gold,
        Platinum,
        Education
    }
    
}
