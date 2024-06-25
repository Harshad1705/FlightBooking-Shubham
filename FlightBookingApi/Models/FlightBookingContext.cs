using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FlightBookingApi.Models
{
    public partial class FlightBookingContext : DbContext
    {
        public FlightBookingContext()
        {
        }

        public FlightBookingContext(DbContextOptions<FlightBookingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BookingDetail> BookingDetails { get; set; } = null!;
        public virtual DbSet<FlightDetail> FlightDetails { get; set; } = null!;
        public virtual DbSet<PassengerDetail> PassengerDetails { get; set; } = null!;
        public virtual DbSet<UserDetail> UserDetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=ROCK\\SQLEXPRESS;Database=FlightBooking;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookingDetail>(entity =>
            {
                entity.HasKey(e => e.BookingId);

                entity.ToTable("Booking_Details");

                entity.Property(e => e.BookingId).HasColumnName("Booking_Id");

                entity.Property(e => e.FlightId).HasColumnName("Flight_Id");

                entity.Property(e => e.NumberOfPassenger).HasColumnName("Number_Of_Passenger");

                entity.Property(e => e.PassengerId).HasColumnName("Passenger_Id");

                entity.Property(e => e.TotalAmount)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Total_Amount");

                entity.Property(e => e.TransactionNumber).HasColumnName("Transaction_Number");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.HasOne(d => d.Flight)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.FlightId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Details_Flight_Details");

                entity.HasOne(d => d.Passenger)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.PassengerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Details_Passenger_Details");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Details_UserDetails");
            });

            modelBuilder.Entity<FlightDetail>(entity =>
            {
                entity.HasKey(e => e.FlightId);

                entity.ToTable("Flight_Details");

                entity.Property(e => e.FlightId).HasColumnName("Flight_Id");

                entity.Property(e => e.ArrivalTime).HasColumnType("datetime");

                entity.Property(e => e.DepartureTime).HasColumnType("datetime");

                entity.Property(e => e.Fare).HasColumnType("decimal(18, 4)");
            });

            modelBuilder.Entity<PassengerDetail>(entity =>
            {
                entity.HasKey(e => e.PassengerId);

                entity.ToTable("Passenger_Details");

                entity.Property(e => e.PassengerId).HasColumnName("Passenger_Id");

                entity.Property(e => e.BookingId).HasColumnName("Booking_Id");

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<UserDetail>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).HasColumnName("User_Id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
