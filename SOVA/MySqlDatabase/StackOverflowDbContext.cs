using System;
using System.Collections.Generic;
using System.Data.Entity;
using DomainModel;

namespace MySqlDatabase
{
    public class StackOverflowDbContext : DbContext
    {
        public StackOverflowDbContext() : base(ConnectionStringContainer.NameString)
        {

        }

        /******************************************
            StackOverflow tables
        ******************************************/
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }

        /******************************************
            Our Annotation tabels
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
            

            /*****************************
                Answer
            *****************************/
            //Renaming
            modelBuilder.Entity<Answer>().ToTable("answers");
            modelBuilder.Entity<Answer>().Property(a => a.QuestionId)
                .HasColumnName("parentId");
            
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
            
            /*****************************
                Post
            *****************************/
            //Renaming
            modelBuilder.Entity<Post>().ToTable("posts");
            modelBuilder.Entity<Post>().Property(p => p.UserId).HasColumnName("owneruserid");
            
            /*****************************
                Question
            *****************************/
            //Renaming
            modelBuilder.Entity<Question>().ToTable("questions");
            
            /*****************************
                Search
            *****************************/
            //Renaming
            modelBuilder.Entity<Search>().ToTable("search_history");
            modelBuilder.Entity<Search>().Property(s => s.Id).HasColumnName("search_id");
            modelBuilder.Entity<Search>().Property(s => s.SearchUserId).HasColumnName("search_user_id");
            modelBuilder.Entity<Search>().Property(s => s.SearchString).HasColumnName("search_string");
            modelBuilder.Entity<Search>().Property(s => s.DateTime).HasColumnName("search_date_time");
            
            /*****************************
                SearchUser
            *****************************/
            //Renaming
            modelBuilder.Entity<SearchUser>().ToTable("search_user");
            modelBuilder.Entity<SearchUser>().Property(sh => sh.Id).HasColumnName("search_user_id");
            modelBuilder.Entity<SearchUser>()
                .Property(sh => sh.MacAdresse)
                .HasColumnName("mac_adresse");
            
            /*****************************
                Tag
            *****************************/
            //Renaming
            modelBuilder.Entity<Tag>().ToTable("tags");
            modelBuilder.Entity<Tag>().Property(t => t.Id).HasColumnName("tag_id");
            modelBuilder.Entity<Tag>().Property(t => t.Body).HasColumnName("tag");
            
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
            

            base.OnModelCreating(modelBuilder);
        }
        /*
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        */
    }
}