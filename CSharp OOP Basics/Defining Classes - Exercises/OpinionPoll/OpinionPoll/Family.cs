using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class Family
{
    private List<Person> family = new List<Person>();

    public Family()
    {
        this.family = new List<Person>();

    }

    public void AddMember(Person member)
    {
        this.family.Add(member);
    }

    public List<Person> GetMembersOlderThan30()
    {
        return this.family.Where(x => x.Age > 30).OrderBy(x => x.Name).ToList();
    }


}
