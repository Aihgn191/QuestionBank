namespace QuestionBank.Models
{
    public class MaTran
    {
        public Guid Id { get; set; }
        public Guid MaMonHoc {  get; set; }
        public Guid MaPhan { get; set; }
        public int Clo1 { get; set; }
        public int Clo2 { get; set; }
        public int Clo3 { get; set; }
        public int SoCauHoi { get; set; }
        public string TenPhan { get; set; }
    }
}
