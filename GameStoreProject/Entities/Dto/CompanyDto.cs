using Core.Entities.Abstract;

namespace Entities.Dto
{
    public class CompanyDto : UserDto, IDto
    {
        public string Name { get; set; }
        public string Website { get; set; }
    }
}
