using LivrosApi.Data;
using LivrosApi.Enums;
using LivrosApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LivrosApi.Repository
{
    public class LivroRepository : ILivroRepository
    {
        private readonly LivrosContext _context;
        private readonly ILogger _logger;

        public LivroRepository(LivrosContext context, ILogger<Livro> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<bool> AdicionaLivroAsync(Livro livro)
        {
            try
            {
                _logger.LogInformation("Inicio do processo para inclusão de um novo Livro");

                await _context.AddAsync(livro);

                if (await _context.SaveChangesAsync() > 0)
                {
                    _logger.LogInformation("Livro adicionado com sucesso !");
                    return true;
                }
                _logger.LogError("Erro ao tentar adicionar o livro");
                return false;


            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao adicionar o livro" + "Mensagem=>" + ex.Message);
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<bool> AtualizaLivroAsync(Livro livro)
        {
            try
            {
                _logger.LogInformation("Inicio do processo para atualizar um Livro");

                _context.Update(livro);

                if (await _context.SaveChangesAsync() > 0)
                {
                    _logger.LogInformation("Livro alterado com sucesso");
                    return true;
                }
                _logger.LogError("Erro ao tentar alterar o livro");
                return false;

            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao alterar o livro" + "Mensagem=>" + ex.Message);
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Livro> BuscaLivroAsync(int id)
        {
            try
            {
                _logger.LogInformation("Buscando livro...");
                var livro = await _context.Livros.Where(x => x.Id == id).FirstOrDefaultAsync();

                if (livro != null)
                {
                    _logger.LogInformation("Livro encontrado: " + livro);
                    return livro;
                }

                _logger.LogError("Livro não encontrado");
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao encontrar livro" + "Mensagem=>" + ex.Message);
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<IEnumerable<Livro>> BuscaLivrosAsync(BuscaLivrosEnum opcao)
        {
            try
            {
                _logger.LogInformation("Buscando livros...");

                var list = await _context.Livros.ToListAsync();

                if (list.Count > 0)
                {
                    _logger.LogInformation("Livros recuperados na base: " + list);
                }
                else
                {
                    _logger.LogError("Livros nao encontrados");
                    return null;
                }

                if (opcao == BuscaLivrosEnum.codigo)
                {
                    _logger.LogInformation("Ordenando por codigo");
                    return list.OrderBy(x => x.Id);
                }

                _logger.LogInformation("Ordenando por Nome");
                return list.OrderBy(x => x.Nome);
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao adicionar o livro" + "Mensagem=>" + ex.Message);
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<bool> DeletaLivroAsync(Livro livro)
        {
            try
            {
                _logger.LogInformation("Inicio do processo de exclusão de um livro");

                _context.Remove(livro);

                if (await _context.SaveChangesAsync() > 0)
                {
                    _logger.LogInformation("Livro excluido com sucesso !");
                    return true;
                }
                _logger.LogError("Erro ao tentar excluir o livro");
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao adicionar o livro" + "Mensagem=>" + ex.Message);
                throw new Exception(ex.Message, ex);
            }
        }
    }
}