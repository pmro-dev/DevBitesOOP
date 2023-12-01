public class MyScooter : IElectricScooter
{
	long ScooterId { get; private set; }
	decimal PricePerMinute { get; private set; }
	decimal UnlockingPrice { get; private set; }
	bool IsScheduledForMaintenance { get; private set; }
	float BatteryLevel { get; private set; }
	private IScooterData _scooterData;
	private IMaintenanceService _maintenanceService;
	public Position LastPosition {  get; set; }

	public MyScooter(IScooterData data, IMaintenanceService maintenanceService, Position startingPosition, decimal pricePerMinute, decimal unlockingPrice)
	{
		_scooterData = data;
		_priceService = priceService;
		_maintenanceService = _maintenanceService.ScheduleForMaintenance();
		LastPosition = startingPosition;
		UnlockingPrice = unlockingPrice;
		PricePerMinute = pricePerMinute;

		IsScheduledForMaintenance = _maintenanceService.Schedule(_position);
	}
}
