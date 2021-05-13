using System;
using CubleDaLeitura.consoleApp.Controladores;
using CubleDaLeitura.consoleApp.Dominio;

namespace CubleDaLeitura.consoleApp.Telas
{
    public class TelaRevista : TelaBase, IEditavel
    {
        private ControladorRevista controladorRevista;

        private TelaCaixa telaCaixa;

        private readonly ControladorCaixa controladorCaixa;

        public TelaRevista(ControladorRevista ctrlRevista, TelaCaixa telaCaixa, ControladorCaixa controladorCaixa) : base("Cadastro de Revistas")
        {
            this.controladorRevista = ctrlRevista;
            this.telaCaixa = telaCaixa;
            this.controladorCaixa = controladorCaixa;
        }

        public void EditarRegistro()
        {
            ConfigurarTela("Editando uma Revista...");

            VisualizarRegistros();

            Console.WriteLine();

            Console.Write("Digite o número do equipamento que deseja editar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            bool conseguiuGravar = GravarRevista(id);

            if (conseguiuGravar)
                ApresentarMensagem("Equipamento editado com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar editar o equipamento", TipoMensagem.Erro);
                EditarRegistro();
            }
        }

        public void ExcluirRegistros()
        {
            ConfigurarTela("Excluindo uma Revista...");

            VisualizarRegistros();

            Console.WriteLine();

            Console.Write("Digite o número do equipamento que deseja excluir: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool conseguiuExcluir = controladorRevista.ExcluirRevista(idSelecionado);

            if (conseguiuExcluir)
                ApresentarMensagem("Revista excluída com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar excluir a revista", TipoMensagem.Erro);
                ExcluirRegistros();
            }
        }

        public void InserirNovoRegistro(int id)
        {
            ConfigurarTela("Inserindo uma nova revista...");

            bool conseguiuGravar = GravarRevista(0);

            if (conseguiuGravar)
                ApresentarMensagem("revista inserido com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar inserir a revista", TipoMensagem.Erro);
                InserirNovoRegistro(id);
            }
        }

        public void VisualizarRegistros()
        {
            ConfigurarTela("Visualizando revistas cadastradas...");

            string configuracaColunasTabela = "{0,-10} | {1,-55} | {2,-35}";

            MontarCabecalhoTabela(configuracaColunasTabela);

            Revista[] revistas = controladorRevista.SelecionarTodasRevistas();

            if (revistas.Length == 0)
            {
                ApresentarMensagem("Nenhuma Revista cadastrada!", TipoMensagem.Atencao);
                return;
            }

            for (int i = 0; i < revistas.Length; i++)
            {
                Console.WriteLine(configuracaColunasTabela,
                   revistas[i].id, revistas[i].nomeDaRevista, revistas[i].numeroDaEdicao);
            }
        }

        private static void MontarCabecalhoTabela(string configuracaoColunasTabela)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(configuracaoColunasTabela, "Id", "Nome", "Numero Edição");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
        }

        private bool GravarRevista(int id)
        {
            string resultadoValidacao;
            bool conseguiuGravar = true;

            VisualizarCaixas();

            Console.Write("Selecione o ID da Caixa: ");
            int IdCaixa = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite a qual coleção pertence a Revista: ");
            string tipoDaColecao = Console.ReadLine();

            Console.Write("Digite o nome da Revista: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o número da edição da revista: ");
            string numeroDaEdicao = Console.ReadLine();

            Console.Write("Digite a data de lançamento da Revista: ");
            DateTime dataLancamento = Convert.ToDateTime(Console.ReadLine());

            resultadoValidacao = controladorRevista.RegistrarRevista(IdCaixa,
                id, tipoDaColecao, nome, numeroDaEdicao, dataLancamento );

            if (resultadoValidacao != "REVISTA_VALIDA")
            {
                ApresentarMensagem(resultadoValidacao, TipoMensagem.Erro);
                conseguiuGravar = false;
            }

            return conseguiuGravar;
        }
        string IEditavel.ObterOpcao()
        {
            Console.WriteLine("Digite 1 para inserir nova Revista");
            Console.WriteLine("Digite 2 para visualizar todas Revista");
            Console.WriteLine("Digite 3 para editar uma Revista");
            Console.WriteLine("Digite 4 para excluir uma Revista");

            Console.WriteLine("Digite S para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        private void VisualizarCaixas()
        {
            Console.WriteLine();
            Caixa[] caixas = controladorCaixa.SelecionarTodasCaixas();

            Console.WriteLine("{0,-10} | {1,-15} | {1,-15}", "Id", "cor", "etiqueta");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            foreach (var e in caixas)
            {
                Console.WriteLine("{0,-10} | {1,-15} | {2,-15}", e.id, e.cor, e.etiqueta);
            }
            Console.WriteLine();
        }
    }
}
