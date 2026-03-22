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
