using GenericApi.Core.BaseModel;

namespace GenericApi.Bl.Dto
{
    public class ClassStudentDto : BaseEntityDto
    {
        public int ClassId { get; set; }
        public int StudentId { get; set; }
    }
}
