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
    public class Searcher
    {
        private EncyclopediaDB _encyclopedia;

        public Searcher()
        {
            Encyclopedia = new EncyclopediaDB();
        }

        public EncyclopediaDB Encyclopedia { get => _encyclopedia; set => _encyclopedia = value; }

        public List<Item> SearchItems(string[] criteria = null)
        {
            // TODO later
            return null;
        }
    }
}
