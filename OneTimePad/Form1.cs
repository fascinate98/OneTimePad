using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OneTimePad
{
    public partial class Form1 : Form
    {
        List<string> binaryList = new List<string>();
        List<string> randBinaryList = new List<string>();
        List<string> encryptionList = new List<string>();
        List<string> dyptkeyData = new List<string>();
        List<string> dyptencryptData = new List<string>();
        List<string> decryptionList = new List<string>();
        

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ResetEncryptListView();
            ResetDecryptListView();
        }

        private void button1_Click(object sender, EventArgs e) //encrypt
        {
            ResetEncryptListView();
            Encyption();
            UpdateKey();
            UpdateCrypto();
            UpdateEncryptListView();
        }
        private void button2_Click(object sender, EventArgs e) //decrypt
        {
            ResetDecryptListView();
            UpdateDecryptListView();
            Decryption();
        }

        private void Encyption()
        {
            binaryList = Encoder.Encoding(textBox1.Text);
            randBinaryList = Rand.GetRandomBinary(textBox1.Text.Length);
            encryptionList = Encrypt.Encryption(binaryList, randBinaryList);
        }
        private void UpdateKey()
        {
            foreach (string s in randBinaryList)
            {
                textBox2.Text += s;
                textBox5.Text += s;
            }
        }
        private void UpdateCrypto()
        {
            foreach (string s in encryptionList)
            {
                textBox3.Text += s;
                textBox4.Text += s;
            }
        }
        private void UpdateEncryptListView()
        {
            foreach (char s in textBox1.Text)
            {
                listView1.Items.Add(s.ToString());
            }
            for (int i = 0; i < binaryList.Count; i++)
            {
                listView1.Items[i].SubItems.Add(binaryList[i]);
            }
            for (int i = 0; i < randBinaryList.Count; i++)
            {
                listView1.Items[i].SubItems.Add(randBinaryList[i]);
            }
            for (int i = 0; i < encryptionList.Count; i++)
            {
                listView1.Items[i].SubItems.Add(encryptionList[i]);
            }
        }
        private void ResetEncryptListView()
        {
            listView1.View = View.Details;

            binaryList.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            listView1.Clear();
            ResetDecryptListView();
            listView1.Width = 350;

            listView1.Columns.Add("문자", 50, HorizontalAlignment.Center);
            listView1.Columns.Add("2진수", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("랜덤키", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("xor암호문", 100, HorizontalAlignment.Center);

        }



        private void ResetDecryptListView()
        {
            listView2.View = View.Details;

            listView2.Clear();
            listView2.Width = 350;

            listView2.Columns.Add("키", 100, HorizontalAlignment.Center);
            listView2.Columns.Add("암호문", 100, HorizontalAlignment.Center);
            listView2.Columns.Add("xor연산", 100, HorizontalAlignment.Center);
            listView2.Columns.Add("문자", 50, HorizontalAlignment.Center);

        }
        private void UpdateDecryptListView()
        {
            dyptkeyData  = stringConverter(textBox5.Text);
            dyptencryptData = stringConverter(textBox4.Text);
            for (int i = 0; i < dyptkeyData.Count; i++)
            {
                listView2.Items.Add(dyptkeyData[i]);
            }
            for (int i = 0; i < dyptencryptData.Count; i++)
            {
                listView2.Items[i].SubItems.Add(dyptencryptData[i]);
            }

        }
        private void Decryption()
        {
            decryptionList = Decrypt.Decryption(dyptencryptData, dyptkeyData);
            for (int i = 0; i < decryptionList.Count; i++)
            {
                listView2.Items[i].SubItems.Add(decryptionList[i]);
            }
            int j = 0;
            string str = "";
            foreach (char s in Decoder.Decoding(decryptionList))
            {
                listView2.Items[j].SubItems.Add(s.ToString());
                j++;
                str += s;
            }
            textBox6.Text = str;
        }

        private List<string> stringConverter(string str)
        {
            int startIdx = 0, endIdx = 0;
            List<string> result = new List<string>();

            for(int i = 0; i < (str.Length /9) + 1; i++)
            {
                if (str.Length < startIdx + 9)
                    endIdx = str.Length - startIdx;
                else
                    endIdx = str.Substring(startIdx, 9).LastIndexOf("");

                result.Add(str.Substring(startIdx, endIdx));

                startIdx += endIdx;
            }

            return result;
        }
    }
}
