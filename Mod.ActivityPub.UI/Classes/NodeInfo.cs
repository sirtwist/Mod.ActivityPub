using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mod.ActivityPub.UI
{
	public class NodeInfo
	{
		public string Version { get => "2.1"; }
		public NodeSoftwareInfo Software { get; set; } = new NodeSoftwareInfo();
		[JsonConverter(typeof(StringArrayEnumConverter))]
		public NodeProtocols Protocols { get; set; }
		public NodeServices Services { get; set; } = new NodeServices();
		public bool OpenRegistrations { get; set; }
		public NodeUsage Usage { get; set; } = new NodeUsage();
		public Dictionary<string, string>? Metadata { get; set; }
	}

	public class NodeSoftwareInfo
	{
		public string Name { get; set; }
		public string Version { get; set; }
		public string? Repository { get; set; }
		public string? Homepage { get; set; }

	}

	public class NodeServices
	{
		[JsonConverter(typeof(StringArrayEnumConverter))]
		public NodeServicesInbound Inbound { get; set; }
		[JsonConverter(typeof(StringArrayEnumConverter))]
		public NodeServicesOutbound Outbound { get; set; }
	}

	public class NodeUsage
	{
		public NodeUsers Users { get; set; } = new NodeUsers();
		public long LocalPosts { get; set; } = 0;
		public long LocalComments { get; set; } = 0;
	}

	public class NodeUsers
	{
		public long Total { get; set; } = 0;
		public long ActiveHalfyear { get; set; } = 0;
		public long ActiveMonth { get; set; } = 0;
	}

	[Flags]
	public enum NodeProtocols { 
		none = 0,
		activitypub = 1, 
		buddycloud = 2, 
		dfrn = 4, 
		diaspora = 8, 
		libertree = 16, 
		ostatus = 32, 
		pumpio = 64, 
		tent = 128, 
		xmpp = 256, 
		zot = 512 }

	[Flags]
	public enum NodeServicesInbound
	{
		none = 0,
		atom1_0 = 1,
		gnusocial = 2,
		imap = 4,
		pnut = 8,
		pop3 = 16,
		pumpio = 32,
		rss2_0 = 64,
		twitter = 128
	}

	[Flags]
	public enum NodeServicesOutbound
	{
		none = 0,
		atom1_0 = 1,
		blogger = 2,
		buddycloud = 4,
		diaspora = 8,
		dreamwidth = 16,
		drupal = 32,
		facebook = 64,
		friendica = 128,
		gnusocial = 256,
		google = 512,
		insanejournal = 1024,
		libertree = 2048,
		linkedin = 4096,
		livejournal = 8192,
		mediagoblin = 16384,
		myspace = 32768,
		pinterest = 65536,
		pnut = 131072,
		posterous = 262144,
		pumpio = 524288,
		redmatrix = 1048576,
		rss2_0 = 2097152,
		smtp = 4194304,
		tent = 8388608,
		tumblr = 16777216,
		twitter = 33554432,
		wordpress = 67108864,
		xmpp = 134217728
	}


}
