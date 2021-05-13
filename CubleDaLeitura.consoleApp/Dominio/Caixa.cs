

namespace CubleDaLeitura.consoleApp.Dominio
{
    public class Caixa : GeradorIds
    {
        public int id;
        public string cor;
        public string etiqueta;
        public Revista[] revistas;

        public Caixa()
        {
            id = GerarIdCaixa();
        }

        public Caixa(int idSelecionado)
        {
            id = idSelecionado;
        }
        public string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(cor))
                resultadoValidacao += "O campo COR é obrigatório \n";

            if (string.IsNullOrEmpty(etiqueta))
                resultadoValidacao += "O campo etqueta é obrigatório \n";

            if (string.IsNullOrEmpty(resultadoValidacao))
                resultadoValidacao = "CAIXA_VALIDA";

            return resultadoValidacao;
        }
        public override bool Equals(object obj)
        {
            Caixa caixa = (Caixa)obj;

            if (id == caixa.id)
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
