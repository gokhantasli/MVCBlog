using Microsoft.AspNet.Identity.EntityFramework;
using MVCBlog.ENTITY;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBlog.DAL
{
    public class BlogContext : IdentityDbContext<User>
    {
        public BlogContext():base("DefaultConnection")
        {

        }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Commentary> Commentaries { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Resim> Resims { get; set; }
        //public virtual DbSet<User> Users { get; set; }
        public static BlogContext Create()
        {
            return new BlogContext();

        }
        protected override void OnModelCreating(DbModelBuilder mb)
        {
            #region Table Properties
            mb.Entity<Article>().HasKey(x => x.Id);
            mb.Entity<Category>().HasKey(x => x.Id);
            mb.Entity<Commentary>().HasKey(x => x.Id);
            mb.Entity<Tag>().HasKey(x => x.Id);
            mb.Entity<Resim>().HasKey(x => x.Id);
            //mb.Entity<User>().HasKey(x => x.Id);
            #endregion
            #region Properties
            //ArticleProperties
            mb.Entity<Article>().Property(x => x.Content).IsRequired();
            mb.Entity<Article>().Property(x => x.Title).IsRequired().HasMaxLength(250).IsUnicode();
            mb.Entity<Article>().HasIndex(x => x.Title).IsUnique();
            //mb.Entity<Article>().Property(x => x.Like).HasColumnAnnotation("DefaultValue", 0);
            //mb.Entity<Article>().Property(x => x.View).HasColumnAnnotation("DefaultValue", 0);
            //CategoryProperties
            mb.Entity<Category>().Property(x => x.CategoryName).IsRequired().HasMaxLength(250).IsUnicode();
            mb.Entity<Category>().HasIndex(x => x.CategoryName).IsUnique();

            //TagProperties
            mb.Entity<Tag>().Property(x => x.TagName).IsRequired().HasMaxLength(150).IsUnicode();
            mb.Entity<Tag>().HasIndex(x => x.TagName).IsUnique();

            //CommentProperties
            //mb.Entity<Commentary>().Property(x => x.Like).HasColumnAnnotation("DefaultValue", "0");

            //UserProperties
            mb.Entity<User>().Property(x => x.Password).IsRequired().HasMaxLength(100);
            mb.Entity<User>().Property(x => x.Name).IsRequired().HasMaxLength(100);
            mb.Entity<User>().Property(x => x.Surname).IsRequired().HasMaxLength(100);
            mb.Entity<User>().Property(x => x.MailAddress).IsRequired().HasMaxLength(250).IsUnicode();
            mb.Entity<User>().HasIndex(x => x.MailAddress).IsUnique();
            #endregion
            #region Relation Properties
            mb.Entity<Article>().HasRequired(x => x.Tag).WithMany(x => x.Articles).HasForeignKey(x=>x.TagId).WillCascadeOnDelete(false);
            mb.Entity<Article>().HasMany(x => x.Commentaries).WithRequired(x => x.Article).HasForeignKey(x => x.ArticleId).WillCascadeOnDelete(false);
            mb.Entity<Article>().HasRequired(x => x.Category).WithMany(x => x.Articles).HasForeignKey(x => x.CategoryId).WillCascadeOnDelete(false);
            mb.Entity<User>().HasMany(x => x.Commentaries).WithRequired(x => x.User).HasForeignKey(x => x.UserID).WillCascadeOnDelete(false);
            mb.Entity<User>().HasMany(x => x.Articles).WithRequired(x => x.User).HasForeignKey(x => x.UserID).WillCascadeOnDelete(false);
            #endregion
            mb.Entity<Resim>().HasMany(x => x.Article).WithRequired(x => x.Resim).HasForeignKey(x=>x.ResimID).WillCascadeOnDelete(false);
            base.OnModelCreating(mb);
        }
    }
}