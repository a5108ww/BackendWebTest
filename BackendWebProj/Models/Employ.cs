using System.ComponentModel.DataAnnotations.Schema;

namespace BackendWebProj.Models
{
    public class Employ : AbstractEntity
    {
        public string name { get; set; }
        public DateTime? dateOfBirth { get; set; }

        [NotMapped]
        public string dateOfBirthString {
            get { return dateOfBirth != null ? Convert.ToDateTime(dateOfBirth).ToString("yyyy-MM-dd") : ""; }
            set { }
        }
        public int salary { get; set; }
        public string address { get; set; }
    }
}
