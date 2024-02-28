using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_project
{
   
    internal class Recognizer_Bullish : aRecognizer
    {
        public Recognizer_Bullish() : base("Bullish", 1) { }

        /// Determines if the pattern matched a subset of candlesticks is bullish.
        protected override bool patternMatchedSubset(List<aCandlestick> subsetOfCandlesticks)
        {
            return subsetOfCandlesticks[0].isBullish;
        }
    }
    internal class Recognizer_Bearish : aRecognizer
    {
        public Recognizer_Bearish() : base("Bearish", 1) { }
        /// Determines if the pattern matched a subset of candlesticks is bearish.
        protected override bool patternMatchedSubset(List<aCandlestick> subsetOfCandlesticks)
        {
            return subsetOfCandlesticks[0].isBearish;
        }
    }
    internal class Recognizer_Neutral : aRecognizer
    {
        public Recognizer_Neutral() : base("Neutral", 1) { }
        /// Determines if the pattern matched a subset of candlesticks is nuetral.
        protected override bool patternMatchedSubset(List<aCandlestick> subsetOfCandlesticks)
        {
            return subsetOfCandlesticks[0].isNeutral;
        }
    }
    internal class Recognizer_Doji : aRecognizer
    {
        public Recognizer_Doji() : base("Doji", 1) { }
        /// Determines if the pattern matched a subset of candlesticks is doji.
        protected override bool patternMatchedSubset(List<aCandlestick> subsetOfCandlesticks)
        {
            return subsetOfCandlesticks[0].isDoji;
        }
    }
    internal class Recognizer_DragonFly : aRecognizer
    {
        public Recognizer_DragonFly() : base("Dragonfly", 1) { }
        /// Determines if the pattern matched a subset of candlesticks is dragonfly.
        protected override bool patternMatchedSubset(List<aCandlestick> subsetOfCandlesticks)
        {
            return subsetOfCandlesticks[0].isDragonflyDoji;
        }
    }
    internal class Recognizer_NeutralDoji : aRecognizer
    {
        public Recognizer_NeutralDoji() : base("Neutral Doji", 1) { }
        /// Determines if the pattern matched a subset of candlesticks is nuetral doji.
        protected override bool patternMatchedSubset(List<aCandlestick> subsetOfCandlesticks)
        {
            return subsetOfCandlesticks[0].isNeutralDoji;
        }
    }
    internal class Recognizer_GravestoneDoji : aRecognizer
    {
        public Recognizer_GravestoneDoji() : base("Gravestone Doji", 1) { }
        /// Determines if the pattern matched a subset of candlesticks is gravestone
        protected override bool patternMatchedSubset(List<aCandlestick> subsetOfCandlesticks)
        {
            return subsetOfCandlesticks[0].isGravestoneDoji;
        }
    }
    internal class Recognizer_LongLeggedDoji : aRecognizer
    {
        public Recognizer_LongLeggedDoji() : base("LongLegged Doji", 1) { }
        /// Determines if the pattern matched a subset of candlesticks 
        protected override bool patternMatchedSubset(List<aCandlestick> subsetOfCandlesticks)
        {
            return subsetOfCandlesticks[0].isLongLeggedDoji;
        }
    }
    internal class Recognizer_Hammer : aRecognizer
    {
        public Recognizer_Hammer() : base("Hammer", 1) { }
        /// Determines if the pattern matched a subset of candlesticks
        protected override bool patternMatchedSubset(List<aCandlestick> subsetOfCandlesticks)
        {
            return subsetOfCandlesticks[0].isHammer;
        }
    }
    internal class Recognizer_BullishHammer : aRecognizer
    {
        public Recognizer_BullishHammer() : base("Bullish Hammer", 1) { }
        /// Determines if the pattern matched a subset of candlesticks
        protected override bool patternMatchedSubset(List<aCandlestick> subsetOfCandlesticks)
        {
            return subsetOfCandlesticks[0].isBullishHammer;
        }
    }
    internal class Recognizer_BearishHammer : aRecognizer
    {
        public Recognizer_BearishHammer() : base("Bearish Hammer", 1) { }
        /// Determines if the pattern matched a subset of candlesticks
        protected override bool patternMatchedSubset(List<aCandlestick> subsetOfCandlesticks)
        {
            return subsetOfCandlesticks[0].isBearishHammer;
        }
    }
    internal class Recognizer_invertedHammer : aRecognizer
    {
        public Recognizer_invertedHammer() : base("Inverted Hammer", 1) { }
        /// Determines if the pattern matched a subset of candlesticks
        protected override bool patternMatchedSubset(List<aCandlestick> subsetOfCandlesticks)
        {
            return subsetOfCandlesticks[0].isInvertedHammer;
        }
    }
    internal class Recognizer_bullishInvertedHammer : aRecognizer
    {
        public Recognizer_bullishInvertedHammer() : base("Bullish Inverted Hammer", 1) { }
        /// Determines if the pattern matched a subset of candlesticks
        protected override bool patternMatchedSubset(List<aCandlestick> subsetOfCandlesticks)
        {
            return subsetOfCandlesticks[0].isBullishInvertedHammer;
        }
    }
    internal class Recognizer_bearishInvertedHammer : aRecognizer
    {
        public Recognizer_bearishInvertedHammer() : base("Bearish Inverted Hammer", 1) { }
        /// Determines if the pattern matched a subset of candlesticks
        protected override bool patternMatchedSubset(List<aCandlestick> subsetOfCandlesticks)
        {
            return subsetOfCandlesticks[0].isBearishInvertedHammer;
        }
    }
    internal class Recognizer_Marubozu : aRecognizer
    {
        public Recognizer_Marubozu() : base("Marubozu", 1) { }
        /// Determines if the pattern matched a subset of candlesticks
        protected override bool patternMatchedSubset(List<aCandlestick> subsetOfCandlesticks)
        {
            return subsetOfCandlesticks[0].isMarubozu;
        }
    }
    internal class Recognizer_whiteMarubozu : aRecognizer
    {
        public Recognizer_whiteMarubozu() : base("White Marubozu", 1) { }
        /// Determines if the pattern matched a subset of candlesticks
        protected override bool patternMatchedSubset(List<aCandlestick> subsetOfCandlesticks)
        {
            return subsetOfCandlesticks[0].isWhiteMarubozu;
        }
    }
    internal class Recognizer_blackMarubozu : aRecognizer
    {
        public Recognizer_blackMarubozu() : base("Black Marubozu", 1) { }
        /// Determines if the pattern matched a subset of candlesticks
        protected override bool patternMatchedSubset(List<aCandlestick> subsetOfCandlesticks)
        {
            return subsetOfCandlesticks[0].isBlackMarubozu;
        }
    }

}

