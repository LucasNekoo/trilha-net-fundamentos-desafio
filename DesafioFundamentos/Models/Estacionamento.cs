using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        // Variáveis para armazenar os preços do estacionamento
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;

        // Lista para armazenar as placas dos veículos estacionados
        private List<string> veiculos = new List<string>();

        // Construtor que recebe os preços iniciais do estacionamento
        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        // Método para adicionar um veículo ao estacionamento
        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();

            // Verifica se a placa já está cadastrada
            if (!veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                veiculos.Add(placa.ToUpper());
                Console.WriteLine($"Veículo com placa {placa} estacionado com sucesso!");
            }
            else
            {
                Console.WriteLine($"Veículo com placa {placa} já está estacionado.");
            }
        }

        // Método para remover um veículo do estacionamento
        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                if (int.TryParse(Console.ReadLine(), out int horas))
                {
                    // Calcula o preço total com base nas horas e preços definidos
                    decimal valorTotal = precoInicial + precoPorHora * horas;

                    // Remove a placa digitada da lista de veículos
                    veiculos.Remove(placa.ToUpper());

                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                }
                else
                {
                    Console.WriteLine("Quantidade de horas inválida.");
                }
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        // Método para listar os veículos estacionados
        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
