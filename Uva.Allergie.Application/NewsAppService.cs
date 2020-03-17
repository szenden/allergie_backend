using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uva.Allergie.Application.Contracts;
using Uva.Allergie.Common.Models;
using Uva.Allergie.Common.Models.Dto;
using Uva.Allergie.Data.Context;
using Uva.Allergie.Data.Entities;

namespace Uva.Allergie.Application
{
    public class NewsAppService : INewsAppService
    {
        private readonly IAllergieDbContext _dbContext;
        public NewsAppService(IAllergieDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BaseOutput<object>> CreateNews(string news)
        {
            var newsObj = JsonConvert.DeserializeObject<NewsOrgDto>(news);
            if (!newsObj.status.Equals("ok"))
                return new BaseOutput<object>
                {
                    IsSuccessful = false,
                    Message = "news articles not found.",
                    Payload = newsObj
                };

            foreach (var article in newsObj.articles)
            {
                var newsArticleEntity = new NewsArticleEntity
                {
                    Source = article.source.name,
                    Author = article.author,
                    Title = article.title,
                    Description = article.description,
                    Url = article.url,
                    UrlToImage = article.urlToImage,
                    PublishedAt = article.publishedAt,
                    Content = article.content
                };
                _dbContext.NewsArticles.Add(newsArticleEntity);
            }
            await _dbContext.SaveChangesAsync();

            return new BaseOutput<object>
            {
                IsSuccessful = true,
                Message = "product created",
                Payload = newsObj
            };
        }

        public async Task<BaseOutput<object>> GeNews(int page = 1, int pageSize = 10)
        {
            var article = await _dbContext.NewsArticles
                .OrderByDescending(a => a.PublishedAt)
                .Take(pageSize*page)
                .ToListAsync();

            if (article == null)
            {
                return new BaseOutput<object>
                {
                    IsSuccessful = false,
                    Message = $"No articles found.",
                    Payload = ""
                };
            }
            var articleStr = JsonConvert.SerializeObject(article);
            var articleOutput = JsonConvert.DeserializeObject<List<ArticleOutput>>(articleStr);
            return new BaseOutput<object>
            {
                IsSuccessful = true,
                Message = $"Articles found.",
                Payload = articleOutput
            };
        }
        public async Task<BaseOutput<object>> GeNewsById(int id)
        {
            var article = await _dbContext.NewsArticles
                .Where(a => a.ArticleId == id)
                .FirstOrDefaultAsync();

            if (article == null)
            {
                return new BaseOutput<object>
                {
                    IsSuccessful = false,
                    Message = $"article with id = {id} not found.",
                    Payload = ""
                };
            }
            var articleStr = JsonConvert.SerializeObject(article);
            var articleOutput = JsonConvert.DeserializeObject<ArticleOutput>(articleStr);
            return new BaseOutput<object>
            {
                IsSuccessful = true,
                Message = $"Article with id = {id} found.",
                Payload = articleOutput
            };
        }
    }
}