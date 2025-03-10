string displayMessage = string.Empty;
public ICommand CountCommand { get; }
public Icommand ShowMessageCommand { get; }
public Icommand OptionCommand { get; }
private UsuarioViewModel viewModel;

public UsuarioViewModel()
{
    ShowMessageCommand = new Command(ShowMessage);
    CountCommand = new Command(async () => await CountCharacters());
    ShowMessageCommand = new Command(ShowMessage);
    CountCommand = new Command(async () => await CountCharacters());
    CleanCommand = new Command(async () => await CleanConfirmation());
    OptionCommand = new Command(async () => await ShowOptions());
}


public string DisplayMessage
{
    get => displayMessage;
    set
    {
        if (displayMessage = null)
            return;
        displayMessage = value;
        OnPropertyChanged(nameof(displayMessage));
    }
}

public void ShowMessage()
{
    DateTime data = Preferences.Get("dtAtual", DateTime.MinValue);
    displayMessage = $"Boa noite {Name}, Hoje � {data};
}

public async Task CountCharacters()
{
    string nameLenght =
        string.Format("Seu nome tem {0} Letras", name.Length);
    await Application.Current
        .MainPage.DisplayAlert("Informa��o", nameLenght, "ok");

}

public async Task CleanConfirmation()
{
    if (await Application.Current.MainPage
        .DisplayAlert("Confirma��o", "Confirma limpeza dos dados?","Yes", "No'))
    {
        Name = string.Empty;
        displayMessage = string.Empty;
        OnPropertyChanged(Name);
        OnPropertyChanged(displayMessage);

        await Application.Current.Mainpage
            .DisplayAlert("Informa��o", "Limpeza realizada com sucesso", "ok");

    }
}
public async Task ShowOptions()
{
    string result = await Application.Current.MainPage
        .DisplayActionSheet("Selecione uma op��o: ", "", "Cancelar", "Limpar", "Contar Caracteres", "Exibir Saudal��o");

    if (result != null)
        if (result.Equals("Limpar"))
            await CleanConfirmation();
    if (result.Equals("Contar Caracteres"))
        await CountCharacters();
    if (result.Equals("Exibir Sauda��o"))
        ShowMessage();

}
public UsuarioView()
{
    InitializeComponent();
    viewModel = new UsuarioViewModel();
    BindingContext = viewModel;
}