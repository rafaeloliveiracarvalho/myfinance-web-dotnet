using domain.Entities;
using infra;
using Microsoft.EntityFrameworkCore;
using service.Interfaces;

namespace service
{
    public class TransacaoService : ITransacaoService
    {
        private readonly InfraDbContext _dbContext;

        public TransacaoService(InfraDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CadastrarAlterar(Transacao Entidade)
        {
            var dbSet = _dbContext.Transacao;
            if (Entidade.Id == null)
            {
                dbSet.Add(Entidade);
            }
            else
            {
                dbSet.Attach(Entidade);
                _dbContext.Entry(Entidade).State = EntityState.Modified;
            }
            // else
            // {
            //     dbSet.Update(Entidade);
            // }

            _dbContext.SaveChanges();
        }

        public void Excluir(int Id)
        {
            var dbSet = _dbContext.Transacao;
            var registro = dbSet.First(x => x.Id == Id);
            dbSet.Remove(registro);
            _dbContext.SaveChanges();
        }

        public List<Transacao> Listar()
        {
            return _dbContext.Transacao.Include(x => x.Categoria).ToList();
        }

        public Transacao RegistroPorId(int Id)
        {
            return _dbContext.Transacao.Where(x => x.Id == Id).First();
        }
    }
}
