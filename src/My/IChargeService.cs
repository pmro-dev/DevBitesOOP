public interface IChargeService
{
	decimal Calculate(int rentalTime, decimal pricePerMinute, decimal unlockingPrice, bool isImmediate, decimal clientCredit);
}
