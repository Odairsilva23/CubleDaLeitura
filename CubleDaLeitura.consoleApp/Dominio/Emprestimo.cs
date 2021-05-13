using System;


namespace CubleDaLeitura.consoleApp.Dominio
{
    public class Emprestimo : GeradorIds
    {
        public int id;
        public DateTime dataEmprestimo;
        public DateTime dataDevolucao;
        public Amigo nomeAmigo;
        public Revista revista;
        public bool Devolvido;

        public Emprestimo()
        {
            id = GerarIdEmprestimo();
        }

        public Emprestimo(int idSelecionado)
        {
            id = idSelecionado;
        }

        public string Validar()
        {
            string resultadoValidacao = "";


            if (dataEmprestimo > DateTime.Now)
                resultadoValidacao += "O campo Data de Emprestimo não pode ser no futuro \n";

            if (string.IsNullOrEmpty(resultadoValidacao))
                resultadoValidacao = "EMPRESTIMO_VALIDO";

            return resultadoValidacao;
        }
        public override bool Equals(object obj)
        {
            Emprestimo emprestimo = (Emprestimo)obj;

            if (id == emprestimo.id)
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
