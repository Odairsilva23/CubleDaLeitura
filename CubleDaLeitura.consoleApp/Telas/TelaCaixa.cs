using CubleDaLeitura.consoleApp.Controladores;
using CubleDaLeitura.consoleApp.Dominio;
using System;


namespace CubleDaLeitura.consoleApp.Telas
{
    public class TelaCaixa : TelaBase, IEditavel
    {
       
        private readonly ControladorCaixa controladorCaixa;

        public TelaCaixa(ControladorCaixa controladorCaixa) : base("Cadastro de Caixas")
        {
            this.controladorCaixa = controladorCaixa;
        }

        public void EditarRegistro()
        {
            ConfigurarTela("Editando uma Caixa...");

            VisualizarRegistros();

            Console.WriteLine();

            Console.Write("Digite o número da caixa que deseja editar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            bool conseguiuGravar = GravarCaixa(id);

            if (conseguiuGravar)
                ApresentarMensagem("Caixa editada com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar editar a Caixa", TipoMensagem.Erro);
                EditarRegistro();
            }
        }

        public void ExcluirRegistros()
        {
            ConfigurarTela("Excluindo uma Caixa...");

            VisualizarRegistros();

            Console.WriteLine();

            Console.Write("Digite o número da caixa que deseja excluir: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool conseguiuExcluir = controladorCaixa.ExcluirCaixa(idSelecionado);

            if (conseguiuExcluir)
                ApresentarMensagem("Caixa excluída com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar excluir a caixa", TipoMensagem.Erro);
                ExcluirRegistros();
            }
        }

        public void InserirNovoRegistro(int id)
        {
            ConfigurarTela("Inserindo Uma nova Caixa ao Sistema...");

            bool conseguiuGravar = GravarCaixa(0);

            if (conseguiuGravar)
                ApresentarMensagem("Caixa inserida com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar inserir a caixa", TipoMensagem.Erro);
                InserirNovoRegistro(id);
            }
        }

        private bool GravarCaixa(int id)
        {
            string resultadoValidacao;
            bool conseguiuGravar = true;

            Console.Write("Digite a cor da caixa para cadastro: ");
            string cor = Console.ReadLine();

            Console.Write("Digite o numero da etiqueta : ");
            string etiqueta = Console.ReadLine();


            resultadoValidacao = controladorCaixa.RegistrarCaixa(
                id, cor , etiqueta);

            if (resultadoValidacao != "CAIXA_VALIDA")
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

            Caixa[] caixas = controladorCaixa.SelecionarTodasCaixas();

            if (caixas.Length == 0)
            {
                ApresentarMensagem("Nenhuma Caixa cadastrada!", TipoMensagem.Atencao);
                return;
            }

            for (int i = 0; i < caixas.Length; i++)
            {
                Console.WriteLine(configuracaColunasTabela,
                   caixas[i].id, caixas[i].cor, caixas[i].etiqueta);
            }
        }
        private static void MontarCabecalhoTabela(string configuracaoColunasTabela)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(configuracaoColunasTabela, "Id", "Cor", "Numero da Etiqueta");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
        }
        string IEditavel.ObterOpcao()
        {
            Console.WriteLine("Digite 1 para inserir nova Caixa");
            Console.WriteLine("Digite 2 para visualizar todas Caixa");
            Console.WriteLine("Digite 3 para editar uma Caixa");
            Console.WriteLine("Digite 4 para excluir uma Caixa");

            Console.WriteLine("Digite S para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        
    }
}
