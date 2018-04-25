using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;

namespace CrowdSourcing.EntityCore.Entity
{
    public class DataEntity
    {
        public int Id { get; set; }
        public string PersonId { get; set; }
        public string PersonRoleId { get; set; }
        public string Description{ get; set; }
        public DateTime UploadTime { get; set; }
        public int IsDone { get; set; }

        public IdentityUserRole Uploader { get; set; }
        public ICollection<TaskDataEntity> TaskDatas { get; set; }
        public ICollection<FileEntity> Files { get; set; }
    }
}
