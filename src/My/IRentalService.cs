public interface IRentalService
{
	public void StartNewRental(long clientId, long scooterId);
	public void EndRentalWithSummary();
}
