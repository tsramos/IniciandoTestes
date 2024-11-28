using Bogus;
using IniciandoTestes.Entidades;
using IniciandoTestes.Servicos;
using IniciandoTestes.Tests.Builder;
using IniciandoTestes.Tests.MotherObjects;
using System.Collections.Generic;
using Xunit;

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
            yield return new object[]
            {
               FuncionarioMother.GetFuncionarioValidoPorSenioridade(Senioridade.Junior)
            };

            yield return new object[] 
            {
                new FuncionarioBuilder().ComNome()
                                        .ComNascimento()
                                        .ComSalarioValido(Senioridade.Pleno)
                                        .Build()
            }; 

            yield return new object[]
                {
                FuncionarioMother.GetFuncionarioValidoPorSenioridade(Senioridade.Senior)
            };
        }
    }
}
