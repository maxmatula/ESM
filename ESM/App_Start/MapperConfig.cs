using AutoMapper;
using ESM.Models;
using ESM.ViewModels.Employees;

namespace ESM
{
    public partial class Startup
    {
        public void MapperInitialize()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Employee, EmployeeViewModel>()
                    .ForMember(m => m.Earnings, x => x.Ignore())
                    .ForMember(g => g.Agreements, x => x.Ignore());

            });
        }
    }
}
