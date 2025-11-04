using Microsoft.AspNetCore.Mvc;

namespace TaliExpress.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonTestController : ControllerBase
    {

        [HttpPost("postPokemonServer")]
        [Route("postPokemonServer")]
        public IActionResult? PostPokemonServer()
        {
            return Ok();
        }

        [HttpGet("getPokemonServer")]
        [Route("getPokemonServer")]
        public Pokemon[] GetPokemonServer()
        {
            return Pokemon.GetPokemons();
        }

        [HttpGet("getPokemonServerById")]
        [Route("getPokemonServerById")]
        public Pokemon? getPokemonServerById(int id)
        {
            return Pokemon.GetPokemons().Where(p => p.id == id).FirstOrDefault();
        }

        public class Pokemon
        {
            public int id { get; set; } = -1;
            public string type { get; set; } = string.Empty;
            public string name { get; set; } = string.Empty;
            public bool isCool { get; set; } = false;

            public static Pokemon[] GetPokemons()
            {
                return new Pokemon[] {
               new Pokemon() {
      id = 1,
      name = "Bulbasaur",
      type =  "Grass/Poison",
      isCool = true
    },
    new Pokemon() {
      id = 2,
      name = "Charmander",
      type = "Fire",
      isCool = false
    },
    new Pokemon() {
      id = 3,
      name = "Squirtle",
      type = "Water",
      isCool = true
    },
    new Pokemon() {
      id = 4,
      name = "Pikachu",
      type = "Electric",
      isCool = true
    },
   new Pokemon()  {
      id = 5,
      name = "Eevee",
      type = "Normal",
      isCool = false
   }
                };
            }
        }
    }
}