using DemirorenTech.Business.Commons.Models.CommonModels;
using DemirorenTech.Business.Commons.Models.NewsListModels;
using DemirorenTech.Business.IEngines.INewsEngines;
using DemirorenTech.Business.IEngines.INewsListEngines;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemirorenTech.Web.Api.Controllers
{
    [Route("api/newsList")]
    [ApiController]
    public class NewsListController : ControllerBase
    {
        private readonly INewsEngine _newsEngine;
        private readonly INewsListEngine _newsListEngine;

        

        public NewsListController(INewsEngine newsEngine, INewsListEngine newsListEngine)
        {
            _newsEngine = newsEngine;
            _newsListEngine = newsListEngine;
        }

        [HttpPost("InsertNewsList")]
        [Authorize]
        public IActionResult InsertNewsList(RequestToken<InsertNewsListRequest> request)
        {

            var response = Token<bool>.Instance;

            try
            {
                //Haber içeriklerini al
                var getNews = _newsEngine.GetNewsWithIds(request.Filter);

                //Sıralı haber listesi oluştur
                var result = _newsListEngine.InsertNewsList(request.Filter, getNews);

                response.SuccessResult(result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(response.FailResult("News List Error", "Couldn't add news list. Error Detail =>" + ex.Message));
            }
        }

        [HttpPost("GetNewsListWithName")]
        [Authorize]
        public IActionResult GetNewsListWithName(RequestToken<NewsListRequest> request)
        {

            var response = Token<List<NewsListItemResponse>>.Instance;

            try
            {
                int totalCount = 0;

                var result = _newsListEngine.GetNewsListWithName(request.Filter.ListName, request.Paging.Index, request.Paging.Take, out totalCount);

                response.Header = Filter<NewsListRequest>.Instance.Parameter(request, totalCount);
                response.SuccessResult(result);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(response.FailResult("News List Error", "Couldn't get news list. Error Detail =>" + ex.Message));
            }
        }
    }
}
