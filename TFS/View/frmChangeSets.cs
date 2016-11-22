using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TFS.Controladores;

namespace TFS
{
    public partial class frmChangeSets : Form
    {
        private Tfs _tfs; 
        public frmChangeSets()
        {
            InitializeComponent();            
            dataGridView1.AutoGenerateColumns = false;
            _tfs = new Tfs();
            tbUsuario.Text = _tfs.Usuario;
            tbCollection.Text = _tfs.Collection;
            Workspaces();
            tbBranchOrigem.Text = _tfs.BranchOrigem;
            tbBranchDestino.Text = _tfs.BranchDestino;
            tbCaminhoTfExe.Text = _tfs.CaminhoTfExe;
        }

        private void Workspaces()
        {
            var workspaces = _tfs.CarregaWorkspaces();
            cbWorkspace.DataSource = workspaces;
            if (workspaces.Length > 0)
            {
                if (string.IsNullOrEmpty(_tfs.Workspace))
                {
                    _tfs.Workspace = workspaces[0];
                }                    
                cbWorkspace.SelectedItem = _tfs.Workspace;                
            }
        }

        private void CarregaComboUsuarios()
        {
            var listausuarios = _tfs.ObterDesenvolvedores();
            cbUsuario.Items.Clear();
            cbUsuario.Items.AddRange(listausuarios);
        }

        private async Task CarregaChangeSetsCandidatos()
        {
            PannelAguarde pnlAguarde = new PannelAguarde(this);
            pnlAguarde.Mostra();

            await _tfs.ObterChangeSetsCandidatos();            
            dataGridView1.DataSource = _tfs.ChangesetsFiltrados;            
            CarregaComboUsuarios();

            pnlAguarde.Esconde();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (_tfs.PossuiPendingChanges())
            {
                MessageBox.Show("Existem alterações pendentes no workspace selecionando, realize checkin!");
                return;
            }
            frmMerge frmMerge = new frmMerge(_tfs);
            frmMerge.ShowDialog();
            if(frmMerge.Confirmado)
                await CarregaChangeSetsCandidatos();
        }

        private void cbUsuario_Leave(object sender, EventArgs e)
        {
            string[] selecionados = cbUsuario.CheckBoxItems.Where(d => d.Checked).Select(d => d.ComboBoxItem.ToString()).ToArray();

            if (selecionados.Length <= 0)
                return;

            _tfs.FiltraPorUsuarios(selecionados);
            dataGridView1.DataSource = _tfs.ChangesetsFiltrados;
        }

        private async void btnRecarregaChangesets_Click(object sender, EventArgs e)
        {
            try
            {
                await CarregaChangeSetsCandidatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnMarcaTodos_Click(object sender, EventArgs e)
        {
            bool marca = InverteSelecaoGrid();
            _tfs.InverterSelecao(marca);
            dataGridView1.Refresh();            
        }

        private bool InverteSelecaoGrid()
        {            
            if (btnMarcaTodos.Text == "Marca Todos")
            {
                btnMarcaTodos.Text = "Desmarca Todos";
                return true;
            }
            btnMarcaTodos.Text = "Marca Todos";            
            return false;
        }

        private void tbCollection_Validated(object sender, EventArgs e)
        {
            try
            {
                _tfs.Collection = tbCollection.Text;
                Workspaces();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                tbCollection.Focus();
                tbCollection.Select();
            }
        }

        private void tbUsuario_Validated(object sender, EventArgs e)
        {
            try
            {
                _tfs.Usuario = tbUsuario.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                tbUsuario.Focus();
                tbUsuario.Select();
            }
        }

        private void cbWorkspace_Validated(object sender, EventArgs e)
        {
            try
            {
                _tfs.Workspace = cbWorkspace.SelectedItem.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cbWorkspace.Focus();
                cbWorkspace.Select();
            }
        }

        private void tbBranchOrigem_Validated(object sender, EventArgs e)
        {
            try
            {
                _tfs.BranchOrigem = tbBranchOrigem.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                tbBranchOrigem.Focus();
                tbBranchOrigem.Select();
            }
        }

        private void tbBranchDestino_Validated(object sender, EventArgs e)
        {
            try
            {
                _tfs.BranchDestino = tbBranchDestino.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                tbBranchDestino.Focus();
                tbBranchDestino.Select();
            }
        }

        private void tbCaminhoTfExe_Validated(object sender, EventArgs e)
        {
            try
            {
                _tfs.CaminhoTfExe = tbCaminhoTfExe.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                tbCaminhoTfExe.Focus();
                tbCaminhoTfExe.Select();
            }
        }
    }
}
