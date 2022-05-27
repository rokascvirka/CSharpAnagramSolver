using NUnit.Framework;
using BuisnessLogic;
using Shouldly;

namespace AnagrameGeneratorUnitTests
{
    class InputTests
    {
        [TestCase("Alus", "valid")]
        [TestCase("al  us", "valid")]
        [TestCase("123", "Every charracter supposed to be from a to z. You can't use any symbols or numbers.")]
        [TestCase("a!us", "Every charracter supposed to be from a to z. You can't use any symbols or numbers.")]
        public void When_BadInput_Expect_AnError(string word, string actual)
        {
            //Act
            InputControler picker = new InputControler();

            word = word.RemoveSpaces();

            string result = picker.InputVerifyer(word);

            //Assert
            result.ShouldBe(actual);
        }

        //Old Assert.Equal example
        [TestCase("  al us ", "alus")]
        [TestCase(" alus", "alus")]
        [TestCase(" alus ", "alus")]
        [TestCase("alus  ", "alus")]
        [TestCase("al us", "alus")]

        public void When_InputWhithSpaces_Expect_AnswerWithout(string word, string actual)
        {

            var result = word.RemoveSpaces();

            Assert.AreEqual(result, actual);
        }

        //Shouldly example
        [TestCase("  al us ", "alus")]
        [TestCase(" alus", "alus")]
        [TestCase(" alus ", "alus")]
        [TestCase("alus  ", "alus")]
        [TestCase("al us", "alus")]
        public void When_InputWhithSpaces_Expect_AnswerWithoutUsingShouldly(string word, string actual)
        {
            var result = word.RemoveSpaces();

            result.ShouldBe(actual);

            Assert.AreEqual(result, actual);
        }

    }
}

