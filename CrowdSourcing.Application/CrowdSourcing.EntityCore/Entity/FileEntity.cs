namespace CrowdSourcing.EntityCore.Entity
{
    public class FileEntity
    {
        public int Id { get; set; }
        public int FileTypeId { get; set; }
        public int DataId { get; set; }
        public string Url { get; set; }

        public FileTypeEntity FileType { get; set; }
        public DataEntity Data { get; set; }
    }
}
