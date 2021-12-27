namespace StorageSync.Services
{
    public class FileService
    {
        public FileService()
        {

        }

        public FileInfo[] GetDirectoryTree(string path, string[]? exclude = null)
        {
            var root = new DirectoryInfo(path);
            var options = new EnumerationOptions {
                RecurseSubdirectories = true,
                AttributesToSkip = FileAttributes.Hidden | FileAttributes.System
            };
            var files = root.GetFiles("*", options);
            return files;
        }
    }
}