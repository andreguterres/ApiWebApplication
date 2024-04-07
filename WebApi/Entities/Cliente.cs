﻿using System.Reflection.Metadata;

namespace WebApi.Entities
{
    public class Cliente
    {
        //Nome, e-mail, Logotipo* e Logradouro
        public int ClienteId { get; set; }
        public string? Email { get; set; }
        public Blob Logotipo { get; set; }
        public List<Logradouro> Logradouros { get; set; } = new List<Logradouro>();

    }
}
