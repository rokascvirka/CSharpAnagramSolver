using Contracts;
using FakeItEasy;
using AnagramSolver.Website.Controllers;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AnagramSolverWebApp.Tests.Controller
{

    public class HomeControllerTests
    {
        private IAnagramGenerator anagramGenerator;
        private ITxtReader txtReader;
        private IDictGenerator dictionaryGenerator;
        private IWordSorter wordSorter;
        private IInputControler inputControler;



        public HomeControllerTests()
        {
            //Dependencies
            this.anagramGenerator = A.Fake<IAnagramGenerator>();
            this.txtReader = A.Fake<ITxtReader>();
            this.dictionaryGenerator = A.Fake<IDictGenerator>();
            this.wordSorter = A.Fake<IWordSorter>();
            this.inputControler = A.Fake<IInputControler>();
        }

        [Fact]
        public void HomeController_Index_ReturnsSuccess()
        {
            HomeController controler = new HomeController(null, anagramGenerator, txtReader, dictionaryGenerator, wordSorter, inputControler);

            A.CallTo(() => inputControler.InputVerifyer("alus")).Returns("valid");
            A.CallTo(() => inputControler.InputVerifyer("aluss")).Returns("NoValid");
            A.CallTo(anagramGenerator).Where(call => call.Method.Name == "AnagramGeneratorMethod").WithReturnType<string>().Returns("sula");

            var result = controler.Index("aluss");

            var viewResult = Assert.IsType<ViewResult>(result);

            Assert.Equal("NoValid", ((ViewResult)result).ViewData["Message"]);
        }
    }
}
