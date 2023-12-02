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
		_scooterService.Book(scooterId);
		Position startingPoint = scooter.LastPosition;
		_client = _clientService.LoadClient(clientId);

		_rentalData.OpenRent(startingPoint);
		_stoper.Begin();
	}

	public IRentalData EndRentalWithSummary()
	{
		_stoper.End();
		int rentalTime = _stoper.GetMinutes();
		decimal chargeAmount = _chargeService.Calculate(rentalTime, _scooter.PricePerMinute, _scooter.UnlockingPrice, _client.IsImmediate, _client.ClientCredit);
		int loyaltyPointsGain = _loyaltyService.CalculatePoints(rentalTime, _client.IsImmediate, chargeAmount);
		Position endPosition = _scooterService.GetPosition(scooterId);

		SetTransactionDataBasedOnPeriodType();

		_rentalData.CloseRent(chargeAmount, rentalTime, loyaltyPointsGain, endPosition);

		_scooterService.Release(_scooter.ScooterId);
		_paymentService.Charge(_rentalData);

		bool isSaved =; // save to database rental data

		return GetRentalSummary(isSaved) ?? // throw and log;
	}


	private void SetTransactionDataBasedOnPeriodType()
	{
		if (_client.IsImmediate)
		{
			_client.ImmediateTransactionsCounter++;
		}
		else
		{
			_client.MonthlyPaymentDescriptions.add(_scooter.Data.Description);
		}
	}


	private IRentalData? GetRentalSummary(bool isSaved)
	{
		if (_rentalData.IsRentalFinished && isSaved)
		{
			return _rentalData;
		}

		return null;
	}

}
