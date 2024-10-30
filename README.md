# Portfolio de Ações

A API fornece endpoints para gravar compras e vendas de ações, recebimento de dividendos e acompanhar o histórico das transações realizadas. Esta API é implementada com .NET Core e segue os princípios RESTful.

## Estrutura do Projeto

- **Controllers**
  - `AcaoController`: Gerencia operações relacionadas a ações, como compra, venda, e dividendos.

## Endpoints da API

### 1. Comprar Ação

- **URL:** `/api/acao/compra`
- **Método:** `POST`
- **Parâmetros Query:**
  - `ticker` (string): O símbolo da ação.
  - `quantidade` (int): O número de ações a serem compradas.
  - `precoPorAcao` (decimal): O preço de cada ação.

- **Exemplo de Requisição:**
  ```http
  POST /api/acao/compra?ticker=ITSA4&quantidade=10&precoPorAcao=300.50
  ```

- **Resposta:**
  - 200 OK: Compra realizada com sucesso.

### 2. Vender Ação

- **URL:** /api/acao/venda
- **Método:** POST
- **Parâmetros Query:**
  - `ticker` (string): O símbolo da ação.
  - `quantidade` (int): O número de ações a serem vendidas.
  - `precoPorAcao` (decimal): O preço de cada ação.

- **Exemplo de Requisição:**
```http
POST /api/acao/venda?ticker=ITSA4&quantidade=5&precoPorAcao=305.75
```

- **Resposta:**
  - 200 OK: Venda realizada com sucesso.

### 3. Receber Dividendo

- **URL:** /api/acao/dividendo
- **Método:** POST
- **Parâmetros Query:**
  - `ticker` (string): O símbolo da ação.
  - `valorDividendo` (decimal): O valor do dividendo recebido.

- **Exemplo de Requisição:**
```http
POST /api/acao/dividendo?ticker=ITSA4&valorDividendo=50.00
```

- **Resposta:**
  - 200 OK: Dividendo registrado com sucesso.

### 4. Calcular Lucro ou Perda

- **URL:** /api/acao/lucro-ou-perda
- **Método:** GET
- **Parâmetros Query:**
  - `ticker` (string): O símbolo da ação.

- **Exemplo de Requisição:**
```http
GET /api/acao/lucro-ou-perda?ticker=ITSA4
```

- **Resposta:**
  - 200 OK: Retorna o lucro ou a perda para a ação especificada.

### 5. Obter Ações

- **URL:** /api/acao/acoes
- **Método:** GET

- **Exemplo de Requisição:**
```http
GET /api/acao/acoes
```

- **Resposta:**
  - 200 OK: Retorna a lista de ações registradas.

### 6. Obter Dividendos

- **URL:** /api/acao/dividendos
- **Método:** GET

- **Exemplo de Requisição:**
```http
GET /api/acao/dividendos
```

- **Resposta:**
  - 200 OK: Retorna a lista de dividendos recebidos.

### 7. Obter Transações

- **URL:** /api/acao/transacoes
- **Método:** GET

- **Exemplo de Requisição:**
```http
GET /api/acao/transacoes
```

- **Resposta:**
  - 200 OK: Retorna a lista de transações realizadas.


## Configuração

1. Clone o repositório:
git clone https://github.com/seu-usuario/seu-repositorio.git

2. Navegue até o diretório do projeto:
cd seu-repositorio

3. Restaure os pacotes do projeto:
dotnet restore

4. Execute o projeto:
dotnet run

5. A API estará disponível em http://localhost:5071 por padrão.

## Configurações Adicionais

Antes de executar a aplicação, você precisa configurar o Secret Manager para armazenar a string de conexão do banco de dados e a API key do Alpha Vantage. Siga as instruções abaixo:

### 1. Iniciar o Secret Manager

1. Abra um terminal ou prompt de comando.
2. Navegue até o diretório do seu projeto.

### 2. Adicionar a String de Conexão ao Secret Manager

1. Use o comando abaixo para adicionar a string de conexão ao Secret Manager:

 ```bash
 dotnet user-secrets set "ConnectionStrings:DefaultConnection" "SuaConnectionString"
 ```
Substitua o valor da string de conexão pelo valor adequado para o seu ambiente.

2. Adicione a API key do Alpha Vantage aos segredos do usuário:

```bash
dotnet user-secrets set "AlphaVantage:ApiKey" "SUA_API_KEY"
```
Substitua `SUA_API_KEY` pela chave da API que você pode obter [aqui](https://www.alphavantage.co/support/#api-key).

## Dependências

- [.NET 6.0 ou superior](https://dotnet.microsoft.com/download)

## Contribuição

Contribuições são bem-vindas! Para contribuir, siga as etapas abaixo:

1. Faça um fork do repositório.
2. Crie uma branch para a sua feature (`git checkout -b feature/MinhaFeature`).
3. Faça commit das suas alterações (`git commit -am 'Adiciona nova feature'`).
4. Faça push para a branch (`git push origin feature/MinhaFeature`).
5. Abra um Pull Request.

## Licença

Este projeto está licenciado sob a Licença MIT - consulte o [LICENSE](LICENSE) para detalhes.
