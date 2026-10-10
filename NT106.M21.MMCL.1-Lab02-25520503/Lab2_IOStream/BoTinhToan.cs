using System;
using System.Globalization;

namespace Lab2_IOStream
{
    /// <summary>
    /// Tính giá trị biểu thức gồm + - * / và ngoặc đơn (không dùng DataTable.Compute).
    /// Đúng thứ tự ưu tiên: ngoặc, rồi * /, rồi + -.
    /// </summary>
    public class BoTinhToan
    {
        private string chuoi = "";
        private int viTri;

        public decimal TinhGiaTri(string bieuThuc)
        {
            chuoi = ChuanHoa(bieuThuc);
            viTri = 0;

            if (chuoi.Length == 0)
                throw new FormatException("Biểu thức rỗng");

            decimal ketQua = DocBieuThuc();

            if (viTri < chuoi.Length)
                throw new FormatException("Ký tự không hợp lệ: '" + chuoi[viTri] + "'");

            return ketQua;
        }

        // Đổi các dấu gạch/nhân/chia "đẹp" (– — − × ÷) về dấu ASCII và bỏ khoảng trắng
        private static string ChuanHoa(string s)
        {
            return s.Replace('–', '-').Replace('—', '-').Replace('−', '-')
                    .Replace('×', '*').Replace('÷', '/')
                    .Replace(" ", "").Replace("\t", "");
        }

        // bieuThuc = soHang { ('+' | '-') soHang }
        private decimal DocBieuThuc()
        {
            decimal ketQua = DocSoHang();
            while (viTri < chuoi.Length && (chuoi[viTri] == '+' || chuoi[viTri] == '-'))
            {
                char dau = chuoi[viTri++];
                decimal so = DocSoHang();
                ketQua = dau == '+' ? ketQua + so : ketQua - so;
            }
            return ketQua;
        }

        // soHang = nhanTo { ('*' | '/') nhanTo }
        private decimal DocSoHang()
        {
            decimal ketQua = DocNhanTo();
            while (viTri < chuoi.Length && (chuoi[viTri] == '*' || chuoi[viTri] == '/'))
            {
                char dau = chuoi[viTri++];
                decimal so = DocNhanTo();
                if (dau == '*')
                {
                    ketQua *= so;
                }
                else
                {
                    if (so == 0) throw new DivideByZeroException("Chia cho 0");
                    ketQua /= so;
                }
            }
            return ketQua;
        }

        // nhanTo = so | '(' bieuThuc ')' | ('-' | '+') nhanTo
        private decimal DocNhanTo()
        {
            if (viTri >= chuoi.Length)
                throw new FormatException("Biểu thức chưa đầy đủ");

            char c = chuoi[viTri];

            if (c == '-') { viTri++; return -DocNhanTo(); }
            if (c == '+') { viTri++; return DocNhanTo(); }

            if (c == '(')
            {
                viTri++;
                decimal ketQua = DocBieuThuc();
                if (viTri >= chuoi.Length || chuoi[viTri] != ')')
                    throw new FormatException("Thiếu dấu ')'");
                viTri++;
                return ketQua;
            }

            return DocSo();
        }

        private decimal DocSo()
        {
            int batDau = viTri;
            while (viTri < chuoi.Length && (char.IsDigit(chuoi[viTri]) || chuoi[viTri] == '.'))
            {
                viTri++;
            }

            if (batDau == viTri)
                throw new FormatException("Ký tự không hợp lệ: '" + chuoi[viTri] + "'");

            return decimal.Parse(chuoi.Substring(batDau, viTri - batDau),
                                 NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture);
        }
    }
}
