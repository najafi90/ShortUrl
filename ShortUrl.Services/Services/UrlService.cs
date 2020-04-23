using Microsoft.EntityFrameworkCore;
using ShortUrl.DataLayer.Context;
using ShortUrl.Entities.Models;
using ShortUrl.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShortUrl.Services.Services
{
    public class UrlService : IUrlService
    {
        private readonly DbContext _context;
        public UrlService()
        {
            _context = new MainContext();
        }
        public bool CreateShortUrl(Url model)
        {
            try
            {
                _context.Set<Url>().Add(model);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }   
        }

        public Url GetByShortAddress(string shortAddress)
        {
            try
            {
                return _context.Set<Url>().FirstOrDefault(o => o.ShortAddress == shortAddress);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string GetMainAddress(string shortAddress)
        {
            try
            {
                var url = GetByShortAddress(shortAddress);
                if (url != null)
                {
                    return url.MainUrlAddress;
                }
                return null ;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool? ShortAddressIsValid(string shortAddress)
        {
            try
            {
                return !_context.Set<Url>().Any(o => o.ShortAddress == shortAddress);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool SubmitUrlView(string shortAddress)
        {
            try
            {
                var url = GetByShortAddress(shortAddress);
                if (url != null)
                {
                    url.CounterViews++;
                    _context.Set<Url>().Update(url);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
