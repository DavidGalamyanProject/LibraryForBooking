using LibraryBookingGoods.Dto;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LibraryBookingGoods
{
    public class ShopStorage
    {
        private readonly string _url = "https://localhost:44387/reservations";
        private static HttpClient _client = new HttpClient();
        /// <summary> Резервируем товар на сервере </summary>
        public async Task<Guid> ReservProduct(string nameProduct, int quantityReserv)
        {

            var requestReserv = new ReservRequest()
            {
                ProductName = nameProduct,
                Quantity = quantityReserv
            };
            var stringContent = new StringContent(JsonSerializer.Serialize(requestReserv), Encoding.UTF8, "application/json");

            var responseMessage = await _client.PostAsync(_url, stringContent);
            using var readResponse = await responseMessage.Content.ReadAsStreamAsync();
            var json = await JsonSerializer.DeserializeAsync<ReserveResponse>(readResponse,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return json.Id;
        }
        /// <summary> Проверка на успешный резерв </summary>
        public async Task<string> CheckReserv(Guid id)
        {
            var responseMessage = await _client.GetAsync($"{_url}/id/{id}");
            if (!responseMessage.IsSuccessStatusCode)
            {
                return "Не удалось зарезервировать товар";
            }
            return "Товар был зарезервирован";
        }

    }
}
