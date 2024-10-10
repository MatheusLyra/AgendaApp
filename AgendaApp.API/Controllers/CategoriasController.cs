using AgendaApp.API.Dtos;
using AgendaApp.Data.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgendaApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly IMapper _mapper;

        public CategoriasController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            //realizando a consulta de categorias no banco de dados
            var categoriaRepository = new CategoriaRepository();

            var categorias = categoriaRepository.GetAll();

            //usando o AutoMapper para copiar a lista de categorias para uma lista do DTO
            var result = _mapper.Map<List<CategoriaResponseDto>>(categorias);

            //retornando a lista de objetos DTO
            return Ok(result);


            /* //sem utilizar o mapper tem que fazer o DExPARA na mão
             * 
            //declarando uma lista da classe DTO
            var result = new List<CategoriaResponseDto>();

            //percorrendo a lista de categorias do banco de dados
            foreach (var item in categorias)
            {
                //criando um objeto da classe DTO
                var response = new CategoriaResponseDto();
                response.Id = item.Id;
                response.Descricao = item.Descricao;

                //adicionando cada objeto DTO na lista
                result.Add(response);
            }

            //retornando a lista de objetos DTO
            return Ok(result);
            */
        }
    }
}



