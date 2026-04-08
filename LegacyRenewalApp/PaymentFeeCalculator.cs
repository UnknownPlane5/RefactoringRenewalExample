using System;
using System.Collections.Generic;

namespace LegacyRenewalApp;


public class PaymentFeeCalculator : IPaymentFeeCalculator
{
    private static readonly Dictionary<string, (decimal rate, string note)> Fees = 
        new Dictionary<string, (decimal, string)>
        {
            ["CARD"]          = (0.02m,  "card payment fee; "),
            ["BANK_TRANSFER"] = (0.01m,  "bank transfer fee; "), 
            ["PAYPAL"]        = (0.035m, "paypal fee; "),
            ["INVOICE"]       = (0m,     "invoice payment; "), 
        };
    public FeeResult Calculate(string normalizedPaymentMethod, decimal subtotal) { 
        if (!Fees.TryGetValue(normalizedPaymentMethod, out var entry)) 
            throw new ArgumentException("Unsupported payment method"); 
        return new FeeResult(subtotal * entry.rate, entry.note); 
    }
}
