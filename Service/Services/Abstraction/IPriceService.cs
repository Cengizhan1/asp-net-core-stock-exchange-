using Entity.Entities;

namespace Service.Services.Abstraction
{
    public interface IPriceService
    {
        Task<List<Price>> GetAllPrice();
        Task AddPrice(Price price);

    }
}
