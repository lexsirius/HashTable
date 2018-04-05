using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTable
{
    public class TableElement
    {
        public int Bucket { get; set; }
        public object Key { get; set; }
        public object Value { get; set; }

        /// <summary>
        /// Конструктор ячейки хэш -таблицы
        /// <param name="bucket">Хэш-значение ключа</param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public TableElement(int bucket, object key, object value)
        {
            Bucket = bucket;
            Key = key;
            Value = value;
        }
    }
    public class HashTable
    {
        public int Size { get; set; }
        public List<TableElement> Table;

        /// <summary>
        /// Конструктор контейнера
        /// <param name="size">Размер хэш-таблицы</param>
        public HashTable(int size)
        {
            Size = size;
            Table = new List<TableElement>(size);
        }

        /// <summary>
        /// Метод, складывающий пару ключ-значение в таблицу
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void PutPair(object key, object value)
        { 
            var bucket = GetBucket(key);
            var element = new TableElement(bucket, key, value);
            var elemIndex = 0;
            if (Table.Count != 0)
            {
                elemIndex = FindBucket(bucket);
            }
            if (elemIndex == -1)
            {
                Table.Add(element);
            }
            else
            {
                Table.Insert(elemIndex, element);
            }
        }

        /// <summary>
        /// Поиск значения по ключу
        /// </summary>
        /// <param name="key">Ключ</param>
        /// <returns>Значение, null если ключ отсутствует</returns>
        public object GetValueByKey(object key)
        {
            var bucket = GetBucket(key);
            var elemIndex = FindBucket(bucket);
            if (elemIndex == -1 || !key.Equals(Table[elemIndex].Key))
            {
                return null;
            }
            return Table[elemIndex].Value;
        }

        /// <summary>
        /// Поиск индекса корзины для пары ключ-значение
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Хэш-значение ключа</returns>
        public int GetBucket(object key)
        {
            return key.GetHashCode() % Size;
        }

        /// <summary>
        /// Поиск индекса элемента по корзине
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Индекс ячейки таблицы, -1 если отсутствует</returns>
        public int FindBucket(int index)
        {
            var count = Table.Count;
            for(int i = 0; i < count; i++)
            {
                if (Table[i].Bucket == index)
                    return i;
            }
            return -1;
        }
    }
}
