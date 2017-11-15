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
                    .ForMember(vm => vm.ClasifProveedoresViewModel, map => map.MapFrom(m => m.ClasificacionesProv))
                    .ForMember(vm => vm.ClasifProveedorId, map => map.MapFrom(m => m.id_ClasificacionProv))
                    .ForMember(vm => vm.AM, map => map.MapFrom(m => m.EsAM))
                    .ForMember(vm => vm.ModeloImplementado, map => map.MapFrom(m => m.ModeloImplementado))
                    .ForMember(vm => vm.NombreCompras, map => map.MapFrom(m => m.NombreProvCompras))
                    .ForMember(vm => vm.Gestion, map => map.MapFrom(m => m.Gestion))
                    .ForMember(vm => vm.Vigente, map => map.MapFrom(m => m.Vigente));

                cfg.CreateMap<ProveedorViewModel, Proveedores>()
                 .ForMember(vm => vm.id_Proveedor, map => map.MapFrom(m => m.Id))
                 .ForMember(vm => vm.NombreProv, map => map.MapFrom(m => m.NombreProveedor))
                 .ForMember(vm => vm.ClasificacionesProv, map => map.MapFrom(m => m.ClasifProveedoresViewModel))
                 .ForMember(vm => vm.id_ClasificacionProv, map => map.MapFrom(m => m.ClasifProveedorId))
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

                cfg.CreateMap<UnidadeDeMedidas, UnidadesMedidasViewModel>()
                .ForMember(vm => vm.Id, map => map.MapFrom(m => m.id_UMedida))
                .ForMember(vm => vm.UnidadMedida, map => map.MapFrom(m => m.UM));

                cfg.CreateMap<UnidadesMedidasViewModel, UnidadeDeMedidas>()
                .ForMember(vm => vm.id_UMedida, map => map.MapFrom(m => m.Id))
                .ForMember(vm => vm.UM, map => map.MapFrom(m => m.UnidadMedida));

                cfg.CreateMap<TiposMetricas, TiposMetricasViewModel>()
                .ForMember(vm => vm.Id, map => map.MapFrom(m => m.id_TipoMetrica))
                .ForMember(vm => vm.TipoMetrica, map => map.MapFrom(m => m.DescripcionTipMet));

                cfg.CreateMap<TiposMetricasViewModel, TiposMetricas>()
                .ForMember(vm => vm.id_TipoMetrica, map => map.MapFrom(m => m.Id))
                .ForMember(vm => vm.DescripcionTipMet, map => map.MapFrom(m => m.TipoMetrica));

                cfg.CreateMap<ContratoProv, ContratoProvViewModel>()
                .ForMember(vm => vm.Id, map => map.MapFrom(m => m.id_Contrato))
                .ForMember(vm => vm.Numcontrato, map => map.MapFrom(m => m.NroContrato))
                .ForMember(vm => vm.ProveedorViewModel, map => map.MapFrom(m => m.Proveedores))
                .ForMember(vm => vm.IdProveedor, map => map.MapFrom(m => m.id_Proveedor))
                .ForMember(vm => vm.Responsable, map => map.MapFrom(m => m.Responsable))
                .ForMember(vm => vm.Monto, map => map.MapFrom(m => m.MontoContrato));

                cfg.CreateMap<ContratoProvViewModel, ContratoProv>()
                .ForMember(vm => vm.id_Contrato, map => map.MapFrom(m => m.Id))
                .ForMember(vm => vm.NroContrato, map => map.MapFrom(m => m.Numcontrato))
                .ForMember(vm => vm.Proveedores, map => map.MapFrom(m => m.ProveedorViewModel))
                .ForMember(vm => vm.id_Proveedor, map => map.MapFrom(m => m.IdProveedor))
                .ForMember(vm => vm.Responsable, map => map.MapFrom(m => m.Responsable))
                .ForMember(vm => vm.MontoContrato, map => map.MapFrom(m => m.Monto));
                
            });

            Mapper = mapConfiguration.CreateMapper();
        }
    }
}