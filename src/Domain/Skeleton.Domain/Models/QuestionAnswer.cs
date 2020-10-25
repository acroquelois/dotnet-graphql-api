﻿using Skeleton.Domain.Core.Models;

namespace Skeleton.Domain.Models
{
    public class QuestionAnswer: BaseEntity<int>
    {
        public string Libelle { get; set; }
    }
}