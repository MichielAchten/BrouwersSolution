using BrouwersClasses;
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
        /// <summary>
        /// Alle brouwers lezen
        /// </summary>
        [HttpGet]
        [Route("brewers")]
        public IHttpActionResult Allen()
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

        /// <summary>
        /// Een brouwer lezen
        /// </summary>
        /// <param name="id">De id van de te lezen brouwer</param>
        /// <returns>De brouwer</returns>
        [HttpGet]
        [Route("brewers/{id}")]
        public IHttpActionResult Een(int id)
        {
            if (InMemoryDataBase.Brouwers.ContainsKey(id))
            {
                return this.Ok(InMemoryDataBase.Brouwers[id]);
            }
            return this.NotFound();
        }

        [HttpGet]
        [Route("brewers")]
        public IHttpActionResult ByBeginNaam(string beginNaam)
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

        //[HttpDelete]
        //[Route("brewers")]
        public IHttpActionResult Delete(int id)
        {
            //error 405: https://www.asp.net/web-api/overview/testing-and-debugging/troubleshooting-http-405-errors-after-publishing-web-api-applications
            if (InMemoryDataBase.Brouwers.ContainsKey(id))
            {
                InMemoryDataBase.Brouwers.Remove(id);
                return this.Ok();
            }
            return this.NotFound();
        }

        [HttpPost]
        [Route("brewers")]
        public IHttpActionResult VoegToe(Brouwer brouwer)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var id = InMemoryDataBase.Brouwers.Keys.Max() + 1;
            brouwer.ID = id;
            InMemoryDataBase.Brouwers[id] = brouwer;
            return this.Created(this.Request.RequestUri.AbsoluteUri + "/" + id, brouwer);
        }

        //[HttpPut]
        //[Route("brewers")]
        public IHttpActionResult Put(int id, Brouwer brouwer)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (InMemoryDataBase.Brouwers.ContainsKey(id))
            {
                InMemoryDataBase.Brouwers[id] = brouwer;
                return this.Ok();
            }
            return this.NotFound();
        }

    }
}
