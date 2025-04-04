# API de Criação e Gerenciamento de Bancos de Dados em Containers Docker

Esta API foi desenvolvida para facilitar a criação e o gerenciamento de bancos de dados dentro de **containers Docker**. Utilizando o **Docker SDK** para integração com o Docker, esta API permite criar e gerenciar containers para os bancos de dados PostgreSQL e MongoDB de forma dinâmica. O projeto foi implementado utilizando .NET 9 e expõe sua documentação com **Scalar** no lugar do **Swagger**.

---

## 📲 Funcionalidades

- Criação de containers Docker com **PostgreSQL** e **MongoDB**.
- Configuração de variáveis como nome do banco de dados, usuário e senha.
- Exposição de informações sobre o container criado, como o número da porta do banco.
- Gerenciamento eficiente de containers utilizando o **Docker SDK**.
- Documentação da API gerada dinamicamente utilizando **Scalar**.

---

## ⚒️ Tecnologias Utilizadas

- **ASP.NET Core 9** (Minimal APIs)
- **Docker SDK** (Docker.DotNet) para interação com a API do Docker
- **Scalar** para documentação da API
- **Docker** para a criação e gerenciamento de containers

---

## 📋 Pré-requisitos

Antes de executar este projeto, você precisará garantir que tenha os seguintes pré-requisitos instalados:
- **Docker**: Para criar e gerenciar containers Docker.
- **.NET 9 SDK**: A API foi desenvolvida com .NET 9, sendo necessário ter o SDK dessa versão ou superior para rodar o projeto.
- **Ferramenta de cliente para Docker** (opcional): Como o Docker Desktop ou outro cliente Docker de sua escolha.

---

## Como Funciona

### 1. Gerenciamento de Containers com Docker SDK

Esta API utiliza o **Docker SDK** (com a biblioteca **Docker.DotNet**) para realizar a interação com a API do Docker, permitindo que você crie containers dinamicamente com diferentes tipos de bancos de dados: **PostgreSQL** e **MongoDB**. O SDK facilita a comunicação com o Docker, permitindo criar, gerenciar e obter informações sobre containers diretamente da aplicação.

Quando você faz uma requisição `POST` para criar um novo container, a API utiliza o Docker SDK para executar o comando que cria o container do banco de dados desejado (PostgreSQL ou MongoDB), configurando-o conforme as especificações fornecidas (usuário, senha, nome do banco, etc).

### 2. Implementação com .NET 9

A aplicação foi construída utilizando **.NET 9**, que traz várias melhorias de performance, segurança e novos recursos para otimização do desenvolvimento. O uso de **Minimal APIs** permite criar uma estrutura de endpoints simples e direta, com o mínimo de boilerplate, facilitando a manutenção e escalabilidade da aplicação.

### 3. Documentação com Scalar

Ao invés de utilizar o **Swagger**, a documentação da API é gerada dinamicamente com **Scalar**. O Scalar permite expor a documentação da API de maneira interativa e personalizada. Você pode visualizar todos os endpoints disponíveis, seus parâmetros e tipos de resposta, e até mesmo realizar chamadas diretamente da interface do Scalar.

---

## 📫 Como Contribuir

Se você deseja contribuir para o desenvolvimento deste projeto, siga os passos abaixo:

1. **Fork o repositório**: Faça um fork do repositório para sua própria conta no GitHub.
   
2. **Crie uma branch**: Crie uma nova branch para a sua feature ou correção. Utilize o comando:
   ```bash
   git checkout -b feature/nova-funcionalidade

3. **Faça suas alterações**: Implemente a funcionalidade ou correção desejada.

   - **Adicione novos recursos**: Implemente novos endpoints, funcionalidades ou melhore as existentes.
   - **Corrija bugs**: Se você encontrou um bug, tente corrigi-lo antes de enviar o pull request.
   - **Escreva testes**: Se possível, adicione testes para garantir que as alterações não quebrem funcionalidades existentes.
   - **Siga os padrões de código**: Mantenha o estilo de código consistente com o do projeto. Use identação de 4 espaços e sempre prefira legibilidade.

4. **Commit as alterações**: Após realizar as modificações, faça o commit das suas alterações com uma mensagem clara e objetiva. Por exemplo:

   ```bash
   git commit -am 'Adiciona nova funcionalidade de gerenciamento de containers'

Mensagens de commit devem ser curtas, claras e no tempo presente, descrevendo a mudança feita. Exemplos:
- "Adiciona endpoint para criação de containers"
- "Corrige erro na listagem de containers"
- "Melhora a validação de parâmetros no endpoint de criação"

Certifique-se de que cada commit seja focado em uma única mudança ou correção, para facilitar o entendimento e a revisão.

---

5. **Push para o repositório remoto**: Após realizar o commit das suas alterações, envie as modificações para o seu repositório no GitHub:

   ```bash
   git push origin feature/nova-funcionalidade

Isso vai atualizar o seu fork no GitHub com as alterações feitas.

6. **Abra um Pull Request (PR)**: Vá até o seu repositório no GitHub e abra um Pull Request para o repositório original. No PR, forneça uma descrição detalhada do que foi alterado e o porquê. Isso ajuda na revisão e no entendimento das mudanças feitas.

   - **Título**: Mantenha o título do PR claro e objetivo.
   - **Descrição**: Explique o que foi alterado, por que a alteração foi necessária e se há algo mais a ser considerado. Se o PR estiver resolvendo um problema específico ou adicionando uma nova funcionalidade, mencione isso na descrição.

   Um exemplo de descrição de PR poderia ser:
   ```markdown
   ### Descrição
   Adiciona um novo endpoint `GET /containers` para listar todos os containers em execução e suas respectivas portas.

   ### Como testar
   1. Crie um novo container utilizando o endpoint `POST /create-container`.
   2. Faça uma requisição `GET /containers` para obter a lista de containers.
   3. Verifique se o retorno inclui as informações corretas.

   ### Relacionado
   - Issue #42: Adicionar endpoint para listar containers.
   
- Issue #42: Adicionar endpoint para listar containers.

Após abrir o Pull Request, o repositório será analisado pelos mantenedores do projeto, que revisarão suas mudanças. Caso tudo esteja correto, o PR será aprovado e mesclado ao repositório principal.

---

## 📃 Licença
Este projeto está licenciado sob a MIT License.
