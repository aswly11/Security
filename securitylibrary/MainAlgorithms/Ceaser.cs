using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    public class Ceaser : ICryptographicTechnique<string, int>
    {
        public string Encrypt(string plainText, int key)
        {
            if (key > 26)
            {
                key = key % 26;
            }
            else if (key < 0)
            {
                key = (key % 26) + 26;
            }
            string cipher = "";
            int sizee = plainText.Length;
            for (int i = 0; i < sizee; i++)
            {
                char ch = plainText[i];
                if (char.IsLetter(ch))
                {
                    if (char.IsLower(ch))
                    {
                        char c = (char)(ch + key);
                        if (c > 'z')
                        {
                            cipher += (char)(ch - (26 - key));
                        }
                        else
                        {
                            cipher += c;
                        }
                    }
                    else if (char.IsUpper(ch))
                    {
                        char c = (char)(ch + key);
                        if (c > 'Z')
                        {
                            cipher += (char)(ch - (26 - key));
                        }
                        else
                        {
                            cipher += c;
                        }
                    }
                }
                else
                {
                    cipher += ch;
                }
            }
            return cipher;

        }

        public string Decrypt(string cipherText, int key)
        {
            if (key > 26)
            {
                key = key % 26;
            }
            else if (key < 0)
            {
                key = (key % 26) + 26;
            }
            string cipher = "";
            int sizee = cipherText.Length;
            for (int i = 0; i < sizee; i++)
            {
                char ch = cipherText[i];
                if (char.IsLetter(ch))
                {
                    if (char.IsLower(ch))
                    {
                        char c = (char)(ch - key);
                        if (c < 'a')
                        {
                            cipher += (char)(ch + (26 - key));
                        }
                        else
                        {
                            cipher += c;
                        }
                    }
                    else if (char.IsUpper(ch))
                    {
                        char c = (char)(ch - key);
                        if (c < 'A')
                        {
                            cipher += (char)(ch + (26 - key));
                        }
                        else
                        {
                            cipher += c;
                        }
                    }
                }
                else
                {
                    cipher += ch;
                }
            }
            return cipher;
        }

        public int Analyse(string plainText, string cipherText)
        {
            plainText = plainText.ToLower();
            cipherText = cipherText.ToLower();
            int k;
            int first_plnTxt;
            int first_cphrTxt;
            first_plnTxt = plainText[0] - 97;
            first_cphrTxt = cipherText[0] - 97;
            if (first_cphrTxt < first_plnTxt)
            {
                k = 25 - first_cphrTxt;
            }
            else
            {
                k = first_cphrTxt - first_plnTxt;
            }
            return k;
        }
    }
}
