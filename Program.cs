/*
 Heurísticas de Nielsen aplicadas:

 #1 - Visibilidade do Status:
 O sistema indica em qual etapa o usuário está pelas mensagens:
 [Passo 1 de 3], [Passo 2 de 3], [Passo 3 de 3].

 #3 - Controle e Liberdade:
 O usuário pode digitar "voltar" para voltar à etapa anterior
 ou "cancelar" para terminar o pedido a qualquer momento.

 #9 - Ajuda e Erros:
 O sistema trata entradas inválidas e fornece mensagens claras,
 como quando o código do produto não existe ou quando o usuário
 digita algo que não é número.
*/

using System;

class Program
{
    static void Main()
    {
        int codigoProduto = 0;
        int quantidade = 0;

        while (true)
        {
            // PASSO 1 - CÓDIGO DO PRODUTO
            Console.WriteLine("\n[Passo 1 de 3] Seleção de Item");
            Console.WriteLine("Digite o código do produto (1 a 10):");
            Console.WriteLine("(Digite 'cancelar' para sair)");

            string inputCodigo = Console.ReadLine();

            if (inputCodigo.ToLower() == "cancelar")
            {
                Console.WriteLine("Pedido cancelado.");
                return;
            }

            if (!int.TryParse(inputCodigo, out codigoProduto))
            {
                Console.WriteLine("Entrada inválida. Digite apenas números.");
                continue;
            }

            if (codigoProduto < 1 || codigoProduto > 10)
            {
                Console.WriteLine($"Código {codigoProduto} não encontrado. Nossos códigos vão de 1 a 10. Tente novamente.");
                continue;
            }

            // PASSO 2 - QUANTIDADE
            while (true)
            {
                Console.WriteLine("\n[Passo 2 de 3] Quantidade");
                Console.WriteLine("Digite a quantidade:");
                Console.WriteLine("(Digite 'voltar' para retornar ou 'cancelar' para sair)");

                string inputQtd = Console.ReadLine();

                if (inputQtd.ToLower() == "cancelar")
                {
                    Console.WriteLine("Pedido cancelado.");
                    return;
                }

                if (inputQtd.ToLower() == "voltar")
                {
                    break; // volta para o passo anterior
                }

                if (!int.TryParse(inputQtd, out quantidade))
                {
                    Console.WriteLine("Entrada inválida. Digite apenas números.");
                    continue;
                }

                if (quantidade <= 0)
                {
                    Console.WriteLine("A quantidade deve ser maior que zero.");
                    continue;
                }

                // PASSO 3 - CONFIRMAÇÃO
                Console.WriteLine("\n[Passo 3 de 3] Confirmação");
                Console.WriteLine($"Produto: {codigoProduto}");
                Console.WriteLine($"Quantidade: {quantidade}");
                Console.WriteLine("Digite 'confirmar', 'voltar' ou 'cancelar'");

                string confirmacao = Console.ReadLine().ToLower();

                if (confirmacao == "cancelar")
                {
                    Console.WriteLine("Pedido cancelado.");
                    return;
                }
                else if (confirmacao == "voltar")
                {
                    continue; // volta para quantidade
                }
                else if (confirmacao == "confirmar")
                {
                    Console.WriteLine("\nPedido realizado com sucesso!");
                    Console.WriteLine("Obrigado por utilizar o sistema da cantina.");
                    return;
                }
                else
                {
                    Console.WriteLine("Opção inválida.");
                }
            }
        }
    }
}
