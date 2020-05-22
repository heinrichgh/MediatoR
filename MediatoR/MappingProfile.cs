using System;
using System.Linq;
using System.Reflection;
using AutoMapper;
using MediatoR.Controllers;
using MediatoR.CQRS;
using MediatoR.Mappings;

namespace MediatoR
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // CreateMap<TestResponse, TestVm>();
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(t => IsSubclassOfRawGeneric(typeof(MapFrom<>), t) && !t.IsAbstract)
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);

                var methodInfo = type.GetMethod("Mapping");

                methodInfo?.Invoke(instance, new object[] {this});
            }
        }
        
        private static bool IsSubclassOfRawGeneric(Type generic, Type toCheck) {
            while (toCheck != null && toCheck != typeof(object)) {
                var cur = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
                if (generic == cur) {
                    return true;
                }
                toCheck = toCheck.BaseType;
            }
            return false;
        }
    }
}