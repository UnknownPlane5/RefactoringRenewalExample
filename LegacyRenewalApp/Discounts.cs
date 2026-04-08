using System.Collections.Generic;

namespace LegacyRenewalApp;
    public class SegmentDiscountRule : IDiscountRule
{
    private static readonly Dictionary<string, (decimal rate, string note)> Rates = new()
    {
        ["Silver"]   = (0.05m, "silver discount; "),
        ["Gold"]     = (0.10m, "gold discount; "),
        ["Platinum"] = (0.15m, "platinum discount; "),
    };

    public DiscountResult Apply(Customer customer, SubscriptionPlan plan, int seatCount, decimal baseAmount)
    {
        if (Rates.TryGetValue(customer.Segment, out var entry))
            return new DiscountResult(baseAmount * entry.rate, entry.note);

        if (customer.Segment == "Education" && plan.IsEducationEligible)
            return new DiscountResult(baseAmount * 0.20m, "education discount; ");

        return DiscountResult.None;
    }
}

public class LoyaltyYearsDiscountRule : IDiscountRule
{
    public DiscountResult Apply(Customer customer, SubscriptionPlan plan, int seatCount, decimal baseAmount)
    {
        if (customer.YearsWithCompany >= 5)
            return new DiscountResult(baseAmount * 0.07m, "long-term loyalty discount; ");

        if (customer.YearsWithCompany >= 2)
            return new DiscountResult(baseAmount * 0.03m, "basic loyalty discount; ");

        return DiscountResult.None;
    }
}

public class SeatCountDiscountRule : IDiscountRule
{
    public DiscountResult Apply(Customer customer, SubscriptionPlan plan, int seatCount, decimal baseAmount)
    {
        if (seatCount >= 50) return new DiscountResult(baseAmount * 0.12m, "large team discount; ");
        if (seatCount >= 20) return new DiscountResult(baseAmount * 0.08m, "medium team discount; ");
        if (seatCount >= 10) return new DiscountResult(baseAmount * 0.04m, "small team discount; ");

        return DiscountResult.None;
    }
}

public class LoyaltyPointsDiscountRule : IDiscountRule
{
    private readonly bool _useLoyaltyPoints;

    public LoyaltyPointsDiscountRule(bool useLoyaltyPoints)
    {
        _useLoyaltyPoints = useLoyaltyPoints;
    }

    public DiscountResult Apply(Customer customer, SubscriptionPlan plan, int seatCount, decimal baseAmount)
    {
        if (_useLoyaltyPoints && customer.LoyaltyPoints > 0)
        {
            int pointsToUse = customer.LoyaltyPoints > 200 ? 200 : customer.LoyaltyPoints;
            return new DiscountResult(pointsToUse, $"loyalty points used: {pointsToUse}; ");
        }

        return DiscountResult.None;
    }

}
