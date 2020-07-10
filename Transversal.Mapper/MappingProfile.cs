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
            CreateMap<TM_MUNICIPALIDAD, MunicipalidadDto.RQInsert>()
                .ForMember(destination => destination.sRuc, source => source.MapFrom(src => src.STR_NUMRUC))
                .ForMember(destination => destination.sRazonSocial, source => source.MapFrom(src => src.STR_RAZONSOCIAL))
                .ForMember(destination => destination.nTipoVia, source => source.MapFrom(src => src.NUM_IDTPVIA))
                .ForMember(destination => destination.sVia, source => source.MapFrom(src => src.STR_NOMVIA))
                .ForMember(destination => destination.nCentroPoblado, source => source.MapFrom(src => src.NUM_IDCCPP))
                .ForMember(destination => destination.sCentroPoblado, source => source.MapFrom(src => src.STR_NOMCCPP))
                .ForMember(destination => destination.nIdNumeroManzana, source => source.MapFrom(src => src.NUM_IDNUMAKM))
                .ForMember(destination => destination.sNumeroManzana, source => source.MapFrom(src => src.STR_NUMMZKIL))
                .ForMember(destination => destination.nIdLoteInterior, source => source.MapFrom(src => src.NUM_IDLOINDP))
                .ForMember(destination => destination.sLoteInterior, source => source.MapFrom(src => src.STR_INTLOTE))
                .ForMember(destination => destination.sReferencia, source => source.MapFrom(src => src.STR_REFERENCIA))
                .ForMember(destination => destination.sCodDepartamento, source => source.MapFrom(src => src.STR_CDPTO))
                .ForMember(destination => destination.sCodProvincia, source => source.MapFrom(src => src.STR_CDPROV))
                .ForMember(destination => destination.sCodDistrito, source => source.MapFrom(src => src.STR_CDDIST))
                .ForMember(destination => destination.sUsuario, source => source.MapFrom(src => src.STR_USUCREACION))
                .ForMember(destination => destination.nIdSession, source => source.MapFrom(src => src.NUM_IDSESION))
                .ForMember(destination => destination.sRepresentante, source => source.MapFrom(src => src.STR_REPRESENTANTE))
                .ForMember(destination => destination.nIdentidadsso, source => source.MapFrom(src => src.NUM_IDENTIDADSSO))
                .ForMember(destination => destination.nIdLocalsso, source => source.MapFrom(src => src.NUM_IDLOCALSSO))
                .ReverseMap();
            CreateMap<TM_MUNICIPALIDAD, MunicipalidadDto.RQUpdate>()
                .ForMember(destination => destination.nIdEntidad, source => source.MapFrom(src => src.NUM_IDENTIDAD))
                .ForMember(destination => destination.sRuc, source => source.MapFrom(src => src.STR_NUMRUC))
                .ForMember(destination => destination.sRazonSocial, source => source.MapFrom(src => src.STR_RAZONSOCIAL))
                .ForMember(destination => destination.nTipoVia, source => source.MapFrom(src => src.NUM_IDTPVIA))
                .ForMember(destination => destination.sVia, source => source.MapFrom(src => src.STR_NOMVIA))
                .ForMember(destination => destination.nCentroPoblado, source => source.MapFrom(src => src.NUM_IDCCPP))
                .ForMember(destination => destination.sCentroPoblado, source => source.MapFrom(src => src.STR_NOMCCPP))
                .ForMember(destination => destination.nIdNumeroManzana, source => source.MapFrom(src => src.NUM_IDNUMAKM))
                .ForMember(destination => destination.sNumeroManzana, source => source.MapFrom(src => src.STR_NUMMZKIL))
                .ForMember(destination => destination.nIdLoteInterior, source => source.MapFrom(src => src.NUM_IDLOINDP))
                .ForMember(destination => destination.sLoteInterior, source => source.MapFrom(src => src.STR_INTLOTE))
                .ForMember(destination => destination.sReferencia, source => source.MapFrom(src => src.STR_REFERENCIA))
                .ForMember(destination => destination.sCodDepartamento, source => source.MapFrom(src => src.STR_CDPTO))
                .ForMember(destination => destination.sCodProvincia, source => source.MapFrom(src => src.STR_CDPROV))
                .ForMember(destination => destination.sCodDistrito, source => source.MapFrom(src => src.STR_CDDIST))
                .ForMember(destination => destination.sUsuario, source => source.MapFrom(src => src.STR_USUACT))
                .ForMember(destination => destination.nIdSession, source => source.MapFrom(src => src.NUM_IDSESION))
                .ForMember(destination => destination.sRepresentante, source => source.MapFrom(src => src.STR_REPRESENTANTE))
                .ReverseMap();
            CreateMap<TM_MUNICIPALIDAD, MunicipalidadDto.RQDelete>()
                .ForMember(destination => destination.nIdEntidad, source => source.MapFrom(src => src.NUM_IDENTIDAD))
                .ForMember(destination => destination.sUsuario, source => source.MapFrom(src => src.STR_USUACT))
                .ForMember(destination => destination.nIdSession, source => source.MapFrom(src => src.NUM_IDSESION))
                .ReverseMap();
            CreateMap<TM_MUNICIPALIDAD, MunicipalidadDto.RSGet>()
                .ForMember(destination => destination.nIdEntidad, source => source.MapFrom(src => src.NUM_IDENTIDAD))
                .ForMember(destination => destination.sRuc, source => source.MapFrom(src => src.STR_NUMRUC))
                .ForMember(destination => destination.sRazonSocial, source => source.MapFrom(src => src.STR_RAZONSOCIAL))
                .ForMember(destination => destination.nTipoVia, source => source.MapFrom(src => src.NUM_IDTPVIA))
                .ForMember(destination => destination.sVia, source => source.MapFrom(src => src.STR_NOMVIA))
                .ForMember(destination => destination.nCentroPoblado, source => source.MapFrom(src => src.NUM_IDCCPP))
                .ForMember(destination => destination.sCentroPoblado, source => source.MapFrom(src => src.STR_NOMCCPP))
                .ForMember(destination => destination.nIdNumeroManzana, source => source.MapFrom(src => src.NUM_IDNUMAKM))
                .ForMember(destination => destination.sNumeroManzana, source => source.MapFrom(src => src.STR_NUMMZKIL))
                .ForMember(destination => destination.nIdLoteInterior, source => source.MapFrom(src => src.NUM_IDLOINDP))
                .ForMember(destination => destination.sLoteInterior, source => source.MapFrom(src => src.STR_INTLOTE))
                .ForMember(destination => destination.sReferencia, source => source.MapFrom(src => src.STR_REFERENCIA))
                .ForMember(destination => destination.sCodDepartamento, source => source.MapFrom(src => src.STR_CDPTO))
                .ForMember(destination => destination.sCodProvincia, source => source.MapFrom(src => src.STR_CDPROV))
                .ForMember(destination => destination.sCodDistrito, source => source.MapFrom(src => src.STR_CDDIST))
                .ForMember(destination => destination.sRepresentante, source => source.MapFrom(src => src.STR_REPRESENTANTE))
                .ReverseMap();
            CreateMap<TM_MUNICIPALIDAD, TableModel>()
                .ForMember(destination => destination.Id, source => source.MapFrom(src => src.NUM_IDENTIDAD))
                .ForMember(destination => destination.Column1, source => source.MapFrom(src => src.NUM_FILA))
                .ForMember(destination => destination.Column2, source => source.MapFrom(src => src.STR_NUMRUC))
                .ForMember(destination => destination.Column3, source => source.MapFrom(src => src.STR_RAZONSOCIAL))
                .ForMember(destination => destination.Column4, source => source.MapFrom(src => src.STR_DIRECCION))
                .ReverseMap();
            #endregion
            #region Estacion de Servicio
            CreateMap<TM_ESTACIONSERVICIO, EstacionServicioDto.RQInsert>()
               .ForMember(destination => destination.sRuc, source => source.MapFrom(src => src.STR_NUMRUC))
               .ForMember(destination => destination.sRazonSocial, source => source.MapFrom(src => src.STR_RAZONSOCIAL))
               .ForMember(destination => destination.nTipoVia, source => source.MapFrom(src => src.NUM_IDTPVIA))
               .ForMember(destination => destination.sVia, source => source.MapFrom(src => src.STR_NOMVIA))
               .ForMember(destination => destination.nCentroPoblado, source => source.MapFrom(src => src.NUM_IDCCPP))
               .ForMember(destination => destination.sCentroPoblado, source => source.MapFrom(src => src.STR_NOMCCPP))
               .ForMember(destination => destination.nIdNumeroManzana, source => source.MapFrom(src => src.NUM_IDNUMAKM))
               .ForMember(destination => destination.sNumeroManzana, source => source.MapFrom(src => src.STR_NUMMZKIL))
               .ForMember(destination => destination.nIdLoteInterior, source => source.MapFrom(src => src.NUM_IDLOINDP))
               .ForMember(destination => destination.sLoteInterior, source => source.MapFrom(src => src.STR_INTLOTE))
               .ForMember(destination => destination.sReferencia, source => source.MapFrom(src => src.STR_REFERENCIA))
               .ForMember(destination => destination.sCodDepartamento, source => source.MapFrom(src => src.STR_CDPTO))
               .ForMember(destination => destination.sCodProvincia, source => source.MapFrom(src => src.STR_CDPROV))
               .ForMember(destination => destination.sCodDistrito, source => source.MapFrom(src => src.STR_CDDIST))
               .ForMember(destination => destination.sNroSucursales, source => source.MapFrom(src => src.STR_NROSUCURSALES))
               .ForMember(destination => destination.sUsuario, source => source.MapFrom(src => src.STR_USUCREACION))
               .ForMember(destination => destination.nIdSession, source => source.MapFrom(src => src.NUM_IDSESION))
               .ForMember(destination => destination.sRepresentante, source => source.MapFrom(src => src.STR_REPRESENTANTE))
               .ForMember(destination => destination.nIdentidadsso, source => source.MapFrom(src => src.NUM_IDENTIDADSSO))
               .ForMember(destination => destination.nIdLocalsso, source => source.MapFrom(src => src.NUM_IDLOCALSSO))
               .ReverseMap();
            CreateMap<TM_ESTACIONSERVICIO, EstacionServicioDto.RQUpdate>()
                .ForMember(destination => destination.nIdEstServicio, source => source.MapFrom(src => src.NUM_IDESTSERVICIO))
                .ForMember(destination => destination.sRuc, source => source.MapFrom(src => src.STR_NUMRUC))
                .ForMember(destination => destination.sRazonSocial, source => source.MapFrom(src => src.STR_RAZONSOCIAL))
                .ForMember(destination => destination.nTipoVia, source => source.MapFrom(src => src.NUM_IDTPVIA))
                .ForMember(destination => destination.sVia, source => source.MapFrom(src => src.STR_NOMVIA))
                .ForMember(destination => destination.nCentroPoblado, source => source.MapFrom(src => src.NUM_IDCCPP))
                .ForMember(destination => destination.sCentroPoblado, source => source.MapFrom(src => src.STR_NOMCCPP))
                .ForMember(destination => destination.nIdNumeroManzana, source => source.MapFrom(src => src.NUM_IDNUMAKM))
                .ForMember(destination => destination.sNumeroManzana, source => source.MapFrom(src => src.STR_NUMMZKIL))
                .ForMember(destination => destination.nIdLoteInterior, source => source.MapFrom(src => src.NUM_IDLOINDP))
                .ForMember(destination => destination.sLoteInterior, source => source.MapFrom(src => src.STR_INTLOTE))
                .ForMember(destination => destination.sReferencia, source => source.MapFrom(src => src.STR_REFERENCIA))
                .ForMember(destination => destination.sCodDepartamento, source => source.MapFrom(src => src.STR_CDPTO))
                .ForMember(destination => destination.sCodProvincia, source => source.MapFrom(src => src.STR_CDPROV))
                .ForMember(destination => destination.sCodDistrito, source => source.MapFrom(src => src.STR_CDDIST))
                .ForMember(destination => destination.sNroSucursales, source => source.MapFrom(src => src.STR_NROSUCURSALES))
                .ForMember(destination => destination.sUsuario, source => source.MapFrom(src => src.STR_USUACT))
                .ForMember(destination => destination.nIdSession, source => source.MapFrom(src => src.NUM_IDSESION))
                .ForMember(destination => destination.sRepresentante, source => source.MapFrom(src => src.STR_REPRESENTANTE))
                .ReverseMap();
            CreateMap<TM_ESTACIONSERVICIO, EstacionServicioDto.RQDelete>()
                .ForMember(destination => destination.nIdEstServicio, source => source.MapFrom(src => src.NUM_IDESTSERVICIO))
                .ForMember(destination => destination.sUsuario, source => source.MapFrom(src => src.STR_USUACT))
                .ForMember(destination => destination.nIdSession, source => source.MapFrom(src => src.NUM_IDSESION))
                .ReverseMap();
            CreateMap<TM_ESTACIONSERVICIO, EstacionServicioDto.RSGet>()
                .ForMember(destination => destination.nIdEstServicio, source => source.MapFrom(src => src.NUM_IDESTSERVICIO))
                .ForMember(destination => destination.sRuc, source => source.MapFrom(src => src.STR_NUMRUC))
                .ForMember(destination => destination.sRazonSocial, source => source.MapFrom(src => src.STR_RAZONSOCIAL))
                .ForMember(destination => destination.nTipoVia, source => source.MapFrom(src => src.NUM_IDTPVIA))
                .ForMember(destination => destination.sVia, source => source.MapFrom(src => src.STR_NOMVIA))
                .ForMember(destination => destination.nCentroPoblado, source => source.MapFrom(src => src.NUM_IDCCPP))
                .ForMember(destination => destination.sCentroPoblado, source => source.MapFrom(src => src.STR_NOMCCPP))
                .ForMember(destination => destination.nIdNumeroManzana, source => source.MapFrom(src => src.NUM_IDNUMAKM))
                .ForMember(destination => destination.sNumeroManzana, source => source.MapFrom(src => src.STR_NUMMZKIL))
                .ForMember(destination => destination.nIdLoteInterior, source => source.MapFrom(src => src.NUM_IDLOINDP))
                .ForMember(destination => destination.sLoteInterior, source => source.MapFrom(src => src.STR_INTLOTE))
                .ForMember(destination => destination.sReferencia, source => source.MapFrom(src => src.STR_REFERENCIA))
                .ForMember(destination => destination.sCodDepartamento, source => source.MapFrom(src => src.STR_CDPTO))
                .ForMember(destination => destination.sCodProvincia, source => source.MapFrom(src => src.STR_CDPROV))
                .ForMember(destination => destination.sCodDistrito, source => source.MapFrom(src => src.STR_CDDIST))
                .ForMember(destination => destination.sNroSucursales, source => source.MapFrom(src => src.STR_NROSUCURSALES))
                .ForMember(destination => destination.sRepresentante, source => source.MapFrom(src => src.STR_REPRESENTANTE))
                .ReverseMap();
            CreateMap<TM_ESTACIONSERVICIO, TableModel>()
                .ForMember(destination => destination.Id, source => source.MapFrom(src => src.NUM_IDESTSERVICIO))
                .ForMember(destination => destination.Column1, source => source.MapFrom(src => src.NUM_FILA))
                .ForMember(destination => destination.Column2, source => source.MapFrom(src => src.STR_NUMRUC))
                .ForMember(destination => destination.Column3, source => source.MapFrom(src => src.STR_RAZONSOCIAL))
                .ForMember(destination => destination.Column4, source => source.MapFrom(src => src.STR_DIRECCION))
                .ReverseMap();
            #endregion
            #region General
            CreateMap<GENERAL.TIPO_VIA, ComboModelDto.XId>()
                .ForMember(destination => destination.nId, source => source.MapFrom(src => src.NUM_IDTPVIA))
                .ForMember(destination => destination.sDescription, source => source.MapFrom(src => src.STR_DSTPVIA))
                .ReverseMap();
            CreateMap<GENERAL.CENTRO_POBLADO, ComboModelDto.XId>()
                .ForMember(destination => destination.nId, source => source.MapFrom(src => src.NUM_IDCCPP))
                .ForMember(destination => destination.sDescription, source => source.MapFrom(src => src.STR_DSCCPP))
                .ReverseMap();
            CreateMap<GENERAL.NUMERO_MANZANA, ComboModelDto.XId>()
                .ForMember(destination => destination.nId, source => source.MapFrom(src => src.NUM_IDNUMAKM))
                .ForMember(destination => destination.sDescription, source => source.MapFrom(src => src.STR_DSNUMAKM))
                .ReverseMap();
            CreateMap<GENERAL.LOTE_INTERIOR, ComboModelDto.XId>()
                .ForMember(destination => destination.nId, source => source.MapFrom(src => src.NUM_IDLOINDP))
                .ForMember(destination => destination.sDescription, source => source.MapFrom(src => src.STR_DSLOINDP))
                .ReverseMap();
            CreateMap<GENERAL.DEPARTAMENTO, ComboModelDto.XCodigo>()
                .ForMember(destination => destination.sCodigo, source => source.MapFrom(src => src.STR_CDPTO))
                .ForMember(destination => destination.sDescription, source => source.MapFrom(src => src.STR_DSDPTO))
                .ReverseMap();
            CreateMap<GENERAL.PROVINCIA, ComboModelDto.XCodigo>()
               .ForMember(destination => destination.sCodigo, source => source.MapFrom(src => src.STR_CDPROV))
               .ForMember(destination => destination.sDescription, source => source.MapFrom(src => src.STR_DSPROV))
               .ReverseMap();
            CreateMap<GENERAL.DISTRITO, ComboModelDto.XCodigo>()
               .ForMember(destination => destination.sCodigo, source => source.MapFrom(src => src.STR_CDDIST))
               .ForMember(destination => destination.sDescription, source => source.MapFrom(src => src.STR_DSDIST))
               .ReverseMap();
            CreateMap<GENERAL.TIPO_DOCUMENTO_REPRESENTANTELEGAL, ComboModelDto.XId>()
               .ForMember(destination => destination.nId, source => source.MapFrom(src => src.NUM_IDTPDOCUMENTO))
               .ForMember(destination => destination.sDescription, source => source.MapFrom(src => src.STR_DSTPDOCUMENTO))
               .ReverseMap();
            CreateMap<GENERAL.CARGO_REPRESENTANTELEGAL, ComboModelDto.XId>()
               .ForMember(destination => destination.nId, source => source.MapFrom(src => src.NUM_IDCARGO))
               .ForMember(destination => destination.sDescription, source => source.MapFrom(src => src.STR_DSCARGO))
               .ReverseMap();
            #endregion
            #region Admin
            CreateMap<ADMIN.TM_SESION, AdminDto.RegistrarSesion>()
                .ForMember(destination => destination.sUsuario, source => source.MapFrom(src => src.STR_USUARIO))
                .ForMember(destination => destination.sUsuarioSSO, source => source.MapFrom(src => src.STR_USERSO))
                .ForMember(destination => destination.sIp, source => source.MapFrom(src => src.STR_NUMEROIP))
                .ForMember(destination => destination.sFlag, source => source.MapFrom(src => src.STR_FLAGCR))
                .ReverseMap();
            #endregion
        }
    }
}
