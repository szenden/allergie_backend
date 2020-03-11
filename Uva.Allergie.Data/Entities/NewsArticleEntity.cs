using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Uva.Allergie.Data.Entities
{
    [Table("articles", Schema = "allergie_dev")]
    public class NewsArticleEntity
    {
        [Column("article_id")]
        [Key]
        public int ArticleId { get; set; }
        [Column("source")]
        public string Source { get; set; }
        [Column("author")]
        public string Author { get; set; }
        [Column("title")]
        public string Title { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("url")]
        public string Url { get; set; }
        [Column("url_to_image")]
        public string UrlToImage { get; set; }
        [Column("published_at")]
        public DateTime PublishedAt { get; set; }
        [Column("content")]
        public string Content { get; set; }
        [Column("created_on")]
        public DateTime CreatedOn { get; set; }
        [Column("created_by")]
        public string CreatedBy { get; set; }
        [Column("modified_on")]
        public DateTime ModifiedOn { get; set; }
        [Column("modified_by")]
        public string ModifiedBy { get; set; }
    }
}
