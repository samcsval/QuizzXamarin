using Newtonsoft.Json;
using QuizXamarin.Constantes;
using QuizXamarin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace QuizXamarin.Services
{
    public class ApiService
    {
        public async Task<VideoLink> ObtenerVideoAsync()
        {
            var videos = await ObtenerValoresServicioApi<VideoLink>("VideoLinks");
           var valor= new Random().Next(videos.Count);
            var videoRetorno = videos.ElementAtOrDefault(valor);
            if (videoRetorno == null)
                return videos.First();
            return videoRetorno;
        }
        public async Task<List<QuestionResponse>> ObtenerPreguntas()
        {
            var preguntas = await ObtenerValoresServicioApi<QuestionResponse>("Questions");
            
            return preguntas;
        }
        public VideoLink ObtenerVideo()
        {
            var videos =Task.Run(async()=>await ObtenerValoresServicioApi<VideoLink>("VideoLinks")).Result;
            var valor = new Random().Next(videos.Count);
            var videoRetorno = videos.ElementAtOrDefault(valor);
            if (videoRetorno == null)
                return videos.First();
            return videoRetorno;
        }
        public async Task<string> PostUserAnswerAsync(List<UserQuestionAnswer> _userQuestionAnswer)
        {
            try
            {
                var ruta = new Uri(Configuracion.ServicioWeb + "/api/Questions/PostUserAnswers?id=1");
                var jsonRequest = JsonConvert.SerializeObject(_userQuestionAnswer);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                var client = new HttpClient();
                // client.BaseAddress= new Uri(Configuration.RouteServiceWeb+ "/odata/Prescriptions");
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                //    "Bearer", TokenReturnStatic.access_token);
                var json = await client.PostAsync(ruta, content);

                if (json.IsSuccessStatusCode)
                    return "";
                else
                {
                    return json.StatusCode.ToString();
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
        private static async Task<List<T>> ObtenerValoresServicioApi<T>( string _controller,string _api="", string _action="", string _id="", string _secondParameter="")
        {
            try
            {
                if (_api == "")
                {
                    _api = "api";
                }

                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                //    "Bearer", TokenReturnStatic.access_token);
                string ruta = Configuracion.ServicioWeb + "/" + _api + "/" + _controller;
                if (_action != "")
                {
                    ruta += "/" + _action;
                }
                if (_id != "")
                {
                    ruta += "/" + _id;
                }
                if (_secondParameter != "")
                {
                    ruta += "/" + _secondParameter;
                }

                var json = await client.GetStringAsync(ruta);
                
                var prescripciones = JsonConvert.DeserializeObject<List<T>>(json);
                //var value = new List<T>();
                // value.Add(prescripciones);
                return prescripciones;
            }
            catch (Exception ex)
            {
                return new List<T>();
            }
        }
    }
}
