using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace ProjectProgramTest
{
    public partial class Form1 : Form
    {
        
  
        public Form1()
        {
            InitializeComponent();
        }
        class RootObject
        {
            [JsonProperty("TeacherName")]
            public string TeacherName { get; set; }
            [JsonProperty("StudentName")]
            public string StudentName { get; set; }
            [JsonProperty("Group")]
            public string Group { get; set; }
            [JsonProperty("PercentAnsw")]
            public string PercentAnsw { get; set; }
            [JsonProperty("TopicQuestion")]
            public string TopicQuestion { get; set; }
            [JsonProperty("Questions")]
            List<Questions> Questions;
           
        }
      

            class Questions
        {
            [JsonProperty("Type")]
            public string QType { get; set; }
            [JsonProperty("TypeAnsw")]
            public int QTypeAnsw { get; set; }
            [JsonProperty("Topic")]
            public string QTopic { get; set; }
            [JsonProperty("Subject")]
            public string QSubject { get; set; }
            [JsonProperty("isRight")]
            public bool QAisRight { get; set; }
            [JsonProperty("Answers")]
            List<Answers> Answers;
        
        }

        class Answers
        {
            [JsonProperty("Type")]
            public string QAType { get; set; }
            [JsonProperty("Value")]
            public string QAValue { get; set; }
            [JsonProperty("isRight")]
            public bool QAisRight { get; set; }
            [JsonProperty("isAnsw")]
            public bool QAisAnsw { get; set; }
        }

        private async  void button1_Click(object sender, System.EventArgs e)
        {

 
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            /*Возвращает или задает текущую строку фильтра имен файлов, которая определяет варианты, 
            которые появляются в окне "сохранить как тип файла" или "файлы типа" в диалоговом окне. 
            */
            openFileDialog1.FilterIndex = 2; //Возвращает или задает индекс фильтра, выбранного в настоящий момент в диалоговом окне файла.
            openFileDialog1.RestoreDirectory = true;

           

            if (openFileDialog1.ShowDialog() == DialogResult.OK)//Comment
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (StreamReader sr = new StreamReader(myStream))
                        {
                            
                            string L = await sr.ReadToEndAsync();
                            RootObject obj = JsonConvert.DeserializeObject<RootObject>(L);
                            textBox1.Text = L;
                            Console.WriteLine(obj.TeacherName);
                            
                            // Insert code to read the stream here.
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        

    }
}
}
