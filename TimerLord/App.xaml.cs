namespace TimerLord
{
    public partial class App
    {
        private void Application_Exit(object sender, System.Windows.ExitEventArgs e)
        {
            TimerLord.Properties.Settings.Default.Save();
        }
    }
}