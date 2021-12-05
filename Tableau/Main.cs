using System;

namespace Tableau
{
    public class Main()
    {
        public static void main() 
        {
            Tableau<int> tab = new Tableau<int>(3);
            tab.insert(3, 0);
            tab.insert(2, 1);
            tab.insert(5, 2);
        }        
    }
}