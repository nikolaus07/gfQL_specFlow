using gfQL_specFlow.Pages;
using NUnit.Framework;

namespace gfQL_specFlow.StepDefinitions
{
    [Binding]
    public sealed class RechnerSteps
    {
        private RechnerPage rechner = new RechnerPage();

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            rechner.zahl1 = number;
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            rechner.zahl2 = number;
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            rechner.addiere();
        }

        [When(@"the two numbers are multipliziert")]
        public void WhenTheTwoNumbersAreMultipliziert()
        {
            rechner.multipiziere();
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            Assert.True(rechner.ergebnis == result);
        }
    }
}