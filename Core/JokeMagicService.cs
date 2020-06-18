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

        public async Task<Joke> GetJokesWhichStartsWithWord(string word)
        {
            var jokes = await _jokeApiService.GetJokeWithWord(word);
            return jokes.FirstOrDefault(joke => joke.Text.StartsWith(word, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
