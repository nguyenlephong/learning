# Azure CLI

> Bash script support start stop VM


## Commands

```bash
az --version
az login
az account list --output table

az vm list -o table
az account set --subscription "MyResourceGroup"

az vm start -g MyResourceGroup -n MyVm


az vm stop -g MyResourceGroup -n MyVm


az vm restart -g MyResourceGroup -n MyVm

```