using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uva.Allergie.Common.Models;

namespace Uva.Allergie.Application.Contracts
{
    public interface INewsAppService
    {
        Task<BaseOutput<object>> GeNewsById(int id);
        Task<BaseOutput<object>> GeNews(int page, int pageSize);

        Task<BaseOutput<object>> CreateNews(string news);
    }
}
