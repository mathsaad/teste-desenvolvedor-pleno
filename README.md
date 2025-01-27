## **Passo a Passo para Rodar o Projeto**

### **1. Configurando o Back-end**
**Clonar o Repositório**
   ```bash
    git clone https://github.com/mathsaad/teste-desenvolvedor-pleno.git
    cd teste-desenvolvedor-pleno/backend/Products
  ````

Restaurar Dependências

```bash
    dotnet restore
 ``` 
Aplicar as Migrations Certifique-se de que o banco de dados está configurado e execute:

```bash
    dotnet ef database update
```
Rodar a API

```bash
    dotnet run
```
### **2. Configurando o Front-end**
   Ir para a Pasta do Front-end
```bash
    cd /Products.Presentation/Client/Products
```

Instalar Dependências Use Yarn ou NPM para instalar as dependências do React:
```bash
    # Com Yarn
    yarn install

    # Ou com NPM
    npm install
```

Rodar o Front-end Inicie o servidor de desenvolvimento:

```bash
# Com Yarn
yarn run dev

# Ou com NPM
npm run dev
```
