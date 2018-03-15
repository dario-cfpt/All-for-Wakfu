/* Project : All for Wakfu
 * Description : Builder for Wakfu
 * Date : 15.03.2018
 * Author : GENGA Dario
 * © 2018
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_for_Wakfu
{
    public class Build
    {
        private const int MIN_LVL = 1;
        private const int MAX_LVL = 200;

        private int _lvl;
        private List<Item> _items;
        private Dictionary<string, int> _skills;
        private Dictionary<string, int> _stats;

        public Build(int lvl, List<Item> items)
        {
            Lvl = lvl;
            Items = items; // TODO : verify if we can transfer a list of item like this
        }

        public int Lvl {
            get => _lvl;
            set
            {
                if (value < MIN_LVL)
                {
                    value = MIN_LVL;
                }
                if (value > MAX_LVL)
                {
                    value = MAX_LVL;
                }
                _lvl = value;
            }
        }
        public List<Item> Items { get => _items; set => _items = value; }
        public Dictionary<string, int> Skills { get => _skills; set => _skills = value; }
        public Dictionary<string, int> Stats { get => _stats; set => _stats = value; }

        public Dictionary<string, int> CalculateStats(List<Item> items, Dictionary<string, int> skills)
        {
            // TODO develop this method later
            return null;
        }
    }
}
