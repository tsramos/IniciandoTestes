﻿using Bogus;
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
        [Fact]
        public void AdicionarCLiente_DeveAdicionarComSucesso_QuandoClienteValido()
        {
            //Arrange
            Mock<IClienteRepository> clienteRepositoryMock = new Mock<IClienteRepository>();
            clienteRepositoryMock.Setup(x => x.GetCliente(It.IsAny<Guid>())).Returns(new Cliente());
            ClienteService sut = new ClienteService(clienteRepositoryMock.Object);
            Faker faker = new Faker();
            var cliente = ClienteMother.GetClienteValido();

            //Act

            sut.AddClliente(cliente);

            //Assert

            clienteRepositoryMock.Verify(x => x.GetCliente(It.IsAny<Guid>()), Times.Once());
            clienteRepositoryMock.Verify(x => x.AddCliente(cliente), Times.Once());

        }

        [Fact]
        public void TesteEx()
        {
            Mock<IClienteRepository> mock = new Mock<IClienteRepository>();
            ClienteService clienteService = new ClienteService(mock.Object);

            var result = clienteService.ExemploAtrasadinhoQueNaoAvisaEDepoisEncheOSaco();
            var resultadoEsperado = "Responda a mensagem na proxima vez";
            Assert.NotNull(result);
            Assert.Equal(resultadoEsperado, result);
        }

        [Fact]
        public void AddCliente_DeveQuebrar_QuandoClienteJaExiste()
        {
            //Arrange
            Faker faker = new Faker();
            Cliente cliente = ClienteMother.GetClienteSemId();

            Mock<IClienteRepository> clienteRepositoryMock = new Mock<IClienteRepository>();
            clienteRepositoryMock.Setup(x => x.GetCliente(It.IsAny<Guid>())).Returns(cliente);

            ClienteService sut = new ClienteService(clienteRepositoryMock.Object);

            //Act - Assert   // x => x.  -- () => 
            Assert.Throws<Exception>(() => sut.AddClliente(cliente));
        }
    }
}
