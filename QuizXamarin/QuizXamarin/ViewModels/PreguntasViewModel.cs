using QuizXamarin.Models;
using QuizXamarin.Services;
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
   public class PreguntasViewModel:INotifyPropertyChanged
    {
        INavigation navigation;
        ApiService _apiService = new ApiService();
        public PreguntasViewModel(INavigation _navigation)
        {
            navigation = _navigation;
            CargarPreguntas();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<QuestionResponse> questionResponses;

        public ObservableCollection<QuestionResponse> QuestionResponses
        {
            get { return questionResponses; }
            set { questionResponses = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Grouping<QuestionChecked,AnswerChecked>> questionAnswers;

        public ObservableCollection<Grouping<QuestionChecked,AnswerChecked>> QuestionAnswersGroup
        {
            get { return questionAnswers; }
            set { questionAnswers = value;
                OnPropertyChanged();
            }
        }

        private bool isRefreshing=false;

        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set { isRefreshing = value;
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


        public ICommand SalvarRespuestasCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await SalvarPreguntas();
                }, () => !IsBusy);
            }

        }

        private async Task SalvarPreguntas()
        {
            if (IsBusy == false)
            {
                IsBusy = true;
                List<QuestionChecked> qc = new List<QuestionChecked>();
                List<AnswerChecked> ac = new List<AnswerChecked>();
                foreach (var item in QuestionAnswersGroup)
                {
                    var valor = item.ToList();
                    ac.AddRange(valor.Where(x => x.CheckedAnswer).ToList());
                    qc.Add(new QuestionChecked
                    {
                        QuestionId = item.Key.QuestionId,
                        QuestionString = item.Key.QuestionString,
                        Answers = valor
                    });
                }
                List<UserQuestionAnswer> uqas = new List<UserQuestionAnswer>();
                foreach (var item in ac)
                {
                    uqas.Add(new UserQuestionAnswer
                    {
                        AnswerId = item.AnswerId,
                        QuestionId = item.QuestionId,
                        UserId = 1,
                        UserQuestionAnswerId = new Random().Next(),
                        Answer = item,
                        Question = item.Question,
                        User = new User() { UserId = 1 }
                    });
                }
                await _apiService.PostUserAnswerAsync(uqas);
                await navigation.PushAsync(new Views.SendAnswerView());
                IsBusy = false;
            }
        }

        private async Task CargarPreguntas()
        {
            IsRefreshing = true;
            var preguntas = await _apiService.ObtenerPreguntas();
            QuestionResponses =new ObservableCollection<QuestionResponse>();
            foreach (var item in preguntas)
            {
                QuestionResponses.Add(item);
            }
            QuestionAnswersGroup = new ObservableCollection<Grouping<QuestionChecked, AnswerChecked>>();
            foreach (var item in preguntas)
            {
                ObservableCollection<AnswerChecked> answerCheckeds = new ObservableCollection<AnswerChecked>();
                foreach (var item2 in item.Answers)
                {
                    answerCheckeds.Add(new AnswerChecked {
                     AnswerId =item2.AnswerId,
                     AnswerString=item2.AnswerString,
                     IsCorrect=item2.IsCorrect,
                     QuestionId=item2.QuestionId,
                     CheckedAnswer=false});
                }
                QuestionChecked key = new QuestionChecked { QuestionId=item.QuestionId, QuestionString=item.QuestionString, Answers=answerCheckeds };
                QuestionAnswersGroup.Add(new Grouping<QuestionChecked, AnswerChecked>(key,key.Answers));
            }
            IsRefreshing = false;
        }
    }
}
