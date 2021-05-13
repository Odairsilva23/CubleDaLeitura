using System;


namespace CubleDaLeitura.consoleApp.Dominio
{
    public class Revista : GeradorIds
    {
        public int id;
        public string tipoDaColecao;
        public string nomeDaRevista;
        public string numeroDaEdicao;
        public DateTime dataLancametno;
        public Caixa caixa;

        public Revista()
        {
            id = GeraIdRevista();
        }

        public Revista(int idSelecionado)
        {
            id = idSelecionado;
        }
        public string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(tipoDaColecao))
                resultadoValidacao += "O campo tipo da coleção  é obrigatório \n";

            if (string.IsNullOrEmpty(nomeDaRevista))
                resultadoValidacao += "O campo Nome é obrigatório \n";

            if (string.IsNullOrEmpty(numeroDaEdicao))
                resultadoValidacao += "O campo nume da edição é obrigatório \n";

            if (dataLancametno > DateTime.Now)
                resultadoValidacao += "O campo Data de Lançamento não pode ser nmo futuro \n";

            if (string.IsNullOrEmpty(resultadoValidacao))
                resultadoValidacao = "REVISTA_VALIDA";

            return resultadoValidacao;
        }

        public override bool Equals(object obj)
        {
            Revista revista = (Revista)obj;

            if (id == revista.id)
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
