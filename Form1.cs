using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace Collect_Data_Web_To_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Download or Crawl a Webpage
            List<string> ranks = new List<string>();
            List<string> scores = new List<string>();
            WebClient webPage = new WebClient();

            string sourceCodeHtml = webPage.DownloadString("https://open.kattis.com/users/ivan-petrov");
            MatchCollection codeLines = Regex.Matches(sourceCodeHtml, @"Score\s*(.+?)\s*</table>", RegexOptions.Singleline);

            foreach (Match line in codeLines)
            {
                //if (line.Groups[1].Value != "")
                //{
                string values = line.Groups[1].Value;
                values = values.Replace("</span></td></tr>", "").Replace("<tr><td>", "").Replace("</td> <td", "").Replace("</td></tr>", "").Replace(" ", "");
                string[] splitValues = values.Split('>');
                ranks.Add(splitValues[0]);
                scores.Add(splitValues[1]);

                //}
            }

            listBox1.DataSource = ranks;
            listBox2.DataSource = scores;

            //Console.WriteLine(score);
            //Console.WriteLine(sourceCodeHtml);
        }
    }
}
