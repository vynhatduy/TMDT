namespace TMDT.Models
{
    public class GetObject
    {
        public static List<Voucher> GetListVouchersById(string IDVoucher)
        {
            var ds = new List<Voucher>();
            using (var _context = new TMDTContext())
            {
                var voucher = _context.Vouchers.FirstOrDefault(x => x.Idvouchers == IDVoucher);
                ds.Add(voucher);
                return ds;
            }
        }
    }
}
