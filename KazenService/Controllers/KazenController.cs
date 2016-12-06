using KazenService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KazenService.Controllers
{
    public class KazenController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            var detail = this.Request.RequestUri.AbsoluteUri + "/";
            var kazen = new Kazen();
            kazen.AddRange(from kaas in InMemoryDataBase.Kazen.Values
                           orderby kaas.Naam
                           select new KaasBeknopt
                           {
                               ID = kaas.ID,
                               Naam = kaas.Naam,
                               Detail = detail + kaas.ID
                           });
            return this.Ok(kazen);
        }

        public IHttpActionResult GetBySmaak(string smaak)
        {
            smaak = smaak.ToUpper();
            var detail = this.Request.RequestUri.AbsoluteUri;
            detail = detail.Substring(0, detail.IndexOf("?"));
            detail += "/";
            var kazen = new Kazen();
            kazen.AddRange(from kaas in InMemoryDataBase.Kazen.Values
                           where kaas.Smaak.ToUpper() == smaak
                           orderby kaas.Naam
                           select new KaasBeknopt
                           {
                               ID = kaas.ID,
                               Naam = kaas.Naam,
                               Detail = detail + kaas.ID
                           });
            return Ok(kazen);
        }

        public IHttpActionResult Get(int id)
        {
            if (InMemoryDataBase.Kazen.ContainsKey(id))
            {
                return this.Ok(InMemoryDataBase.Kazen[id]);
            }
            return this.NotFound();
        }

    }
}
