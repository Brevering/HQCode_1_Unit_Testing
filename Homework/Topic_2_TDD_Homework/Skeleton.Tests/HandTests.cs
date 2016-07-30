namespace Poker.Tests
{
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class HandTests
    {
        Hand testHand = new Hand(new List<ICard>
                                         {
                                             new Card(CardFace.Ace, CardSuit.Clubs),
                                             new Card(CardFace.Ten, CardSuit.Spades),
                                             new Card(CardFace.Jack, CardSuit.Hearts),
                                             new Card(CardFace.Five, CardSuit.Clubs),
                                             new Card(CardFace.Six, CardSuit.Diamonds)
                                         });

        [TestMethod]
        public void HandMustConsistOfFiveCardsWhenCreatedProperly()
        {
            Assert.AreEqual(5, this.testHand.Cards.Count);
        }

        [TestMethod]
        public void ToStringMustReturnTheSeparatedStringRepresentationsOfTheCardsInTheHand()
        {
            Assert.AreEqual("A♣, 10♠, J♥, 5♣, 6♦", this.testHand.ToString());
        }
    }
}
