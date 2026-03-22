# Mediator
Repositório criado para postar a Documentação e aplicação sobre o método de Mediator para desenvolver uma aplicação.

## 1. Introdução e Contextualização

O padrão de projeto **Mediator** é classificado pelo *Gang of Four (GoF)* como um **padrão comportamental**. Isso significa que a sua principal preocupação não é como as partes do sistema são criadas, mas sim como elas se comportam, interagem e trocam informações entre si enquanto o software está rodando.
Seu objetivo central é **organizar e simplificar a comunicação** entre múltiplos objetos de um sistema. Em aplicações normais, é comum que os componentes tentem conversar diretamente uns com os outros, o que rapidamente cria uma teia confusa de dependências. 
O Mediator resolve isso proibindo essa comunicação direta e introduzindo um **"objeto central"**, que passa a ser o único responsável por receber e repassar as informações.
