using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Set_Theory_Operator_Overloading_UnitTests.Data_Structures
{
    public class Iterators
    {
        [Fact]
        public void Add()
        {
            Set_Theory_Operator_Overloading_LIB.Interfaces.ISet<int> INIT = new Set_Theory_Operator_Overloading_LIB.Sets.Set<int>(new int[0]);
            var ValueArray = INIT.GetValues();
            INIT.Add<int>(ref ValueArray, 10);
            Assert.Equal(10, ValueArray[0]);
        }

        [Fact]
        public void Intersection()
        {
            Set_Theory_Operator_Overloading_LIB.Interfaces.ISet<int> INIT = new Set_Theory_Operator_Overloading_LIB.Sets.Set<int>(new int[0]);
            var ValueArray = INIT.GetValues();
            INIT.Add<int>(ref ValueArray, 10);
            INIT.Add<int>(ref ValueArray, 20);
            INIT.Add<int>(ref ValueArray, 30);
            Set_Theory_Operator_Overloading_LIB.Interfaces.ISet<int> INIT2 = new Set_Theory_Operator_Overloading_LIB.Sets.Set<int>(new int[0]);
            var ValueArray2 = INIT2.GetValues();
            INIT2.Add<int>(ref ValueArray2, 10);
            INIT2.Add<int>(ref ValueArray2, 20);
            INIT2.Add<int>(ref ValueArray2, 30);
            var INTERSECTION = INIT2.Intersection<int>(ref ValueArray, ref ValueArray2);
            Assert.Equal(3, INTERSECTION.GetValues().Length);

        }

        [Fact]
        public void Complement()
        {
            Set_Theory_Operator_Overloading_LIB.Interfaces.ISet<int> INIT = new Set_Theory_Operator_Overloading_LIB.Sets.Set<int>(new int[0]);
            var ValueArray = INIT.GetValues();
            INIT.Add<int>(ref ValueArray, 10);
            INIT.Add<int>(ref ValueArray, 20);
            INIT.Add<int>(ref ValueArray, 30);
            Set_Theory_Operator_Overloading_LIB.Interfaces.ISet<int> INIT2 = new Set_Theory_Operator_Overloading_LIB.Sets.Set<int>(new int[0]);
            var ValueArray2 = INIT2.GetValues();
            INIT2.Add<int>(ref ValueArray2, 10);
            INIT2.Add<int>(ref ValueArray2, 20);
            INIT2.Add<int>(ref ValueArray2, 40);
            var COMPLEMENT = INIT2.Complement<int>(ref ValueArray, ref ValueArray2);
            Assert.Single(COMPLEMENT.GetValues());
        }

        [Fact]
        public void Remove()
        {
            Set_Theory_Operator_Overloading_LIB.Interfaces.ISet<int> INIT = new Set_Theory_Operator_Overloading_LIB.Sets.Set<int>(new int[0]);
            var ValueArray = INIT.GetValues();
            INIT.Add<int>(ref ValueArray, 10);
            INIT.Add<int>(ref ValueArray, 20);
            INIT.Add<int>(ref ValueArray, 30);
            INIT.Remove<int>(ref ValueArray, 10);
            Assert.Equal(2, ValueArray.Length);
        }

        [Fact]
        public void PowerSet()
        {
            Set_Theory_Operator_Overloading_LIB.Interfaces.ISet<int> INIT = new Set_Theory_Operator_Overloading_LIB.Sets.Set<int>(new int[0]);
            var ValueArray = INIT.GetValues();
            INIT.Add<int>(ref ValueArray, 10);
            INIT.Add<int>(ref ValueArray, 20);
            INIT.Add<int>(ref ValueArray, 30);
            var POWERSET = INIT.PowerSet(ref ValueArray);
            Assert.NotEmpty(POWERSET.GetValues());
        }
        [Fact]
        public void CartesianProduct()
        {
            Set_Theory_Operator_Overloading_LIB.Interfaces.ISet<int> INIT = new Set_Theory_Operator_Overloading_LIB.Sets.Set<int>(new int[0]);
            var ValueArray = INIT.GetValues();
            INIT.Add<int>(ref ValueArray, 10);
            INIT.Add<int>(ref ValueArray, 20);
            INIT.Add<int>(ref ValueArray, 30);
            Set_Theory_Operator_Overloading_LIB.Interfaces.ISet<int> INIT2 = new Set_Theory_Operator_Overloading_LIB.Sets.Set<int>(new int[0]);
            var ValueArray2 = INIT2.GetValues();
            INIT2.Add<int>(ref ValueArray2, 10);
            INIT2.Add<int>(ref ValueArray2, 20);
            INIT2.Add<int>(ref ValueArray2, 40);
            var CARTESIAN = INIT2.Complement<int>(ref ValueArray, ref ValueArray2);
            Assert.NotEmpty(CARTESIAN.GetValues());
        }

        [Fact]
        public void Count()
        {
            Set_Theory_Operator_Overloading_LIB.Interfaces.ISet<int> INIT = new Set_Theory_Operator_Overloading_LIB.Sets.Set<int>(new int[0]);
            var ValueArray = INIT.GetValues();
            INIT.Add<int>(ref ValueArray, 10);
            INIT.Add<int>(ref ValueArray, 20);
            INIT.Add<int>(ref ValueArray, 30);
            Assert.Equal(3,ValueArray.Length);
        }

        [Fact]
        public void Clear()
        {
            Set_Theory_Operator_Overloading_LIB.Interfaces.ISet<int> INIT = new Set_Theory_Operator_Overloading_LIB.Sets.Set<int>(new int[0]);
            var ValueArray = INIT.GetValues();
            INIT.Add<int>(ref ValueArray, 10);
            INIT.Add<int>(ref ValueArray, 20);
            INIT.Add<int>(ref ValueArray, 30);
            INIT.Clear(ref ValueArray);
            Assert.Empty(ValueArray);
        }

        [Fact]
        public void Contains()
        {
            Set_Theory_Operator_Overloading_LIB.Interfaces.ISet<int> INIT = new Set_Theory_Operator_Overloading_LIB.Sets.Set<int>(new int[0]);
            var ValueArray = INIT.GetValues();
            INIT.Add<int>(ref ValueArray, 10);
            INIT.Add<int>(ref ValueArray, 20);
            INIT.Add<int>(ref ValueArray, 30);
            Assert.Equal(3, INIT.Count<int>(ValueArray));
        }

    }
}
