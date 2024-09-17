﻿using System;

namespace CalculaImposto;
class Program
{
    static void Main()
    {
        int numeroContribuintes;
        while (true)
        {
            Console.Write("Informe o número de contribuintes a calcular: ");
            if (int.TryParse(Console.ReadLine(), out numeroContribuintes) && numeroContribuintes > 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("Por favor, informe um valor válido para o número de contribuintes.");
            }
        }

        for (int i = 0; i < numeroContribuintes; i++)
        {
            Console.WriteLine($"\nContribuinte {i + 1}");
            Console.WriteLine("Informe o nome do contribuinte: ");
            string nomeContribuinte = Console.ReadLine() ?? "Desconhecido";

            decimal salarioBruto;
            while (true)
            {
                Console.Write("Informe um valor válido para salário: ");
                if (decimal.TryParse(Console.ReadLine(), out salarioBruto) && salarioBruto >= 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("Por favor, informe um valor válido para salário.");
            }
            }
                decimal desconto = CalcularDesconto(salarioBruto);
                decimal salarioLiquido = salarioBruto - desconto;

                Console.WriteLine($"Nome do Contribuinte: {nomeContribuinte}");
                Console.WriteLine($"Salário Bruto: R$ {salarioBruto:F2}");
                Console.WriteLine($"Desconto: R$ {desconto:F2}");
                Console.WriteLine($"Salário Líquido: R$ {salarioLiquido:F2}");
        }
    }

    static decimal CalcularDesconto(decimal salarioBruto)
    {
        decimal aliquota;
        decimal deducao;

        if (salarioBruto <= 1903.99m)
        {
            aliquota = 0m;
            deducao = 0m;
        }
        else if (salarioBruto <= 2826.65m)
        {
            aliquota = 0.075m;
            deducao = 142.80m;
        }
        else if (salarioBruto <= 3751.05m)
        {
            aliquota = 0.15m;
            deducao = 354.80m;
        }
        else if (salarioBruto <= 4664.68m)
        {
            aliquota = 0.225m;
            deducao = 636.13m;
        }
        else
        {
            aliquota = 0.275m;
            deducao = 869.36m;
        }

        decimal desconto = salarioBruto * aliquota - deducao;
        return desconto;
    }
}
