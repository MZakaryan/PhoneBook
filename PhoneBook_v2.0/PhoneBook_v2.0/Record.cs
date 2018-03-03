using System;

namespace PhoneBook_v2._0
{
    class Record
    {
        public string Name { get; set; }
        public string Phone { get; set; }

        public Record() : this("Unknown", "") {}

        public Record(string name, string phone)
        {
            Name = name;
            Phone = phone;
        }

        public override string ToString()
        {
            return $"{Name,-12}{Phone,-5}";
        }

        public override bool Equals(object obj)
        {
            Record record = (Record)obj;
            return record.Name == Name && record.Phone == Phone;
        }

        public override int GetHashCode()
        {
            return Name.ToLower().GetHashCode() * Phone.ToLower().GetHashCode();
        }
    }
}
