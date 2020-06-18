using System.Threading.Tasks;
using Core;
using Moq;
using NUnit.Framework;

namespace UnitTest
{
    public class Tests
    {

        [Test]
        public async Task Test1()
        {
            var mock = new Mock<IJokeApiService>();
            mock.Setup(s => s.GetJokeWithWord("en")).Returns(
                Task.FromResult(new[]{
                new Joke {Text = "En, to, tre."},
                new Joke {Text = "To, en, tre."},
                new Joke {Text = "Tre, to, en."},
            }));
            //var service = new JokeMagicService(new TerjeJokeService());
            var service = new JokeMagicService(mock.Object);
            var joke = await service.GetJokesWhichStartsWithWord("en");
            Assert.AreEqual("En, to, tre.", joke.Text);
        }

        [Test]
        public async Task Test2()
        {
            // arrange
            var mock = new Mock<IJokeApiService>();
            mock.Setup(s => s.GetJokeWithWord(It.IsAny<string>())).Returns(
                Task.FromResult(new[]{
                    new Joke {Text = "En, to, tre."},
                    new Joke {Text = "To, en, tre."},
                    new Joke {Text = "Tre, to, en."},
                    new Joke {Text = "En, tre, to."},
                }));
            
            // act
            var service = new JokeMagicService(mock.Object);
            var joke = await service.GetJokesWhichStartsWithWord("en");

            // assert
            Assert.AreEqual("En, to, tre.", joke.Text);
            mock.Verify(s=>s.GetJokeWithWord("en"));
            mock.VerifyNoOtherCalls();
        }

        [Test]
        public async Task Test3()
        {
            // arrange
            var mock = new Mock<IJokeApiService>();
            mock.Setup(s => s.GetJokeWithWord(It.IsAny<string>())).Returns(
                Task.FromResult(new Joke[0]));

            // act
            var service = new JokeMagicService(mock.Object);
            var joke = await service.GetJokesWhichStartsWithWord("en");

            // assert
            Assert.IsNull(joke);
        }
    }
}