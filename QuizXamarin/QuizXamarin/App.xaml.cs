using QuizXamarin.Interfaces;
using QuizXamarin.Language;
using QuizXamarin.Views;
using Xamarin.Forms;

namespace QuizXamarin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            

            App.Current.MainPage = new Views.YoutubePlayerHibrid(); //new MDLandingPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
