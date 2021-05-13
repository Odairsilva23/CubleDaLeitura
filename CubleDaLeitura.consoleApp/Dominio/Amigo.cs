
namespace CubleDaLeitura.consoleApp.Dominio
{
    public class Amigo : GeradorIds
    {
        public int id;
        public string nomeAmigo;
        public string endereco;
        public string nomeResponsavel;
        public string telefone;
        public Emprestimo[] emprestimos;

        public Amigo()
        {
            id = GerarIdAmigo();
        }

        public Amigo(int idSelecionado)
        {
            id = idSelecionado;
        }
        public string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(nomeAmigo))
                resultadoValidacao += "O campo Nome  é obrigatório \n";

            if (string.IsNullOrEmpty(endereco))
                resultadoValidacao += "O campo Endereço é obrigatório \n";

            if (string.IsNullOrEmpty(nomeResponsavel))
                resultadoValidacao += "O campo Responsavel é obrigatório \n";

            if (string.IsNullOrEmpty(telefone))
                resultadoValidacao += "O campo Telefone é obrigatório \n";

            if (string.IsNullOrEmpty(resultadoValidacao))
                resultadoValidacao = "AMIGO_VALIDO";

            return resultadoValidacao;
        }

        public override bool Equals(object obj)
        {
            Amigo amiguinho = (Amigo)obj;

            if (id == amiguinho.id)
                return true;
            else
                return false;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
