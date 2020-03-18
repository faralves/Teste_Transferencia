No projeto FastMindBank, deve se alterar no arquivo "appsettings.json" a string de conexão para criar o Banco e as tabelas

No Banco de dados serão criadas 4 tabelas:
 Agencia = {Id, CodigoAgencia, DigitoAgencia}
 Banco = {Id, CodigoBanco, Nome}
 ContaCorrente = {Id, BancoId, AgenciaId, Conta, Digito, Saldo, NomeCliente}
 Lancamentos = {Id, Credito, Debito, Referencia, data, ContaCorrenteId}


Segue exemplo do Json para consulta via postMan, inserir o Json abaixo no body:

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

Banco	  Nome Banco          Agência Digito  Conta	    Digito  saldo	     Nome Cliente
237	    Bradesco	           1996	   8	      32961	    4	      100000.00	 Fernando Augusto
341	    Itau	               1234	   5	      32945	    1	      200000.00	 Michelle Saunitti
33	     Santander	          567	    6	      52974	    2	      300000.00	 Felipe Saunitti
1	      Banco do Brasil	    89	     7	      891584	   3	      400000.00	 Marcia Batista
104	    Caixa Economica	    789	    9	      15151	    4	      500000.00	 Willian Ribeiro
633	    Rendimento	         2005	   0	      3559	     5	      600000.00	 José de Jesus
422	    Safra	              324	    1	      589215	   6	      700000.00	 Rafaella Ribeiro


Regras impostas:
Não é permitido efetuar uma transferência com valor zerado.
Não é permitido efetuar transferência a partir de uma conta inexistente no banco de dados

Não é permitido efetuar transferência para uma conta inexistente no banco de dados (isso porque o teste proposto é para apenas efetuar transferência e acompanhar os lançamentos, 
poderia deixar enviar a transferência para qualquer conta, porém não teria como verificar os lançamentos a não ser que no momento do lançamento de uma transferência se a conta de destino não existisse no banco de dados fizesse o cadastro dela).


Na aplicação de testes "FastMindBank.TesteIntegracao" deixei preparado apenas uma transferência.
