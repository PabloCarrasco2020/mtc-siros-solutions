using System;
using System.Collections.Generic;
using System.Text;

namespace Transversal.Common
{
    public class Messages
    {
        public class SSO
        {
            public class Login
            {
                public const string EX001 = "El usuario y/o contraseña son incorrectos.";
                public const string EX002 = "El usuario no tiene ninguna empresa asociada en el SSO.";
                public const string EX003 = "El usuario no tiene ningun local asociado a su empresa en el SSO.";
                public const string EX004 = "El usuario no tiene ningun perfil asociado en el SSO.";
                public const string EX005 = "El usuario no tiene el perfil necesario para poder continuar.";
                public const string EX006 = "No se pudo obtener la información personal del usuario.";
                public const string EX007 = "No se pudo registrar la sesion del usuario.";
            }
        }
    }
}
