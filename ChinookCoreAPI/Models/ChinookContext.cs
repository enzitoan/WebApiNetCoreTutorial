using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ChinookCoreAPI.Models
{
    public partial class ChinookContext : DbContext
    {
        public ChinookContext()
        {
        }

        public ChinookContext(DbContextOptions<ChinookContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Albums> Albums { get; set; }
        public virtual DbSet<Artists> Artists { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<FkPlaylistTrackPlaylistId> FkPlaylistTrackPlaylistId { get; set; }
        public virtual DbSet<Genres> Genres { get; set; }
        public virtual DbSet<InvoiceLines> InvoiceLines { get; set; }
        public virtual DbSet<Invoices> Invoices { get; set; }
        public virtual DbSet<MediaTypes> MediaTypes { get; set; }
        public virtual DbSet<Playlists> Playlists { get; set; }
        public virtual DbSet<Tracks> Tracks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Albums>(entity =>
            {
                entity.HasKey(e => e.AlbumId);

                entity.HasIndex(e => e.ArtistArtistId)
                    .HasName("IX_FK_AlbumArtistId");

                entity.Property(e => e.ArtistArtistId).HasColumnName("Artist_ArtistId");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(160);

                entity.HasOne(d => d.ArtistArtist)
                    .WithMany(p => p.Albums)
                    .HasForeignKey(d => d.ArtistArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AlbumArtistId");
            });

            modelBuilder.Entity<Artists>(entity =>
            {
                entity.HasKey(e => e.ArtistId);

                entity.Property(e => e.Name).HasMaxLength(120);
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.HasIndex(e => e.EmployeeEmployeeId)
                    .HasName("IX_FK_CustomerSupportRepId");

                entity.Property(e => e.Address).HasMaxLength(70);

                entity.Property(e => e.City).HasMaxLength(40);

                entity.Property(e => e.Company).HasMaxLength(80);

                entity.Property(e => e.Country).HasMaxLength(40);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.EmployeeEmployeeId).HasColumnName("Employee_EmployeeId");

                entity.Property(e => e.Fax).HasMaxLength(24);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Phone).HasMaxLength(24);

                entity.Property(e => e.PostalCode).HasMaxLength(10);

                entity.Property(e => e.State).HasMaxLength(40);

                entity.HasOne(d => d.EmployeeEmployee)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.EmployeeEmployeeId)
                    .HasConstraintName("FK_CustomerSupportRepId");
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.HasIndex(e => e.Employee2EmployeeId)
                    .HasName("IX_FK_EmployeeReportsTo");

                entity.Property(e => e.Address).HasMaxLength(70);

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.City).HasMaxLength(40);

                entity.Property(e => e.Country).HasMaxLength(40);

                entity.Property(e => e.Email).HasMaxLength(60);

                entity.Property(e => e.Employee2EmployeeId).HasColumnName("Employee2_EmployeeId");

                entity.Property(e => e.Fax).HasMaxLength(24);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.HireDate).HasColumnType("datetime");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Phone).HasMaxLength(24);

                entity.Property(e => e.PostalCode).HasMaxLength(10);

                entity.Property(e => e.State).HasMaxLength(40);

                entity.Property(e => e.Title).HasMaxLength(30);

                entity.HasOne(d => d.Employee2Employee)
                    .WithMany(p => p.InverseEmployee2Employee)
                    .HasForeignKey(d => d.Employee2EmployeeId)
                    .HasConstraintName("FK_EmployeeReportsTo");
            });

            modelBuilder.Entity<FkPlaylistTrackPlaylistId>(entity =>
            {
                entity.HasKey(e => new { e.PlaylistsPlaylistId, e.TracksTrackId });

                entity.ToTable("FK_PlaylistTrackPlaylistId");

                entity.HasIndex(e => e.TracksTrackId)
                    .HasName("IX_FK_FK_PlaylistTrackPlaylistId_Track");

                entity.Property(e => e.PlaylistsPlaylistId).HasColumnName("Playlists_PlaylistId");

                entity.Property(e => e.TracksTrackId).HasColumnName("Tracks_TrackId");

                entity.HasOne(d => d.PlaylistsPlaylist)
                    .WithMany(p => p.FkPlaylistTrackPlaylistId)
                    .HasForeignKey(d => d.PlaylistsPlaylistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FK_PlaylistTrackPlaylistId_Playlist");

                entity.HasOne(d => d.TracksTrack)
                    .WithMany(p => p.FkPlaylistTrackPlaylistId)
                    .HasForeignKey(d => d.TracksTrackId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FK_PlaylistTrackPlaylistId_Track");
            });

            modelBuilder.Entity<Genres>(entity =>
            {
                entity.HasKey(e => e.GenreId);

                entity.Property(e => e.Name).HasMaxLength(120);
            });

            modelBuilder.Entity<InvoiceLines>(entity =>
            {
                entity.HasKey(e => e.InvoiceLineId);

                entity.HasIndex(e => e.InvoiceInvoiceId)
                    .HasName("IX_FK_InvoiceLineInvoiceId");

                entity.HasIndex(e => e.TrackTrackId)
                    .HasName("IX_FK_InvoiceLineTrackId");

                entity.Property(e => e.InvoiceInvoiceId).HasColumnName("Invoice_InvoiceId");

                entity.Property(e => e.TrackTrackId).HasColumnName("Track_TrackId");

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.InvoiceInvoice)
                    .WithMany(p => p.InvoiceLines)
                    .HasForeignKey(d => d.InvoiceInvoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InvoiceLineInvoiceId");

                entity.HasOne(d => d.TrackTrack)
                    .WithMany(p => p.InvoiceLines)
                    .HasForeignKey(d => d.TrackTrackId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InvoiceLineTrackId");
            });

            modelBuilder.Entity<Invoices>(entity =>
            {
                entity.HasKey(e => e.InvoiceId);

                entity.HasIndex(e => e.CustomerCustomerId)
                    .HasName("IX_FK_InvoiceCustomerId");

                entity.Property(e => e.BillingAddress).HasMaxLength(70);

                entity.Property(e => e.BillingCity).HasMaxLength(40);

                entity.Property(e => e.BillingCountry).HasMaxLength(40);

                entity.Property(e => e.BillingPostalCode).HasMaxLength(10);

                entity.Property(e => e.BillingState).HasMaxLength(40);

                entity.Property(e => e.CustomerCustomerId).HasColumnName("Customer_CustomerId");

                entity.Property(e => e.InvoiceDate).HasColumnType("datetime");

                entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.CustomerCustomer)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.CustomerCustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InvoiceCustomerId");
            });

            modelBuilder.Entity<MediaTypes>(entity =>
            {
                entity.HasKey(e => e.MediaTypeId);

                entity.Property(e => e.Name).HasMaxLength(120);
            });

            modelBuilder.Entity<Playlists>(entity =>
            {
                entity.HasKey(e => e.PlaylistId);

                entity.Property(e => e.Name).HasMaxLength(120);
            });

            modelBuilder.Entity<Tracks>(entity =>
            {
                entity.HasKey(e => e.TrackId);

                entity.HasIndex(e => e.AlbumAlbumId)
                    .HasName("IX_FK_TrackAlbumId");

                entity.HasIndex(e => e.GenreGenreId)
                    .HasName("IX_FK_TrackGenreId");

                entity.HasIndex(e => e.MediaTypeMediaTypeId)
                    .HasName("IX_FK_TrackMediaTypeId");

                entity.Property(e => e.AlbumAlbumId).HasColumnName("Album_AlbumId");

                entity.Property(e => e.Composer).HasMaxLength(220);

                entity.Property(e => e.GenreGenreId).HasColumnName("Genre_GenreId");

                entity.Property(e => e.MediaTypeMediaTypeId).HasColumnName("MediaType_MediaTypeId");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.AlbumAlbum)
                    .WithMany(p => p.Tracks)
                    .HasForeignKey(d => d.AlbumAlbumId)
                    .HasConstraintName("FK_TrackAlbumId");

                entity.HasOne(d => d.GenreGenre)
                    .WithMany(p => p.Tracks)
                    .HasForeignKey(d => d.GenreGenreId)
                    .HasConstraintName("FK_TrackGenreId");

                entity.HasOne(d => d.MediaTypeMediaType)
                    .WithMany(p => p.Tracks)
                    .HasForeignKey(d => d.MediaTypeMediaTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TrackMediaTypeId");
            });
        }
    }
}
