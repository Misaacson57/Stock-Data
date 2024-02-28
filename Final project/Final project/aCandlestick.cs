using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Final_project
{
    public class aCandlestick
    {
        /// <summary>
        /// gets the value from the data and set them as the value for the variables, Date, Open, Close, High, Low, Volume
        /// </summary>
        /// 

        public string Ticker { get; set; }

        public string Period { get; set; }

        public DateTime Date { get; set; }

        public double Open { get; set; }
        
        public double Close { get; set; }

        public double High { get; set; }

        public double Low { get; set; }

        public long Volume { get; set; }

        public double range { get; private set; }

        public double body { get; private set; }

        public double topPrice { get; private set; }
        public double bottomPrice { get; private set; }
        public double UpperTail { get; private set; }
        public double LowerTail { get; private set; }


        public static DataTable Datasource { get; internal set; }

        public Boolean isBullish { get; private set; }
        public Boolean isBearish { get; private set; }
        public Boolean isNeutral { get; private set; }


        public Boolean isDoji { get; private set; }
        public Boolean isGravestoneDoji { get; private set; }
        public Boolean isNeutralDoji { get; private set; }
        public Boolean isDragonflyDoji { get; private set; }
        public Boolean isLongLeggedDoji { get; private set; }

        public Boolean isHammer { get; private set; }
        public Boolean isBullishHammer { get; private set; }
        public Boolean isBearishHammer { get; private set; }
        public Boolean isInvertedHammer { get; private set; }
        public Boolean isBullishInvertedHammer { get; private set; }
        public Boolean isBearishInvertedHammer { get; private set; }
        public Boolean isMarubozu { get; private set; }
        public Boolean isWhiteMarubozu { get; private set; }
        public Boolean isBlackMarubozu { get; private set; }

        public Boolean dojiTest(double bodyTolerance = 0.03)
        {
            return body <= bodyTolerance * range;
        }

        public Boolean dragonflyDoji(double bodyTolerance = 0.03, double upperTailTolerance = .05)
        {
            return dojiTest(bodyTolerance) && (UpperTail <= range + upperTailTolerance);
        }
        public Boolean neutralDojiTest(double bodyTolerance = 0.03)
        {
            return dojiTest(bodyTolerance);
        }
        public Boolean gravestoneDojiTest(double bodyTolerance = 0.03, double lowerTailTolerance = .05)
        {
            return dojiTest(bodyTolerance) && (UpperTail <= range + lowerTailTolerance);
        }
        public Boolean longleggedDojiTest(double bodyTolerance = .03, double positionToleranceAroundCenter = .1)
        {
            double longestTail = Math.Max(UpperTail, LowerTail);
            return dojiTest(bodyTolerance) && (longestTail <= range * (0.5 - positionToleranceAroundCenter));
        }
        public Boolean hammerTest(double minbodyTolerance = 0.15,double maxBodyTolerance = .25, double upperTailTolerance = .1)
        {
            return (minbodyTolerance * range <= body) && (body >= maxBodyTolerance * range) && (UpperTail <= upperTailTolerance);
        }
        public Boolean bullishHammerTest(double minBodyTolerance = 0.15,double maxBodyTolerance = .25,double upperTailTolerance = .1)
        {
            return hammerTest(minBodyTolerance, maxBodyTolerance, upperTailTolerance) && (Close > Open);
        }
        public Boolean bearishHammerTest(double minBodyTolerance = 0.15, double maxBodyTolerance = .25, double upperTailTolerance = .1)
        {
            return hammerTest(minBodyTolerance, maxBodyTolerance, upperTailTolerance) && (Close < Open);
        }
        public Boolean invertedHammerTest(double minBodyTolerance = 0.15, double maxBodyTolerance = .25, double lowerTailTolerance = .1)
        {
            return hammerTest(minBodyTolerance, maxBodyTolerance, lowerTailTolerance) && (Close < Open);
        }
        public Boolean bullishInvertedHammerTest(double bodyTolerance = 0.03)
        {
            return invertedHammerTest(bodyTolerance) && isBullish == true;
        }
        public Boolean bearishInvertedHammerTest(double bodyTolerance = 0.03)
        {
            return invertedHammerTest(bodyTolerance) && isBearish == true;
        }
        public Boolean marubozuTest(double bodyTolerance = .03)
        {
            return body > range * (1 - bodyTolerance);
        }
        public Boolean whiteMarubozuTest(double bodyTolerance = 0.03)
        {
            return marubozuTest(bodyTolerance) && isBullish == true;
        }
        public Boolean blackMarubozuTest(double bodyTolerance = 0.03)
        {
            return marubozuTest(bodyTolerance) && isBearish == true;
        }
        public aCandlestick()
        {
            /// Sets the default values for Date, Open, Close, High, Low, Volume
            Date = DateTime.Now;
            Open = 0; Close = 0; High = 0; Low = 0; Volume = 0;

            Ticker = string.Empty;
            Period = string.Empty;

        }

        public aCandlestick(aCandlestick cs)
        {
            Date = cs.Date;
            Open = cs.Open;
            High= cs.High; 
            Low= cs.Low;
            Close= cs.Close;
            Volume= cs.Volume;

            Ticker = cs.Ticker;
            Period = cs.Period; 

            computeProperties();
        }



        public aCandlestick(DateTime date, double open, double high, double low, double close, long volume, string Ticker)
        {
            /// Allows the pieces of information to be used publically in the program
            this.Date = date;
            this.Open = open;
            this.Close = close;
            this.High = high;
            this.Low = low;
            this.Volume = volume;

            this.Ticker = Ticker;
            this.Period = Period;
            computeProperties();
        }

        /// This method converts the object to a string format.
        public override string ToString()
        {
            string DateText;
            Period = Period.ToUpper();
            char p = Period[0];

            /// Determine the date format based on the first character of the Period string.
            if ((p == 'D') || (p == 'W') || (p == 'M'))
                DateText = Date.ToString("MM-dd-yyyy");
            else
                DateText = Date.ToString();

            string result = Ticker + "," + Period+ "," + DateText + "," + Open + "," + High + "," + Low + "," + Close + "," + Volume;

            return result;
        }

        /// computes the pattern
        private void computePatterns()
        {
            isBullish = Close > Open;
            isBearish = Open > Close;
            isNeutral = Open == Close;

            ///Tests if doji
            isDoji = dojiTest();
            isDragonflyDoji = dragonflyDoji();
            isNeutralDoji = neutralDojiTest();
            isGravestoneDoji = gravestoneDojiTest();


            /// tests if hammer
            isHammer = hammerTest();
            isBullishHammer = bullishHammerTest();
            isBearishHammer = bearishHammerTest();
            isInvertedHammer = invertedHammerTest();
            isBullishInvertedHammer = bullishInvertedHammerTest();
            isBearishInvertedHammer = bearishInvertedHammerTest();


            ///tests if its Marubozu
            isMarubozu = marubozuTest();
            isWhiteMarubozu = whiteMarubozuTest();
            isBlackMarubozu = blackMarubozuTest();





        }

        /// <summary>
        /// Computes candlestick patterns
        /// </summary>
        private void computeProperties()
        {
            range = High - Low;
            body = Math.Max(Open, Close) - Math.Min(Close, Open);
            topPrice = Math.Max(Open, Close);
            bottomPrice = Math.Min(Open, Close);
            UpperTail = High - topPrice;
            LowerTail = bottomPrice - Low;

            computePatterns();
        }


    }
}
