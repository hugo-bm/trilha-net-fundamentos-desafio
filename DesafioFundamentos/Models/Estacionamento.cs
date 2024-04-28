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

        private static bool VerificarPlaca(string placa)
        {

            Regex expressaoRegular = new Regex("^[a-zA-Z]{3}[0-9][A-Za-z0-9][0-9]{2}$");
            return expressaoRegular.IsMatch(placa);
        }
        public void AdicionarVeiculo()
        {
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            while (true)
            {
                Console.WriteLine("Digite a placa do veículo para estacionar:");
                string placa = Console.ReadLine().ToUpper();
                if (VerificarPlaca(placa))
                {
                    if(!veiculos.Any(x => x.ToUpper() == placa.ToUpper())) // Verifica se o carro já esta cadastrado
                    {
                        veiculos.Add(placa);
                        break;
                    }
                    else {
                        Console.WriteLine("Veículo já cadastrado!");
                        break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Você deve ter digitado a placa incorretamente! Por favor, digite novamente!\n");
                }
            }
        }

        public void RemoverVeiculo()
        {

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            string placa = "";

            while (true)
            {
                Console.WriteLine("Digite a placa do veículo para remover:");
                placa = Console.ReadLine().ToUpper();
                if (VerificarPlaca(placa))
                {
                    break;
                }
                else{
                    Console.Clear();
                    Console.WriteLine("Você deve ter digitado a placa incorretamente! Por favor, digite novamente!\n");
                }
            }

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                

                int horas = 0;
                decimal valorTotal = 0;

                horas = Convert.ToInt32(Console.ReadLine());

                valorTotal = precoInicial + precoPorHora * horas;

                // TODO: Remover a placa digitada da lista de veículos
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
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine($"Quantidade Total de veículos estacionados: {veiculos.Count}\n\nOs veículos estacionados são:");
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                foreach(string veiculo in veiculos)
                {
                    Console.WriteLine($" - Veículo Placa: {veiculo}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
