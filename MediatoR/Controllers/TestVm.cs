using System;
using AutoMapper;
using MediatoR.CQRS;
using MediatoR.Mappings;

namespace MediatoR.Controllers
{
    public class TestVm : MapFrom<TestResponse>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string BinaryAge { get; set; }
        public bool ThisIsADto { get; set; } = true;

        public new void Mapping(Profile profile)
        {
            profile.CreateMap<TestResponse, TestVm>()
                .ForMember(d => d.BinaryAge, 
                    opt => 
                        opt.MapFrom(s => Convert.ToString(s.Age, 2)));
        }
    }
}