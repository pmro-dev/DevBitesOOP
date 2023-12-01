public class Client
{
	int _standardPriceMultiplier = 1;
	int _counterStarterPosition = 0;
	int _loyaltyPointsOnRegister = 0;

	int LoyaltyPoints { get; set; }
	long ClientId { get; private set; }
	float ClientCredit { get; set; }
	bool IsImmediate { get; set; }
	int ImmediateTransactionsCounter { get; set; }
	float ClientPriceMultiplier { get; set; }
	List<String> MonthlyPaymentDescriptions { get; set; }

	public Client(float clientCredit)
	{
		LoyaltyPoints = _loyaltyPointsOnRegister;
		ClientCredit = clientCredit;
		ClientPriceMultiplier = _standardPriceMultiplier;
		IsImmediate = false;
		ImmediateTransactionsCounter = _counterStarterPosition;
		MonthlyPaymentDescriptions = new();
	}
}
