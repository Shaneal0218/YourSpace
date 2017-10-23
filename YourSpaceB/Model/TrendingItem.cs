using System;
using System.Collections.Generic;

namespace YourSpaceB
{
    public class TrendingPageInfo
{
    public int totalResults { get; set; }
    public int resultsPerPage { get; set; }
}

public class TrendingDefault
{
    public string url { get; set; }
    public int width { get; set; }
    public int height { get; set; }
}

public class TrendingMedium
{
    public string url { get; set; }
    public int width { get; set; }
    public int height { get; set; }
}

public class TrendingHigh
{
    public string url { get; set; }
    public int width { get; set; }
    public int height { get; set; }
}

public class TrendingStandard
{
    public string url { get; set; }
    public int width { get; set; }
    public int height { get; set; }
}

public class TrendingMaxres
{
    public string url { get; set; }
    public int width { get; set; }
    public int height { get; set; }
}

public class TrendingThumbnails
{
    public Default @default { get; set; }
    public Medium medium { get; set; }
    public TrendingHigh high { get; set; }
    public TrendingStandard standard { get; set; }
    public TrendingMaxres maxres { get; set; }
}

public class TrendingLocalized
{
    public string title { get; set; }
    public string description { get; set; }
}

public class TrendingSnippet
{
    public DateTime publishedAt { get; set; }
    public string channelId { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public TrendingThumbnails thumbnails { get; set; }
    public string channelTitle { get; set; }
    public List<string> tags { get; set; }
    public string categoryId { get; set; }
    public string liveBroadcastContent { get; set; }
    public TrendingLocalized localized { get; set; }
    public string defaultAudioLanguage { get; set; }
    public string defaultLanguage { get; set; }
}

public class TrendingItem
{
    public string kind { get; set; }
    public string etag { get; set; }
    public string id { get; set; }
    public TrendingSnippet snippet { get; set; }
}

public class TrendingRootObject
{
    public string kind { get; set; }
    public string etag { get; set; }
    public string nextPageToken { get; set; }
    public TrendingPageInfo pageInfo { get; set; }
    public List<TrendingItem> items { get; set; }
}
}