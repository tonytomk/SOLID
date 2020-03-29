using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns
{
    public enum Relationship
    {
        Parent,
        Child,
        Sibling
    }

    public class Person
    {
        public string Name;
    }

    public interface  IRelationshipBrowser
    {
        IEnumerable<Person> FindAllChildren(string name);
    }
    // Low-level
    public class Relationships : IRelationshipBrowser
    {
        private List<(Person, Relationship, Person)> relations
            = new List<(Person, Relationship, Person)>();

        public void AddParentAndChild(Person parent, Person child)
        {
            relations.Add((parent, Relationship.Parent, child));
            relations.Add((child, Relationship.Child, parent));
        }

        public IEnumerable<Person> FindAllChildren(string name)
        {

            foreach (var r in relations.Where(x =>
                x.Item1.Name == name && x.Item2 == Relationship.Parent))
            {
                yield return r.Item3;
            }
        }

        // public List<(Person, Relationship, Person)> Relations => relations;

    }

    /// <summary>
    /// The program_ dip.
    /// </summary>
    public class Program_DIP
    {
        //public Program_DIP(Relationships relationships)
        //{
        //    var relations = relationships.Relations;
        //    foreach (var r in relations.Where( x => 
        //        x.Item1.Name == "John" && x.Item2 == Relationship.Parent))
        //    {
        //        Console.WriteLine($"John has a child named : {r.Item3.Name}");
        //    }

        //}
        public Program_DIP(IRelationshipBrowser browser)
        { 
            foreach (var p in browser.FindAllChildren("John"))
            {
                Console.WriteLine($"John has a child named : {p.Name}");
            }

        }
        public static  void Main(string[] args)
        {
            var parent = new Person {Name = "John"};
            var child1 = new Person { Name = "Izabel" };
            var child2 = new Person { Name = "Thor" };

            var relationships = new Relationships();
            relationships.AddParentAndChild(parent,child1);
            relationships.AddParentAndChild(parent,child2);

            new Program_DIP(relationships);
        }
    }
}
