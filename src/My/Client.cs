public class Client
{
	private int _standardPriceMultiplier = 1;
	private int _counterStarterPosition = 0;
	private int _loyaltyPointsOnRegister = 0;

	public int LoyaltyPoints { get; set; }
	public long ClientId { get; private set; }
	public float ClientCredit { get; set; }
	public bool IsImmediate { get; set; }
	public int ImmediateTransactionsCounter { get; set; }
	public float ClientPriceMultiplier { get; set; }
	public List<String> MonthlyPaymentDescriptions { get; set; }

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
