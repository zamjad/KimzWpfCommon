namespace KimzWpfCommon.Model
{
    public class FileSystemInfo
    {
        public string Name { get; set; }
        
        public long Length { get; set; }

        public string CreationTime { get; set; }

        public string Extension { get; set; }

        public bool IsReadOnly { get; set; }
    }
}
