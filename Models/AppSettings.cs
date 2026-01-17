/**
 * geetRPCS - AppSettings Model
 * Structure for application-wide configuration
 */

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace geetRPCS.Models
{
    public class AppSettings
    {
        [JsonPropertyName("language")]
        public string Language { get; set; } = "en";
        [JsonPropertyName("disabledApps")]
        public List<string> DisabledApps { get; set; } = new List<string>();
        [JsonPropertyName("mouseEnergyEnabled")]
        public bool MouseEnergyEnabled { get; set; } = true;
        [JsonPropertyName("trayAnimationEnabled")]
        public bool TrayAnimationEnabled { get; set; } = true;
        [JsonPropertyName("telemetryEnabled")]
        public bool TelemetryEnabled { get; set; } = true;
        [JsonPropertyName("appOverrides")]
        public Dictionary<string, AppOverrideConfig> AppOverrides { get; set; } = new Dictionary<string, AppOverrideConfig>(StringComparer.OrdinalIgnoreCase);
    }
    public class AppOverrideConfig
    {
        [JsonPropertyName("details")]
        public string Details { get; set; }
        [JsonPropertyName("state")]
        public string State { get; set; }
    }
}
