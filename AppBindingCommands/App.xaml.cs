namespace AppBindingCommands
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DateTime data = DateTime.Now;
            Preferences.set("dtAtual", data);
            Preferences.set("AcaoInicial", string.Format("* App executado às {0}. /n", data));

            MainPage = new AppShell();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
        protected override void OnStart()
        {
            base.OnStart();
            Preferences.Set("AcaoStart", string.Format("* App iniciado às {0}. /n", DateTime.Now));

        }
        protected override void OnSleep()
        {
            base.OnSleep();
            Preferences.Set("AcaoSleep", string.Format("* App em segundos plano às {0}. /n", DateTime.Now));

        }
        protected override void OnResume()
        {
            base.OnResume();
            Preferences.Set("AcaoResume", string.Format("* App reatividade às {0}. /n", DateTime.Now));

        }
        private void btnAtualizarInformacoes_Clicked(object sender, EventArgs e)
        {
            string informacoes = string.Empty;
            if (Preferences.ContainsKey("AçãoInicial"))
                informacoes += Preferences.Get("AcaoInicial", string.Empty);
            if (Preferences.ContainsKey("AcaoStart"))
                informacoes += Preferences.Get("AcaoStart", string.Empty);
            if (Preferences.ContainsKey("AcaoSleep"))
                informacoes += Preferences.Get("AcaoSleep", string Empty);
            if (Preferences.ContainsKey("AcaoResume"))
                informacoes += Preferences.Get("AcaoResume", string Empty);

            lblInformacoes.Text = informacoes;
        }
    }
}