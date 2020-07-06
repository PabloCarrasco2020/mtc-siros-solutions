using System;
using Application.Dto;
using AutoMapper;
using Domain.Entities;

namespace Transversal.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            #region Municipalidad
            CreateMap<TM_MUNICIPALIDAD, MunicipalidadDto.RSGet>()
                .ForMember(destination => destination.Id, source => source.MapFrom(src => src.NID))
                .ForMember(destination => destination.Name, source => source.MapFrom(src => src.SNOMBRE))
                .ReverseMap();
            CreateMap<TM_MUNICIPALIDAD, TableModel>()
                .ForMember(destination => destination.Id, source => source.MapFrom(src => src.NID))
                .ForMember(destination => destination.Column1, source => source.MapFrom(src => src.SNOMBRE))
                .ReverseMap();
            #endregion
            #region General
            CreateMap<GENERAL.TIPO_VIA, ComboModelDto>()
                .ForMember(destination => destination.sCodigo, source => source.MapFrom(src => src.NUM_IDTPVIA))
                .ForMember(destination => destination.sDescription, source => source.MapFrom(src => src.STR_DSTPVIA))
                .ReverseMap();
            CreateMap<GENERAL.CENTRO_POBLADO, ComboModelDto>()
                .ForMember(destination => destination.sCodigo, source => source.MapFrom(src => src.NUM_IDCCPP))
                .ForMember(destination => destination.sDescription, source => source.MapFrom(src => src.STR_DSCCPP))
                .ReverseMap();
            CreateMap<GENERAL.NUMERO_MANZANA, ComboModelDto>()
                .ForMember(destination => destination.sCodigo, source => source.MapFrom(src => src.NUM_IDNUMAKM))
                .ForMember(destination => destination.sDescription, source => source.MapFrom(src => src.STR_DSNUMAKM))
                .ReverseMap();
            CreateMap<GENERAL.LOTE_INTERIOR, ComboModelDto>()
                .ForMember(destination => destination.sCodigo, source => source.MapFrom(src => src.NUM_IDLOINDP))
                .ForMember(destination => destination.sDescription, source => source.MapFrom(src => src.STR_DSLOINDP))
                .ReverseMap();
            CreateMap<GENERAL.DEPARTAMENTO, ComboModelDto>()
                .ForMember(destination => destination.sCodigo, source => source.MapFrom(src => src.STR_CDPTO))
                .ForMember(destination => destination.sDescription, source => source.MapFrom(src => src.STR_DSDPTO))
                .ReverseMap();
            CreateMap<GENERAL.PROVINCIA, ComboModelDto>()
               .ForMember(destination => destination.sCodigo, source => source.MapFrom(src => src.STR_CDPROV))
               .ForMember(destination => destination.sDescription, source => source.MapFrom(src => src.STR_DSPROV))
               .ReverseMap();
            CreateMap<GENERAL.DISTRITO, ComboModelDto>()
               .ForMember(destination => destination.sCodigo, source => source.MapFrom(src => src.STR_CDDIST))
               .ForMember(destination => destination.sDescription, source => source.MapFrom(src => src.STR_DSDIST))
               .ReverseMap();
            CreateMap<GENERAL.TIPO_DOCUMENTO_REPRESENTANTELEGAL, ComboModelDto>()
               .ForMember(destination => destination.sCodigo, source => source.MapFrom(src => src.NUM_IDTPDOCUMENTO))
               .ForMember(destination => destination.sDescription, source => source.MapFrom(src => src.STR_DSTPDOCUMENTO))
               .ReverseMap();
            CreateMap<GENERAL.CARGO_REPRESENTANTELEGAL, ComboModelDto>()
               .ForMember(destination => destination.sCodigo, source => source.MapFrom(src => src.NUM_IDCARGO))
               .ForMember(destination => destination.sDescription, source => source.MapFrom(src => src.STR_DSCARGO))
               .ReverseMap();
            #endregion
        }
    }
}
