using domain.Entities;

namespace service.Interfaces
{
    public interface ITransacaoService
    {
        void CadastrarAlterar(Transacao Entidade);
        void Excluir(int Id);
        List<Transacao> Listar();
        Transacao RegistroPorId(int Id);
    }
}