using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Classes
{
    public class Trapecio : FormaGeometrica
    {
        private readonly decimal _baseMayor;
        private readonly decimal _baseMenor;
        private readonly decimal _altura;
        public override string Nombre => "Trapecio";

        public Trapecio(decimal baseMayor, decimal baseMenor, decimal altura)
        {
            _baseMayor = baseMayor;
            _baseMenor = baseMenor;
            _altura = altura;
        }

        public override decimal CalcularArea()
        {
            return ((_baseMayor + _baseMenor) * _altura) / 2;
        }

        public override decimal CalcularPerimetro()
        {
            return _baseMayor + _baseMenor + (2 * (decimal)Math.Sqrt((double)(_altura * _altura + ((_baseMayor - _baseMenor) / 2) * ((_baseMayor - _baseMenor) / 2))));
        }
    }
}
