using Bogus;
using System.Collections.Generic;
using System;
using Xunit;
using IniciandoTestes.Entidades;
using IniciandoTestes.Servicos;

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
        public void AdicionarFuncionario_DeveConcluir_QuandoDadosValidos(Funcionario funcionario, int n1, string exemplo)
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
                new Funcionario()
                {
                    Nome = faker.Name.FullName(),
                    Nascimento = faker.Date.Between(DateTime.Now.AddDays(-21), DateTime.Now.AddDays(-50)),
                    Senioridade = Senioridade.Junior,
                    Salario = faker.Random.Double(3200,5500)
                },
                2,
                "Sucesso"
            };

            yield return new object[] { new Funcionario()
                {
                    Nome = faker.Name.FullName(),
                    Nascimento = faker.Date.Between(DateTime.Now.AddDays(-21), DateTime.Now.AddDays(-50)),
                    Senioridade = Senioridade.Pleno,
                    Salario = faker.Random.Double(5500,8000)
                },
                5,
                "Falha"
            };

            yield return new object[] { new Funcionario()
                {
                    Nome = faker.Name.FullName(),
                    Nascimento = faker.Date.Between(DateTime.Now.AddDays(-21), DateTime.Now.AddDays(-50)),
                    Senioridade = Senioridade.Senior,
                    Salario = faker.Random.Double(8000,20000)
                }, 10, "Uhuuul"
            };
        }
    }
}
