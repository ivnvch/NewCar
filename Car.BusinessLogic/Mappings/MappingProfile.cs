using AutoMapper;
using Car.Model;
using Car.Model.ViewModel;
using Car.ViewModel;


namespace Car.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CarC, CarViewModel>().ReverseMap();
            CreateMap<Company,CompanyViewModel>().ReverseMap();
            CreateMap<Person,RegisterView>();
        }
    }
}
