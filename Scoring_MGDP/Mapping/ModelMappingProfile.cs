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

                cfg.CreateMap<Metricas, MetricasViewModel>()
                .ForMember(vm => vm.IdMetrica, map => map.MapFrom(m => m.id_Metrica))
                .ForMember(vm => vm.Sigla, map => map.MapFrom(m => m.SiglaMetrica))
                .ForMember(vm => vm.Descripcion, map => map.MapFrom(m => m.DescripcionMet))
                .ForMember(vm => vm.TiposMetricasViewModel, map => map.MapFrom(m => m.TiposMetricas))
                .ForMember(vm => vm.UnidadesMedidasViewModel, map => map.MapFrom(m => m.UnidadeDeMedidas))
                .ForMember(vm => vm.IdTipo, map => map.MapFrom(m => m.id_TipoMetrica))
                .ForMember(vm => vm.IdUnidad, map => map.MapFrom(m => m.id_UMedida));

                cfg.CreateMap<MetricasViewModel, Metricas>()
                .ForMember(vm => vm.id_Metrica, map => map.MapFrom(m => m.IdMetrica))
                .ForMember(vm => vm.SiglaMetrica, map => map.MapFrom(m => m.Sigla))
                .ForMember(vm => vm.DescripcionMet, map => map.MapFrom(m => m.Descripcion))
                .ForMember(vm => vm.TiposMetricas, map => map.MapFrom(m => m.TiposMetricasViewModel))
                .ForMember(vm => vm.UnidadeDeMedidas, map => map.MapFrom(m => m.UnidadesMedidasViewModel))
                .ForMember(vm => vm.id_TipoMetrica, map => map.MapFrom(m => m.IdTipo))
                .ForMember(vm => vm.id_UMedida, map => map.MapFrom(m => m.IdUnidad));

                cfg.CreateMap<Scoring_Configuracion, ScoringConfigFrentesViewModel>()
                .ForMember(vm => vm.Id, map => map.MapFrom(m => m.id_MetricasScoring))
                .ForMember(vm => vm.Metrica, map => map.MapFrom(m => m.Metrica))
                .ForMember(vm => vm.Peso, map => map.MapFrom(m => m.Peso))
                .ForMember(vm => vm.Ambito, map => map.MapFrom(m => m.Ambito))
                .ForMember(vm => vm.Tipo, map => map.MapFrom(m => m.Tipo));

                cfg.CreateMap<ScoringConfigFrentesViewModel, Scoring_Configuracion>()
                .ForMember(vm => vm.id_MetricasScoring, map => map.MapFrom(m => m.Id))
                .ForMember(vm => vm.Metrica, map => map.MapFrom(m => m.Metrica))
                .ForMember(vm => vm.Peso, map => map.MapFrom(m => m.Peso))
                .ForMember(vm => vm.Ambito, map => map.MapFrom(m => m.Ambito))
                .ForMember(vm => vm.Tipo, map => map.MapFrom(m => m.Tipo));

                cfg.CreateMap<Scoring_Configuracion, ScoringConfigMedidasViewModel>()
                .ForMember(vm => vm.Id, map => map.MapFrom(m => m.id_MetricasScoring))
                .ForMember(vm => vm.Metrica, map => map.MapFrom(m => m.Metrica))
                .ForMember(vm => vm.Peso, map => map.MapFrom(m => m.Peso))
                .ForMember(vm => vm.Ambito, map => map.MapFrom(m => m.Ambito))
                .ForMember(vm => vm.Tipo, map => map.MapFrom(m => m.Tipo));

                cfg.CreateMap<ScoringConfigMedidasViewModel, Scoring_Configuracion>()
                .ForMember(vm => vm.id_MetricasScoring, map => map.MapFrom(m => m.Id))
                .ForMember(vm => vm.Metrica, map => map.MapFrom(m => m.Metrica))
                .ForMember(vm => vm.Peso, map => map.MapFrom(m => m.Peso))
                .ForMember(vm => vm.Ambito, map => map.MapFrom(m => m.Ambito))
                .ForMember(vm => vm.Tipo, map => map.MapFrom(m => m.Tipo));

                cfg.CreateMap<TiposProyectos, TiposProyectosViewModel>()
                .ForMember(vm => vm.IdTipoProyecto, map => map.MapFrom(m => m.id_TiposProyectos))
                .ForMember(vm => vm.Descripcion, map => map.MapFrom(m => m.DescTipoProyecto))
                .ForMember(vm => vm.Sigla, map => map.MapFrom(m => m.SiglaTipoPry));

                cfg.CreateMap<TiposProyectosViewModel, TiposProyectos>()
                .ForMember(vm => vm.id_TiposProyectos, map => map.MapFrom(m => m.IdTipoProyecto))
                .ForMember(vm => vm.DescTipoProyecto, map => map.MapFrom(m => m.Descripcion))
                .ForMember(vm => vm.SiglaTipoPry, map => map.MapFrom(m => m.Sigla));

                cfg.CreateMap<DefMetricas, DefMetricasViewModel>()
                .ForMember(vm => vm.IdDefMetrica, map => map.MapFrom(m => m.id_DefMetricas))
                .ForMember(vm => vm.IdTipoProyecto, map => map.MapFrom(m => m.id_TiposProyectos))
                .ForMember(vm => vm.IdProveedor, map => map.MapFrom(m => m.id_Proveedor))
                .ForMember(vm => vm.IdMetrica, map => map.MapFrom(m => m.id_Metricas))
                .ForMember(vm => vm.IdVision, map => map.MapFrom(m => m.id_vision))
                .ForMember(vm => vm.FechaDesde, map => map.MapFrom(m => m.FechaDesde))
                .ForMember(vm => vm.FechaHasta, map => map.MapFrom(m => m.FechaHasta))
                .ForMember(vm => vm.Clave, map => map.MapFrom(m => m.Clave))
                .ForMember(vm => vm.Ratio, map => map.MapFrom(m => m.Ratio))
                .ForMember(vm => vm.Peso, map => map.MapFrom(m => m.Peso))
                .ForMember(vm => vm.PesoPonderado, map => map.MapFrom(m => m.PesoPonderado))
                .ForMember(vm => vm.ObjCritico, map => map.MapFrom(m => m.ObjCritico))
                .ForMember(vm => vm.ObjMinimo, map => map.MapFrom(m => m.ObjMinimo))
                .ForMember(vm => vm.ObjExcelencia, map => map.MapFrom(m => m.ObjExcelencia))
                .ForMember(vm => vm.HubNoHub, map => map.MapFrom(m => m.Hub_NoHub))
                .ForMember(vm => vm.TiposProyectosViewModel, map => map.MapFrom(m => m.TiposProyectos))
                .ForMember(vm => vm.ProveedorViewModel, map => map.MapFrom(m => m.Proveedores))
                .ForMember(vm => vm.MetricasViewModel, map => map.MapFrom(m => m.Metricas));

                cfg.CreateMap<DefMetricasViewModel, DefMetricas>()
                .ForMember(vm => vm.id_DefMetricas, map => map.MapFrom(m => m.IdMetrica))
                .ForMember(vm => vm.id_TiposProyectos, map => map.MapFrom(m => m.IdTipoProyecto))
                .ForMember(vm => vm.id_Proveedor, map => map.MapFrom(m => m.IdProveedor))
                .ForMember(vm => vm.id_Metricas, map => map.MapFrom(m => m.IdMetrica))
                .ForMember(vm => vm.id_vision, map => map.MapFrom(m => m.IdVision))
                .ForMember(vm => vm.FechaDesde, map => map.MapFrom(m => m.FechaDesde))
                .ForMember(vm => vm.FechaHasta, map => map.MapFrom(m => m.FechaHasta))
                .ForMember(vm => vm.Clave, map => map.MapFrom(m => m.Clave))
                .ForMember(vm => vm.Ratio, map => map.MapFrom(m => m.Ratio))
                .ForMember(vm => vm.Peso, map => map.MapFrom(m => m.Peso))
                .ForMember(vm => vm.PesoPonderado, map => map.MapFrom(m => m.PesoPonderado))
                .ForMember(vm => vm.ObjCritico, map => map.MapFrom(m => m.ObjCritico))
                .ForMember(vm => vm.ObjMinimo, map => map.MapFrom(m => m.ObjMinimo))
                .ForMember(vm => vm.ObjExcelencia, map => map.MapFrom(m => m.ObjExcelencia))
                .ForMember(vm => vm.Hub_NoHub, map => map.MapFrom(m => m.HubNoHub))
                .ForMember(vm => vm.TiposProyectos, map => map.MapFrom(m => m.TiposProyectosViewModel))
                .ForMember(vm => vm.Proveedores, map => map.MapFrom(m => m.ProveedorViewModel))
                .ForMember(vm => vm.Metricas, map => map.MapFrom(m => m.MetricasViewModel));

                cfg.CreateMap<MedicionesMetricas, MedicionesMetricasViewModel>()
                .ForMember(vm => vm.IdMedicionMetrica, map => map.MapFrom(m => m.id_Medicion_Metrica))
                .ForMember(vm => vm.IdDefMetrica, map => map.MapFrom(m => m.id_DefMetricas))
                .ForMember(vm => vm.IdTipoProyecto, map => map.MapFrom(m => m.id_TiposProyectos))
                .ForMember(vm => vm.FechaMedicion, map => map.MapFrom(m => m.FechaMedicion))
                .ForMember(vm => vm.ValorMedido, map => map.MapFrom(m => m.ValorMedido))
                .ForMember(vm => vm.Calculado, map => map.MapFrom(m => m.Calculado))
                .ForMember(vm => vm.Ratio, map => map.MapFrom(m => m.Cump_Ratio))
                .ForMember(vm => vm.RatioSiNo, map => map.MapFrom(m => m.Calcula_RatioSN))
                .ForMember(vm => vm.TiposProyectosViewModel, map => map.MapFrom(m => m.TiposProyectos));

                cfg.CreateMap<MedicionesMetricasViewModel, MedicionesMetricas>()
                .ForMember(vm => vm.id_Medicion_Metrica, map => map.MapFrom(m => m.IdMedicionMetrica))
                .ForMember(vm => vm.id_DefMetricas, map => map.MapFrom(m => m.IdDefMetrica))
                .ForMember(vm => vm.id_TiposProyectos, map => map.MapFrom(m => m.IdTipoProyecto))
                .ForMember(vm => vm.FechaMedicion, map => map.MapFrom(m => m.FechaMedicion))
                .ForMember(vm => vm.ValorMedido, map => map.MapFrom(m => m.ValorMedido))
                .ForMember(vm => vm.Calculado, map => map.MapFrom(m => m.Calculado))
                .ForMember(vm => vm.Cump_Ratio, map => map.MapFrom(m => m.Ratio))
                .ForMember(vm => vm.Calcula_RatioSN, map => map.MapFrom(m => m.RatioSiNo))
                .ForMember(vm => vm.TiposProyectos, map => map.MapFrom(m => m.TiposProyectosViewModel));
            });

            Mapper = mapConfiguration.CreateMapper();
        }
    }
}