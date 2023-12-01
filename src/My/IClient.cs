public interface IClient
{
	int LoyaltyPoints { get; set; }
	long ClientId { get; private set; }
	float ClientCredit { get; set; }
	bool IsImmediate { get; set; }
	int ImmediateTransactionsCounter { get; set; }
	float ClientPriceMultiplier { get; set; }
	List<String> MonthlyPaymentDescriptions { get; set; }
}
