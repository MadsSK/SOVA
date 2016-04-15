using System;
using System.Collections;
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
            /*****************************
                Annotaiton
            *****************************/
            modelBuilder.Entity<Annotation>().ToTable("annotation");
            modelBuilder.Entity<Annotation>().Property(a => a.Id)
                .HasColumnName("annotation_id");
            modelBuilder.Entity<Annotation>().Property(a => a.Body)
                .HasColumnName("annotation_body");
            modelBuilder.Entity<Annotation>()
                .Property(a => a.SearchUserId)
                .HasColumnName("search_user_id");
            //Many-To-One
            modelBuilder.Entity<Annotation>()
                .HasOptional<Post>(a => a.Post)
                .WithMany(p => (ICollection<Annotation>) p.Annotations)
                .HasForeignKey(a => a.PostId);
            modelBuilder.Entity<Annotation>()
                .HasOptional<Comment>(a => a.Comment)
                .WithMany(c => (ICollection<Annotation>)c.Annotations)
                .HasForeignKey(a => a.CommentId);
            modelBuilder.Entity<Annotation>()
                .HasRequired<SearchUser>(a => a.SearchUser)
                .WithMany(s => (ICollection<Annotation>)s.Annotations)
                .HasForeignKey(a => a.SearchUserId);

            /*****************************
                Answer
            *****************************/
            modelBuilder.Entity<Answer>().ToTable("answers");
            modelBuilder.Entity<Answer>().Property(a => a.QuestionId)
                .HasColumnName("ParentId");
            //Many-To-One
            modelBuilder.Entity<Answer>()
                .HasRequired<Question>(a => a.Question)
                .WithMany(q => (ICollection<Answer>) q.Answers)
                .HasForeignKey(a => a.QuestionId);

            /*****************************
                Comment
            *****************************/
            modelBuilder.Entity<Comment>().ToTable("comments");
            modelBuilder.Entity<Comment>().Property(c => c.Id).HasColumnName("commentid");
            modelBuilder.Entity<Comment>().Property(c => c.Score).HasColumnName("commentscore");
            modelBuilder.Entity<Comment>().Property(c => c.Body).HasColumnName("commenttext");
            modelBuilder.Entity<Comment>().Property(c => c.CreateDate).HasColumnName("commentcreatedate");
            //One-To-Many
            modelBuilder.Entity<Comment>()
                .HasMany<Annotation>(c => (ICollection<Annotation>)c.Annotations)
                .WithOptional(a => a.Comment)
                .HasForeignKey(a => a.CommentId);
            //Many-To-One
            modelBuilder.Entity<Comment>()
                .HasRequired<User>(c => c.User)
                .WithMany(q => (ICollection<Comment>) q.Comments)
                .HasForeignKey(c => c.UserId);
            modelBuilder.Entity<Comment>()
                .HasRequired<Post>(c => c.Post)
                .WithMany(q => (ICollection<Comment>)q.Comments)
                .HasForeignKey(c => c.PostId);

            /*****************************
                Post
            *****************************/
            modelBuilder.Entity<Post>().ToTable("posts");
            modelBuilder.Entity<Post>().Property(p => p.UserId).HasColumnName("owneruserid");
            //One-To-Many
            modelBuilder.Entity<Post>()
                .HasMany<Comment>(p => (ICollection<Comment>) p.Comments)
                .WithRequired(c => c.Post)
                .HasForeignKey(c => c.PostId);
            modelBuilder.Entity<Post>()
                .HasMany<Annotation>(p => (ICollection<Annotation>)p.Annotations)
                .WithRequired(a => a.Post)
                .HasForeignKey(a => a.PostId);
            //Many-To-Many
            modelBuilder.Entity<Post>()
                .HasMany<Tag>(p =>  (ICollection<Tag>) p.Tags)
                .WithMany(t => t.Posts)
                .Map(tp =>
                    {
                        tp.MapLeftKey("tag_id");
                        tp.MapRightKey("post_id");
                        tp.ToTable("tags_posts");
                    });
            modelBuilder.Entity<Post>()
                .HasMany<SearchUser>(p => (ICollection<SearchUser>)p.SearchUsers)
                .WithMany(s => (ICollection<Post>) s.Posts)
                .Map(tp =>
                {
                    tp.MapLeftKey("post_id");
                    tp.MapRightKey("search_user_id");
                    tp.ToTable("favorites");
                });
            modelBuilder.Entity<Post>()
                .HasMany<Post>(p => (ICollection<Post>)p.LinkedPosts)
                .WithMany(s => (ICollection<Post>)s.LinkedPosts)
                .Map(tp =>
                {
                    tp.MapLeftKey("linkpostid");
                    tp.MapRightKey("id");
                    tp.ToTable("linkedposts");
                });
            //Many-To-One
            modelBuilder.Entity<Post>()
                .HasRequired<User>(p => p.User)
                .WithMany(u => (ICollection<Post>)u.Posts)
                .HasForeignKey(p => p.UserId);

            /*****************************
                Questions
            *****************************/
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