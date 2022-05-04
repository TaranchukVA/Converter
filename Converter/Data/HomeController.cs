using Converter.Data.Params;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Converter.Data
{
    public class HomeController : Controller
    {
        private const string RUB = "RUB";

        [Route("/")]
        public IActionResult WelcomePage()
        {
            return Ok("Welcome to converter. ");
        }


        [NonAction]
        private async Task<CbrData> GetDataAsync()
        {

            string uri = "https://www.cbr-xml-daily.ru/daily_json.js";

            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            var responce = await client.SendAsync(request);
            var responceSting = await responce.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CbrData>(responceSting);
        }

        [NonAction]
        private double ToRub(double quantity, Valute valute)
        {
            return quantity * valute.Value / valute.Nominal;
        }
        [NonAction]
        private double FromRub(double quantity, Valute valute)
        {
            return quantity  * valute.Nominal / valute.Value;
        }

        [Route("/convert")]
        public IActionResult Covert([FromBody] CurencyData curencyData)
        {

            if (curencyData == null) return BadRequest("Параметры не переданы");
            if (String.IsNullOrEmpty(curencyData.oldCurency)) return BadRequest("Исходная валюта не передана");
            if (String.IsNullOrEmpty(curencyData.newCurency)) return BadRequest("Новая валюта не передана");
            if (Double.IsNegative(curencyData.oldQuantity)) return BadRequest("Не введено количество денег");

            if (curencyData.oldCurency == curencyData.newCurency)
            {
                curencyData.newQuantity = 1;
                return Ok(curencyData);
            }

            var data = GetDataAsync().Result;

            if (!data.valute.ContainsKey(curencyData.oldCurency))
                return BadRequest($"Нет информации о валюте {curencyData.oldCurency}");
            if (!data.valute.ContainsKey(curencyData.newCurency))
                return BadRequest($"Нет информации о валюте {curencyData.newCurency}");

            if (curencyData.newCurency == RUB)
            {
                curencyData.newQuantity = ToRub(curencyData.oldQuantity, data.valute[curencyData.oldCurency]);
                return Ok(curencyData);
            }
            if (curencyData.oldCurency == RUB)
            {
                curencyData.newQuantity = FromRub(curencyData.oldQuantity, data.valute[curencyData.newCurency]);
                return Ok(curencyData);
            }

            curencyData.newQuantity = FromRub(
                ToRub(curencyData.oldQuantity, data.valute[curencyData.oldCurency])
                , data.valute[curencyData.newCurency]);

            return Ok(curencyData);
        }
    }
}
