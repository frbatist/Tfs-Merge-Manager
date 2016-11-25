using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TFS.Controladores;
using Microsoft.TeamFoundation.VersionControl.Client;
using System.Diagnostics;

namespace TFS
{
    public partial class frmItens : Form
    {
        private Tfs _tfs;
        private int _idChangeSet;
        private Change[] _changes;

        public frmItens(int idChangeSet, Tfs tfs)
        {
            InitializeComponent();
            _tfs = tfs;
            _idChangeSet = idChangeSet;
        }

        private async void frmItens_Load(object sender, EventArgs e)
        {
            _changes = await _tfs.ObterArquivosChangeSet(_idChangeSet);            
            lboxItens.DataSource = _changes.Select(d => d.Item.ServerItem.Substring(d.Item.ServerItem.LastIndexOf("/") + 1)).ToList();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lboxItens_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var change = _changes[lboxItens.SelectedIndex];
            _tfs.Abrir(change);
        }
    }
}
