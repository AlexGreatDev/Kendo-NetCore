using AutoMapper;
using Core.Common.DTOs.Employee;
using KendoCRUD.Models.Employee;

namespace KendoCRUD.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeDto, EmployeeViewModel>();
            CreateMap<EmployeeViewModel, EmployeeDto>();
        }
    }
}
