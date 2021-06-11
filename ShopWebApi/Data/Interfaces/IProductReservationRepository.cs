using ShopWebApi.Model;
using ShopWebApi.Model.Dto;
using System.Threading.Tasks;

namespace ShopWebApi.Data.Interfaces
{
    public interface IProductReservationRepository
    {
        void CreateReserve(ReservedProducts product);
    }
}
