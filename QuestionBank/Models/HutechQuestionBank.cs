using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuestionBank.Models;


namespace QuestionBank.Models;

public partial class HutechQuestionBank : IdentityDbContext<CustomUser>
{

    public HutechQuestionBank(DbContextOptions<HutechQuestionBank> options)
        : base(options)
    {
    }

    public virtual DbSet<CauHoi> CauHois { get; set; }

    public virtual DbSet<CauTraLoi> CauTraLois { get; set; }

    public virtual DbSet<ChiTietDeThi> ChiTietDeThis { get; set; }

    public virtual DbSet<DeThi> DeThis { get; set; }

    public virtual DbSet<File> Files { get; set; }

    public virtual DbSet<Khoa> Khoas { get; set; }

    public virtual DbSet<MonHoc> MonHocs { get; set; }
    public virtual DbSet<Clo> Clos { get; set; }
    public virtual DbSet<Phan> Phans { get; set; }

    public virtual DbSet<YeuCauRutTrich> YeuCauRutTriches { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityUserRole<string>>().HasKey(p => new { p.UserId, p.RoleId });



        modelBuilder.Entity<CauHoi>(entity =>
        {
            entity.HasKey(e => e.MaCauHoi);

            entity.ToTable("CauHoi");
            entity.Property(e => e.MaCauHoi).ValueGeneratedNever();
            entity.Property(e => e.NgaySua).HasColumnType("datetime");
            entity.Property(e => e.NgayTao).HasColumnType("datetime");

            entity.HasOne(d => d.MaPhanNavigation).WithMany(p => p.CauHois)
                .HasForeignKey(d => d.MaPhan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CauHoi_Phan");
        });

        modelBuilder.Entity<CauTraLoi>(entity =>
        {
            entity.HasKey(e => e.MaCauTraLoi);

            entity.ToTable("CauTraLoi");

            entity.Property(e => e.MaCauTraLoi).ValueGeneratedNever();

            entity.HasOne(d => d.MaCauHoiNavigation).WithMany(p => p.CauTraLois)
                .HasForeignKey(d => d.MaCauHoi)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CauTraLoi_CauHoi");
        });
        modelBuilder.Entity<ChiTietDeThi>(entity =>
        {
            entity.HasKey(e => new { e.MaDeThi, e.MaPhan, e.MaCauHoi });

            entity.ToTable("ChiTietDeThi");

            entity.HasOne(d => d.MaCauHoiNavigation).WithMany(p => p.ChiTietDeThis)
                .HasForeignKey(d => d.MaCauHoi)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietDeThi_CauHoi1");

            entity.HasOne(d => d.MaDeThiNavigation).WithMany(p => p.ChiTietDeThis)
                .HasForeignKey(d => d.MaDeThi)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietDeThi_DeThi");

            entity.HasOne(d => d.MaPhanNavigation).WithMany(p => p.ChiTietDeThis)
                .HasForeignKey(d => d.MaPhan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietDeThi_Phan");
        });

        modelBuilder.Entity<DeThi>(entity =>
        {
            entity.HasKey(e => e.MaDeThi);

            entity.ToTable("DeThi");

            entity.Property(e => e.MaDeThi).ValueGeneratedNever();
            entity.Property(e => e.NgayTao).HasColumnType("datetime");
            entity.Property(e => e.TenDeThi).HasMaxLength(250);

            entity.HasOne(d => d.MaMonHocNavigation).WithMany(p => p.DeThis)
                .HasForeignKey(d => d.MaMonHoc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DeThi_MonHoc");
        });

        modelBuilder.Entity<File>(entity =>
        {
            entity.HasKey(e => e.MaFile).HasName("PK_File");

            entity.Property(e => e.MaFile).ValueGeneratedNever();
            entity.Property(e => e.TenFile).HasMaxLength(250);

            entity.HasOne(d => d.MaCauHoiNavigation).WithMany(p => p.Files)
                .HasForeignKey(d => d.MaCauHoi)
                .HasConstraintName("FK_File_CauHoi");
        });

        modelBuilder.Entity<Khoa>(entity =>
        {
            entity.HasKey(e => e.MaKhoa);

            entity.ToTable("Khoa");

            entity.Property(e => e.MaKhoa).ValueGeneratedNever();
            entity.Property(e => e.TenKhoa).HasMaxLength(250);
        });

        modelBuilder.Entity<MonHoc>(entity =>
        {
            entity.HasKey(e => e.MaMonHoc);

            entity.ToTable("MonHoc");

            entity.Property(e => e.MaMonHoc).ValueGeneratedNever();
            entity.Property(e => e.MaSoMonHoc).HasMaxLength(50);
            entity.Property(e => e.TenMonHoc).HasMaxLength(250);

            entity.HasOne(d => d.MaKhoaNavigation).WithMany(p => p.MonHocs)
                .HasForeignKey(d => d.MaKhoa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MonHoc_Khoa");
        });

        modelBuilder.Entity<Phan>(entity =>
        {
            entity.HasKey(e => e.MaPhan);

            entity.ToTable("Phan");

            entity.Property(e => e.MaPhan).ValueGeneratedNever();
            entity.Property(e => e.TenPhan).HasMaxLength(250);

            entity.HasOne(d => d.MaMonHocNavigation).WithMany(p => p.Phans)
                .HasForeignKey(d => d.MaMonHoc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Phan_MonHoc");
        });

        modelBuilder.Entity<YeuCauRutTrich>(entity =>
        {
            entity.HasKey(e => e.MaYeuCauDe).HasName("PK_YeuCauDe");

            entity.ToTable("YeuCauRutTrich");

            entity.Property(e => e.MaYeuCauDe).ValueGeneratedNever();
            entity.Property(e => e.HoTenGiaoVien).HasMaxLength(50);
            entity.Property(e => e.NgayLay).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

public DbSet<QuestionBank.Models.MaTran> MaTran { get; set; } = default!;
}
