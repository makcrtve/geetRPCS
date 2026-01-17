/**
 * geetRPCS - Presence Assets Utility
 * Maps applications to their respective Discord assets
 */

using System;
using DiscordRPC;
using geetRPCS.Services;

namespace geetRPCS.Utils
{
    internal static class PresenceAssets
    {
        public static void Reload() => AppConfigManager.Reload();
        public static Assets ForApp(string processName, Assets fallback)
        {
            var app = AppConfigManager.Apps.Find(a => a.Process.Equals(processName, StringComparison.OrdinalIgnoreCase));
            var assets = new Assets
            {
                LargeImageKey = app?.LargeKey ?? fallback.LargeImageKey,
                LargeImageText = app?.LargeText ?? fallback.LargeImageText,
                SmallImageKey = "geetrpcs-small", // "Patented" key
                SmallImageText = "geetRPCS"       // "Patented" text
            };
            return assets;
        }
    }
}
