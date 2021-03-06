﻿using FastMindBank.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FastMindBank.Models
{
    public class SeedData
    {
        public static void SeedDatabase(FastMindBankContext context)
        {
            context.Database.Migrate();

            Model.Banco banco = context.Banco.Where(x => x.CodigoBanco > 0).FirstOrDefault();

            if (banco == null)
            {
                context.ContaCorrente.AddRange(
                     new Model.ContaCorrente
                     {
                         Banco = new Model.Banco { CodigoBanco = 237, Nome = "Bradesco" },
                         Agencia = new Model.Agencia { CodigoAgencia = 1996, DigitoAgencia = 8 },
                         Saldo = 100000,
                         NomeCliente = "Fernando Augusto",
                         Conta = 32961,
                         Digito = 4,
                         Lancamentos = new List<Model.Lancamentos> { new Model.Lancamentos(100000, 0, "Ref 1 - Criação da Conta", DateTime.Now) }
                     },
                     new Model.ContaCorrente
                     {
                         Banco = new Model.Banco { CodigoBanco = 341, Nome = "Itau" },
                         Agencia = new Model.Agencia { CodigoAgencia = 1234, DigitoAgencia = 5 },
                         Saldo = 200000,
                         NomeCliente = "Michelle Saunitti",
                         Conta = 32945,
                         Digito = 1,
                         Lancamentos = new List<Model.Lancamentos> { new Model.Lancamentos(200000, 0, "Ref 2 - Criação da Conta", DateTime.Now) }
                     },
                     new Model.ContaCorrente
                     {
                         Banco = new Model.Banco { CodigoBanco = 33, Nome = "Santander" },
                         Agencia = new Model.Agencia { CodigoAgencia = 567, DigitoAgencia = 6 },
                         Saldo = 300000,
                         NomeCliente = "Felipe Saunitti",
                         Conta = 52974,
                         Digito = 2,
                         Lancamentos = new List<Model.Lancamentos> { new Model.Lancamentos(300000, 0, "Ref 3 -Criação da Conta", DateTime.Now) }
                     },
                     new Model.ContaCorrente
                     {
                         Banco = new Model.Banco { CodigoBanco = 1, Nome = "Banco do Brasil" },
                         Agencia = new Model.Agencia { CodigoAgencia = 89, DigitoAgencia = 7 },
                         Saldo = 400000,
                         NomeCliente = "Marcia Batista",
                         Conta = 891584,
                         Digito = 3,
                         Lancamentos = new List<Model.Lancamentos> { new Model.Lancamentos(400000, 0, "Ref 4 - Criação da Conta", DateTime.Now) }
                     },
                     new Model.ContaCorrente
                     {
                         Banco = new Model.Banco { CodigoBanco = 104, Nome = "Caixa Economica" },
                         Agencia = new Model.Agencia { CodigoAgencia = 789, DigitoAgencia = 9 },
                         Saldo = 500000,
                         NomeCliente = "Willian Ribeiro",
                         Conta = 15151,
                         Digito = 4,
                         Lancamentos = new List<Model.Lancamentos> { new Model.Lancamentos(500000, 0, "Ref 5 - Criação da Conta", DateTime.Now) }
                     },
                     new Model.ContaCorrente
                     {
                         Banco = new Model.Banco { CodigoBanco = 633, Nome = "Rendimento" },
                         Agencia = new Model.Agencia { CodigoAgencia = 2005, DigitoAgencia = 0 },
                         Saldo = 600000,
                         NomeCliente = "José de Jesus",
                         Conta = 3559,
                         Digito = 5,
                         Lancamentos = new List<Model.Lancamentos> { new Model.Lancamentos(600000, 0, "Ref 6 - Criação da Conta", DateTime.Now) }
                     },
                     new Model.ContaCorrente
                     {
                         Banco = new Model.Banco { CodigoBanco = 422, Nome = "Safra" },
                         Agencia = new Model.Agencia { CodigoAgencia = 324, DigitoAgencia = 1 },
                         Saldo = 700000,
                         NomeCliente = "Rafaella Ribeiro",
                         Conta = 589215,
                         Digito = 6,
                         Lancamentos = new List<Model.Lancamentos> { new Model.Lancamentos(700000, 0, "Ref 7 - Criação da Conta", DateTime.Now) }
                     }
                    );
                context.SaveChanges();
            }
        }

    }
}
