using DemirorenTech.Business.Commons.Models.CommonModels;
using DemirorenTech.Business.Commons.Models.NewsModel;
using DemirorenTech.Business.IEngines.INewsEngines;
using DemirorenTech.Business.IEngines.INewsListEngines;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace DemirorenTech.Web.Api.Controllers
{
    [Route("api/news")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsEngine _newsEngine;
        private readonly INewsListEngine _newsListEngine;

        public NewsController(INewsEngine newsEngine, INewsListEngine newsListEngine)
        {
            _newsEngine = newsEngine;
            _newsListEngine = newsListEngine;
        }


        [HttpPost("BulkInsertNews")]
        [Authorize]
        public IActionResult BulkInsertNews(RequestToken<InsertNewsRequest> request)
        {

            var response = Token<List<NewsResponse>>.Instance;

            try
            {
                var result = _newsEngine.BulkInsertNews(request.Filter);

                response.SuccessResult(result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(response.FailResult("News Error", "Couldn't add news. Error Detail =>" + ex.Message));
            }
        }

        [HttpPost("UpdateNews")]
        [Authorize]
        public IActionResult UpdateNews(RequestToken<UpdateNewsRequest> request)
        {

            var response = Token<bool>.Instance;

            try
            {
                using (TransactionScope transaction = new TransactionScope())
                {
                    //News tablosunda haber güncellendi
                    var result = _newsEngine.UpdateNews(request.Filter);

                    //NewsList tablosunda da içerikler güncelleniyor
                    _newsListEngine.UpdateNewsContents(request.Filter);

                    response.SuccessResult(result);

                    transaction.Complete();
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                return Ok(response.FailResult("News Error", "Couldn't update news. Error Detail =>" + ex.Message));
            }
        }
    }
}
