using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace idz_OP
{
    public interface IObserver
    {
        public string Update(DocumentEvent doce);
    }
    public enum DocEventType
    {
        Delete,
        ParagraphAdded,
        AutoSave
    }
    public class DocumentEvent
    {
        public DocEventType Etype { get; set; }
        public string Text { get; set; }
        public int RemoveWords { get; set; }
        public List<string> DeletedWords { get; set; } = new List<string>();
        

    }
    public class Document
    {
        private static readonly Lazy<Document> lazy =
           new Lazy<Document>(() => new Document());
        public static Document Instance
        {
            get { return lazy.Value; }
        }

        private Document() { }

        public string Text { get; set; } = "";
        private List<IObserver> observers = new List<IObserver>();
        public void AddObs(IObserver obs)
        {
            observers.Add(obs);
        }
        public void RemoveObs(IObserver obs)
        {
            observers.Remove(obs);
        }
        public List<string> Notify(DocumentEvent ev)
        {
            List<string> result = new();
            foreach (var obs in observers)
            {
                string r = obs.Update(ev);
                if (!string.IsNullOrEmpty(r))
                    result.Add(r);
            }
            return result;
        }
       

        public List<string> InsertParagraph()
        {
            Text += "\r\n";
            return Notify(new DocumentEvent { Etype = DocEventType.ParagraphAdded });
        }

        public List<string> DeleteRange(int start, int length)
        {
            string removed = Text.Substring(start, length);

        
            int removedWords = Regex.Matches(removed, @"\b\w+\b").Count;

            Text = Text.Remove(start, length);

            var ev = new DocumentEvent
            {
                Etype = DocEventType.Delete,
                RemoveWords = removedWords,
                Text = removed
            };

            return Notify(ev);
        }
        public void ClearObservers()
        {
            observers.Clear();
        }

    }
    public class WordDeleteObserver : IObserver
    {
        public string Update(DocumentEvent ev)
        {
            if (ev.Etype != DocEventType.Delete)
                return null;

            if (ev.RemoveWords > 1)
                return $"\nDeleted {ev.RemoveWords} words\r\n";

            return null;
        }
    }
    public class AutoSaveObserver : IObserver
    {
        private readonly string path;

        public AutoSaveObserver(string filePath)
        {
            path = filePath;
        }

        public string Update(DocumentEvent ev)
        {
            if (ev.Etype != DocEventType.ParagraphAdded)
                return null;

            var provider = FileFactoryProvider.GetInstancee;
            var factory = provider.GetFactoryByExtension(path);
            var saver = factory.CreateSaver();

            saver.Save(path, Document.Instance.Text);

            return "AutoSave File\n";
        }
    }
    public class ParagraphObserver : IObserver
    {
        public string Update(DocumentEvent doce)
        {
            if (doce.Etype == DocEventType.ParagraphAdded)
                return "\r\nAdder new paragraph\r\n";

            return "";
        }
    }
}
