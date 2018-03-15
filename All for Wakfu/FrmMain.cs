/* Project : All for Wakfu
 * Description : Builder for Wakfu
 * Date : 15.03.2018
 * Author : GENGA Dario
 * © 2018
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace All_for_Wakfu
{
    public partial class FrmMain : Form
    {
        private BuildManager _builder;
        private Searcher _searcher;
        private int _searchIndex;

        public FrmMain()
        {
            InitializeComponent();
            Builder = new BuildManager();
            Searcher = new Searcher();
        }

        public BuildManager Builder { get => _builder; set => _builder = value; }
        public Searcher Searcher { get => _searcher; set => _searcher = value; }
        public int SearchIndex { get => _searchIndex; set => _searchIndex = value; }

        private void UpdateView()
        {

        }

        private void ShowNext()
        {

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            // this is for the testing only !
            Searcher.Encyclopedia.UpdateDB();
        }

    }
}
