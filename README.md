# README - PaymentsAPI

```md
# TrezzeCloud.PaymentsAPI

Microsserviço responsável pelo processamento de pagamentos.

## Responsabilidades

- Consumo de OrderPlacedEvent
- Processamento de pagamento
- Publicação de PaymentProcessedEvent

---

# Tecnologias

- .NET 10
- ASP.NET Core
- RabbitMQ
- MassTransit
- Docker
- Kubernetes

---

# Variáveis de Ambiente

| Variável | Descrição |
|---|---|
| RabbitMq__Host | Host RabbitMQ |
| RabbitMq__Username | Usuário RabbitMQ |
| RabbitMq__Password | Senha RabbitMQ |

---

# Executar Localmente

```bash
dotnet restore
dotnet run
````

---

# Docker

```bash
docker build -t trezzecloud-payments-api .
```

---

# Kubernetes

Manifestos disponíveis em:

```txt
k8s/payments-api
```

````

---