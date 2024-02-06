using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Classes
{
    public class Reporte
    {
        private readonly List<FormaGeometrica> _formas;
        Dictionary<int, CultureInfo> cultures = new Dictionary<int, CultureInfo>
        {
            { 1, new CultureInfo("es-ES") },
            { 2, new CultureInfo("en-US") },
            { 3, new CultureInfo("it-IT") }
        };

        public Reporte(List<FormaGeometrica> formas)
        {
            _formas = formas;
        }

        public string GenerarReporte(int idioma)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultures[idioma].ToString());

            var sb = new StringBuilder();

            if (!_formas.Any())
            {
                sb.Append(GetResourceString("ListaVacia"));
            }
            else
            {
                sb.Append(GetResourceString("ReporteHeader"));

                var formasAgrupadas = _formas.GroupBy(f => f.Nombre);

                foreach (var forma in formasAgrupadas)
                {
                    var cantidad = forma.Count();
                    var areaTotal = forma.Sum(f => f.CalcularArea());
                    var perimetroTotal = forma.Sum(f => f.CalcularPerimetro());

                    sb.Append(GetLine(forma.Key, cantidad, areaTotal, perimetroTotal));
                }

                var totalFormas = _formas.Count;
                var totalArea = Math.Round(_formas.Sum(f => f.CalcularArea()), 2);
                var totalPerimetro = Math.Round(_formas.Sum(f => f.CalcularPerimetro()), 2);

                sb.Append(GetResourceString("ReportFooter"));
                sb.Append(totalFormas + " " + GetResourceString(totalFormas > 1 ? "Formas" : "Forma") + " ");
                sb.Append(GetResourceString("Perimetro") + " " + totalPerimetro + " ");
                sb.Append(GetResourceString("Area") + " " + totalArea);
            }

            return sb.ToString();
        }

        private string GetLine(string tipo, int cantidad, decimal area, decimal perimetro)
        {
            if (cantidad > 0)
            {
                return $"{cantidad} {GetResourceString(cantidad > 1 ? tipo + "s" : tipo)} | {GetResourceString("Area")} {area:#.##} | {GetResourceString("Perimetro")} {perimetro:#.##} <br/>";
            }
            return string.Empty;
        }

        private string GetResourceString(string key)
        {
            var resourceManager = new ResourceManager("DevelopmentChallenge.Data.Resources.Resources", typeof(Reporte).Assembly);
            return resourceManager.GetString(key);
        }
    }
}
