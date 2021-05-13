

namespace CubleDaLeitura.consoleApp.Telas
{
    public interface IEditavel
    {
        void InserirNovoRegistro(int id);
        void EditarRegistro();
        void ExcluirRegistros();
        void VisualizarRegistros();
        string ObterOpcao();
    }
}
