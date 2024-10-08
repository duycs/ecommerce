using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace ECommerce.Shared.SeedWork
{
    public abstract class Enumeration : IComparable
    {
        [Key]
        [JsonProperty(PropertyName = "Id")]
        public int Id { get; private set; }

        [JsonProperty(PropertyName = "Name")]
        public string Name { get; private set; }

        protected Enumeration()
        {
        }

        protected Enumeration(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }

        public static IEnumerable<T> GetAll<T>() where T : Enumeration, new()
        {
            FieldInfo[] fields = typeof(T).GetFields(BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.Public);
            FieldInfo[] array = fields;
            foreach (FieldInfo obj in array)
            {
                T obj2 = new T();
                T val = obj.GetValue(obj2) as T;
                if (val != null)
                {
                    yield return val;
                }
            }
        }

        public override bool Equals(object obj)
        {
            Enumeration enumeration = obj as Enumeration;
            if (enumeration == null)
            {
                return false;
            }

            bool num = GetType() == obj.GetType();
            bool flag = Id.Equals(enumeration.Id);
            return num && flag;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static int AbsoluteDifference(Enumeration firstValue, Enumeration secondValue)
        {
            return Math.Abs(firstValue.Id - secondValue.Id);
        }

        public static T FromValue<T>(int value) where T : Enumeration, new()
        {
            return Parse(value, "value", (T item) => item.Id == value);
        }

        public static List<T> FromValues<T>(IEnumerable<int> values) where T : Enumeration, new()
        {
            return values.Select((int a) => Parse(a, "value", (T item) => item.Id == a)).ToList();
        }

        public static T FromDisplayName<T>(string displayName) where T : Enumeration, new()
        {
            return Parse(displayName, "display name", (T item) => item.Name.Equals(displayName, StringComparison.InvariantCultureIgnoreCase));
        }

        private static T Parse<T, TK>(TK value, string description, Func<T, bool> predicate) where T : Enumeration, new()
        {
            return GetAll<T>().FirstOrDefault(predicate) ?? throw new ArgumentOutOfRangeException($"'{value}' is not a valid {description} in {typeof(T)}");
        }

        public int CompareTo(object other)
        {
            return Id.CompareTo(((Enumeration)other).Id);
        }
    }
}
