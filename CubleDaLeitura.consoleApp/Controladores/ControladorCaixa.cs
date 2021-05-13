using CubleDaLeitura.consoleApp.Dominio;
using System;


namespace CubleDaLeitura.consoleApp.Controladores
{
    public class ControladorCaixa : ControladorBase
    {
        internal string RegistrarCaixa(int id, string cor, string etiqueta)
        {
            Caixa caixa = null;

            int posicao;

            if (id == 0)
            {
                caixa = new Caixa();
                posicao = ObterPosicaoVaga();
            }
            else
            {
                posicao = ObterPosicaoOcupada(new Caixa(id));
                caixa = (Caixa)registros[posicao];
            }

            caixa.cor = cor;
            caixa.etiqueta = etiqueta;
            

            string resultadoValidacao = caixa.Validar();

            if (resultadoValidacao == "CAIXA_VALIDA")
                registros[posicao] = caixa;

            return resultadoValidacao;
        }

        public Caixa SelecionarCaixaPorId(int id)
        {
            return (Caixa)SelecionarRegistroPorId(new Caixa(id));
        }
        public bool ExcluirCaixa(int idSelecionado)
        {
            return ExcluirRegistro(new Caixa(idSelecionado));
        }
        public Caixa[] SelecionarTodasCaixas()
        {
            Caixa[] CaixasAux = new Caixa[QtdRegistrosCadastrados()];

            Array.Copy(SelecionarTodosRegistros(), CaixasAux, CaixasAux.Length);

            return CaixasAux;
        }
    }
}
