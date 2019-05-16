﻿using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MVCBlog.ENTITY;

namespace MVCBlog.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public static async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager,User User)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(User, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        internal Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager,ApplicationUser user)
        {
            throw new NotImplementedException();
        }
    }

    //public class ApplicationDbContext 
    //{
    //    public ApplicationDbContext()
    //        : base("DefaultConnection", throwIfV1Schema: false)
    //    {
    //    }

    //    public static ApplicationDbContext Create()
    //    {
    //        return new ApplicationDbContext();
    //    }
    //}
}