using Microsoft.AspNetCore.Http;
using Taxes.Shared.Abstractions.Contexts;
using System;
using System.Linq;
using System.Security.Claims;

namespace Taxes.Shared.Infrastructure.Contexts
{
    public class UserContext : IUserContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid Id
        {
            get
            {
                if (_httpContextAccessor
                    .HttpContext?
                    .User?
                    .Claims?
                    .SingleOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?
                    .Value != null)
                {
                    return Guid.Parse(_httpContextAccessor.HttpContext.User.Claims.Where(w => w.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value);
                }

                return default;
            }
        }

        public bool IsAvailable => _httpContextAccessor.HttpContext != null;

        public Guid CompanyId
        {
            get
            {
                if (_httpContextAccessor
                    .HttpContext?
                    .User?
                    .Claims?
                    .SingleOrDefault(x => x.Type == "company_id")?
                    .Value != null)
                {
                    return Guid.Parse(_httpContextAccessor.HttpContext.User.Claims.Where(w => w.Type == "company_id").FirstOrDefault().Value);
                }

                return default;
            }
        }

        public string CompanyName
        {
            get
            {
                if (_httpContextAccessor
                    .HttpContext?
                    .User?
                    .Claims?
                    .SingleOrDefault(x => x.Type == "company_name")?
                    .Value != null)
                {
                    return _httpContextAccessor.HttpContext.User.Claims.Where(w => w.Type == "company_name").FirstOrDefault().Value;
                }

                return default;
            }
        }


        public string FullName
        {
            get
            {


                if (_httpContextAccessor
                    .HttpContext?
                    .User?
                    .Claims?
                    .SingleOrDefault(x => x.Type == "fn")?
                    .Value != null)
                {
                    return _httpContextAccessor.HttpContext.User.Claims.Where(w => w.Type == "fn").FirstOrDefault().Value;

                }

                return default;
            }
        }

    }
}

