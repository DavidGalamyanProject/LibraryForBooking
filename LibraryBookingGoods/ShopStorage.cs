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
        public async Task<Guid> ReservProduct(string nameProduct,int quantityReserv)
        {
            var requestReserv = new ReservRequest() { ProductName = nameProduct, Quantity = quantityReserv };
            var httpClient = new HttpClient();
            var stringContent = new StringContent(JsonSerializer.Serialize(requestReserv), Encoding.UTF8, "application/json");            
            try
            {
                var responseMessage = await httpClient.PostAsync("https://localhost:44387/reservations/", stringContent);
                using var readResponse = await responseMessage.Content.ReadAsStreamAsync();
                var json = await JsonSerializer.DeserializeAsync<ReserveResponse>(readResponse,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                var result = json.Id;
                var responseMessage2 = await httpClient.GetAsync($"https://localhost:44387/reservations/{result}");
                using var readResponse2 = await responseMessage.Content.ReadAsStreamAsync();
                var json2 = await JsonSerializer.DeserializeAsync<string>(readResponse2,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                if(json2 == "Неверный Guid")
                return result;

            }
            catch (Exception ex)
            {
                return default;
            }
            
        }
    }
}
