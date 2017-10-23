using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace YourSpaceB
{
  public class VideoLocalized
  {
    [Key] public int Id { get; set; }
    public string title { get; set; }
    public string description { get; set; }
  }

  public class VideoSnippet
  {
    [Key] public int Id { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public VideoLocalized localized { get; set; }
  }

  public class VideoItem
  {
    [Key] public string id { get; set; }
    public VideoSnippet snippet { get; set; }
  }

  public class VideoRootObject
  {
    public List<VideoItem> items { get; set; }
  }
}