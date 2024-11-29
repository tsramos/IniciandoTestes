using Bogus;
using IniciandoTestes.Contratos;
using IniciandoTestes.Entidades;
using IniciandoTestes.Servicos;
using IniciandoTestes.Tests.MotherObjects;
using Moq;
using System;
using Xunit;

namespace IniciandoTestes.Tests
{
    public class ClienteServiceTest
    {
        private readonly Faker _faker;
        private readonly Mock<IClienteRepository> _mockRepository;
        private readonly ClienteService _sut;

        public ClienteServiceTest()
        {
            _faker = new Faker();
            _mockRepository = new Mock<IClienteRepository>();
            _sut = new ClienteService(_mockRepository.Object);
        }

        [Fact]
        public void AdicionarCLiente_DeveAdicionarComSucesso_QuandoClienteValido()
        {
            //Arrange
            _mockRepository.Setup(x => x.GetCliente(It.IsAny<Guid>())).Returns(new Cliente());                        
            var cliente = ClienteMother.GetClienteValido();

            //Act
            _sut.AddClliente(cliente);

            //Assert
            _mockRepository.Verify(x => x.GetCliente(It.IsAny<Guid>()), Times.Once());
            _mockRepository.Verify(x => x.AddCliente(cliente), Times.Once());
        }

        [Fact]
        public void TesteEx()
        {
            //Arrange
            var resultadoEsperado = "Responda a mensagem na proxima vez";

            //Act
            var result = _sut.ExemploAtrasadinhoQueNaoAvisaEDepoisEncheOSaco();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(resultadoEsperado, result);
        }

        [Fact]
        public void AddCliente_DeveQuebrar_QuandoClienteJaExiste()
        {
            //Arrange            
            Cliente cliente = ClienteMother.GetClienteSemId();
                        
            _mockRepository.Setup(x => x.GetCliente(It.IsAny<Guid>())).Returns(cliente);            

            //Act - Assert   // x => x.  -- () => 
            Assert.Throws<Exception>(() => _sut.AddClliente(cliente));
        }
    }
}
