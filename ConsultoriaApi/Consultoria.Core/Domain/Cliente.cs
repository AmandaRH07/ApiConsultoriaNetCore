﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Consultoria.Core.Domain
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}