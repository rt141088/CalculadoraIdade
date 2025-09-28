using System;

namespace CalculadoraIdade
{
    class Program
    {
        // Struct obrigatória
        struct Pessoa
        {
            public string NomeCompleto;
            public DateTime DataNascimento;
        }

        static void Main(string[] args)
        {
            Pessoa pessoa;

            // Entrada de dados
            Console.Write("Digite seu nome completo: ");
            pessoa.NomeCompleto = Console.ReadLine();

            Console.Write("Digite sua data de nascimento (dd/MM/yyyy): ");
            DateTime dataNascimento;
            while (!DateTime.TryParse(Console.ReadLine(), out dataNascimento))
            {
                Console.WriteLine("Data inválida. Digite novamente no formato dd/MM/yyyy:");
            }
            pessoa.DataNascimento = dataNascimento;

            // Cálculo da idade
            int idade = CalcularIdade(pessoa.DataNascimento);

            // Saída
            Console.WriteLine($"\nOlá, {pessoa.NomeCompleto}!");
            Console.WriteLine($"Você tem {idade} anos.");

            if (idade >= 18)
            {
                Console.WriteLine("Você é maior de idade.");
                Console.WriteLine("Você pode tirar a carteira de habilitação para dirigir.");
            }
            else
            {
                Console.WriteLine("Você é menor de idade.");
                Console.WriteLine("Você ainda não pode tirar a carteira de habilitação.");
            }

            Console.WriteLine("\nPressione qualquer tecla para sair...");
            Console.ReadKey();
        }

        // Função para calcular idade
        static int CalcularIdade(DateTime dataNascimento)
        {
            DateTime hoje = DateTime.Now;
            int idade = hoje.Year - dataNascimento.Year;

            // Ajuste se ainda não fez aniversário no ano atual
            if (hoje.Month < dataNascimento.Month ||
               (hoje.Month == dataNascimento.Month && hoje.Day < dataNascimento.Day))
            {
                idade--;
            }

            return idade;
        }
    }
}
