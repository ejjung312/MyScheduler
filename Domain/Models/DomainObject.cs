using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class DomainObject
    {
        // [Key]: ORM 프레임워크에서 모델 클래스를 정의할 때 기본 키를 지정하는 데 사용
        [Key]
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreateDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime ModifiedDate { get; set; }
    }
}
