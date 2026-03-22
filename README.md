# Mediator
Repositório criado para postar a Documentação e aplicação sobre o método de Mediator para desenvolver uma aplicação.

## 1. Introdução e Contextualização

O padrão de projeto **Mediator** é classificado pelo *Gang of Four (GoF)* como um **padrão comportamental**. Isso significa que a sua principal preocupação não é como as partes do sistema são criadas, mas sim como elas se comportam, interagem e trocam informações entre si enquanto o software está rodando.
Seu objetivo central é **organizar e simplificar a comunicação** entre múltiplos objetos de um sistema. Em aplicações normais, é comum que os componentes tentem conversar diretamente uns com os outros, o que rapidamente cria uma teia confusa de dependências. 
O Mediator resolve isso proibindo essa comunicação direta e introduzindo um **"objeto central"**, que passa a ser o único responsável por receber e repassar as informações.

## 2. Características Principais do Mediator

Para compreender o verdadeiro impacto do padrão **Mediator** na organização do nosso código, precisamos olhar para as suas propriedades fundamentais. Ele atua como um verdadeiro "maestro" do sistema, resolvendo a bagunça que seria a comunicação direta entre as peças da interface (como botões e listas). 

A eficácia desse padrão no dia a dia da programação se baseia nas seguintes características essenciais:

* **Comunicação Centralizada:** Em vez de os componentes conversarem entre si (o que gera confusão), todos enviam e recebem mensagens através de um único ponto central (o Mediador).
* **Baixo Acoplamento:** Como os componentes (botões, listas, etc.) não precisam de saber da existência uns dos outros, eles ficam independentes. Apenas conhecem o Mediador.
* **Regras de Negócio num só lugar:** A lógica de como o ecrã ou o sistema deve reagir a uma ação fica concentrada apenas na classe do Mediador, e não espalhada por vários ficheiros.

---

## 3. Vantagens e Desvantagens

Como na área de desenvolvimento de software não existe uma "bala de prata" (uma solução perfeita para tudo), o Mediator tem os seus prós e contras:

### ✅ Vantagens:
* **Facilidade de Manutenção:** Como os componentes estão separados, alterar um botão ou uma lista não "quebra" as outras partes do código.
* **Reutilização:** Fica muito mais fácil pegar num componente (como uma barra de pesquisa) e usá-lo noutro ecrã do sistema, pois ele não está "agarrado" a outros elementos.
* **Adição de Novos Elementos:** É muito simples adicionar novos componentes ao sistema; basta ligá-los ao Mediador, sem precisar de reescrever o código dos componentes antigos.

### ⚠️ Desvantagens:
* **O "God Object" (Objeto Deus):** Este é o maior risco do Mediator. Se o sistema crescer demasiado e o programador não tiver cuidado, a classe do Mediador torna-se num "monstro" gigante e super complexo que sabe fazer de tudo. Se o Mediador tiver milhares de linhas de código, torna-se um pesadelo para manter.
* **Complexidade Inicial:** Para ecrãs ou sistemas muito simples, criar interfaces, componentes e uma classe mediadora é escrever código a mais sem necessidade.

## 4. O Problema

Para entender a verdadeira necessidade do Mediator, imagine um cenário muito comum na vida de qualquer programador: a criação de uma **Tela de Cadastro de Clientes** usando WPF ou Windows Forms. Nessa tela, você tem alguns elementos visuais básicos:

* Uma lista (como um *DataGrid*) exibindo os clientes cadastrados.
* Caixas de texto (*TextBox*) para visualizar e editar os dados.
* Botões de ação, como "Salvar" e "Excluir".

Se programamos essa tela do jeito "tradicional", fazendo as ligações de forma direta, a lógica do sistema vai ficar completamente espalhada. Pense no fluxo:
1. Quando o usuário clica em um cliente na lista, o código dessa lista precisa acessar diretamente as caixas de texto para preenchê-las e, logo em seguida, ir até o botão "Excluir" para ativá-lo.
2. Da mesma forma, assim que alguém digita qualquer coisa em uma caixa de texto, ela precisa "avisar" o botão "Salvar" para que ele fique clicável.
3. E, por fim, quando o botão "Salvar" é pressionado, ele próprio tem a obrigação de limpar os campos de texto e mandar a lista se atualizar.

O grande perigo do **alto acoplamento** é que o código vira um verdadeiro **"prato de espaguete"**: se puxa um fio, a macarronada toda vem junto. Se amanhã o cliente pedir para adicionar um simples botão de "Novo Cliente", você terá que abrir e alterar o código da lista, das caixas de texto e dos outros botões para ensiná-los a interagir com essa nova peça. Isso torna o sistema péssimo para dar manutenção e aumenta drasticamente as chances de criar novos *bugs* toda vez que uma alteração é feita.

---

## 5. A Solução

Para resolver o problema do "código espaguete" e do alto acoplamento, o padrão **Mediator** propõe uma solução radical, mas muito inteligente: **proibir totalmente que os componentes da tela conversem entre si**. Na arquitetura do Mediator, todas as ligações diretas são cortadas. 

A solução consiste em criar uma **nova classe central**, que chamamos de Mediador. A partir desse momento, os componentes da nossa tela passam a conhecer apenas e exclusivamente a interface do Mediador.

Com essa mudança, a arquitetura do sistema deixa de ser uma teia bagunçada e passa a ter o formato de uma **"estrela"**, onde todas as informações convergem para o centro. Isso garante organização, previsibilidade e torna muito mais fácil descobrir onde um erro está acontecendo, já que toda a lógica de comunicação está em um único lugar.
