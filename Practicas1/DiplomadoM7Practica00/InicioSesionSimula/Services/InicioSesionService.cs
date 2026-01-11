using System;
using System.Collections.Generic;
using System.Text;

namespace InicioSesionSimula.Services
{
    public class InicioSesionService
    {
        public async Task<bool> IniciarSesion(string usuario, string contrasena)
        {
            await Task.Delay(2000);

            if (usuario == "admin" && contrasena == "password")
            {
                return true;
            }

            return false;
        }
    }
}
