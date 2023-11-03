using Moq;
using TechOil.Models;
using TechOil.Repository;
using TechOil.Services;

namespace TechOil.Tests
{
    [TestClass]
    public class PruebasProyecto
    {
        [TestMethod]
        public void PruebaObtenerTodosLosProyectos()
        {
            // Arrange
            var mockRepository = new Mock<IProyectoRepository>();
            mockRepository.Setup(repo => repo.GetAll())
                         .Returns(new List<Proyecto>
                         {
                new Proyecto { codProyecto = 1, nombre = "Juan", direccion = "Test 123", estado = 1 },
                new Proyecto { codProyecto = 2, nombre = "Carlos", direccion = "Test 123", estado = 2 },
                new Proyecto { codProyecto = 3, nombre = "Matias", direccion = "Test 123", estado = 3 }
            });
            var proyectoService = new ProyectoService(mockRepository.Object);
            // Act
            var proyectos = proyectoService.ObtenerTodosLosProyectos();

            // Assert
            Assert.IsNotNull(proyectos);
            Assert.AreEqual(3, proyectos.Count());
        }

        [TestMethod]
        public void PruebaObtenerPorEstado()
        {
            var estado = 1;

            // Crea una lista de proyectos con diferentes estados
            var listaDeProyectos = new List<Proyecto>
            {
                new Proyecto { codProyecto = 1, nombre = "Juan", direccion = "Test 123", estado = 1 },
                new Proyecto { codProyecto = 2, nombre = "Carlos", direccion = "Test 123", estado = 2 },
                new Proyecto { codProyecto = 3, nombre = "Matias", direccion = "Test 123", estado = 1 }
            };

            // Filtra la lista de proyectos para solo incluir los que coinciden con el estado especificado
            var listaFiltrada = listaDeProyectos.Where(p => p.estado == estado).ToList();

            // Arrange
            var mockRepository = new Mock<IProyectoRepository>();
            mockRepository.Setup(repo => repo.GetByState(estado))
                 .Returns(listaFiltrada);

            var proyectoService = new ProyectoService(mockRepository.Object);

            // Act
            var proyectos = proyectoService.ObtenerProyectoPorEstado(estado);

            // Assert
            Assert.IsNotNull(proyectos);
            Assert.AreEqual(listaFiltrada.Count(), proyectos.Count()); // Verifica que haya la misma cantidad de proyectos que en la lista filtrada.
        }

    }

}