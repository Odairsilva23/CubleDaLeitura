using System;
using CubleDaLeitura.consoleApp.Controladores;
using CubleDaLeitura.consoleApp.Dominio;

namespace CubleDaLeitura.consoleApp.Telas
{
    public class ControladorRevista : ControladorBase
    {
        private ControladorCaixa controladorCaixa;
        public ControladorRevista(ControladorCaixa controladorCaixa)
        {
            this.controladorCaixa = controladorCaixa;
        }
        internal string RegistrarRevista(int idCaixa, int id, string tipoDaColecao, string nome, string numeroDaEdicao, DateTime dataLancamento)
        {
            Revista revista = null;

            int posicao;

            if (id == 0)
            {
                revista = new Revista();
                posicao = ObterPosicaoVaga();
            }
            else
            {
                posicao = ObterPosicaoOcupada(new Revista(id));
                revista = (Revista)registros[posicao];
            }

            revista.caixa = controladorCaixa.SelecionarCaixaPorId(idCaixa);
            revista.tipoDaColecao = tipoDaColecao;
            revista.nomeDaRevista = nome;
            revista.numeroDaEdicao = numeroDaEdicao;
            revista.dataLancametno = dataLancamento;
           

            string resultadoValidacao = revista.Validar();

            if (resultadoValidacao == "EQUIPAMENTO_VALIDO")
                registros[posicao] = revista;

            return resultadoValidacao;

        }
        public Revista SelecionarRevistaPorId(int id)
        {
            return (Revista)SelecionarRegistroPorId(new Revista(id));
        }
        public bool ExcluirRevista(int idSelecionado)
        {
            return ExcluirRegistro(new Revista(idSelecionado));
        }
        public Revista[] SelecionarTodasRevistas()
        {
            Revista[] revistasAux = new Revista[QtdRegistrosCadastrados()];

            Array.Copy(SelecionarTodosRegistros(), revistasAux, revistasAux.Length);

            return revistasAux;
        }

    }
}