using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace modul10_103022300003.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private static readonly List<Movie> Movies = new List<Movie>
        {
            new Movie("The Shawshank Redemption", "Frank Darabont",new List<string>{"Tim Robbins","Morgan Freeman","Bob Gunton"}, "A banker convicted of uxoricide forms a friendship over a quarter century with a hardened convict, while maintaining his innocence and trying to remain hopeful through simple compassion."),
            new Movie("The Godfather", "Francis Ford Coppola",new List<string>{"Marlon Brando","Al Pacino","James Caan"}, "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son."),
            new Movie("The Dark Knight", "Christopher Nolan",new List<string>{ "Christian Bale","Heath Ledger","Aaron Eckhart"}, "When a menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman, James Gordon and Harvey Dent must work together to put an end to the madness."),
        };

        // GET: api/movie
        [HttpGet]
        public IActionResult GetMovies()
        {
            return Ok(Movies); // Mengembalikan semua data mahasiswa
        }

        // GET: api/mahasiswa/{id}
        [HttpGet("{id}")]
        public IActionResult GetMoviesById(int id)
        {
            if (id < 0 || id >= Movies.Count)
            {
                return NotFound(); // Mengembalikan "Not Found" jika ID tidak valid
            }

            return Ok(Movies[id]); // Mengembalikan data mahasiswa berdasarkan ID
        }

        // POST: api/mahasiswa
        [HttpPost]
        public IActionResult AddMovies([FromBody] Movie movie)
        {
            Movies.Add(movie); // Menambahkan mahasiswa baru ke dalam list
            return CreatedAtAction(nameof(GetMoviesById), new { id = Movies.Count - 1 }, movie);
        }

        // DELETE: api/mahasiswa/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            if (id < 0 || id >= Movies.Count)
            {
                return NotFound(); // Jika ID tidak ditemukan
            }

            Movies.RemoveAt(id); // Menghapus mahasiswa berdasarkan ID
            return NoContent(); // Mengembalikan status sukses tanpa body
        }
    }
}
