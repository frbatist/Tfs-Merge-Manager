using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TFS
{    
    public class PannelAguarde
    {
        private Panel _pnl;
        private Control _parent;
        public PannelAguarde(Control parent)
        {
            _parent = parent;
            _pnl = new Panel();
            _pnl.BorderStyle = BorderStyle.FixedSingle;
            _pnl.Width = 210;
            _pnl.Height = 50;
            _pnl.Top = (_parent.Height - _pnl.Height) / 2;
            _pnl.Left = (_parent.Width - _pnl.Width) / 2;
            var label = new Label();
            label.Height = _pnl.Height;
            label.Width = _pnl.Width;
            label.Text = "Carregando...";
            label.Font = new Font("Arial", 24);
            label.ForeColor = Color.Blue;
            label.Top = 5;
            _pnl.Controls.Add(label);
        }

        public void Mostra(params Control[] bloqueados)
        {
            foreach (Control item in _parent.Controls)
            {
                if (!bloqueados.Contains(item))
                {
                    item.Enabled = false;
                }
            }
            _parent.Controls.Add(_pnl);
            _parent.Resize += _parent_Resize;
            _pnl.BringToFront();
        }

        private void _parent_Resize(object sender, EventArgs e)
        {
            _pnl.Top = (_parent.Height - _pnl.Height) / 2;
            _pnl.Left = (_parent.Width - _pnl.Width) / 2;
        }

        public void Esconde(params Control[] bloqueados)
        {
            foreach (Control item in _parent.Controls)
            {
                if (!bloqueados.Contains(item))
                {
                    item.Enabled = true;
                }
            }
            _parent.Controls.Remove(_pnl);            
        }
    }
}
