public interface IMaintenancyService
{
	public void Schedule(long scooterId);
	public bool IsMaintenancyRequired(long scooterId);
}