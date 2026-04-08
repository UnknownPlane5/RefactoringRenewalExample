using System.Collections.Generic;

namespace LegacyRenewalApp;

public class SupportFeeCalculator: ISupportFeeCalculator
{
    private static readonly Dictionary<string, decimal> Fees = new Dictionary<string, decimal>
    {
        ["START"]      = 250m,
        ["PRO"]        = 400m,
        ["ENTERPRISE"] = 700m,
    };

    public decimal Calculate(string normalizedPlanCode)
    {
        return Fees.TryGetValue(normalizedPlanCode, out var fee) ? fee : 0m;
    }

}