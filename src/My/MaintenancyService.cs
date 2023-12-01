public class MaintenancyService : IMaintenancyService
{
	private IScooterService _scooterService;
	private IScooter _scooter;

    public MaintenancyService(IScooterService scooterService)
    {
		_scooterService = scooterService;
		_scooter = _scooterService.
	}

    public void Schedule(long scooterId, Position lastPosition)
	{
		IsMaintenancyRequired(scooterId);
	}

	public bool IsMaintenancyRequired(long scooterId)
	{
		float batteryLevel = _scooterService.GetEnergyLevel(scooterId);

		if (batteryLevel < 0.07)
		{
			_scooterService.MaintenancyRequired(scooterId);
		}

		return scheduleForMaintenance;
	}
}
