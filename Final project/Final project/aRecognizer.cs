using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_project
{
    internal abstract class aRecognizer
    {
        public string patternName { get; set; }

        public int patternSize { get; set; }
        /// This is an abstract method that checks whether the pattern is matched with the subset of candlesticks.
        protected abstract bool patternMatchedSubset(List<aCandlestick> subsetOfCandlesticks);

        /// This method recognizes the pattern in the given list of candlesticks and returns a list of indices where the pattern occurs.
        public List<int> recognize(List<aCandlestick> candlesticks)
        {
            List<int> result = new List<int>(candlesticks.Count / 8);


            int offset = patternSize - 1;

            for (int i = offset; i < candlesticks.Count; ++i)
            {
                List<aCandlestick> subset = candlesticks.GetRange(i - offset, patternSize);

                if (patternMatchedSubset(subset))
                {
                    result.Add(i);
                }
            }
            return result;
        }

        /// This is a constructor of aRecognizer class.
        public aRecognizer(string pName, int pSize) => (patternName, patternSize) = (pName, pSize); 
        
            

    }


    


}
