using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LineBotByAspNetCore.Models;
using LineBotByAspNetCore.ViewModels;
using LineBotByAspNetCore.Utility;

namespace LineBotByAspNetCore.Controllers
{
    [Produces("application/json")]
    [Route("api/Line")]
    public class LineController :Controller
    {
        private readonly LineBotByAspNetCoreContext _context;

        public LineController(LineBotByAspNetCoreContext context)
        {
            _context = context;
        }


        // POST: api/Line
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RequestBody requestBody)
        {
            string ChannelAccessToken = "NxrC9tDF2YmnWADkA0DU4hxfi6S1tCuH1IS9xsKHwWfX5DM2lMxUVcP79szORTXyK+dI/j6nXwotqlivHWxgQHA0LPlul1EaLuZPnvzzaAK4v5XURsB8hxcIIWQCoxyWbj6ep5tNTpMnICsGMYanSwdB04t89/1O/w1cDnyilFU=";

            var requestMessage = new RequestMessage(requestBody.events.FirstOrDefault().replyToken);

            string text = requestBody.events.First().message.text;

            string[] messages = text.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);

            if (text.Contains("�p�p�ǲ�"))
            {

                var lineKeyword = new LineKeyword();

                lineKeyword.Keyword = messages[0].Replace("�p�p�ǲ�", "");

                lineKeyword.ReplyMessage = messages[1];

                var result = _context.LineKeyword.Find(lineKeyword.Keyword);

                if (result != null)
                {
                    await LineBot.ReplayMessageAsync(ChannelAccessToken, requestMessage.replyToken, "�p�p�ǹL�F");
                    return Ok();
                }

                _context.Add(lineKeyword);

                _context.SaveChanges();

                await LineBot.ReplayMessageAsync(ChannelAccessToken, requestMessage.replyToken, "�p�p�Ƿ|�F");

            }
            else if (text.Contains("�p�p�ѰO"))
            {
                
            }
            else
            {
                var model = _context.LineKeyword.Where(x => x.Keyword == text).FirstOrDefault();

                requestMessage.messages.Add(new Message() { type = "text", text = model.ReplyMessage });

                await LineBot.ReplayMessageAsync(ChannelAccessToken, requestMessage.replyToken, model.ReplyMessage);
            }

            return Ok();
        }


    }
}