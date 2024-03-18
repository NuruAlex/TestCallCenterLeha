namespace Notes.Serialization
{
    public abstract class UniqeCollection<T>
    {
        private List<T> _list;
      
        private readonly string _path;
       
        public List<T> Items
        {
            get
            {
                return _list;
            }
        }

        public int Count
        {
            get
            {
                return _list.Count;
            }
        }



        public UniqeCollection(string path)
        {
            _list = new JsonRetriever().LoadFromFile<T>(path);
            _path = path;
        }

        public void Refresh()
        {
            new JsonRetriever().SaveToFile(_list, _path);
            _list = new JsonRetriever().LoadFromFile<T>(_path);
        }


        public void Add(T item)
        {
            if (item == null || Contains(item))//не допускаем null и такой же элемент в коллекции
            {
                return;
            }

            _list.Add(item);
            Refresh();
        }
        public void Delete(Predicate<T> match)
        {
            _list.RemoveAll(match);
            Refresh();
        }



        public T? Find(Predicate<T> match)
        {
            return _list.Find(match);
        }
        public List<T> FindAll(Predicate<T> match)
        {
            return _list.FindAll(match);
        }
        public bool Contains(Predicate<T> match)
        {
            return Find(match) != null;
        }


        public abstract bool Contains(T item);
        public abstract void Delete(T item);

    }
}
