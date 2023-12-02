public class MyScooter : IElectricScooter
{
	public long ScooterId { get; private set; }
	public decimal PricePerMinute { get; private set; }
	public decimal UnlockingPrice { get; private set; }
	public bool IsScheduledForMaintenance { get; private set; }
	public float BatteryLevel { get; private set; }
	public Position LastPosition {  get; set; }
	public IScooterData Data { get; private set; }

	private IMaintenanceService _maintenanceService;

	public MyScooter(IScooterData data, IMaintenanceService maintenanceService, Position startingPosition, decimal pricePerMinute, decimal unlockingPrice)
	{
		this.Data = data;
		_priceService = priceService;
		_maintenanceService = _maintenanceService.ScheduleForMaintenance();
		LastPosition = startingPosition;
		UnlockingPrice = unlockingPrice;
		PricePerMinute = pricePerMinute;

		IsScheduledForMaintenance = _maintenanceService.Schedule(_position);
	}
}
