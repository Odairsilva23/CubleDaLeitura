using System;
using CubleDaLeitura.consoleApp.Dominio;


namespace CubleDaLeitura.consoleApp.Controladores
{
    public class ControladorAmigo : ControladorBase
    {
        public string RegistrarAmigo(int id, string nomeAmigo, string endereco, string nomeResponsavel, string telefone)
        {
            Amigo amigo = null;

            int posicao;

            if (id == 0)
            {
                amigo = new Amigo();
                posicao = ObterPosicaoVaga();
            }
            else
            {
                posicao = ObterPosicaoOcupada(new Amigo(id));
                amigo = (Amigo)registros[posicao];
            }

            amigo.nomeAmigo = nomeAmigo;
            amigo.endereco = endereco;
            amigo.nomeResponsavel = nomeResponsavel;
            amigo.telefone = telefone;


            string resultadoValidacao = amigo.Validar();

            if (resultadoValidacao == "AMIGO_VALIDO")
                registros[posicao] = amigo;

            return resultadoValidacao;
        }
        public Amigo SelecionarAmigoPorId(int id)
        {
            return (Amigo)SelecionarRegistroPorId(new Amigo(id));
        }
        public bool ExcluirAmigo(int idSelecionado)
        {
            return ExcluirRegistro(new Amigo(idSelecionado));
        }
        public Amigo[] SelecionarTodosAmigos()
        {
            Amigo[] amigosAux = new Amigo[QtdRegistrosCadastrados()];

            Array.Copy(SelecionarTodosRegistros(), amigosAux, amigosAux.Length);

            return amigosAux;
        }

      
    }
}
