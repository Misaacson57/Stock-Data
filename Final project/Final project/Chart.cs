using Microsoft.CSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Final_project
{
    public partial class Chart : Form
    {
        List<aCandlestick> candlesticks= new List<aCandlestick>();
        public Chart()
        {
            InitializeComponent();
            InitializeRecognizers();


            StockChart.Series["OHLC"].XValueMember = "Date";///sets the values on the x-axis to the date type
            StockChart.Series["OHLC"].YValuesPerPoint = 4;///sets the amount of variables on the y-axis from its inital 1 to 4
            StockChart.Series["OHLC"].YValueMembers = "High,Low,Open,Close";///defines what the name of the variables the y-axis should be looking for
            StockChart.ChartAreas["OHLC"].AxisX.MajorGrid.LineWidth = 0;///determines the line width for the x-axis on the chart
            StockChart.ChartAreas["OHLC"].AxisY.MajorGrid.LineWidth = 0;///determines the line width for the y-axis on the chart

            //chartDoji.Series["OHLC"]["OpenCLoseStyle"] = "Triangle";
            //chartDoji.Series["OHLC"]["ShowOpenCLose"] = "Both";
            StockChart.Series["OHLC"].CustomProperties = "PriceUpColor=Green,PriceDownColor=Red";///this sets the color for the up and down candlesticks to green and red respectively


            StockChart.DataBind();///this binds the candlestick reader to the doji chart so that the data can be displayed properly

        }
        
        private void Chart_Load(object sender, EventArgs e)
        {

        }


        /// This method updates the chart's y-axis maximum and minimum values based on the data source.
        private void upDateChart()
        {
            var dataSource = StockChart.DataSource as List<aCandlestick>;

            if (dataSource != null)
            {

                candlesticks = dataSource;

                /// Calculate the maximum and minimum y-axis values and set a padding for spacing.
                double maxY = candlesticks.Max(cs => cs.High);
                double minY = candlesticks.Min(cs => cs.Low)    ;
                double padding = .10 * (maxY - minY);

                /// Update the chart's y-axis maximum and minimum values
                StockChart.ChartAreas["OHLC"].AxisY.Maximum = maxY + padding;
                StockChart.ChartAreas["OHLC"].AxisY.Minimum= minY + padding;

            }
        }




        List<aRecognizer> recognizers = new List<aRecognizer>(32);

        /// This method initializes the list of recognizers with different pattern
        private List<aRecognizer> InitializeRecognizers()
        {
            aRecognizer recognizer = null;

            recognizer = new Recognizer_Bullish();
            recognizers.Add(recognizer);

            recognizer = new Recognizer_Bearish();
            recognizers.Add(recognizer);

            recognizer = new Recognizer_Neutral();
            recognizers.Add(recognizer);

            recognizer = new Recognizer_Doji();
            recognizers.Add(recognizer);

            recognizer = new Recognizer_DragonFly();
            recognizers.Add(recognizer);

            recognizer = new Recognizer_NeutralDoji();
            recognizers.Add(recognizer);

            recognizer = new Recognizer_LongLeggedDoji();
            recognizers.Add(recognizer);

            recognizer = new Recognizer_Hammer();
            recognizers.Add(recognizer);

            recognizer = new Recognizer_BullishHammer();
            recognizers.Add(recognizer);

            recognizer = new Recognizer_BearishHammer();
            recognizers.Add(recognizer);

            recognizer = new Recognizer_GravestoneDoji();
            recognizers.Add(recognizer);

            recognizer = new Recognizer_invertedHammer();
            recognizers.Add(recognizer);

            recognizer = new Recognizer_bearishInvertedHammer();
            recognizers.Add(recognizer);

            recognizer = new Recognizer_bullishInvertedHammer();
            recognizers.Add(recognizer);



            recognizer = new Recognizer_Marubozu();
            recognizers.Add(recognizer);

            recognizer = new Recognizer_whiteMarubozu();
            recognizers.Add(recognizer);

            recognizer = new Recognizer_blackMarubozu();
            recognizers.Add(recognizer);

            /// Clear the combo box and add the name of each recognizer pattern to it.
            comboBox_Pattern.Items.Clear();
            foreach (aRecognizer r in recognizers)
            {
                comboBox_Pattern.Items.Add(r.patternName);
            }
            comboBox_Pattern.Enabled = true;

            /// Enable the combo box and return the list of recognizers
            return recognizers;

        }
        /*
        private void comboBox_Pattern_SelectedIndexChanged(object sender, EventArgs e)
        {
            aRecognizer recognizer = recognizers[comboBox_Pattern.SelectedIndex];
            recognizer.recognize(candlesticks);
        }
        
         */

        private void HighlightDoji()
        {


            foreach (DataPoint dp in StockChart.Series["OHLC"].Points)
            {
                if (IsDoji(dp.YValues[0], dp.YValues[1], dp.YValues[2], dp.YValues[3]))
                {
                    var rectangleAnnotation = new RectangleAnnotation();
                    rectangleAnnotation.Height = 50;
                    rectangleAnnotation.Width = 7;
                    rectangleAnnotation.LineWidth = 1;
                    rectangleAnnotation.LineDashStyle = ChartDashStyle.Solid;
                    rectangleAnnotation.AnchorDataPoint = dp;
                    rectangleAnnotation.BackColor = Color.Transparent;
                    double x = dp.XValue;

                    rectangleAnnotation.Name = $"Annotation{x}";
                    rectangleAnnotation.Text = $"Common Doji";
                    rectangleAnnotation.IsSizeAlwaysRelative = false;

                    StockChart.Annotations.Add(rectangleAnnotation);
                }
            }


        }

        private bool IsDoji(double low, double high, double open, double close)
        {
            double bodySize = Math.Abs(close - open);
            double range = high - low;
            double dojirange = range * 0.15;

            if (bodySize < dojirange)
            {
                return true;
            }

            return false;
        }
        /// Long LeggedDoji method that highlights any Long Legged Doji by making a new series called "Long Legged Doji" and reads each datapoint to see if they fit the creteria
        private void HighlightLongLeggedDoji()
        {
            var LongdojiSeries = new Series("LOng Legged Doji");
            LongdojiSeries.ChartType = SeriesChartType.Point;
            LongdojiSeries.Color = Color.Indigo;
            LongdojiSeries.MarkerSize = 7;

            foreach (DataPoint dp in StockChart.Series["OHLC"].Points)
            {
                if (IsLongLeggedDoji(dp.YValues[0], dp.YValues[1], dp.YValues[2], dp.YValues[3]))
                {
                    var rectangleAnnotation = new RectangleAnnotation();
                    rectangleAnnotation.Height = 150;
                    rectangleAnnotation.Width = 7;
                    rectangleAnnotation.LineWidth = 1;
                    rectangleAnnotation.LineDashStyle = ChartDashStyle.Solid;
                    rectangleAnnotation.AnchorDataPoint = dp;
                    rectangleAnnotation.BackColor = Color.Transparent;
                    double x = dp.XValue;

                    rectangleAnnotation.Name = $"Annotation{x}";
                    rectangleAnnotation.Text = $"Long Legged Doji";
                    rectangleAnnotation.IsSizeAlwaysRelative = false;

                    StockChart.Annotations.Add(rectangleAnnotation);
                }
            }


        }

        private bool IsLongLeggedDoji(double low, double high, double open, double close)
        {
            double bodySize = Math.Abs(close - open);
            double range = high - low;

            double islongleg = range * 0.07;
            if (bodySize < islongleg)
            {
                return true;
            }

            return false;
        }

        /// Dragonfly Doji method that highlights any Dragonfly Doji by making a new series called "Dragonfly Doji" and reads each datapoint to see if they fit the creteria

        private void HighlightDragonflyDoji()
        {
            var DragondojiSeries = new Series("Dragonfly Doji");
            DragondojiSeries.ChartType = SeriesChartType.Point;
            DragondojiSeries.Color = Color.IndianRed;
            DragondojiSeries.MarkerSize = 7;

            foreach (DataPoint dp in StockChart.Series["OHLC"].Points)
            {
                if (IsDragonDoji(dp.YValues[0], dp.YValues[1], dp.YValues[2], dp.YValues[3]))
                {
                    var rectangleAnnotation = new RectangleAnnotation();
                    rectangleAnnotation.Height = 150;
                    rectangleAnnotation.Width = 7;
                    rectangleAnnotation.LineWidth = 1;
                    rectangleAnnotation.LineDashStyle = ChartDashStyle.Solid;
                    rectangleAnnotation.AnchorDataPoint = dp;
                    rectangleAnnotation.BackColor = Color.Transparent;
                    double x = dp.XValue;

                    rectangleAnnotation.Name = $"Annotation{x}";
                    rectangleAnnotation.Text = $"Dragonfly Doji";
                    rectangleAnnotation.IsSizeAlwaysRelative = false;

                    StockChart.Annotations.Add(rectangleAnnotation);
                }
            }


        }

        private bool IsDragonDoji(double low, double high, double open, double close)
        {
            double bodySize = Math.Abs(close - open);
            double range = high - low;
            double dojirange = range * 0.15;
            double distanceToTop = high - Math.Max(open, close);
            if (bodySize < dojirange && distanceToTop < range * 0.15)
            {
                return true;
            }

            return false;
        }
        /// Gravestone Doji method that highlights any Gravestone Doji by making a new series called "Gravestone Doji" and reads each datapoint to see if they fit the creteria
        private void HighlightGravestoneDoji()
        {
            var DragondojiSeries = new Series("Gravestone Doji");
            DragondojiSeries.ChartType = SeriesChartType.Point;
            DragondojiSeries.Color = Color.Yellow;
            DragondojiSeries.MarkerSize = 7;

            foreach (DataPoint dp in StockChart.Series["OHLC"].Points)
            {
                if (IsGravestoneDoji(dp.YValues[0], dp.YValues[1], dp.YValues[2], dp.YValues[3]))
                {
                    var rectangleAnnotation = new RectangleAnnotation();
                    rectangleAnnotation.Height = 150;
                    rectangleAnnotation.Width = 7;
                    rectangleAnnotation.LineWidth = 1;
                    rectangleAnnotation.LineDashStyle = ChartDashStyle.Solid;
                    rectangleAnnotation.AnchorDataPoint = dp;
                    rectangleAnnotation.BackColor = Color.Transparent;
                    double x = dp.XValue;

                    rectangleAnnotation.Name = $"Annotation{x}";
                    rectangleAnnotation.Text = $"Gravestone Doji";
                    rectangleAnnotation.IsSizeAlwaysRelative = false;

                    StockChart.Annotations.Add(rectangleAnnotation);
                }
            }


        }

        private bool IsGravestoneDoji(double low, double high, double open, double close)
        {
            double bodySize = Math.Abs(close - open);
            double range = high - low;
            double dojirange = range * 0.15;
            double distanceToBottom = Math.Min(open, close) - low;
            if (bodySize < dojirange && distanceToBottom < range * 0.15)
            {
                return true;
            }

            return false;
        }

        ///Hammer method that highlights any Hammer by making a new series called "Hammer" and reads each datapoint to see if they fit the creteria
        private void HighlightHammer()
        {
            var hammerSeries = new Series("Hammer");
            hammerSeries.ChartType = SeriesChartType.Point;
            hammerSeries.Color = Color.Black;
            hammerSeries.MarkerSize = 7;

            foreach (DataPoint dp in StockChart.Series["OHLC"].Points)
            {
                if (IsHammer(dp.YValues[0], dp.YValues[1], dp.YValues[2], dp.YValues[3]))
                {
                    var rectangleAnnotation = new RectangleAnnotation();
                    rectangleAnnotation.Height = 150;
                    rectangleAnnotation.Width = 7;
                    rectangleAnnotation.LineWidth = 1;
                    rectangleAnnotation.LineDashStyle = ChartDashStyle.Solid;
                    rectangleAnnotation.AnchorDataPoint = dp;
                    rectangleAnnotation.BackColor = Color.Transparent;
                    double x = dp.XValue;

                    rectangleAnnotation.Name = $"Annotation{x}";
                    rectangleAnnotation.Text = $"Hammer";
                    rectangleAnnotation.IsSizeAlwaysRelative = false;

                    StockChart.Annotations.Add(rectangleAnnotation);
                }
            }


        }

        private bool IsHammer(double low, double high, double open, double close)
        {
            double bodySize = Math.Abs(close - open);
            double range = high - low;
            double distanceToTop = high - Math.Max(open, close);
            bool IsBullish = close > open;

            if (IsBullish == true && distanceToTop < range * 0.1)
            {
                return true;
            }

            return false;
        }
        /// Inverted Hammer method that highlights any Inverted Hammer by making a new series called "Inverted Hammer" and reads each datapoint to see if they fit the creteria
        private void HighlightInvertedHammer()
        {

            foreach (DataPoint dp in StockChart.Series["OHLC"].Points)
            {
                if (IsInvertedHammer(dp.YValues[0], dp.YValues[1], dp.YValues[2], dp.YValues[3]))
                {
                    var rectangleAnnotation = new RectangleAnnotation();
                    rectangleAnnotation.Height = 150;
                    rectangleAnnotation.Width = 7;
                    rectangleAnnotation.LineWidth = 1;
                    rectangleAnnotation.LineDashStyle = ChartDashStyle.Solid;
                    rectangleAnnotation.AnchorDataPoint = dp;
                    rectangleAnnotation.BackColor = Color.Transparent;
                    double x = dp.XValue;

                    rectangleAnnotation.Name = $"Annotation{x}";
                    rectangleAnnotation.Text = $"Inverted Hammer";
                    rectangleAnnotation.IsSizeAlwaysRelative = false;

                    StockChart.Annotations.Add(rectangleAnnotation);
                }
            }


        }

        private bool IsInvertedHammer(double low, double high, double open, double close)
        {
            double bodySize = Math.Abs(close - open);
            double range = high - low;
            double distanceToBottom = Math.Min(open, close) - low;
            bool IsBullish = close > open;

            if (IsBullish == true && distanceToBottom < range * 0.1)
            {
                return true;
            }

            return false;
        }
        /// Shooting Star method that highlights any Shooting Star by making a new series called "Shooting Star" and reads each datapoint to see if they fit the creteria
        private void HighlightShootingStar()
        {

            foreach (DataPoint dp in StockChart.Series["OHLC"].Points)
            {
                if (IsShootingStar(dp.YValues[0], dp.YValues[1], dp.YValues[2], dp.YValues[3]))
                {
                    var rectangleAnnotation = new RectangleAnnotation();
                    rectangleAnnotation.Height = 150;
                    rectangleAnnotation.Width = 7;
                    rectangleAnnotation.LineWidth = 1;
                    rectangleAnnotation.LineDashStyle = ChartDashStyle.Solid;
                    rectangleAnnotation.AnchorDataPoint = dp;
                    rectangleAnnotation.BackColor = Color.Transparent;
                    double x = dp.XValue;

                    rectangleAnnotation.Name = $"Annotation{x}";
                    rectangleAnnotation.Text = $"Shooting Star";
                    rectangleAnnotation.IsSizeAlwaysRelative = false;

                    StockChart.Annotations.Add(rectangleAnnotation);
                }
            }


        }

        private bool IsShootingStar(double low, double high, double open, double close)
        {
            double bodySize = Math.Abs(close - open);
            double range = high - low;
            double distanceToBottom = Math.Min(open, close) - low;
            bool IsBearish = close > open;

            if (IsBearish == true && distanceToBottom < range * 0.1)
            {
                return true;
            }

            return false;
        }
        /// Hangman method that highlights any Hangman by making a new series called "Hangman" and reads each datapoint to see if they fit the creteria
        private void HighlightHangman()
        {

            foreach (DataPoint dp in StockChart.Series["OHLC"].Points)
            {
                if (IsHangman(dp.YValues[0], dp.YValues[1], dp.YValues[2], dp.YValues[3]))
                {
                    var rectangleAnnotation = new RectangleAnnotation();
                    rectangleAnnotation.Height = 150;
                    rectangleAnnotation.Width = 7;
                    rectangleAnnotation.LineWidth = 1;
                    rectangleAnnotation.LineDashStyle = ChartDashStyle.Solid;
                    rectangleAnnotation.AnchorDataPoint = dp;
                    rectangleAnnotation.BackColor = Color.Transparent;
                    double x = dp.XValue;

                    rectangleAnnotation.Name = $"Annotation{x}";
                    rectangleAnnotation.Text = $"Hangman";
                    rectangleAnnotation.IsSizeAlwaysRelative = false;

                    StockChart.Annotations.Add(rectangleAnnotation);
                }
            }


        }

        private bool IsHangman(double low, double high, double open, double close)
        {
            double bodySize = Math.Abs(close - open);
            double range = high - low;
            double distanceToTop = high - Math.Max(open, close);
            bool IsBearish = close < open;

            if (IsBearish == true && distanceToTop < range * 0.1)
            {
                return true;
            }

            return false;
        }
        /// White Marubozu method that highlights any White Marubozu by making a new series called "White Marubozu" and reads each datapoint to see if they fit the creteria
        private void HighlightWhiteMarubozu()
        {


            foreach (DataPoint dp in StockChart.Series["OHLC"].Points)
            {
                if (IsWhiteMarubozu(dp.YValues[0], dp.YValues[1], dp.YValues[2], dp.YValues[3]))
                {
                    var rectangleAnnotation = new RectangleAnnotation();
                    rectangleAnnotation.Height = 150;
                    rectangleAnnotation.Width = 7;
                    rectangleAnnotation.LineWidth = 1;
                    rectangleAnnotation.LineDashStyle = ChartDashStyle.Solid;
                    rectangleAnnotation.AnchorDataPoint = dp;
                    rectangleAnnotation.BackColor = Color.Transparent;
                    double x = dp.XValue;

                    rectangleAnnotation.Name = $"Annotation{x}";
                    rectangleAnnotation.Text = $"White Marubozu";
                    rectangleAnnotation.IsSizeAlwaysRelative = false;

                    StockChart.Annotations.Add(rectangleAnnotation);
                }
            }
        }

        private bool IsWhiteMarubozu(double low, double high, double open, double close)
        {
            double bodySize = Math.Abs(close - open);
            double range = high - low;
            double distanceToTop = high - Math.Max(open, close);
            bool IsBullish = close > open;

            if (IsBullish == true && bodySize > range * 0.80)
            {
                return true;
            }

            return false;
        }

        /// Black Marubozu method that highlights any Black Marubozu by making a new series called "Black Marubozu" and reads each datapoint to see if they fit the creteria
        private void HighlightBlackMarubozu()
        {


            foreach (DataPoint dp in StockChart.Series["OHLC"].Points)
            {
                if (IsBlackMarubozu(dp.YValues[0], dp.YValues[1], dp.YValues[2], dp.YValues[3]))
                { 
                    var rectangleAnnotation = new RectangleAnnotation();
                    rectangleAnnotation.Height = 150;
                    rectangleAnnotation.Width = 7;
                    rectangleAnnotation.LineWidth = 1;
                    rectangleAnnotation.LineDashStyle = ChartDashStyle.Solid;
                    rectangleAnnotation.AnchorDataPoint = dp;
                    rectangleAnnotation.BackColor = Color.Transparent;
                    double x = dp.XValue;

                    rectangleAnnotation.Name = $"Annotation{x}";
                    rectangleAnnotation.Text = $"Black Marubozu";
                    rectangleAnnotation.IsSizeAlwaysRelative = false;

                    StockChart.Annotations.Add(rectangleAnnotation);
                }
            }
        }

        private bool IsBlackMarubozu(double low, double high, double open, double close)
        {
            double bodySize = Math.Abs(close - open);
            double range = high - low;
            bool IsBearish = close < open;

            if (IsBearish == true && bodySize > range * 0.80)
            {
                return true;
            }

            return false;


        }

        private void StockChart_Click(object sender, EventArgs e)
        {

        }

        private void comboBox_Pattern_SelectedIndexChanged(object sender, EventArgs e)
        {
            upDateChart();

            /// Get the selected pattern from the list of recognizers
            aRecognizer recognizer = recognizers[comboBox_Pattern.SelectedIndex];

            /// Use the selected recognizer to identify any matching patterns in the candlestick data.
            List<int> retcon = recognizer.recognize(candlesticks);

            foreach (int i in retcon)
            {
                RectangleAnnotation ra = new RectangleAnnotation();
                ra.Text = recognizer.patternName;
                ra.AnchorDataPoint = StockChart.Series["OHLC"].Points[i];
                StockChart.Annotations.Add(ra);
            }
        }
    }
}
