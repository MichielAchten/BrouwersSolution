using BrouwersService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BrouwersService.Controllers
{
    public class BrouwersController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            //return this.Ok(InMemoryDataBase.Brouwers.Values.ToList());
            //var brouwers = new Brouwers();
            //brouwers.AddRange(InMemoryDataBase.Brouwers.Values);
            //return this.Ok(brouwers);
            var brouwers = new Brouwers();
            var detail = this.Request.RequestUri.AbsoluteUri + "/";
            brouwers.AddRange(from brouwer in InMemoryDataBase.Brouwers.Values
                              orderby brouwer.Naam
                              select new BrouwerBeknopt
                              {
                                  ID = brouwer.ID,
                                  Naam = brouwer.Naam,
                                  Detail = detail + brouwer.ID
                              });
            return this.Ok(brouwers);
        }

        public IHttpActionResult Get(int id)
        {
            if (InMemoryDataBase.Brouwers.ContainsKey(id))
            {
                return this.Ok(InMemoryDataBase.Brouwers[id]);
            }
            return this.NotFound();
        }

        public IHttpActionResult GetByBeginNaam(string beginNaam)
        {
            beginNaam = beginNaam.ToLower();
            var brouwers = new Brouwers();
            //brouwers.AddRange((from brouwer in InMemoryDataBase.Brouwers.Values
            //           where brouwer.Naam.ToLower().StartsWith(beginNaam)
            //           orderby brouwer.Naam
            //           select brouwer));
            //return Ok(brouwers);
            var detail = this.Request.RequestUri.AbsoluteUri;
            detail = detail.Substring(0, detail.IndexOf("?"));
            detail += "/";
            brouwers.AddRange(from brouwer in InMemoryDataBase.Brouwers.Values
                              where brouwer.Naam.ToLower().StartsWith(beginNaam)
                              orderby brouwer.Naam
                              select new BrouwerBeknopt
                              {
                                  ID = brouwer.ID,
                                  Naam = brouwer.Naam,
                                  Detail = detail + brouwer.ID
                              });
            return Ok(brouwers);
        }
    }
}
