using LivrosApi.Enums;
using LivrosApi.Models;

namespace LivrosApi.Repository
{
    public interface ILivroRepository
    {
        Task<IEnumerable<Livro>> BuscaLivrosAsync(BuscaLivrosEnum opcao);
        Task<Livro> BuscaLivroAsync(int id);
        Task<bool> DeletaLivroAsync(Livro livro);
        Task<bool> AdicionaLivroAsync(Livro livro);
        Task<bool> AtualizaLivroAsync(Livro livro);

    }
}