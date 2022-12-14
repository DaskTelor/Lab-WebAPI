﻿namespace Lab_WebAPI.Storage
{
    public interface IStorage<T> where T : class
    {
        List<T> All { get; }
        T this[Guid id] { get; set; }
        void Add(T value);
        void RemoveAt(Guid id);
        bool Has(Guid id);
    }
}
