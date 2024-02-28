using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_project
{
    internal class aCandlestickReader
    {
        const string dataFolder = "Stock Data";
        /// <summary>
        /// declare array 
        /// </summary>
        /// 

        public List<aCandlestick> listOfCandlesticks = null;

        /// CONSTRUCTOR initlizes listofcandlesitcks
        /// </summary>
        public aCandlestickReader()
        {

            listOfCandlesticks = new List<aCandlestick>(256);
        }

        public string Ticker { get; private set; }

        /// <summary>
        /// constructor reads listofcandlestick
        /// </summary>
        /// <param name="csvFilename"></param>
        /// <param name="startdate"></param>
        /// <param name="enddate"></param>
        /// <returns></returns>
        public List<aCandlestick> readlistOfCandlesticks(string csvFilename, DateTime startdate, DateTime enddate)

        {
            char[] seperators = new char[] { '/', ',', '"', '-' };
            /// get all lines as sting array by readiNg all lines
            String[] lines = System.IO.File.ReadAllLines(csvFilename);




            /// skip header.make sure its valid
            String header = lines[0];
            /// use first line to make sure file is proper filed
            if (header == "Date,Open,High,Low,Close,Adj Close,Volume")
            { /// create list of candle sicks with enough capacity 
                listOfCandlesticks = new List<aCandlestick>(lines.Length - 1);
                for (int l = 1; l < lines.Length; l++)
                { ///get lth line
                    String line = lines[l].Trim();
                    /// split based on '-' commas
                    string[] subString = line.Split(seperators, StringSplitOptions.RemoveEmptyEntries);
                    /// now gather all parts of date string. year, month, and day

                    int month = int.Parse(subString[0]);
                    int day = int.Parse(subString[1]);
                    int year = int.Parse(subString[2]);
                    /// and build a date object for 4 parameters
                    DateTime date = new DateTime(year, month, day);
                    if (date.CompareTo(startdate) >= 0 && date.CompareTo(enddate) <= 0)
                    {
                        ///now just get other parts of the line. Open, High,Low, CLose, and volume
                        double Open = double.Parse(subString[3]);
                        double High = double.Parse(subString[4]);
                        double low = double.Parse(subString[5]);
                        double close = double.Parse(subString[6]);
                        String Ticker = subString[7];
                        /// long adj = long.Parse(subString[7]);
                        long volume = long.Parse(subString[8]);
                        Open = Math.Round(Open, 2);
                        High = Math.Round(High, 2);
                        low = Math.Round(low, 2);
                        close = Math.Round(close, 2);
                        /// volume = Math.Round(adj, 2);


                        ///create new candlestick 
                        aCandlestick candlestick = new aCandlestick(date, Open, High, low, close, volume, Ticker);
                        /// add newly created candlestick to listOfcandlesticks
                        listOfCandlesticks.Add(candlestick);



                    }

                }
            }

            return listOfCandlesticks;
        }

        public List<aCandlestick> readStock(String ticker, DateTime startDate, DateTime endDate)

        /// create filename for ticker by concatenating the folder ticker and period 
        {
            String csvFilename = dataFolder + @"\" + ticker;
            /// read candlestick and return listofcandlestick memeber 
            listOfCandlesticks = readlistOfCandlesticks(csvFilename, startDate, endDate);
            return listOfCandlesticks;

        }

    }
}
