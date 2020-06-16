using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class JokeMagicService
    {
        private IJokeApiService _jokeApiService;

        public JokeMagicService(IJokeApiService jokeApiService)
        {
            _jokeApiService = jokeApiService;
        }

        public async Task<Joke[]> GetJokesWithSameWord(int count)
        {
            var jokes = new List<Joke>();
            var randomJoke = await _jokeApiService.GetRandomJoke();
            var firstWord = randomJoke.Text.Split(' ').First();
            jokes.Add(new Joke() { Text = randomJoke.Text });
            var jokesResult = await _jokeApiService.GetJokeWithWord(firstWord);
            jokes.AddRange(jokesResult.Take(count - 1));
            return jokes.ToArray();
        }
    }
}
