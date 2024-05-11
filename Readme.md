# Utilizando User-Secrets
## Armazena dados sensíveis para utilizá-los em ambiente de desenvolvimento.

### Iniciando User Secrets
*dotnet user-secrets init*

### Incluindo varial
*dotnet user-secrets set "Nome da chave" "Valor"*

### Utilizando 
- Implementamos a chamda para IConfiguration 
-		E chamamos (_config["Nome da Chava"])