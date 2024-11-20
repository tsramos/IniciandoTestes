using System;

namespace IniciandoTestes.Entidades
{
    public class Cliente
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime Nascimento { get; set; }
    }
}
