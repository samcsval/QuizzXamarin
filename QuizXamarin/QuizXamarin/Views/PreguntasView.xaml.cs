using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuizXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PreguntasView : ContentPage
    {
        public PreguntasView()
        {
            InitializeComponent();
            BindingContext =new ViewModels.PreguntasViewModel(Navigation);
        }
    }
}