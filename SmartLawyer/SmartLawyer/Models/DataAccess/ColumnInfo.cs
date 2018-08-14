using System;

namespace SmartLawyer.Models
{
    public class ColumnInfo
    {
        public string Name { get; private set; }
        public Type Type { get; private set; }
        public int? Length { get; private set; }

        public static implicit operator ColumnInfo((string name, Type type, int length) v)
            => new ColumnInfo
            {
                Length = v.length,
                Name = v.name,
                Type = v.type,
            };
        public static implicit operator ColumnInfo((string name, Type type) v)
          => new ColumnInfo
          {
              Name = v.name,
              Type = v.type,
          };
        public static implicit operator ColumnInfo((string name, int length) v)
      => new ColumnInfo
      {
          Name = v.name,
          Type = typeof(string),
          Length = v.length
      };
        public static implicit operator ColumnInfo(string name)
         => new ColumnInfo
         {
             Name = name,
             Type = typeof(string),
         };

        public static implicit operator string(ColumnInfo ntl) => ntl.Name;
        public override string ToString() => this.Name;
    }
}