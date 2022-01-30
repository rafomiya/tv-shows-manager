using System;
using System.Collections.Generic;
using System.Linq;

namespace shows.Models
{
    public class ShowsList : List<Show>, IEntity<Show>
    {
        static ShowsList _instance;
        public static ShowsList GetInstance()
        {
            if (_instance == null)
                _instance = new ShowsList();

            return _instance;
        }
        public void Create(Show entity)
        {
            this.Add(entity);
        }
        public List<Show> Read()
        {
            return this.Where(x => !x.IsDeleted).ToList();
        }
        public Show Read(Guid id)
        {
            return this.FirstOrDefault(x => !x.IsDeleted && x.Id == id);
        }
        public void Update(Show entity)
        {
            int index = this.IndexOf(this.FirstOrDefault(x => !x.IsDeleted && x.Id == entity.Id));

            if (index != -1)
                this[index] = entity;
        }
        public void Delete(Guid id)
        {
            int index = this.IndexOf(this.FirstOrDefault(x => x.Id == id));

            this[index].IsDeleted = true;
        }
        private ShowsList() { }
        public override string ToString()
        {
            string result = "";

            foreach (Show show in this.Read())
                result += show.ToString() + "\n";

            return result;
        }
    }
}