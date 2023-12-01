public interface IScooterService
{
	public bool Release(long scooterId);
	public Position GetPosition(long scooterId);
}
