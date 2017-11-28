using Microsoft.EntityFrameworkCore;

namespace SoundsUp.Data.Models
{
    public partial class SoundsUpSQLDatabaseContext : DbContext
    {
        public virtual DbSet<Albums> Albums { get; set; }
        public virtual DbSet<Artists> Artists { get; set; }
        public virtual DbSet<Discographies> Discographies { get; set; }
        public virtual DbSet<Favorites> Favorites { get; set; }
        public virtual DbSet<Messages> Messages { get; set; }
        public virtual DbSet<Tracks> Tracks { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Albums>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ImageUrl).HasColumnName("image_url");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Artists>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Discographies>(entity =>
            {
                entity.HasKey(e => new { e.ArtistId, e.AlbumId });

                entity.Property(e => e.ArtistId).HasColumnName("artist_id");

                entity.Property(e => e.AlbumId).HasColumnName("album_id");

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.Discographies)
                    .HasForeignKey(d => d.AlbumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Discographies_Albums");

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.Discographies)
                    .HasForeignKey(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Discographies_Artists");
            });

            modelBuilder.Entity<Favorites>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.TrackId });

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.TrackId).HasColumnName("track_id");

                entity.HasOne(d => d.Track)
                    .WithMany(p => p.Favorites)
                    .HasForeignKey(d => d.TrackId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Favorites_Tracks");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Favorites)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Favorites_Users");
            });

            modelBuilder.Entity<Messages>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MsgContent)
                    .IsRequired()
                    .HasColumnName("msg_content")
                    .IsUnicode(false);

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("time_stamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TrackId).HasColumnName("track_id");

                entity.Property(e => e.UserFrom).HasColumnName("user_from");

                entity.Property(e => e.UserTo).HasColumnName("user_to");

                entity.HasOne(d => d.Track)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.TrackId)
                    .HasConstraintName("FK_Messages_Tracks");

                entity.HasOne(d => d.UserFromNavigation)
                    .WithMany(p => p.MessagesUserFromNavigation)
                    .HasForeignKey(d => d.UserFrom)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Messages_UsersFrom");

                entity.HasOne(d => d.UserToNavigation)
                    .WithMany(p => p.MessagesUserToNavigation)
                    .HasForeignKey(d => d.UserTo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Messages_UsersTo");
            });

            modelBuilder.Entity<Tracks>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AlbumId).HasColumnName("album_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PreviewUrl)
                    .HasColumnName("preview_url")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SpotifyUrl)
                    .IsRequired()
                    .HasColumnName("spotify_url")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.Tracks)
                    .HasForeignKey(d => d.AlbumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tracks_Albums");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Avatar)
                    .HasColumnName("avatar")
                    .HasMaxLength(255);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(255);

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasColumnName("display_name")
                    .HasMaxLength(25);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(255);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(255);

                entity.Property(e => e.Salt)
                    .IsRequired()
                    .HasColumnName("salt")
                    .HasMaxLength(255);
            });
        }
    }
}