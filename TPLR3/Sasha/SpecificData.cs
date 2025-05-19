using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TPLR3.Sasha
{
    public abstract class SpecificData
    {
        public string name { get; }
        public SpecificData (string name)
        {
            this.name = name;
        }
        public abstract List<Object> GetListOfSpecificData();
        public abstract void AddToSpecificlist(Object data);
        public abstract void RemoveAt(int i);
    }
    public class FloatData: SpecificData
    {
        public List<float> specificData { get; set; }
        public FloatData(string name) : base(name)
        {
            this.specificData = new List<float>();
        }
        public override List<Object> GetListOfSpecificData()
        {
            List<Object> list = new List<Object>();
            foreach (var item in specificData)
                list.Add(item.ToString());
            return list;
        }
        public override void AddToSpecificlist(Object data)
        {
            specificData.Add(float.Parse(data.ToString()));
        }
        public override void RemoveAt(int i)
        {
            specificData.RemoveAt(i);
        }
    }
}
    
