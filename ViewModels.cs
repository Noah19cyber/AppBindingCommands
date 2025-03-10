public class UsuarioViewModel : INotifyPropetyChanged
{
	public event PropertyChangedEventHandles PropertyChanged;

	void OnPropertyChanged(string propertyName)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

	}
	private string name = string.Empty;
	public string Name
	{
		get => name;
		set
		{
			if (name == null)
				return;
			name = value;
			OnPropertyChanged(nameof(name));

		}
	public string DisplayName => $"Nome digitado : {Name}";
	public string Name
	{
		get => name;
		set
		{
			if (name == null)
				return;
			name = value;
			OnPropertyChanged(nameof(Name));
			OnPropertyChanged(nameof(DisplayName));

		}
	}
	}
}