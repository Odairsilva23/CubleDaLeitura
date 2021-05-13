using System;
using CubleDaLeitura.consoleApp.Controladores;
using CubleDaLeitura.consoleApp.Dominio;


namespace CubleDaLeitura.consoleApp.Telas
{
    public class TelaAmigo : TelaBase, IEditavel

    {
       
        private readonly ControladorAmigo controladorAmigo;

        public TelaAmigo(ControladorAmigo controladorAmigo) : base("Cadastro de Amiguinhos")
        {
            this.controladorAmigo = controladorAmigo;
        }

        public void EditarRegistro()
        {
            ConfigurarTela("Editando informações de um Amigo...");

            VisualizarRegistros();

            Console.WriteLine();

            Console.Write("Digite o número do Amigo que deseja editar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            bool conseguiuGravar = GravarAmigo(id);

            if (conseguiuGravar)
                ApresentarMensagem("Informaçoes do Amigo editado com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar editar ", TipoMensagem.Erro);
                EditarRegistro();
            }
        }

        public void ExcluirRegistros()
        {
            ConfigurarTela("Excluindo um Amigo da LISTA...");

            VisualizarRegistros();

            Console.WriteLine();

            Console.Write("Digite o número da caixa que deseja excluir: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool conseguiuExcluir = controladorAmigo.ExcluirAmigo(idSelecionado);

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
            ConfigurarTela("Inserindo Um novo Amigo...");

            bool conseguiuGravar = GravarAmigo(0);

            if (conseguiuGravar)
                ApresentarMensagem("Amigo inserido com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar inserir Amigo", TipoMensagem.Erro);
                InserirNovoRegistro(id);
            }
        }

        private bool GravarAmigo(int id)
        {
            string resultadoValidacao;
            bool conseguiuGravar = true;

            Console.Write("Digite o nome do novo Amigo a ser Cadastrado: ");
            string nomeAmigo = Console.ReadLine();

            Console.Write("Digite o Endereço do Amigo : ");
            string endereco = Console.ReadLine();

            Console.Write("Digite o nome do Responsavel pelo Amigo : ");
            string nomeResponsavel = Console.ReadLine();

            Console.Write("Digite o numero do Telefone do Amigo : ");
            string telefone = Console.ReadLine();


            resultadoValidacao = controladorAmigo.RegistrarAmigo(
                id, nomeAmigo, endereco, nomeResponsavel, telefone);

            if (resultadoValidacao != "AMIGO_VALIDA")
            {
                ApresentarMensagem(resultadoValidacao, TipoMensagem.Erro);
                conseguiuGravar = false;
            }

            return conseguiuGravar;
        }

        public void VisualizarRegistros()
        {
            ConfigurarTela("Visualizando Amigos Cadastrados...");

            string configuracaColunasTabela = "{0,-10} | {1,-15} | {2,-20} | {3,-15} | {4,-10} ";

            MontarCabecalhoTabela(configuracaColunasTabela);

            Amigo[] amiguinhos = controladorAmigo.SelecionarTodosAmigos();

            if (amiguinhos.Length == 0)
            {
                ApresentarMensagem("Nenhum Amigo cadastrado!", TipoMensagem.Atencao);
                return;
            }

            for (int i = 0; i < amiguinhos.Length; i++)
            {
                Console.WriteLine(configuracaColunasTabela,
                   amiguinhos[i].id, amiguinhos[i].nomeAmigo, amiguinhos[i].endereco, amiguinhos[i].nomeResponsavel, amiguinhos[i].telefone);
            }
            
        }

        private static void MontarCabecalhoTabela(string configuracaoColunasTabela)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(configuracaoColunasTabela, "Id", "Nome", "Endereço", "Nome Responsavel", "Telefone");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
        }

        string IEditavel.ObterOpcao()
        {
            Console.WriteLine("Digite 1 para inserir novo Amigo");
            Console.WriteLine("Digite 2 para visualizar Amigo");
            Console.WriteLine("Digite 3 para editar um Amigo");
            Console.WriteLine("Digite 4 para excluir um Amigo");

            Console.WriteLine("Digite S para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }
    }
}
