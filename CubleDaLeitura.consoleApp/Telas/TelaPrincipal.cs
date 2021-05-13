using System;
using CubleDaLeitura.consoleApp.Controladores;
using CubleDaLeitura.consoleApp.Dominio;


namespace CubleDaLeitura.consoleApp.Telas
{
    public class TelaPrincipal : TelaBase
    {
        protected ControladorCaixa controladorCaixa;
        protected ControladorRevista controladorRevista;
        protected ControladorAmigo controladorAmigo;
        protected ControladorEmprestimo controladorEmprestimo;
        protected TelaCaixa telaCaixa;
        protected TelaRevista telaRevista;
        protected TelaAmigo telaAmigo;
        protected TelaEmprestimo telaEmprestimo;


        public TelaPrincipal(ControladorCaixa ctrlCaixa, ControladorRevista ctrlRevista, ControladorEmprestimo crtlEmperestimo, TelaEmprestimo tEmprestimo,
            TelaCaixa tCaixa, TelaRevista tRevista, ControladorAmigo ctrlAmigo, TelaAmigo tAmigo) : base("Clube da Leitura")
        {
            controladorCaixa = ctrlCaixa;
            controladorRevista = ctrlRevista;
            controladorAmigo = ctrlAmigo;
            controladorEmprestimo = crtlEmperestimo;
            telaCaixa = tCaixa;
            telaRevista = tRevista;
            telaAmigo = tAmigo;
            telaEmprestimo = tEmprestimo;

        }

        public IEditavel ObterTela()
        {
            ConfigurarTela("Escolha uma opção: ");

            IEditavel telaSelecionada = null;
         

            Console.WriteLine("Digite 1 para cadastrar caixas");
            Console.WriteLine("Digite 2 para cadastrar revistas");
            Console.WriteLine("Digite 3 para cadastrar amigos");
            Console.WriteLine("Digite 4 Para Cadastar um emprestimo");

            Console.WriteLine("Digite S para Sair");

            string opcao = Console.ReadLine();

            if (opcao.Equals("s", StringComparison.OrdinalIgnoreCase))
                Environment.Exit(0);

            if (opcao == "1")
                telaSelecionada = telaCaixa;

            else if (opcao == "2")
                telaSelecionada = telaRevista;

            else if (opcao == "3")
                telaSelecionada = (IEditavel)telaAmigo;

            else if (opcao == "4")
                telaSelecionada = (IEditavel)telaEmprestimo;

            return telaSelecionada;
        }
    }
    
}
