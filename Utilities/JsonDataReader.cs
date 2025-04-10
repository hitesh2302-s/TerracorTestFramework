using System.IO;
using System.Text.Json;
using TerracorTestFramework.Models;

namespace TerracorTestFramework.Utilities
{
    public static class JsonDataReader
    {
        private static readonly string BasePath = Directory.GetCurrentDirectory();

        public static T LoadJson<T>(string fileName)
        {
            string filePath = Path.Combine(BasePath, "TestData", fileName);
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"JSON file not found at: {filePath}");
            }

            string jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<T>(jsonString) ?? throw new InvalidDataException("Failed to deserialize JSON.");
        }

        // Convenience method for loading TestData.json specifically
        public static TestDataModel LoadTestData()
        {
            return LoadJson<TestDataModel>("TestData.json");
        }
    }
}