using System;
using System.ComponentModel.Design;
using static System.Net.Mime.MediaTypeNames;

namespace CalculadoraTabajara
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] historicoOperaçoes = new string[100];
            string opcao, operacao, operador;
            int contadorOperacoes = 0;
            do
            {

                ApresentarMenu();

                opcao = Console.ReadLine();

                if (OpcaoHistorico(opcao))
                {
                    VisualizarHistorico(historicoOperaçoes, contadorOperacoes);
                    continue;
                }

                else if (OpcaoSair(opcao))
                {
                    break;
                }

                else if (OpcaoInvalida(opcao))
                {
                    ApresentarMensagem("Opção não encontrada, ", ConsoleColor.Red);
                    continue;
                }

                operacao = ObterOperacao(opcao);
                operador = ObterOperador(operacao);

                historicoOperaçoes[contadorOperacoes] = Calcular(operacao, operador, opcao);


                contadorOperacoes++;

            } while (true);
            //while (opcao == "1"|| opcao == "2" || opcao == "3" || opcao == "4" || opcao == "S" || opcao == "s");

        }
        #region Métodos
        static string Calcular(string operacao, string operador, string  opcao )
        {

            Console.Clear();
            Console.WriteLine("Você escolheu " + operacao);

            decimal primeiroNumero = ObterPrimeiroNumero(operador);
            decimal segundoNumero = 0;
            for (int i = 0; i < 1; i++)
            {
                segundoNumero = ObterSegundoNumero();
                if (operacao == "Divisão" && segundoNumero == 0)
                {
                    ApresentarMensagem("O dividendo não pode ser [0], ", ConsoleColor.Red);
                    i--;
                    continue;
                }

            }

            decimal resultado = ExecutarCalculo(opcao, primeiroNumero, segundoNumero);

            string descricaoCalculo = primeiroNumero + " " + operador + " " + segundoNumero + " = " + resultado;

            ApresentarResultado(primeiroNumero, operador, segundoNumero, resultado);

            return descricaoCalculo;
        }

        static void VisualizarHistorico(string[] historicoOperaçoes, int contadorOperacoes)
        {
            for (int i = 0; i < contadorOperacoes; i++)
            {
                if (historicoOperaçoes[i] != null)
                {
                    ApresentarHistorico(historicoOperaçoes, i);
                }
               

                if (historicoOperaçoes[i] == null)
                {
                    ApresentarMensagem("Nenhuma operação foi realizada, ", ConsoleColor.DarkYellow);
                }

            }
            ApresentarMensagem("", ConsoleColor.DarkGreen);
            
        }

        static void ApresentarHistorico(string[] historicoOperaçoes, int i)
        {
            if (historicoOperaçoes[i].Contains("+"))
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            else if (historicoOperaçoes[i].Contains("-"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (historicoOperaçoes[i].Contains("/"))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else if (historicoOperaçoes[i].Contains("x"))
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            }
            Console.WriteLine(historicoOperaçoes[i]);
            Console.ResetColor();
        }

        static bool OpcaoInvalida(string opcao)
        {
            return opcao != "1" && opcao != "2" && opcao != "3" && opcao != "4" && opcao != "5" && opcao != "s" && opcao != "S";
        }

        static bool OpcaoHistorico(string opcao)
        {
            return opcao == "5";
        }

        static bool OpcaoSair(string opcao)
        {
            return opcao == "S" || opcao == "s";
        }

        static string ObterOperador(string operacao)
        {
            string operador = "";
            if (operacao == "Soma")
                operador = "+";
            else if (operacao == "Subtração")
                operador = "-";
            else if (operacao == "Divisão")
                operador = "/";
            else if (operacao == "Multiplicação")
                operador = "x";

            return operador;
        }

        static void ApresentarResultado(decimal primeiroNumero,string operador, decimal segundoNumero, decimal resultado)
        {
            
            Console.Write(primeiroNumero + " " + operador + " " + segundoNumero + " = " + resultado + "\nAperte [ENTER] para continuar");
            Console.ReadLine();
        }

        static decimal ObterSegundoNumero()
        {
            decimal segundoNumero;
            Console.Write("Digite o segundo Número: ");
            segundoNumero = Convert.ToInt16(Console.ReadLine());
            return segundoNumero;
        }

        static decimal ObterPrimeiroNumero(string operacao)
        {
            decimal primeiroNumero;
            Console.Write("Digite o primeiro Numero: ");
            primeiroNumero = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine(primeiroNumero +" "+ operacao +" __");
            return primeiroNumero;
        }

        static void ApresentarMenu()
        {
            Console.Clear();
            Console.Write("Calculadora Tabajara 1.5 \n\nDigite [1] para SOMAR\nDigite [2] para SUBTRAIR\nDigite [3] para DIVIDIR\nDigite [4] para MULTIPLICAR\nDigite [5] para ver HISTORICO\nDigite [S] para SAIR\nOpção: ");
        }
        static void ApresentarMensagem(string mensagem, ConsoleColor cor)
        {
            Console.ForegroundColor= cor;
            Console.WriteLine(mensagem + "tente novamente apertando[ENTER].");
            Console.ReadLine();
            Console.ResetColor();
            Console.Clear();
        }
        static string ObterOperacao(string opcao)
        {
            string operacao = "";
            if (opcao == "1")
                operacao = "Soma";
            else if (opcao == "2")
                operacao = "Subtração";
            else if (opcao == "3")
                operacao = "Divisão";
            else if (opcao == "4")
                operacao = "Multiplicação";

            return operacao;
        }
        static decimal ExecutarCalculo(string opcao, decimal primeiroNumero, decimal segundoNumero)
        {
            decimal resultado = 0;
            if (opcao == "1")
                resultado = primeiroNumero + segundoNumero;
            else if (opcao == "2")
                resultado = primeiroNumero - segundoNumero;
            else if (opcao == "3")
                resultado= primeiroNumero / segundoNumero;
            else if (opcao == "4")
                resultado = primeiroNumero * segundoNumero;
            return resultado;
        }
        #endregion
    }
}
