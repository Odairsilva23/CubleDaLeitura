using CubleDaLeitura.consoleApp.Controladores;
using System;


namespace CubleDaLeitura.consoleApp.Telas
{
    public class TelaBase
    {
        private string titulo;

        public string Titulo { get { return titulo; } }

        public ControladorEmprestimo CtrlEmprestimo { get; }
        public ControladorAmigo CtrlAmigo { get; }
        public ControladorRevista CtrlRevista { get; }

        public TelaBase(string tit)
        {
            titulo = tit;
        }

        public TelaBase(ControladorEmprestimo ctrlEmprestimo, ControladorAmigo ctrlAmigo, ControladorRevista ctrlRevista)
        {
            CtrlEmprestimo = ctrlEmprestimo;
            CtrlAmigo = ctrlAmigo;
            CtrlRevista = ctrlRevista;
        }

        public string ObterOpcao()
        {
            Console.WriteLine("Digite 1 para inserir um novo registro");
            Console.WriteLine("Digite 2 para Editar Registros");
            Console.WriteLine("Digite 3 para visualizar Registros");
            Console.WriteLine("Digite 4 para Excluir Registros");


            Console.WriteLine("Digite S para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }
        protected void ApresentarMensagem(string mensagem, TipoMensagem tm)
        {
            switch (tm)
            {
                case TipoMensagem.Sucesso:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;

                case TipoMensagem.Atencao:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;

                case TipoMensagem.Erro:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;

                default:
                    break;
            }

            Console.WriteLine();
            Console.WriteLine(mensagem);
            Console.ResetColor();
            Console.ReadLine();
        }
        protected void ConfigurarTela(string subtitulo)
        {
            Console.Clear();

            Console.WriteLine(titulo);

            Console.WriteLine();

            Console.WriteLine(subtitulo);

            Console.WriteLine();
        }
    }
}
