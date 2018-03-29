using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Markup;

namespace KimzWpfCommon.MarkupExtensions
{
    [MarkupExtensionReturnType(typeof(string))]
    public class DirectoryExtension : MarkupExtension
    {
        public bool IncludeFolders { get; set; }
        public string Directory { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            List<Model.FileSystemInfo> items = new List<Model.FileSystemInfo>();

            DirectoryInfo di = new DirectoryInfo(Directory);

            FileInfo[] fiList = di.GetFiles();

            foreach (FileInfo fi in fiList)
            {
                Model.FileSystemInfo fsi = new Model.FileSystemInfo
                {
                    Name = fi.Name,
                    Extension = fi.Extension,
                    Length = fi.Length,
                    IsReadOnly = fi.IsReadOnly,
                    CreationTime = fi.CreationTime.ToString(CultureInfo.InvariantCulture)
                };

                items.Add(fsi);
            }

            if (IncludeFolders == true)
            {
                DirectoryInfo[] diList = di.GetDirectories();

                foreach (DirectoryInfo dInfo in diList)
                {
                    Model.FileSystemInfo fsi = new Model.FileSystemInfo
                    {
                        Name = dInfo.Name,
                        CreationTime = dInfo.CreationTime.ToString(CultureInfo.InvariantCulture),
                        Extension = dInfo.Extension
                    };

                    items.Add(fsi);
                }
            }

            return items;
        }
    }
}
