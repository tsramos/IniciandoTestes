using Bogus;
using IniciandoTestes.Entidades;
using System;

namespace IniciandoTestes.Tests.Builder
{
    internal class FuncionarioBuilder
    {
        private Funcionario _instancia;
        private Faker _faker;

        public FuncionarioBuilder()
        {
            _instancia = new Funcionario();
            _faker = new Faker();
        }

        public FuncionarioBuilder ComNome(string nome = null)
        {
            if (string.IsNullOrEmpty(nome))
                nome = _faker.Name.FullName();

            _instancia.Nome = nome;
            return this;
        }

        public FuncionarioBuilder ComNascimento(DateTime nascimento = default)
        {
            if (nascimento == default)
                nascimento = _faker.Date.Past(50, DateTime.Now.AddYears(-21));

            _instancia.Nascimento = nascimento;            
            return this;
        }

        public FuncionarioBuilder ComSalarioValido(Senioridade senioridade)
        {
            _instancia.Senioridade = senioridade;
            switch (senioridade)
            {
                case Senioridade.Junior:
                    _instancia.Salario = (double)_faker.Finance.Amount(3200, 5500, 2);
                    break;
                case Senioridade.Pleno:
                    _instancia.Salario = (double)_faker.Finance.Amount(5500, 8000, 2);
                    break;
                case Senioridade.Senior:
                    _instancia.Salario = (double)_faker.Finance.Amount(8000, 20000, 2);
                    break;
            }

            return this;
        }

        public Funcionario Build()
        {
            return _instancia;
        }
    }
}
