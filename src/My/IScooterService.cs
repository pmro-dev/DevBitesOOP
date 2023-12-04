public interface IScooterService
{
	public bool Release(long scooterId);
	public Position GetPosition(long scooterId);
	public void Book(long scooterId);
	public Scooter LoadScooter(long scooterId);
	public void SetMaintenancyAsRequired(long scooterId);
}
