using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace PhoneBook_v2._0
{
    class PhoneBook : IList<Record>
    {
        private Record[] _records;
        private const string FilePath = @"MyPhoneBook.dat";

        public PhoneBook()
        {
            _records = GetRecordsFromFile();
        }

        public Record this[int index]
        {
            get { return _records[index]; }
            set { _records[index] = value; UpdatingFileRecords(); }

        }

        public Record this[string name]
        {
            get
            {
                for (int i = 0; i < _records.Length; i++)
                {
                    if (name == _records[i].Name)
                    {
                        return _records[i];
                    }
                }
                return null;
            }
        }

        public int Count
        {
            get
            {
                int count = 0;
                for (int i = 0; i < _records.Length; i++)
                {
                    if (_records[i] != null)
                    {
                        count++;
                    }
                }
                return count;
            }
        }

        public bool IsReadOnly => false;

        public void Add(Record item)
        {
            Record[] tempRecords = new Record[_records.Length + 1];
            _records.CopyTo(tempRecords, 0);
            tempRecords[_records.Length] = item;
            _records = tempRecords;
            UpdatingFileRecords();
        }

        public void Clear()
        {
            _records = new Record[0];
            UpdatingFileRecords();
        }

        public bool Contains(Record item)
        {
            for (int i = 0; i < _records.Length; i++)
            {
                if (_records[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(Record[] array, int arrayIndex)
        {
            if (array.Length < Count - arrayIndex)
            {
                int index = 0;
                for (int i = arrayIndex; i < Count; i++)
                {
                    array[index++] = _records[i];
                }
            }
            throw new IndexOutOfRangeException();
        }

        public int IndexOf(Record item)
        {
            for (int i = 0; i < _records.Length; i++)
            {
                if (item.Equals(_records[i]))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, Record item)
        {
            Record[] tempRecords = new Record[_records.Length + 1];
            int tempIndex = 0;
            for (int i = 0; i < tempRecords.Length; i++)
            {
                if (i != index)
                {
                    tempRecords[i] = _records[tempIndex++];
                }
                else
                {
                    tempRecords[i] = item;
                }
            }
            _records = tempRecords;
            UpdatingFileRecords();
        }

        public bool Remove(Record item)
        {
            try
            {
                RemoveAt(IndexOf(item));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void RemoveAt(int index)
        {
            if (index < _records.Length && index >= 0)
            {
                Record[] newRecord = new Record[_records.Length - 1];
                int tempIndex = 0;
                for (int i = 0; i < _records.Length; i++)
                {
                    if (i != index)
                    {
                        newRecord[tempIndex++] = _records[i];
                    }
                }
                _records = newRecord;
                UpdatingFileRecords();
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void RemoveAll(Record item)
        {
            if (Contains(item))
            {
                List<Record> listRecord = new List<Record>();
                for (int i = 0; i < _records.Length; i++)
                {
                    if (!_records[i].Equals(item))
                    {
                        listRecord.Add(_records[i]);
                    }
                }
                _records = listRecord.ToArray();
                UpdatingFileRecords();
            }
            else
            {
                throw new Exception("Item not found for removal");
            }
        }

        public IEnumerator<Record> GetEnumerator()
        {
            foreach (Record item in _records)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private Record[] GetRecordsFromFile()
        {
            List<Record> recordList = new List<Record>();
            using (FileStream fs = File.Open(FilePath,
                FileMode.OpenOrCreate, FileAccess.Read, FileShare.None))
            {}
            using (StreamReader reader = new StreamReader(FilePath))
            {
                string name = null;
                string phone = null;
                bool flag = true;
                string input = null;
                while ((input = reader.ReadLine()) != null)
                {
                    if (flag)
                        name = input;
                    if (!flag)
                        phone = input;
                    if (flag == false)
                        recordList.Add(new Record(name, phone));
                    flag = !flag;
                }
                return recordList.ToArray();
            }
        }

        private void UpdatingFileRecords()
        {
            using (StreamWriter writer = new StreamWriter(FilePath))
            {
                foreach (Record item in _records)
                {
                    bool flag = true;
                    string name = item.Name;
                    string phone = item.Phone;
                    do
                    {
                        if (flag)
                        {
                            writer.WriteLine(name);
                        }
                        if (!flag)
                        {
                            writer.WriteLine(phone);
                        }
                        flag = !flag;
                    } while (!flag);
                }
            }
        }
    }
}