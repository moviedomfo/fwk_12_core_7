﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace fwk.security.identity.core
{
    public partial class SecurityUsers
    {
        public SecurityUsers()
        {
            SecurityUserClaims = new HashSet<SecurityUserClaims>();
            SecurityUserRoles = new HashSet<SecurityUserRoles>();
            SecuritytUserLogins = new HashSet<SecuritytUserLogins>();
        }

        public Guid Id { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastLogInDate { get; set; }
        public string UserName { get; set; }
        public bool? IsLockedOut { get; set; }
        public short? FailedPasswordAttemptCount { get; set; }
        public bool? IsApproved { get; set; }
        public Guid? InstitutionId { get; set; }

        public virtual ICollection<SecurityUserClaims> SecurityUserClaims { get; set; }
        public virtual ICollection<SecurityUserRoles> SecurityUserRoles { get; set; }
        public virtual ICollection<SecuritytUserLogins> SecuritytUserLogins { get; set; }
    }
}