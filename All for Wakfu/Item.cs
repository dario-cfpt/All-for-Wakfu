/* Project : All for Wakfu
 * Description : Builder for Wakfu
 * Date : 15.03.2018
 * Author : GENGA Dario
 * © 2018
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_for_Wakfu
{
    public class Item
    {
        private int _id;
        private string _name;
        private Image _img;
        private string _typeItem;
        private int _rarity;
        private int _lvl;
        private string _url;
        private Dictionary<string, int> _stats;

        public Item(int id, string name, Image img, string typeItem, int rarity, int lvl, string url, Dictionary<string, int> stats)
        {
            Id = id;
            Name = name;
            Img = img;
            TypeItem = typeItem;
            Rarity = rarity;
            Lvl = lvl;
            Url = url;
            Stats = stats;
        }

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public Image Img { get => _img; set => _img = value; }
        public string TypeItem { get => _typeItem; set => _typeItem = value; }
        public int Rarity { get => _rarity; set => _rarity = value; }
        public int Lvl { get => _lvl; set => _lvl = value; }
        public string Url { get => _url; set => _url = value; }
        public Dictionary<string, int> Stats { get => _stats; set => _stats = value; }
    }
}
