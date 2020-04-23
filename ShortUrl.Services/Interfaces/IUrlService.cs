using ShortUrl.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShortUrl.Services.Interfaces
{
    public interface IUrlService
    {
        bool CreateShortUrl(Url model);
        bool? ShortAddressIsValid(string shortAddress);
        string GetMainAddress(string shortAddress);
        bool SubmitUrlView(string shortAddress);
        Url GetByShortAddress(string shortAddress);
    }
}
