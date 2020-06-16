using System;
using System.Threading.Tasks;
using Core;
using InterfaceFun.ApiModel;
using RestSharp;
using RestSharp.Authenticators;

namespace InterfaceFun
{
    class Program
    {
        static void Main(string[] args)
        {
            Test().Wait();
        }

        static async Task Test()
        {
            //var service = new JokeMagicService(new ChuckNorrisJokeService());
            var service = new JokeMagicService(new TerjeJokeService());
            var jokes = await service.GetJokesWithSameWord(5);
            foreach (var joke in jokes)
            {
                Console.WriteLine(joke.Text);
            }
        }
    }
}
