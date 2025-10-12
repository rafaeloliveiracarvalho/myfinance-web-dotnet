using domain.Entities;
using infra;
using service.Interfaces;

namespace service
{
    public class CategoriaService(InfraDbContext dbContext) : ICategoriaService
    {
        private readonly InfraDbContext _dbContext = dbContext;

        public void CadastrarAlterar(Categoria Entidade)
        {
            var dbSet = _dbContext.Categoria;
            if (Entidade.Id == null)
            {
                dbSet.Add(Entidade);
            }
            else
            {
                dbSet.Update(Entidade);
            }


            _dbContext.SaveChanges();
        }

        public void Excluir(int Id)
        {
            var dbSet = _dbContext.Categoria;
            var registro = dbSet.First(x => x.Id == Id);
            dbSet.Remove(registro);
            _dbContext.SaveChanges();
        }

        public List<Categoria> Listar()
        {
            return _dbContext.Categoria.ToList();
        }

        public Categoria RegistroPorId(int Id)
        {
            return _dbContext.Categoria.Where(x => x.Id == Id).First();
        }
    }
}
