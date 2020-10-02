using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OtiotHtml
{
    class Program
    {
        static List<String> alLetters = new List<string>();
        static List<String> alWords = new List<string>();


        static void Main(string[] args)
        {
            int book = 1;
            string bookname = "exodus";
            int chapters = 40;

            for (int chapter = 1; chapter <= chapters; chapter++)
            {
                Console.Write(chapter.ToString() + ".");
                string fin = @"F:\HOT\B" + book.ToString("00") + "C" + chapter.ToString("000") + ".htm";
                string fout = @"F:\HOT\" + bookname + chapter.ToString("00") + "otiot.htm";
                StreamReader sr = new StreamReader(fin);
                StreamWriter sw = new StreamWriter(fout);
                string sline = sr.ReadLine();

                while (sline != null)
                {
                    int previx = 0;
                    int six = sline.IndexOf(".gif");
                    while (six > 0)
                    {
                        int prevslash = sline.IndexOf("src=", six - 20)+3;
                        if (six > prevslash)
                        {
                            string word = sline.Substring(prevslash + 1, six - prevslash);
                            alLetters.Add(substitute(word));
                            six = sline.IndexOf(".gif", six + 1);
                            if ((previx > 0) && (six > 0))
                            {
                                string test = sline.Substring(previx, six - previx);
                                if ((test.IndexOf("<br>") > 0) || (test.IndexOf("<BR>") > 0))
                                {
                                    alWords.Add(render() + "<hr>");
                                    sw.WriteLine(renderWords() + "<hr>");
                                }
                                if (test.IndexOf("nbsp;") > 0)
                                {
                                    alWords.Add(render() + "<hr>");
                                }

                            }
                        }
                        else
                        {
                            six = 0;
                        }
                        previx = six;
                    }

                    string thewords = render();
                    if (thewords != String.Empty)
                        alWords.Add(thewords + "<hr>");
                    string theline = renderWords();
                    if (theline != String.Empty)
                        sw.WriteLine(theline + "<hr>");

                    sline = sr.ReadLine();
                }
                sw.Flush();
                sw.Close();
            }
        }

        static string renderWords()
        {
            StringBuilder sb = new StringBuilder();
            int last = alWords.Count - 1;
            for (int ix = last; ix >= 0; ix--)
            {
                sb.Append(alWords[ix]);
            }
            alWords.Clear();
            return sb.ToString();
        }
        static string render()
        {
            StringBuilder sb = new StringBuilder();
            int last = alLetters.Count - 1;
            for (int ix = last; ix >= 0; ix--)
            {
                sb.Append(alLetters[ix]);
            }
            alLetters.Clear();
            return sb.ToString();
        }

        static string substitute(string w)
        {
            string ot = w;
            switch (w)
            {
                case "paleph.": { ot = "a.png"; break; }
                case "payin.": { ot = "ayin.png"; break; }
                case "pbeth.": { ot = "b.png"; break; }
                case "pgimel.": { ot = "g.png"; break; }
                case "pcheyth.": { ot = "het.png"; break; }
                case "pdaleth.": { ot = "d.png"; break; }
                case "phe.": { ot = "h.png"; break; }
                case "pkaph.": { ot = "kaf.png"; break; }
                case "plamed.": { ot = "l.png"; break; }
                case "pmem.": { ot = "m.png"; break; }
                case "pnuwn.": { ot = "n.png"; break; }
                case "pphe.": { ot = "p.png"; break; }
                case "pqowph.": { ot = "k.png"; break; }
                case "preysh.": { ot = "r.png"; break; }
                case "pshiyn.": { ot = "sh.png"; break; }
                case "pteyth.": { ot = "tet.png"; break; }
                case "pthav.": { ot = "t.png"; break; }
                case "ptsadey.": { ot = "tz.png"; break; }
                case "pvav.": { ot = "v.png"; break; }
                case "pyowd.": { ot = "y.png"; break; }
                case "pzayin.": { ot = "z.png"; break; }
                case "psamek.": { ot = "s.png"; break; }
            }
            return "<img src=" + ot + ">";
        }
    }
}

