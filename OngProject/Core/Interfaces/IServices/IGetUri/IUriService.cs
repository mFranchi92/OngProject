using System;

namespace OngProject.Core.Interfaces.IServices.IGetUri
{
    public interface IUriService
    {
        Uri GetPaginationUri(int page, string actionUrl);
    }
}