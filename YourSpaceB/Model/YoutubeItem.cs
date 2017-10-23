using System;
using System.Collections.Generic;

namespace YourSpaceB
{
  public class PageInfo
{
    public int totalResults { get; set; }
    public int resultsPerPage { get; set; }
}

public class Id
{
    public string kind { get; set; }
    public string channelId { get; set; }
    public string videoId { get; set; }
}

public class Default
{
    public string url { get; set; }
    public int? width { get; set; }
    public int? height { get; set; }
}

public class Medium
{
    public string url { get; set; }
    public int? width { get; set; }
    public int? height { get; set; }
}

public class High
{
    public string url { get; set; }
    public int? width { get; set; }
    public int? height { get; set; }
}

public class Thumbnails
{
    public Default @default { get; set; }
    public Medium medium { get; set; }
    public High high { get; set; }
}

public class Snippet
{
    public DateTime publishedAt { get; set; }
    public string channelId { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public Thumbnails thumbnails { get; set; }
    public string channelTitle { get; set; }
    public string liveBroadcastContent { get; set; }
}

public class Item
{
    public string kind { get; set; }
    public string etag { get; set; }
    public Id id { get; set; }
    public Snippet snippet { get; set; }
}

public class RootObject
{
    public string kind { get; set; }
    public string etag { get; set; }
    public string nextPageToken { get; set; }
    public string regionCode { get; set; }
    public PageInfo pageInfo { get; set; }
    public List<Item> items { get; set; }
}
}

// How to get list of videos based on search
// https://www.googleapis.com/youtube/v3/search?q=skate&part=snippet&key=AIzaSyB9BnIJt1Y1aKgxjFr8bniwrp6KGxmFdwM

// How to get 1 video
// https://www.googleapis.com/youtube/v3/videos?id=7lCDEYXw3mM&key=AIzaSyB9BnIJt1Y1aKgxjFr8bniwrp6KGxmFdwM
// &part=snippet

