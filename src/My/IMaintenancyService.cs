public interface IMaintenancyService
{
	public void Schedule(long scooterId, Position lastPosition);
	public bool IsMaintenancyRequired(long scooterId);
}