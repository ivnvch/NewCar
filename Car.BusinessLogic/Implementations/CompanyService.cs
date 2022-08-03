 using AutoMapper;
using Car.BusinessLogic.Contracts;
using Car.Model;
using Car.Model.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Car.BusinessLogic.Implementations
{
    public class CompanyService : ICompanyService
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        public CompanyService(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Create(CompanyViewModel company)
        {
            var comp = _mapper.Map<CompanyViewModel, Company>( company );
            _context.Companies.Add(comp);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var company = _context.Companies.FirstOrDefault(x => x.Id == id);
            if (company != null)
            {
                _context.Companies.Remove(company);
                _context.SaveChanges();
            }
            throw new Exception("Company not exist!");
        }

        public IEnumerable<CompanyViewModel> Gets()
        {
            //var list = new List<CompanyViewModel>();
            //foreach (var company in _context.Companies)
            //{
            //    list = _context.Companies.AsNoTracking().ToList();
            //}
            //var  copmanies?? = _mapper.Map<IEnumerable<Company>>, List<CompanyViewModel>> (_context.);
            //return copmanies;
           //return _context.Companies.AsNoTracking().ToList();
           var companies = _context.Companies.AsNoTracking().ToList();
           var companiesView = _mapper.Map<IEnumerable<CompanyViewModel>>(companies);
           return companiesView;
        }

        public CompanyViewModel Get(int id)
        {
            var company = _context.Companies.FirstOrDefault(x => x.Id == id);
            var companyView = _mapper.Map<CompanyViewModel>(company);
            return companyView;
        }

        public void Update(int id, CompanyViewModel companyView)
        {
            //Company salon = _context.Companies.FirstOrDefault(s => s.Id == id);
            //if (salon == null) throw new Exception("Object = null");
            //else _context.Update(salon);
            var comp = _mapper.Map<CompanyViewModel, Company>(companyView);
            _context.Update(comp);
            _context.SaveChanges();
        }
    }
}
