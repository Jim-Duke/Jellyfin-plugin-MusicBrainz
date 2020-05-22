using System;
using System.Collections.Generic;
using Jellyfin.Plugin.MusicBrainz.Configuration;
using MediaBrowser.Common.Configuration;
using MediaBrowser.Common.Plugins;
using MediaBrowser.Model.Plugins;
using MediaBrowser.Model.Serialization;

namespace Jellyfin.Plugin.MusicBrainz
{
    public class Plugin : BasePlugin<PluginConfiguration>, IHasWebPages
    {
        public override string Name => "MusicBrainz";

        public override Guid Id => Guid.Parse("59ECF98E-E0D2-48F0-A7B2-60028C24E823");

        public Plugin(IApplicationPaths applicationPaths, IXmlSerializer xmlSerializer) : base(applicationPaths, xmlSerializer)
        {
            Instance = this;
        }

        public static Plugin Instance { get; private set; }

        public IEnumerable<PluginPageInfo> GetPages()
        {
            return new[]
            {
                new PluginPageInfo
                {
                    Name = this.Name,
                    EmbeddedResourcePath = string.Format("{0}.Configuration.configPage.html", GetType().Namespace)
                }
            };
        }
    }
}
