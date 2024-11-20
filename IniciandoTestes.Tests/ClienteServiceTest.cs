using Xunit;
using IniciandoTestes.Servicos;
using IniciandoTestes.Tests.Fakes;
using IniciandoTestes.Entidades;
using Bogus;
using System;
using Moq;
using IniciandoTestes.Contratos;


namespace IniciandoTestes.Tests
{
    public class ClienteServiceTest
    {
        [Fact]
        public void AdicionarCLiente_DeveAdicionarComSucesso_QuandoClienteValido()
        {
            //Arrange
            Mock<IClienteRepository> clienteRepositoryMock = new Mock<IClienteRepository>();
            clienteRepositoryMock.Setup(x => x.GetCliente(It.IsAny<Guid>())).Returns(new Cliente());
            ClienteService sut = new ClienteService(clienteRepositoryMock.Object);
            Faker faker = new Faker();
            Cliente cliente = new Cliente()
            {
                Id = Guid.NewGuid(),
                Nome = faker.Name.FullName(),
                Nascimento = new System.DateTime(1900, 12, 12)
            };

            //Act

            sut.AddClliente(cliente);

            //Assert
        }

        [Fact]
        public void AddCliente_DeveQuebrar_QuandoClienteJaExiste()
        {
            Faker faker = new Faker();
            Cliente cliente = new Cliente()
            {
                Nome = faker.Name.FullName(),
                Nascimento = new System.DateTime(1900, 12, 12),
                Id = Guid.NewGuid(),
            };

            Mock<IClienteRepository> clienteRepositoryMock = new Mock<IClienteRepository>();
            clienteRepositoryMock.Setup(x => x.GetCliente(It.IsAny<Guid>())).Returns(cliente);
              
            ClienteService sut = new ClienteService(clienteRepositoryMock.Object);
            

            Assert.Throws<Exception>(() => sut.AddClliente(cliente));
        }
    }
}
