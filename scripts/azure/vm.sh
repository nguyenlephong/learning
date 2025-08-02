#!/bin/bash

# ===========================
# Script: azure-vm.sh
# Chức năng: Start Azure VM, SSH vào, chạy lệnh
# ===========================

# ---- Cấu hình mặc định ----
RESOURCE_GROUP=""
VM_NAME=""
SSH_USER=""
SSH_KEY="$HOME/az-ssh-key.pem"
REMOTE_CMD=""                # Lệnh mặc định khi SSH vào

# ---- Hàm hiển thị hướng dẫn ----
show_help() {
  cat << EOF
Usage: $(basename "$0") [options] [remote_command]

Options:
  -g, --group     Azure Resource Group (default: $RESOURCE_GROUP)
  -n, --name      Azure VM Name (default: $VM_NAME)
  -u, --user      SSH username (default: $SSH_USER)
  -k, --key       SSH private key path (default: $SSH_KEY)
  -h, --help      Show this help message

Examples:
  $(basename "$0")                      # Start VM, SSH vào
  $(basename "$0") "ls -la"              # Start VM, SSH vào, chạy 'ls -la'
  $(basename "$0") -g rg1 -n vm2 "uptime"
EOF
}

# ---- Parse tham số ----
while [[ $# -gt 0 ]]; do
  case "$1" in
    -g|--group) RESOURCE_GROUP="$2"; shift 2;;
    -n|--name)  VM_NAME="$2"; shift 2;;
    -u|--user)  SSH_USER="$2"; shift 2;;
    -k|--key)   SSH_KEY="$2"; shift 2;;
    -h|--help)  show_help; exit 0;;
    *) REMOTE_CMD="$1"; shift;;
  esac
done

# ---- Bắt đầu VM ----
echo "🔄 Starting VM: $VM_NAME in group: $RESOURCE_GROUP ..."
az vm start --resource-group "$RESOURCE_GROUP" --name "$VM_NAME" >/dev/null

# ---- Lấy IP public ----
echo "🔍 Getting public IP..."
IP=$(az vm show -d -g "$RESOURCE_GROUP" -n "$VM_NAME" --query publicIps -o tsv)

if [[ -z "$IP" ]]; then
  echo "❌ Could not get public IP."
  exit 1
fi

echo "🌐 VM IP: $IP"

# ---- SSH vào VM ----
if [[ -n "$REMOTE_CMD" ]]; then
  echo "▶ Running remote command: $REMOTE_CMD"
  ssh -t -i "$SSH_KEY" "$SSH_USER@$IP" "$REMOTE_CMD"
else
  echo "💻 Connecting to SSH..."
  ssh -t -i "$SSH_KEY" "$SSH_USER@$IP"
fi