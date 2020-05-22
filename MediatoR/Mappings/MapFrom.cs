using AutoMapper;

namespace MediatoR.Mappings
{
    public abstract class MapFrom<T>
    {
        public void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}