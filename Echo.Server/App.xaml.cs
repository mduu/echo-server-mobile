using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Echo.Server.Services;
using Echo.Server.Views;

namespace Echo.Server
{
    public partial class App : Application
    {
        private readonly TcpServer server = new TcpServer();

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            server.Start().GetAwaiter().GetResult();
        }

        protected override void OnSleep()
        {
            server.Pause().GetAwaiter().GetResult();
        }

        protected override void OnResume()
        {
        }
    }
}
