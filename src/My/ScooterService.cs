public class ScooterService : IScooterService
{
	private ILocalizationService _localizationService;
	private IMaintenanceService _maintenanceService;

	public ScooterService(ILocalizationService localizationService, IMaintenanceService maintenanceService)
    {
		_localizationService = localizationService;
		_maintenanceService = maintenanceService;
	}

	public void Book(long scooterId)
	{
		// check if scooter is available,
		// then set Scooter.IsAvailable to false and save to db
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
