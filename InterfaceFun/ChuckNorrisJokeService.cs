
using System.Linq;
using System.Threading.Tasks;
using Core;
using InterfaceFun.ApiModel;
using RestSharp;

namespace InterfaceFun
{
    class ChuckNorrisJokeService : IJokeApiService
    {
        public async Task<Joke> GetRandomJoke()
        {
            var client = new RestClient("https://api.chucknorris.io");
            var request = new RestRequest("jokes/random");
            var joke = await client.GetAsync<ApiJoke>(request);
            return new Joke(){Text = joke.value};
        }

        public async Task<Joke[]> GetJokeWithWord(string word)
        {
            var client = new RestClient("https://api.chucknorris.io");
            var request = new RestRequest($"jokes/search?query={word}");
            var jokes = await client.GetAsync<ApiJokes>(request);
            return jokes.result.Select(j => new Joke {Text = j.value}).ToArray();
        }
    }
}
