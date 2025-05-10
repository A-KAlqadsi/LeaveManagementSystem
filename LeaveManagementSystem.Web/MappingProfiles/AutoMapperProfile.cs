using AutoMapper;
using LeaveManagementSystem.Domain;
using LeaveManagementSystem.Web.Models.LeaveTypes;

namespace LeaveManagementSystem.Web.MappingProfiles
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<LeaveType, LeaveTypeReadOnlyVM>();
			CreateMap<LeaveTypeCreateVM, LeaveType>();
			CreateMap<LeaveTypeEditVM, LeaveType>().ReverseMap();
			// if there is property has different name 
			//.ForMember(dest => dest.Days, opt => opt.MapFrom(src => src.NumberOfDays));
		}
	}
}
