﻿using System;

namespace NetCore31Skeleton.Core.Dtos
{
    public class NoteDto 
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public long CategoryId { get; set; }
        public DateTime CreateTime { get; set; }

    }
}
