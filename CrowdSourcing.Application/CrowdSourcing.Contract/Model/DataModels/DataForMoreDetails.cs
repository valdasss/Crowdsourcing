﻿using CrowdSourcing.Contract.Model.FileModels;
using System;
using System.Collections.Generic;

namespace CrowdSourcing.Contract.Model.DataModels
{
    public class DataForMoreDetails
    {
        public int DataId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Status { get; set; }
        public string UploaderComment { get; set; }
        public DateTime UploadDate { get; set; }
        public IEnumerable<FileForDetailsModel> Files { get; set; }
    }
}
