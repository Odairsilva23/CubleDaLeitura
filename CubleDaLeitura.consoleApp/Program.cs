using CubleDaLeitura.consoleApp.Controladores;
using CubleDaLeitura.consoleApp.Telas;
using System;



namespace CubleDaLeitura.consoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            ControladorCaixa controladorCaixa = new ControladorCaixa();
            ControladorRevista ctrlRevista = new ControladorRevista(controladorCaixa);
            ControladorAmigo controladorAmigo = new ControladorAmigo();
            ControladorEmprestimo controladorEmprestimo = new ControladorEmprestimo(controladorCaixa, controladorAmigo, ctrlRevista);

            TelaCaixa telaCaixa = new TelaCaixa(controladorCaixa);
            TelaRevista telaRevista = new TelaRevista(ctrlRevista, telaCaixa, controladorCaixa);
            TelaAmigo telaAmigo = new TelaAmigo(controladorAmigo);
            TelaEmprestimo telaEmprestimo = new TelaEmprestimo(controladorEmprestimo, controladorAmigo, ctrlRevista);

            TelaPrincipal telaPrincipal = new TelaPrincipal( controladorCaixa, ctrlRevista, telaCaixa,  telaEmprestimo, telaRevista, controladorAmigo, telaAmigo);

            IEditavel telaSelecionada;

            Console.Clear();

            string opcaoCadastro;

            do
            {
                telaSelecionada = telaPrincipal.ObterTela();

                Console.Clear();

                opcaoCadastro = telaSelecionada.ObterOpcao();

                if (opcaoCadastro == "1")
                    telaSelecionada.InserirNovoRegistro(0);

                else if (opcaoCadastro == "2")
                    telaSelecionada.VisualizarRegistros();

                else if (opcaoCadastro == "3")
                {
                    IEditavel telaSelecionadaCast = telaSelecionada as IEditavel;
                    telaSelecionadaCast.EditarRegistro();
                }

                else if (opcaoCadastro == "4")
                {
                    IEditavel telaSelecionadaCast = telaSelecionada as IEditavel;
                    telaSelecionadaCast.ExcluirRegistros();
                }

                Console.Clear();
            } while (telaSelecionada != null);
        }
    }
}
