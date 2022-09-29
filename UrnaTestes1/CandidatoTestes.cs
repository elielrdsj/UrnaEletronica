using Xunit;
using UrnaEletronica;

namespace UrnaTestes1
{
    public class CandidatoTestes
    {
        [Theory]
        [InlineData("Kevin")]
        [InlineData("")]
        [InlineData(null)]
        public void ValidarCandidato0Votos(string name)
        {
            //Arrange
            var candidato = new Candidato(name);
            //Act
            var retorno = candidato.RetornarVotos();
            //Assert
            Assert.Equal(0, retorno);
        }
        [Fact]
        public void ValidarNomeCandidato()
        {
            //Arrange
            string name = "Eliel";
            var candidato = new Candidato(name);
            //Act /Assert
            Assert.Equal(name, candidato.Name);
        }

    }
}