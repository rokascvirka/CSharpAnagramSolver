using NUnit.Framework;
using BuisnessLogic;
using System.Collections.Generic;
using Shouldly;

namespace AnagrameGeneratorUnitTests
{
    public class Tests
    {

        //First try to test ShowAnagram
        [Test]
        public void When_KnownInput_Expect_NoErrors()
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
            string resultZero = generator.ShowAnagram(answerZero, anagramWord, "");

            // ASSERT
            Assert.AreEqual(result, "This word: alus anagram: sula");
            Assert.AreEqual(resultTwo, "This word: alus doesn't have anagram in our dictionary");
            Assert.AreEqual(resultZero, "This word: alus doesn't have anagram in our dictionary");
        }

        //Second try to test ShowAnagram with TestCase
        [TestCase(1, "alus", "sula", "This word: alus anagram: sula")]
        [TestCase(0, "alus", "", "This word: alus doesn't have anagram in our dictionary")]
        public void When_EnteredResultIsGood_Expect_KnownOutPut(int answer, string anagramWord, string randomValueInList, string actual)
        {
            AnagramGenerator generator = new AnagramGenerator();
            string expected = generator.ShowAnagram(answer, anagramWord, randomValueInList);

            Assert.AreEqual(expected, actual);
        }

        //Third try to test ShowAnagram with Shouldly
        [TestCase(1, "alus", "sula", "This word: alus anagram: sula")]
        [TestCase(0, "alus", "", "This word: alus doesn't have anagram in our dictionary")]
        public void When_EnteredResultIsGood_Expect_KnownOutPutShouldly(int answer, string anagramWord, string randomValueInList, string actual)
        {
            AnagramGenerator generator = new AnagramGenerator();
            string result = generator.ShowAnagram(answer, anagramWord, randomValueInList);

            result.ShouldBe(actual);
            
        }

        [Test]
        public void When_KnowInput_Expect_RightValidationNumberReturned()
        {
            //Arange
            var randomValueInList = "sula";
            var anagramWord = "alus";
            var sortedMainWordForAnagram = "alsu";
            var valuesList = new List<string>() { "sula" };
            var moreThanOneValueList = new List<string>() { "sula", "alus"};

            var wordsInDictionary = new Dictionary<string, List<string>>() 
                {
                    { "alsu", valuesList }
                };

            var secondWordsInDictionary = new Dictionary<string, List<string>>()
                {
                    { "alsu", moreThanOneValueList }
                };


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

        