using System.Collections.Generic;

namespace LegacyRenewalApp;

public class CountryTaxCalculator: ITaxCalculator
{
    private static readonly Dictionary<string, decimal> Rates = new() {
        ["Poland"] = 0.23m, ["Germany"] = 0.19m, 
        ["Czech Republic"] = 0.21m, ["Norway"] = 0.25m
    };
    public decimal GetRate(string country) => 
        Rates.TryGetValue(country, out var r) ? r : 0.20m;
}