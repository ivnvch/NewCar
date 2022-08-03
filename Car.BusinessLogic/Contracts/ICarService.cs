using Car.Model;
using Car.ViewModel;

namespace Car.BusinessLogic.Contracts
{
    public interface ICarService
    {
        IEnumerable<CarViewModel> Gets();
        CarViewModel Get(int id);
        void Create(CarViewModel carView);
        void Update(int id, CarViewModel carView);
        void Delete(int id);
    }
}
