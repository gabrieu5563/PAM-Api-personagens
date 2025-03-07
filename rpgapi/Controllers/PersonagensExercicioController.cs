using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rpgapi.models;
using rpgapi.Models.Enums;

namespace rpgapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonagensExercicioController : ControllerBase
    {
        //Gabriel Joaqim e João Victor
         private static List<Personagem> personagens = new List<Personagem>()
        {
            new Personagem() { Id = 1, Nome = "Frodo", PontosVida=100, Forca=17, Defesa=23, Inteligencia=33, Classe=ClasseEnum.Cavaleiro},
            new Personagem() { Id = 2, Nome = "Sam", PontosVida=100, Forca=15, Defesa=25, Inteligencia=30, Classe=ClasseEnum.Cavaleiro},
            new Personagem() { Id = 3, Nome = "Galadriel", PontosVida=100, Forca=18, Defesa=21, Inteligencia=35, Classe=ClasseEnum.Clerigo },
            new Personagem() { Id = 4, Nome = "Gandalf", PontosVida=100, Forca=18, Defesa=18, Inteligencia=37, Classe=ClasseEnum.Mago },
            new Personagem() { Id = 5, Nome = "Hobbit", PontosVida=100, Forca=20, Defesa=17, Inteligencia=31, Classe=ClasseEnum.Cavaleiro },
            new Personagem() { Id = 6, Nome = "Celeborn", PontosVida=100, Forca=21, Defesa=13, Inteligencia=34, Classe=ClasseEnum.Clerigo },
            new Personagem() { Id = 7, Nome = "Radagast", PontosVida=100, Forca=25, Defesa=11, Inteligencia=35, Classe=ClasseEnum.Mago }
        };

        //A)
        [HttpGet("GetByNome/{nome}")]
        public IActionResult GetByNome(string nome)
        {
            var personagem = personagens.Find(p => p.Nome == nome);
            return personagem != null ? Ok(personagem) : NotFound("NotFound.");
        }

        //B)
        [HttpGet("GetClerigoMago")]
        public IActionResult GetClerigoMago()
        {
            var lista = personagens
                .Where(p => p.Classe != ClasseEnum.Cavaleiro)
                .OrderByDescending(p => p.PontosVida)
                .ToList();
            return Ok(lista);
        }

        //C)
        [HttpGet("GetEstatisticas")]
        public IActionResult GetEstatisticas()
        {
            int quantidade = personagens.Count;
            int somaInteligencia = personagens.Sum(p => p.Inteligencia);
            return Ok(new { Quantidade = quantidade, SomaInteligencia = somaInteligencia });
        }

        //D)
        [HttpPost("PostValidacao")]
        public IActionResult PostValidacao([FromBody] Personagem personagem)
        {
            if (personagem.Defesa < 10 || personagem.Inteligencia > 30)
                return BadRequest("Defesa abaixo de 10 ou inteligência acima de 30");
            personagens.Add(personagem);
            return Ok(personagem);
        }

        //E)
        [HttpPost("PostValidacaoMago")]
        public IActionResult PostValidacaoMago([FromBody] Personagem personagem)
        {
            if (personagem.Inteligencia < 35)
                return BadRequest("Inteligência de magos deve ser acima de 35");
            personagens.Add(personagem);
            return Ok(personagem);
        }

        //F)
        [HttpGet("GetByClasse/{idClasse}")]
        public IActionResult GetByClasse(int idClasse)
        {
            var lista = personagens.Where(p => p.Classe == (ClasseEnum)idClasse).ToList();
            return Ok(lista);
        }
    }
}