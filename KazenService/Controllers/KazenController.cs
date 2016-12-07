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
        /// <summary>
        /// Alle kazen lezen
        /// </summary>
        /// <returns>Alle kaezn</returns>
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

        /// <summary>
        /// Kazen lezen volgens smaak
        /// </summary>
        /// <param name="smaak">De smaak van de te lezen kazen</param>
        /// <returns>Kazen van een bepaalde smaak</returns>
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

        /// <summary>
        /// Een kaas lezen
        /// </summary>
        /// <param name="id">De id van de te lezen kaas</param>
        /// <returns>De kaas met de gegeven id</returns>
        public IHttpActionResult Get(int id)
        {
            if (InMemoryDataBase.Kazen.ContainsKey(id))
            {
                return this.Ok(InMemoryDataBase.Kazen[id]);
            }
            return this.NotFound();
        }

        /// <summary>
        /// Een kaas verwijderen
        /// </summary>
        /// <param name="id">De id van de te verwijderen kaas</param>
        /// <returns></returns>
        public IHttpActionResult Delete(int id)
        {
            if (InMemoryDataBase.Kazen.ContainsKey(id))
            {
                InMemoryDataBase.Kazen.Remove(id);
                return this.Ok();
            }
            return this.NotFound();
        }

        /// <summary>
        /// Een kaas toevoegen
        /// </summary>
        /// <param name="kaas">De toe te voegen kaas</param>
        /// <returns></returns>
        public IHttpActionResult Post(Kaas kaas)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }
            var id = InMemoryDataBase.Kazen.Keys.Max() + 1;
            kaas.ID = id;
            InMemoryDataBase.Kazen[id] = kaas;
            return this.Created(this.Request.RequestUri.AbsoluteUri + "/" + id, kaas);
        }
         /// <summary>
         /// Een kaas wijzigen
         /// </summary>
         /// <param name="id">De id van de te wijzigen kaas</param>
        /// <param name="kaas">De gewijzigde kaas</param>
         /// <returns></returns>
        public IHttpActionResult Put(int id, Kaas kaas)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }
            if (InMemoryDataBase.Kazen.ContainsKey(id))
            {
                InMemoryDataBase.Kazen[id] = kaas;
                return this.Ok();
            }
            return this.NotFound();
        }
    }
}
