﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLib
{
    public interface IInterface
    {
        string P { get; set; }
        void GetResult();
    }

    public sealed class PClass
    {
        public int _intnum;
        public List<int> _list;
        public readonly int[] _mass;
        internal const string _stringField = "";
        protected internal int _intField;
        private static float _floatField;

        private static float FloatProperty
        {
            set
            {
                _floatField = value;
            }
            get
            {
                return _floatField;
            }
        }
        public int IntProperty
        {
            get
            {
                return _intField;
            }

            set
            {
                _intField = value;
            }
        }

        public void Method1(ref int num, float num2, out string str)
        {
            str = "hello";
        }

        public static int Method2()
        {
            return 0;
        }

        private List<int> Method3(List<string> list)
        {
            return null;
        }
    }

    public abstract class PClass2
    {
        public abstract int a { get; }

        public abstract void Method();
    }

    public class PClass3
    {
        public PClass3(int a)
        {

        }
        public virtual void MethodVirt()
        {
        }
    }
}

namespace StructEnumDelegate
{
    public enum Operation
    {
        Add = 2,
        Subtract = 4,
        Multiply = 8,
        Divide = 16
    }

    public delegate void Message();

    public struct User
    {
        public string name;
        public int age;

        public void ChooseOperation()
        {
            Operation op;
            op = Operation.Add;
        }
    }
}
