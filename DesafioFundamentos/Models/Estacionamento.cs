using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placaVal = Console.ReadLine().ToUpper();
                        
        if (ValidarPlaca(placaVal))
        {
            Console.WriteLine("Placa válida. veículo adicionado com sucesso!");
            veiculos.Add(placaVal);
        }
        else
        {
            Console.WriteLine("Placa inválida, favor cadastrar novamente.");
        }

           }
            static bool ValidarPlaca(string placa)
    {
        // Padrão Mercosul (AAA1A23)
        string padraoMercosul = @"^[A-Z]{3}[0-9][A-Z][0-9]{2}$";
        // Padrão antigo (AAA1234)
        string padraoAntigo = @"^[A-Z]{3}[0-9]{4}$";

        // Valida se a placa corresponde a algum dos padrões usando Regex
        return Regex.IsMatch(placa, padraoMercosul) || Regex.IsMatch(placa, padraoAntigo);
    }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");


            string placa = Console.ReadLine();
            

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                int horas = Convert.ToInt32(Console.ReadLine());

                decimal valorTotal = precoInicial + (precoPorHora * horas); 

                veiculos.Remove(placa);
                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach(string item in veiculos){
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
