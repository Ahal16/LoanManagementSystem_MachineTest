using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LMS_Machinetest6_2.Model;

public partial class LoanManagementDbContext : DbContext
{
    public LoanManagementDbContext()
    {
    }

    public LoanManagementDbContext(DbContextOptions<LoanManagementDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BackgroundVerification> BackgroundVerifications { get; set; }

    public virtual DbSet<CustomerDetail> CustomerDetails { get; set; }

    public virtual DbSet<CustomerFeedback> CustomerFeedbacks { get; set; }

    public virtual DbSet<FeedbackQuestion> FeedbackQuestions { get; set; }

    public virtual DbSet<HelpReport> HelpReports { get; set; }

    public virtual DbSet<LoanOfficerDetail> LoanOfficerDetails { get; set; }

    public virtual DbSet<LoanRequest> LoanRequests { get; set; }

    public virtual DbSet<LoanType> LoanTypes { get; set; }

    public virtual DbSet<LoanVerification> LoanVerifications { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source =DESKTOP-8PGNBNF\\SQLEXPRESS; Initial Catalog = LoanManagementDB; Integrated Security = True; Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BackgroundVerification>(entity =>
        {
            entity.HasKey(e => e.VerificationId).HasName("PK__Backgrou__306D49076D0F5AEA");

            entity.Property(e => e.Comments).HasColumnType("text");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('Pending')");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.LoanRequest).WithMany(p => p.BackgroundVerifications)
                .HasForeignKey(d => d.LoanRequestId)
                .HasConstraintName("FK__Backgroun__LoanR__4CA06362");

            entity.HasOne(d => d.Officer).WithMany(p => p.BackgroundVerifications)
                .HasForeignKey(d => d.OfficerId)
                .HasConstraintName("FK__Backgroun__Offic__4D94879B");
        });

        modelBuilder.Entity<CustomerDetail>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64D87D245739");

            entity.Property(e => e.Address).HasColumnType("text");
            entity.Property(e => e.AnnualIncome).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.CustomerDetails)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__CustomerD__UserI__3D5E1FD2");
        });

        modelBuilder.Entity<CustomerFeedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__Customer__6A4BEDD67EB8366F");

            entity.ToTable("CustomerFeedback");

            entity.Property(e => e.Answer).HasColumnType("text");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Customer).WithMany(p => p.CustomerFeedbacks)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__CustomerF__Custo__6383C8BA");

            entity.HasOne(d => d.Question).WithMany(p => p.CustomerFeedbacks)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("FK__CustomerF__Quest__6477ECF3");
        });

        modelBuilder.Entity<FeedbackQuestion>(entity =>
        {
            entity.HasKey(e => e.QuestionId).HasName("PK__Feedback__0DC06FAC5E86DABD");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.Question).HasColumnType("text");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<HelpReport>(entity =>
        {
            entity.HasKey(e => e.ReportId).HasName("PK__HelpRepo__D5BD480584CCE4AB");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('Active')");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<LoanOfficerDetail>(entity =>
        {
            entity.HasKey(e => e.OfficerId).HasName("PK__LoanOffi__2E65577A3D1E9508");

            entity.HasIndex(e => e.BadgeNumber, "UQ__LoanOffi__D110FD56B0B70B80").IsUnique();

            entity.Property(e => e.BadgeNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Department)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.LoanOfficerDetails)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__LoanOffic__UserI__412EB0B6");
        });

        modelBuilder.Entity<LoanRequest>(entity =>
        {
            entity.HasKey(e => e.LoanRequestId).HasName("PK__LoanRequ__F948002BB4DFE55F");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('Pending')");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Customer).WithMany(p => p.LoanRequests)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__LoanReque__Custo__45F365D3");

            entity.HasOne(d => d.LoanType).WithMany(p => p.LoanRequests)
                .HasForeignKey(d => d.LoanTypeId)
                .HasConstraintName("FK__LoanReque__LoanT__46E78A0C");
        });

        modelBuilder.Entity<LoanType>(entity =>
        {
            entity.HasKey(e => e.LoanTypeId).HasName("PK__LoanType__19466BAF3D9C2F6B");

            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.InterestRate).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.MaxAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MinAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<LoanVerification>(entity =>
        {
            entity.HasKey(e => e.LoanVerificationId).HasName("PK__LoanVeri__E1F7A990395EB37F");

            entity.Property(e => e.Comments).HasColumnType("text");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('Pending')");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.LoanRequest).WithMany(p => p.LoanVerifications)
                .HasForeignKey(d => d.LoanRequestId)
                .HasConstraintName("FK__LoanVerif__LoanR__534D60F1");

            entity.HasOne(d => d.Officer).WithMany(p => p.LoanVerifications)
                .HasForeignKey(d => d.OfficerId)
                .HasConstraintName("FK__LoanVerif__Offic__5441852A");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C0E2D7F5E");

            entity.HasIndex(e => e.Username, "UQ__Users__536C85E48032CA9B").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Users__A9D105345F77361D").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('Pending')");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
