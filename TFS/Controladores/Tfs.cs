using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.VersionControl.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TFS.Modelos;

namespace TFS.Controladores
{
    public class Tfs
    {        
        public List<ChangeSet> ChangeSetsCandidatos { get; set; }
        public List<ChangeSet> ChangesetsFiltrados { get; set; }
        public List<Merge> Merges { get; set; }

        private VersionControlServer _vcServer;
        private WorkspaceInfo _wsInfo;
        private Workspace _ws;


        private string _usuario;        
        public string Usuario
        {
            get
            {
                if (string.IsNullOrEmpty(_usuario))
                {
                    var config = ConfigurationManager.AppSettings["usuario"];
                    if (string.IsNullOrEmpty(config))
                    {
                        _usuario = Environment.UserDomainName + @"\" + Environment.UserName;
                        Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                        configuration.AppSettings.Settings["usuario"].Value = _usuario;
                        configuration.Save(ConfigurationSaveMode.Modified);
                        ConfigurationManager.RefreshSection("appSettings");
                    }
                    else
                    {
                        _usuario = config.ToString();
                    }                    
                }
                return _usuario;
            }
            set
            {
                _usuario = value;
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                configuration.AppSettings.Settings["usuario"].Value = _usuario;
                configuration.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
        }
        private string _collection;
        public string Collection
        {
            get
            {
                if (string.IsNullOrEmpty(_collection))
                {
                    var config = ConfigurationManager.AppSettings["collection"];
                    if (string.IsNullOrEmpty(config))
                    {
                        return "";
                    }
                    else
                    {
                        _collection = config.ToString();
                    }
                }
                return _collection;
            }
            set
            {
                _collection = value;
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                configuration.AppSettings.Settings["collection"].Value = _collection;
                configuration.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
        }
        private string _workspace;
        public string Workspace
        {
            get
            {
                if (string.IsNullOrEmpty(_workspace))
                {
                    var config = ConfigurationManager.AppSettings["workspace"];
                    if (string.IsNullOrEmpty(config))
                    {
                        return "";
                    }
                    else
                    {
                        _workspace = config.ToString();
                    }
                }
                return _workspace;
            }
            set
            {
                _workspace = value;
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                configuration.AppSettings.Settings["workspace"].Value = _workspace;
                configuration.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
        }
        private string _branchOrigem;
        public string BranchOrigem
        {
            get
            {
                if (string.IsNullOrEmpty(_branchOrigem))
                {
                    var config = ConfigurationManager.AppSettings["branchOrigem"];
                    if (string.IsNullOrEmpty(config))
                    {
                        return "";
                    }
                    else
                    {
                        _branchOrigem = config.ToString();
                    }
                }
                return _branchOrigem;
            }
            set
            {
                _branchOrigem = value;
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                configuration.AppSettings.Settings["branchOrigem"].Value = _branchOrigem;
                configuration.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
        }
        private string _branchDestino;
        public string BranchDestino
        {
            get
            {
                if (string.IsNullOrEmpty(_branchDestino))
                {
                    var config = ConfigurationManager.AppSettings["branchDestino"];
                    if (string.IsNullOrEmpty(config))
                    {
                        return "";
                    }
                    else
                    {
                        _branchDestino = config.ToString();
                    }
                }
                return _branchDestino;
            }
            set
            {
                _branchDestino = value;
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                configuration.AppSettings.Settings["branchDestino"].Value = _branchDestino;
                configuration.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
        }

        private string _caminhoTfExe;
        public string CaminhoTfExe
        {
            get
            {
                if (string.IsNullOrEmpty(_caminhoTfExe))
                {
                    var config = ConfigurationManager.AppSettings["caminhoTfExe"];
                    if (string.IsNullOrEmpty(config))
                    {
                        return "";
                    }
                    else
                    {
                        _caminhoTfExe = config.ToString();
                    }
                }
                return _caminhoTfExe;
            }
            set
            {
                _caminhoTfExe = value;
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                configuration.AppSettings.Settings["caminhoTfExe"].Value = _caminhoTfExe;
                configuration.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
        }

        public Tfs()
        {            
            ChangeSetsCandidatos = new List<ChangeSet>();
            ChangesetsFiltrados = new List<ChangeSet>();
            Merges = new List<Merge>();
        }

        public bool PossuiPendingChanges()
        {
            return ObterPendingChanges().Count() > 0;
        }
        public string[] ObterDesenvolvedores()
        {
            return ChangeSetsCandidatos.Select(d => d.NomeUsuario).OrderBy(e => e).Distinct().ToArray();
        }

        public async Task ObterChangeSetsCandidatos()
        {
            CarregaWorkspace();
            var candidates = await Task.Run(() =>
            {                
                return _vcServer.GetMergeCandidates(BranchOrigem, BranchDestino, RecursionType.Full);
            });

            var consulta = from a in candidates
                           orderby a.Changeset.CreationDate descending
                           select
                           new ChangeSet
                           {
                               Selecionado = false,
                               Id = a.Changeset.ChangesetId,
                               Data = a.Changeset.CreationDate,
                               CodigoUsuario = a.Changeset.Owner,
                               NomeUsuario = a.Changeset.OwnerDisplayName,
                               Comentario = a.Changeset.Comment
                           };

            ChangeSetsCandidatos = consulta.ToList();
            ChangesetsFiltrados = consulta.ToList();            
        }

        private void CarregaWorkspace()
        {
            CarregaServer();
            if (_wsInfo == null || _ws == null)
            {

                _wsInfo = Workstation.Current.GetLocalWorkspaceInfo(_vcServer, Workspace, Usuario);
                _ws = _vcServer.GetWorkspace(_wsInfo);
            }
        }

        private void CarregaServer()
        {
            if (_vcServer == null)
            {
                TfsTeamProjectCollection tpc = new TfsTeamProjectCollection(new Uri(Collection));
                _vcServer = tpc.GetService<VersionControlServer>();
            }
        }

        public string[] CarregaWorkspaces()
        {
            if (!string.IsNullOrEmpty(Usuario))
            {
                CarregaServer();
                return Workstation.Current.QueryLocalWorkspaceInfo(_vcServer, null, Usuario).Select(d => d.Name).ToArray();
            }
            else
            {
                return new string[] { };
            }
        }

        public void RollBackPendingChanges()
        {
            var pendingChanges = ObterPendingChanges();
            _ws.Undo(pendingChanges);
        }

        /// <summary>
        /// Realiza o merge do primeiro item da lista e retorna o resultado
        /// </summary>
        /// <returns></returns>
        public async Task<Tuple<string, bool>> RealizaMerges()
        {
            foreach (var item in Merges.Where(d => d.Finalizado == false))
            {
                Tuple<string, Exception> retorno = await Task.Run(() =>
                {
                    try
                    {
                        if (item.Conflitos > 0)
                        {
                            if (VerificaConflitos(item) > 0)
                            {
                                return new Tuple<string, Exception>(item.Mensagem, null);
                            }
                        }
                        else
                        {
                            RealizaMerge(item);                            
                            if (VerificaConflitos(item) > 0)
                            {

                                return new Tuple<string, Exception>(item.Mensagem, null);
                            }                            
                        }
                        item.Finalizado = true;
                        Checkin(item.Mensagem);
                        return new Tuple<string, Exception>("", null);
                    }
                    catch (Exception ex)
                    {
                        return new Tuple<string, Exception>("", ex);
                    }
                });

                if (!string.IsNullOrEmpty(retorno.Item1))
                    return new Tuple<string, bool>(retorno.Item1, true);
                if (retorno.Item2 != null)
                    throw retorno.Item2;
            }
            return new Tuple<string, bool>("", Merges.Where(d => d.Finalizado == false).Count() > 0);
        }

        private void Checkin(string mensagem)
        {
            var pendingChanges = ObterPendingChanges();
            if (pendingChanges.Count() > 0)
                _ws.CheckIn(pendingChanges, mensagem);
        }

        private PendingChange[] ObterPendingChanges()
        {
            return _ws.GetPendingChanges();
        }

        private void RealizaMerge(Merge merge)
        {
            string arguments = @"merge /version:C" + merge.IdChangeSetInicio.ToString() + "~" + merge.IdChangeSetFim.ToString() + " ";
            arguments += BranchOrigem + " ";
            arguments += BranchDestino + " ";
            arguments += @"/recursive";

            ProcessStartInfo info = new ProcessStartInfo();
            info.Arguments = arguments;
            info.FileName = "\"" + CaminhoTfExe + "\"";
            info.RedirectStandardError = true;
            info.UseShellExecute = false;

            Process process = new Process();
            process.StartInfo = info;
            process.Start();
            process.WaitForExit();
        }

        private int VerificaConflitos(Merge merge)
        {
            Conflict[] listaConflitos = _ws.QueryConflicts(null, true);
            var qtdConflitos = listaConflitos.Count();
            merge.Conflitos = qtdConflitos;
            return qtdConflitos;
        }

        public Task CarregaMerges()
        {
            return Task.Run(() =>
            {
                Merges = new List<Merge>();
                var selecionados = (from a in ChangesetsFiltrados
                                    where a.Selecionado
                                    orderby a.Data ascending
                                    select a).ToArray();

                var todos = ChangeSetsCandidatos.OrderBy(d => d.Data).ToArray();
                int index = 0;
                ChangeSet changesetDe = null;
                foreach (var item in selecionados)
                {

                    ChangeSet poximoSelecionados = null;
                    ChangeSet proximoTodos = null;

                    if (index < selecionados.Length - 1)
                    {
                        poximoSelecionados = selecionados[index + 1];

                        var objTodos = todos.Where(d => d.Id == item.Id).First();
                        var indiceTodos = Array.IndexOf(todos, objTodos);
                        proximoTodos = todos[indiceTodos + 1];
                    }

                    if (changesetDe == null)
                    {
                        changesetDe = item;
                        if (poximoSelecionados == null || poximoSelecionados.Id != proximoTodos.Id)
                        {
                            Merges.Add(new Merge
                            {
                                IdChangeSetInicio = item.Id,
                                IdChangeSetFim = item.Id,
                                Mensagem = "Merge: " + item.Id.ToString() + " - " + item.Id.ToString()
                            });
                            changesetDe = null;
                            index++;
                            continue;
                        }
                    }
                    else if (poximoSelecionados == null || poximoSelecionados.Id != proximoTodos.Id)
                    {
                        Merges.Add(new Merge
                        {
                            IdChangeSetInicio = changesetDe.Id,
                            IdChangeSetFim = item.Id,
                            Mensagem = "Merge: " + changesetDe.Id.ToString() + " - " + item.Id.ToString()
                        });
                        changesetDe = null;
                        index++;
                        continue;
                    }
                    index++;
                }
            });
        }

        public void InverterSelecao(bool marca)
        {
            foreach (var item in ChangesetsFiltrados)
            {
                item.Selecionado = marca;
            }            
        }

        public void FiltraPorUsuarios(string[] selecionados)
        {
            ChangesetsFiltrados = (from a in ChangeSetsCandidatos
                                   where selecionados.Contains(a.NomeUsuario)
                                   select a).ToList();
        }
    }
}
