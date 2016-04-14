using System;
using System.Collections.Generic;
using System.Data.Entity;
using DomainModel;

namespace MySqlDatabase
{
    public class SovaDBContext : DbContext
    {
        public SovaDBContext() : base("madssk")
        {

        }

        /******************************************
            StackOverflow tabels
        ******************************************/
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }

        /******************************************
            Our Annotaion tabels
        ******************************************/
        public DbSet<Annotation> Annotations { get; set; }
        public DbSet<Search> Searchs { get; set; }
        public DbSet<SearchUser> SearchUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Annotation>().ToTable("annotation");
            modelBuilder.Entity<Annotation>().Property(a => a.Id)
                .HasColumnName("annotation_id");
            modelBuilder.Entity<Annotation>().Property(a => a.Body)
                .HasColumnName("annotation_body");
            modelBuilder.Entity<Annotation>()
                .Property(a => a.SearchUserId)
                .HasColumnName("search_user_id");
            modelBuilder.Entity<Annotation>()
                .HasRequired<Post>(a => a.Post)
                .WithMany(p => (ICollection<Annotation>) p.Annotations)
                .HasForeignKey(a => a.PostId);
            modelBuilder.Entity<Annotation>()
                .HasRequired<Comment>(a => a.Comment)
                .WithMany(c => (ICollection<Annotation>)c.Annotations)
                .HasForeignKey(a => a.CommentId);
            modelBuilder.Entity<Annotation>()
                .HasRequired<SearchUser>(a => a.SearchUser)
                .WithMany(s => (ICollection<Annotation>)s.Annotations)
                .HasForeignKey(a => a.SearchUserId);


            modelBuilder.Entity<Answer>().ToTable("answers");

            modelBuilder.Entity<Comment>().ToTable("comments");
            modelBuilder.Entity<Comment>().Property(c => c.Id).HasColumnName("commentid");
            modelBuilder.Entity<Comment>().Property(c => c.Score).HasColumnName("commentscore");
            modelBuilder.Entity<Comment>().Property(c => c.Body).HasColumnName("commenttext");
            modelBuilder.Entity<Comment>().Property(c => c.CreateDate).HasColumnName("commentcreatedate");

            modelBuilder.Entity<Post>().ToTable("posts");
            modelBuilder.Entity<Post>()
                .HasMany<Tag>(p => (ICollection<Tag>) p.Tags)
                .WithMany(t => t.Posts)
                .Map(tp =>
                    {
                        tp.MapLeftKey("tag_id");
                        tp.MapRightKey("post_id");
                        tp.ToTable("tags_posts");
                    });

            modelBuilder.Entity<Question>().ToTable("questions");

            modelBuilder.Entity<Search>().ToTable("search_history");
            modelBuilder.Entity<Search>().Property(s => s.Id).HasColumnName("search_id");
            modelBuilder.Entity<Search>().Property(s => s.SearchUserId).HasColumnName("search_user_id");
            modelBuilder.Entity<Search>().Property(s => s.SearchString).HasColumnName("search_string");
            modelBuilder.Entity<Search>().Property(s => s.DateTime).HasColumnName("search_date_time");

            modelBuilder.Entity<SearchUser>().ToTable("search_user");
            modelBuilder.Entity<SearchUser>().Property(sh => sh.Id).HasColumnName("search_user_id");
            modelBuilder.Entity<SearchUser>().Property(sh => sh.MacAdresse).HasColumnName("mac_adresse");

            modelBuilder.Entity<Tag>().ToTable("tags");
            modelBuilder.Entity<Tag>().Property(t => t.Id).HasColumnName("tag_id");
            modelBuilder.Entity<Tag>().Property(t => t.Body).HasColumnName("tag");

            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<User>().Property(u => u.Id).HasColumnName("userid");
            modelBuilder.Entity<User>().Property(u => u.DisplayName).HasColumnName("userdisplayname");
            modelBuilder.Entity<User>().Property(u => u.CreationDate).HasColumnName("usercreationdate");
            modelBuilder.Entity<User>().Property(u => u.Location).HasColumnName("userlocation");
            modelBuilder.Entity<User>().Property(u => u.Age).HasColumnName("userage");

            base.OnModelCreating(modelBuilder);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}