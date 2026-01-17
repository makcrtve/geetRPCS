/**
 * geetRPCS - AppConfig Model
 * Data structure for application detection and RPC details
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace geetRPCS.Models
{
    public class AppConfig
    {
        [JsonPropertyName("process")]
        public string Process { get; set; }
        [JsonPropertyName("appName")]
        public string AppName { get; set; }
        [JsonPropertyName("windowTitle")]
        public string WindowTitle { get; set; }
        [JsonPropertyName("largeKey")]
        public string LargeKey { get; set; }
        [JsonPropertyName("largeText")]
        public string LargeText { get; set; }
        [JsonPropertyName("smallKey")]
        public string SmallKey { get; set; }
        [JsonPropertyName("smallText")]
        public string SmallText { get; set; }
        [JsonPropertyName("clientId")]
        public string ClientId { get; set; }
        [JsonPropertyName("customDetails")]
        public string CustomDetails { get; set; }
        [JsonPropertyName("buttons")]
        public List<AppButtonConfig> Buttons { get; set; }
        [JsonPropertyName("wittyTexts")]
        public List<string> WittyTexts { get; set; }
        public static List<AppConfig> Load(string path)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                string json = File.ReadAllText(path);
                return JsonSerializer.Deserialize<List<AppConfig>>(json, options);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[AppConfig] Error loading {path}: {ex.Message}");
                return null;
            }
        }
    }
    public class AppButtonConfig
    {
        [JsonPropertyName("label")]
        public string Label { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
