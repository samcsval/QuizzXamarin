using QuizXamarin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuizXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class YoutubePlayerHibrid : ContentPage
    {
        public YoutubePlayerHibrid()
        {
            InitializeComponent();
            BindingContext=new ViewModels.VideoViewModel(Navigation);
            // string idVideo = "sts02Xx84jo";
           // CargarVideo();
          hybridWebView.RegisterAction(data =>AbrirPreguntas());
        }

      

        private void AbrirPreguntas()
        {
           // var resp = DisplayAlert("Ir a Preguntas", "Desea ir a las preguntas, no podra volver a ver el video", "Ok", "Regresar").Result;
           
                Task.Run(async () =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    //Application.Current.MainPage = new Views.PreguntasView();
                    boton.IsVisible = true;
                });
            });
            
        }

        private void btnPlay_Clicked(object sender, EventArgs e)
        {
         
        }

        //private void boton_Clicked(object sender, EventArgs e)
        //{
        //    Navigation.PushModalAsync(new NavigationPage(new PreguntasView()));
        //}
    }
}