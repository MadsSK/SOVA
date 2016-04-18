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
            /*****************************
                Annotaiton
            *****************************/
            //Renaming
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
                .WithMany(p => p.Annotations)
                .HasForeignKey(a => a.PostId);
            modelBuilder.Entity<Annotation>()
                .HasOptional<Comment>(a => a.Comment)
                .WithMany(c => c.Annotations)
                .HasForeignKey(a => a.CommentId);
            modelBuilder.Entity<Annotation>()
                .HasRequired<SearchUser>(a => a.SearchUser)
                .WithMany(s => s.Annotations)
                .HasForeignKey(a => a.SearchUserId);

            /*****************************
                Answer
            *****************************/
            //Renaming
            modelBuilder.Entity<Answer>().ToTable("answers");
            modelBuilder.Entity<Answer>().Property(a => a.QuestionId)
                .HasColumnName("parentId");
            //Many-To-One
            modelBuilder.Entity<Answer>()
                .HasRequired(a => a.Question)
                .WithMany(q => q.Answers)
                .HasForeignKey(a => a.QuestionId);

            /*****************************
                Comment
            *****************************/
            //Renaming
            modelBuilder.Entity<Comment>().ToTable("comments");
            modelBuilder.Entity<Comment>().Property(c => c.Id).HasColumnName("commentid");
            modelBuilder.Entity<Comment>().Property(c => c.Score).HasColumnName("commentscore");
            modelBuilder.Entity<Comment>().Property(c => c.Body).HasColumnName("commenttext");
            modelBuilder.Entity<Comment>().Property(c => c.CreateDate).HasColumnName("commentcreatedate");
            modelBuilder.Entity<Comment>().HasKey(c => c.Id);
            //One-To-Many
            modelBuilder.Entity<Comment>()
                .HasMany<Annotation>(c => c.Annotations)
                .WithOptional(a => a.Comment)
                .HasForeignKey(a => a.CommentId);
            //Many-To-One
            modelBuilder.Entity<Comment>()
                .HasRequired<User>(c => c.User)
                .WithMany(q => q.Comments)
                .HasForeignKey(c => c.UserId);
            modelBuilder.Entity<Comment>()
                .HasRequired<Post>(c => c.Post)
                .WithMany(q => q.Comments)
                .HasForeignKey(c => c.PostId);

            /*****************************
                Post
            *****************************/
            //Renaming
            modelBuilder.Entity<Post>().ToTable("posts");
            modelBuilder.Entity<Post>().Property(p => p.UserId).HasColumnName("owneruserid");
            //One-To-Many
            modelBuilder.Entity<Post>()
                .HasMany<Comment>(p => p.Comments)
                .WithRequired(c => c.Post)
                .HasForeignKey(c => c.PostId);
            modelBuilder.Entity<Post>()
                .HasMany<Annotation>(p => p.Annotations)
                .WithOptional(a => a.Post)
                .HasForeignKey(a => a.PostId);
            //Many-To-Many
            modelBuilder.Entity<Post>()
                .HasMany<Tag>(p =>  p.Tags)
                .WithMany(t => t.Posts)
                .Map(tp =>
                    {
                        tp.MapLeftKey("tag_id");
                        tp.MapRightKey("post_id");
                        tp.ToTable("tags_posts");
                    });
            modelBuilder.Entity<Post>()
                .HasMany<SearchUser>(p => p.SearchUsers)
                .WithMany(s => s.Posts)
                .Map(tp =>
                {
                    tp.MapLeftKey("post_id");
                    tp.MapRightKey("search_user_id");
                    tp.ToTable("favorites");
                });
            modelBuilder.Entity<Post>()
                .HasMany<Post>(p => p.LinkedPosts)
                .WithMany()
                .Map(tp =>
                {
                    tp.MapLeftKey("linkpostid");
                    tp.MapRightKey("id");
                    tp.ToTable("linkedposts");
                });
            //Many-To-One
            modelBuilder.Entity<Post>()
                .HasRequired<User>(p => p.User)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.UserId);

            /*****************************
                Question
            *****************************/
            //Renaming
            modelBuilder.Entity<Question>().ToTable("questions");
            //One-To-Many
            modelBuilder.Entity<Question>()
                .HasMany<Answer>(q => q.Answers)
                .WithRequired(a => a.Question)
                .HasForeignKey(a => a.QuestionId);

            /*****************************
                Search
            *****************************/
            //Renaming
            modelBuilder.Entity<Search>().ToTable("search_history");
            modelBuilder.Entity<Search>().Property(s => s.Id).HasColumnName("search_id");
            modelBuilder.Entity<Search>().Property(s => s.SearchUserId).HasColumnName("search_user_id");
            modelBuilder.Entity<Search>().Property(s => s.SearchString).HasColumnName("search_string");
            modelBuilder.Entity<Search>().Property(s => s.DateTime).HasColumnName("search_date_time");
            //Many-To-One
            modelBuilder.Entity<Search>()
                .HasRequired<SearchUser>(s => s.SearchUser)
                .WithMany(su => su.Searches)
                .HasForeignKey(s => s.SearchUserId);

            /*****************************
                SearchUser
            *****************************/
            //Renaming
            modelBuilder.Entity<SearchUser>().ToTable("search_user");
            modelBuilder.Entity<SearchUser>().Property(sh => sh.Id).HasColumnName("search_user_id");
            modelBuilder.Entity<SearchUser>()
                .Property(sh => sh.MacAdresse)
                .HasColumnName("mac_adresse");
            //One-To-Many
            modelBuilder.Entity<SearchUser>()
                .HasMany<Annotation>(su => su.Annotations)
                .WithRequired(a => a.SearchUser)
                .HasForeignKey(a => a.SearchUserId);
            //One-To-Many
            modelBuilder.Entity<SearchUser>()
                .HasMany<Search>(su => su.Searches)
                .WithRequired(s => s.SearchUser)
                .HasForeignKey(s => s.SearchUserId);
            //Many-To-Many
            modelBuilder.Entity<SearchUser>()
                .HasMany<Post>(su => su.Posts)
                .WithMany(p => p.SearchUsers)
                .Map(f =>
                {
                    f.MapLeftKey("post_id");
                    f.MapRightKey("search_user_id");
                    f.ToTable("favorites");
                });

            /*****************************
                Tag
            *****************************/
            //Renaming
            modelBuilder.Entity<Tag>().ToTable("tags");
            modelBuilder.Entity<Tag>().Property(t => t.Id).HasColumnName("tag_id");
            modelBuilder.Entity<Tag>().Property(t => t.Body).HasColumnName("tag");
            //Many-To-Many
            modelBuilder.Entity<Tag>()
                .HasMany<Post>(t => t.Posts)
                .WithMany(p => p.Tags)
                .Map(f =>
                {
                    f.MapLeftKey("tag_id");
                    f.MapRightKey("post_id");
                    f.ToTable("tags_posts");
                });

            /*****************************
                User
            *****************************/
            //Renaming
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<User>().Property(u => u.Id).HasColumnName("userid");
            modelBuilder.Entity<User>().Property(u => u.DisplayName).HasColumnName("userdisplayname");
            modelBuilder.Entity<User>().Property(u => u.CreationDate).HasColumnName("usercreationdate");
            modelBuilder.Entity<User>().Property(u => u.Location).HasColumnName("userlocation");
            modelBuilder.Entity<User>().Property(u => u.Age).HasColumnName("userage");
            //One-To-Many
            modelBuilder.Entity<User>()
                .HasMany<Post>(u => u.Posts)
                .WithRequired(p => p.User)
                .HasForeignKey(p => p.UserId);
            modelBuilder.Entity<User>()
                .HasMany<Comment>(u => u.Comments)
                .WithRequired(c => c.User)
                .HasForeignKey(c => c.UserId);


            base.OnModelCreating(modelBuilder);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}