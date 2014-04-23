using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using FoodTruckFinal.Models;

namespace FoodTruckFinal.Controllers
{
    public class AdminController : ApiController
    {
        private UserContext db = new UserContext();

        // GET api/Admin
        public IEnumerable<FoodTruck> GetFoodTrucks()
        {
            return db.FoodTrucks.AsEnumerable();
        }

        // GET api/Admin/5
        public FoodTruck GetFoodTruck(int id)
        {
            FoodTruck foodtruck = db.FoodTrucks.Find(id);
            if (foodtruck == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return foodtruck;
        }

        // PUT api/Admin/5
        public HttpResponseMessage PutFoodTruck(int id, FoodTruck foodtruck)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != foodtruck.ID)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(foodtruck).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Admin
        public HttpResponseMessage PostFoodTruck(FoodTruck foodtruck)
        {
            if (ModelState.IsValid)
            {
                db.FoodTrucks.Add(foodtruck);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, foodtruck);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = foodtruck.ID }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Admin/5
        public HttpResponseMessage DeleteFoodTruck(int id)
        {
            FoodTruck foodtruck = db.FoodTrucks.Find(id);
            if (foodtruck == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.FoodTrucks.Remove(foodtruck);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, foodtruck);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}