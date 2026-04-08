namespace LegacyRenewalApp;
public class DiscountResult
{
    public decimal Amount { get; }
    public string Note { get; }

    public DiscountResult(decimal amount, string note)
    {
        Amount = amount;
        Note = note;
    }

    public static DiscountResult None => new DiscountResult(0m, string.Empty);
}
public interface ICustomerRepository
{
    Customer GetById(int customerId);
}
public interface ISubscriptionPlanRepository
{
    SubscriptionPlan GetByCode(string planCode);
}
public interface IBillingGateway {
    void SaveInvoice(RenewalInvoice invoice);
    void SendEmail(string email, string subject, string body);
}
public interface IDiscountRule {
    DiscountResult Apply(Customer customer, SubscriptionPlan plan, int seatCount, decimal baseAmount);
}
public interface ITaxCalculator { decimal GetRate(string country); }

public class FeeResult
{
    public decimal Amount { get; }
    public string Note { get; }

    public FeeResult(decimal amount, string note)
    {
        Amount = amount;
        Note = note;
    }
}

public interface ISupportFeeCalculator
{
    decimal Calculate(string normalizedPlanCode);
}

public interface IPaymentFeeCalculator
{
    FeeResult Calculate(string normalizedPaymentMethod, decimal subtotal);
}

