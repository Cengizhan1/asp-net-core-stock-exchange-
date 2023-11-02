using Data.UnitOfWorks;
using Entity.Entities;
using Service.Services.Abstraction;


namespace Service.Services.Concretes
{
    public class PriceService : IPriceService
    {
        private readonly IUnitOfWork unitOfWork;
        public PriceService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task AddPrice(Price price)
        {
             await unitOfWork.GetRepository<Price>().AddAsync(price);
        }
        public async Task<List<Price>> GetAllPrice()
        {
            return await unitOfWork.GetRepository<Price>().GetAll();
        }
    }
}
