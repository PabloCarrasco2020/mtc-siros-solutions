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
            CreateMap<TM_MUNICIPALIDAD, ComboModelDto>()
                .ForMember(destination => destination.Id, source => source.MapFrom(src => src.NID))
                .ForMember(destination => destination.Description, source => source.MapFrom(src => String.Format("{0} - {1}",src.SNOMBRE,src.SDIRECCION)))
                .ReverseMap();
            #endregion
        }
    }
}
