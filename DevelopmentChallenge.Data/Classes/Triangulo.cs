using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Classes
{
    public class Triangulo : FormaGeometrica
    {
        private readonly decimal _lado1;
        private readonly decimal _lado2;
        private readonly decimal _lado3;
        public override string Nombre => "Triángulo";

        public Triangulo(decimal lado)
        {
            _lado1 = lado;
            _lado2 = lado;
            _lado3 = lado;
        }
        public Triangulo(decimal lado1, decimal lado2, decimal lado3)
        {
            _lado1 = lado1;
            _lado2 = lado2;
            _lado3 = lado3;
        }

        public string Tipo
        {
            get
            {
                if (_lado1 == _lado2 && _lado2 == _lado3)
                {
                    return "Equilátero";
                }
                else if (_lado1 == _lado2 || _lado1 == _lado3 || _lado2 == _lado3)
                {
                    return "Isósceles";
                }
                else
                {
                    return "Escaleno";
                }
            }
        }

        public override decimal CalcularArea()
        {
            decimal semiperimetro = CalcularPerimetro() / 2;
            return (decimal) Math.Sqrt((double) (semiperimetro * (semiperimetro - _lado1) * (semiperimetro - _lado2) * (semiperimetro - _lado3)));
        }

        public override decimal CalcularPerimetro()
        {
            return _lado1 + _lado2 + _lado3;
        }
    }
}
