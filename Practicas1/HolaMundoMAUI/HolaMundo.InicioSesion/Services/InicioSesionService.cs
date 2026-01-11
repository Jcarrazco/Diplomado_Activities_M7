using System;
using System.Collections.Generic;
using System.Text;

namespace HolaMundo.InicioSesion.Services
{
    public class InicioSesionService
    {
        public bool IniciarSesion(string usuario, string contrasena)
        {
            if (usuario == "admin" && contrasena == "password")
            {
                return true; 
            }
            return false; 
        }
    }
}
