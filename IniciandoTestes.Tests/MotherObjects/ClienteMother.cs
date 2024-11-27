using IniciandoTestes.Entidades;
using System;
using Bogus;

namespace IniciandoTestes.Tests.MotherObjects
{
    internal static class ClienteMother
    {
        public static Cliente GetClienteValido()
        {

            var faker = new Faker<Cliente>();
            faker.RuleFor(x => x.Nome, f => f.Name.FullName())
                 .RuleFor(x => x.Nascimento, f => f.Date.Past(50, DateTime.Now.AddYears(-18)))
                 .RuleFor(x => x.Id, Guid.NewGuid());

            return faker.Generate();
        }

        public static Cliente GetClienteSemId()
        {
            Faker<Cliente> faker = new Faker<Cliente>();
            faker.RuleFor(x => x.Nome, f => f.Name.FullName())
                 .RuleFor(x => x.Nascimento, f => f.Date.Past(50, DateTime.Now.AddYears(-18)));

            return faker.Generate();
        }


    }



}

