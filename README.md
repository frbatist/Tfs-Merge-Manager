# Tfs-Merge-Manager
Ferramenta para realizar mesclagem de changesets de um branch para outro utilizando o TFVC.


Foi desenvolvido tendo como base o pacote TeamFoundationServer.Client - https://www.visualstudio.com/pt-br/docs/integrate/get-started/client-libraries/dotnet

Este pacote fornece uma serie de apis para realizar diversas operações no TFS, eu no caso, utilizei para buscar os changesets candidatos a mesclagem entre um changeset e outro.

Eu desenvolvi para o meu dia-a-dia então, podem encontrar quebras de padrão de projeto, code smells e etc. São todos bem-vindos a submeter um pull request com melhorias ;).

O uso é bem simplificado a tela principal pede tudo que é necessário:
- Usuário do tfs - que pode ser o usuário de rede ou o login do team services (não testei nesse ambiente);
- Collection;
- Workspace - Ele busca as workspaces do usuário na collection;
- Branch de origem e destino;
- Caminho do tf.exe - Isso eu quero melhorar, utilizo o tf.exe para rodar o merge propriamente dito, o comando da dll não resolve os conflitos automáticamente, e com a opção que resolve, ele não traz os conflitos que deveriam ter decisção de mesclagem. Por isso uso o comando para realizar a mesclagem, quero fazer mais testes para ver se consigo o efeito desejado pelas apis do pacote.

Clicando em mesclar, ele vai agrupar os changesets e separar em merges distintos (se um changeset for adjacente ao outro, pode ser mesclado junto);
Depois basta confirmar, e ele vai fazer os merges e checkins, se encontrar conflitos, vai interromper a operação para que o usuário resolva os conflitos e retome a operação.

Estou aberto a criticas, sugestões e pull requests.
