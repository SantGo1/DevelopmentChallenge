using System;
using System.Collections.Generic;
using DevelopmentChallenge.Data.Classes;
using NUnit.Framework;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        public void TestResumenListaVacia()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                new Reporte(new List<FormaGeometrica>()).GenerarReporte(1));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                new Reporte(new List<FormaGeometrica>()).GenerarReporte(2));
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var cuadrados = new List<FormaGeometrica> {new Cuadrado(5)};

            var resumen = new Reporte(cuadrados).GenerarReporte(1);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 Forma Perimetro 20 Area 25", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var cuadrados = new List<FormaGeometrica>
            {
                new Cuadrado (5),
                new Cuadrado (1),
                new Cuadrado (3)
            };

            var resumen = new Reporte(cuadrados).GenerarReporte(2);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 Shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            var formas = new List<FormaGeometrica>
            {
                new Cuadrado (5),
                new Circulo(3),
                new Triangulo(4),
                new Cuadrado (2),
                new Triangulo(9),
                new Circulo(2.75m),
                new Triangulo(4.2m)
            };

            var resumen = new Reporte(formas).GenerarReporte(2);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13.01 | Perimeter 18.06 <br/>3 Triangles | Area 49.64 | Perimeter 51.6 <br/>TOTAL:<br/>7 Shapes Perimeter 97.66 Area 91.65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<FormaGeometrica>
            {
                new Cuadrado (5),
                new Circulo (3),
                new Triangulo(4),
                new Cuadrado (2),
                new Triangulo(9),
                new Circulo(2.75m),
                new Triangulo(4.2m)
            };

            var resumen = new Reporte(formas).GenerarReporte(1);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13.01 | Perimetro 18.06 <br/>3 Triángulos | Area 49.64 | Perimetro 51.6 <br/>TOTAL:<br/>7 Formas Perimetro 97.66 Area 91.65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnItaliano()
        {
            Assert.AreEqual("<h1>Lista vuota di forme!</h1>",
                new Reporte(new List<FormaGeometrica>()).GenerarReporte(3));
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnItaliano()
        {
            var formas = new List<FormaGeometrica>
            {
                new Cuadrado (5),
                new Circulo (3),
                new Triangulo(4),
                new Cuadrado (2),
                new Triangulo(9),
                new Circulo(2.75m),
                new Triangulo(4.2m)
            };

            var resumen = new Reporte(formas).GenerarReporte(3);

            Assert.AreEqual(
                "<h1>Report di Forme</h1>2 Quadrati | Area 29 | Perimetro 28 <br/>2 Cerchi | Area 13.01 | Perimetro 18.06 <br/>3 Triangoli | Area 49.64 | Perimetro 51.6 <br/>TOTALE:<br/>7 Forme Perimetro 97.66 Area 91.65",
                resumen);
        }
    }
}
