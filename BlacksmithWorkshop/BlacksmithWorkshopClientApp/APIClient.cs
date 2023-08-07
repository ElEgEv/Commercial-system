using BlacksmithWorkshopContracts.ViewModels;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace BlacksmithWorkshopClientApp
{
    //класс, который общается с RestAPI. Под клиентом тут подразумевается клиент, общающийся с API, а не созданный нами
    public class APIClient
    {
        private static readonly HttpClient _client = new();

        //поле, хранящее клиента, которого необходимо авторизовать
        public static ClientViewModel? Client { get; set; } = null;

        //для пагинации
        public static int CurrentPage { get; set; } = 0;

        public static void Connect(IConfiguration configuration)
        {
            _client.BaseAddress = new Uri(configuration["IPAddress"]);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        //Get-запрос
        public static T? GetRequest<T>(string requestUrl)
        {
            var response = _client.GetAsync(requestUrl);
            var result = response.Result.Content.ReadAsStringAsync().Result;

            if (response.Result.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<T>(result);
            }
            else
            {
                throw new Exception(result);
            }
        }

        //Post-запрос
        public static void PostRequest<T>(string requestUrl, T model)
        {
            var json = JsonConvert.SerializeObject(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = _client.PostAsync(requestUrl, data);

            var result = response.Result.Content.ReadAsStringAsync().Result;

            if (!response.Result.IsSuccessStatusCode)
            {
                throw new Exception(result);
            }
        }
    }
}
