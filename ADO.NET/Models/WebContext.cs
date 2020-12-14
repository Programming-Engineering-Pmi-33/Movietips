using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ADO.NET.Models
{
    public partial class WebContext : DbContext
    {
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<CommentRate> CommentRate { get; set; }
        public virtual DbSet<Movie> Movie { get; set; }
        public virtual DbSet<MovieRate> MovieRate { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=34.65.181.129;user=maks;pwd=password;database=web;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("comment");

                entity.HasIndex(e => e.MovieId)
                    .HasName("comment_movie_id_fk");

                entity.HasIndex(e => e.UserLogin)
                    .HasName("comment_user_user_login_fk");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MovieId)
                    .HasColumnName("movie_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnName("text")
                    .HasColumnType("text");

                entity.Property(e => e.Timestamp)
                    .HasColumnName("timestamp")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.UserLogin)
                    .IsRequired()
                    .HasColumnName("user_login")
                    .HasMaxLength(30);

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("comment_movie_id_fk");

                entity.HasOne(d => d.UserLoginNavigation)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.UserLogin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("comment_user_user_login_fk");
            });

            modelBuilder.Entity<CommentRate>(entity =>
            {
                entity.ToTable("comment_rate");

                entity.HasIndex(e => e.CommentId)
                    .HasName("comment_rate_comment_id_fk");

                entity.HasIndex(e => e.UserLogin)
                    .HasName("comment_rate_user_user_login_fk");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CommentId)
                    .HasColumnName("comment_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserLogin)
                    .IsRequired()
                    .HasColumnName("user_login")
                    .HasMaxLength(30);

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.CommentRate)
                    .HasForeignKey(d => d.CommentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("comment_rate_comment_id_fk");

                entity.HasOne(d => d.UserLoginNavigation)
                    .WithMany(p => p.CommentRate)
                    .HasForeignKey(d => d.UserLogin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("comment_rate_user_user_login_fk");
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable("movie");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LenInSec)
                    .HasColumnName("len_in_sec")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<MovieRate>(entity =>
            {
                entity.ToTable("movie_rate");

                entity.HasIndex(e => e.MovieId)
                    .HasName("movie_rate_movie_id_fk");

                entity.HasIndex(e => e.UserLogin)
                    .HasName("movie_rate_user_user_login_fk");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasColumnName("comment")
                    .HasColumnType("text");

                entity.Property(e => e.MovieId)
                    .HasColumnName("movie_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserLogin)
                    .IsRequired()
                    .HasColumnName("user_login")
                    .HasMaxLength(30);

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.MovieRate)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("movie_rate_movie_id_fk");

                entity.HasOne(d => d.UserLoginNavigation)
                    .WithMany(p => p.MovieRate)
                    .HasForeignKey(d => d.UserLogin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("movie_rate_user_user_login_fk");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserLogin);

                entity.ToTable("user");

                entity.Property(e => e.UserLogin)
                    .HasColumnName("user_login")
                    .HasMaxLength(30);

                entity.Property(e => e.EncodedPass)
                    .IsRequired()
                    .HasColumnName("encoded_pass")
                    .HasColumnType("text");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("text");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasColumnType("text");
            });
        }
    }
}
