using Set_Theory_Operator_Overloading_LIB.Sets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Set_Theory_Operator_Overloading_LIB.Singletons
{
    public class IteratorsSingleton<T>
    {
        private static Set<T> _set;
        private static IteratorsSingleton<T> _singleton;
        private static Sets.List<T> _list;
        private static BinaryTree<T> _tree;
        private IteratorsSingleton()
        {

        }

        public static IteratorsSingleton<T> GetSingleton()
        {
            if (_singleton == null)
            {
                _singleton = new IteratorsSingleton<T>();
            }

            return _singleton;
        }

        public static Set<T> GetSet()
        {
            if (_list == null)
            {
                _list = new Sets.List<T>(new T[0]);
            }

            return _list;
        }

        public static Sets.List<T> GetList()
        {
            if (_list == null)
            {
                _list = new Sets.List<T>(new T[0]);
            }

            return _list;
        }

        public static BinaryTree<T> GetBinaryTree()
        {
            if (_tree == null)
            {
                _tree = new BinaryTree<T>();
            }

            return _tree;
        }
    }
}
