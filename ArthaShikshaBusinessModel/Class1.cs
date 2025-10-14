namespace ArthaShikshaBusinessModel
{
    public class Class1
    {

    }
    public class LMS_ProgramWiseReportCenter
    {
        public int Id { get; set; }

        public int? CourseTypeId { get; set; }

        public int? CourseTypeTableId { get; set; }

        public int? CourseCount { get; set; }

        public int? CompanyId { get; set; }

        public string? FileURL { get; set; }

        public int? IsActive { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public int? UpdatedBy { get; set; }

        public DateTime? UpdatedDateTime { get; set; }

        public string Status { get; set; }

    }
    public class ProgramWiseReportModelDto
    {
        public int Id { get; set; }

        public int? CourseTypeId { get; set; }
        public string ProgramType { get; set; }

        public int? CourseTypeTableId { get; set; }
        public string ProgramName { get; set; }

        public int? CourseCount { get; set; }

        public int? CompanyId { get; set; }

        public string FileURL { get; set; }

        public int? IsActive { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public int? UpdatedBy { get; set; }

        public DateTime? UpdatedDateTime { get; set; }

        public string Status { get; set; }
    }

}
