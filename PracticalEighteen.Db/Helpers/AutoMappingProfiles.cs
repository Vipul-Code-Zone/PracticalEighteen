using AutoMapper;
using PracticalEighteen.Models.Models;
using PracticalEighteen.Models.ViewModels;

namespace PracticalEighteen.Db.Helpers
{
    public class AutoMappingProfiles : Profile
    {
        public AutoMappingProfiles()
        {
            CreateMap<Student, StudentModel>().ReverseMap();
        }
    }
}
