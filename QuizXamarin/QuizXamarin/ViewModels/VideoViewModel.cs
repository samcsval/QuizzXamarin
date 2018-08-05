using QuizXamarin.Models;
using QuizXamarin.Services;
using QuizXamarin.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace QuizXamarin.ViewModels
{
    public class VideoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        ApiService _apiService = new ApiService();
        private INavigation Navigation;

        public VideoViewModel(INavigation navigation)
        {
            Navigation = navigation;
           //var asynTask=new Task(async() => await CargarVideo());
           // asynTask.RunSynchronously();
            CargarVideo();
        }
      
        private void CargarVideo()
        {
            try
            {


                VideoActual = _apiService.ObtenerVideo();
                if (VideoActual != null || VideoActual.Link != "")
                {
                    string reg = Regexs.YoutubeRegex.ObtenerId(VideoActual.Link);
                    string _html = @"<html>
<head>
   <style>
body {
   background-color: ";
                    _html += Application.Current.Resources["BackGroundColor"];
                   _html+= @" ;
  
}

   .buttonPlay {
    background-color: #4CAF50; /* Green */
    border: none;
    width:40%;
    color: white;
    padding: 32px 16px;
    text-align: center;
    text-decoration: none;
    display: inline-block;
    font-size: 20px;
 margin: 25px 0px 0px;
}
   .buttonStop {
    background-color: #f44336; /* Green */
    border: none;
    width:15%;
    color: white;
    padding: 32px 16px;
    text-align: center;
    text-decoration: none;
    display: inline-block;
    font-size: 20px;
 margin: 25px 0px 0px;
}
   .buttonPause {
    background-color: #008CBA; /* Green */
    border: none;
    width:15%;
    color: white;
    padding: 32px 16px;
    text-align: center;
    text-decoration: none;
    display: inline-block;
    font-size: 20px;
    margin: 25px 0px 0px;
}
   </style>
</head>
                                <body>
<div id='player'></div>
<script src='http://www.youtube.com/player_api'></script>
 <script>

                                     // create youtube player
                                     var player;
                                            function onYouTubePlayerAPIReady()
                                            {
                                                player = new YT.Player('player', {
                                            
                                          videoId: '";
                    _html += reg;
                    _html += @"',playerVars: { 
                                                controls: '1', 
                                                rel : '0',
                                                fs : '0',
                                                list:'user'
                                            },
                                  events:
                                    {
                                        'onReady': onPlayerReady,
                                    'onStateChange': onPlayerStateChange
                                  }
                                });
                            }

                            // autoplay video
                            function onPlayerReady(event)
                            {
                                event.target.playVideo();
                            }

                            // when video ends
                            function onPlayerStateChange(event)
                            {
                                if (event.data === 0) {
                                    invokeCSharpAction(event);
                                }
                            }
                            function onPlay() {

                                player.playVideo();

                            }
          function onStop() {

                                player.stopVideo();

                            }
         function onPause() {

                                player.pauseVideo();

                            }
                            </script>
                        </body>
                        </html>
                        ";

                    CodigoHtml = _html;

                }
            }
            catch (Exception ex)
            {

            }
        }
        private ObservableCollection<VideoLink> videos;

        public ObservableCollection<VideoLink> Videos
        {
            get { return videos; }
            set { videos = value;
                OnPropertyChanged();
            }
        }
        private VideoLink video;

        public VideoLink VideoActual
        {
            get { return video; }
            set { video = value;
                OnPropertyChanged();
            }
        }
        private bool isBusy;

        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value;
                OnPropertyChanged();
            }
        }
        private  bool btnPreguntasVisible;

        public bool BtnPreguntasVisible
        {
            get { return btnPreguntasVisible; }
            set
            {
                btnPreguntasVisible = value;
                OnPropertyChanged();
            }
        }

        private string codigoHtml;

        public string CodigoHtml
        {
            get { return codigoHtml; }
            set { codigoHtml = value;
                OnPropertyChanged();
            }
        }


        public ICommand AbrirPreguntasCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await AbrirPreguntas();
                }, () => !IsBusy);
            }

        }

        private async Task AbrirPreguntas()
        {
          await  Navigation.PushModalAsync(new NavigationPage(new PreguntasView()));
        }
    }
}
