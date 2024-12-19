## Vertical Slice Architecture

A **Vertical Slice Architecture** é uma abordagem arquitetural que organiza a aplicação em "fatias verticais" independentes, onde cada fatia representa um caso de uso ou funcionalidade completa. Essa arquitetura prioriza o isolamento e a modularidade, agrupando todas as partes necessárias (como lógica de negócios, acesso a dados, e endpoints) dentro de uma única fatia, ao invés de separá-las em camadas horizontais (ex.: controllers, serviços, repositórios).

### Características principais:
- **Isolamento por funcionalidade**: Cada fatia é independente e contém tudo o que é necessário para implementar um caso de uso.
- **Foco em casos de uso**: As fatias são organizadas com base nas funcionalidades da aplicação, e não por camadas técnicas.
- **Facilidade de manutenção e testes**: Como as fatias são autossuficientes, alterações ou testes podem ser feitos de forma isolada, sem impactar o restante do sistema.
- **Baixo acoplamento**: Cada fatia tem dependências mínimas em relação a outras, facilitando a escalabilidade e a evolução do projeto.

### Estrutura típica de uma Vertical Slice:
Uma fatia típica pode incluir:
- **Handler**: O ponto de entrada do caso de uso.
- **Request/Response Models**: Modelos específicos para entrada e saída de dados.
- **Lógica de Negócios**: Regras específicas da funcionalidade.
- **Acesso a Dados**: Repositórios ou serviços relacionados ao armazenamento.

Exemplo de estrutura para a funcionalidade "Criar Pedido":

- Features/
  - CriarPedido/
    - CriarPedidoCommand.cs
    - CriarPedidoHandler.cs
    - CriarPedidoResponse.cs
    - CriarPedidoValidator.cs
    - CriarPedidoRepository.cs


### Vantagens:
- **Organização modular**: Facilita a navegação e o entendimento do código.
- **Escalabilidade**: Novas funcionalidades podem ser adicionadas sem impacto significativo no restante do sistema.
- **Entrega de valor**: Foco em implementar casos de uso completos, do início ao fim.
- **Aproximação ao DDD**: Segue uma estrutura próxima ao **Domain-Driven Design**, onde cada fatia reflete um agregado ou caso de uso do domínio.

### Quando usar:
A Vertical Slice Architecture é ideal para projetos com requisitos complexos, onde as funcionalidades são bem definidas e independentes, e quando há necessidade de manter o sistema modular e escalável. Também é comumente usada em conjunto com padrões como **CQRS** (Command Query Responsibility Segregation) e **Event-Driven Design**.

---
