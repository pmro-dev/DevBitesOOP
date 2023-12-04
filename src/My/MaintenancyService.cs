public class MaintenancyService : IMaintenancyService
{
	private IScooterService _scooterService;
	private IScooter _scooter;

    public MaintenancyService(IScooterService scooterService)
    {
		_scooterService = scooterService;
		_scooter = _scooterService.
	}

    public void Schedule(long scooterId)
	{
		if (IsMaintenancyRequired(scooterId))
		{
			_scooterService.SetMaintenancyAsRequired(scooterId);
		}
	}

	public bool IsMaintenancyRequired(long scooterId)
	{
		bool maintenanceStatus = false;

		float batteryLevel = _scooterService.GetEnergyLevel(scooterId);

		if (batteryLevel < 0.07)
		{
			maintenanceStatus = true;
		}

		return maintenanceStatus;
	}
}
