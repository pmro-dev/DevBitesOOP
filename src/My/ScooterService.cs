public class ScooterService : IScooterService
{
	private ILocalizationService _localizationService;
	private IMaintenanceService _maintenanceService;

	public ScooterService(ILocalizationService localizationService, IMaintenanceService maintenanceService)
    {
		_localizationService = localizationService;
		_maintenanceService = maintenanceService;
	}

    public bool Release(long scooterId)
	{
		Position lastPosition = GetPosition(scooterId);
		_maintenanceService.Schedule(scooterId, lastPosition);
		return true;
	}

	public Position GetPosition(long scooterId)
	{
		return _localizationService.Localize(scooterId);
	}

	public Scooter LoadScooter(scooterId)
	{
		Scooter scooter =;
		// database etc

		return scooter
	}
}
