using Lab_WebAPI.Exceptions;
using Lab_WebAPI.Models;

namespace Lab_WebAPI.Storage
{
    public class MemCache : IStorage<PersonalComputerData>
    {
        private object _sync = new object();
        private List<PersonalComputerData> _memCache = new List<PersonalComputerData>();
        public PersonalComputerData this[Guid id]
        {
            get
            {
                lock (_sync)
                {
                    if (!Has(id)) throw new IncorrectPersonalComputerDataException($"No PersonalComputerData with id {id}");

                    return _memCache.Single(x => x.Id == id);
                }
            }
            set
            {
                if (id == Guid.Empty) throw new IncorrectPersonalComputerDataException("Cannot request PersonalComputerData with an empty id");

                lock (_sync)
                {
                    if (Has(id))
                    {
                        RemoveAt(id);
                    }

                    value.Id = id;
                    _memCache.Add(value);
                }
            }
        }

        public List<PersonalComputerData> All => _memCache.Select(x => x).ToList();

        public void Add(PersonalComputerData value)
        {
            if (value.Id != Guid.Empty) throw new IncorrectPersonalComputerDataException($"Cannot add value with predefined id {value.Id}");

            value.Id = Guid.NewGuid();
            this[value.Id] = value;
        }

        public void Add(PersonalComputerData value, Guid Id)
        {
            if (value.Id != Guid.Empty) throw new IncorrectPersonalComputerDataException($"Cannot add value with predefined id {value.Id}");
            if (Id == Guid.Empty) throw new IncorrectPersonalComputerDataException($"Cannot add value incorrect id {Id}");

            value.Id = Id;
            this[value.Id] = value;
        }

        public bool Has(Guid id)
        {
            return _memCache.Any(x => x.Id == id);
        }

        public void RemoveAt(Guid id)
        {
            lock (_sync)
            {
                _memCache.RemoveAll(x => x.Id == id);
            }
        }
    }
}
