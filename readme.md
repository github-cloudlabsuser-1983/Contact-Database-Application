# Web Application Readme

This readme file provides information about the web application and its deployment process.

## Build

To build the web application, follow these steps:

1. Clone the repository to your local machine.
2. Open a terminal or command prompt and navigate to the project directory.
3. Run the following command to install the required dependencies:

    ```
    npm install
    ```

4. Once the dependencies are installed, run the following command to build the application:

    ```
    npm run build
    ```

## Infrastructure Deployment with Azure CLI

To deploy the infrastructure using Azure CLI and the `infra\azuredeploy.json` file, follow these steps:

1. Make sure you have the Azure CLI installed on your machine.
2. Open a terminal or command prompt and navigate to the project directory.
3. Run the following command to log in to your Azure account:

    ```
    az login
    ```

4. Run the following command to set the subscription where you want to deploy the infrastructure:

    ```
    az account set --subscription <subscription-id>
    ```

5. Run the following command to deploy the infrastructure:

    ```
    az deployment group create --resource-group <resource-group-name> --template-file infra/azuredeploy.json
    ```

    Replace `<resource-group-name>` with the name of the resource group where you want to deploy the infrastructure.

## GitHub Actions

This web application uses GitHub Actions for continuous integration and deployment. The workflow is defined in the `.github/workflows/main.yml` file. It includes the following steps:

1. Checkout the repository.
2. Set up Node.js environment.
3. Install dependencies.
4. Build the application.
5. Deploy the application to the specified environment.

The workflow is triggered on every push to the `main` branch.
