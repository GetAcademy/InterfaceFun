using System.Threading.Tasks;

namespace Core
{
    public interface IJokeApiService
    {
        Task<Joke> GetRandomJoke();
        Task<Joke[]> GetJokeWithWord(string word);
    }
}
