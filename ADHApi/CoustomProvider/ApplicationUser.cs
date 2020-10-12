using System;
using System.Security.Principal;

namespace ADHApi.CoustomProvider
{
    public class ApplicationUser : IIdentity
    {
        public virtual string Id { get; set; } = DateTime.UtcNow.Year.ToString() + Guid.NewGuid().ToString();
        public virtual string UserName { get; set; }
        public virtual string Email { get; set; }
        public virtual bool EmailConfirmed { get; set; }
        public virtual String PasswordHash { get; set; }
        public string NormalizedUserName { get; set; }
        public string NormalizedEmail { get; set; }
        public string AuthenticationType { get; set; }
        public bool IsAuthenticated { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }

    }
}
