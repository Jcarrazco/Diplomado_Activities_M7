using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace CalculadorRFC.Services
{
    public class CalculaRFCService
    {
        public string CalcularRFC(
         string nombre,
         string apellidoPaterno,
         string apellidoMaterno,
         DateTime fechaNacimiento)
        {
            // Limpieza
            nombre = Limpiar(nombre);
            apellidoPaterno = Limpiar(apellidoPaterno);
            apellidoMaterno = Limpiar(apellidoMaterno);

            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("Nombre requerido");
            if (string.IsNullOrWhiteSpace(apellidoPaterno))
                throw new ArgumentException("Apellido paterno requerido");
            if (string.IsNullOrWhiteSpace(apellidoMaterno))
                throw new ArgumentException("Apellido materno requerido");

            // RFC base + fecha
            string rfc = RfcBase(nombre, apellidoPaterno, apellidoMaterno)
                       + fechaNacimiento.ToString("yyMMdd");

            // Homoclave
            rfc += Homoclave(nombre, apellidoPaterno, apellidoMaterno);

            // Dígito verificador
            rfc += DigitoVerificador(rfc);

            return rfc;
        }

        // ================== helpers ==================

        private const string TablaHomoclave = "0123456789ABCDEFGHIJKLMN&OPQRSTUVWXYZ Ñ";
        private const string TablaDigito = "0123456789ABCDEFGHIJKLMN&OPQRSTUVWXYZ";

        private static string RfcBase(string nombre, string ap, string am)
        {
            char a1 = ap[0];
            char a2 = PrimeraVocalInterna(ap);
            char a3 = am[0];
            char a4 = nombre[0];

            return new string(new[] { a1, a2, a3, a4 });
        }

        private static char PrimeraVocalInterna(string texto)
        {
            for (int i = 1; i < texto.Length; i++)
                if ("AEIOU".IndexOf(texto[i]) >= 0)
                    return texto[i];

            return 'X';
        }

        private static string Homoclave(string nombre, string ap, string am)
        {
            string nombreCompleto = $"{ap} {am} {nombre}";
            var valores = nombreCompleto.Select(c =>
            {
                int i = TablaHomoclave.IndexOf(c);
                return i < 0 ? 0 : i;
            }).ToList();

            long suma = 0;
            for (int i = 0; i < valores.Count - 1; i++)
                suma += valores[i] * valores[i + 1];

            int h1 = (int)(suma / 34);
            int h2 = (int)(suma % 34);

            return $"{TablaDigito[h1 % TablaDigito.Length]}{TablaDigito[h2 % TablaDigito.Length]}";
        }

        private static char DigitoVerificador(string rfc12)
        {
            var valores = new Dictionary<char, int>();
            for (int i = 0; i < TablaDigito.Length; i++)
                valores[TablaDigito[i]] = i;

            long suma = 0;
            for (int i = 0; i < rfc12.Length; i++)
            {
                valores.TryGetValue(rfc12[i], out int v);
                suma += v * (13 - i);
            }

            int residuo = (int)(suma % 11);
            if (residuo == 0) return '0';
            if (residuo == 1) return 'A';
            return (char)('0' + (11 - residuo));
        }

        private static string Limpiar(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) return "";

            texto = texto.Trim().ToUpperInvariant()
                .Replace('Á', 'A').Replace('À', 'A').Replace('Ä', 'A')
                .Replace('É', 'E').Replace('È', 'E').Replace('Ë', 'E')
                .Replace('Í', 'I').Replace('Ì', 'I').Replace('Ï', 'I')
                .Replace('Ó', 'O').Replace('Ò', 'O').Replace('Ö', 'O')
                .Replace('Ú', 'U').Replace('Ù', 'U').Replace('Ü', 'U');

            return System.Text.RegularExpressions.Regex
                .Replace(texto, @"[^A-ZÑ ]", "")
                .Trim();
        }
    }
}
