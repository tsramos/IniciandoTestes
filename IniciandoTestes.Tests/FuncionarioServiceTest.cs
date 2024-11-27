using Bogus;
using System.Collections.Generic;
using System;
using Xunit;
using IniciandoTestes.Entidades;
using IniciandoTestes.Servicos;
using IniciandoTestes.Tests.MotherObjects;

namespace IniciandoTestes.Tests
{
    public class FuncionarioServiceTest
    {
        private readonly Faker _faker;

        public FuncionarioServiceTest()
        {
            _faker = new Faker();
        }


        [Theory]
        [MemberData(nameof(GetFuncionariosData))]
        public void AdicionarFuncionario_DeveConcluir_QuandoDadosValidos(Funcionario funcionario)
        {
            //Arrange
            FuncionarioService sut = new FuncionarioService();

            //Act - Assert
            sut.AdicionarFuncionario(funcionario);
        }

        public static IEnumerable<object[]> GetFuncionariosData()
        {
            var faker = new Faker();

            yield return new object[]
            {
               FuncionarioMother.GetFuncionarioValidoPorSenioridade(Senioridade.Junior)
            };

            yield return new object[] 
            {
                FuncionarioMother.GetFuncionarioValidoPorSenioridade(Senioridade.Pleno)
            };

            yield return new object[]
                {
                FuncionarioMother.GetFuncionarioValidoPorSenioridade(Senioridade.Senior)
            };
        }
    }
}
