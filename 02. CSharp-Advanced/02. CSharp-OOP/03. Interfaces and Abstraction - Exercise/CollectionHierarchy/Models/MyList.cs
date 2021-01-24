using CollectionHierarchy.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CollectionHierarchy.Models
{
    public class MyList<T> : AddRemoveCollection<T>, IMyList<T>
    {
        private const int RemovalIndex = 0;

        public IReadOnlyCollection<T> Used
        {
            get
            {
                return this.Data as IReadOnlyCollection<T>;
            }
        }

        public override T Remove()
        {
            var firstElemennt = this.Data.First();
            this.Data.RemoveAt(RemovalIndex);
            return firstElemennt;
        }
    }
}