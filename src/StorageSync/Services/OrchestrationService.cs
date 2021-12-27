namespace StorageSync.Services;

public class OrchestrationService
{
    public OrchestrationService()
    {
    }

    public FileInfo[] Do(string path) {
        var fileService = new FileService();
        return fileService.GetDirectoryTree(path);
    }
}