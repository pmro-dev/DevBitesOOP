public interface IRentalData
{
	public int Minutes { get; set; }
	public long ClientId { get; set; }
	public long ScooterId { get; set; }
	public int LoyaltyPointsGain { get; set; }
	public decimal ChargeAmount { get; set; }
	public Position ScooterStartingPosition { get; set; }
	public Position ScooterReturnPosition { get; set; }
	public bool IsRentalFinished { get; set; }

	public void OpenRent(Position startingPosition);
	public void EndRent(decimal chargeAmount, int rentalTime, int loyaltyPointsGain, Position closingScooterPosition);
}