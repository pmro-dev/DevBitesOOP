public interface IScooter
{
	public long ScooterId { get; private set; }
	public decimal PricePerMinute { get; private set; }
	public decimal UnlockingPrice { get; private set; }
	public bool IsScheduledForMaintenance { get; private set; }
	public Position LastPosition { get; set; }
	public IScooterData Data { get; private set; }
}


public interface IElectricScooter : IScooter
{
	float BatteryLevel { get; private set; }
}