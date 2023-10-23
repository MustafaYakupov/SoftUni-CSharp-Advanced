using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoeStore
{
    public class ShoeStore
    {
        public ShoeStore(string name, int storageCapacity)
        {
            this.Name = name;
            this.StorageCapacity = storageCapacity;
            this.Shoes = new List<Shoe>();
        }

        public string Name { get; set; }
        public int StorageCapacity { get; set; }
        public List<Shoe> Shoes { get; private set; }

        public int Count
        {
            get
            {
                return this.Shoes.Count;
            }
        }

        public string AddShoe(Shoe shoe)
        {
            if (this.StorageCapacity == this.Shoes.Count)
            {
                return "No more space in the storage room.";
            }
            else
            {
                this.Shoes.Add(shoe);
                return $"Successfully added {shoe.Type} {shoe.Material} pair of shoes to the store.";
            }
        }

        public int RemoveShoes(string material)
        {
            int removedCount = this.Shoes.FindAll(sh => sh.Material == material).Count;
            this.Shoes.RemoveAll(x => x.Material == material);

            return removedCount;
        }

        public List<Shoe> GetShoesByType(string type)
        {
            List<Shoe> resultList = new List<Shoe>();

            foreach (var shoe in this.Shoes)
            {
                if (shoe.Type.ToLower() == type.ToLower())
                {
                    resultList.Add(shoe);
                }
            }

            return resultList;
        }

        public Shoe GetShoeBySize(double size)
        { 
            return this.Shoes.FirstOrDefault(x => x.Size == size);
        }
        public string StockList(double size, string type)
        {
            List<Shoe> resultList = new List<Shoe>();
            resultList = this.Shoes.Where(x => x.Size == size).Where(x => x.Type == type).ToList();

            if (resultList.Any())
            {
                StringBuilder sb = new();
                sb.AppendLine($"Stock list for size {size} - {type} shoes:");

                foreach (var item in resultList)
                {
                    sb.AppendLine(item.ToString());
                }

                return sb.ToString().Trim();
            }
            else
            {
                return "No matches found!";
            }
        }
    }
}
