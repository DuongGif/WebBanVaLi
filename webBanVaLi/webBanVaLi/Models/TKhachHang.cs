﻿using System;
using System.Collections.Generic;

namespace webBanVaLi.Models
{
    public partial class TKhachHang
    {
        public TKhachHang()
        {
            THoaDonBans = new HashSet<THoaDonBan>();
        }

        public string MaKhanhHang { get; set; } = null!;
        public string? Username { get; set; }
        public string? TenKhachHang { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string? SoDienThoai { get; set; }
        public string? DiaChi { get; set; }
        public byte? LoaiKhachHang { get; set; }
        public string? AnhDaiDien { get; set; }
        public string? GhiChu { get; set; }

        public virtual TUser? UsernameNavigation { get; set; }
        public virtual ICollection<THoaDonBan> THoaDonBans { get; set; }
    }
}
