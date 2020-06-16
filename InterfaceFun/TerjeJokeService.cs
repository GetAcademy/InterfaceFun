using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace InterfaceFun
{
    class TerjeJokeService : IJokeApiService
    {
        public Task<Joke> GetRandomJoke()
        {
            return Task.FromResult(
                new Joke() {Text = "Haha, hei hadet."}
                );
        }

        public Task<Joke[]> GetJokeWithWord(string word)
        {
            return Task.FromResult(
                new[] {
                new Joke() { Text = "Haha, hei hadet." },
                new Joke() { Text = "Hadet, hei haha." },
                }
                );
        }
    }
}
