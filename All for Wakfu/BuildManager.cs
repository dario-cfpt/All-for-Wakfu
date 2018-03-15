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
    public class BuildManager
    {
        private Build _currentBuild;
        private List<Build> _builds;

        public BuildManager()
        {

        }

        public Build CurrentBuild { get => _currentBuild; set => _currentBuild = value; }
        public List<Build> Builds { get => _builds; set => _builds = value; }

        public void AddItemToBuild(Item item, Build build)
        {
            build.Items.Add(item);
        }

        public void RemoveItemToBuild(Item item, Build build)
        {
            build.Items.Remove(item);
        }

        public Build CreateBuild(int lvl, List<Item> items = null)
        {
            if (items == null)
            {
                items = new List<Item>();
            }

            Build build = new Build(lvl, items);
            Builds.Add(build);
            return build;
        }

        public void DeleteBuild(Build build)
        {
            Builds.Remove(build);
            if (CurrentBuild == build)
            {
                CurrentBuild = null; // not sure if necessary
            }
            build = null;
        }

    }
}
