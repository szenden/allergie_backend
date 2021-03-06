﻿using System;

namespace Uva.Allergie.Common.Models
{
    public class ArticleOutput
    {
        public int ArticleId { get; set; }
        public string Source { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string UrlToImage { get; set; }
        public DateTime PublishedAt { get; set; }
        public string Content { get; set; }
    }
}
