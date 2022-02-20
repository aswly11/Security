using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    public class Monoalphabetic : ICryptographicTechnique<string, string>
    {
        public string Analyse(string plainText, string cipherText)
        {

            plainText = plainText.ToLower();
            cipherText = cipherText.ToLower();
            string alpha = "abcdefghijklmnopqrstuvwxyz";
            Dictionary<char, int> frec = new Dictionary<char, int>();
            Dictionary<char, char?> dic = new Dictionary<char, char?>();
            foreach (var item in alpha)
            {
                dic.Add(item, null);
                frec.Add(item, 0);
            }
            for (int i = 0; i < plainText.Length; i++)
            {
                dic[plainText[i]] = cipherText[i];
                frec[plainText[i]] += 1;

            }
            foreach (var item in dic.Keys.ToList())
            {
                if(dic[item]==null)
                {
                    foreach (var item1 in alpha)
                    {
                      if(!dic.ContainsValue(item1))
                        {
                            dic[item] = item1;
                            break;
                        }
                    }
                }
            }
            string key = "";
            foreach (var item in dic)
            {
                key += item.Value;
            }
            return key;
            //throw new NotImplementedException();
        }

        public string Decrypt(string cipherText, string key)
        {
            cipherText = cipherText.ToLower();
            char[] cipher = cipherText.ToLower().ToCharArray();
            char[] plain = new char[cipher.Length];
            for (int i = 0; i < cipher.Length; i++)
            {
                int c = key.IndexOf(cipher[i]) + 97;
                char ch = (char)c;
                plain[i] = ch;

            }
            return new string(plain);
        }


        public string Encrypt(string plainText, string key)
        {
            char[] alphabetic = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            char[] keyy = key.ToLower().ToCharArray();
            char[] plain = plainText.ToLower().ToCharArray();
            char[] result = new char[plainText.Length];
            var map = new Dictionary<char, char>();


            for (int i = 0; i < alphabetic.Length; i++)
            {
                map.Add(alphabetic[i], keyy[i]);
            }

            for (int i = 0; i < plainText.Length; i++)
            {
                char c = map[plain[i]];
                result[i] = c;

            }
            return new string(result);
        }

        /// <summary>
        /// Frequency Information:
        /// E   12.51%
        /// T	9.25
        /// A	8.04
        /// O	7.60
        /// I	7.26
        /// N	7.09
        /// S	6.54
        /// R	6.12
        /// H	5.49
        /// L	4.14
        /// D	3.99
        /// C	3.06
        /// U	2.71
        /// M	2.53
        /// F	2.30
        /// P	2.00
        /// G	1.96
        /// W	1.92
        /// Y	1.73
        /// B	1.54
        /// V	0.99
        /// K	0.67
        /// X	0.19
        /// J	0.16
        /// Q	0.11
        /// Z	0.09
        /// </summary>
        /// <param name="cipher"></param>
        /// <returns>Plain text</returns>
        public string AnalyseUsingCharFrequency(string cipher)
        {
            int freq = 0, cou = 0, c = 1;
            char[] arr = cipher.ToCharArray();
            char[] arrOfHighFreqAlph = new char[] { 'E', 'T', 'A', 'O', 'I', 'N', 'S', 'R', 'H', 'L', 'D', 'C', 'U', 'M', 'F', 'P', 'G', 'W', 'Y', 'B', 'V', 'K', 'X', 'J', 'Q', 'Z' };
            char[] arrOfHighFreqAlphSmall = new char[] { 'e', 't', 'a', 'o', 'i', 'n', 's', 'r', 'h', 'l', 'd', 'c', 'u', 'm', 'f', 'p', 'g', 'w', 'y', 'b', 'v', 'k', 'x', 'j', 'q', 'z' };
            Dictionary<char, int> mapofchar = new Dictionary<char, int>();


            for (int j = 0; j < cipher.Length; j++)
            {
                if (mapofchar.ContainsKey(cipher[j]))
                {
                    freq = mapofchar[cipher[j]];
                    freq++;
                    mapofchar[cipher[j]] = freq;
                    continue;
                }
                mapofchar.Add(cipher[j], c);

            }
            char[] arrOfHighFreq = new char[26];
            foreach (KeyValuePair<char, int> iter in mapofchar.OrderByDescending(iter => iter.Value))
            {
                arrOfHighFreq[cou] = iter.Key;
                cou++;

            }
            string finalstring = new string(arrOfHighFreq);

            for (int i = 0; i < arr.Length; i++)
            {
                int indexoffinalstring = finalstring.IndexOf(arr[i]);
                arr[i] = arrOfHighFreqAlph[indexoffinalstring];
            }
            string res = new string(arr).ToLower();
            return res;
        }
    }
}
