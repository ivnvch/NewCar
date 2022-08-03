using Car.Model;
using Car.Model.ViewModel;

namespace Car.BusinessLogic.Contracts
{
    public interface ICompanyService
    {
        IEnumerable<CompanyViewModel> Gets();
        CompanyViewModel Get(int id);
        void Create(CompanyViewModel companyView);
        void Update(int id, CompanyViewModel companyView);
        void Delete(int id);
    }
}
