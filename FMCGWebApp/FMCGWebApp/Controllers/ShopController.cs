﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FMCGWebApp.Manager;
using FMCGWebApp.Models;

namespace FMCGWebApp.Controllers
{
    public class ShopController : ApiController
    {
        private ShopInfoManager _shopInfo = new ShopInfoManager();

        public HttpResponseMessage PostShopInfo(ShopInfo shopInfo)
        {
            var messages = _shopInfo.SaveShopInfo(shopInfo);
            if (messages != null)
            {
                var message = Request.CreateResponse(HttpStatusCode.Created, messages);
                return message;
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Category not created");
        }

        public HttpResponseMessage Get()
        {
            try
            {
                var product = _shopInfo.GetAreaList();
                if (product != null)
                {
                    var message = Request.CreateResponse(HttpStatusCode.Found, product);
                    return message;
                }
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Product not found");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
