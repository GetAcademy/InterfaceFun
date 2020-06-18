using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace UnitTest
{
    class TerjeJokeService : IJokeApiService
    {
        public Task<Joke> GetRandomJoke()
        {
            return Task.FromResult(
                new Joke() { Text = "Haha, hei hadet." }
            );
        }

        public Task<Joke[]> GetJokeWithWord(string word)
        {
            return Task.FromResult(
                new[] {
                    new Joke() { Text = "En, to, tre." },
                    new Joke() { Text = "To, en, tre." },
                    new Joke() { Text = "Tre, to, en." },
                }
            );
        }
    }
}
