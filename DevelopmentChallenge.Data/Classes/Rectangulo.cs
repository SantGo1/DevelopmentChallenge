using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Classes
{
    internal class Rectangulo : FormaGeometrica
    {
        private readonly decimal _base;
        private readonly decimal _altura;
        public override string Nombre => "Rectangulo";

        public Rectangulo(decimal @base, decimal altura)
        {
            _base = @base;
            _altura = altura;
        }

        public override decimal CalcularArea()
        {
            return _base * _altura;
        }

        public override decimal CalcularPerimetro()
        {
            return 2 * (_base + _altura);
        }
    }
}
