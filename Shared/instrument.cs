using System;
using System.Collections.Generic;
using System.Text;

namespace P8.Shared
{
    public class Instrument
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LeftInStock { get; set; }
        public int Price { get; set; }
        public string ImgAddress { get; set; }
        public int Chosen = 0;

        public override string ToString() =>
            $"{this.Name}, {this.Price}, {this.Id}, {this.LeftInStock}";

        public override int GetHashCode() =>
            this.Id;

        public override bool Equals(object obj)
        {
            var other = obj as Instrument;
            if(other==null) return false;
            return this.Id == other.Id;
        }
    }
}