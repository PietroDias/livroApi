using LivrosApi.Enums;
using LivrosApi.Models;
using LivrosApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LivrosApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivrosController : ControllerBase
    {
        private readonly ILivroRepository _livroRepository;
        public LivrosController(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Livro livro)
        {
            return await _livroRepository.AdicionaLivroAsync(livro) ? Ok("Livro adicionado com sucesso")
      : BadRequest("Erro ao adicionar o Livro");

        }

        [HttpGet]
        public async Task<IActionResult> GetLivros([FromHeader] BuscaLivrosEnum opcao)
        {
            var livros = await _livroRepository.BuscaLivrosAsync(opcao);
            return livros.Any() ? Ok(livros)
            : NotFound("Livro não encontrado");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLivro(int id)
        {
            var livro = await _livroRepository.BuscaLivroAsync(id);
            return livro != null ? Ok(livro)
            : NotFound("Livro não encontrado");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Livro livro)
        {
            var livroBanco = await _livroRepository.BuscaLivroAsync(id);

            if (livroBanco == null) return NotFound("Livro não encontrado");

            livroBanco.Nome = livro.Nome ?? livroBanco.Nome;
            livroBanco.NomeEscritor = livro.NomeEscritor ?? livroBanco.NomeEscritor;
            livroBanco.Sinopse = livro.Sinopse ?? livroBanco.Sinopse;
            livroBanco.DataPublicacao = livro.DataPublicacao != new DateTime()
            ? livro.DataPublicacao : livroBanco.DataPublicacao;

            return await _livroRepository.AtualizaLivroAsync(livroBanco) ? Ok("Livro alterado com sucesso")
            : NotFound("Erro ao atualizar o livro");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var livroBanco = await _livroRepository.BuscaLivroAsync(id);

            if (livroBanco == null) return NotFound("Livro não encontrado");

            return await _livroRepository.DeletaLivroAsync(livroBanco) ?
            Ok("Livro deletado com sucesso")
            : BadRequest("Erro ao deletar o Livro");

        }
    }
}