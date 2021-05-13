

namespace CubleDaLeitura.consoleApp
{
    public class GeradorIds
    {
        public static int idAmigo = 0;
        public static int idCaixa = 0;
        public static int idCadastroInternoRevista = 0;
        public static int idEmprestimo = 0;

        public static int GerarIdAmigo()
        {
            return ++idAmigo;
        }

        public static int GerarIdCaixa()
        {
            return ++idCaixa;
        }

        public static int GeraIdRevista()
        {
            return ++idCadastroInternoRevista;
        }
        public static int GerarIdEmprestimo()
        {
            return ++idEmprestimo;
        }
    }
}
