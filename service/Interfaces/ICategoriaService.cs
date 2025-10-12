using domain.Entities;

namespace service.Interfaces
{
    public interface ICategoriaService
    {
        void CadastrarAlterar(Categoria Entidade);
        void Excluir(int Id);
        List<Categoria> Listar();
        Categoria RegistroPorId(int Id);
    }
}