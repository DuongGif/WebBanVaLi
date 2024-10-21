using webBanVaLi.Models;
namespace webBanVaLi.Res
{
    public interface IloaispRespository
    {
        TLoaiSp Add(TLoaiSp loaisp);

        TLoaiSp Update(string maloai);

        TLoaiSp Delete(string maloai);

        TLoaiSp GetLoaiSp(string maloai);

        IEnumerable<TLoaiSp> GetAllLoaiSp();
    }
}
