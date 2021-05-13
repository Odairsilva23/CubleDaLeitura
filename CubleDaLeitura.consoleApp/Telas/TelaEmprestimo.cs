using System;
using CubleDaLeitura.consoleApp.Controladores;
using CubleDaLeitura.consoleApp.Dominio;

namespace CubleDaLeitura.consoleApp.Telas
{
    public class TelaEmprestimo : TelaBase, ICadastravel

    {
        private readonly ControladorEmprestimo controladorEmprestimo;
        private readonly ControladorAmigo controladorAmigo;
        private readonly ControladorRevista controladorRevista;

        public TelaEmprestimo(ControladorEmprestimo ctrlEmprestimo, ControladorAmigo controladorAmigo, ControladorRevista controladorRevista) : base("Cadastro de Empréstimos")
        {
            this.controladorEmprestimo = ctrlEmprestimo;
            this.controladorAmigo = controladorAmigo;
            this.controladorRevista = controladorRevista;
        }


        private bool GravarEmprestimo(int id)
        {
            string resultadoValidacao;
            bool conseguiuGravar = true;

            Console.Write("Digite a data de emprestimo da Revista: ");
            DateTime dataEmprestimo = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Digite a data de devolução da Revista caso Devolução feita: ");
            DateTime dataDevolucao = Convert.ToDateTime(Console.ReadLine());

            VisualizarAmigosCadastrados();

            Console.Write("Digite o Id do Amigo: ");
            int idAmiguinho = Convert.ToInt32(Console.ReadLine());

            VisualizarRevistasCadastradas();

            Console.Write("Digite o Id da Revista: ");
            int idRevista = Convert.ToInt32(Console.ReadLine());

            resultadoValidacao = controladorEmprestimo.RegistrarEmprestimo(
                id, dataEmprestimo, dataDevolucao, idAmiguinho , idRevista);

            if (resultadoValidacao != "EMPRESTIMO_VALIDO")
            {
                ApresentarMensagem(resultadoValidacao, TipoMensagem.Erro);
                conseguiuGravar = false;
            }

            return conseguiuGravar;
        }

        public void VisualizarRegistros()
        {
            ConfigurarTela("Visualizando Caixas Cadastradas...");

            string configuracaColunasTabela = "{0,-10} | {1,-35} | {2,-35}";

            MontarCabecalhoTabela(configuracaColunasTabela);

            Emprestimo[] emprestimos = controladorEmprestimo.SelecionarTodosEmprestimos();

            if (emprestimos.Length == 0)
            {
                ApresentarMensagem("Nenhum emprestimo cadastrada!", TipoMensagem.Atencao);
                return;
            }

            for (int i = 0; i < emprestimos.Length; i++)
            {
                Console.WriteLine(configuracaColunasTabela,
                   emprestimos[i].id, emprestimos[i].nomeAmigo, emprestimos[i].revista);
            }
            foreach (Emprestimo emprestimo in emprestimos)
            {
                if (emprestimo.dataDevolucao != DateTime.MinValue)
                {
                    if (emprestimo.dataDevolucao.Month == DateTime.Now.Month)
                    {
                        Console.WriteLine("{0,-10} | {1,-10} | {2,-10} | {3,-10} | {4,-10}",
                            emprestimo.id, emprestimo.revista.id, emprestimo.nomeAmigo.nomeAmigo, emprestimo.dataEmprestimo, emprestimo.dataDevolucao);
                    }
                }
            }
        }
        string ICadastravel.ObterOpcao()
        {
            Console.WriteLine("Digite 1 para inserir um novo emprestimo");
            Console.WriteLine("Digite 2 para Registrar Devolução");
            Console.WriteLine("Digite 3 para visualizar os Emprestimos do dia");
            Console.WriteLine("Digite 4 para para vizualicar os emprestimos de um dertimado mes");

            Console.WriteLine("Digite S para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }
        private void VisualizarAmigosCadastrados()
        {
            Console.WriteLine();
            Amigo[] amiguinhos = controladorAmigo.SelecionarTodosAmigos();

            Console.WriteLine("{0,-10} | {1,-30}", "Id", "Equipamento");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            foreach (var e in amiguinhos)
            {
                Console.WriteLine("{0,-10} | {1,-30}", e.id, e.nomeAmigo);
            }
            Console.WriteLine();

            
        }
        private void VisualizarRevistasCadastradas()
        {
            Console.WriteLine();
            Revista[] revistas = controladorRevista.SelecionarTodasRevistas();

            Console.WriteLine("{0,-10} | {1,-30}", "Id", "nome");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            foreach (var e in revistas)
            {
                Console.WriteLine("{0,-10} | {1,-30}", e.id, e.nomeDaRevista);
            }
            Console.WriteLine();
        }

        public void InserirNovoRegistro(int id)
        {
            ConfigurarTela("Inserindo um Novo Emprestimo...");

            bool conseguiuGravar = GravarEmprestimo(0);

            if (conseguiuGravar)
                ApresentarMensagem("Emprestimo inserido com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar inserir  Emprestimo", TipoMensagem.Erro);
                InserirNovoRegistro(id);
            }
        }
        private static void MontarCabecalhoTabela(string configuracaoColunasTabela)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(configuracaoColunasTabela, "Id", "Nome Amigo", "Revista Emprestada");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
        }

    }
}
