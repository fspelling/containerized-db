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

---

## 📃 Licença
Este projeto está licenciado sob a MIT License.
