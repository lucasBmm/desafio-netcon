# Projeto de Desafio de Software

Este é o desafio proposto pela Netcon Américas para vaga de Estágio - Desenvolvimento - Analista de Sistemas.

## Descrição

O objetivo deste projeto é criar uma aplicação que faça a conversão de anos luz e quilômetros e vice versa.
Apesar de no desafio inicial me ter parecido se tratarem de duas aplicações diferentes, achei que seria mais interessante parecido com um cenário de um projeto real fazer essas duas aplicações terem uma comunicação entre si.
A abordagem que tomei foi de criar um micro frontend com PHP e a API REST em .NET.
Também achei que seria muito mais prático rodar essas aplicações em containers Docker e as conectar com Docker Compose para descomplicar o ambiente de desenvolvimento e também para a minha aplicação ser mais rápida e fácil de testar.

## Configuração do Ambiente

1. **Pré-requisitos:**
   - [Docker](https://www.docker.com/get-started)
   - [Visual Studio](https://visualstudio.microsoft.com/) 

2. **Instruções:**
    - Clone o repositório: ```git clone https://github.com/lucasBmm/desafio-netcon```
   - Importe a aplicação no Visual Studio em Arquivo->Abrir->Projeto/Solução->./"pastaDoProjeto"/backend-netcon.sln
   - Executar o "Docker Compose"
   - Será aberto automaticamente o Swagger da aplicação .NET
   - O frontend PHP ficará disponível em http://localhost 

### Observações Importantes:

- Ao utilizar Docker, as configurações de ambiente são tratadas automaticamente, proporcionando um ambiente isolado e fácil de configurar.