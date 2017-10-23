using System;
using System.Collections.Generic;

namespace YourSpaceB
{
  public class Article
{
    public string author { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public string url { get; set; }
    public string urlToImage { get; set; }
    public DateTime? publishedAt { get; set; }
}

public class EntertainmentRootObject
{
    public string status { get; set; }
    public string source { get; set; }
    public string sortBy { get; set; }
    public List<Article> articles { get; set; }
}
}