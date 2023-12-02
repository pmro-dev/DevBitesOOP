public class LoyaltyService : ILoyaltyService
{
	public int CalculatePoints(int rentalTime, bool isImmediate, decimal chargeAmount)
	{
		int loyaltyPoints = 0;
		if (rentalTime > 15 && rentalTime < 50)
		{
			loyaltyPoints = 4;
			if (isImmediate)
			{
				loyaltyPoints = 2;
			}
		}

		if (rentalTime >= 50 && chargeAmount > 30)
		{
			loyaltyPoints = 20;
		}
		return loyaltyPoints;
	}
}
