using QuizXamarin.Models;
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
    public partial class SendAnswerView : ContentPage
    {
        public SendAnswerView()
        {
            InitializeComponent();
           new Timer(data=>App.Current.MainPage=new Views.YoutubePlayerHibrid(),null,3000,0);
        }
    }
}