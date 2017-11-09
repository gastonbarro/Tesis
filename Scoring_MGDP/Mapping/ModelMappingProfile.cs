using AutoMapper;
using PagedList;
using Scoring_MGDP.ViewModel;
using Scoring_MGDPData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scoring_MGDP.Mapping
{
    public class ModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "ModelMappingProfile";
            }
        }
        public static IMapper Mapper { get; private set; }


        public ModelMappingProfile()
        {
            var mapConfiguration = new MapperConfiguration(cfg =>
            {
               
                cfg.CreateMap<Proveedores, ProveedorViewModel>()
                    .ForMember(vm => vm.Id, map => map.MapFrom(m => m.id_Proveedor))
                    .ForMember(vm => vm.NombreProveedor, map => map.MapFrom(m => m.NombreProv))
                    .ForMember(vm => vm.ClasificacionProveedorId, map => map.MapFrom(m => m.id_ClasificacionProv))
                    .ForMember(vm => vm.AM, map => map.MapFrom(m => m.EsAM))
                    .ForMember(vm => vm.ModeloImplementado, map => map.MapFrom(m => m.ModeloImplementado))
                    .ForMember(vm => vm.NombreCompras, map => map.MapFrom(m => m.NombreProvCompras))
                    .ForMember(vm => vm.Gestion, map => map.MapFrom(m => m.Gestion))
                    .ForMember(vm => vm.Vigente, map => map.MapFrom(m => m.Vigente));

                cfg.CreateMap<ProveedorViewModel, Proveedores>()
                 .ForMember(vm => vm.id_Proveedor, map => map.MapFrom(m => m.Id))
                 .ForMember(vm => vm.NombreProv, map => map.MapFrom(m => m.NombreProveedor))
                 .ForMember(vm => vm.id_ClasificacionProv, map => map.MapFrom(m => m.ClasificacionProveedorId))
                 .ForMember(vm => vm.EsAM, map => map.MapFrom(m => m.AM))
                 .ForMember(vm => vm.ModeloImplementado, map => map.MapFrom(m => m.ModeloImplementado))
                 .ForMember(vm => vm.NombreProvCompras, map => map.MapFrom(m => m.NombreCompras))
                 .ForMember(vm => vm.Gestion, map => map.MapFrom(m => m.Gestion))
                 .ForMember(vm => vm.Vigente, map => map.MapFrom(m => m.Vigente));

                cfg.CreateMap<ClasificacionesProv, ClasifProveedoresViewModel>()
                .ForMember(vm => vm.Id, map => map.MapFrom(m => m.id_ClasificacionProv))
                .ForMember(vm => vm.ClasificacionProv, map => map.MapFrom(m => m.DescripcionClasifProv));

                cfg.CreateMap<ClasifProveedoresViewModel, ClasificacionesProv>()
                .ForMember(vm => vm.id_ClasificacionProv, map => map.MapFrom(m => m.Id))
                .ForMember(vm => vm.DescripcionClasifProv, map => map.MapFrom(m => m.ClasificacionProv));

            });

            Mapper = mapConfiguration.CreateMapper();
        }
    }
}