public class RentalService : IRentalService
{
	private IRentalData _rentalData;
	private IClient _client;
	private IScooter _scooter;
	private IStoper _stoper;
	private IChargeService _chargeService;
	private IPaymentService _paymentService;
	private ILoyaltyService _loyaltyService;
	private IClientService _clientService;
	private IScooterService _scooterService;

	public RentalService(IStoper stoper, IChargeService chargeService, IPaymentService _paymentService, 
		ILoyaltyService loyaltyService, IClientService clientService, IScooterService scooterService)
	{
		_stoper = stoper;
		_chargeService = chargeService;
		_loyaltyService = loyaltyService;
		_clientService = clientService;
		_scooterService = scooterService;
	}
	
	public void StartNewRental(long clientId, long scooterId)
	{
		_rentalData = new RentalData(_clientId, _scooterId);
		_scooter = _scooterService.LoadScooter(scooterId);
		_client = _clientService.LoadClient(clientId);

		Position startingPoint = scooter.LastPosition;
		_rentalData.OpenRent(startingPoint);
		_stoper.Begin();
	}

	public IRentalData EndRentalWithSummary()
	{
		_stoper.End();
		int rentalTime = _stoper.GetMinutes();
		int loyaltyPointsGain = _loyaltyService.CalculatePoints(rentalTime, _client.IsImmediate);
		decimal chargeAmount = _chargeService.Calculate(rentalTime, _scooter.PricePerMinute, _scooter.UnlockingPrice, _client.IsImmediate);
		Position endPosition = _scooterService.GetPosition(scooterId);
		_rentalData.CloseRent(chargeAmount, rentalTime, loyaltyPointsGain, endPosition);

		_scooterService.Release(scooterId);
		_paymentService.Charge(_rentalData);

		return GetRentalSummary() ?? // throw and log;
	}

	private IRentalData? GetRentalSummary()
	{
		if (_rentalData.IsRentalFinished)
		{
			return _rentalData;
		}

		return null;
	}
}
