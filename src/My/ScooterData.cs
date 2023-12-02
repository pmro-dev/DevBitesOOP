public class ScooterData : IScooterData
{
	string Name { get; private set; }
	string SpeedMode { get; private set; } = string.Empty;
	bool IsAvailable { get; set; } = true;

	private string _description = string.Empty;
	private long _scooterId;

	string Description {
		get
		{
			if (string.IsNullOrEmpty(_description))
			{
				_description = GenerateDetailedDescription();
				return this._description;
			}
		};
		private set
		{
			_description = value;
		}; 
	};

	public ScooterData(long scooterId, string name, string speedMode, string description)
	{
		Name = name;
		SpeedMode = speedMode;
		Description = description;
		_scooterId = scooterId;
	}

	public ScooterData(long scooterId, string name, string speedMode)
	{
		Name = name;
		SpeedMode = speedMode;
		_scooterId = scooterId;
	}

	private string GenerateDetailedDescription()
	{
        return _scooterId + " " + this.SpeedMode;
	}
}
