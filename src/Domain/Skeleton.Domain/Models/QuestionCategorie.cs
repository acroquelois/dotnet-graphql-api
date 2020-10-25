﻿using Skeleton.Domain.Core.Models;

namespace Skeleton.Domain.Models
{
    public class QuestionCategorie: BaseEntity<int>
    {
        public string Libelle { get; set; }
    }
}