namespace Poker
{
    class HandCatagorizerChain
    {
        private HandCatagorizerChain()
        {
            Head = new RoyalFlushCatagorizer();
            Head.RegisterNext(new StraightFlushCatagorizer())
                 .RegisterNext(new FourOfAKindCatagorizer())
                 .RegisterNext(new FullHouseCatagorizer())
                 .RegisterNext(new FlushCatagorizer())
                 .RegisterNext(new StraightCatagorizer())
                 .RegisterNext(new ThreeOfAKindCatagorizer())
                 .RegisterNext(new TwoPairCatagorizer())
                 .RegisterNext(new PairCatagorizer())
                 .RegisterNext(new HighCardCatagorizer());
        }

        public static HandRanking GetRank(Hand hand)
        {
            return _instance.Head.Catagorize(hand);
        }

        private HandCatagorizer Head { get; set; }

        private static readonly HandCatagorizerChain _instance = new HandCatagorizerChain();
    }
}
