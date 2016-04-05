using System.Data.Entity;
using DomainModel;

namespace MySqlDatabase
{
    public class MovieDBContext : DbContext
    {
        public MovieDBContext() : base("madssk")
        {

        }

        /******************************************
            StackOverflow tabels
        ******************************************/
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<LinkedPost> LinkedPosts { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<TagPost> TagPosts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }

        /******************************************
            Our Annotaion tabels
        ******************************************/
        public DbSet<Annotation> Annotations { get; set; }
        public DbSet<Favorit> Favorites { get; set; }
        public DbSet<Search> Searchs { get; set; }
        public DbSet<SearchUser> SearchUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>().ToTable("answers");

            modelBuilder.Entity<Annotation>().ToTable("annotation");
            modelBuilder.Entity<Annotation>().Property(a => a.Id).HasColumnName("annotation_id");
            modelBuilder.Entity<Annotation>().Property(a => a.Body).HasColumnName("annotation_body");

            modelBuilder.Entity<Comment>().ToTable("comments");
            modelBuilder.Entity<Comment>().Property(c => c.Id).HasColumnName("commentid");
            modelBuilder.Entity<Comment>().Property(c => c.Score).HasColumnName("commentscore");
            modelBuilder.Entity<Comment>().Property(c => c.Text).HasColumnName("commenttext");
            modelBuilder.Entity<Comment>().Property(c => c.CreateDate).HasColumnName("commentcreatedate");

            modelBuilder.Entity<Favorit>().ToTable("favorites");
            modelBuilder.Entity<Favorit>().Property(f => f.PostId).HasColumnName("post_id");
            modelBuilder.Entity<Favorit>().Property(f => f.SearchUserId).HasColumnName("search_user_id");

            modelBuilder.Entity<LinkedPost>().ToTable("linkedposts");

            modelBuilder.Entity<Post>().ToTable("posts");

            modelBuilder.Entity<Question>().ToTable("questions");

            modelBuilder.Entity<Search>().ToTable("search_history");
            modelBuilder.Entity<Search>().Property(s => s.Id).HasColumnName("search_id");
            modelBuilder.Entity<Search>().Property(s => s.UserId).HasColumnName("search_user_id");
            modelBuilder.Entity<Search>().Property(s => s.SearchString).HasColumnName("search_string");
            modelBuilder.Entity<Search>().Property(s => s.DateTime).HasColumnName("search_date_time");

            modelBuilder.Entity<SearchUser>().ToTable("search_user");
            modelBuilder.Entity<SearchUser>().Property(sh => sh.Id).HasColumnName("search_user_id");
            modelBuilder.Entity<SearchUser>().Property(sh => sh.MacAdresse).HasColumnName("mac_adresse");

            modelBuilder.Entity<Tag>().ToTable("tags");
            modelBuilder.Entity<Tag>().Property(t => t.Id).HasColumnName("tag_id");
            modelBuilder.Entity<Tag>().Property(t => t.Body).HasColumnName("tag");

            modelBuilder.Entity<TagPost>().ToTable("tags_posts");
            modelBuilder.Entity<TagPost>().Property(tp => tp.PostId).HasColumnName("post_id");
            modelBuilder.Entity<TagPost>().Property(tp => tp.TagId).HasColumnName("tag_id");

            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<User>().Property(u => u.Id).HasColumnName("userid");
            modelBuilder.Entity<User>().Property(u => u.DisplayName).HasColumnName("userdisplayname");
            modelBuilder.Entity<User>().Property(u => u.CreationDate).HasColumnName("usercreationdate");
            modelBuilder.Entity<User>().Property(u => u.Location).HasColumnName("userlocation");
            modelBuilder.Entity<User>().Property(u => u.Age).HasColumnName("userage");

            base.OnModelCreating(modelBuilder);
        }
    }
}