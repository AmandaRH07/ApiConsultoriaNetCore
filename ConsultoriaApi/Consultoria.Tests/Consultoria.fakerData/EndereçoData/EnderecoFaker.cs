﻿using Bogus;
using Consultoria.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consultoria.FakerData.EndereçoData
{
    public class EnderecoFaker : Faker<Endereco>
    {
        public EnderecoFaker(int clientId)
        {
            RuleFor(o => o.ClienteId, f => clientId);
            RuleFor(o => o.Numero, f => f.Address.BuildingNumber());
            RuleFor(o => o.CEP, f => Convert.ToInt32(f.Address.ZipCode().Replace("-", "")));
            RuleFor(o => o.Cidade, f => f.Address.City());
            RuleFor(o => o.Estado, f => f.PickRandom<Estado>());
            RuleFor(o => o.Logradouro, f => f.Address.StreetName());
            RuleFor(o => o.Complemento, f => f.Lorem.Sentence(10));
        }
    }
}
