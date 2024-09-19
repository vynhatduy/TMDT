using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TMDT.Models;

public partial class TMDTContext : DbContext
{
    public TMDTContext()
    {
    }

    public TMDTContext(DbContextOptions<TMDTContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Banner> Banners { get; set; }

    public virtual DbSet<ChiTietGioHang> ChiTietGioHangs { get; set; }

    public virtual DbSet<CthoaDon> CthoaDons { get; set; }

    public virtual DbSet<DanhGium> DanhGia { get; set; }

    public virtual DbSet<DanhMuc> DanhMucs { get; set; }

    public virtual DbSet<GioHang> GioHangs { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<Loai> Loais { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

    public virtual DbSet<Shop> Shops { get; set; }

    public virtual DbSet<Ultility> Ultilities { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Voucher> Vouchers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=VYNHATDUY;Initial Catalog=TMDT;User ID=sa;Password=sa;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Uid).HasName("PK__Account__C5B19602A8D80804");

            entity.ToTable("Account");

            entity.HasIndex(e => e.Username, "UQ__Account__536C85E4BAEDC554").IsUnique();

            entity.Property(e => e.Uid)
                .ValueGeneratedNever()
                .HasColumnName("UID");
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Username).HasMaxLength(255);

            entity.HasOne(d => d.Role).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Account__RoleId__3E52440B");

            entity.HasOne(d => d.UidNavigation).WithOne(p => p.Account)
                .HasForeignKey<Account>(d => d.Uid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Account__UID__3D5E1FD2");
        });

        modelBuilder.Entity<Banner>(entity =>
        {
            entity.HasKey(e => e.Idbanner).HasName("PK__Banner__A1B2D7B58731AD45");

            entity.ToTable("Banner");

            entity.Property(e => e.Idbanner)
                .ValueGeneratedNever()
                .HasColumnName("IDBanner");
            entity.Property(e => e.Link).HasMaxLength(100);
        });

        modelBuilder.Entity<ChiTietGioHang>(entity =>
        {
            entity.HasKey(e => e.IdchiTiet).HasName("PK__ChiTietG__EF38009B15A91466");

            entity.ToTable("ChiTietGioHang");

            entity.Property(e => e.IdchiTiet).HasColumnName("IDChiTiet");
            entity.Property(e => e.Gia).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.IdgioHang).HasColumnName("IDGioHang");
            entity.Property(e => e.IdsanPham)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IDSanPham");
            entity.Property(e => e.Idshop).HasColumnName("IDShop");
            entity.Property(e => e.ThanhTien)
                .HasComputedColumnSql("([SoLuong]*[Gia])", false)
                .HasColumnType("decimal(29, 2)");

            entity.HasOne(d => d.IdgioHangNavigation).WithMany(p => p.ChiTietGioHangs)
                .HasForeignKey(d => d.IdgioHang)
                .HasConstraintName("FK__ChiTietGi__IDGio__75A278F5");

            entity.HasOne(d => d.IdsanPhamNavigation).WithMany(p => p.ChiTietGioHangs)
                .HasForeignKey(d => d.IdsanPham)
                .HasConstraintName("FK__ChiTietGi__IDSan__76969D2E");

            entity.HasOne(d => d.IdshopNavigation).WithMany(p => p.ChiTietGioHangs)
                .HasForeignKey(d => d.Idshop)
                .HasConstraintName("FK_ChiTietGioHang_Shop");
        });

        modelBuilder.Entity<CthoaDon>(entity =>
        {
            entity.HasKey(e => new { e.IdhoaDon, e.IdsanPham }).HasName("PK__CTHoaDon__E25D3111729ED415");

            entity.ToTable("CTHoaDon");

            entity.Property(e => e.IdhoaDon)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IDHoaDon");
            entity.Property(e => e.IdsanPham)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IDSanPham");
            entity.Property(e => e.DonGia).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IdhoaDonNavigation).WithMany(p => p.CthoaDons)
                .HasForeignKey(d => d.IdhoaDon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CTHoaDon__IDHoaD__52593CB8");

            entity.HasOne(d => d.IdsanPhamNavigation).WithMany(p => p.CthoaDons)
                .HasForeignKey(d => d.IdsanPham)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CTHoaDon__IDSanP__534D60F1");
        });

        modelBuilder.Entity<DanhGium>(entity =>
        {
            entity.HasKey(e => e.IddanhGia).HasName("PK__DanhGia__C216E48D6CC50C22");

            entity.Property(e => e.IddanhGia)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IDDanhGia");
            entity.Property(e => e.IdsanPham)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IDSanPham");
            entity.Property(e => e.TieuDe).HasMaxLength(255);
            entity.Property(e => e.Uid).HasColumnName("UID");

            entity.HasOne(d => d.IdsanPhamNavigation).WithMany(p => p.DanhGia)
                .HasForeignKey(d => d.IdsanPham)
                .HasConstraintName("FK__DanhGia__IDSanPh__571DF1D5");

            entity.HasOne(d => d.UidNavigation).WithMany(p => p.DanhGia)
                .HasForeignKey(d => d.Uid)
                .HasConstraintName("FK__DanhGia__UID__5629CD9C");
        });

        modelBuilder.Entity<DanhMuc>(entity =>
        {
            entity.HasKey(e => e.IddanhMuc).HasName("PK__DanhMuc__DF6C0BD2F996F584");

            entity.ToTable("DanhMuc");

            entity.Property(e => e.IddanhMuc)
                .ValueGeneratedNever()
                .HasColumnName("IDDanhMuc");
            entity.Property(e => e.Ten).HasMaxLength(255);
        });

        modelBuilder.Entity<GioHang>(entity =>
        {
            entity.HasKey(e => e.IdgioHang).HasName("PK__GioHang__0B2CDDAE57DE9925");

            entity.ToTable("GioHang");

            entity.Property(e => e.IdgioHang).HasColumnName("IDGioHang");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Uid).HasColumnName("UID");

            entity.HasOne(d => d.UidNavigation).WithMany(p => p.GioHangs)
                .HasForeignKey(d => d.Uid)
                .HasConstraintName("FK__GioHang__UID__71D1E811");
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasKey(e => e.IdhoaDon).HasName("PK__HoaDon__5B896F49D7290190");

            entity.ToTable("HoaDon");

            entity.Property(e => e.IdhoaDon)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IDHoaDon");
            entity.Property(e => e.Idshop).HasColumnName("IDShop");
            entity.Property(e => e.Idvouchers)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IDVouchers");
            entity.Property(e => e.ThanhTien).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TrangThai).HasMaxLength(50);
            entity.Property(e => e.Uid).HasColumnName("UID");

            entity.HasOne(d => d.IdshopNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.Idshop)
                .HasConstraintName("FK_HoaDon_Shop");

            entity.HasOne(d => d.IdvouchersNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.Idvouchers)
                .HasConstraintName("FK__HoaDon__IDVouche__4F7CD00D");

            entity.HasOne(d => d.UidNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.Uid)
                .HasConstraintName("FK__HoaDon__UID__4E88ABD4");
        });

        modelBuilder.Entity<Loai>(entity =>
        {
            entity.HasKey(e => e.Idloai).HasName("PK__Loai__CA55DD6713CD846D");

            entity.ToTable("Loai");

            entity.Property(e => e.Idloai)
                .ValueGeneratedNever()
                .HasColumnName("IDLoai");
            entity.Property(e => e.IddanhMuc).HasColumnName("IDDanhMuc");
            entity.Property(e => e.Ten).HasMaxLength(255);

            entity.HasOne(d => d.IddanhMucNavigation).WithMany(p => p.Loais)
                .HasForeignKey(d => d.IddanhMuc)
                .HasConstraintName("FK__Loai__IDDanhMuc__45F365D3");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__8AFACE1AF8063279");

            entity.ToTable("Role");

            entity.Property(e => e.RoleId).ValueGeneratedNever();
            entity.Property(e => e.RoleName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.HasKey(e => e.IdsanPham).HasName("PK__SanPham__9D45E58A3F9A2790");

            entity.ToTable("SanPham");

            entity.Property(e => e.IdsanPham)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IDSanPham");
            entity.Property(e => e.GiaBan).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Idloai).HasColumnName("IDLoai");
            entity.Property(e => e.Idshop).HasColumnName("IDShop");
            entity.Property(e => e.Ten).HasMaxLength(255);

            entity.HasOne(d => d.IdloaiNavigation).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.Idloai)
                .HasConstraintName("FK__SanPham__IDLoai__48CFD27E");

            entity.HasOne(d => d.IdshopNavigation).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.Idshop)
                .HasConstraintName("FK__SanPham__IDShop__49C3F6B7");
        });

        modelBuilder.Entity<Shop>(entity =>
        {
            entity.HasKey(e => e.Idshop).HasName("PK__Shops__C5255028C985D562");

            entity.Property(e => e.Idshop)
                .ValueGeneratedNever()
                .HasColumnName("IDShop");
            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.TenShop).HasMaxLength(255);
            entity.Property(e => e.Uid).HasColumnName("UID");

            entity.HasOne(d => d.UidNavigation).WithMany(p => p.Shops)
                .HasForeignKey(d => d.Uid)
                .HasConstraintName("FK__Shops__UID__412EB0B6");
        });

        modelBuilder.Entity<Ultility>(entity =>
        {
            entity.HasKey(e => e.IdtienIch).HasName("PK__Ultility__4D2097D2BC68B182");

            entity.ToTable("Ultility");

            entity.Property(e => e.IdtienIch)
                .ValueGeneratedNever()
                .HasColumnName("IDTienIch");
            entity.Property(e => e.PhamViApDung).HasMaxLength(255);
            entity.Property(e => e.Ten).HasMaxLength(255);

            entity.HasMany(d => d.Uids).WithMany(p => p.IdtienIches)
                .UsingEntity<Dictionary<string, object>>(
                    "MyUtility",
                    r => r.HasOne<Account>().WithMany()
                        .HasForeignKey("Uid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__MyUtility__UID__5CD6CB2B"),
                    l => l.HasOne<Ultility>().WithMany()
                        .HasForeignKey("IdtienIch")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__MyUtility__IDTie__5BE2A6F2"),
                    j =>
                    {
                        j.HasKey("IdtienIch", "Uid").HasName("PK__MyUtilit__717B8EB2B5AE7381");
                        j.ToTable("MyUtility");
                        j.IndexerProperty<int>("IdtienIch").HasColumnName("IDTienIch");
                        j.IndexerProperty<Guid>("Uid").HasColumnName("UID");
                    });
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Uid).HasName("PK__User__C5B19602C67B7E3C");

            entity.ToTable("User");

            entity.HasIndex(e => e.Sdt, "UQ__User__CA1930A589C31846").IsUnique();

            entity.Property(e => e.Uid)
                .ValueGeneratedNever()
                .HasColumnName("UID");
            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.HoTen).HasMaxLength(255);
            entity.Property(e => e.Sdt)
                .HasMaxLength(20)
                .HasColumnName("SDT");
        });

        modelBuilder.Entity<Voucher>(entity =>
        {
            entity.HasKey(e => e.Idvouchers).HasName("PK__Vouchers__6D49019B1C1EE060");

            entity.Property(e => e.Idvouchers)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IDVouchers");
            entity.Property(e => e.DonViTinh).HasMaxLength(50);
            entity.Property(e => e.Giam).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PhamViApDung).HasMaxLength(255);
            entity.Property(e => e.Ten).HasMaxLength(255);

            entity.HasMany(d => d.Uids).WithMany(p => p.Idvouchers)
                .UsingEntity<Dictionary<string, object>>(
                    "MyVoucher",
                    r => r.HasOne<Account>().WithMany()
                        .HasForeignKey("Uid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__MyVouchers__UID__60A75C0F"),
                    l => l.HasOne<Voucher>().WithMany()
                        .HasForeignKey("Idvouchers")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__MyVoucher__IDVou__5FB337D6"),
                    j =>
                    {
                        j.HasKey("Idvouchers", "Uid").HasName("PK__MyVouche__511218FBD49D0B14");
                        j.ToTable("MyVouchers");
                        j.IndexerProperty<string>("Idvouchers")
                            .HasMaxLength(50)
                            .IsUnicode(false)
                            .HasColumnName("IDVouchers");
                        j.IndexerProperty<Guid>("Uid").HasColumnName("UID");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
