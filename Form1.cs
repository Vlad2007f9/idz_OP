using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace idz_OP
{
    public partial class Form1 : Form
    {
        private string currentFile = "";
        public Form1()
        {
            InitializeComponent();
            
        }

        private void openFileDialog_FileOK(object sender, CancelEventArgs e)
        {
            string fullPathname = openFileDialog.FileName;
            FileInfo src = new FileInfo(fullPathname);
            filename.Text = src.FullName;
            source.Text = "";

            LoadFile(fullPathname);
        }

        private void LoadFile(string Path)
        {
            source.Clear();

            currentFile = Path;

            var provider = FileFactoryProvider.GetInstancee;
            var factory = provider.GetFactoryByExtension(Path);
            var loader = factory.CreateLoader();
            string text = loader.Load(Path);
            Document.Instance.Text = text;
            source.Text = text;
            Document.Instance.AddObs(new WordDeleteObserver());
            Document.Instance.AddObs(new AutoSaveObserver(Path));
            Document.Instance.AddObs(new ParagraphObserver());
        }

        private void SaveFile(string path)
        {
            var provider = FileFactoryProvider.GetInstancee;
            var factory = provider.GetFactoryByExtension(currentFile);
            var saver = factory.CreateSaver();
            saver.Save(path, Document.Instance.Text);
        }

        private void Staticstics(string text, string Path)
        {

            StaticsticsBox.Clear();

            int TotalChars = text.Length;
            int words = Regex.Matches(text, @"\w+").Count;
            int paragraphs = Regex.Matches(text.Trim(), @"(\r?\n\s*\r?\n)+").Count + 1;
            int vowels = Regex.Matches(text, "[AEIOUYaeiouyАЕЄИІЇОУЮЯаеєиіїоуюя]").Count;
            int consonants = Regex.Matches(text, "[BCDFGHJKLMNPQRSTVWXZbcdfghjklmnpqrstvwxzБВГҐДЖЗЙКЛМНПРСТФХЦЧШЩбвгґджзйклмнпрстфхцчшщ]").Count;

            int digits = Regex.Matches(text, @"\d").Count;
            int punctuation = Regex.Matches(text, @"[.,!?';:-]").Count;
            int spaces = Regex.Matches(text, @"\s").Count;
            int specials = Regex.Matches(text, "[$@!%^&*()_+ь'\'{}{<?>[#|/]").Count;

            Regex regex = new Regex(@"\b[a-z0-9._%+-]+@[a-z0-9.-]+\.(edu\.ua|net\.ua|com\.ua|in\.ua|org\.ua)\b", RegexOptions.IgnoreCase);
            int UrlCount = regex.Matches(text).Count;
            MatchCollection matches = regex.Matches(text);
            if (matches.Count > 0)
            {
                StaticsticsBox.AppendText("Found URLs:\r\n");
                foreach (Match matc in matches)
                    StaticsticsBox.AppendText($"{matc.Value}\r\n");
            }

            Regex regexd = new Regex(@"(?<![\d.])\d+(?![\d.])");
            int DigitCount = regexd.Matches(text).Count;
            MatchCollection matchesd = regexd.Matches(text);
            if (matchesd.Count > 0)
            {
                StaticsticsBox.AppendText("Found integer constants:\r\n");
                foreach (Match matcd in matchesd)
                    StaticsticsBox.AppendText($"{matcd.Value}\r\n");
            }

            Regex regexnf = new Regex(@"()?\b\d{4}\.\d{7}\b\1");
            int NFCount = regexnf.Matches(text).Count;
            MatchCollection matchesnf = regexnf.Matches(text);
            if (matchesnf.Count > 0)
            {
                StaticsticsBox.AppendText("Found real constants NNNN.FFFFFFF: \r\n");
                foreach (Match matcnf in matchesnf)
                    StaticsticsBox.AppendText($"{matcnf.Value}\r\n");
            }

            Regex regexhtml = new Regex(@"<(/?)(\w+)[^>]*>", RegexOptions.IgnoreCase);
            int HTMLCount = regexhtml.Matches(text).Count;
            MatchCollection matcheshtml = regexhtml.Matches(text);
            if (matcheshtml.Count > 0)
            {
                StaticsticsBox.AppendText("Found HTML attributes: \r\n");
                foreach (Match matchtml in matcheshtml)
                    StaticsticsBox.AppendText($"{matchtml.Value}\r\n");
            }

            List<string> HtmlReplace = new List<string>();
            string modifiedText = text;

            string ReplaceB = Regex.Replace(modifiedText, @"<\s*b\b[^>]*>", "<strong>", RegexOptions.IgnoreCase);

            if (ReplaceB != modifiedText)
            {
                HtmlReplace.Add("Replaced <b> with <strong>");
            }
            modifiedText = ReplaceB;

            string ReplaceBS = Regex.Replace(modifiedText, @"<\s*/\s*b\s*>", "</strong>", RegexOptions.IgnoreCase);

            if (ReplaceBS != modifiedText)
            {
                HtmlReplace.Add("Replaced </b> with </strong>");
            }
            modifiedText = ReplaceBS;

            string ReplaceI = Regex.Replace(modifiedText, @"<\s*i\b[^>]*>", "<em>", RegexOptions.IgnoreCase);

            if (ReplaceI != modifiedText)
            {
                HtmlReplace.Add("Replaced <i> with <em>");
            }
            modifiedText = ReplaceI;

            string ReplaceIE = Regex.Replace(modifiedText, @"<\s*/\s*i\s*>", "</em>", RegexOptions.IgnoreCase);

            if (ReplaceIE != modifiedText)
            {
                HtmlReplace.Add("Replaced </i> with </em>");
            }
            modifiedText = ReplaceIE;

            Dictionary<string, int> WordsCount = new Dictionary<string, int>();
            MatchCollection wordMatches = Regex.Matches(text.ToLower(), @"[\w.@+-]+");

            foreach (Match match in wordMatches)
            {
                string word = match.Value;
                if (WordsCount.ContainsKey(word))
                    WordsCount[word]++;
                else
                    WordsCount[word] = 1;
            }

            List<string> WordLong = new List<string>(WordsCount.Keys);
            WordLong.Sort((a, b) => b.Length.CompareTo(a.Length));
            if (WordLong.Count > 10)
                WordLong = WordLong.GetRange(0, 10);

            double authorPages = TotalChars / 1800.0;
            double sizeKB;

            if (File.Exists(Path))
            {
                sizeKB = new FileInfo(Path).Length / 1024.0;
            }
            else
            {
                sizeKB = Encoding.UTF8.GetByteCount(text) / 1024.0;
            }

            StaticsticsBox.AppendText(
                $"Statistics:\r\n" +
                $"File size: {sizeKB:F2} KB\r\n" +
                $"Number of characters {TotalChars}\r\n" +
                $"Words: {words}\r\n" +
                $"Paragraphs: {paragraphs}\r\n" +
                $"Vowels: {vowels}\r\n" +
                $"Consonants: {consonants}\r\n" +
                $"Specials: {specials}\r\n" +
                $"Author's pages: {authorPages:F2}\r\n" +
                $"Internet addresses: {UrlCount} \r\n" +
                $"Integer constants: {DigitCount}\r\n" +
                $"Constants NNNN.FFFFFFF: {NFCount}\r\n" +
                $"HTML attributes: {HTMLCount}\r\n");

            StaticsticsBox.AppendText("\r\nWord frequencies:\r\n");
            foreach (string word in WordsCount.Keys)
            {
                int count = WordsCount[word];
                StaticsticsBox.AppendText($"{word} -> {count}\r\n");
            }

            StaticsticsBox.AppendText("\r\nTop 10 longest words:\r\n");
            foreach (string word in WordLong)
            {
                StaticsticsBox.AppendText($"{word} (length: {word.Length})\r\n");
            }

            if (HtmlReplace.Count > 0)
            {
                StaticsticsBox.AppendText("\r\nHTML replacements performed:\r\n");
                foreach (string HTMLreplace in HtmlReplace)
                {
                    StaticsticsBox.AppendText($"{HTMLreplace}\r\n");
                }
            }
            else
            {
                StaticsticsBox.AppendText("\r\nNo HTML replacements found.\r\n");
            }

        }
        private void buttonClear_Click(object sender, EventArgs e)
        {
            string clear = source.Text;

            clear = Regex.Replace(clear, @"[ \t]+", " ");
            clear = Regex.Replace(clear, @"^\s+|\s+$", "\r", RegexOptions.Multiline);
            clear = Regex.Replace(clear, @"(\r?\n){2,}", Environment.NewLine + Environment.NewLine);
            clear = Regex.Replace(clear, @"[ ]{2,}", " ");
            clear = Regex.Replace(clear, @"(\r?\n){2,}", Environment.NewLine);

            source.Text = clear;
        }
        private void toolStripMenuItemFile_Click(object sender, EventArgs e)
        {

        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            source.Clear();
            filename.Text = "New File";
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                LoadFile(openFileDialog.FileName);
            }
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files|*.txt|All Files|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveFile(saveFileDialog.FileName);
                filename.Text = saveFileDialog.FileName;
            }
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            source.Copy();
        }
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            source.Paste();
        }
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            source.Cut();
        }
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            source.Undo();
        }
        private void statisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Staticstics(source.Text, filename.Text);
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Author: student of group 6.1214-1 Nesterenko Vladyslav");
        }
        private void textBoxtext_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                newsFromTheSiteToolStripMenuItem_Click(sender, EventArgs.Empty);
            }
        }
        private async void newsFromTheSiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxtext.Text, out int newsct))
            {
                HttpClient ReqClient = new HttpClient();

                string Chtml = await ReqClient.GetStringAsync("https://www.znu.edu.ua/cms/index.php?action=news/view&start=0&site_id=27&lang=ukr");

                string RegHtml = @"<div\s+class\s*=\s*[""']znu-2016-new[""'][\s\S]*?<h4>\s*<a[^>]*>(?<title>.*?)</a>[\s\S]*?<div\s+class\s*=\s*[""']text[""']>\s*(?<text>.*?)</div>";

                MatchCollection Regmatches = Regex.Matches(Chtml, RegHtml);

                int Regcount = 0;

                foreach (Match Regmatch in Regmatches)
                {
                    if (Regcount >= newsct) break;
                    Regcount++;

                    string rawTitle = Regex.Replace(Regmatch.Groups["title"].Value, "<.*?>", "").Trim();
                    string rawText = Regex.Replace(Regmatch.Groups["text"].Value, "<.*?>", "").Trim();

                    string title = WebUtility.HtmlDecode(rawTitle);
                    string text = WebUtility.HtmlDecode(rawText);

                    source.AppendText($"{title}\r\n\r\n");
                    source.AppendText($"{text}\r\n\r\n");
                }
            }
            else
            {
                MessageBox.Show("Please enter the correct number of pages");
            }

        }
       
        private void singltonToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void lazySingletonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Slazy l1 = Slazy.GetInstance;
            Slazy l2 = Slazy.GetInstance;

            StaticsticsBox.AppendText($"Lazy Singleton:\r\n l1 = {l1.GetHashCode()}   l2 = {l2.GetHashCode()}\r\n");
        }
        private void limitSingletonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Slimit s1 = Slimit.GetInstances();
            Slimit s2 = Slimit.GetInstances();
            Slimit s3 = Slimit.GetInstances();
            Slimit s4 = Slimit.GetInstances();

            StaticsticsBox.AppendText($"Limited Singleton (max=3):\r\n" + $"s1 = {s1.GetHashCode()}\r\n" + $"s2 ={s2.GetHashCode()}\r\n"
                + $"s3 ={s3.GetHashCode()}\r\n" + $"s4 = {s4.GetHashCode()}\r\n");
        }

        private void ShowObs(List<string> mes)
        {
            foreach (var m in mes)
                StaticsticsBox.AppendText(m + "\n");
        }

        private void source_KeyDown(object sender, KeyEventArgs e)
        {
            int pos = source.SelectionStart;

            if (e.KeyCode == Keys.Enter)
            {
                var msgs = Document.Instance.InsertParagraph();
                source.Text = Document.Instance.Text;
                source.SelectionStart = pos + 2;
                ShowObs(msgs);
                e.Handled = true;
                return;
            }
            if(e.KeyCode == Keys.Back)
{
                e.SuppressKeyPress = true; 

                string txt = source.Text;
                int selStart = source.SelectionStart;
                int selLength = source.SelectionLength;

                if (selLength == 0 && selStart == 0)
                    return;

                int start = selStart;
                int length = selLength;

                string removed;

                if (selLength > 0)
                {
                    
                    removed = txt.Substring(selStart, selLength);
                }
                else
                {
                   
                    int pose = selStart - 1;

                   
                    while (pose >= 0 && char.IsWhiteSpace(txt[pose]))
                        pose--;

                    if (pose < 0)
                        return;

                    int wordEnd = pose;
                    while (pose > 0 && !char.IsWhiteSpace(txt[pose - 1]))
                        pose --;

                    start = pose;
                    length = selStart - start;
                    removed = txt.Substring(start, length);
                }

                var msgs = Document.Instance.DeleteRange(start, length);
               
                source.Text = Document.Instance.Text;
                source.SelectionStart = start;

                ShowObs(msgs);
            }
        }
    }
}
