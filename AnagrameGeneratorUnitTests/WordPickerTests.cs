using NUnit.Framework;
using BuisnessLogic;

namespace AnagrameGeneratorUnitTests
{
    class InputTests
    {
        [TestCase("", "String can't be null or empty")]
        [TestCase("Alus", "valid")]
        [TestCase("al  us", "valid")]
        [TestCase("123", "Every charracter supposed to be from a to z. You can't use any symbols or numbers.")]
        [TestCase("a!us", "Every charracter supposed to be from a to z. You can't use any symbols or numbers.")]
        public void When_BadInput_Expect_AnError(string word, string actual)
        {
            //Act
            WordPicker picker = new WordPicker();

            word = picker.RemoveSpaces(word);

            string expected = picker.InputVerifyer(word);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("  al us ", "alus")]
        [TestCase(" alus", "alus")]
        [TestCase(" alus ", "alus")]
        [TestCase("alus  ", "alus")]
        [TestCase("al us", "alus")]

        public void When_InputWhithSpaces_Expect_AnswerWithout(string word, string actual)
        {
            WordPicker remover = new WordPicker();

            string expected = remover.RemoveSpaces(word);

            Assert.AreEqual(expected, actual);
        }

    }
}

