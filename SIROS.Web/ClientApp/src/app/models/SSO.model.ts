export class LoginResponseModel {
    IdUsuario: number;
    nIdEmpresa: number;
    sNombreEmpresa: string;
    nIdLocal: number;
    sNombreLocal: string;
    nIdPerfil: number;
    sNombrePerfil: string;
    sToken: string;
    dTokenExpiration: Date;
}
