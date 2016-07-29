namespace Santase.Tests
{
    using System;

    using NUnit.Framework;

    using Logic.Cards;

    using Santase.Logic;
    
    [TestFixture]
    public class DeckTests
    {
        [Test]
        public void NewDeckShouldContain24Cards()
        {
            Deck testDeck = new Deck();
            Assert.AreEqual(24, testDeck.CardsLeft);
        }

        [Test]
        public void TrumpCardShouldBeAValidCard()
        {
            Deck testDeck = new Deck();
            Assert.IsTrue(Enum.IsDefined(typeof(CardSuit), testDeck.GetTrumpCard.Suit));
            Assert.IsTrue(Enum.IsDefined(typeof(CardType), testDeck.GetTrumpCard.Type));
        }

        [Test]
        public void GetNextCardShouldThrowIfDeckIsEmpty()
        {
            Deck testDeck = new Deck();            
            int initialNumberOfCards = testDeck.CardsLeft;
            for (int i = 0; i < initialNumberOfCards; i++)
            {
                testDeck.GetNextCard();
            }
            
            Assert.That(() => testDeck.GetNextCard(), Throws.TypeOf<InternalGameException>()) ;
        }


        [Test]
        public void GetNextCardShouldReturnAValidCard()
        {
            Deck testDeck = new Deck();
            Assert.IsTrue(Enum.IsDefined(typeof(CardSuit), testDeck.GetNextCard().Suit));
            Assert.IsTrue(Enum.IsDefined(typeof(CardType), testDeck.GetNextCard().Type));
        }

        [Test]
        public void GetNextCardShouldRemoveTheCardFromTheDeck()
        {
            Deck testDeck = new Deck();
            int initialNumberOfCards = testDeck.CardsLeft;
            testDeck.GetNextCard();
            Assert.AreEqual((initialNumberOfCards - 1), testDeck.CardsLeft);
        }

        [Test]
        public void ChangeTrumpCardShouldChangeTheTrumpCardIfThereAreCardsLeftInTheDeck()
        {
            Deck testDeck = new Deck();
            Card initialTrumpCard = testDeck.GetTrumpCard;
            Card newCard = testDeck.GetNextCard();
            testDeck.ChangeTrumpCard(newCard);
            Assert.AreNotSame(initialTrumpCard, testDeck.GetTrumpCard);
        }

        [TestCase(24)]
        public void ChangeTrumpCardShouldNotChangeTheTrumpCardIfThereAreNoCardsLeftInTheDeck(int cardsToBeDrawn)
        {
            Deck testDeck = new Deck();
            Card initialTrumpCard = testDeck.GetTrumpCard;
            Card newCard = new Card(CardSuit.Spade, CardType.Ace);
            for (int i = 0; i < cardsToBeDrawn; i++)
            {
                if (i == cardsToBeDrawn - 1)
                {
                    newCard = testDeck.GetNextCard();
                }
                else
                {
                    testDeck.GetNextCard();
                }
            }

            testDeck.ChangeTrumpCard(newCard);

            Assert.AreEqual(0, testDeck.CardsLeft);
            Assert.AreSame(initialTrumpCard, testDeck.GetTrumpCard);
        }
    }
}
