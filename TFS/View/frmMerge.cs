using System;
using System.Windows.Forms;
using TFS.Controladores;

namespace TFS
{
    public partial class frmMerge : Form
    {
        private Tfs _tfs;
        public bool Confirmado { get; set; }
        public frmMerge(Tfs tfs)
        {
            _tfs = tfs;
            _tfs.CarregaMerges();
            InitializeComponent();
            gridMerges.DataSource = _tfs.Merges;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnConfirmar_Click(object sender, EventArgs e)
        {
            PannelAguarde pnlAguarde = new PannelAguarde(this);
            pnlAguarde.Mostra();
            var resultado = await _tfs.RealizaMerges();
            pnlAguarde.Esconde();
            gridMerges.Refresh();
            while (resultado.Item2)
            {
                if (!string.IsNullOrEmpty(resultado.Item1))
                {
                    if (MessageBox.Show("Existem conflitos com o merge: " + resultado.Item1 + "... Pressione 'Sim' para continuar, e 'Não' para cancelar o procedimento.", "TFS", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        pnlAguarde.Mostra();
                        resultado = await _tfs.RealizaMerges();
                        pnlAguarde.Esconde();
                        gridMerges.Refresh();
                    }
                    else
                    {
                        if (MessageBox.Show("Deseja realizar rollback das alterações pedentes?", "TFS", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            _tfs.RollBackPendingChanges();
                        }
                        pnlAguarde.Esconde();
                        return;
                    }                    
                }
                pnlAguarde.Mostra();
                resultado = await _tfs.RealizaMerges();
                pnlAguarde.Esconde();
                gridMerges.Refresh();
            }            
            MessageBox.Show("Merges/Checkins realizados com sucesso!");
            Confirmado = true;
        }
    }
}
