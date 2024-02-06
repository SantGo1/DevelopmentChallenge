/******************************************************************************************************************/
/******* ¿Qué pasa si debemos soportar un nuevo idioma para los reportes, o agregar más formas geométricas? *******/
/******************************************************************************************************************/

/*
 * TODO: 
 * Refactorizar la clase para respetar principios de la programación orientada a objetos.
 * Implementar la forma Trapecio/Rectangulo. 
 * Agregar el idioma Italiano (o el deseado) al reporte.
 * Se agradece la inclusión de nuevos tests unitarios para validar el comportamiento de la nueva funcionalidad agregada (los tests deben pasar correctamente al entregar la solución, incluso los actuales.)
 * Una vez finalizado, hay que subir el código a un repo GIT y ofrecernos la URL para que podamos utilizar la nueva versión :).
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevelopmentChallenge.Data.Classes
{
    
    public abstract class FormaGeometrica
    {
        public abstract string Nombre { get; }
        public abstract decimal CalcularArea();
        public abstract decimal CalcularPerimetro();
    }

    public class Cuadrado : FormaGeometrica
    {
        private readonly decimal _lado;

        public Cuadrado(decimal lado)
        {
            _lado = lado;
        }

        public override string Nombre => "Cuadrado";

        public override decimal CalcularArea()
        {
            return _lado * _lado;
        }

        public override decimal CalcularPerimetro()
        {
            return _lado * 4;
        }
    }

    public class Circulo : FormaGeometrica
    {
        private readonly decimal _radio;

        public Circulo(decimal radio)
        {
            _radio = radio;
        }

        public override string Nombre => "Círculo";

        public override decimal CalcularArea()
        {
            return (decimal)Math.PI * (_radio * _radio);
        }

        public override decimal CalcularPerimetro()
        {
            return (decimal)Math.PI * (_radio * 2);
        }
    }

    public class TrianguloEquilatero : FormaGeometrica
    {
        private readonly decimal _lado;

        public TrianguloEquilatero(decimal lado)
        {
            _lado = lado;
        }

        public override string Nombre => "Triángulo";

        public override decimal CalcularArea()
        {
            return (_lado * _lado * (decimal)Math.Sqrt(3)) / 4;
        }

        public override decimal CalcularPerimetro()
        {
            return _lado * 3;
        }
    }

    public class Trapecio : FormaGeometrica
    {
        private readonly decimal _baseMayor;
        private readonly decimal _baseMenor;
        private readonly decimal _altura;

        public Trapecio(decimal baseMayor, decimal baseMenor, decimal altura)
        {
            _baseMayor = baseMayor;
            _baseMenor = baseMenor;
            _altura = altura;
        }

        public override string Nombre => "Trapecio";

        public override decimal CalcularArea()
        {
            return ((_baseMayor + _baseMenor) * _altura) / 2;
        }

        public override decimal CalcularPerimetro()
        {
            return _baseMayor + _baseMenor + (2 * (decimal)Math.Sqrt((double)(_altura * _altura + ((_baseMayor - _baseMenor) / 2) * ((_baseMayor - _baseMenor) / 2))));
        }
    }

    public class FormaGeometricaReporte
    {
        private readonly List<FormaGeometrica> _formas;

        public FormaGeometricaReporte(List<FormaGeometrica> formas)
        {
            _formas = formas;
        }

        public string GenerarReporte(int idioma)
        {
            var sb = new StringBuilder();

            if (!_formas.Any())
            {
                sb.Append(GetResourceString("EmptyListMessage", idioma));
            }
            else
            {
                sb.Append(GetResourceString("ReportHeader", idioma));

                var formasAgrupadas = _formas.GroupBy(f => f.Nombre);

                foreach (var forma in formasAgrupadas)
                {
                    var cantidad = forma.Count();
                    var areaTotal = forma.Sum(f => f.CalcularArea());
                    var perimetroTotal = forma.Sum(f => f.CalcularPerimetro());

                    sb.Append(GetResourceString("FormaLine", idioma, cantidad, forma.Key, areaTotal, perimetroTotal));
                }

                var totalFormas = _formas.Count;
                var totalPerimetro = _formas.Sum(f => f.CalcularPerimetro());
                var totalArea = _formas.Sum(f => f.CalcularArea());

                sb.Append(GetResourceString("ReportFooter", idioma, totalFormas, totalPerimetro, totalArea));
            }

            return sb.ToString();
        }

        private string GetResourceString(string key, int idioma, params object[] args)
        {
            var resourceManager = new ResourceManager(typeof(Resources.Resource));
            var cultureInfo = new CultureInfo(idioma);
            var format = resourceManager.GetString(key, cultureInfo);

            return string.Format(format, args);
        }
    }
}
