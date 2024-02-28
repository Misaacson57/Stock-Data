using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_project
{
    public partial class Stock : Form
    {

        aCandlestickReader candlestickReader= null;
        List<aCandlestick> listOfCandleSticks = null;


        FileInfo[] Files = null;
        public static Stock instance;

        public Stock()
        {
            InitializeComponent();
            candlestickReader= new aCandlestickReader();
            
            ///grid.DataSource = listOfCandleSticks = new List<aCandleStick>(512);

            instance = this;
            string fileName = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            string filepath = fileName + "/Stock Data/";
            DirectoryInfo d = new DirectoryInfo(filepath);
            Files = d.GetFiles("*.csv");

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButtonDaily_CheckedChanged(object sender, EventArgs e)
        {
            string targetFilenamePattern = String.Empty;
            targetFilenamePattern = "Day";
            comboBox1.Items.Clear();
            foreach (FileInfo file in Files)
            {
                if ((file.Name).Contains(targetFilenamePattern))
                {
                    comboBox1.Items.Add(file.Name);
                }
            }
            Controls.Add(comboBox1);

        }
        /// populates combo box with day when radiobutton day(1) checked
        private void Ticker_Click(object sender, EventArgs e)
        {

            /// if statment to get day week or motnth dpending on radiobutton checked
            string targetFilenamePattern = String.Empty;

            if (radioButtonDaily.Checked)
            {
                targetFilenamePattern = "Day";
            }
            else if (radioButtonWeekly.Checked)
            {
                targetFilenamePattern = "Week";
            }
            else if (radioButtonMonthly.Checked)
            {
                targetFilenamePattern = "Month";
            }
            else
            {
                targetFilenamePattern = "Day";
            }


            ///connecting Stock to chart

            Chart formgraph = new Chart();
            /// Show the chart form
            Form1 form = new Form1();

            listOfCandleSticks = candlestickReader.readStock(comboBox1.Text, dateTimePicker1.Value, dateTimePicker2.Value);
            formgraph.StockChart.DataSource = listOfCandleSticks;
            form.dataGridView1.DataSource = listOfCandleSticks;
            formgraph.Show();

            form.Show();
        }

        /// This method is triggered when the "Weekly" radio button is checked
        /// It sets the target filename pattern to "Week", clears the items in the ComboBox,
        /// iterates through each FileInfo object in the Files collection and adds the file name
        /// to the ComboBox if it contains the target filename pattern "Week"
        /// Finally, it adds the ComboBox to the Controls collection
        private void radioButtonWeekly_CheckedChanged(object sender, EventArgs e)
        {
            string targetFilenamePattern = String.Empty;
            targetFilenamePattern = "Week";
            comboBox1.Items.Clear();
            foreach (FileInfo file in Files)
            {
                if ((file.Name).Contains(targetFilenamePattern))
                {
                    comboBox1.Items.Add(file.Name);
                }
            }
            Controls.Add(comboBox1);
        }

        /// This method is triggered when the "Monthly" radio button is checked
        /// It sets the target filename pattern to "Month", clears the items in the ComboBox,
        /// iterates through each FileInfo object in the Files collection and adds the file name
        /// to the ComboBox if it contains the target filename pattern "Month"
        /// Finally, it adds the ComboBox to the Controls collection
        private void radioButtonMonthly_CheckedChanged(object sender, EventArgs e)
        {
            string targetFilenamePattern = String.Empty;
            targetFilenamePattern = "Month";
            comboBox1.Items.Clear();
            foreach (FileInfo file in Files)
            {
                if ((file.Name).Contains(targetFilenamePattern))
                {
                    comboBox1.Items.Add(file.Name);
                }
            }
            Controls.Add(comboBox1);
        }
    }
}
