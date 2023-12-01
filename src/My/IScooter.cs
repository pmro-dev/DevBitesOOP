public interface IScooter
{
	decimal Price { get; private set; }
	bool IsScheduledForMaintenance { get; private set; }

	public void Release(Position where);
}


public interface IElectricScooter : IScooter
{
	float BatteryLevel { get; private set; }
}