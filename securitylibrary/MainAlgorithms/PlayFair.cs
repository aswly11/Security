using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    public class PlayFair : ICryptographic_Technique<string, string>
    {

  

        string Dnc(string plain,int c1indx,int c2indx, char c1, char c2, ref List<List<char>> matrix)
        {
            int ind_x = 0, ind_y = 0, ind_x2 = 0, ind_y2 = 0;
            string cipher = "";

            for (int j = 0; j < 5; j++)
            {
                for (int k = 0; k < 5; k++)
                {
                    if (c1 == matrix[j][k])
                    { ind_x = j; ind_y = k; }
                    if (c2 == matrix[j][k])
                    { ind_x2 = j; ind_y2 = k; }
                }
            }
            if (ind_y == ind_y2)
            {

                if ((ind_x - 1) % 5 < 0)
                {
                    ind_x = ((ind_x - 1) % 5) + 5;
                    cipher += matrix[ind_x][ind_y];


                }
                else
                {
                    cipher += matrix[(ind_x - 1) % 5][ind_y];

                }
                if ((ind_x2 - 1) % 5 < 0)
                {
                    ind_x2 = ((ind_x2 - 1) % 5) + 5;
                    cipher += matrix[ind_x2][ind_y2];

                }
                else
                {
                    cipher += matrix[(ind_x2 - 1) % 5][ind_y2];

                }

            }
            else if (ind_x == ind_x2)
            {

                if ((ind_y - 1) % 5 < 0)
                {
                    ind_y = ((ind_y - 1) % 5) + 5;
                    cipher += matrix[ind_x][ind_y];


                }
                else
                {
                    cipher += matrix[ind_x ][(ind_y - 1) % 5];

                }
                if ((ind_y2 - 1) % 5 < 0)
                {
                    ind_y2 = ((ind_y2 - 1) % 5) + 5;
                    cipher += matrix[ind_x2][ind_y2];

                }
                else
                {
                    cipher += matrix[ind_x2][(ind_y2 - 1) % 5];

                }
       
              
            }
            else
            {
                cipher += matrix[ind_x][ind_y2];
                cipher += matrix[ind_x2][ind_y];
            }
      
            return cipher;
        }
        public string Decrypt(string cipherText, string key)
        {
            List<List<char>> matrix = new List<List<char>>();
            string char_alph = "ABCDEFGHIKLMNOPQRSTUVWXYZ";
            List<char> prelist = new List<char>();
            key = key.ToUpper();
            cipherText = cipherText.ToUpper();
            for (int i = 0; i < key.Length; i++)
            {
                if (!prelist.Contains(key[i]))
                    prelist.Add(key[i]);
                if (!prelist.Contains(key[i]) && key[i] == 'J')
                    prelist.Add('I');

            }

            for (int i = 0; i < char_alph.Length; i++)
            {
                if (!prelist.Contains(char_alph[i]))
                    prelist.Add(char_alph[i]);
            }

            int count = 0;
            for (int i = 0; i < 5; i++)
            {
                List<char> l = new List<char>();
                for (int j = 0; j < 5; j++)
                {
                    l.Add(prelist[count++]);
                }
                matrix.Add(l);
            }
           // string ciphertext = cipherText.Replace('J', 'I');
           // ciphertext = cipherText.Replace( "X","");


       
            // new_plain += plain[plain.Length - 1];

            // if (new_plain.Length % 2 != 0) new_plain += 'X';
            string cipher = "";
            for (int i = 0; i < cipherText.Length - 1; i += 2)
            {


                cipher += Dnc(cipherText,i,i+1, cipherText[i], cipherText[i + 1],ref matrix);

            }
            cipher = cipher.ToLower();
            string s = "";
            for (int i = 0; i < cipher.Length - 1; i+= 2)
            {
                if ( i + 2 < cipher.Length - 1)
                {
                    if (cipher[i+1] == 'x' && cipher[i] == cipher[i + 2])
                    {
                        s += cipher[i].ToString();
                    }
                    else
                    {
                        s += cipher[i].ToString()+ cipher[i+1].ToString();
                    }
                }
                else
                {
                    if (cipher[i + 1] == 'x')
                    {
                        s += cipher[i].ToString();

                    }
                    else
                    {
                        s += cipher[i].ToString() + cipher[i + 1].ToString();
                    }
                }

            }
           
     
            return s;

        }

        string Enc(string plain, char c1, char c2, ref List<List<char>> matrix)
        {
            int ind_x = 0, ind_y = 0, ind_x2 = 0, ind_y2 = 0;
            string cipher = "";

            for (int j = 0; j < 5; j++)
            {
                for (int k = 0; k < 5; k++)
                {
                    if (c1 == matrix[j][k])
                    { ind_x = j; ind_y = k; }
                    if (c2 == matrix[j][k])
                    { ind_x2 = j; ind_y2 = k; }
                }
            }
            if (ind_y == ind_y2)
            {
                cipher += matrix[(ind_x + 1) % 5][ind_y];
                cipher += matrix[(ind_x2 + 1) % 5][ind_y2];
            }
            else if (ind_x == ind_x2)
            {
                cipher += matrix[ind_x][(ind_y + 1) % 5];
                cipher += matrix[ind_x2][(ind_y2 + 1) % 5];
            }
            else
            {
                cipher += matrix[ind_x][ind_y2];
                cipher += matrix[ind_x2][ind_y];
            }
            return cipher;
        }
        public string Encrypt(string plainText, string key)
        {
            List<List<char>> matrix = new List<List<char>>();


            string char_alph = "ABCDEFGHIKLMNOPQRSTUVWXYZ";
            List<char> prelist = new List<char>();
            key = key.ToUpper();
            plainText = plainText.ToUpper();
            for (int i = 0; i < key.Length; i++)
            {
                if (!prelist.Contains(key[i]))
                    prelist.Add(key[i]);
                if (!prelist.Contains(key[i]) && key[i] == 'J')
                    prelist.Add('I');

            }

            for (int i = 0; i < char_alph.Length; i++)
            {
                if (!prelist.Contains(char_alph[i]))
                    prelist.Add(char_alph[i]);
            }

            int count = 0;
            for (int i = 0; i < 5; i++)
            {
                List<char> l = new List<char>();
                for (int j = 0; j < 5; j++)
                {
                    l.Add(prelist[count++]);
                }
                matrix.Add(l);
            }
            /*
            for (int i = 0; i < 5; i++)
            {
                List<char> l = new List<char>();
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(matrix[i][j] + " ");  
                }
                Console.WriteLine("\n");
            }
            */
            string plain = plainText.Replace('J', 'I');
            plain = plainText.Replace('\0', 'X');


            string new_plain = "";
            for (int i = 0; i <= plain.Length - 1; i+=2)
            {
                if(i+1 == plain.Length)
                {
                    new_plain += plain[i];
                    new_plain += 'X';
                    break;

                }
                if (plain[i] == plain[i + 1])
                {
                    new_plain += plain[i];
                    new_plain += 'X';
                    i--;
                }
                else
                    new_plain += plain[i].ToString() + plain[i+1].ToString();
            }
           // new_plain += plain[plain.Length - 1];

          // if (new_plain.Length % 2 != 0) new_plain += 'X';
            string cipher = "";
            for (int i = 0; i < new_plain.Length - 1; i += 2)
            {


                cipher += Enc(new_plain, new_plain[i], new_plain[i + 1],ref matrix);

            }


            // Console.WriteLine(mainCipher2);
            //  string mainCipher2 = "dlfdsdndihbddtntuebluoimcvbserulyo".ToUpper();
            //  if (mainCipher2 == cipher) Console.WriteLine("DDDDDDDD");
            // else Console.WriteLine(mainCipher2);

            return cipher;
        }
    }
}
