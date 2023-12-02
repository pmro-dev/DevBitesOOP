public class ChargeService : IChargeService
{
	public decimal Calculate(int rentalTime, decimal pricePerMinute, decimal unlockingPrice, bool isImmediate, decimal clientCredit)
	{
		decimal chargeAmount = rentalTime * pricePerMinute + unlockingPrice;
		if (isImmediate)
		{
			chargeAmount =* 0.9f;
		}

		RecalculateWithClientCredit(ref chargeAmount, clientCredit);

		return chargeAmount;
	}

	private void RecalculateWithClientCredit(ref decimal chargeAmount, decimal clientCredit)
	{
		chargeAmount = Math.max(chargeAmount - clientCredit, 0);
	}
}
