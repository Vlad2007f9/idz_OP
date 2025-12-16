using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace idz_OP
{
    public interface ISaver
    {
        void Save(string path, string text);
    }

    public interface ILoader
    {
        string Load(string path);
    }

    public interface IFileFactory
    {
        ISaver CreateSaver();
        ILoader CreateLoader();
    }

    public class HtmlLoader : ILoader
    {
        public string Load(string path)
        {
            string html = File.ReadAllText(path);

            string parag = Regex.Replace(html, @"<\s*(p|br)\b[^>]*>", "\n", RegexOptions.IgnoreCase);

            string removehtml = Regex.Replace(parag, @"<[^>]+>", "");

            string decoded = WebUtility.HtmlDecode(removehtml);

            decoded = Regex.Replace(decoded, @"^[ \t]+", "", RegexOptions.Multiline);

            return decoded.Trim();

        }
    }
    public class TxtLoader : ILoader
    {
        public string Load(string path)
        {
            return File.ReadAllText(path, Encoding.UTF8);
        }
    }
    public class BinLoader : ILoader
    {
        public string Load(string path)
        {
            byte[] bytes = File.ReadAllBytes(path);

            return Convert.ToBase64String(bytes);
        }
    }
    public class HtmlSaver : ISaver
    {
        public void Save(string path, string text)
        {
            string[] paragr = Regex.Split(text, @"(\r?\n){2,}");
            StringBuilder sb = new StringBuilder();
            foreach (var p in paragr)
            {
                string t = WebUtility.HtmlEncode(p.Trim());
                sb.AppendLine($"<p>{t}</p>");
            }
            File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
        }
    }
    public class TxtSaver : ISaver
    {
        public void Save(string path, string text)
        {
            File.WriteAllText(path, text, Encoding.UTF8);
        }
    }
    public class BinSaver : ISaver
    {
        public void Save(string path, string text)
        {
            try
            {
                byte[] bytes = Convert.FromBase64String(text);
                File.WriteAllBytes(path, bytes);
            }
            catch
            {
                File.WriteAllBytes(path, Encoding.UTF8.GetBytes(text));
            }
        }
    }
    public class HtmlFactory : IFileFactory
    {
        public ISaver CreateSaver()
        {
            return new HtmlSaver();
        }
        public ILoader CreateLoader()
        {
            return new HtmlLoader();
        }
    }
    public class TxtFactory : IFileFactory
    {
        public ISaver CreateSaver()
        {
            return new TxtSaver();
        }
        public ILoader CreateLoader()
        {
            return new TxtLoader();
        }
    }
    public class BinFactory : IFileFactory
    {
        public ISaver CreateSaver()
        {
            return new BinSaver();
        }
        public ILoader CreateLoader()
        {
            return new BinLoader();
        }
    }

    public sealed class FileFactoryProvider
    {
        private static readonly Lazy<FileFactoryProvider> lazy =
            new Lazy<FileFactoryProvider>(() => new FileFactoryProvider());

        public static FileFactoryProvider GetInstancee
        {
            get { return lazy.Value; }
        }

        private FileFactoryProvider() { }

        public IFileFactory GetFactoryByExtension(string filePathOrName)
        {
            string ext = Path.GetExtension(filePathOrName)?.ToLower() ?? ".txt";

            if (ext == ".html" || ext == ".htm")
            {
                return new HtmlFactory();
            }
            else if (ext == ".bin")
            {
                return new BinFactory();
            }
            else
            {
                return new TxtFactory();
            }
        }
    }
}
