using NUnit.Framework;
using BuisnessLogic;
using System.Collections.Generic;

namespace AnagrameGeneratorUnitTests
{
    public class Tests
    {
        [Test]
        public void When_GoodInput_Expect_AnNoErrors()
        {

            // ARANGE
            var answer = 1;
            var answerTwo = 2;
            var answerZero = 0;
            var anagramWord = "alus";
            var randomValueInList = "sula";

            // ACT
            AnagramGenerator generator = new AnagramGenerator();
            string result = generator.ShowAnagram(answer, anagramWord, randomValueInList);
            string resultTwo = generator.ShowAnagram(answerTwo, anagramWord, randomValueInList);
            string resultZero = generator.ShowAnagram(answerZero, anagramWord, randomValueInList);

            // ASSERT
            Assert.AreEqual(result, "This word: alus anagram: sula");
            Assert.AreEqual(resultTwo, "This word: alus doesn't have anagram in our dictionary");
            Assert.AreEqual(resultZero, "This word: alus doesn't have anagram in our dictionary");

        }
        [Test]
        public void Whatever()
        {
            //Arange
            var randomValueInList = "sula";
            var anagramWord = "alus";
            var sortedMainWordForAnagram = "alsu";
            var valuesList = new List<string>();
            var moreThanOneValueList = new List<string>();
            var wordsInDictionary = new Dictionary<string, List<string>>();
            var secondWordsInDictionary = new Dictionary<string, List<string>>();

            valuesList.Add("sula");
            moreThanOneValueList.Add("sula");
            moreThanOneValueList.Add("alsu");
            wordsInDictionary.Add("alsu", valuesList);
            secondWordsInDictionary.Add("alsu", moreThanOneValueList);


            // Act
            AnagramGenerator validator = new AnagramGenerator();
            // if dict value count == 1
            int positiveResult = validator.ValidateAnagram(randomValueInList, anagramWord, sortedMainWordForAnagram, wordsInDictionary);
            int negativeResult = validator.ValidateAnagram(anagramWord, anagramWord, sortedMainWordForAnagram, wordsInDictionary);

            //if dict value count > 1
            int positiveRes = validator.ValidateAnagram(randomValueInList, anagramWord, sortedMainWordForAnagram, secondWordsInDictionary);
            int negativeRes = validator.ValidateAnagram(anagramWord, anagramWord, sortedMainWordForAnagram, secondWordsInDictionary);


            //assert
            Assert.AreEqual(positiveResult, 1);
            Assert.AreEqual(negativeResult, 0);
            Assert.AreEqual(positiveRes, 1);
            Assert.AreEqual(negativeRes, 2);
        }
    }
}

 // Unit tests
            //if (VerifyInput(null) == "valid")
            //{
            //    Console.WriteLine("Input can't be null");
            //}

            //if (VerifyInput("") == "valid")
            //{
            //    Console.WriteLine("Input can't be empty");
            //}

            //if (VerifyInput("Labas") != "valid")
            //{
            //    Console.WriteLine("Does't work ToLower()");
            //}

            //if (VerifyInput("      Labas") != "valid")
            //{
            //    Console.WriteLine("Does't work Trim() from beggining");
            //}

            //if (VerifyInput("      Labas  ") != "valid")
            //{
            //    Console.WriteLine("Does't work Trim() from end");
            //}
            //if (VerifyInput("123") == "valid")
            //{
            //    Console.WriteLine("Does't work IsLetter() - numbers case");
            //}
            //if (VerifyInput("!labas") == "valid")
            //{
            //    Console.WriteLine("Does't work IsLetter() - symbols case");
            //}
            //if (VerifyInput("la bas") == "not valid")
            //{
            //    Console.WriteLine("Space in the middle is not solved");
            //}

            //Console.WriteLine("All tests passed");
        