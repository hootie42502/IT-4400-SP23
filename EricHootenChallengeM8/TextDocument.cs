using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

namespace EricHootenChallengeM8
{
    internal class TextDocument
    {
        public string FilePath { get; private set; }
        public string Content { get; set; }
        public bool IsChanged { get; set; }

     
        public void New()
        {
            IsChanged = false;
            FilePath= null;
            Content = "";
            
        }

        public void Changed()
        {
            IsChanged = true;
        }

        public bool Open(string filePath)
        {
            try
            {
                Content = File.ReadAllText(filePath);
                FilePath = filePath;
                IsChanged = false;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Save()
        {
            try
            {
                if (FilePath == null)
                {
                    return false;
                }
                using (Stream s = File.OpenWrite(FilePath))
                using (StreamWriter sw = new StreamWriter(s))
                {
                    sw.Write(Content);
                    this.IsChanged = false;
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool SaveAs(string filePath)
        {
            try
            {
                using (Stream s = File.Open(filePath, FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(s))
                {
                    this.IsChanged = false;
                    sw.Write(Content);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
