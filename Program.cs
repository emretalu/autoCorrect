using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace autoCorrect
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] szlk = new string[] { "baba", "bebe", "babet", "kedi", "kadı", "köpek", "miskin" };
            bool dongu = true;
            while (dongu)
            {
                Console.Write("Kelime: ");
                string k = Console.ReadLine();
                if (k == "")
                {
                    dongu = false;
                    break;
                }
                List<string> oneriler = new List<string>();
                foreach (string s in szlk)
                {
                    int kl = k.Length;
                    int sl = s.Length;
                    if (kl == sl)
                    {
                        int hata = 0;
                        for (int i = 0; i < kl; i++)
                        {
                            if (k[i] != s[i])
                            {
                                hata++;
                            }
                        }
                        if (kl > 2 && hata <= 2 && !oneriler.Contains(s))
                        {
                            oneriler.Add(s);
                        }
                        hata = 0;
                        Dictionary<string, int> lk = new Dictionary<string,int>();
                        Dictionary<string, int> ls = new Dictionary<string, int>();
                        for (int i = 0; i < kl; i++)
                        {
                            if (!lk.ContainsKey(k[i].ToString()))
                            {
                                lk[k[i].ToString()] = 1;
                            }
                            else
                            {
                                lk[k[i].ToString()] = lk[k[i].ToString()] + 1;
                            }
                        }

                        for (int i = 0; i < sl; i++)
                        {
                            if (!ls.ContainsKey(s[i].ToString()))
                            {
                                ls[s[i].ToString()] = 1;
                            }
                            else
                            {
                                ls[s[i].ToString()] = ls[s[i].ToString()] + 1;
                            }
                        }

                        bool match = true;
                        foreach (string i in lk.Keys)
                        {
                            if (!ls.ContainsKey(i) || lk[i] != ls[i])
                            {
                                match = false;
                            }
                        }
                        if (match)
                        {
                            for (int i = 0; i < kl; i++)
                            {
                                if (k[i] != s[i])
                                {
                                    hata++;
                                }
                            }
                        }
                        if (match && hata <= 2 && !oneriler.Contains(s))
                        {
                            oneriler.Add(s);
                        }
                    }
                    else if (kl == sl - 1)
                    {
                        for (int i = 0; i < sl; i++)
                        {
                            string _s = "";

                            if (i != sl - 1)
                            {
                                _s = s.Substring(0, i) + s.Substring(i + 1, sl - (i + 1));
                            }
                            else
                            {
                                _s = s.Substring(0, i);
                            }
                            if (k == _s && !oneriler.Contains(s))
                            {
                                oneriler.Add(s);
                            }
                        }
                    }
                    else if (kl == sl - 2)
                    {
                        for (int i = 0; i < sl; i++)
                        {
                            string _s = "";
                            if (i != sl - 1)
                            {
                                _s = s.Substring(0, i) + s.Substring(i + 1, sl - (i + 1));
                            }
                            else
                            {
                                _s = s.Substring(0, i);
                            }
                            for (int j = 0; j < sl - 1; j++)
                            {
                                string __s = "";
                                if (j != sl - 1)
                                {
                                    __s = s.Substring(0, j) + s.Substring(j + 1, sl - (j + 2));
                                }
                                else
                                {
                                    __s = s.Substring(0, j);
                                }
                                if (k == __s && !oneriler.Contains(s))
                                {
                                    oneriler.Add(s);
                                }
                            }
                        }
                    }

                    else if (kl == sl + 1)
                    {
                        for (int i = 0; i < kl; i++)
                        {
                            string _k = "";

                            if (i != kl - 1)
                            {
                                _k = k.Substring(0, i) + k.Substring(i + 1, kl - (i + 1));
                            }
                            else
                            {
                                _k = k.Substring(0, i);
                            }
                            if (s == _k && !oneriler.Contains(s))
                            {
                                oneriler.Add(s);
                            }
                        }
                    }
                    else if (kl == sl + 2)
                    {
                        for (int i = 0; i < kl; i++)
                        {
                            string _k = "";
                            if (i != kl - 1)
                            {
                                _k = k.Substring(0, i) + k.Substring(i + 1, kl - (i + 1));
                            }
                            else
                            {
                                _k = k.Substring(0, i);
                            }
                            for (int j = 0; j < kl - 1; j++)
                            {
                                string __k = "";
                                if (j != kl - 1)
                                {
                                    __k = k.Substring(0, j) + k.Substring(j + 1, kl - (j + 2));
                                }
                                else
                                {
                                    __k = k.Substring(0, j);
                                }
                                if (s == __k && !oneriler.Contains(s))
                                {
                                    oneriler.Add(s);
                                }
                            }
                        }
                    }
                }
                Console.WriteLine(string.Join(", ", oneriler.ToArray()));
                    
            }
        }
    }
}
