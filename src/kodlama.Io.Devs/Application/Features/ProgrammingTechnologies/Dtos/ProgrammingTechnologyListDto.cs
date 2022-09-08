﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingTechnologies.Dtos
{
    public class ProgrammingTechnologyListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProgrammingLanguageName { get; set; }
        public string ImageUrl { get; set; }
    }
}
