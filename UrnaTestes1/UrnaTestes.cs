    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrnaEletronica;
using Xunit;
using FluentAssertions;

namespace UrnaTestes1
{
    public class UrnaTestes
    {
        [Fact]
        public void TestarConstrutor()
        {
            //Arrange
            var urna = new Urna();
            var comparativo = new Urna
            {
                VencedorEleicao = "",
                VotosVencedor = 0,
                Candidatos = new List<Candidato>(),
                EleicaoAtiva = true
            };
            //Act /Assert
            urna.Should().BeEquivalentTo(comparativo);
        }
        [Fact]
        public void TestarInicio()
        {
            //Arrange
            var urna = new Urna();
            //Act /Assert
            Assert.True(urna.EleicaoAtiva);
        }
        [Fact]
        public void TestarTermino()
        {
            //Arrange
            var urna = new Urna();
            //Act
            urna.IniciarEncerrarEleicao();
            //Assert
            Assert.False(urna.EleicaoAtiva);
        }
        [Fact]
        public void TestarAdicionarCandidato()
        {
            //Assert
            var urna = new Urna();
            //Act
            urna.CadastrarCandidato("Eliel");
            urna.CadastrarCandidato("Kevin");
            //Assert
            Assert.Equal("Kevin", urna.Candidatos.LastOrDefault().Name);
        }
        [Fact]
        public void TestarVotarCandidatoNaoCadastrado()
        {
            //Assert
            var urna = new Urna();
            //Act
            urna.CadastrarCandidato("Eliel");
            urna.Votar("João");
            //Assert
            Assert.Equal(0, urna.Candidatos.First().Votes);
        }
        [Fact]
        public void TestarVotarCandidatoCadastrado()
        {
            //Assert
            var urna = new Urna();
            //Act
            urna.CadastrarCandidato("Eliel");
            urna.Votar("Eliel");
            //Assert
            Assert.Equal(1, urna.Candidatos.First().Votes);
        }
        [Fact]
        public void TestarResultado()
        {
            //Arrange
            var urna = new Urna();
            urna.CadastrarCandidato("Eliel");
            urna.CadastrarCandidato("Lais");
            urna.CadastrarCandidato("Calebe");
            urna.CadastrarCandidato("André");
            urna.CadastrarCandidato("Eduardo");
            //Act
            urna.Votar("Eliel");
            urna.Votar("Lais");
            urna.Votar("Lais");
            urna.Votar("Calebe");
            urna.Votar("Calebe");
            urna.Votar("Calebe");
            urna.Votar("André");
            urna.Votar("Eduardo");
            //Assert
            Assert.Equal("Nome vencedor: Calebe. Votos: 3", urna.MostrarResultadoEleicao());
        }
    }
}
