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
                var responseMessage = await httpClient.PostAsync("https://localhost:44387/productreservations/", stringContent);
                using var readResponse = responseMessage.Content.ReadAsStreamAsync().Result;
                var json = JsonSerializer.DeserializeAsync<ReserveProductResponse>(readResponse,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }).Result;
                var result = json.Id;
                return result;
                
            }
            catch (Exception ex)
            {               
            }
            return default;
        }
    }
}
