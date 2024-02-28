using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_project
{
    internal class EngulfingBullishCandlestick_Recognizer : aRecognizer
    {
        public EngulfingBullishCandlestick_Recognizer() : base("Bullish Engulfing Pattern", 2) { }
        /// Determines if the pattern matched a subset of candlesticks
        protected override bool patternMatchedSubset(List<aCandlestick> Lcs)
        {
            aCandlestick pcs = Lcs[0];
            aCandlestick cs = Lcs[1];
            return pcs.isBearish && cs.isBullish && pcs.High < cs.topPrice && pcs.Low < cs.bottomPrice;
        }

    }
    internal class EngulfingBearishCandlestick_Recognizer : aRecognizer
    {
        public EngulfingBearishCandlestick_Recognizer() : base("Bearish Engulfing Pattern", 2) { }
        /// Determines if the pattern matched a subset of candlesticks
        protected override bool patternMatchedSubset(List<aCandlestick> Lcs)
        {
            aCandlestick pcs = Lcs[0];
            aCandlestick cs = Lcs[1];
            return pcs.isBullish && cs.isBearish && pcs.High < cs.topPrice && pcs.Low < cs.bottomPrice;
        }

    }
}
