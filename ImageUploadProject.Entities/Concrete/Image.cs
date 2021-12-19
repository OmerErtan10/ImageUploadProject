using ImageUploadProject.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageUploadProject.Entities.Concrete
{
    public class Image : ITable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
    }
}
