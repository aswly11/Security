using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    public class RailFence : ICryptographicTechnique<string, int>
    {
        public int Analyse(string plainText, string cipherText)
        {

            int i = 2;
            while(true)
            {
                string ciphr = Encrypt(plainText, i);
                if (cipherText.ToLower().Equals(ciphr))
                    break;
                i++;
            }

            return i;
          
        }

        public string Decrypt(string cipherText, int key)
        {
            int rows = key;
            decimal cols = Math.Ceiling((decimal)cipherText.Length / key);
            int col = int.Parse(cols.ToString());
            char[,] text = new char[rows, col];
            int counter = 0;
            for (int i = 0; i < rows; i++)
            {

                for (int j = 0; j < col; j++)
                {
                    if (counter >= cipherText.Length)
                        text[i, j] = ' ';
                    else
                        text[i, j] = cipherText[counter];
                    counter++;
                }

            }
            string plaintext = "";
            for (int j = 0; j < col; j++)
            {
                for (int i = 0; i < rows; i++)
                {
                    if(text[i,j]!=' ')
                        plaintext += text[i, j];


                }

            }
            return plaintext;
        }

        public string Encrypt(string plainText, int key)
        {
            List<string> lst = new List<string>();
            decimal f = plainText.Length, f2 = key;


            float col = plainText.Length / key;
            float rem = plainText.Length - col * key;
            if (rem > 0)
                col = col + 1;
            else
                col = (int)col;
            int idx = 0;
            string str = "";
            for (int i = 1; i <= col; i++)
            {
                for (int j = 0; j < key; j++)
                {
                    if (idx < plainText.Length)
                        str += plainText[idx];
                    idx++;
                }
                lst.Add(str);
                str = "";
            }
            //foreach (string l in lst)
            //{

            //        Console.WriteLine( l + "\t");
            //}
            int k = 0;
            string s = "";

            for (int i = 0; i < key; i++)
            {
                foreach (string l in lst)
                {
                    if (l.Length > k)
                        s += l[k];
                }
                k++;
            }
            // Console.WriteLine(s);

            return s;
        }
    }
}
