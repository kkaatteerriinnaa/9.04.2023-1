using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp47
{
    interface IVisitor
    {
        void visit(Bank e);
        void visit(House e);
        void visit(Fabric e);
    }
    interface BuildingType
    {
        string insurance { get; set; }
        void Accept(IVisitor visitor);
    }
    class Bank:BuildingType
    {
        public string insurance { get; set; } = "Bank interface";
        public void Accept(IVisitor visitor)
        {
            visitor.visit(this);
        }
    }
    class House:BuildingType
    {
        public string insurance { get; set; } = "House interface";
        public void Accept(IVisitor visitor)
        {
            visitor.visit(this);
        }
    }
    class Fabric : BuildingType
    {
        public string insurance { get; set; } = "Fabric interface";
        public void Accept(IVisitor visitor)
        {
            visitor.visit(this);
        }
    }
    class InsuranceAgent:IVisitor
    {
        public void visit(Bank e)
        {
            Console.WriteLine($"{e.insurance} in is insurance type bank");
        }
        public void visit(House e)
        {
            Console.WriteLine($"{e.insurance} in is insurance type bank");
        }
        public void visit(Fabric e)
        {
            Console.WriteLine($"{e.insurance} in is insurance type bank");
        }
    }
    class Client
    {
        List<BuildingType> build = new List<BuildingType>();
        public void Add(ref BuildingType b)
        {
            build.Add(b);
        }
        public void Remove(ref BuildingType b)
        {
            build.Remove(b);
        }
        public void Accept(ref IVisitor visitor)
        {
            foreach(var b in build)
            {
                b.Accept(visitor);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            BuildingType house = new House();
            BuildingType fabric = new Fabric();
            BuildingType bank = new Bank();
            IVisitor i = new InsuranceAgent();
            client.Add(ref house);
            client.Add(ref fabric);
            client.Add(ref bank);
            client.Accept(ref i);
        }
    }
}
