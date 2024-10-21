using webBanVaLi.Models;

namespace webBanVaLi.Res
{
    public class loaispRespository : IloaispRespository
    {
        private readonly QLBanVaLiContext _context;

        public loaispRespository(QLBanVaLiContext context)
        {
            _context = context;
        }


        public TLoaiSp Add(TLoaiSp loaisp)
        {
            _context.Add(loaisp);
            _context.SaveChanges();
            return loaisp;
        }

        public TLoaiSp Delete(string maloai)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TLoaiSp> GetAllLoaiSp()
        {
            return _context.TLoaiSps;
        }

        public TLoaiSp GetLoaiSp(string maloai)
        {
           return _context.TLoaiSps.Find(maloai);
        }

        public TLoaiSp Update(TLoaiSp loaiSp)
        {
           _context.Update(loaiSp);
            _context.SaveChanges();
            return loaiSp;
        }

        public TLoaiSp Update(string maloai)
        {
            throw new NotImplementedException();
        }
    }
}
