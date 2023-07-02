using SaveSystem;

namespace Game.Tests
{
    public class FakeStorage<T> : ISaveStorage<T>
    {
        public bool HasSave()
        {
            return false;
        }

        public T Load()
        {
            return default;
        }

        public void Save(T value)
        {
        }

        public void DeleteSave()
        {
        }
    }
}