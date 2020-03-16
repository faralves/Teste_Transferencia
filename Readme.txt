No Banco de dados serão criadas 4 tabelas:
 Agencia
 Banco
 ContaCorrente
 Lancamentos

 No projeto FastMindBank, deve se alterar no arquivo "appsettings.json" a string de conexão para criar o Banco e as tabelas

Segue exemplo do Json para consulta:

{
    "contaCorrenteCredito": {
        "banco": {
            "codigoBanco": 237,
        },
        "agencia": {
            "codigoAgencia": 1996,
            "digitoAgencia": 8,
        },
        "conta": 32961,
        "digito": 4,
    },
    "contaCorrenteDebito": {
        "banco": {
            "codigoBanco": 341,
        },
        "agencia": {
            "codigoAgencia": 1234,
            "digitoAgencia": 5,
        },
        "conta": 32945,
        "digito": 1,
    },
    "montante": 259.46
}


Estão cadastradas 7 contas:

                     new Model.ContaCorrente
                     {
                         Banco = new Model.Banco { CodigoBanco = 237, Nome = "Bradesco" },
                         Agencia = new Model.Agencia { CodigoAgencia = 1996, DigitoAgencia = 8 },
                         Saldo = 100000,
                         ClienteRef = "Ref 1 - Criação da Conta",
                         Conta = 32961,
                         Digito = 4,
                         Lancamentos = new List<Model.Lancamentos> { new Model.Lancamentos(100000, 0, "Ref 1 - Criação da Conta", DateTime.Now) }
                     },
                     new Model.ContaCorrente
                     {
                         Banco = new Model.Banco { CodigoBanco = 341, Nome = "Itau" },
                         Agencia = new Model.Agencia { CodigoAgencia = 1234, DigitoAgencia = 5 },
                         Saldo = 200000,
                         ClienteRef = "Ref 2 - Criação da Conta",
                         Conta = 32945,
                         Digito = 1,
                         Lancamentos = new List<Model.Lancamentos> { new Model.Lancamentos(200000, 0, "Ref 2 - Criação da Conta", DateTime.Now) }
                     },
                     new Model.ContaCorrente
                     {
                         Banco = new Model.Banco { CodigoBanco = 33, Nome = "Santander" },
                         Agencia = new Model.Agencia { CodigoAgencia = 567, DigitoAgencia = 6 },
                         Saldo = 300000,
                         ClienteRef = "Ref 3 - Criação da Conta",
                         Conta = 52974,
                         Digito = 2,
                         Lancamentos = new List<Model.Lancamentos> { new Model.Lancamentos(300000, 0, "Ref 3 -Criação da Conta", DateTime.Now) }
                     },
                     new Model.ContaCorrente
                     {
                         Banco = new Model.Banco { CodigoBanco = 1, Nome = "Banco do Brasil" },
                         Agencia = new Model.Agencia { CodigoAgencia = 89, DigitoAgencia = 7 },
                         Saldo = 400000,
                         ClienteRef = "Ref 4 - Criação da Conta",
                         Conta = 891584,
                         Digito = 3,
                         Lancamentos = new List<Model.Lancamentos> { new Model.Lancamentos(400000, 0, "Ref 4 - Criação da Conta", DateTime.Now) }
                     },
                     new Model.ContaCorrente
                     {
                         Banco = new Model.Banco { CodigoBanco = 104, Nome = "Caixa Economica" },
                         Agencia = new Model.Agencia { CodigoAgencia = 789, DigitoAgencia = 9 },
                         Saldo = 500000,
                         ClienteRef = "Ref 5 - Criação da Conta",
                         Conta = 15151,
                         Digito = 4,
                         Lancamentos = new List<Model.Lancamentos> { new Model.Lancamentos(500000, 0, "Ref 5 - Criação da Conta", DateTime.Now) }
                     },
                     new Model.ContaCorrente
                     {
                         Banco = new Model.Banco { CodigoBanco = 633, Nome = "Rendimento" },
                         Agencia = new Model.Agencia { CodigoAgencia = 2005, DigitoAgencia = 0 },
                         Saldo = 600000,
                         ClienteRef = "Ref 6 - Criação da Conta",
                         Conta = 3559,
                         Digito = 5,
                         Lancamentos = new List<Model.Lancamentos> { new Model.Lancamentos(600000, 0, "Ref 6 - Criação da Conta", DateTime.Now) }
                     },
                     new Model.ContaCorrente
                     {
                         Banco = new Model.Banco { CodigoBanco = 422, Nome = "Safra" },
                         Agencia = new Model.Agencia { CodigoAgencia = 324, DigitoAgencia = 1 },
                         Saldo = 700000,
                         ClienteRef = "Ref 7 - Criação da Conta",
                         Conta = 589215,
                         Digito = 6,
                         Lancamentos = new List<Model.Lancamentos> { new Model.Lancamentos(700000, 0, "Ref 7 - Criação da Conta", DateTime.Now) }
                     }
                    );

