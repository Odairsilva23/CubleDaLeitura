using System;
using CubleDaLeitura.consoleApp.Dominio;
using CubleDaLeitura.consoleApp.Telas;

namespace CubleDaLeitura.consoleApp.Controladores
{
    public class ControladorEmprestimo : ControladorBase
    {
        private ControladorAmigo controladorAmigo;
        private ControladorRevista controladorRevista;
        private ControladorCaixa controladorCaixa;

        public ControladorEmprestimo(ControladorCaixa ctrlCaixa,
            ControladorAmigo ctrlAmigo,
            ControladorRevista ctrlRevista)
        {
            controladorAmigo = ctrlAmigo;
            controladorRevista = ctrlRevista;
            controladorCaixa = ctrlCaixa;
        }

        internal string RegistrarEmprestimo(int id, DateTime dataEmprestimo, DateTime dataDevolucao, int idAmiguinho, int idRevista)
        {
            Emprestimo emprestimo = null;

            int posicao;

            if (id == 0)
            {
                emprestimo = new Emprestimo();
                posicao = ObterPosicaoVaga();
            }
            else
            {
                posicao = ObterPosicaoOcupada(new Emprestimo(id));
                emprestimo = (Emprestimo)registros[posicao];
            }

            emprestimo.dataEmprestimo = dataEmprestimo;
            emprestimo.dataDevolucao = dataDevolucao;
            emprestimo.nomeAmigo = controladorAmigo.SelecionarAmigoPorId(idAmiguinho);
            emprestimo.revista = controladorRevista.SelecionarRevistaPorId(idRevista);


            string resultadoValidacao = emprestimo.Validar();

            if (resultadoValidacao == "EMPRESTIMO_VALIDO")
                registros[posicao] = emprestimo;

            return resultadoValidacao;
        }
        public Emprestimo SelecionarEmprestimoPorId(int id)
        {
            return (Emprestimo)SelecionarRegistroPorId(new Emprestimo(id));
        }
        public Emprestimo SelecionarEmprestimo(int id)
        {
            Emprestimo emprestimo = new Emprestimo(id);
            return SelecionarEmprestimos(emprestimo);
        }

        private Emprestimo SelecionarEmprestimos(Emprestimo emprestimo)
        {
            return (Emprestimo)SelecionarEmprestimos(new Emprestimo());
        }

        public Emprestimo[] SelecionarEmprestimos()
        {
            return SelecionarEmprestimos();
        }

        internal Emprestimo[] SelecionarTodosEmprestimos()
        {
            throw new NotImplementedException();
        }

        public Emprestimo[] SelecionarEmprestimosNaoDevolvidos()
        {
            Emprestimo[] emprestimos = SelecionarEmprestimos();
            Emprestimo[] naoDevolvidos = new Emprestimo[ContarEmprestimosNaoDevolvidos()];

            int count = 0;

            foreach (Emprestimo emprestimo in emprestimos)
            {
                if (!emprestimo.Devolvido)
                {
                    naoDevolvidos[count] = emprestimo;
                    count++;
                }
            }

            return naoDevolvidos;
        }
        private int ContarEmprestimosNaoDevolvidos()
        {
            int count = 0;
            Emprestimo[] emprestimos = SelecionarEmprestimos();

            foreach (Emprestimo emprestimo in emprestimos)
            {
                if (!emprestimo.Devolvido)
                    count++;
            }

            return count;
        }
        private bool RevistaJaFoiEmprestada(Revista revista)
        {
            Emprestimo[] emprestimos = SelecionarEmprestimos();

            foreach (Emprestimo emprestimo in emprestimos)
            {
                if (!emprestimo.Devolvido && emprestimo.revista.Equals(revista))
                    return true;
            }

            return false;
        }

        private int ContarEmprestimosNaoDevolvidos(int idSelecionado)
        {
            int count = 0;
            Emprestimo[] emprestimos = SelecionarEmprestimos();
           

            foreach (Emprestimo emprestimo in emprestimos)
            {
                if (!emprestimo.Devolvido)
                    count++;
            }

            return count;
        }

        private int ContarEmprestimosAbertoDia()
        {
            int count = 0;
            int diaHoje = DateTime.Now.DayOfYear;
            Emprestimo[] emprestimos = SelecionarEmprestimos();

            foreach (Emprestimo emprestimo in emprestimos)
            {
                if (!emprestimo.Devolvido && emprestimo.dataEmprestimo.DayOfYear == diaHoje)
                    count++;
            }

            return count;
        }

        private int ContarEmprestimosAbertoMes()
        {
            Emprestimo[] emprestimos = SelecionarEmprestimos();

            int mesHoje = DateTime.Now.Month;
            int count = 0;

            foreach (Emprestimo emprestimo in emprestimos)
            {
                if (emprestimo.dataEmprestimo.Month == mesHoje)
                    count++;
            }

            return count;
        }
        public Emprestimo[] SelecionarEmprestimosNaoDevolvidos(int id)
        {
            Emprestimo[] naoDevolvidos = SelecionarEmprestimos();
            Emprestimo[] emprestimos = new Emprestimo[SelecionarEmprestimosNaoDevolvidos().Length];


            int count = 0;

            foreach (Emprestimo emprestimo in naoDevolvidos)
            {
                if (!emprestimo.Devolvido)
                {
                    naoDevolvidos[count] = emprestimo;
                    count++;
                }
            }

            return naoDevolvidos;
        }

        public Emprestimo[] SelecionarEmprestimosAbertoDia()
        {
            Emprestimo[] emprestimos = SelecionarEmprestimos();
            Emprestimo[] emprestimosHoje = new Emprestimo[ContarEmprestimosAbertoDia()];

            int diaHoje = DateTime.Now.DayOfYear;
            int count = 0;

            foreach (Emprestimo emprestimo in emprestimos)
            {
                if (!emprestimo.Devolvido && emprestimo.dataEmprestimo.DayOfYear == diaHoje)
                {
                    emprestimosHoje[count] = emprestimo;
                    count++;
                }
            }

            return emprestimosHoje;
        }

        public Emprestimo[] SelecionarEmprestimosAbertoMes()
        {
            Emprestimo[] emprestimos = SelecionarEmprestimos();
            Emprestimo[] emprestimosMes = new Emprestimo[ContarEmprestimosAbertoMes()];

            int mesHoje = DateTime.Now.Month;
            int count = 0;

            foreach (Emprestimo emprestimo in emprestimos)
            {
                if (emprestimo.dataEmprestimo.Month == mesHoje)
                {
                    emprestimosMes[count] = emprestimo;
                    count++;
                }
            }

            return emprestimosMes;
        }

        public bool VerificaAmigoValidoParaEmprestar(int idSelecionado)
        {
            foreach (Emprestimo e in SelecionarTodosEmprestimos())
            {
                if ((e.nomeAmigo.id == idSelecionado) && (e.dataDevolucao == DateTime.MinValue))
                {
                    return false;
                }
            }
            return true;
        }
        public void DevolverEmprestimo(int emprestimoId)
        {
            Emprestimo emprestimo = SelecionarEmprestimo(emprestimoId);

            if (emprestimo == null)
                 Console.WriteLine( "Emprestimo não encontrado");

            if (emprestimo.Devolvido)
                Console.WriteLine( "Esse emprestimo já foi devolvido");

            emprestimo.dataDevolucao = DateTime.Now;
            emprestimo.Devolvido = true;

            Console.WriteLine( "Emprestimo devolvido com sucesso");
        }
    }
}
