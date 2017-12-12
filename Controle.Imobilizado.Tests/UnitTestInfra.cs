using Controle.Imobilizado.Domain.DomainEntities;
using Controle.Imobilizado.Infra.Data.Repository;
using Xunit;

namespace Controle.Imobilizado.Tests
{
    public class UnitTestInfra
    {
        private ImmobilizedRepository rep;

        public UnitTestInfra()
        {
            rep = new ImmobilizedRepository();
        }

        /// <summary>
        /// teste salvar
        /// </summary>
        [Theory]
        [InlineData("Cadeira", "novo", "3 andar", true, "12345")]
        [InlineData("Mesa", "novo", "4 andar", true, "12346")]
        [InlineData("Notebook", "novo", "5 andar", false, "12347")]
        public void SaveOk(string title, string description, string localization, bool active, string serial)
        {
            Immobilized immobilized = new Immobilized(title, description, localization, active, serial);
            rep.Save(immobilized);
        }

        /// <summary>
        /// Entidade nula
        /// </summary>
        /// <param name="Immobilized"></param>
        [Theory]
        [InlineData(null)]
        public void SaveEntityNull(Immobilized immobilized)
        {
            Assert.Equal(null, immobilized);
        }

        /// <summary>
        /// Serial existe cadastrado
        /// </summary>
        /// <param name="serial"></param>
        [Theory]
        [InlineData("12345")]
        public void SerialExist(string serial)
        {
            Assert.True(rep.HasExists(serial));
        }

        /// <summary>
        /// Verificar se esta retornando elementos
        /// </summary>
        [Fact]
        public void GetAll()
        {
            Assert.NotEmpty(rep.GetAll(0, 50));
        }
    }
}