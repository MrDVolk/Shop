﻿using System;

namespace Shop.Domain.Models
{
    public class Car : ICloneable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }
        public string Img { get; set; }
        public ushort Price { get; set; }
        public bool IsFavourite { get; set; }
        public bool Avaliable { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
