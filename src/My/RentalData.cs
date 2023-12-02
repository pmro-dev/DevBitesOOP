public class RentalData : IRentalData
{
	public int RentalTime { get; private set; }
	public long ClientId { get; private set; }
	public long ScooterId { get; private set; }
	public int LoyaltyPointsGain { get; private set; }
	public decimal ChargeAmount { get; private set; }
	public Position? ScooterStartingPosition { get; private set; }
	public Position? LastRentScooterPosition { get; private set; }
	public bool IsRentalFinished { get; private set; }
	public PaymentStatusType PaymentStatus {  get; set; }

    public RentalData(long clientId, long scooterId)
    {
        ClientId = clientId;
		ScooterId = scooterId;
		IsRentalFinished = false;
	}

	public void OpenRent(Position startingPosition)
	{
		ScooterStartingPosition = startingPosition;
		IsRentalFinished = false;
	}

	public void EndRent(decimal chargeAmount, int rentalTime, int loyaltyPointsGain, Position closingScooterPosition)
	{
		ChargeAmount = chargeAmount;
		RentalTime = rentalTime;
		LoyaltyPointsGain = loyaltyPointsGain;
		LastRentScooterPosition = closingScooterPosition;
		IsRentalFinished = true;
		PaymentStatus = PaymentStatusType.Pending;
	}
}



public enum PaymentStatusType
{
	Pending,
	Failed,
	Succeed
}