namespace StorageSync.Services;

public class StorageService {

    private readonly string _connectionString;
    public StorageService(string AzureStorageConnectionString) {
        _connectionString = AzureStorageConnectionString;
    }

    public async Task Do() {
        
    }
}