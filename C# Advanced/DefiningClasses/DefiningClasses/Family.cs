using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        public Family()
        {
            People = new List<Person>();
        }
        public List<Person> People { get; set; }

        public void AddMember(Person member)
        {
            People.Add(member); 
        }

        public Person GetOldestMember()
        {
            Person person = People.OrderByDescending(x => x.Age).FirstOrDefault();

            return person;

            //int oldestMember = 0;
            //Person oldest = null;
            //for (int i = 0; i < People.Count; i++)
            //{
            //    if(People[i].Age>oldestMember)
            //    {
            //        oldest = People[i];
            //        oldestMember = oldest.Age;
            //    }
            //}
            //return oldest;
        }

        internal List<Person> Where(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }
    }
}
